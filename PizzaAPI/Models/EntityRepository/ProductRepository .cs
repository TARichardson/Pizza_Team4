using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public class ProductRepository : IProductRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public ProductRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public void Add(Product product)
        {
            APIDbContext.Products.Add(product);
            APIDbContext.SaveChanges();
        }
        
        public Product Delete(int id)
        {
            Product product = APIDbContext.Products.Find(id);
            if (product != null)
            {
                APIDbContext.Products.Remove(product);
                APIDbContext.SaveChanges();
            }
            return product;
        }

        public Product Get(int id)
        { 
            Product product = APIDbContext.Products.Find(id);
            
            return product;
        }

        public List<Product> GetAll()
        {
            return APIDbContext.Products.ToList();
        }

        public List<Product> GetAll(int categoryId)
        {
            return GetAll().Where(b=>b.CategoryId==categoryId).ToList();
        }
        public void Update(Product product)
        {
            APIDbContext.Products.Update(product);
            APIDbContext.SaveChanges();
        }
    }
}
