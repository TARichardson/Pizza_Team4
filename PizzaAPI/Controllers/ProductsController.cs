using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using PizzaAPI.Models;
using PizzaAPI.Models.EntityRepository;
using Microsoft.AspNetCore.Cors;


namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("CorsOrigin")]
    public class ProductsController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IProductRepository _cr;
        public ProductsController(APIDbContext context, IProductRepository cr)
        {
            _context = context;
            _cr = cr;
            _cr.APIDbContext = context;
            //if (_context.Products.Count() == 0)
            //{
            //    _context.Products.AddRange(
            //        new Product
            //        {
            //        
            //        }
            //         );
            //    _context.SaveChanges();
            //}
        }
        // GET api/Products
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var products = await _context.Products.ToListAsync<Product>();
            if (products == null) { return NotFound("records not found."); }
            return Ok(products);
        }

        // GET api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var product = await _cr.Get(id);
            // error check for status 
            if(product == null) { return NotFound("record not found."); }
            return Ok(await _cr.Get(id));
        }

        // POST api/Products
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Product dto)
        {
            var result = await _cr.Add(dto);
            // error check for status 
            if (result == null) { return BadRequest("Product was not created."); }
            return CreatedAtAction(
                nameof(Get),
                result);
        }

        // PUT api/Products/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Product dto)
        {
            Product product = await _cr.Update(dto);
            // error check for status 
            if (product == null) { return NotFound("record not found."); }
            return Ok(product);
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _cr.Delete(id);
            // error check for status 
            if (product == null) { return NotFound("record not found."); }
            return Ok(new KeyValuePair<string, Product>("Product deleted", product));

        }
    }
}
