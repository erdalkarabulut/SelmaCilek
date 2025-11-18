using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
    public class UploadedFilesModel
    {
        [CsDisplayName("FLNAME")]
        public string FLNAME { get; set; }

        [CsDisplayName("GNPATH")]
        [MaxLength(500)]
        public string GNPATH { get; set; }

        [DisplayName("Size")]
        [MaxLength(500)]
        public string GNSIZE { get; set; }
    }
}