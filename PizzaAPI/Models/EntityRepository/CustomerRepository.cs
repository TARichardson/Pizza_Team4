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
            try
            {
                APIDbContext.Customers.Add(customer);
                await APIDbContext.SaveChangesAsync();
                var result = await APIDbContext.Customers.FindAsync(APIDbContext.Customers.Count());
                return result;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Customer> Add(CustomerDTO dto)
        {
            try
            {

                Customer customer = new Customer(dto);
                APIDbContext.Customers.Add(customer);
                await APIDbContext.SaveChangesAsync();
                var result = await this.Get(dto);
                return result;
            }
            catch
            {
                return null;
            }
        }
        public async Task<Customer> Delete(int id)
        {
            try
            {
                Customer customer = await APIDbContext.Customers.FindAsync(id);
                if (customer != null)
                {
                    APIDbContext.Customers.Remove(customer);
                    await APIDbContext.SaveChangesAsync();
                }
                return customer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Customer> Get(int id)
        {
            try
            {
                Customer customer = await APIDbContext.Customers.FindAsync(id);
                return customer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<Customer> Get(CustomerDTO dto)
        {
            try
            {

                Customer customer = await APIDbContext.Customers
                .Where(b => (b.Email == dto.Email) && (b.Password == dto.Password))
                .FirstOrDefaultAsync();

                return customer;
            }
            catch
            {
                return null;
            }
        }

        public async Task<IEnumerable<Customer>> GetAll()
        {
            try
            {
                var customers = await APIDbContext.Customers.ToListAsync<Customer>();
                return customers;
            }
            catch
            {
                return null;
            }
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
