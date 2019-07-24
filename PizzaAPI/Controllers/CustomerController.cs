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
                        Password = "passpass"
                    }
                    );
                _context.Customers.Add(
                    new Customer
                    {
                        FirstName = "Rob",
                        Email = "r@a.com",
                        Password = "passpass"
                    }
                    );
                _context.Customers.Add(
                     new Customer
                     {
                         FirstName = "Tom",
                         Email = "t@a.com",
                         Password = "passpass"
                     }
                     );
                _context.SaveChanges();
            }
        }
        // GET api/Customers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return  Ok(await _context.Customers.ToListAsync<Customer>());
        }
        // GET api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return Ok(await _context.Customers.FindAsync(id));
        }

        // POST api/Customers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            var result = await _context.Customers.FindAsync(_context.Customers.Count());
            return CreatedAtAction(
                nameof(Get),
                result);
        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDTO dto)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            //customer.CustomerID = id;
            customer = customer + dto;
            _context.Customers.Update(customer).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(customer);

        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = await _context.Customers.FindAsync(id);
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return Ok(new KeyValuePair<string,Customer>("Customer delete", customer));

        }
    }
}
