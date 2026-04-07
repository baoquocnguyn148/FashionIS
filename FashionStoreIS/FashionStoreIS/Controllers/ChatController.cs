using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace FashionStoreIS.Controllers
{
    public class ChatController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly string _chatbotUrl;

        public ChatController(IHttpClientFactory httpClientFactory, IConfiguration configuration)
        {
            _httpClientFactory = httpClientFactory;
            var host = Environment.GetEnvironmentVariable("CHATBOT_URL") 
                       ?? configuration["CHATBOT_URL"] 
                       ?? "http://localhost:8000";
            
            _chatbotUrl = host.TrimEnd('/');
        }

        [HttpPost]
        public async Task<IActionResult> Message([FromBody] JsonElement payload)
        {
            try
            {
                var client = _httpClientFactory.CreateClient();
                var content = new StringContent(payload.GetRawText(), Encoding.UTF8, "application/json");
                
                // Construct the full internal URL (e.g., http://fashion-store-chatbot:8000/chat)
                var requestUrl = $"{_chatbotUrl.TrimEnd('/')}/chat";
                
                var response = await client.PostAsync(requestUrl, content);
                
                if (response.IsSuccessStatusCode)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    return Content(responseBody, "application/json");
                }
                
                return StatusCode((int)response.StatusCode, "Error connecting to AI service.");
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
