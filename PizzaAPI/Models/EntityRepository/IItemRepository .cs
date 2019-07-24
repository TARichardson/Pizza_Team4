using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public interface IItemRepository
    {
        APIDbContext APIDbContext { set; get; }
        
        Task<Item> Add(Item item,int OrderId);
        Task<Item> Delete(int id);
        Task<Item> Update(Item item);
     //   Item Get(int id);
        List<Item> GetAll();
        Task<List<Item>> GetAll(int orderId);
    }
}
