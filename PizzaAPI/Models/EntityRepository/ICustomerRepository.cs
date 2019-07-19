using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace Models.EntityRepository
{
    public interface ICustomerRepository
    {
        ApplicationDbContext ApplicationDbContext { set; get; }
        
        
        void Add(Customer customer);
        Customer Delete(int id);
        void Update(Customer customer);
        Customer Get(int id);
        Customer Get(string email, string password);
        List<Customer> GetAll();
    }
}
