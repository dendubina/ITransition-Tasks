using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Linq;
using Task_6_RandomData.Logic;
using Task_6_RandomData.Models;

namespace Task_6_RandomData.Controllers
{
    public class HomeController : Controller
    {

        public HomeController()
        {
           
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData(RequestDataModel model)
        {
            var data = Generator.GetData(model.Region, model.MistakesCount, model.Seed);

            return Json(data.Skip((model.PageNumber - 1) * 20).Take(20));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
