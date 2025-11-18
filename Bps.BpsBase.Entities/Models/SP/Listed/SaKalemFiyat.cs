using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SaKalemFiyat
    {
        [CsDisplayName("Şirket Id")]
        public int SIRKID { get; set; }

        [CsDisplayName("Belge Tarihi")]
        public DateTime BELTRH { get; set; }

        [CsDisplayName("Stok Kodu")]
        public string STKODU { get; set; }

        [CsDisplayName("Stok Adı")]
        public string STKNAM { get; set; }

        [CsDisplayName("Parti No")]
        public string PARTIN { get; set; }

        [CsDisplayName("Döviz Cinsi")]
        public string DVCNKD { get; set; }

        [CsDisplayName("Miktar")]
        public decimal? GNMKTR { get; set; }

        [CsDisplayName("Ölçü Birimi")]
        public string OLCUKD { get; set; }

        [CsDisplayName("Giriş Miktarı")]
        public decimal? GRMKTR { get; set; }

        [CsDisplayName("Giriş Ölçü Birimi")]
        public string GROLBR { get; set; }

        [CsDisplayName("Fiyat")]
        public decimal? GFIYAT { get; set; }

        [CsDisplayName("Tutar")]
        public decimal? GNTUTR { get; set; }

        [CsDisplayName("Satınalma Ölçü Birimi")]
        public string SAOLKD { get; set; }

        [CsDisplayName("Parti Birim Fiyat")]
        public decimal? PRBRFY { get; set; }
    }
}
