using System.Collections.Generic;
using Bps.BpsBase.Entities.Concrete.CM;
using Bps.BpsBase.Entities.Concrete.IS;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.BpsBase.Entities.Models.TS;
using Bps.BpsBase.Entities.Models.WM.Api;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;

namespace Bps.BpsBase.Business.Abstract.XX
{
    public interface IXXService
    {
        StandardResponse Ncch_StokKartKaydet_Log(Global global, GenelStokKartModel model, List<Grid> grids, string action, bool yetkiKontrol = true);

        StandardResponse Ncch_SiparisKaydet_Log(SiparisKayitModel model, Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_CrmKartKaydet_Log(CMKART cmkart, List<CMAKSN> aksiyonList, Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_StokSayim_Log(StokHareketModel model, Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_SasGiris_Log(StokHareketModel model, Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_StokDepoTransfer_Log(StokHareketModel model, Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_StokMalGirisCikis_Log(StokHareketModel model, Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_StokAdresTransferWm_Log(List<StokAdresTransferModel> modelList, Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_StokGirisCikisByOptimizasyon_Log(StokHareketModel cikisModel, StokHareketModel girisModel, Global global, bool yetkiKontrol = true);

        StandardResponse<SiparisKayitModel> Ncch_OnlineProformaKaydet_Log(SiparisKayitModel model, Global global,
            bool yetkiKontrol = true);

        StandardResponse Ncch_TeslimatKaydet_Log(TeslimatKayitModel model, Global global, bool yetkiKontrol = true);

        StandardResponse Ncch_SiparisRezervasyonKaydet_Log(List<SPREZV> sprezvList, Global global,
            bool yetkiKontrol = true);
        StandardResponse Ncch_OrganizasyonHareketKaydet_Log(string orgKod, string tablnm, int tablid, Global global, bool yetkiKontrol = true);
        StandardResponse Ncch_OrganizasyonHareketOnay_Log(string orgKod, string tablnm, int tablid, Global global, bool yetkiKontrol = true, bool onay = true);

        StandardResponse<ISYRTN> Ncch_IsyeriOperasyonKaydet_Log(ISYRTN isyrtn, List<string> operasyonList,
	        Global global, bool yetkiKontrol = true);

        StandardResponse<string> Ncch_SiparisIsemriOlustur_Log(string sipBelgeNo, Global global, bool yetkiKontrol = true);
        StandardResponse<string> Ncch_StokKodOlustur_NLog(Global global, STMALT _stmalt, STKART _stkart, string krtsay = "D4", bool yetkiKontrol = true, bool kaydet = true);
    }
}