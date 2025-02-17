using System.Net;
using System.Text.Json;

namespace app.Infrastructure
{
    public class ErrorHandlingMiddleware(RequestDelegate next)
    {
        public async Task Invoke(HttpContext context)
        {
            try
            {
                await next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private static Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.ContentType = "application/json";

            //var response = context.Response;
            var errorResponse = new { message = exception.Message };

            switch (exception)
            {
                case ArgumentNullException:
                    errorResponse = new { message = "Clock-in data is missing." };
                    break;

                case InvalidOperationException:
                    errorResponse = new { message = "Time entry already exists"};
                    break;

                default:
                    errorResponse = new { message = "An unexpected error occurred." };
                    break;
            }

            var result = JsonSerializer.Serialize(errorResponse);
            return context.Response.WriteAsync(result);
        }
    }
}
