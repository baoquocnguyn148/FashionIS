from fastapi import FastAPI, HTTPException
from fastapi.middleware.cors import CORSMiddleware
from pydantic import BaseModel
from typing import List, Optional
from dotenv import load_dotenv
import os

# Load environment variables from .env file
load_dotenv()

from llm_client import get_chatbot_agent

app = FastAPI(title="FashionStore Chatbot API")

# Add CORS to allow frontend to call this service
app.add_middleware(
    CORSMiddleware,
    allow_origins=["*"], # In production, restrict to your website domain
    allow_credentials=True,
    allow_methods=["*"],
    allow_headers=["*"],
)

class ChatMessage(BaseModel):
    role: str # 'user' or 'assistant'
    content: str

class ChatRequest(BaseModel):
    message: str
    history: List[ChatMessage] = []

@app.post("/chat")
async def chat(request: ChatRequest):
    try:
        agent_executor = get_chatbot_agent()
        
        from langchain_core.messages import SystemMessage, HumanMessage, AIMessage
        web_base = os.getenv("WEB_BASE_URL", "https://localhost:7290")
        system_prompt = f"""Bạn là Chuyên viên tư vấn cấp cao (Senior Fashion Advisor) của BN Store.

Quy Tắc Giao Tiếp (BẮT BUỘC):
1. XƯNG HÔ: Luôn xưng "Mình" và gọi khách hàng là "Bạn". Văn phong thân thiện, nhiệt tình, lịch sự và chuyên nghiệp.
2. NGÔN NGỮ: TRẢ LỜI 100% BẰNG TIẾNG VIỆT (trừ tên sản phẩm).

Xử Lý Ngoại Lệ (BẮT BUỘC):
1. Không bao giờ nói các câu sặc mùi lập trình như "Backend trả về 0", "API request failed", "tool trả về status empty". 
2. NẾU KHÔNG TÌM THẤY: Hãy trả lời khéo léo: "Dạ hiện tại mẫu này bên mình đang tạm hết hàng. Bạn thử xem qua các mẫu khác nhé!".

Quy Tắc Tìm Kiếm & Tool:
1. LUÔN GỌI TOOL khi cần thông tin thực tế. Không tự bịa đặt.
2. DỊCH TỪ KHÓA TÌM KIẾM: Kho hàng đặt tên bằng tiếng Anh. Nếu khách gõ tiếng Việt (vd: "áo trắng"), bạn PHẢI dịch sang tiếng Anh (vd: "white shirt") trước khi truyền vào `query` của tool.
3. PHIẾM CHỈ: Nếu khách hỏi "có bao nhiêu sản phẩm", "bạn có gì", "cho xem đồ", TUYỆT ĐỐI BỎ TRỐNG `query` (=None).

Định Dạng Trả Về (Markdown):
1. Khi hiển thị sản phẩm, TUYỆT ĐỐI dùng định dạng: `### **[Tên]**`, chèn ảnh `![Ảnh]({web_base}{{imageUrl}})`, giá `**{{price}} VNĐ**`, 
   => Nút Call-to-Action (CTA): Kèm theo link `[🛒 Bấm vào đây để Xem Chi Tiết / Thêm Giỏ Hàng]({web_base}/Product/Detail/{{id}})`
2. TƯ VẤN SIZE: Tham khảo: 1m6-1m7/50-60kg (S); 1m7-1m75/60-70kg (M); 1m75-1m85/70-80kg (L); >1m85/>80kg (XL).

CẢNH BÁO QUAN TRỌNG: 
Tuyệt đối KHÔNG tự ý thêm thông tin, thêm màu sắc hoặc loại quần áo nếu người dùng KHÔNG NHẮC ĐẾN. Điển hình: Nếu không nhắc màu đen, KHÔNG TÌM màu đen. Chỉ tìm chính xác những gì người dùng yêu cầu.
"""
        # Prepare messages for LangGraph (System, then history, then current message)
        messages = [SystemMessage(content=system_prompt)]
        
        for msg in request.history:
            if msg.role == "user":
                messages.append(HumanMessage(content=msg.content))
            else:
                messages.append(AIMessage(content=msg.content))
                
        messages.append(HumanMessage(content=request.message))
                 
        # Invoke agent
        response = await agent_executor.ainvoke({
            "messages": messages
        })
        
        # LangGraph returns a state dictionary where 'messages' ends with the AI reply
        final_message = response["messages"][-1].content
        
        return {"response": final_message}
    except Exception as e:
        print(f"Error in chat endpoint: {str(e)}")
        raise HTTPException(status_code=500, detail=str(e))

if __name__ == "__main__":
    import uvicorn
    uvicorn.run(app, host="0.0.0.0", port=8000)
