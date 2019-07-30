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
using Microsoft.AspNetCore.Cors;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsOrigin")]
    public class CustomersController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly ICustomerRepository _cr; 

        public CustomersController(APIDbContext context, ICustomerRepository cr)
        {
            _context = context;
            _cr = cr;
            _cr.APIDbContext = context;
        }
        // GET api/Customers
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var customers = await _context.Customers.ToListAsync<Customer>();
            //// error check for status needed
            if (customers == null) { return NotFound("records not found."); }
            return Ok(customers);
        }

        // GET api/Customers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var customer = await _cr.Get(id);
            // error check for status 
            if (customer == null) { return NotFound("record not found."); }
            return Ok(customer);
        }
        // GET api/Customers/
        [Route("Profile")]
        [HttpPost]
        public async Task<IActionResult> GetProfile([FromBody] CustomerDTO dto)
        {
            var customer = await _cr.Get(dto);
            // error check for status 
            if (customer == null) { return NotFound("record not found."); }
            return Ok(customer);
        }

        // POST api/Customers
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CustomerDTO dto)
        {
            var result = await _cr.Add(dto);
            // error check for status 
            if (result == null) { return BadRequest("Customer was not created."); }
            return CreatedAtAction(
                nameof(Get),
                result);
        }

        // PUT api/Customers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] CustomerDTO dto)
        {
            Customer cus = await _cr.Update(id, dto);
            // error check for status 
            if (cus == null) { return NotFound("record not found."); }
            return Ok(cus);
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Customer customer = await _cr.Delete(id);
            // error check for status 
            if (customer == null) { return NotFound("record not found."); }
            return Ok(new KeyValuePair<string,Customer>("Customer deleted", customer));

        }
    }
}
