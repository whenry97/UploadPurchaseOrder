// Purchase Order Class Definition
using System;
using System.ComponentModel.DataAnnotations;

namespace UploadPurchaseOrder.Models
{
    public class PurchaseOrder
    {
        public int ID { get; set; }
        public string orderNumber { get; set; }
		public string buyerName { get; set; }
		public string buyerStreetAddress { get; set; }
		public string buyerCityStateZip { get; set; }
		public string buyerPhoneNumber { get; set; }

        public DateTime OrderDate { get; set; }
		public string vendorName { get; set; }
		public string vendorStreetAddress { get; set; }
		public string vendorCityStateZip { get; set; }
		public string vendorPhoneNumber { get; set; }
        [DataType(DataType.Currency)]
		public decimal subtotal { get; set; }
        [DataType(DataType.Currency)]
		public decimal tax { get; set; }
        [DataType(DataType.Currency)]
		public decimal shipping { get; set; }
        [DataType(DataType.Currency)]
		public decimal fullTotal { get; set; }

        public string purchaseOrderPDF { get; set; }
    }
}