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
    public class ItemRepository : IItemRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public ItemRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public void Add(Item item,int OrderID)
        {
            var order = APIDbContext.Orders.Where(o => o.OrderID == OrderID).FirstOrDefault();
            Item i = new Item();
            i.Order = order;
            i.qty = item.qty;
            i.Amount = item.Amount;
            order.TotalAmount += (decimal)item.Amount;
            APIDbContext.Orders.Update(order);
            APIDbContext.Items.Add(i);
            APIDbContext.SaveChangesAsync();
        }
        
        public Item Delete(int id)
        {
            var item = APIDbContext.Items.Include("Order").Where(i => i.ItemID == id).First();
            if (item == null)
            {
                return null;
            }
            var order = APIDbContext.Orders.Where(o => o.OrderID == item.Order.OrderID).FirstOrDefault();
            order.TotalAmount = order.TotalAmount - item.Amount;
            APIDbContext.Items.Remove(item);
            APIDbContext.Update(order);
            APIDbContext.SaveChanges();
            return item;
         
        }

        //public Item Get(int id)
        //{
        //    Item item = APIDbContext.Items.Find(id);
            
        //    return item;
        //}

        public List<Item> GetAll()
        {
            return APIDbContext.Items.ToList();
        }

        public List<Item> GetAll(int orderId)
        {
            return APIDbContext.Items.Include("Order").Where(i => i.Order.OrderID == orderId).ToList();
        }
        public void Update(Item item)
        {
            APIDbContext.Items.Update(item);
            APIDbContext.SaveChanges();
        }
    }
}
