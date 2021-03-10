using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using UploadPurchaseOrder.Data;
using UploadPurchaseOrder.Models;

namespace UploadPurchaseOrder.Pages.PurchaseOrders
{
    public class UploadPDFModel : PageModel
    {
        private readonly UploadPurchaseOrder.Data.PurchaseOrderContext _context;

        private IWebHostEnvironment _iWebHostEnvironment;

        public UploadPDFModel(UploadPurchaseOrder.Data.PurchaseOrderContext context, IWebHostEnvironment iWebHostEnvironment)
        {
            _context = context;
            _iWebHostEnvironment = iWebHostEnvironment;
        }

        [BindProperty]
        public PurchaseOrder PurchaseOrder { get; set; }

        [BindProperty]
        public IFormFile PDFOrder { get; set; }
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

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var path = Path.Combine(_iWebHostEnvironment.WebRootPath, "UploadedFiles", PDFOrder.FileName);
            using (var fileStream = new FileStream(path, FileMode.Create))
            {
                await PDFOrder.CopyToAsync(fileStream);
            }
            
            PurchaseOrder.purchaseOrderPDF = PDFOrder.FileName;
            
            _context.Entry(PurchaseOrder).Property(x => x.purchaseOrderPDF).IsModified = true;

            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}