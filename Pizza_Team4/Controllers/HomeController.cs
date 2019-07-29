using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Pizza_Team4.Models;
using Entities;

namespace Pizza_Team4.Controllers
{
    public class HomeController : Controller
    {
        MyHttpClient myhttpclient = new MyHttpClient();
        public IActionResult Index()
        {
            myhttpclient.ApiURL = "customers";
            ViewBag.CustomerUrl = myhttpclient.FullApiURL;
            ViewBag.BaseUrl = myhttpclient.BaseApiURL;
            ViewBag.MediaType = myhttpclient.MediaType;
            return View();
        }
        [Route("Pizza")]
        public IActionResult Pizza()
        {
            return View();
        }
        [Route("Stromboli")]
        public IActionResult Stromboli()
        {
            return View();
        }
        [Route("Calzone")]
        public IActionResult Calzone()
        {
            return View();
        }
        [Route("Sides")]
        public IActionResult Sides()
        {
            return View();
        }
        [Route("Drinks")]
        public IActionResult Drinks()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
