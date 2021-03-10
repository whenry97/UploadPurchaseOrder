// Database Model for Purchase Order Class
using Microsoft.EntityFrameworkCore;

namespace UploadPurchaseOrder.Data
{
    public class PurchaseOrderContext : DbContext
    {
        public PurchaseOrderContext (
            DbContextOptions<PurchaseOrderContext> options)
            : base(options)
        {
        }

        public DbSet<UploadPurchaseOrder.Models.PurchaseOrder> PurchaseOrder { get; set; }
    }
}