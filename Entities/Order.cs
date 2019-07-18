using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Entities
{
    public class Order
    {
        [ForeignKey("CustomerID")]
        public Customer Customer { set; get; }
        [Key]
        public int OrderID { set; get; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal? TotalAmount { set; get; }
        [DataType(DataType.Text)]
        public string ItemList { set; get; }
        [DisplayName("Status")]
        public bool Pay { set; get; }

        
    }
}