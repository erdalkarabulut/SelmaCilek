using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
    public class ImageGaleryModel
    {
        [CsDisplayName("FLNAME")]
        public string FLNAME { get; set; }

        [CsDisplayName("GNDOSY")]
        public byte[] GNDOSY { get; set; }

        [CsDisplayName("GNPATH")]
        [MaxLength(500)]
        public string GNPATH { get; set; }

        [DisplayName("Size")]
        [MaxLength(500)]
        public string GNSIZE { get; set; }

        [CsDisplayName("FLNAME")]
        public string FileName
        {
            get
            {
                var str = "";
                if (!string.IsNullOrEmpty(FLNAME))
                {
                    var splitedNames = FLNAME.Split(new string[] { "---" }, StringSplitOptions.None);

                    if (splitedNames.Length == 3)
                    {
                        str = splitedNames[2];
                    }
                    else
                    {
                        str = FLNAME;
                    }
                }
                return str;
            }
        }
    }
}