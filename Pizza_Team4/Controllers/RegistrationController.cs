using System;
using System.Collections.Generic;
using System.Linq;
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
        public IActionResult Register([Bind("FirstName,LastName,Address,City,State,ZipCode,Phone,Email,Password")] CustomerDTO customer)
        {
            if (ModelState.IsValid)
            {
                
                return RedirectToAction(nameof(Register));
            }
            return View(customer);
        }
    }
}