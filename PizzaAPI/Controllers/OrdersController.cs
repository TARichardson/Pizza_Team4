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
    public class OrdersController : ControllerBase
    {
        private readonly APIDbContext _context;

        private readonly IOrderRepository _cr;

        public OrdersController(APIDbContext context,IOrderRepository cr)          
        {
            _context = context;
            _cr = cr;
            _cr.APIDbContext = context;

        }
        //[HttpGet]
        //public async Task<IEnumerable<Order>> Get()
        //{
        //    return await _context.Orders.Include("Customer").ToListAsync<Order>();
        //}

        // GET: api/Orders
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Order>>> GetOrders()
        //{
        //    return await _context.Orders.ToListAsync();
        //}

        //// GET: api/Orders/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<Order>> GetOrder(int id)
        //{
        //    var order = await _context.Orders.Include("Customer").Where(o => o.OrderID == id ).FirstOrDefaultAsync();

        //    if (order == null)
        //    {
        //        order = new Order()
        //        {
        //            Pay = false,
        //            TotalAmount = 0,
        //            Customer = _context.Customers.Find(id)
        //        };
        //        _context.Orders.Add(order);
        //    }
        //    return order;
        //}
        // GET: api/Orders/5
        [HttpGet("CustomerCart/{id}")]
        [Route("CustomerCart/{Id}")]
        public async Task<IActionResult> GetCart(int id)
        {
            return  Ok(await _cr.GetOrder(id));
        }
        // PUT: api/Orders/5
        //[HttpPut("{id}")]
        //[Route("AddCart/{Id}")]
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
        //[HttpDelete("Delet/{id}")]
        //public async Task<ActionResult<Order>> DeleteOrder(int id)
        //{
        //    var order = await _context.Orders.FindAsync(id);
        //    if (order == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.Orders.Remove(order);
        //    await _context.SaveChangesAsync();

        //    return order;
        //}

        //private bool OrderExists(int id)
        //{
        //    return _context.Orders.Any(e => e.OrderID == id);
        //}
        [HttpGet("History/{id}")]
        [Route("History/{Id}")]
        public async Task<IActionResult> History(int Id)
        {
            return Ok(await _cr.GetHistory(Id));
        }
        [HttpGet("Transation/{id}")]
        [Route("Transation/{Id}")]
        public async Task<IActionResult> Transation(int Id)
        {
            return Ok(await _cr.Transation(Id));
        }
        [HttpGet("Transationsumbit/{id}")]
        [Route("Transationsumbit/{Id}")]
        public async Task<IActionResult> Transationsumbit(int Id)
        {
            return Ok(await _cr.Transationsumbit(Id));           
        }
        [HttpGet("Payment/{Id}")]
        public async Task<IActionResult>Paymen(int Id)
        {
            return Ok(await _cr.Payment(Id));
        }


    }
}
