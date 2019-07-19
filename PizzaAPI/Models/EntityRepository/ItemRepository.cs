using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace Models.EntityRepository
{
    public class ItemRepository : IItemRepository
    {
        public ApplicationDbContext ApplicationDbContext { set; get; }

        public ItemRepository(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }

        public void Add(Item item)
        {
            ApplicationDbContext.Items.Add(item);
            ApplicationDbContext.SaveChanges();
        }
        
        public Item Delete(int id)
        {
            Item item = ApplicationDbContext.Items.Find(id);
            if (item != null)
            {
                ApplicationDbContext.Items.Remove(item);
                ApplicationDbContext.SaveChanges();
            }
            return item;
        }

        public Item Get(int id)
        {
            Item item = ApplicationDbContext.Items.Find(id);
            
            return item;
        }

        public List<Item> GetAll()
        {
            return ApplicationDbContext.Items.ToList();
        }

        public List<Item> GetAll(int orderId)
        {
            return GetAll().Where(b=>b.OrderId==orderId).ToList();
        }
        public void Update(Item item)
        {
            ApplicationDbContext.Items.Update(item);
            ApplicationDbContext.SaveChanges();
        }
    }
}
