using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DatabaseLayer
{
    public class Invoice
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [Required]
        [DisplayName("Invoice Date")]
        public DateTime Date { get; set; }

        [Required]
        [DisplayName("Invoice No")]
        public int InvoiceNo { get; set; }

        [Required]
        [ForeignKey("Store")]
        public int StoreId { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public decimal Net { get; set; }

        [Required]
        public decimal Tax { get; set; }

        public Store Store { get; set; }
    }
}
