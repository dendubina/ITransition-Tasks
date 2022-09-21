using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Task4AuthWebApp.Models;
using Task4AuthWebApp.Services.Interfaces;

namespace Task4AuthWebApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult SignIn()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            await _authService.SignInAsync(model.Email, model.Password);

            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            await _authService.SignUpAsync(model.Email, model.UserName, model.Password);

            return RedirectToAction("Index", "Home");
        }

        public async Task<IActionResult> Logout()
        {
            await _authService.Logout();

            return RedirectToAction("Index", "Home");
        }
    }
}
