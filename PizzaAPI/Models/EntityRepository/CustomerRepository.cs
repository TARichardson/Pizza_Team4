using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace Models.EntityRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        public ApplicationDbContext ApplicationDbContext { set; get; }

        public CustomerRepository(ApplicationDbContext ApplicationDbContext)
        {
            this.ApplicationDbContext = ApplicationDbContext;
        }

        public void Add(Customer customer)
        {
            ApplicationDbContext.Customers.Add(customer);
            ApplicationDbContext.SaveChanges();
        }
        
        public Customer Delete(int id)
        {
            Customer customer = ApplicationDbContext.Customers.Find(id);
            if (customer != null)
            {
                ApplicationDbContext.Customers.Remove(customer);
                ApplicationDbContext.SaveChanges();
            }
            return customer;
        }

        public Customer Get(int id)
        {
            Customer customer = ApplicationDbContext.Customers.Find(id);
            
            return customer;
        }

        public Customer Get(string email, string password)
        {
            
           Customer customer = ApplicationDbContext.Customers.
                    Where(b => (b.Email == email) && (b.Password==password))
                    .FirstOrDefault();

            return customer;
        }

        public List<Customer> GetAll()
        {
            return ApplicationDbContext.Customers.ToList();
        }

        public void Update(Customer customer)
        {
            ApplicationDbContext.Customers.Update(customer);
            ApplicationDbContext.SaveChanges();
        }
    }
}
