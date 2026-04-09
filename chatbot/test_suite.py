import httpx
import json
import asyncio
import os

# Configuration
CHATBOT_URL = "http://localhost:8000/chat"
WEB_BASE_URL = "https://localhost:7290"

test_cases = [
    {
        "name": "Grounding Check (Negative)",
        "message": "Tôi muốn mua áo vest màu tím hồng giá 100k",
        "description": "Checks if AI hallucinates non-existent products."
    },
    {
        "name": "Product Search (Positive)",
        "message": "Cho mình xem các mẫu áo màu đen",
        "description": "Checks if AI correctly calls tools and shows real products."
    },
    {
        "name": "Size Advice Flow",
        "message": "Mình cao 1m75, nặng 68kg thì mặc áo hoodie size gì?",
        "description": "Checks if AI uses the size chart correctly."
    },
    {
        "name": "Mix & Match logic",
        "message": "Gợi ý cho mình một bộ đồ đi hẹn hò buổi tối",
        "description": "Checks if AI suggests a full outfit (Top + Bottom + Accessory)."
    },
    {
        "name": "Policy & Shipping",
        "message": "Phí ship về Biên Hòa bao nhiêu và đơn bao nhiêu thì được miễn phí?",
        "description": "Checks if AI knows the 25k/35k fee and 499k freeship rule."
    }
]

async def run_test(case):
    print(f"\n[TEST] {case['name']} - {case['description']}")
    payload = {
        "message": case["message"],
        "web_base_url": WEB_BASE_URL,
        "history": []
    }
    try:
        async with httpx.AsyncClient(timeout=30.0) as client:
            response = await client.post(CHATBOT_URL, json=payload)
            if response.status_code == 200:
                result = response.json().get("response", "")
                print(f"RESULT:\n{result}")
            else:
                print(f"FAILED: Status {response.status_code} - {response.text}")
    except Exception as e:
        print(f"ERROR: {str(e)}")

async def main():
    print("=== NOVA AI ENGINEER TEST SUITE ===")
    if not os.getenv("GROQ_API_KEY"):
        print("WARNING: GROQ_API_KEY not found in environment. Tests will likely fail.")
    
    for case in test_cases:
        await run_test(case)

if __name__ == "__main__":
    asyncio.run(main())
