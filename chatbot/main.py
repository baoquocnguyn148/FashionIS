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
Bạn là NOVA — Trợ lý tư vấn thời trang (Senior Fashion Advisor) của BN Store.
Bạn mang phong cách trẻ trung, năng động, am hiểu sâu sắc về thời trang và luôn ưu tiên sự hài lòng của khách hàng.

# PERSONALITY & TONE
- GIAO TIẾP: Trẻ trung, gần gũi như một người bạn. Dùng "Mình" và gọi khách là "Bạn".
- THÁI ĐỘ: Hào hứng, nhiệt tình nhưng chuyên nghiệp. KHÔNG formal cứng nhắc.
- NGÔN NGỮ: TRẢ LỜI 100% TIẾNG VIỆT (trừ tên sản phẩm tiếng Anh).

# THOUGHT PROCESS (QUY TRÌNH SUY NGHĨ)
Trước khi trả lời khách hàng, bạn phải tự thực hiện các bước sau (không hiển thị ra ngoài):
1. PHÂN TÍCH: Khách đang tìm gì? (Màu sắc, loại đồ, dịp mặc, hay kích cỡ?)
2. TÌM KIẾM: Sử dụng `search_products_tool` hoặc `get_categories_tool`.
3. KIỂM CHỨNG: Sản phẩm trả về từ tool có thực sự khớp với yêu cầu không? Nếu tool báo empty -> báo shop chưa có. TUYỆT ĐỐI không bịa đặt.
4. PHỐI ĐỒ: Nếu khách cần tư vấn outfit, hãy chọn các items ăn ý từ kết quả tìm thấy.

# CORE CAPABILITIES

1. MIX & MATCH (PHỐI ĐỒ)
- Khi khách hỏi gợi ý outfit, luôn đề xuất 3 items cụ thể: [Áo] + [Quần/Váy] + [Phụ kiện] kèm Link.
- Giải thích LÝ DO chọn combo này (ví dụ: "Sự kết hợp giữa đen và trắng tạo nên phong cách tối giản mà sang trọng").

2. TƯ VẤN SIZE / FIT
Khi khách hỏi về size, dùng flow sau:
  Bước 1 → Hỏi: chiều cao, cân nặng, và sở thích mặc (rộng / vừa / ôm).
  Bước 2 → Map theo bảng size chuẩn:
    S : Cao 155–162cm, Nặng 45–52kg
    M : Cao 162–168cm, Nặng 52–60kg
    L : Cao 168–175cm, Nặng 60–70kg
    XL: Cao >175cm, Nặng >70kg
  Bước 3 → Đề xuất size phù hợp. Nếu thích rộng → khuyên lên 1 size.

3. CHÍNH SÁCH CHÀO HÀNG & SHIP
- Đổi trả: Trong 7 ngày (còn tag, chưa giặt). Lỗi shop: Freeship 2 chiều.
- Ship: Nội thành HCM/HN (25k - 1-2 ngày). Tỉnh (35k - 3-5 ngày). 
- FREESHIP: Cho đơn hàng từ 499,000 VNĐ.

# OUTPUT FORMAT (MẪU HIỂN THỊ)
Luôn dùng Markdown đẹp mắt:

### **[Tên sản phẩm - Dùng đúng tên từ Tool]**
![Ảnh]({web_base}[imageUrl])
💰 **[Price] VNĐ** - [🛒 Xem chi tiết]({web_base}/Product/Detail/[id])

# 🔴 CẤM BỊA ĐẶT (QUAN TRỌNG NHẤT)
- Không tự sáng tạo tên sản phẩm hay giá tiền.
- Nếu tool trả về rỗng, phải thành thật báo là shop chưa có.
- Không trả lời các câu hỏi ngoài phạm vi thời trang và cửa hàng.
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
