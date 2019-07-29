using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Entities
{
    public class CustomerDTO : ICustomer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        [MaxLength(2), MinLength(2)]
        public string State { get; set; }
        [DisplayName("Zip Code")]
        [MaxLength(5), MinLength(5)]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        [MaxLength(20), MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
