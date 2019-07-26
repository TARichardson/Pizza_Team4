using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { set; get; }
        public string Name { set; get; }
    }
}
