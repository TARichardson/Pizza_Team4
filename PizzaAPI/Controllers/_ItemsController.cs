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
        private readonly IItemRepository itemRepository;


        public ItemsController(APIDbContext context, IItemRepository itemRepository)
        {
            _context = context;
            this.itemRepository = itemRepository;
            this.itemRepository.APIDbContext = context;
        }

        // GET: api/Items
        [HttpGet]
        public ActionResult<IEnumerable<Item>> GetItems()
        {
            return  itemRepository.GetAll();
        }

        // GET: api/Items/5
        [HttpGet("{id}")]
        public ActionResult<Item> GetItem(int id)
        {
            var item = itemRepository.Get(id);

            if (item == null)
            {
                return NotFound();
            }

            return item;
        }

        // PUT: api/Items/5
        [HttpPut("{id}")]
        public IActionResult PutItem(int id, Item item)
        {
            if (id != item.ItemId)
            {
                return BadRequest();
            }

            try
            {
                itemRepository.Update(item);
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
        [HttpPost]
        public ActionResult<Item> PostItem(Item item)
        {
            itemRepository.Add(item);

            return CreatedAtAction("GetItem", new { id = item.ItemId }, item);
        }

        // DELETE: api/Items/5
        [HttpDelete("{id}")]
        public ActionResult<Item> DeleteItem(int id)
        {
            var item = itemRepository.Get(id);
            if (item == null)
            {
                return NotFound();
            }

            itemRepository.Delete(id);

            return item;
        }

        private bool ItemExists(int id)
        {
            return _context.Items.Any(e => e.ItemId == id);
        }
    }
}
