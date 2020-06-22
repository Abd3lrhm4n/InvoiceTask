using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class InvoiceBL : Invoice
    {
        private readonly ApplicationDbContext _ctx;

        public InvoiceBL(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }
        public InvoiceBL()
        {
        }

        public async Task<int> GetNextInvoiceNoAsync()
        {
            var q = await this._ctx.Invoices.OrderByDescending(o => o.Date).FirstOrDefaultAsync();

            // if table empty
            // return 1
            if (q == null)
            {
                return 1;
            }

            return ++q.InvoiceNo;
        } 
    }
}
