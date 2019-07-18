using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Entities;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly APIDbContext _context;

        public CustomerController(APIDbContext context)
        {
            _context = context;
            if (_context.Customers.Count() == 0)
            {
                _context.Customers.Add(
                    new Customer
                    {
                        FirstName = "Troy",
                        Email = "a@a.com",
                        Password = "pass"
                    }
                    );
                _context.Customers.Add(
                    new Customer
                    {
                        FirstName = "Rob",
                        Email = "r@a.com",
                        Password = "pass"
                    }
                    );
                _context.Customers.Add(
                     new Customer
                     {
                         FirstName = "Tom",
                         Email = "t@a.com",
                         Password = "pass"
                     }
                     );
                _context.SaveChanges();
            }
        }
        // GET api/Customer
        [HttpGet]
        public async Task<IEnumerable<Customer>> Get()
        {
            return await _context.Customers.ToListAsync<Customer>();
        }

        // GET api/Customer/5
        [HttpGet("{id}")]
        public async Task<Customer> Get(int id)
        {
            return await _context.Customers.FindAsync(id);
        }

        // POST api/values
        [HttpPost]
        public async void Post([FromBody] Customer value)
        {
                _context.Customers.Add(value);
                await _context.SaveChangesAsync();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)

        {
        }
    }
}
