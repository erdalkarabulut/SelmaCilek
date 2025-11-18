using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
    public class KullaniciKartModel
    {
        [Required]
        [CsDisplayName("KULKOD")]
        [MaxLength(20)]
        public string KULKOD { get; set; }

        [Required]
        [CsDisplayName("KARTKD")]
        [MaxLength(20)]
        public string KARTKD { get; set; }

        [Required]
        [CsDisplayName("GNPOSI")]
        public int GNPOSI { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [DisplayName("Durum")]
        public bool ACTIVE { get; set; }

        [DisplayName("Silindi")]
        public bool SLINDI { get; set; }

        [DisplayName("Ekleyen Kullanıcı")]
        public string EKKULL { get; set; }

        [DisplayName("Eklenme Tarihi")]
        public DateTime ETARIH { get; set; }

        [DisplayName("Değiştiren Kullanıcı")]
        public string DEKULL { get; set; }

        [DisplayName("Değişiklik Tarihi")]
        public DateTime? DTARIH { get; set; }

        [DisplayName("Kaynak Kod")]
        public string KYNKKD { get; set; }

        [Required]
        [CsDisplayName("TANIMI")]
        [MaxLength(50)]
        public string TANIMI { get; set; }
    }
}