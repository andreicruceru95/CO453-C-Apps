using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;
using ConsoleAppProject.App01;
using ConsoleAppProject.App02;

namespace WebUI.Controllers
{
    public class HomeController : Controller
    {
        DistanceConverter converter = new DistanceConverter();
        BMI BmiCalculator = new BMI();
        public IActionResult BMICalculator(BMI BmiCalculator)
        {
            return View(BmiCalculator);
        }

        public IActionResult BMIResultM(BMI model)
        { 
            var Bmi = model.CalculateBmi(true);
            ViewBag.BMIResult = Bmi;
            ViewBag.BMIMessage = model.GetDetails(Bmi);

            return View();
        }
        public IActionResult BMIResultI(BMI model)
        {
            var Bmi = model.CalculateBmi(false);
            ViewBag.BMIResult = Bmi;
            ViewBag.BMIMessage = model.GetDetails(Bmi);

            return View();
        }
        public IActionResult DistanceConverter(DistanceConverter converter)
        {
            return View(converter);
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
