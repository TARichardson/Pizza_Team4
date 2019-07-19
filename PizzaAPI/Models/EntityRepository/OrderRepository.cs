using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace Models.EntityRepository
{
    public class OrderRepository : IOrderRepository
    {
        public ApplicationDbContext ApplicationDbContext { set; get; }

        public OrderRepository(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }

        public void Add(Order order)
        {
            ApplicationDbContext.Orders.Add(order);
            ApplicationDbContext.SaveChanges();
        }
        
        public Order Delete(int id)
        {
            Order order = ApplicationDbContext.Orders.Find(id);
            if (order != null)
            {
                ApplicationDbContext.Orders.Remove(order);
                ApplicationDbContext.SaveChanges();
            }
            return order;
        }

        public Order Get(int id)
        {
            Order order = ApplicationDbContext.Orders.Find(id);
            
            return order;
        }

        public List<Order> GetAll()
        {
            return ApplicationDbContext.Orders.ToList();
        }

        public List<Order> GetAll(int customerId)
        {
            return GetAll().Where(b=>b.CustomerId==customerId).ToList();
        }
        public void Update(Order order)
        {
            ApplicationDbContext.Orders.Update(order);
            ApplicationDbContext.SaveChanges();
        }
    }
}
