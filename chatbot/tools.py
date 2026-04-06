import httpx
import os
from typing import Optional, List, Dict, Any

# C# Backend Base URL (Adjust to match your dev environment)
BASE_URL = os.getenv("BACKEND_API_URL", "https://localhost:7290/api/chatbot")

async def search_products(q: Optional[str] = None, category: Optional[str] = None, sort: Optional[str] = None, min_price: Optional[float] = None, max_price: Optional[float] = None) -> List[Dict[str, Any]]:
    """
    Tìm kiếm sản phẩm theo tên, danh mục, sắp xếp hoặc khoảng giá.
    """
    params = {}
    if q: params["q"] = q
    if category: params["category"] = category
    if sort: params["sort"] = sort
    if min_price: params["minPrice"] = min_price
    if max_price: params["maxPrice"] = max_price
    
    async with httpx.AsyncClient(verify=False, follow_redirects=True) as client:
        try:
            response = await client.get(f"{BASE_URL}/products", params=params)
            response.raise_for_status()
            data = response.json()
            items = data.get("items", [])
            total_count = data.get("totalCount", 0)
            if not items:
                return [{"status": "empty", "message": "No matching products found."}]
            return [{"status": "success", "total_found_in_db": total_count, "items_shown_here": len(items), "items": items}]
        except Exception as e:
            return [{"status": "error", "message": str(e)}]

async def get_product_details(product_id: int) -> Dict[str, Any]:
    """
    Lấy thông tin chi tiết của một sản phẩm cụ thể bao gồm các phân loại (SKUs).
    """
    async with httpx.AsyncClient(verify=False, follow_redirects=True) as client:
        try:
            response = await client.get(f"{BASE_URL}/products/{product_id}")
            response.raise_for_status()
            return response.json()
        except Exception as e:
            return {"error": f"Lỗi khi lấy chi tiết sản phẩm: {str(e)}"}

async def track_order(order_code: str) -> Dict[str, Any]:
    """
    Kiểm tra trạng thái đơn hàng dựa trên mã vận đơn (Order Code).
    """
    async with httpx.AsyncClient(verify=False, follow_redirects=True) as client:
        try:
            response = await client.get(f"{BASE_URL}/track-order/{order_code}")
            if response.status_code == 404:
                return {"message": "Không tìm thấy mã đơn hàng này."}
            response.raise_for_status()
            return response.json()
        except Exception as e:
            return {"error": f"Lỗi khi tra cứu đơn hàng: {str(e)}"}

async def list_active_vouchers() -> List[Dict[str, Any]]:
    """
    Lấy danh sách các mã giảm giá (vouchers) đang hoạt động.
    """
    async with httpx.AsyncClient(verify=False, follow_redirects=True) as client:
        try:
            response = await client.get(f"{BASE_URL}/vouchers")
            response.raise_for_status()
            return response.json()
        except Exception as e:
            return [{"error": f"Lỗi khi lấy danh sách voucher: {str(e)}"}]

async def get_store_policies() -> Dict[str, str]:
    """
    Truy xuất hệ thống nội quy (Knowledge Base) của cửa hàng: bao gồm địa chỉ, thông tin liên hệ, chính sách đổi trả, phí ship, và hướng dẫn bảo quản.
    Sử dụng tool này NẾU người dùng hỏi các câu hỏi KHÔNG PHẢI VỀ SẢN PHẨM MÀ VỀ DỊCH VỤ HOẶC CỬA HÀNG (ví dụ: địa chỉ ở đâu, trả hàng thế nào, phí ship bao nhiêu).
    """
    file_path = os.path.join(os.path.dirname(__file__), "database_knowledge", "policies.md")
    try:
        with open(file_path, "r", encoding="utf-8") as f:
            content = f.read()
            return {"status": "success", "content": content}
    except Exception as e:
        return {"status": "error", "message": f"Could not read policies: {str(e)}"}
