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
    public class CustomerRepository : ICustomerRepository
    {
        public APIDbContext APIDbContext { set; get; }

        public CustomerRepository(APIDbContext APIDbContext)
        {
            this.APIDbContext = APIDbContext;
        }

        public async Task<Customer> Add(Customer customer)
        {
            APIDbContext.Customers.Add(customer);
            await APIDbContext.SaveChangesAsync();
            var result = await APIDbContext.Customers.FindAsync(APIDbContext.Customers.Count());
            return result;
        }
        public async Task<Customer> Add(CustomerDTO dto)
        {   Customer customer = new Customer(dto);
            APIDbContext.Customers.Add(customer);
            await APIDbContext.SaveChangesAsync();
            var result = await APIDbContext.Customers.FindAsync(APIDbContext.Customers.Count());
            return result;
        }
        public async Task<Customer> Delete(int id)
        {
            Customer customer = await APIDbContext.Customers.FindAsync(id);
            if (customer != null)
            {
                APIDbContext.Customers.Remove(customer);
                await APIDbContext.SaveChangesAsync();
            }
            return  customer;
        }

        public async Task<Customer> Get(int id)
        {
            Customer customer = await APIDbContext.Customers.FindAsync(id);
            return customer;
        }

        public async Task<Customer> Get(CustomerDTO dto)
        {
            
           Customer customer = await APIDbContext.Customers
                .Where(b => (b.Email == dto.Email) && (b.Password==dto.Password))
                .FirstOrDefaultAsync();

            return customer;
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            return await APIDbContext.Customers.ToListAsync();
        }

        public async Task<Customer> Update(int id, CustomerDTO dto)
        {
            try
            {
                Customer customer = await APIDbContext.Customers.FindAsync(id);
                customer += dto;
                APIDbContext.Customers.Update(customer).State = EntityState.Modified;
                await APIDbContext.SaveChangesAsync();
                return customer;
            }
            catch
            {
                return null;
            }
        }
    }
}
