using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
namespace Entities
{
    public class Category
    {
        [Key]
        public int CategoryID { set; get; }
        [DataType(DataType.Text)]
        [DisplayName("Category")]
        public string Type { set; get; }
    }
}
