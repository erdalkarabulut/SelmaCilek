using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.UA
{
    public class UrunAgaciModulPaketParca
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Şirket Id")]
        public int? SIRKID { get; set; }
        [DisplayName("Üretim Yeri")]
        public string URYRKD { get; set; }
        [DisplayName("Revizyon")]
        public string GNREZV { get; set; }
        [DisplayName("Ürün Ağacı Kodu")]
        public string URAKOD { get; set; }
        [DisplayName("Modül Kodu")]
        public string MDKODU { get; set; }
        [DisplayName("Modül Adı")]
        public string MDNAME { get; set; }
        [DisplayName("Modül Adı Yabancı")]
        public string MDYBNM { get; set; }
        [DisplayName("Paket Kodu")]
        public string PKKODU { get; set; }
        [DisplayName("Paket Adı")]
        public string PKNAME { get; set; }
        [DisplayName("Paket Adı Yabancı")]
        public string PKYBNM { get; set; }
        [DisplayName("Parça Kodu")]
        public string PRKODU { get; set; }
        [DisplayName("Parça Adı")]
        public string PRNAME { get; set; }
        [DisplayName("Parça Adı Yabancı")]
        public string PRYBNM { get; set; }
        [DisplayName("Miktar")]
        public decimal? GNMKTR { get; set; }
        [DisplayName("Uzunluk")]
        public decimal? UZUNLK { get; set; }
        [DisplayName("Genişlik")]
        public decimal? GENSLK { get; set; }
        [DisplayName("Yükseklik")]
        public decimal? YUKSLK { get; set; }
        [DisplayName("UGY Ölçü Birimi")]
        public string UGYBKD { get; set; }
        [DisplayName("Brüt Ağırlık")]
        public decimal? NETAGR { get; set; }
        [DisplayName("Net Ağırlık")]
        public decimal? BRTAGR { get; set; }
        [DisplayName("Ağırlık Ölçü Birimi")]
        public string AGOLKD { get; set; }
    }
}