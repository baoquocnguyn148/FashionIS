import httpx
import os
import logging
from typing import Optional, List, Dict, Any

logger = logging.getLogger(__name__)

# C# Backend Base URL
BASE_URL = os.getenv("BACKEND_API_URL", "https://fashion-store-web.onrender.com/api/chatbot")
if not BASE_URL.endswith("/api/chatbot") and not BASE_URL.endswith("/api/chatbot/"):
    BASE_URL = BASE_URL.rstrip("/") + "/api/chatbot"

logger.info(f"[Tools] Backend API URL: {BASE_URL}")

# Shared HTTP client config — 15s timeout prevents hanging requests
_HTTP_TIMEOUT = httpx.Timeout(15.0, connect=10.0)

async def search_products(
    q: Optional[str] = None,
    category: Optional[str] = None,
    sort: Optional[str] = None,
    min_price: Optional[float] = None,
    max_price: Optional[float] = None
) -> List[Dict[str, Any]]:
    """Search for products by name, category, sort order, or price range."""
    params = {}
    if q:         params["q"] = q
    if category:  params["category"] = category
    if sort:      params["sort"] = sort
    if min_price is not None: params["minPrice"] = int(min_price)
    if max_price is not None: params["maxPrice"] = int(max_price)

    logger.info(f"[Tools] search_products called with params: {params}")

    try:
        async with httpx.AsyncClient(verify=False, follow_redirects=True, timeout=_HTTP_TIMEOUT) as client:
            response = await client.get(f"{BASE_URL}/products", params=params)
            response.raise_for_status()
            data = response.json()
            items = data.get("items", [])
            total_count = data.get("totalCount", 0)
            if not items:
                return [{"status": "empty", "message": "No matching products found in the database."}]
            return [{"status": "success", "total_found_in_db": total_count, "items_shown_here": len(items), "items": items}]
    except httpx.TimeoutException:
        logger.error("[Tools] search_products timed out")
        return [{"status": "error", "message": "Request timed out when contacting the product database."}]
    except Exception as e:
        logger.error(f"[Tools] search_products error: {e}")
        return [{"status": "error", "message": str(e)}]


async def get_product_details(product_id: int) -> Dict[str, Any]:
    """Get detailed info of a specific product including SKUs and variants."""
    logger.info(f"[Tools] get_product_details called for product_id={product_id}")
    try:
        async with httpx.AsyncClient(verify=False, follow_redirects=True, timeout=_HTTP_TIMEOUT) as client:
            response = await client.get(f"{BASE_URL}/products/{product_id}")
            response.raise_for_status()
            return response.json()
    except httpx.TimeoutException:
        return {"error": "Timed out fetching product details."}
    except Exception as e:
        return {"error": f"Lỗi khi lấy chi tiết sản phẩm: {str(e)}"}


async def track_order(order_code: str) -> Dict[str, Any]:
    """Check an order's status using its order code (e.g. HD1234)."""
    logger.info(f"[Tools] track_order called for order_code={order_code}")
    try:
        async with httpx.AsyncClient(verify=False, follow_redirects=True, timeout=_HTTP_TIMEOUT) as client:
            response = await client.get(f"{BASE_URL}/track-order/{order_code}")
            if response.status_code == 404:
                return {"message": "Không tìm thấy mã đơn hàng này. Vui lòng kiểm tra lại."}
            response.raise_for_status()
            return response.json()
    except httpx.TimeoutException:
        return {"error": "Timed out while tracking order."}
    except Exception as e:
        return {"error": f"Lỗi khi tra cứu đơn hàng: {str(e)}"}


async def list_active_vouchers() -> List[Dict[str, Any]]:
    """Get the list of currently active discount vouchers and promotions."""
    logger.info("[Tools] list_active_vouchers called")
    try:
        async with httpx.AsyncClient(verify=False, follow_redirects=True, timeout=_HTTP_TIMEOUT) as client:
            response = await client.get(f"{BASE_URL}/vouchers")
            response.raise_for_status()
            return response.json()
    except httpx.TimeoutException:
        return [{"error": "Timed out fetching vouchers."}]
    except Exception as e:
        return [{"error": f"Lỗi khi lấy danh sách voucher: {str(e)}"}]


async def get_store_policies() -> Dict[str, str]:
    """
    Get the store's knowledge base: address, contact, return policy, shipping fees, and care instructions.
    Use this ONLY when user asks about store operations, NOT when searching for products.
    """
    file_path = os.path.join(os.path.dirname(__file__), "database_knowledge", "policies.md")
    try:
        with open(file_path, "r", encoding="utf-8") as f:
            content = f.read()
            return {"status": "success", "content": content}
    except Exception as e:
        return {"status": "error", "message": f"Could not read policies: {str(e)}"}


async def get_categories() -> List[Dict[str, Any]]:
    """
    Get the full list of product categories in the store (Name + Slug).
    Use this when you are unsure which category the user is asking about.
    """
    logger.info("[Tools] get_categories called")
    try:
        async with httpx.AsyncClient(verify=False, follow_redirects=True, timeout=_HTTP_TIMEOUT) as client:
            response = await client.get(f"{BASE_URL}/categories")
            response.raise_for_status()
            return response.json()
    except httpx.TimeoutException:
        return [{"error": "Timed out fetching categories."}]
    except Exception as e:
        return [{"error": f"Lỗi khi lấy danh mục: {str(e)}"}]
