using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.Entities.Models.ST.Single
{
    public class GenelStokKartModel
    {
        public STKART Stkart { get; set; }
        public List<STDEPO> Stdepos { get; set; }
        public List<STMHSB> Stmhsbs { get; set; }
        public List<STSALE> Stsales { get; set; }
        public List<STOLCU> Stolcus { get; set; }
        public STKMIZ Stkmiz { get; set; }
        public List<STNAME> Stnames { get; set; }
        public List<STURYR> Sturyrs { get; set; }
        public List<STDPYN> Stdpyns { get; set; }
        public List<UrunOpsiyonModel> UrunOpsiyons { get; set; }
        public List<STBDRN> Stbdrns { get; set; }

        //public SADEGA SatinAlmaDegerAnahtar { get; set; }

        //public List<STNAME> DilTanimlari { get; set; }
        //public List<StnameBatchModel> DilUpdateValues { get; set; }

        //public string Stname
        //{
        //    get
        //    {
        //        return DilTanimlari.FirstOrDefault(f => f.LANGKD == SessionHelper.DilKod)?.STKNAM;
        //    }
        //}

        //public List<STDEPO> DepoTanimlari { get; set; }

        //public List<StdepoBatchModel> StokDepoUpdateValues { get; set; }

        //public List<STMHSB> MuhasebeTanimlari { get; set; }

        //public List<StmhsbBatchModel> StokMuhasebeUpdateValues { get; set; }

        //public List<STSALE> SatisTanim { get; set; }

        //public List<StsaleBatchModel> StokSatisUpdateValues { get; set; }
    }
}