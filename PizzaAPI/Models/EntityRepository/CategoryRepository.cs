using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Entities;
using PizzaAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace PizzaAPI.Models.EntityRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public CategoryRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }
        public async Task<Category> Add(Category category)
        {
            try
            {
                APIDbContext.Category.Add(category);
                await APIDbContext.SaveChangesAsync();
                var result = await APIDbContext.Category.FindAsync(APIDbContext.Category.Count());
                return result;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Category> Delete(int id)
        {
            try
            {
                Category category = await APIDbContext.Category.FindAsync(id);
                if (category != null)
                {
                    APIDbContext.Category.Remove(category);
                    await APIDbContext.SaveChangesAsync();
                }
                return category;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Category> Get(int id)
        {
            try
            {
                Category category = await APIDbContext.Category.FindAsync(id);
                return category;
            }
            catch
            {
                return null;
            }
        }
        public async Task<IEnumerable<Category>> GetAll()
        {
            try
            {
                var category = await APIDbContext.Category.ToListAsync<Category>();
                return category;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Category> Update(Category dto)
        {
            try
            {
                Category category = await APIDbContext.Category.FindAsync(dto.CategoryID);
                category = dto;
                APIDbContext.Category.Update(category).State = EntityState.Modified;
                await APIDbContext.SaveChangesAsync();
                return category;
            }
            catch
            {
                return null;
            }
        }
    }
}
