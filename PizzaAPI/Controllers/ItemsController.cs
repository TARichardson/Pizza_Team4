using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly APIDbContext _context;

        public ItemsController(APIDbContext context)
        {
            _context = context;
        }

        // GET: api/Items
        [HttpGet("{id}")]
        public async Task<ActionResult<IEnumerable<Item>>> GetItems(int ID)
        {

            return await _context.Items.Include("Order").Where(i => i.ItemID == ID).ToListAsync();
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
            var order = _context.Orders.Where(o => o.OrderID == OrderID).FirstOrDefault();
            Item i = new Item();
            i.Order = order;
            i.qty = item.qty;
            i.Amount = item.Amount;
            order.TotalAmount += (decimal)item.Amount;
            _context.Orders.Update(order);
            _context.Items.Add(i);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetItem", new { id = item.ItemID, OrderID= item.Order.OrderID}, item);
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
            var order = _context.Orders.Where(o=>o.OrderID==item.Order.OrderID).FirstOrDefault();
            order.TotalAmount = order.TotalAmount - item.Amount;
            _context.Items.Remove(item);
            _context.Update(order);
            await _context.SaveChangesAsync();

            return item;
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemID == id);
        }
    }
}
