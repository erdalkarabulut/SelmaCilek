using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.Firestore
{
    [Serializable]
    public class Order
    {
        public string DocId { get; set; }
        public bool Active { get; set; }
        public string BuyerAddress { get; set; }
        public string BuyerContact { get; set; }
        public string BuyerEmail { get; set; }
        public string BuyerName { get; set; }
        public string CreatedBy { get; set; }
        public string Currency { get; set; }
        public string DeliveryTerms { get; set; }
        public long DocumentDate { get; set; }
        public string EditedBy { get; set; }
        public string Language { get; set; }
        public string PaymentTerms { get; set; }
        public string PINo { get; set; }
        public List<Product> Products { get; set; }
        public decimal AdvancePayment { get; set; }
        public decimal Discount { get; set; }
        public string ShipmentTerms { get; set; }
        public string Status { get; set; }
    }
}
