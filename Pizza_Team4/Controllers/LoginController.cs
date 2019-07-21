using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;


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
        public IActionResult Login([Bind("Email, Password")] CustomerDTO login)
        {
            if (ModelState.IsValid)
            {
                
                
                return RedirectToAction(nameof(Login));
            }
            return View(login);
        }
    }
}