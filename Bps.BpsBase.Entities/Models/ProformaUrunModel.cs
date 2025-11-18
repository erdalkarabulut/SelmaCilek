using System;
using System.Drawing;

namespace Bps.BpsBase.Entities.Models
{
    [Serializable]
    public class ProformaUrunModel
    {
        public bool CustomProduct { get; set; }

        public string ImageUrl { get; set; }

        public Image StokImage { get; set; }

        public string ProductCode { get; set; }

        public string ProductDetails { get; set; }

        public string ProductName { get; set; }

        public int Quantity { get; set; }

        public string Remark { get; set; }

        public int RowNo { get; set; }

        public double TotalCbm { get; set; }

        public int TotalPackaging { get; set; }

        public double TotalPrice { get; set; }

        public double TotalWeight { get; set; }

        public double UnitCbm { get; set; }

        public int UnitPackaging { get; set; }

        public double UnitPrice { get; set; }

        public double UnitWeight { get; set; }

    }
}
