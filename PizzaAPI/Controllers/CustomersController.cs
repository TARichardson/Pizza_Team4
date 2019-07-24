using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PizzaAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Entities;
using PizzaAPI.Models.EntityRepository;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly ICustomerRepository _cr; 

        public CustomersController(APIDbContext context, ICustomerRepository cr)
        {
            _context = context;
            _cr = cr;
            _cr.APIDbContext = context;
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
            // error check for status needed
            return Ok(await _cr.GetAll());
        }
        // GET api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            // error check for status needed
            return Ok(await _cr.Get(id));
        }
        // GET api/Customers/
        [Route("Profile")]
        [HttpPost]
        public async Task<IActionResult> GetProfile([FromBody] CustomerDTO dto)
        {
            // error check for status needed
            return Ok(await _cr.Get(dto));
        }

        // POST api/Customers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDTO dto)
        {
            var result = await _cr.Add(dto);
            // error check for status needed
            return CreatedAtAction(
                nameof(Get),
                result);
        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDTO dto)
        {
            // error check for status needed
            Customer cus = await _cr.Update(id, dto);
            return cus != null ? Ok(cus) : NotFound("record not founded.");

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = await _cr.Delete(id);
            // error check for status needed
            return Ok(new KeyValuePair<string,Customer>("Customer delete", customer));

        }
    }
}
