using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Payment
    {
        [Key]
        public int PaymentID { set; get; }

        public virtual int CustomerID { set; get; }
        [ForeignKey("CustomerID")]
        public Customer Customer { get; set; }



        [DataType(DataType.CreditCard)]
        public string CardNumber { set; get; }

        public virtual int  CardTypeID { set; get; }
        [ForeignKey("CardTypeID")]
        public CardType CardType { get; set; }

        [MaxLength(50), MinLength(2)]
        public string Address { get; set; }

        [MaxLength(50), MinLength(2)]
        public string State { get; set; }

        [DisplayName("Zip Code")]
        [MaxLength(5), MinLength(5)]
        [DataType(DataType.PostalCode)]
        public int ZipCode { get; set; }

        public DateTime DateCreated { set; get; }
    }
}
