using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Concrete.IS
{
    public class ISPLAN : BaseEntity
    {
        [CsDisplayName("ISPKOD")]
        [MaxLength(20)]
        public string ISPKOD { get; set; }

        [Required]
        [CsDisplayName("SIRASI")]
        public int SIRASI { get; set; }

        [Required]
        [CsDisplayName("GNTARH")]
        public DateTime GNTARH { get; set; }

        [Required]
        [CsDisplayName("URYRKD")]
        [MaxLength(20)]
        public string URYRKD { get; set; }

        [CsDisplayName("ISYKOD")]
        [MaxLength(20)]
        public string ISYKOD { get; set; }

        [Required]
        [CsDisplayName("ISOPKD")]
        [MaxLength(20)]
        public string ISOPKD { get; set; }

        [CsDisplayName("ISMETN")]
        [MaxLength(50)]
        public string ISMETN { get; set; }

        [CsDisplayName("SPSRNO")]
        public int? SPSRNO { get; set; }

        [Required]
        [CsDisplayName("SPSTKD")]
        [MaxLength(25)]
        public string SPSTKD { get; set; }

        [Required]
        [CsDisplayName("MXPRKD")]
        [MaxLength(25)]
        public string MXPRKD { get; set; }

        [Required]
        [CsDisplayName("STKODU")]
        [MaxLength(25)]
        public string STKODU { get; set; }

        [CsDisplayName("VRKODU")]
        [MaxLength(25)]
        public string VRKODU { get; set; }

        [Required]
        [CsDisplayName("GNREZV")]
        [MaxLength(50)]
        public string GNREZV { get; set; }

        [Required]
        [CsDisplayName("URAKOD")]
        [MaxLength(50)]
        public string URAKOD { get; set; }

        [CsDisplayName("PURKOD")]
        [MaxLength(50)]
        public string PURKOD { get; set; }

        [CsDisplayName("BASTAR")]
        public DateTime? BASTAR { get; set; }

        [CsDisplayName("ISLMNO")]
        public int? ISLMNO { get; set; }

        [Required]
        [CsDisplayName("PLMKTR")]
        public decimal PLMKTR { get; set; }

        [CsDisplayName("GRMKTR")]
        public decimal? GRMKTR { get; set; }

        [Required]
        [CsDisplayName("GROLBR")]
        [MaxLength(20)]
        public string GROLBR { get; set; }

        [CsDisplayName("GNHZSR")]
        public int? GNHZSR { get; set; }

        [CsDisplayName("GNHZOB")]
        [MaxLength(20)]
        public string GNHZOB { get; set; }

        [CsDisplayName("ISLMSR")]
        public int? ISLMSR { get; set; }

        [CsDisplayName("ISLMSB")]
        [MaxLength(20)]
        public string ISLMSB { get; set; }

        [CsDisplayName("ISCSUR")]
        public int? ISCSUR { get; set; }

        [CsDisplayName("ISCSUB")]
        [MaxLength(20)]
        public string ISCSUB { get; set; }

        [CsDisplayName("GCTSUR")]
        public int? GCTSUR { get; set; }

        [CsDisplayName("GCTSUB")]
        [MaxLength(20)]
        public string GCTSUB { get; set; }

        [Required]
        [CsDisplayName("FLGKPN")]
        public bool FLGKPN { get; set; }

        public ISPLAN ShallowCopy()
        {
            return (ISPLAN)this.MemberwiseClone();
        }

    }
}
