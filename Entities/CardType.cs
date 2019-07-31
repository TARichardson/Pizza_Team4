using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class CardType
    {
        [Key]
        public int CardTypeId { set; get; }
        [DataType(DataType.Text)]
        [DisplayName("Card Type")]
        public string Type { set; get; }
        public ICollection<Payment> Payments { get; set; }

    }
}
