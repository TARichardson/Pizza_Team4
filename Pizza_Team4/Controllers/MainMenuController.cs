using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace BankMVCApp.Controllers
{
    public class MainMenuController : Controller
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


    }
}