using Bps.Core.AttributeHelpers;
using System;
using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.UA
{
    public class UrunAgaciRevizyonlar 
    {
        [DisplayName("Stok Kodu")]
        public string StokKodu { get; set; }
        [DisplayName("Revizyon No")]
        public string RevizyonNo { get; set; }
        [DisplayName("Revizyon Tanım")]
        public string RevizyonText { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        public DateTime BaslangicTarih { get; set; }
        public bool Etkin { get; set; }
        [DisplayName("Üretim Onay")]
        public bool UretimOnay { get; set; }
        [DisplayName("Üretim Yeri")]
        public string UretimYeriKodu { get; set; }
        [DisplayName("Ürün Ağacı Kodu")]
        public string UrunAgaciKodu { get; set; }
        [DisplayName("Ürün Ağacı Tipi")]
        public string UAKullanimText { get; set; }
        [DisplayName("Varyant Kodu")]
        public string VRKODU { get; set; }
        [DisplayName("Renk")]
        public string RENKKD { get; set; }
        [DisplayName("Beden")]
        public string BEDNKD { get; set; }
        [DisplayName("Drop")]
        public string DROPKD { get; set; }



    }
}