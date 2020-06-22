using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseLayer
{
    public class InvoiceDetails
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Item")]
        public int ItemId { get; set; }

        [Required]
        [ForeignKey("Unit")]
        public int UnitId { get; set; }

        [Required]
        [ForeignKey("Invoice")]
        public int InvoiceId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public double Quantity { get; set; }

        [Required]
        public decimal Total { get; set; }

        // default value is zero
        public decimal Discount { get; set; } = 0.00M;

        [Required]
        public decimal Net { get; set; }
    }
}
