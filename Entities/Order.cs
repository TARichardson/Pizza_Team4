using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Order
    {
        [ForeignKey("Customer")]
        public virtual int CustomerId { set; get; }
        public virtual Customer Customer { set; get; }

        [Key]
        public int OrderId { set; get; }

        public int TotalAmount { set; get; }

        public bool Pay { set; get; }

        public DateTime DateCreated { set; get; }

        public virtual List<Item> ItemList { set; get; }
    }
}
