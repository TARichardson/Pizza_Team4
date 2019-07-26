using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Entities
{
    public class CardType
    {
        [Key]
        public int CardTypeId { set; get; }
        public string Type { set; get; }
    }
}
