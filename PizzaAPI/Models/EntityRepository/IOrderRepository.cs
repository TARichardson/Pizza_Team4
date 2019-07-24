using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public interface IOrderRepository
    {
        APIDbContext APIDbContext { set; get; }
        
 //       void Add(Order order);
 //       Order Delete(int id);
 //       void Update(Order order);
        Task<Order> GetOrder(int id);
        //       List<Order> GetAll();
        Task<List<Order>> GetHistory(int customerId);
        Task<List<Item>> Transationsumbit(int Id);
    }
}
