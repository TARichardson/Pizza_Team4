using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class CustomerDTO : ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string State { get; set; }
        public string ZipCode { get; set; }
        public string Password { get; set; }
    }
}
