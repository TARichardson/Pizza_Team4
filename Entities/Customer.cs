using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
//using System.Web.Mvc;

namespace Entities
{
    public class Customer : ICustomer
    {
        [Key]
        public int CustomerID { get; set; }
        #region FirstName
        [DisplayName("First Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
        public string FirstName { get; set; }
        #endregion
        #region LastName
        [DisplayName("Last Name")]
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Last name cannot be longer than 50 characters.")]
        public string LastName { get; set; }
        #endregion
        #region Email Address
        [Required(ErrorMessage = "Please enter a Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        #endregion
        #region Phone Number
        [MaxLength(10), MinLength(10)]
        [DataType(DataType.PhoneNumber)]
        public string Phone { get; set; }
        #endregion
        #region Address
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Address cannot be longer than 50 characters.")]
        public string Address { get; set; }
        #endregion
        #region City
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "City cannot be longer than 50 characters.")]
        public string City { get; set; }
        #endregion
        #region State
        [MaxLength(2), MinLength(2)]
        public string State { get; set; }
        #endregion
        #region Zip Code
        [DisplayName("Zip Code")]
        [MaxLength(5), MinLength(5)]
        [DataType(DataType.PostalCode)]
        public string ZipCode { get; set; }
        #endregion
        #region Password
        [Required(ErrorMessage = "Please Password"), MaxLength(20), MinLength(8)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        #endregion

        public Customer() { }

        public Customer(CustomerDTO dto)
        {
            FirstName = dto.FirstName;
            LastName = dto.LastName;
            Email = dto.Email;
            Phone = dto.Phone;
            Address = dto.Address;
            City = dto.City;
            State = dto.State;
            ZipCode = dto.ZipCode;
            Password = dto.Password;
        }
        public static Customer operator +(Customer cL, Customer cR)
        {
            //Customer c = new Customer();
            cL.FirstName = (cR.FirstName == null || cR.FirstName == cL.FirstName) ? cL.FirstName : cR.FirstName;
            cL.LastName = (cR.LastName == null || cR.LastName == cL.LastName) ? cL.LastName : cR.LastName;
            cL.Email = (cR.Email == null || cR.Email == cL.Email) ? cL.Email : cR.Email;
            cL.Phone = (cR.Phone == null || cR.Phone == cL.Phone) ? cL.Phone : cR.Phone;
            cL.Address = (cR.Address == null || cR.Address == cL.Address) ? cL.Address : cR.Address;
            cL.City = (cR.City == null || cR.City == cL.City) ? cL.City : cR.City;
            cL.State = (cR.State == null || cR.State == cL.State) ? cL.State : cR.State;
            cL.ZipCode = (cR.ZipCode == null || cR.ZipCode == cL.ZipCode) ? cL.ZipCode : cR.ZipCode;
            cL.Password = (cR.Password == null || cR.Password == cL.Password) ? cL.Password : cR.Password;
            return cL;
        }
        public static Customer operator +(Customer cL, CustomerDTO cR)
        {
            cL.CustomerID = cL.CustomerID;
            cL.FirstName = (cR.FirstName == null || cR.FirstName == cL.FirstName) ? cL.FirstName : cR.FirstName;
            cL.LastName = (cR.LastName == null || cR.LastName == cL.LastName) ? cL.LastName : cR.LastName;
            cL.Email = (cR.Email == null || cR.Email == cL.Email) ? cL.Email : cR.Email;
            cL.Phone = (cR.Phone == null || cR.Phone == cL.Phone) ? cL.Phone : cR.Phone;
            cL.Address = (cR.Address == null || cR.Address == cL.Address) ? cL.Address : cR.Address;
            cL.City = (cR.City == null || cR.City == cL.City) ? cL.City : cR.City;
            cL.State = (cR.State == null || cR.State == cL.State) ? cL.State : cR.State;
            cL.ZipCode = (cR.ZipCode == null || cR.ZipCode == cL.ZipCode) ? cL.ZipCode : cR.ZipCode;
            cL.Password = (cR.Password == null || cR.Password == cL.Password) ? cL.Password : cR.Password;
            return cL;
        }
    }
}

