using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using CsvHelper;
using Microsoft.AspNetCore.Hosting;
using Task_6_RandomData.Constants;
using Task_6_RandomData.Logic;
using Task_6_RandomData.Models;

namespace Task_6_RandomData.Controllers
{
    public class HomeController : Controller
    {
        private const int PageSize = 20;
        private IWebHostEnvironment _webHostEnvironment;

        public HomeController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult GetData(RequestDataModel model)
        {
            var region = model.Region;
            var mistakesCount = model.MistakesCount;

            if (model.Seed > 0)
            {
                region = (Regions)GetHash(model.Seed, Enum.GetNames<Regions>().Length);
                mistakesCount = GetHash(model.Seed, 100);
            }

            var data = Generator.GetData(region, mistakesCount, model.Seed);

            return Json(data.Skip((model.PageNumber - 1) * PageSize).Take(PageSize));
        }

        [HttpPost]
        public IActionResult CreateCsv([FromBody]IEnumerable<PersonInfo> persons)
        {
            var path = $"{Directory.GetCurrentDirectory()}{DateTime.Now.Ticks}.csv";

            using var writer = new StreamWriter(path);

            using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
            {
                csv.WriteRecords(persons);
            }

            return PhysicalFile(path, "text/csv");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        private static int GetHash(int key, int maxValue) => Math.Abs(key.GetHashCode() % maxValue);
    }
}
