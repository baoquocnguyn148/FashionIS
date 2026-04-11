using Microsoft.AspNetCore.Mvc;
using System.Text;
using System.Text.Json;

namespace FashionStoreIS.Controllers
{
    public class ChatController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly ILogger<ChatController> _logger;
        private readonly string _chatbotUrl;

        public ChatController(IHttpClientFactory httpClientFactory, IConfiguration configuration, ILogger<ChatController> logger)
        {
            _httpClientFactory = httpClientFactory;
            _logger = logger;

            // Render injects CHATBOT_URL as host:port when using 'property: hostport'
            // Local fallback uses appsettings.json
            var url = Environment.GetEnvironmentVariable("CHATBOT_URL")
                      ?? configuration["CHATBOT_URL"]
                      ?? "fashion-store-chatbot:10000"; // Internal name

            // Ensure protocol is present
            if (!string.IsNullOrEmpty(url) && !url.StartsWith("http", StringComparison.OrdinalIgnoreCase))
            {
                url = "http://" + url;
            }

            _chatbotUrl = url.TrimEnd('/');
            _logger.LogInformation("[ChatController] Target Chatbot URL: {Url}", _chatbotUrl);
        }

        [HttpPost]
        public async Task<IActionResult> Message([FromBody] JsonElement payload)
        {
            var requestUrl = $"{_chatbotUrl}/chat";
            _logger.LogInformation("[ChatController] Forwarding chat request to: {Url}", requestUrl);

            try
            {
                var client = _httpClientFactory.CreateClient();
                client.Timeout = TimeSpan.FromSeconds(90); // Groq LLM can be slow on free tier

                var content = new StringContent(payload.GetRawText(), Encoding.UTF8, "application/json");
                var response = await client.PostAsync(requestUrl, content);
                var responseBody = await response.Content.ReadAsStringAsync();

                _logger.LogInformation("[ChatController] Chatbot response status: {Status}", response.StatusCode);

                if (response.IsSuccessStatusCode)
                {
                    return Content(responseBody, "application/json");
                }

                if (response.StatusCode == System.Net.HttpStatusCode.TooManyRequests)
                {
                    _logger.LogWarning("[ChatController] Rate limit exceeded (429).");
                    return StatusCode(429, new { error = "Hệ thống AI đang bận xử lý nhiều yêu cầu. Vui lòng đợi khoảng 30 giây rồi thử lại nhé! ✨" });
                }

                _logger.LogWarning("[ChatController] Chatbot returned error: {Body}", responseBody);
                return StatusCode((int)response.StatusCode, new { error = $"AI service error: {responseBody}" });
            }
            catch (TaskCanceledException)
            {
                _logger.LogError("[ChatController] Request to chatbot timed out.");
                return StatusCode(504, new { error = "AI service timed out. Please try again." });
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "[ChatController] CONNECTION FAILURE to {Url}. Details: {Message}", requestUrl, ex.Message);
                return StatusCode(503, new { error = $"Cannot reach AI service at {requestUrl}. Ensure the chatbot service is running. Error: {ex.Message}" });
            }
        }
    }
}
