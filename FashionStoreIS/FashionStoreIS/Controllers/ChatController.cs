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

            // Render injects CHATBOT_URL as a full URL when using `property: url`
            var url = Environment.GetEnvironmentVariable("CHATBOT_URL")
                      ?? configuration["CHATBOT_URL"]
                      ?? "https://fashion-store-chatbot.onrender.com";

            // WORKAROUND: Force protocol if Render property: hostport is used
            if (!string.IsNullOrEmpty(url) && !url.StartsWith("http"))
            {
                url = "http://" + url;
            }

            if (url.Contains(":10000") || url.Contains("localhost")) 
            {
                url = "https://fashion-store-chatbot.onrender.com";
            }

            _chatbotUrl = url.TrimEnd('/');
            _logger.LogInformation("[ChatController] Chatbot URL configured as: {Url}", _chatbotUrl);
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
                _logger.LogError(ex, "[ChatController] Failed to connect to chatbot at {Url}", requestUrl);
                return StatusCode(503, new { error = $"Cannot reach AI service: {ex.Message}" });
            }
        }
    }
}
