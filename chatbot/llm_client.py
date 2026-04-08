from langchain_groq import ChatGroq
from langchain_core.tools import tool
from langgraph.prebuilt import create_react_agent
import os
import tools as api_tools

# Groq API Configuration (set via Render environment variables)
GROQ_API_KEY = os.getenv("GROQ_API_KEY", "")
# Force a stable, high-limit model for free tier
GROQ_MODEL = "llama-3.1-8b-instant"

from typing import Optional

# Define LangChain Tools
@tool
async def search_products_tool(
    query: Optional[str] = None, 
    category: Optional[str] = None, 
    sort: Optional[str] = None, 
    min_price: Optional[float] = None, 
    max_price: Optional[float] = None
):
    """
    Tool to search for products in the store or to get the full list of products.
    
    Parameters:
    - query: Specific search terms IN ENGLISH ONLY (e.g., 'white shirt', 'polo'). Leave None to list all.
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
    Check the status of a user's order. Ask the user for their order code (e.g. 'HD1234') before calling this.
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
    Get store information: address, return policy, shipping fees.
    Only use when the customer asks about store operations, NOT when searching for products.
    """
    return await api_tools.get_store_policies()

@tool
async def get_categories_tool():
    """
    Lấy danh sách toàn bộ danh mục sản phẩm (Áo, Quần, Phụ kiện, v.v.). 
    TUYỆT ĐỐI NÊN GỌI cái này nếu khách hàng hỏi chung chung như 'bạn bán gì', 'cho xem áo' mà bạn chưa chắc chắn slug.
    """
    return await api_tools.get_categories()

# Setup LLM and Agent using Groq
def get_chatbot_agent():
    llm = ChatGroq(
        api_key=GROQ_API_KEY,
        model=GROQ_MODEL,
        temperature=0.0,
    )
    
    tools_list = [
        search_products_tool,
        get_product_details_tool,
        track_order_tool,
        get_vouchers_tool,
        get_store_policies_tool,
        get_categories_tool
    ]
    
    agent = create_react_agent(llm, tools_list)
    return agent
