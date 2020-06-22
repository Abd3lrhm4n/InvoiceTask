using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseLayer
{
    public class ItemDetials
    {
        [Key, Column(Order = 0)]
        [ForeignKey("Item")]
        [Required]
        public int ItemId { get; set; }

        [Key, Column(Order = 1)]
        [ForeignKey("Unit")]
        [Required]
        public int UnitId { get; set; }

        [Required]
        public decimal Price { get; set; }


        public Item Item { get; set; }

        public Unit Unit { get; set; }
    }
}
