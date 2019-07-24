using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities;
using PizzaAPI.Models;

namespace PizzaAPI.Models.EntityRepository
{
    public interface ICustomerRepository
    {
        APIDbContext APIDbContext { set; get; }


        Task<Customer> Add(Customer customer);
        Task<Customer> Add(CustomerDTO customer);

        Task<Customer> Delete(int id);
        Task<Customer> Update(int id, CustomerDTO dto);
        Task<Customer> Get(int id);
        Task<Customer> Get(CustomerDTO dto);
        Task<IEnumerable<Customer>> GetAll();
    }
}
