using System;
using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.UA
{
    public class UrunAgaciUst
    {
        [DisplayName("Id")]
        public int Id { get; set; }
        [DisplayName("Şirket Id")]
        public int? SIRKID { get; set; }
        [DisplayName("Stok Kodu")]
        public string STKODU { get; set; }
        [DisplayName("Üst Stok Kodu")]
        public string USKODU { get; set; }
        [DisplayName("Üst Stok Adı")]
        public string USNAME { get; set; }
        [DisplayName("Üst Stok Adı Yabancı")]
        public string USYBNM { get; set; }
        [DisplayName("Dil Kodu")]
        public string LANGKD { get; set; }
        [DisplayName("Üretim Yeri")]
        public string URYRKD { get; set; }
        [DisplayName("Kullanım Kodu")]
        public string KLNKOD { get; set; }
        [DisplayName("Ürün Ağacı Kodu")]
        public string URAKOD { get; set; }
        [DisplayName("Alternatif")]
        public int? ALTERN { get; set; }
        [DisplayName("Revizyon")]
        public string GNREZV { get; set; }
        [DisplayName("Revizyon Tanımı")]
        public string TANIMI { get; set; }
        [DisplayName("Başlangıç Tarihi")]
        public DateTime? BASTAR { get; set; }
        [DisplayName("Bitiş Tarihi")]
        public DateTime? BITTAR { get; set; }
        [DisplayName("Üretim Onay")]
        public bool? URTONY { get; set; }
    }
}