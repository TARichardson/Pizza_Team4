using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public class CustomerRepository : ICustomerRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public CustomerRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public void Add(Customer customer)
        {
            APIDbContext.Customers.Add(customer);
            APIDbContext.SaveChanges();
        }
        
        public Customer Delete(int id)
        {
            Customer customer = APIDbContext.Customers.Find(id);
            if (customer != null)
            {
                APIDbContext.Customers.Remove(customer);
                APIDbContext.SaveChanges();
            }
            return customer;
        }

        public Customer Get(int id)
        {
            Customer customer = APIDbContext.Customers.Find(id);
            
            return customer;
        }

        public Customer Get(string email, string password)
        {
            
           Customer customer = APIDbContext.Customers.
                    Where(b => (b.Email == email) && (b.Password==password))
                    .FirstOrDefault();

            return customer;
        }

        public List<Customer> GetAll()
        {
            return APIDbContext.Customers.ToList();
        }

        public void Update(Customer customer)
        {
            APIDbContext.Customers.Update(customer);
            APIDbContext.SaveChanges();
        }
    }
}
