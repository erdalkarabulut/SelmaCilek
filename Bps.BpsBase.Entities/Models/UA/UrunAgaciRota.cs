using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.UA
{
    public class UrunAgaciRota
    {
        [DisplayName("Id")]
        public int Id { get; set; }

        [DisplayName("Şirket Id")]
        public int SIRKID { get; set; }

        [DisplayName("Üretim Yeri")]
        public string URYRKD { get; set; }

        [DisplayName("Kullanım Kodu")]
        public string KLNKOD { get; set; }

        [DisplayName("Ürün Ağacı Kodu")]
        public string URAKOD { get; set; }

        [DisplayName("Revizyon")]
        public string GNREZV { get; set; }

        [DisplayName("Revizyon Tanım")]
        public string RVZTNM { get; set; }

        [DisplayName("Stok Kodu")]
        public string STKODU { get; set; }

        [DisplayName("Stok Adı")]
        public string STKNAM { get; set; }

        [DisplayName("Seviye")]
        public int SEVIYE { get; set; }

        [DisplayName("Kalem Tipi")]
        public string URKLTP { get; set; }

        [DisplayName("Alt Ürün Ağacı Kodu")]
        public string AURKOD { get; set; }

        [DisplayName("Stok Kalemi")]
        public bool STKKLM { get; set; }

        [DisplayName("Metin Kalemi")]
        public bool MTNKLM { get; set; }

        [DisplayName("Fantom Kalemi")]
        public bool FTNKLM { get; set; }

        [DisplayName("Malzeme Türü")]
        public string STMLTR { get; set; }

        [DisplayName("Parça Kodu")]
        public string PRKODU { get; set; }

        [DisplayName("Parça Adı")]
        public string PRCNAM { get; set; }

        [DisplayName("Miktar")]
        public decimal GNMKTR { get; set; }

        [DisplayName("Ölçü Birimi")]
        public string OLCUKD { get; set; }

        [DisplayName("İşlem Sıra No")]
        public int SIRANO { get; set; }

        [DisplayName("İşyeri Operasyon Kodu")]
        public string ISOPKD { get; set; }

        [DisplayName("İşyeri Operasyon Tanımı")]
        public string TANIMI { get; set; }
    }
}