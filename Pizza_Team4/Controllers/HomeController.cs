using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizza_Team4.Models;

namespace PizzaUI.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Pizza()
        {
            return View();
        }

        public IActionResult Stromboli()
        {
            return View();
        }

        public IActionResult Calzone()
        {
            return View();
        }

        public IActionResult Sides()
        {
            return View();
        }

        public IActionResult Drinks()
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
