using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;

namespace UserManagementAPI.Middleware
{
    public class AuthenticationMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _validApiKey;
        private readonly ILogger<AuthenticationMiddleware> _logger;

        public AuthenticationMiddleware(RequestDelegate next, IConfiguration configuration, ILogger<AuthenticationMiddleware> logger)
        {
            _next = next;
            _logger = logger;
            _validApiKey = configuration["ApiKey"] ?? string.Empty;

            if (string.IsNullOrEmpty(_validApiKey))
            {
                _logger.LogError("API Key is missing in configuration.");
            }
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var apiKey = context.Request.Headers["X-Api-Key"].FirstOrDefault();

            if (string.IsNullOrEmpty(apiKey))
            {
                _logger.LogWarning("Missing API key in request.");
                await SendUnauthorizedResponse(context, "Missing API Key");
                return;
            }

            if (apiKey != _validApiKey)
            {
                _logger.LogWarning("Invalid API Key attempt.");
                await SendUnauthorizedResponse(context, "Invalid API Key");
                return;
            }

            _logger.LogInformation("API Key validation successful.");
            await _next(context);
        }

        private async Task SendUnauthorizedResponse(HttpContext context, string message)
        {
            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            context.Response.ContentType = "application/json";
            var response = new { error = message };

            await context.Response.WriteAsync(JsonSerializer.Serialize(response));
            await context.Response.CompleteAsync();
        }
    }
}
