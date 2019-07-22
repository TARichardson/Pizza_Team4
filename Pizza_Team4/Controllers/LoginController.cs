using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


namespace PizzaUI.Controllers
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
                
                
                return RedirectToAction(nameof(OrderMenu));
            }
            return View(login);
        }

        public IActionResult OrderMenu()
        {
            return View();
        }

    }
}