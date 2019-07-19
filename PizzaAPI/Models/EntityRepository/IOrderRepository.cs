using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace Models.EntityRepository
{
    public interface IOrderRepository
    {
        ApplicationDbContext ApplicationDbContext { set; get; }
        
        void Add(Order order);
        Order Delete(int id);
        void Update(Order order);
        Order Get(int id);
        List<Order> GetAll();
        List<Order> GetAll(int customerId);
    }
}
