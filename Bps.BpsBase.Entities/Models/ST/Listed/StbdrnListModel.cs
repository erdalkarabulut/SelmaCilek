using Bps.Core.AttributeHelpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.ST.Listed
{
    public class StbdrnListModel
    {
        [DisplayName("ID")]
        public int Id { get; set; }

        [DisplayName("Şirket ID")]
        public int SIRKID { get; set; }

        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

       
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        
        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        
        [CsDisplayName("VRYTNM")]
        [MaxLength(150)]
        public string VRYTNM { get; set; }

        [CsDisplayName("RENKKD")]
        [MaxLength(20)]
        public string RENKKD { get; set; }

        [DisplayName("Renk Tanımı")]
        public string RENKTN { get; set; }

        [CsDisplayName("BEDNKD")]
        [MaxLength(20)]
        public string BEDNKD { get; set; }

        [DisplayName("Beden Tanımı")]
        public string BEDNTN { get; set; }

        [CsDisplayName("DROPKD")]
        [MaxLength(20)]
        public string DROPKD { get; set; }

        [DisplayName("Drop Tanımı")]
        public string DROPTN { get; set; }

        [CsDisplayName("EANTKD")]
        [MaxLength(20)]
        public string EANTKD { get; set; }

        [DisplayName("EAN Tanımı")]
        public string EANKTN { get; set; }

        [CsDisplayName("EANKOD")]
        [MaxLength(40)]
        public string EANKOD { get; set; }

        [CsDisplayName("STOZEL")]
        [MaxLength(20)]
        public string STOZEL { get; set; }

       

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

        [DefaultValue(false)]
        [DisplayName("Control")]
        public bool CHKCTR { get; set; }
    }
}
