using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

using Bps.BpsBase.Entities.Models.CR.Single;
using Bps.BpsBase.Entities.Models.CR.Listed;
using Bps.Core.Utilities.WinForm;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.CR
{
    public interface ICrcariService
    {
        ListResponse<CRCARI> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCARI> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCARI> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCARI> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCARI> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<CRCARI> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<CRCARI> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<CRCARI> Ncch_Add_NLog(CRCARI crcari, Global global);
        StandardResponse<CRCARI> Ncch_Update_Log(CRCARI crcari,CRCARI oldCrcari, Global global);
        StandardResponse<CRCARI> Ncch_UpdateAktifPasif_Log(CRCARI crcari, Global global);
        StandardResponse<CRCARI> Ncch_Delete_Log(CRCARI crcari, Global global);

        #region ClientFunc

        ListResponse<CRCARI> Ncch_GetAllActive_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRCARI> Cch_GetListByTip_NLog(Global global, string tipKod, bool yetkiKontrol = true);
        ListResponse<CRCARI> Cch_GetAllListByTip_NLog(Global global, string tipKod, bool yetkiKontrol = true);
        StandardResponse<CRCARI> Ncch_GetByCariKod_NLog(string cariKod, Global global, bool yetkiKontrol = true);
        StandardResponse Ncch_CariSaving_Log(Global global, GenelCariKartModel model, List<Grid> grids, bool yetkiKontrol = true);
        StandardResponse<CRCARI> Ncch_SaveSingleCari_Log(Global global, GenelCariKartModel model, bool yetkiKontrol = true);
        ListResponse<CariEmailModel> Ncch_GetCariEmails_NLog(string cariKodu, Global global, bool yetkiKontrol = true);
        ListResponse<CariKodAdModel> Ncch_GetCariKodAdList_NLog(Global global, string crhrkd = "", bool yetkiKontrol = true);
        StandardResponse<CRCARI> Ncch_GetByCariKodLike_NLog(string cariKodu, Global global, bool yetkiKontrol = true);
        ListResponse<CariExternalSourceModel> GetCariListFromExternalSource(string sqlQuery, Global global,
            bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
