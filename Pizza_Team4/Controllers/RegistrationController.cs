using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Pizza_Team4.Controllers
{
    public class RegistrationController : Controller
    {
        private static MyHttpClient _client = new MyHttpClient();


        public RegistrationController()
        {
           
        }
        [HttpGet]
        [Route("Registration")]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [Route("Registration")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([Bind("FirstName,LastName,Address,City,State,ZipCode,Phone,Email,Password")] CustomerDTO dto)
        {
            var customer = await _client.AddCustomer(dto);
           // var customer = await _client.GetCustomers();
            //var customer = task.Result;

            if (customer != null)
            {
                return RedirectToAction("index",
                    "Loading",
                    new { id = customer.CustomerID, toProfile = false });
            }
            return View(customer);
        }
    }
}