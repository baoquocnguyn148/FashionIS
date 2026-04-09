from fastapi import FastAPI, HTTPException
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel
from typing import List, Optional
from dotenv import load_dotenv
import os
import logging

# Load environment variables from .env file
load_dotenv()

logging.basicConfig(level=logging.INFO)
logger = logging.getLogger(__name__)

from llm_client import get_chatbot_agent

app = FastAPI(title="FashionStore Chatbot API")

# Add CORS to allow frontend to call this service
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"],
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

# ─── GLOBAL AGENT INITIALIZATION (ONLY ONCE AT STARTUP) ──────────────────────
# This is the key optimization: agent is built once when the server starts,
# not on every individual request. This eliminates the 502 timeout during cold starts.
_agent_executor = None

def get_or_create_agent():
    global _agent_executor
    if _agent_executor is None:
        logger.info("[Startup] Initializing chatbot agent for the first time...")
        _agent_executor = get_chatbot_agent()
        logger.info("[Startup] Chatbot agent initialized successfully.")
    return _agent_executor

# Pre-warm the agent at startup (runs in background on first request)
@app.on_event("startup")
async def startup_event():
    """Pre-initialize the agent when the server starts to avoid cold-start delays."""
    try:
        if os.getenv("GROQ_API_KEY"):
            get_or_create_agent()
            logger.info("[Startup] Agent pre-warmed successfully.")
        else:
            logger.warning("[Startup] GROQ_API_KEY not set - agent will not be initialized.")
    except Exception as e:
        logger.error(f"[Startup] Failed to pre-warm agent: {e}")
# ─────────────────────────────────────────────────────────────────────────────

class ChatMessage(BaseModel):
    role: str  # 'user' or 'assistant'
    content: str

class ChatRequest(BaseModel):
    message: str
    web_base_url: Optional[str] = None
    history: List[ChatMessage] = []


def build_system_prompt(web_base: str) -> str:
    """Build the production-grade system prompt for NOVA - Fashion Advisor."""
    return f"""# ROLE & IDENTITY
Bạn là NOVA — Trợ lý tư vấn thời trang của BN Store. Trẻ trung, gần gũi, chuyên nghiệp.
Giao tiếp: Dùng "Mình" / "Bạn". Trả lời 100% tiếng Việt.

# PHÂN LOẠI NHIỆM VỤ — RẤT QUAN TRỌNG

## Nhóm A: BẮT BUỘC GỌI TOOL TRƯỚC KHI TRẢ LỜI
Các câu hỏi về sản phẩm, áo, quần, túi, mũ, tìm đồ, màu sắc, giá cả:
→ BẮT BUỘC gọi `search_products_tool` TRƯỚC. KHÔNG được tự trả lời.
→ Ví dụ trigger: "tôi muốn mua", "có áo", "giá dưới", "màu đen", "gợi ý đồ"
→ Dịch tiếng Việt → tiếng Anh để search: đen→black, trắng→white, áo→shirt, túi→bag, mũ→cap
→ Dùng max_price cho "giá dưới X": Ví dụ "giá dưới 700k" → max_price=700000
→ Nếu tool trả về empty → báo thật "shop chưa có". TUYỆT ĐỐI không bịa sản phẩm.

## Nhóm B: TRẢ LỜI TRỰC TIẾP — KHÔNG CẦN GỌI TOOL
Các câu hỏi về size/fit, chính sách, ship, đổi trả → trả lời trực tiếp từ kiến thức:

### Bảng Size BN Store:
- S : Cao 155–162cm, Nặng 45–52kg
- M : Cao 162–168cm, Nặng 52–60kg  
- L : Cao 168–175cm, Nặng 60–70kg
- XL: Cao >175cm, Nặng >70kg
*Thích mặc rộng → lên 1 size*

### Chính sách:
- Đổi trả 7 ngày (còn tag, chưa giặt). Lỗi shop → Freeship 2 chiều.
- Ship nội thành HCM/HN: 25k (1-2 ngày). Tỉnh: 35k (3-5 ngày).
- FREESHIP đơn từ 499,000 VNĐ.

# HIỂN THỊ SẢN PHẨM (SAU KHI GỌI TOOL)
Dùng đúng tên, ID, imageUrl từ kết quả tool — KHÔNG tự bịa:

### **[Tên sản phẩm]**
💰 **[Price] VNĐ** | [🛒 Xem chi tiết]({web_base}/Product/Detail/[id])

# Mix & Match
Khi khách hỏi phối đồ: điền 3 items từ kết quả tool → [Áo] + [Quần] + [Phụ kiện] + lý do phối.
"""


@app.get("/")
async def health_check():
    return {"status": "ok", "message": "BN Store Chatbot API is running."}


@app.post("/chat")
async def chat(request: ChatRequest):
    try:
        if not os.getenv("GROQ_API_KEY"):
            return {"response": "⚠️ Hệ thống AI chưa được cấu hình API Key. Vui lòng liên hệ quản trị viên để thiết lập GROQ_API_KEY."}

        # Use the globally initialized agent (no re-initialization per request)
        agent_executor = get_or_create_agent()

        from langchain_core.messages import SystemMessage, HumanMessage, AIMessage
        
        # Priority: Client provided WebBaseUrl > Environment Variable > Default Render Domain
        web_base = request.web_base_url or os.getenv("WEB_BASE_URL", "https://fashion-store-web.onrender.com")
        web_base = web_base.rstrip("/")

        system_prompt = build_system_prompt(web_base)

        # Prepare messages for LangGraph: System → History → Current message
        messages = [SystemMessage(content=system_prompt)]

        # Limit history to last 10 exchanges to prevent token overflow
        recent_history = request.history[-10:]
        for msg in recent_history:
            if msg.role == "user":
                messages.append(HumanMessage(content=msg.content))
            elif msg.role == "assistant":
                messages.append(AIMessage(content=msg.content))

        messages.append(HumanMessage(content=request.message))

        logger.info(f"[Chat] Processing message: {request.message[:80]}...")

        # Invoke agent
        response = await agent_executor.ainvoke({"messages": messages})
        
        # Log the full response for debugging
        logger.info(f"[Chat] Agent Response Structure: {list(response.keys())}")
        
        # LangGraph returns a state dictionary where 'messages' ends with the AI reply
        final_message = response["messages"][-1].content

        logger.info(f"[Chat] Response generated successfully.")
        return {"response": final_message}

    except Exception as e:
        err_str = str(e)
        logger.error(f"[Chat] Error: {err_str}")

        # Handle Groq tool_use_failed gracefully — happens when model tries
        # to call a tool for a non-tool question (e.g. size advice)
        if "tool_use_failed" in err_str or "Failed to call a function" in err_str:
            return {"response": (
                "Xin lỗi vì sự cố kỹ thuật nhỏ! Mình trả lời trực tiếp nhé 😊\n\n"
                "Dựa trên thông tin bạn cung cấp (chiều cao & cân nặng), mình sẽ tư vấn size phù hợp:\n"
                "- **S**: 155–162cm, 45–52kg\n"
                "- **M**: 162–168cm, 52–60kg\n"
                "- **L**: 168–175cm, 60–70kg\n"
                "- **XL**: >175cm, >70kg\n\n"
                "Bạn hãy cho mình biết chiều cao và cân nặng cụ thể để mình tư vấn chính xác hơn nhé!"
            )}

        return {"response": f"⚠️ Chatbot đang gặp lỗi tạm thời. Vui lòng thử lại sau ít giây."}


if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="0.0.0.0", port=int(os.getenv("PORT", 8000)))
