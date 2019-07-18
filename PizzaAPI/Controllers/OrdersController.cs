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
    public class OrdersController : ControllerBase
    {
        private readonly APIDbContext _context;

        public OrdersController(APIDbContext context)
        {
            _context = context;
           
        }

        // GET: api/Orders
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        //{
        //    return await _context.Orders.ToListAsync();
        //}

        // GET: api/Orders/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetOrder(int id)
        {
            var order = await _context.Orders.Where(o => o.OrderID == id ).FirstOrDefaultAsync();

            if (order == null)
            {
                order = new Order()
                {
                    Pay = false,
                    TotalAmount = 0,
                    Customer = _context.Customers.Find(id)
                };
                _context.Orders.Add(order);
            }
            return order;
        }
        // GET: api/Orders/5
        [HttpGet("{id}")]
        [Route("CustomerCart/{Id}")]
        public async Task<ActionResult<Order>> GetCart(int id)
        {
            var order = await _context.Orders.Where(s => s.Customer.CustomerID == id && s.Pay == false).FirstOrDefaultAsync();

            if (order == null)
            {
                order = new Order()
                {
                    Pay = false,
                    TotalAmount = 0,
                    Customer = _context.Customers.Find(id)
                };
                _context.Orders.Add(order);
            }
            return order;
        }
        // PUT: api/Orders/5
        [HttpPut("{id}")]
        //public async Task<IActionResult> PutOrder(int id, Order order)
        //{
        //    if (id != order.OrderID)
        //    {
        //        return BadRequest();
        //    }
        //    _context.Entry(order).State = EntityState.Modified;
        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!OrderExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}


        // DELETE: api/Orders/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Order>> DeleteOrder(int id)
        {
            var order = await _context.Orders.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }

            _context.Orders.Remove(order);
            await _context.SaveChangesAsync();

            return order;
        }

        //private bool OrderExists(int id)
        //{
        //    return _context.Orders.Any(e => e.OrderID == id);
        //}
        [HttpGet("{id}")]
        [Route("History/{Id}")]
        public List<Order> History(int Id)
        {
            return _context.Orders.Where(b => b.Customer.CustomerID == Id &&b.Pay==true).ToList();
        }
        [HttpGet("{id}")]
        [Route("Transation/{Id}")]
        public void Transationsumbit(int? Id)
        {
           // Order.Where
        }
        
    }
}
