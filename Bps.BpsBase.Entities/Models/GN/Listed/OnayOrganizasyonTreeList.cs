using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.GN
{
    public class OnayOrganizasyonTreeList
    {
        public int ParentId { get; set; }
        public int AltId { get; set; }
        public string Orgtkd { get; set; }

        public string Tanimi { get; set; }
        public int Seviye { get; set; }
        public string Kulkod { get; set; }
        public string Gnname { get; set; }
        public string Gnsnam { get; set; }

        public int Onysvy { get; set; }
        public bool Gnonay { get; set; }
        public bool Gnlony { get; set; }
        public bool Gndfon { get; set; }
        public int Sirasi { get; set; }





    }
}
