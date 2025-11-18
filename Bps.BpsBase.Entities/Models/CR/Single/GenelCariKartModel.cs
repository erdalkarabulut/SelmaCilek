using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.CR;

namespace Bps.BpsBase.Entities.Models.CR.Single
{
    public class GenelCariKartModel
    {
        public CRCARI CariKart { get; set; }
        public List<CRADRS> Adresler { get; set; }
        public List<CRYTKL> Crytkls { get; set; }
        public List<CRBANK> Crbanks { get; set; }
    }
}