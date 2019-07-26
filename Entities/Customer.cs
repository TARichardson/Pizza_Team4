using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required]
        [DisplayName("First Name")]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }

        [Required]
        [DisplayName("Last Name")]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [MaxLength(11), MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        [Required(ErrorMessage = "Please Password"), MaxLength(20), MinLength(6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Registration Date")]
        public DateTime DateCreated { set; get; }
        public virtual List<Order> OrdersList { set; get; }
        public virtual List<Payment> PaymentList { set; get; }
    }
}
