using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UploadPurchaseOrder.Data;
using UploadPurchaseOrder.Models;

namespace UploadPurchaseOrder.Pages.PurchaseOrders
{
    public class EditModel : PageModel
    {
        private readonly UploadPurchaseOrder.Data.PurchaseOrderContext _context;

        public EditModel(UploadPurchaseOrder.Data.PurchaseOrderContext context)
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

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(PurchaseOrder).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PurchaseOrderExists(PurchaseOrder.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PurchaseOrderExists(int id)
        {
            return _context.PurchaseOrder.Any(e => e.ID == id);
        }
    }
}
