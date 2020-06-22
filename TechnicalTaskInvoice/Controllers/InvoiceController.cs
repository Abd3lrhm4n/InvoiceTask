using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLayer;
using Microsoft.AspNetCore.Mvc;
using TechnicalTaskInvoice.Models;

namespace TechnicalTaskInvoice.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly ItemDetailsBL _itemDetails;
        private readonly StoreBL _store;
        private readonly InvoiceBL _invoice;
        private readonly InvoiceDetailsBL _invoiceDetails;

        public InvoiceController(ItemDetailsBL itemDetails, StoreBL store, InvoiceBL invoice, InvoiceDetailsBL invoiceDetails)
        {
            this._itemDetails = itemDetails;
            this._store = store;
            this._invoice = invoice;
            this._invoiceDetails = invoiceDetails;
        }

        public async Task<IActionResult> Create()
        {
            var model = new InvoiceVM();
            model.Stores = await _store.ReadAll();
            model.ItemsDetails = await _itemDetails.ReadAll();
            model.InvoiceNo = await _invoice.GetNextInvoiceNoAsync();
            
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(InvoiceVM obj)
        {
            var header = new InvoiceBL
            {
                InvoiceNo = obj.InvoiceNo,
                StoreId = obj.StoreId,
                Tax = obj.Tax
            };
            List<InvoiceDetailsBL> details = new List<InvoiceDetailsBL>();

            foreach (var item in obj.InvoiceDetails)
            {
                details.Add(new InvoiceDetailsBL
                {
                    Discount = item.Discount,
                    ItemId = item.ItemId,
                    Quantity = item.Quantity,
                    UnitId = item.UnitId
                });
            }

            bool result = await _invoiceDetails.CreateInvoice(header, details);

            return Json(result);
        }
    }
}