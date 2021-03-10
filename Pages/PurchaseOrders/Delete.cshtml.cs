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
    public class DeleteModel : PageModel
    {
        private readonly UploadPurchaseOrder.Data.PurchaseOrderContext _context;

        public DeleteModel(UploadPurchaseOrder.Data.PurchaseOrderContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            PurchaseOrder = await _context.PurchaseOrder.FindAsync(id);

            if (PurchaseOrder != null)
            {
                _context.PurchaseOrder.Remove(PurchaseOrder);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
