using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
    public class TipListModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [Required]
        [Column(Order = 3)]
        [CsDisplayName("TIPKOD")]
        [MaxLength(20)]
        public string TIPKOD { get; set; }

        [Required]
        [Column(Order = 4)]
        [CsDisplayName("TIPADI")]
        [MaxLength(50)]
        public string TIPADI { get; set; }

        [Required]
        [Column(Order = 5)]
        [CsDisplayName("TEKNAD")]
        [MaxLength(6)]
        public string TEKNAD { get; set; }

        [Column(Order = 6)]
        [CsDisplayName("UTPKOD")]
        [MaxLength(20)]
        public string UTPKOD { get; set; }

        [CsDisplayName("UTPADI")]
        public string UTPADI { get; set; }

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
    }
}