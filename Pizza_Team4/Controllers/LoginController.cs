using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Mvc;


namespace Pizza_Team4.Controllers
{
    public class LoginController : Controller
    {
        public MyHttpClient _client = new MyHttpClient();

        public LoginController()
        {
            
        }
        [HttpGet]
        [Route("Login")]
        public IActionResult Login()
        {
            return View();
        }

        
        [HttpPost]
        [Route("Login")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([Bind("Email, Password")] CustomerDTO login)
        {

            if (ModelState.IsValid)
            {
                var customer = await _client.GetCustomersProfile(login);
                // add customer obj to app customer
                return RedirectToAction("index",
                                     "Loading",
                                     new { id = customer.CustomerID, toProfile = false });
            }
            return View(login);
        }

        public IActionResult OrderMenu()
        {
            return View();
        }

    }
}