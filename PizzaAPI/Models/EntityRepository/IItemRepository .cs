using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace Models.EntityRepository
{
    public interface IItemRepository
    {
        ApplicationDbContext ApplicationDbContext { set; get; }
        
        void Add(Item item);
        Item Delete(int id);
        void Update(Item item);
        Item Get(int id);
        List<Item> GetAll();
        List<Item> GetAll(int orderId);
    }
}
