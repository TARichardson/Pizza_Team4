using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public interface IProductRepository
    {
        APIDbContext APIDbContext { set; get; }
        
        void Add(Product product);
        Product Delete(int id);
        void Update(Product product);
        Product Get(int id);
        List<Product> GetAll();
        List<Product> GetAll(int categoryId);
    }
}
