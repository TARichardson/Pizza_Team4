using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Entities
{
    public class Product
    {
        [Key]
        public int ProductId { set; get; }
        public virtual int CategoryID { set; get; }
        [ForeignKey("CategoryID")]
        public Category Category { set; get; }
        [Required]
        [DataType(DataType.Currency)]
        public decimal Price { set; get; }
        [Required]
        public string Name { set; get; }
        [DataType(DataType.Text)]
        public string Description { set; get; }
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "Calories cannot be longer than 50 characters.")]
        public string Calories { set; get; }
        [DataType(DataType.Text)]
        [StringLength(50, ErrorMessage = "URL cannot be longer than 50 characters.")]
        public string SRC { set; get; }
    }
}
