using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public interface ICategoryRepository
    {
        APIDbContext APIDbContext { set; get; }

        Task<Category> Add(Category type);
        Task<Category> Delete(int id);
        Task<Category> Update(Category type);
        Task<Category> Get(int id);
        Task<IEnumerable<Category>> GetAll();
    }
}
