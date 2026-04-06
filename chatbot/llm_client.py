from langchain_openai import ChatOpenAI
from langchain_core.tools import tool
from langgraph.prebuilt import create_react_agent
from langchain_core.messages import SystemMessage
import os
import tools as api_tools

# LM Studio Configuration
LM_STUDIO_URL = os.getenv("LM_STUDIO_URL", "http://127.0.0.1:1234/v1")
MODEL_NAME = os.getenv("LLM_MODEL", "local-model")

# Define LangChain Tools
@tool
async def search_products_tool(query: str = None, category: str = None, sort: str = None, min_price: float = None, max_price: float = None):
    """
    Tool to search for products in the store or to get the full list of products.
    
    EXTREMELY IMPORTANT RULES FOR 4B/8B MODELS:
    1. INTENTION SEPARATION: If the user asks a general question like "bạn có sản phẩm gì", "có bao nhiêu sản phẩm" or "xem tất cả", you MUST leave all parameters (including `query`) EMPTY (None). Do NOT put conversational phrases into the `query` field.
    2. TRANSLATE TO ENGLISH: Our clothing database uses English names. If the user searches in Vietnamese (e.g., "trắng", "đen", "áo", "quần", "áo khoác"), YOU MUST translate it to English (e.g., "white", "black", "shirt", "pants", "jacket") before putting it into the `query` field. NEVER search using Vietnamese words!
    3. If the user asks for a specific combination, use `query` (e.g. user says "áo trắng", set query="white shirt").
    
    Parameters:
    - query: Specific search terms IN ENGLISH ONLY (e.g., 'white shirt', 'polo'). If the user just wants to see all products, leave this EMPTY/None.
    - category: The product category ('tops', 'pants', 'outerwear', 'accessories').
    - sort: 'popular', 'newest', 'price_low', 'price_high'.
    - min_price: Integer minimum price.
    - max_price: Integer maximum price.
    """
    return await api_tools.search_products(q=query, category=category, sort=sort, min_price=min_price, max_price=max_price)

@tool
async def get_product_details_tool(product_id: int):
    """
    Get in-depth details of a specific product using its ID, including stock and variants.
    """
    return await api_tools.get_product_details(product_id)

@tool
async def track_order_tool(order_code: str):
    """
    Check the status of a user's order. DO NOT guess the order code.
    You MUST ask the user for their order code (e.g. 'HD1234') before calling this tool.
    """
    return await api_tools.track_order(order_code)

@tool
async def get_vouchers_tool():
    """
    Check for active discount vouchers and promotions available for the store.
    """
    return await api_tools.list_active_vouchers()

@tool
async def get_store_policies_tool():
    """
    Truy xuất nội quy cửa hàng (địa chỉ, chính sách đổi trả, phí ship, bảo quản).
    CHỈ DÙNG khi khách hỏi thông tin vận hành của cửa hàng.
    TUYỆT ĐỐI KHÔNG DÙNG tool này nếu khách hỏi TÌM MUA quần áo, hỏi giá, hoặc hỏi xem sản phẩm.
    """
    return await api_tools.get_store_policies()

# Setup LLM and Agent
def get_chatbot_agent():
    llm = ChatOpenAI(
        base_url=LM_STUDIO_URL,
        api_key="lm-studio", # LM Studio doesn't require a strict key, but it needs something
        model=MODEL_NAME,
        temperature=0.7,
        streaming=True
    )
    
    tools_list = [search_products_tool, get_product_details_tool, track_order_tool, get_vouchers_tool, get_store_policies_tool]
    
    agent = create_react_agent(llm, tools_list)
    return agent
