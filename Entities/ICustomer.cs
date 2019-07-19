using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    interface ICustomer
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        string Email { get; set; }
        string Phone { get; set; }
        string Address { get; set; }
        string State { get; set; }
        string ZipCode { get; set; }
        string Password { get; set; }
    }
}
