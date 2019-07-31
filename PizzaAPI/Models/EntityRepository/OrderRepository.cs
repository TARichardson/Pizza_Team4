using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using Microsoft.EntityFrameworkCore;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public class OrderRepository : IOrderRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public OrderRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        //public void Add(Order order)
        //{
        //    APIDbContext.Orders.Add(order);
        //    APIDbContext.SaveChanges();
        //}

        //public Order Delete(int id)
        //{
        //    Order order = APIDbContext.Orders.Find(id);
        //    if (order != null)
        //    {
        //        APIDbContext.Orders.Remove(order);
        //        APIDbContext.SaveChanges();
        //    }
        //    return order;
        //}

        public async Task<Order> GetOrder(int id)
        {

            var order = await APIDbContext.Orders.Include("Customer").Where(s => s.Customer.CustomerID == id && s.Pay == false).FirstOrDefaultAsync();

            if (order == null)
            {
                order = new Order()
                {
                    Pay = false,
                    TotalAmount = 0,
                    Customer = await APIDbContext.Customers.FindAsync(id)

                };
                APIDbContext.Orders.Add(order);
                await APIDbContext.SaveChangesAsync();

            }
            return order;
        }


        public async Task<List<Order>> GetHistory(int customerId)
        {
            var qu = await APIDbContext.Orders.Where(b => b.Customer.CustomerID == customerId && b.Pay == true).ToListAsync();
            return qu;
        }
        public async Task<List<Item>> Transation(int Id)
        {
            var transaction = await APIDbContext.Items.Include("Order").Where(s => s.Order.OrderID == Id).ToListAsync();
            //var TotalAmount = transaction[0].Order.TotalAmount;
            return transaction;


        }
        public async Task<Order> Transationsumbit(int Id)
        {
            var transaction = await APIDbContext.Orders.Where(s => s.OrderID == Id&&s.Pay==false).FirstOrDefaultAsync();
            transaction.Pay = true;
            APIDbContext.Orders.Update(transaction);
            await APIDbContext.SaveChangesAsync();
            //var TotalAmount = transaction[0].Order.TotalAmount;
            return transaction;


        }
        public async Task<List<Payment>>Payment(int Id)
        {
            var order = await APIDbContext.Orders.Include("Customer").Where(o => o.OrderID==Id).FirstOrDefaultAsync();
            var card=await APIDbContext.Payment.Where(p=>p.CustomerID==order.Customer.CustomerID).ToListAsync();
            return card;
        }
    }
}

