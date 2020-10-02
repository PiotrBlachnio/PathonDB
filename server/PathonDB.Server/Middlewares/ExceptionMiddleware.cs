using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using PathonDB.Server.Exceptions;

namespace PathonDB.Server.Middlewares {
    public class ExceptionMiddleware {
        private readonly RequestDelegate _next;
        private readonly ILogger<ExceptionMiddleware> _logger;

        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger) {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext httpContext) {
            try {
                await _next(httpContext);
            } catch(Exception error) {
                _logger.LogError($"Something went wrong: {error.Message}");
                await HandleExceptionAsync(httpContext, error);
            }
        }

        private Task HandleExceptionAsync(HttpContext context, Exception error) {
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = 400;

            return context.Response.WriteAsync(new ExceptionDetails() {
                Message = error.Message
            }.ToString());
        }
    }
}