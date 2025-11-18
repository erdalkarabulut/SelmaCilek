using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.UA
{
    public class UrunAgaciModulPaket
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Şirket Id")]
        public int SIRKID { get; set; }
        [DisplayName("Kullanım Kodu")]
        public string KLNKOD { get; set; }
        [DisplayName("Kalem Tanım")]
        public string TANIMI { get; set; }
        [DisplayName("Üretim Yeri")]
        public string URYRKD { get; set; }
        [DisplayName("Ürün Ağacı Kodu")]
        public string URAKOD { get; set; }
        [DisplayName("Revizyon")]
        public string GNREZV { get; set; }
        [DisplayName("Modül Kodu")]
        public string MDKODU { get; set; }
        [DisplayName("Modül Adı")]
        public string MDLNAM { get; set; }
        [DisplayName("Modül Adı İngilizce")]
        public string MDNMEN { get; set; }
        [DisplayName("Child")]
        public int CHILDD { get; set; }
        [DisplayName("Paket Kodu")]
        public string PKKODU { get; set; }
        [DisplayName("Paket Adı")]
        public string PKTNAM { get; set; }
        [DisplayName("Paket Adı İngilizce")]
        public string PKNMEN { get; set; }
        [DisplayName("Miktar")]
        public decimal GNMKTR { get; set; }
        [DisplayName("Ölçü Birimi")]
        public string OLCUKD { get; set; }
        [DisplayName("Brüt Ağırlık")]
        public decimal BRTAGR { get; set; }
        [DisplayName("Ağırlık Ölçü Birimi")]
        public string AGOLKD { get; set; }
        [DisplayName("Uzunluk")]
        public decimal UZUNLK { get; set; }
        [DisplayName("Genişlik")]
        public decimal GENSLK { get; set; }
        [DisplayName("Yükseklik")]
        public decimal YUKSLK { get; set; }
        [DisplayName("UGY Ölçü Birimi")]
        public string UGYBKD { get; set; }
        [DisplayName("Kullanılabilir Stok")]
        public decimal USESTK { get; set; }
        [DisplayName("Stok Resim")]
        public string STKIMG { get; set; }
    }
}