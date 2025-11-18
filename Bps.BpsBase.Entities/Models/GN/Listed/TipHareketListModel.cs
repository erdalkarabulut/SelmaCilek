using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
    [Serializable]
    public class TipHareketListModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [DisplayName("Tip Kod")]
        public string TIPKOD { get; set; }

        [CsDisplayName("UTPKOD")]
        public string UTPKOD { get; set; }

        [CsDisplayName("GFIYAT")]
        public decimal? GFIYAT { get; set; }

        [CsDisplayName("DVCNKD")]
        public string DVCNKD { get; set; }

        [DisplayName("Hareket Kodu")]
        public string HARKOD { get; set; }

        [DisplayName("Tip Adı")]
        public string TIPADI { get; set; }
        [DisplayName("Tip Adı")]

        public string TEKNAD { get; set; }
        [DisplayName("Teknik Adı")]

        public int SIRASI { get; set; }

        [DisplayName("Tanımı")]
        public string TANIMI { get; set; }

        [DisplayName("Parent Adı")]
        public string ParentName { get; set; }

        [DisplayName("Parent")]
        public int PARENT { get; set; }

        [DisplayName("Ek 1")]
        public string EXTRA1 { get; set; }

        [DisplayName("Durum")]
        public bool ACTIVE { get; set; }

        [DisplayName("Ekleyen Kullanıcı")]
        public string EKKULL { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime ETARIH { get; set; }

        [DisplayName("Değiştiren Kullanıcı")]
        public string DEKULL { get; set; }

        [DisplayName("Değişiklik Tarihi")]
        public DateTime? DTARIH { get; set; }
    }
}
