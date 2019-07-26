using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Item
    {
        [ForeignKey("Order")]
        public virtual int OrderId { set; get; }  

        public virtual Order Order { set; get; }

        [Key]
        public int ItemId { set; get; }

        public int ProductId { set; get; }

        public int qty { set; get; }

        public double Amount { set; get; }

        public virtual List<Product> ProductList { set; get; }
    }
}
