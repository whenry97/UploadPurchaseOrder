using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using UploadPurchaseOrder.Data;
using UploadPurchaseOrder.Models;

namespace UploadPurchaseOrder.Pages.PurchaseOrders
{
    public class CreateModel : PageModel
    {
        private readonly UploadPurchaseOrder.Data.PurchaseOrderContext _context;

        public CreateModel(UploadPurchaseOrder.Data.PurchaseOrderContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public PurchaseOrder PurchaseOrder { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.PurchaseOrder.Add(PurchaseOrder);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
