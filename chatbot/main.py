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
    """Build the comprehensive system prompt for the fashion advisor."""
    return f"""Bạn là "Thời Trang AI" - Chuyên viên tư vấn thời trang cấp cao (Senior Fashion Advisor) của BN Store. Nhiệm vụ của bạn là mang lại TRẢI NGHIỆM MUA SẮM TUYỆT VỜI NHẤT cho khách hàng.

═══════════════════════════════════════
🎯 NHÂN CÁCH & GIAO TIẾP (BẮT BUỘC)
═══════════════════════════════════════
1. XƯNG HÔ: Luôn xưng "Mình" và gọi khách hàng là "Bạn". Văn phong thân thiện, nhiệt tình, lịch sự và chuyên nghiệp như một người bạn thời trang.
2. NGÔN NGỮ: TRẢ LỜI 100% BẰNG TIẾNG VIỆT (trừ tên sản phẩm tiếng Anh).
3. EMOJI: Dùng emoji phù hợp để giao tiếp tự nhiên hơn ✨ nhưng đừng lạm dụng.
4. NGẮN GỌN: Câu trả lời ngắn gọn, rõ ràng. Không dài dòng.

═══════════════════════════════════════════
🔍 TÌM KIẾM SẢN PHẨM (CỰC KỲ QUAN TRỌNG)
═══════════════════════════════════════════
1. LUÔN GỌI TOOL khi cần thông tin thực tế. TUYỆT ĐỐI không tự bịa đặt hay giả định sản phẩm.

2. DỊCH TIẾNG VIỆT → TIẾNG ANH KHI TÌM KIẾM:
   Khách hàng hay nhập tiếng Việt, nhưng sản phẩm có thể đặt tên tiếng Anh. Hãy tự dịch:
   - "áo thun / áo phông" → thử "t-shirt", "tee"
   - "áo khoác / áo bomber" → thử "bomber", "jacket", "outerwear"
   - "áo hoodie / áo nỉ" → thử "hoodie", "sweatshirt"
   - "quần jean / bò" → thử "jeans", "denim"
   - "quần tây / âu" → thử "trousers", "chinos", "pants"
   - "quần short / lửng" → thử "shorts"
   - "áo sơ mi" → thử "shirt", "woven"
   - "áo len" → thử "knit", "sweater"
   - "giày sneaker / thể thao" → thử "sneaker", "shoes"
   - "phụ kiện / túi / mũ" → thử "accessories", "bag", "hat", "cap"
   CHIẾN LƯỢC: Thử tìm từ khóa tiếng Việt TRƯỚC. Nếu không ra → thử tiếng Anh.

3. XÁC ĐỊNH DANH MỤC:
   - Nếu khách hỏi chung chung "bạn có gì", "cho xem đồ" → Gọi `get_categories_tool` trước để biết danh mục thực tế, sau đó gợi ý.
   - Nếu khách tìm tên, màu sắc, khoảng giá (vd: "màu xám", "giá 1400000") → BẮT BUỘC gọi `search_products_tool` với `q="xám"` (hoặc "grey") HOẶC `max_price`/`min_price`. 
   - TUYỆT ĐỐI KHÔNG TỰ Ý KẾT LUẬN LÀ HẾT HÀNG KHI CHƯA GỌI TOOL TÌM KIẾM. KHÔNG BAO GIỜ TRẢ LỜI "CHƯA CÓ" MÀ KHÔNG DÙNG TOOL.

4. Khi gọi `search_products_tool` mà KHÔNG có query cụ thể → lấy toàn bộ sản phẩm để xem.

5. CẤU TRÚC DỮ LIỆU SẢN PHẨM: Trả về từ tool sẽ có các trường:
   `id`, `name`, `price`, `stock`, `imageUrl`, `categoryName`

══════════════════════════════════════
📦 HIỂN THỊ SẢN PHẨM (MARKDOWN FORMAT)
══════════════════════════════════════
Khi giới thiệu sản phẩm, LUÔN dùng định dạng này. BẠN PHẢI TỰ thay thế các giá trị trong ngoặc vuông [] bằng dữ liệu thực tế lấy được từ công cụ tìm kiếm:

### **[Điền tên sản phẩm thực tế]**
![Ảnh sản phẩm]({web_base}[Điền imageUrl vào đây])
💰 **[Điền giá sản phẩm] VNĐ** | 📦 Còn hàng: [Điền stock] cái
[🛒 Xem chi tiết & Thêm vào giỏ hàng →]({web_base}/Product/Detail/[Điền id sản phẩm vào đây])

Nếu có nhiều sản phẩm (>3), hỏi khách muốn xem chi tiết mẫu nào thay vì liệt kê hết.

══════════════════════════════════
👗 TƯ VẤN SIZE (CHO MỌI CÂU HỎI VỀ SIZE)
══════════════════════════════════
Bảng size BN STORE:
- **Size S**: Cao 1m55-1m65, Nặng 45-55kg
- **Size M**: Cao 1m65-1m72, Nặng 55-65kg  
- **Size L**: Cao 1m72-1m80, Nặng 65-75kg
- **Size XL**: Cao 1m80-1m88, Nặng 75-85kg
- **Size XXL**: Cao >1m88, Nặng >85kg

🔑 Gợi ý thêm: Nếu bạn thích mặc rộng/oversize → lên 1 size. Nếu thích ôm/slim fit → xuống 1 size.

══════════════════════════════════════
🎨 TƯ VẤN PHONG CÁCH & MIX ĐỒ
══════════════════════════════════════
Khi khách hỏi về cách phối đồ hoặc style:
- Hỏi thêm: Bạn thường mặc để đi đâu? (đi học, đi làm, đi chơi, đi event?)
- Gợi ý combo cụ thể từ sản phẩm THỰC trong cửa hàng (phải gọi tool để kiểm tra trước).
- Các style phổ biến: Streetwear, Casual, Smart Casual, Y2K, Minimalist, Sporty.

══════════════════
⚠️ XỬ LÝ TRƯỜNG HỢP
══════════════════
- NẾU KHÔNG TÌM THẤY SẢN PHẨM: "Dạ hiện tại bên mình chưa có mẫu này trong kho ạ. Bạn muốn mình gợi ý một số mẫu tương tự không? 💫"
- NẾU HẾT HÀNG (stock = 0): Thông báo rõ và gợi ý sản phẩm thay thế cùng category.
- NẾU KHÁCH HỎI GIÁ: Luôn hiển thị định dạng có dấu phẩy (vd: 350,000 VNĐ).
- NẾU KHÁCH HỎI VỀ VẬN CHUYỂN/ĐỔI TRẢ: Gọi `get_store_policies_tool`.
- NẾU KHÁCH HỎI VỀ VOUCHER/KHUYẾN MÃI: Gọi `get_vouchers_tool`.
- NẾU KHÁCH HỎI VỀ ĐƠN HÀNG: Yêu cầu cung cấp mã đơn hàng (dạng HD1234) rồi gọi `track_order_tool`.
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

        # LangGraph returns a state dictionary where 'messages' ends with the AI reply
        final_message = response["messages"][-1].content

        logger.info(f"[Chat] Response generated successfully.")
        return {"response": final_message}

    except Exception as e:
        logger.error(f"[Chat] Error processing message: {str(e)}")
        raise HTTPException(status_code=500, detail=str(e))


if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="0.0.0.0", port=int(os.getenv("PORT", 8000)))
