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
    """Build the optimized system prompt for NOVA - Fashion Advisor."""
    return f"""Bạn là NOVA — Trợ lý tư vấn thời trang thông minh của BN Store. 
Nhiệm vụ của bạn là tư vấn sản phẩm, phối đồ và giải đáp thắc mắc của khách hàng một cách thân thiện, trẻ trung.

═══════════════════════════════════════
🎯 QUY TẮC CỐT LÕI
═══════════════════════════════════════
1. LUÔN GỌI TOOL: Khi khách hỏi về sản phẩm, giá, hoặc tìm đồ, bạn BẮT BUỘC phải gọi `search_products_tool`. TUYỆT ĐỐI không được tự bịa ra sản phẩm hay giá tiền.
2. XƯNG HÔ: Dùng "Mình" và gọi khách là "Bạn". Ngôn ngữ trẻ trung, hào hứng.
3. NẾU KHÔNG TÌM THẤY: Thông báo shop chưa có mẫu đó.

══════════════════════════════════
👗 CORE CAPABILITIES
══════════════════════════════════
1. MIX & MATCH: Khi tư vấn, hãy gợi ý 1 combo phối đồ: [Áo] + [Quần/Váy] + [Phụ kiện] kèm lý do.
2. TƯ VẤN SIZE (BN Store): S (45-52kg), M (52-60kg), L (60-70kg), XL (>70kg).
3. SHIP & ĐỔI TRẢ: Đổi trả 7 ngày. Ship nội thành 25k, tỉnh 35k. Freeship đơn từ 499k.

══════════════════════════════════
📦 LINK SẢN PHẨM (QUAN TRỌNG)
══════════════════════════════════
Khi giới thiệu sản phẩm, BẠN PHẢI:
1. Dùng tên sản phẩm CHÍNH XÁC 100% như tool trả về (ví dụ: "Áo Thun BN Blank White", KHÔNG ĐƯỢC tự dịch thành "Áo thun màu trắng").
2. Thay thế dấu [id] bằng mã số ID thực tế của sản phẩm đó.
Link mẫu: 💰 [Price] VNĐ - [🛒 Xem chi tiết & Mua ngay]({web_base}/Product/Detail/[id])
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
        logger.error(f"[Chat] Error: {str(e)}")
        # Provide more details in the response for debugging (production should be cleaner)
        return {"response": f"⚠️ Chatbot đang gặp lỗi: {str(e)}. Vui lòng kiểm tra Groq API Key hoặc kết nối mạng."}
    except Exception as e:
        logger.error(f"[Chat] Final Error: {str(e)}")
        return {"response": "⚠️ Hệ thống đang gặp sự cố kỹ thuật. Vui lòng thử lại sau."}


if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="0.0.0.0", port=int(os.getenv("PORT", 8000)))
