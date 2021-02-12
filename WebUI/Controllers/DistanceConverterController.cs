using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ConsoleAppProject.App01;

namespace WebUI.Controllers
{
    public class DistanceConverterController : Controller
    {
        DistanceConverter converter = new DistanceConverter();
        public IActionResult DistanceConverter(DistanceConverter converter)
        {
            return View(converter);
        }
    }
}
