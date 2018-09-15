using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using ShyneeBackend.Domain.Exceptions;
using System;
using System.Net;
using System.Threading.Tasks;

namespace ShyneeBackend.Application.Middlewares
{
    public class ErrorHandlingMiddleware
    {
        private readonly RequestDelegate next;

        public ErrorHandlingMiddleware(RequestDelegate next)
        {
            this.next = next;
        }

        public async Task Invoke(HttpContext context /* other dependencies */)
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
            var code = HttpStatusCode.InternalServerError;

            if (exception is ShyneeNotFoundException) code = HttpStatusCode.NotFound;
            if (exception is ShyneeDuplicateException) code = HttpStatusCode.Conflict;
            if (exception is ShyneeProfileNicknameIsEmptyException) code = HttpStatusCode.BadRequest;
            if (exception is InvalidPasswordException) code = HttpStatusCode.Unauthorized;

            var result = JsonConvert.SerializeObject(new { error = exception.Message });
            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)code;
            return context.Response.WriteAsync(result);
        }
    }
}
