using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Entities;

namespace Pizza_Team4.Controllers
{
    public class LoadingController : Controller
    {
        public IActionResult Index(int id = -1, bool toProfile = false)
        {
            if (id != -1)
            {
                ViewBag.CustomerID = id.ToString();
            }
            ViewBag.toProfile = toProfile.ToString().ToLower();
            return View();
        }
        [HttpGet]
        public IActionResult LoadCustomer()
        {
            return View();
        }
        [HttpPost]
        public IActionResult LoadCustomer([Bind("FirstName,LastName,Address,City,State,ZipCode,Phone,Email,Password")]  Customer customer)
        {
            if (!ModelState.IsValid)
            {
                return View(customer);
            }
            return RedirectToAction("index", "MainMenu");
        }

    }
}