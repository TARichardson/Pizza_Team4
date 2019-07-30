using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Entities;
namespace Pizza_Team4.Controllers
{


    public class OrdersController : Controller
    {
        private static MyHttpClient _client = new MyHttpClient();

        [HttpGet("History/{id}")]
        public async Task<IActionResult> history(int id)
        {
            Console.WriteLine("Method GetCustomersObject()...");
            var Orders = await _client.history(id);
            return View(Orders);

        }
        [HttpGet("cart/{id}")]
        public async Task<IActionResult> index(int id)
        {
            var items = await _client.Cart(id);
            return View(items);

        }
        [HttpGet("Transation/{id}")]
        public async Task<IActionResult> Transaction(int id)
        {
            var items = await _client.Transaction(id);
            return View(items);

        }
        [HttpGet("Payment/{Id}")]
        public async Task<IActionResult> Payment(int id)
        {
            var payment = await _client.Payment(id);
            return View(payment);
        }
        [HttpPost("Payment/{Id}")]
        public async Task<IActionResult> Payment(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var payment = await _client.Payment(id);
            var card = payment.Where(p => p.CardNumber == id).FirstOrDefault();
            if (card == null)
            {
                return NotFound();
            }
            return RedirectToAction("History", new { id = card.CustomerId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            var item = await _client.DeleteItem(id);
            return RedirectToAction("Index", new { id = id });

        }

     

    }
}