using DatabaseLayer;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer
{
    public class InvoiceDetailsBL : InvoiceDetails
    {
        private readonly ApplicationDbContext _ctx;


        public InvoiceDetailsBL(ApplicationDbContext ctx)
        {
            this._ctx = ctx;
        }
        public InvoiceDetailsBL()
        {

        }

        public async Task<bool> CreateInvoice(InvoiceBL header, ICollection<InvoiceDetailsBL> details)
        {
            bool result = false;
            using (var trans = _ctx.Database.BeginTransactionAsync())
            {
                try
                {
                    // calculate the total 
                    // to be sure the user didn't change it in html
                    var dalHeader = new Invoice
                    {
                        // insert Totals with zero to update them later
                        InvoiceNo = header.InvoiceNo,
                        Total = 0,
                        Tax = header.Tax,
                        Net = 0,
                        StoreId = header.StoreId,
                        Date = DateTime.Now,
                    };

                    this._ctx.Invoices.Add(dalHeader);

                    result = await this._ctx.SaveChangesAsync() > 0;

                    // didn't insert the header
                    if (!result)
                    {
                        trans.Result.Rollback();
                        return result;
                    }

                    // get the price from database
                    // to be sure the user didn't change it in html
                    var prices = await this._ctx.ItemDetials.Where(x => details.Any(a => a.ItemId == x.ItemId && a.UnitId == x.UnitId )).ToListAsync();

                    foreach (var row in details)
                    {
                        var price = prices.FirstOrDefault(x => x.ItemId == row.ItemId && x.UnitId == row.UnitId).Price;
                        InvoiceDetails dalRow = new InvoiceDetails();

                        dalRow.ItemId = row.ItemId;
                        dalRow.Price = price;
                        dalRow.Quantity = row.Quantity;
                        dalRow.Total = price * Convert.ToDecimal(row.Quantity);
                        dalRow.Discount = row.Discount;
                        dalRow.Net = price * Convert.ToDecimal(row.Quantity) - row.Discount;
                        dalRow.UnitId = row.UnitId;
                        dalRow.InvoiceId = dalHeader.Id;

                        dalHeader.Total += dalRow.Net;
                        
                        this._ctx.InvoiceDetails.Add(dalRow);
                    }
                    
                    dalHeader.Net = dalHeader.Total + dalHeader.Total * dalHeader.Tax / 100;

                    this._ctx.Entry(dalHeader).State = EntityState.Modified;
                    result = await this._ctx.SaveChangesAsync() > 0;

                    // didn't insert the details
                    if (!result)
                    {
                        trans.Result.Rollback();
                        return result;
                    }

                    // successful commit transaction
                    trans.Result.Commit();
                    return result;
                }
                catch (Exception ex)
                {
                    trans.Result.Rollback();
                    return false;
                    throw;
                }
            }
        }
    }
}
