using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Entities
{
    public class Product
    {
        [Key]
        public int ProductID { set; get; }
        [DisplayName("Name")]
        [DataType(DataType.Text)]
        public string Productname { set; get; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Price { set; get; }
        [ForeignKey("CategoryID")]
        public Category Category { set; get; }
    }
}
