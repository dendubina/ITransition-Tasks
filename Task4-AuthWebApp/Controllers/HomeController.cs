using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Task4AuthWebApp.Models;
using Task4AuthWebApp.Services.Interfaces;

namespace Task4AuthWebApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly IUserService _userService;

        public HomeController(IUserService userService)
        {
            _userService = userService;
        }

        public IActionResult Index()
        {
            return View(_userService.FindAll().ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
