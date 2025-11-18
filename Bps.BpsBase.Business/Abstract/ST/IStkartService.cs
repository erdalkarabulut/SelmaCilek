using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.BpsBase.Entities.Models.ST.Api;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStkartService
    {
        ListResponse<STKART> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKART> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKART> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKART> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKART> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STKART> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STKART> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STKART> Ncch_Add_NLog(STKART stkart, Global global);
        StandardResponse<STKART> Ncch_Update_Log(STKART stkart,STKART oldStkart, Global global);
        StandardResponse<STKART> Ncch_UpdateAktifPasif_Log(STKART stkart, Global global);
        StandardResponse<STKART> Ncch_Delete_Log(STKART stkart, Global global);

        #region ClientFunc

        ListResponse<STKART> Cch_GetListByMalTur_NLog(Global global, string malTur, bool yetkiKontrol = true);
        StandardResponse<STKART> Ncch_GetRecentByMalTur_NLog(Global global, string malTur, bool yetkiKontrol = true);
        StandardResponse<STKART> Ncch_GetByStKod_NLog(string stokKod, Global global, bool yetkiKontrol = true);
        ListResponse<StokKodAdModel> GetStokKodAd(Global global, List<string> filterList = null, bool yetkiKontrol = true);
        StandardResponse<STKART> Ncch_GetByStKodLike_NLog(string stokKodu, string malzemeTuru, Global global, bool yetkiKontrol = true);
        ListResponse<STKART> Ncch_GetListByStKodLike_NLog(string stokKodu, string malzemeTuru, Global global, bool yetkiKontrol = true);
        ListResponse<STKART> Ncch_GetListWithParti_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKART> Ncch_GetList_NLog(Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
