using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using System;
using System.ComponentModel;
using Bps.Core.AttributeHelpers;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Bps.BpsBase.Entities.Models.ST.Single
{
    public class StokHareketModel
    {
        public STHBAS Baslik { get; set; }
        public List<STHRKT> Kalemler { get; set; }
        public STOPTM Optimizasyon { get; set; }
        public string KaynakWmAdres { get; set; }
        public string HedefWmAdres { get; set; }
        public List<string> KaynakWmAdresList { get; set; }
        public List<string> HedefWmAdresList { get; set; }
        public List<SPFHAR> SiparisList { get; set; }
        public List<SPREZV> RezervasyonList { get; set; }
        public StokHareketModel ShallowCopy()
        {
            return (StokHareketModel)this.MemberwiseClone();
        }
    }
  
}