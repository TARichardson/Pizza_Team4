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
    public class CategoriesController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly ICategoryRepository _cr;
        public CategoriesController(APIDbContext context, ICategoryRepository cr)
        {
            _context = context;
            _cr = cr;
            _cr.APIDbContext = context;
        }
        // GET api/Category
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var categories = await _context.Category.ToListAsync<Category>();
            if (categories == null) { return NotFound("records not found."); }
            return Ok(categories);
        }

        // GET api/Category/5
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var category = await _cr.Get(id);
            // error check for status 
            if (category == null) { return NotFound("record not found."); }
            return Ok(await _cr.Get(id));
        }

        // POST api/Category
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Category dto)
        {
            var result = await _cr.Add(dto);
            // error check for status 
            if (result == null) { return BadRequest("Category was not created."); }
            return CreatedAtAction(
                nameof(Get),
                result);
        }

        // PUT api/Category/5
        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromBody] Category dto)
        {
            Category category = await _cr.Update(dto);
            // error check for status 
            if (category == null) { return NotFound("record not found."); }
            return Ok(category);
        }
        // DELETE api/values/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Category category = await _cr.Delete(id);
            // error check for status 
            if (category == null) { return NotFound("record not found."); }
            return Ok(new KeyValuePair<string, Category>("Category deleted", category));

        }
    }
}