using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Item
    {
        [ForeignKey("OrderID")]
        public Order Order { set; get; }
        
        [Key]
        public int ItemID { set; get; }
        [ForeignKey("ProductId")]
        public Product Product { set; get; }
        [ForeignKey("CustomerId")]

        [DisplayName("Quantity")]
        public int qty { set; get; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? Amount { set; get; }
        
    }
}
