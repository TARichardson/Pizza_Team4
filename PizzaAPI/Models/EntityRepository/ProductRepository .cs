using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace PizzaAPI.Models.EntityRepository
{
    public class ProductRepository : IProductRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public ProductRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<Product> Add(Product product)
        {
            try
            {
                APIDbContext.Products.Add(product);
                await APIDbContext.SaveChangesAsync();
                var result = await APIDbContext.Products.FindAsync(APIDbContext.Products.Count());
                return result;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Product> Delete(int id)
        {
            try
            {
                Product product = await APIDbContext.Products.FindAsync(id);
                if (product != null)
                {
                    APIDbContext.Products.Remove(product);
                    await APIDbContext.SaveChangesAsync();
                }
                return product;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Product> Get(int id)
        {
            try
            {
                Product product = await APIDbContext.Products.FindAsync(id);
                return product;
            }
            catch
            {
                return null;
            }
        }
        public async Task<IEnumerable<Product>> GetAll()
        {
            try
            {
                var product = await APIDbContext.Products.ToListAsync<Product>();
                return product;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Product> Update(Product dto)
        {
            try
            {
                Product product = await APIDbContext.Products.FindAsync(dto.ProductId);
                product = dto;
                APIDbContext.Products.Update(product).State = EntityState.Modified;
                await APIDbContext.SaveChangesAsync();
                return product;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Product>> GetAll(int categoryId)
        {
            try
            {
                var product = await APIDbContext.Products.Where(b => b.CategoryId == categoryId).ToListAsync<Product>();
                return product;
            }
            catch
            {
                return null;
            }
        }
    }
}
