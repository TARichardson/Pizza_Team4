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
        
        Task<Product> Add(Product product);
        Task<Product> Delete(int id);
        Task<Product> Update(Product product);
        Task<Product> Get(int id);
        Task<IEnumerable<Product>> GetAll();
        Task<IEnumerable<Product>> GetAll(int categoryId);
    }
}
