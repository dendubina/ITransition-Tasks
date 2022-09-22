using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Task4AuthWebApp.Constants;
using Task4AuthWebApp.Entities;

namespace Task4AuthWebApp.Middlewares
{
    public class LogoutMiddleware
    {
        private readonly RequestDelegate _next;

        public LogoutMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context, UserManager<User> userManager, SignInManager<User> signInManager)
        {
            await _next(context);

            if (context.User.Identity is { IsAuthenticated: true })
            {
                var email = context.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.Email)?.Value;

                var user = await userManager.FindByEmailAsync(email);

                if (user is null || user.Status == UserStatuses.Blocked)
                {
                    await signInManager.SignOutAsync();
                }
            }
        }
    }
}
