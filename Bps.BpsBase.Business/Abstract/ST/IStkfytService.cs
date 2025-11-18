using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStkfytService
    {
        ListResponse<STKFYT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKFYT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKFYT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKFYT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STKFYT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STKFYT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STKFYT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STKFYT> Ncch_Add_NLog(STKFYT stkfyt, Global global);
        StandardResponse<STKFYT> Ncch_Update_Log(STKFYT stkfyt,STKFYT oldStkfyt, Global global);
        StandardResponse<STKFYT> Ncch_UpdateAktifPasif_Log(STKFYT stkfyt, Global global);
        StandardResponse<STKFYT> Ncch_Delete_Log(STKFYT stkfyt, Global global);

        #region ClientFunc

        StandardResponse<STKFYT> Ncch_GetByFiyatNo_NLog(string fiyatNo, Global global, bool yetkiKontrol = true);
        ListResponse<STKFYT> Cch_GetListByKdvFlag_NLog(bool kdvFlag, Global global, bool yetkiKontrol = true);
        ListResponse<STKFYT> Ncch_GetListByStokHareketTip_NLog(int sthrtp, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
