using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Utilities.WinForm;

namespace Bps.BpsBase.Entities.Models.GN.Single
{
    public class GenelKayitModel
    {
        public List<Grid> Grids { get; set; }

        public List<GNDPTN> Gndptns { get; set; }
    }
}
