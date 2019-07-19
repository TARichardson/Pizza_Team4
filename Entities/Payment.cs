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
        public int PaymentId { set; get; }

        [ForeignKey("CustomerId")]
        public virtual int CustomerId { set; get; }

        [DataType(DataType.CreditCard)]
        public string CardNumber { set; get; }

        [ForeignKey("CardTypeId")]
        public virtual int  CardTypeId { set; get; }

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
