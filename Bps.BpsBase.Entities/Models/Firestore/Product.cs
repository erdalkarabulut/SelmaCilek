using System;
using System.Drawing;


namespace Bps.BpsBase.Entities.Models.Firestore
{
    [Serializable]
    public class Product
    {
        public int Id { get; set; }
        
        public bool CustomProduct { get; set; }
        
        public string ImageUrl { get; set; }
        
        public Image StokImage { get; set; }
        
        public string ProductCode { get; set; }
        
        public string ProductDetails { get; set; }
       
        public string ProductName { get; set; }
        
        public string ProductNameEn { get; set; }
        
        public decimal Quantity { get; set; }
        
        public string Unit { get; set; }
        
        public string Remark { get; set; }
        
        public int RowNo { get; set; }
        
        public decimal TotalCbm { get; set; }
        
        public int TotalPackaging { get; set; }
        
        public decimal TotalPrice { get; set; }
        
        public decimal TotalWeight { get; set; }
        
        public decimal UnitCbm { get; set; }
        
        public int UnitPackaging { get; set; }
        
        public decimal UnitPrice { get; set; }
        
        public decimal UnitWeight { get; set; }

        public decimal TaxAmount { get; set; }
    }
}
