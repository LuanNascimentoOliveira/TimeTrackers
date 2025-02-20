using System.Net;
using System.Text.Json;

namespace app.Infrastructure
{
    public class GlobalExceptionHandler(RequestDelegate next, ILogger<GlobalExceptionHandler> logger)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                logger.LogInformation($"Request URL {context.Request.Path} ");
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex, logger);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception, ILogger<GlobalExceptionHandler> logger)
        {
            context.Response.ContentType = "application/json";

            var response = context.Response;
            var errorResponse = new { message = exception.Message };

            switch (exception)
            {
                case ArgumentNullException:
                    response.StatusCode = (int)HttpStatusCode.BadRequest;
                    errorResponse = new { message = $"{exception.Message}, data is missing." };
                    logger.LogError(message: $"{exception.Message}");
                    break;

                case InvalidOperationException:
                    response.StatusCode = (int)HttpStatusCode.Conflict;
                    errorResponse = new { message = "A time entry already exists for this date." };
                    logger.LogWarning(message: $"{exception.Message}");
                    break;

                default:
                    response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    errorResponse = new { message = "An unexpected error occurred." };
                    logger.LogWarning(message: $"{exception.Message}");
                    break;
            }

            var result = JsonSerializer.Serialize(errorResponse);
            return context.Response.WriteAsync(result);
        }
    }
}
