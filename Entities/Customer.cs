using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Entities
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }
        #region FirstName
        [DisplayName("First Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string? FirstName { get; set; }
        #endregion
        #region LastName
        [DisplayName("Last Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string? LastName { get; set; }
        #endregion
        #region Email Address
        [Required(ErrorMessage = "Please enter a Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        #endregion
        #region Phone Number
        [MaxLength(10), MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string? Phone { get; set; }
        #endregion
        #region Address
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string? Address { get; set; }
        #endregion
        #region State
        [MaxLength(2), MinLength(2)]
        public string? State { get; set; }
        #endregion
        #region Zip Code
        [DisplayName("Zip Code")]
        [MaxLength(5), MinLength(5)]
        [DataType(DataType.PostalCode)]
        public decimal? ZipCode { get; set; }
        #endregion
        #region Password
        [Required(ErrorMessage = "Please Password"), MaxLength(20), MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        #endregion
    }
}

