using OnlineStore.Common.Shared.Exceptions;
using System.Text;

namespace OnlineStore.API.Middlewares
{
    public sealed class ExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger _logger;

        public ExceptionHandlingMiddleware(RequestDelegate next, ILogger<ExceptionHandlingMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(context, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            var stringBuilder = new StringBuilder();
            stringBuilder.Append($"Error Occured at {DateTime.UtcNow.ToShortDateString()} {DateTime.UtcNow.ToShortTimeString()}\n");
            if (!string.IsNullOrEmpty(exception.Message))
            {
                stringBuilder.Append("Message: ");
                stringBuilder.Append(exception.Message);
                stringBuilder.Append("\n");
            }
            if (exception.InnerException != null && !string.IsNullOrEmpty(exception.InnerException.Message))
            {
                stringBuilder.Append("Inner Exception: ");
                stringBuilder.Append(exception.InnerException.Message);
                stringBuilder.Append("\n");
            }
            if (exception.StackTrace != null)
            {
                stringBuilder.Append("Stack Trace: ");
                stringBuilder.Append(exception.StackTrace);
            }
            _logger.LogError(stringBuilder.ToString());

            if (exception is CustomException)
                return context.Response.WriteAsync($"\"{exception.Message}\"");
            else
                return context.Response.WriteAsync($"\"{stringBuilder}\"");
        }
    }
}
