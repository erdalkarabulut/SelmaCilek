using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.BpsBase.Entities.Models.ST.Listed;

namespace Bps.BpsBase.Entities.Models.WM.Api
{
    public class StokAdresTransferModel
    {
        public StdepoStokAdresModel KaynakStokAdresModel { get; set; }

        public string HedefAdres { get; set; }

        public double Miktar { get; set; }

        public int Stftno { get; set; }
    }
}
