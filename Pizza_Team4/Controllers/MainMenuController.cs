using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;

namespace Pizza_Team4.Controllers
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

        public IActionResult OrdersHistory()
        {
            List<Order> orders = null;
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51953/api/Orders");

                    //HTTP POST
                    var request = client.GetAsync(client.BaseAddress);
                    request.Wait();

                    var result = request.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var read = result.Content.ReadAsAsync<List<Order>>();
                        read.Wait();
                        orders = read.Result;
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Registration Failed. Please contact administrator.");
                    }

                    ModelState.AddModelError(string.Empty, "Email Address and/or Password is Invalid. Try Again.");
                }
            }
            return View(orders);
        }


    }
}