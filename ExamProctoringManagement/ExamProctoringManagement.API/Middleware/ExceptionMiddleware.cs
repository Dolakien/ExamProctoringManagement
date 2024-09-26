using ExamProctoringManagement.Contract.Payloads.Response;
using ExamProctoringManagement.Repository.Exceptions;
using System.Text.Json;

namespace ExamProctoringManagement.API.Middleware
{
    public class ExceptionMiddleware
    {
        private readonly RequestDelegate _next;

        // Logger: to log the exception 
        private readonly ILogger<ExceptionMiddleware> _logger;


        public ExceptionMiddleware(RequestDelegate next, ILogger<ExceptionMiddleware> logger)
        {
            _next = next;
            _logger = logger;
        }

        // recognize this is middleware in the our frameworke, and the framework expect to see a method called Invoke Async
        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
            }
            catch (Exception ex)
            {
                // If they are not handling the exception before it gets to this one, then it is going to hit this particular.
                _logger.LogError(ex, ex.Message);
                await HandleExceptionAsync(context, ex);
            }
        }

        private static async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {
            var statusCode = GetStatusCode(ex);
            var response = new BaseResponse
            {
                StatusCode = statusCode,
                IsSuccess = false,
                Message = ex.Message,
                Data = null,
                Errors = GetErrors(ex),
            };

            context.Response.ContentType = "application/json";
            context.Response.StatusCode = (int)statusCode;

            var options = new JsonSerializerOptions
            {
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase
            };

            var json = JsonSerializer.Serialize(response, options);

            await context.Response.WriteAsync(json);
        }

        private static int GetStatusCode(Exception exception) =>
            exception switch
            {
                BadRequestException => StatusCodes.Status400BadRequest,
                NotFoundException => StatusCodes.Status404NotFound,
                ExamProctoringManagement.Repository.Exceptions.ValidationException => StatusCodes.Status400BadRequest,
                _ => StatusCodes.Status500InternalServerError
            };

        private static IDictionary<string, string[]> GetErrors(Exception exception)
        {
            IDictionary<string, string[]> errors = null;

            if (exception is ExamProctoringManagement.Repository.Exceptions.ValidationException validationException)
            {
                errors = validationException.Errors;
            }

            return errors;
        }
    }
}
