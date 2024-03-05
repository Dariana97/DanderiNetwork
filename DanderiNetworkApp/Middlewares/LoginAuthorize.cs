using DanderiNetworkApp.Controllers;
using DanderiNetworkApp.Middlewares;
using Microsoft.AspNetCore.Mvc.Filters;

namespace DanderiNetworkApp.Midleware
{
    public class LoginAuthorize : IAsyncActionFilter
    {
        private readonly ValidateUserSession _userSession;

        public LoginAuthorize(ValidateUserSession userSession)
        {
            _userSession = userSession;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (_userSession.HasUser())
            {
                var controller = (UserController)context.Controller;
                context.Result = controller.RedirectToAction("Index", "Home");
            }
            else
            {
                await next();
            }
        }
    }
}
