using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UploadPurchaseOrder.Data;
using UploadPurchaseOrder.Models;

namespace UploadPurchaseOrder.Pages.PurchaseOrders
{
    public class DetailsModel : PageModel
    {
        private readonly UploadPurchaseOrder.Data.PurchaseOrderContext _context;

        public DetailsModel(UploadPurchaseOrder.Data.PurchaseOrderContext context)
        {
            _context = context;
        }

        public PurchaseOrder PurchaseOrder { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PurchaseOrder = await _context.PurchaseOrder.FirstOrDefaultAsync(m => m.ID == id);

            if (PurchaseOrder == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
