using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Registration.Core.Common.Response;
using Registration.Infrastructure.Common.Response;

namespace Registration.Api.ValidFilter
{
    public class ValidatorActionFilter : IAsyncActionFilter
    {
        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errorsInModelState = context.ModelState
                    .Where(x => x.Value.Errors.Count > 0)
                    .ToDictionary(g => g.Key, g => g.Value.Errors.Select(x => x.ErrorMessage)).ToArray();
                var response = new OutputResponseForValidationFilter();
                foreach (var error in errorsInModelState)
                {
                    foreach (var subError in error.Value)
                    {
                        var errorModel = new ErrorModel()
                        {
                            Property = error.Key,
                            Message = subError
                        };
                        response.Message = "your request can't complete due to some error in your model";
                        response.Success = false;
                        response.Model = null;
                        response.Errors.Add(errorModel);
                    }
                }
                context.Result = new BadRequestObjectResult(response);
                return;
            }

            await next();
        }
    }
}
