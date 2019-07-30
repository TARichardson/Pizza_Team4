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
        static HttpClient client = new HttpClient();
        string _url = "https://localhost:44361/";

        [HttpGet("History/{id}")]
        public async Task<IActionResult> history(int id)
        {
            Console.WriteLine("Method GetCustomersObject()...");

            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(

            new MediaTypeWithQualityHeaderValue("application/json"));

            var apiUrl = "api/orders/History/" + id;

            var stringTask = await client.GetStringAsync(_url + apiUrl);

            //var res = stringTask.Result;

            var Orders = JsonConvert.DeserializeObject<IEnumerable<Order>>(stringTask);
            return View(Orders);

        }
        [HttpGet("cart/{id}")]
        public async Task<IActionResult> index(int id)
        {
            HttpClient client = new HttpClient();

            client.DefaultRequestHeaders.Accept.Clear();

            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var apiUrl = "api/items/";
            var stringTask = await client.GetStringAsync(_url + apiUrl + id);
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(stringTask);
            return View(items);

        }
        [HttpGet("Transation/{id}")]
        public async Task<IActionResult> Transaction(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var apiUrl = "api/orders/Transation/";
            var stringTask = await client.GetStringAsync(_url + apiUrl + id);
            var items = JsonConvert.DeserializeObject<IEnumerable<Item>>(stringTask);
            return View(items);

        }
        [HttpGet("Payment/{Id}")]
        public async Task<IActionResult> Payment(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var apiUrl = "api/orders/Payment/";
            var stringTask = await client.GetStringAsync(_url + apiUrl + id);
            var payment = JsonConvert.DeserializeObject<IEnumerable<Payment>>(stringTask);
            return View(payment);
        }
        [HttpPost("Payment/{Id}")]
        public async Task<IActionResult> Payment(string id)
        {
            if (id == null)
            {
                return NotFound();
            }
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var apiUrl = "api/orders/Payment/";
            var stringTask = await client.GetStringAsync(_url + apiUrl + id);
            var payment = JsonConvert.DeserializeObject<IEnumerable<Payment>>(stringTask);
            var card = payment.Where(p => p.CardNumber == id).FirstOrDefault();
            if (card == null)
            {
                return NotFound();
            }
            return RedirectToAction("History", new { id = card.CustomerId });
        }

        public async Task<IActionResult> Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
            new MediaTypeWithQualityHeaderValue("application/json"));
            var apiUrl = "api/items/";
            var streamString = await client.DeleteAsync(_url + apiUrl + id);
            var res = await streamString.Content.ReadAsStringAsync();
            var item = JsonConvert.DeserializeObject<Item>(res);
            return RedirectToAction("Index", new { id = id });

        }

     

    }
}