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

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly APIDbContext _context;
        private readonly IItemRepository _cr;

        public ItemsController(APIDbContext context,IItemRepository cr)
        {
            _context = context;
            _cr = cr;
            _cr.APIDbContext = context;

        }

        // GET: api/Items
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems(int ID)
        {

            return Ok(await _cr.GetAll(ID));
        }

        // GET: api/Items/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Item>> GetItem(int id)
        //{
        //    var item = await _context.Items.FindAsync(id);

        //    if (item == null)
        //    {
        //        return NotFound();
        //    }

        //    return item;
        //}

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutItem(int id, Item item)
        {
            if (id != item.ItemID)
            {
                return BadRequest();
            }

            _context.Entry(item).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ItemExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Items

        [HttpPost("{id}")]
        public async Task<ActionResult<Item>> AddItem(Item item,int OrderID)
        {
            return Ok(await _cr.Add(item,OrderID));
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Item>> DeleteItem(int id)
        {
            var item = await _context.Items.Include("Order").Where(i=>i.ItemID==id).FirstAsync();
            if (item == null)
            {
                return NotFound();
            }
            return Ok(await _cr.Delete(id));
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
