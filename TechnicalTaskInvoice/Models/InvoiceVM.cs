using BusinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechnicalTaskInvoice.Models
{
    public class InvoiceVM : InvoiceBL
    {
        public IEnumerable<InvoiceDetailsBL> InvoiceDetails { get; set; }

        public IEnumerable<StoreBL> Stores { get; set; }

        public IEnumerable<ItemDetailsBL> ItemsDetails { get; set; }
    }
}
