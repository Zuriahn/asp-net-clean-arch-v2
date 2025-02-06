using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Web.API.Common.Auhorization
{
    public class CustomAuthorizationFilter : AuthorizeAttribute
    {
        public void OnAuthorization(AuthorizationFilterContext context)
        {
            var user = context.HttpContext.User;

            if (user == null || !user.Identity!.IsAuthenticated)
            {
                var error = Error.Unauthorized("You are unauthorized to access this resource.");

                var problemDetails = new ProblemDetails
                {
                    Status = StatusCodes.Status401Unauthorized,
                    Title = error.Description
                };

                context.Result = new ObjectResult(problemDetails)
                {
                    StatusCode = StatusCodes.Status401Unauthorized
                };
            }
        }
    }

}