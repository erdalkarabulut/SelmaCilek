using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Bps.Core.Entities;

namespace Bps.BpsBase.Entities.Concrete
{
    public class Logs : IEntity
    {
        public int Id { get; set; }

        [CsDisplayName("Detail")]
        public string Detail { get; set; }

        [CsDisplayName("Date")]
        public DateTime? Date { get; set; }

        [CsDisplayName("Audit")]
        public string Audit { get; set; }

        [CsDisplayName("UserKod")]
        public string UserKod { get; set; }

        [CsDisplayName("ProjeKod")]
        public string ProjeKod { get; set; }

        [CsDisplayName("KaynakKod")]
        public string KaynakKod { get; set; }

        [CsDisplayName("IsCompare")]
        public string IsCompare { get; set; }

        [CsDisplayName("TEKNAD")]
        public string TEKNAD { get; set; }

        [CsDisplayName("TableId")]
        public string TableId { get; set; }

        public Logs ShallowCopy()
        {
            return (Logs)this.MemberwiseClone();
        }

    }
}
