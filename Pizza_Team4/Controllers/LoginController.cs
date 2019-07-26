using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizza_Team4.BusinessLogic;

namespace Pizza_Team4.Controllers
{
    public class LoginController : Controller
    {
     

        public LoginController()
        {
            
        }

        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login([Bind("Email, Password")] Login login)
        {
            if (ModelState.IsValid)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("http://localhost:51953/api/Customers");

                    //HTTP POST
                    var request = client.GetAsync(client.BaseAddress);
                    request.Wait();

                    var result = request.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var read = result.Content.ReadAsAsync<List<Customer>>();
                        read.Wait();
                        var customers = read.Result;
                        foreach(Customer customer in customers)
                        {
                            if(customer.Email==login.Email && customer.Password == login.Password)
                            {
                                Operations.currentCustomer = customer;
                                return RedirectToAction(nameof(OrderMenu));
                            }
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Server Error. Registration Failed. Please contact administrator.");
                    }

                    ModelState.AddModelError(string.Empty, "Email Address and/or Password is Invalid. Try Again.");
                }             
            }
            return View(login);
        }

        public IActionResult OrderMenu()
        {
            return View();
        }

    }
}