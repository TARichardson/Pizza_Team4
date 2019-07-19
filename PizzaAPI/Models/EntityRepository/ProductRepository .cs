using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace Models.EntityRepository
{
    public class ProductRepository : IProductRepository
    {
        public ApplicationDbContext ApplicationDbContext { set; get; }

        public ProductRepository(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }

        public void Add(Product product)
        {
            ApplicationDbContext.Products.Add(product);
            ApplicationDbContext.SaveChanges();
        }
        
        public Product Delete(int id)
        {
            Product product = ApplicationDbContext.Products.Find(id);
            if (product != null)
            {
                ApplicationDbContext.Products.Remove(product);
                ApplicationDbContext.SaveChanges();
            }
            return product;
        }

        public Product Get(int id)
        { 
            Product product = ApplicationDbContext.Products.Find(id);
            
            return product;
        }

        public List<Product> GetAll()
        {
            return ApplicationDbContext.Products.ToList();
        }

        public List<Product> GetAll(int categoryId)
        {
            return GetAll().Where(b=>b.CategoryId==categoryId).ToList();
        }
        public void Update(Product product)
        {
            ApplicationDbContext.Products.Update(product);
            ApplicationDbContext.SaveChanges();
        }
    }
}
