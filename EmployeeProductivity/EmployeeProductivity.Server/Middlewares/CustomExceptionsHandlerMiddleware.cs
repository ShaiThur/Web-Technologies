using Application.Common.Exceptions;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeProductivity.Server.Middleware
{
    public class CustomExceptionsHandlerMiddleware : IExceptionHandler
    {
        private readonly Dictionary<Type, Func<HttpContext, Exception, Task>> _exceptionHandlers;

        public CustomExceptionsHandlerMiddleware()
        {
            _exceptionHandlers = new()
            {
                { typeof(MyValidationException), HandleValidationException },
                { typeof(NullEntityException), HandleNullEntityException },
                {typeof(UnauthorizedAccessException), HandleUnauthorizedAccessException }
            };
        }

        public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
        {
            var exceptionType = exception.GetType();

            if (_exceptionHandlers.ContainsKey(exceptionType))
            {
                await _exceptionHandlers[exceptionType].Invoke(httpContext, exception);
                return true;
            }

            return false;
        }

        private async Task HandleValidationException(HttpContext context, Exception ex)
        {
            var exception = (MyValidationException)ex;

            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            await context.Response.WriteAsJsonAsync(new ValidationProblemDetails(exception.Errors)
            {
                Status = StatusCodes.Status400BadRequest,
                Type = exception.Message
            });
        }

        private async Task HandleNullEntityException(HttpContext context, Exception ex)
        {
            var exception = (NullEntityException)ex;

            context.Response.StatusCode = StatusCodes.Status404NotFound;

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = StatusCodes.Status404NotFound,
                Title = exception.Message
            });
        }

        private async Task HandleUnauthorizedAccessException(HttpContext context, Exception ex)
        {
            var exception = (UnauthorizedAccessException)ex;

            context.Response.StatusCode = StatusCodes.Status401Unauthorized;

            await context.Response.WriteAsJsonAsync(new ProblemDetails
            {
                Status = StatusCodes.Status401Unauthorized,
                Title = exception.Message
            });
        }
    }
}
