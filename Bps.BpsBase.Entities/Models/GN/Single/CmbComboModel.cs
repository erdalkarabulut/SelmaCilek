using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.GN.Listed;

namespace Bps.BpsBase.Entities.Models.GN.Single
{
    public class CmbComboModel
    {
        public List<TipHareketListModel> TipHareketList { get; set; }

        public int PARENT { get; set; }

        public string HARKOD { get; set; }

        public List<GNMENU> MenuList { get; set; }

        public int MNUTAG { get; set; }

        public string ComboboxName { get; set; }

        public bool? IsRequired { get; set; }
    }
}