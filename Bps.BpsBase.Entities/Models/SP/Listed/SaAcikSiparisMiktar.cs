using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.SP.Listed
{
    public class SaAcikSiparisMiktar
    {
        [CsDisplayName("Stok Kodu")]
        public string STKODU { get; set; }

        [CsDisplayName("Stok Adı")]
        public string STKNAM { get; set; }

        [CsDisplayName("Parti No")]
        public string PARTIN { get; set; }

        [CsDisplayName("Miktar")]
        public decimal? GNMKTR { get; set; }

        [CsDisplayName("Ölçü Birimi")]
        public string OLCUKD { get; set; }

        [CsDisplayName("Giriş Miktarı")]
        public decimal? GRMKTR { get; set; }

        [CsDisplayName("Giriş Ölçü Birimi")]
        public string GROLBR { get; set; }

        [CsDisplayName("Sipariş Hareket Tipi")]
        public int SPHRTP { get; set; }
    }
}
