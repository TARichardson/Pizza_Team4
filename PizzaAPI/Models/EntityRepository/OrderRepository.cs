using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
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

        public void Add(Order order)
        {
            APIDbContext.Orders.Add(order);
            APIDbContext.SaveChanges();
        }
        
        public Order Delete(int id)
        {
            Order order = APIDbContext.Orders.Find(id);
            if (order != null)
            {
                APIDbContext.Orders.Remove(order);
                APIDbContext.SaveChanges();
            }
            return order;
        }

        public Order Get(int id)
        {
            Order order = APIDbContext.Orders.Find(id);
            
            return order;
        }

        public List<Order> GetAll()
        {
            return APIDbContext.Orders.ToList();
        }

        public List<Order> GetAll(int customerId)
        {
            return GetAll().Where(b=>b.Customer.CustomerID == customerId).ToList();
        }
        public void Update(Order order)
        {
            APIDbContext.Orders.Update(order);
            APIDbContext.SaveChanges();
        }
    }
}
