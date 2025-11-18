using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.SP.Single
{
    public class SiparisRaporModel
    {
        public SPFBAS Baslik { get; set; }
        public SPFHAR Kalem { get; set; }
        public CRCARI FaturaCari { get; set; }
        public CRCARI SevkCari { get; set; }

        public CRADRS FaturaAdres { get; set; }
        public CRADRS SevkAdres { get; set; }

        public STBDRN Varyant { get; set; }
        public CRYTKL FaturaYetKili { get; set; }
        public string UrunImageUrl { get; set; }
        public Image UrunImage { get; set; }
    }
}
