using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using UploadPurchaseOrder.Data;
using UploadPurchaseOrder.Models;

namespace UploadPurchaseOrder.Pages.PurchaseOrders
{
    public class IndexModel : PageModel
    {
        private readonly UploadPurchaseOrder.Data.PurchaseOrderContext _context;
        private IWebHostEnvironment _iWebHostEnvironment;

        public IndexModel(UploadPurchaseOrder.Data.PurchaseOrderContext context, IWebHostEnvironment iWebHostEnvironment)
        {
            _context = context;
            _iWebHostEnvironment = iWebHostEnvironment;
        }

        public IList<PurchaseOrder> PurchaseOrder { get;set; }
        public string FilePath { get; set; }
        public async Task OnGetAsync()
        {
            PurchaseOrder = await _context.PurchaseOrder.ToListAsync();
            FilePath = Path.Combine(_iWebHostEnvironment.WebRootPath, "UploadedFiles");
        }
    }
}
