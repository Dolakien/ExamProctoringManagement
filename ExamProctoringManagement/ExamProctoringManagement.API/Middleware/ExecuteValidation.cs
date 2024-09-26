using FluentValidation;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace ExamProctoringManagement.API.Middleware
{
    public class ExecuteValidation : IAsyncActionFilter
    {
        private readonly IServiceProvider _serviceProvider;

        public ExecuteValidation(IServiceProvider serviceProvider) => _serviceProvider = serviceProvider;

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var method = context.HttpContext.Request.Method;
            if (method.Equals("POST") || method.Equals("PUT") || method.Equals("DELETE"))
            {
                var allErrors = new List<FluentValidation.Results.ValidationFailure>();

                // get All ValidationFailure
                foreach (var parameter in context.ActionDescriptor.Parameters)
                {
                    if (parameter.BindingInfo.BindingSource == BindingSource.Body)
                    {
                        var validator = _serviceProvider.GetService(typeof(IValidator<>).MakeGenericType(parameter.ParameterType)) as IValidator;
                        if (validator != null)
                        {
                            var subject = context.ActionArguments[parameter.Name];
                            var result = await validator.ValidateAsync(new ValidationContext<object>(subject), context.HttpContext.RequestAborted);
                            if (result.IsValid) continue;

                            allErrors.AddRange(result.Errors);
                        }
                    }
                }

                var errors = new Dictionary<string, string[]>();
                foreach (var validationFailure in allErrors)
                {
                    // If error property already exist 
                    if (errors.ContainsKey(validationFailure.PropertyName))
                    {
                        // From key -> get valudate and concat with new errors arr
                        errors[validationFailure.PropertyName] =
                            errors[validationFailure.PropertyName]
                                .Concat(new[] { validationFailure.ErrorMessage }).ToArray();
                    }
                    else // not exist property
                    {
                        errors.Add(
                            validationFailure.PropertyName,
                            new[] { validationFailure.ErrorMessage });
                    }
                }

                if (errors.Any())
                {
                    throw new ExamProctoringManagement.Repository.Exceptions.ValidationException(errors);
                }
                else
                {
                    await next();
                }
            }
            else
            {
                await next();
            }
        }
    }
}
