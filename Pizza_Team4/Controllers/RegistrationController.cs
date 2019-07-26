using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Pizza_Team4.Controllers
{
    public class RegistrationController : Controller
    {
        
        public RegistrationController()
        {
           
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register([Bind("FirstName,LastName,Email,Phone,Address,City,State,ZipCode,Password")] Customer customer)
        {
            customer.DateCreated = DateTime.Now;

            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51953/api/Customers");

                    //HTTP POST
                    var postTask = client.PostAsJsonAsync<Customer>(client.BaseAddress, customer);
                    postTask.Wait();

                    var result = postTask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        return RedirectToAction(nameof(Register)); ;
                    }

                    ModelState.AddModelError(string.Empty, "Server Error. Registration Failed. Please contact administrator.");
                }
            }
            
            return View(customer);
        }
    }
}