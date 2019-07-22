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
        public APIDbContext APIDbContext { set; get; }

        public ItemRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public void Add(Item item)
        {
            APIDbContext.Items.Add(item);
            APIDbContext.SaveChanges();
        }
        
        public Item Delete(int id)
        {
            Item item = APIDbContext.Items.Find(id);
            if (item != null)
            {
                APIDbContext.Items.Remove(item);
                APIDbContext.SaveChanges();
            }
            return item;
        }

        public Item Get(int id)
        {
            Item item = APIDbContext.Items.Find(id);
            
            return item;
        }

        public List<Item> GetAll()
        {
            return APIDbContext.Items.ToList();
        }

        public List<Item> GetAll(int orderId)
        {
            return GetAll().Where(b=>b.OrderId==orderId).ToList();
        }
        public void Update(Item item)
        {
            APIDbContext.Items.Update(item);
            APIDbContext.SaveChanges();
        }
    }
}
