namespace CareerCompass.Api.Middlewares
{
    using System.Net;
    using System.Text.Json;
    using Microsoft.AspNetCore.Http;
    using System.Threading.Tasks;

    public class ExceptionHandlerMiddleware
    {
        private readonly RequestDelegate _next;

        public ExceptionHandlerMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext httpContext)
        {
            try
            {
                await _next(httpContext);
            }
            catch (Exception ex)
            {
                await HandleExceptionAsync(httpContext, ex);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception exception)
        {
            context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is InvalidOperationException)
            {
                context.Response.StatusCode = (int)HttpStatusCode.BadRequest;
            }

            return Task.CompletedTask;
        }
    }
}
