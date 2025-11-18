using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.WM
{
    public interface IWmadrtService
    {
        ListResponse<WMADRT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMADRT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMADRT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMADRT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMADRT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<WMADRT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<WMADRT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<WMADRT> Ncch_Add_NLog(WMADRT wmadrt, Global global);
        StandardResponse<WMADRT> Ncch_Update_Log(WMADRT wmadrt,WMADRT oldWmadrt, Global global);
        StandardResponse<WMADRT> Ncch_UpdateAktifPasif_Log(WMADRT wmadrt, Global global);
        StandardResponse<WMADRT> Ncch_Delete_Log(WMADRT wmadrt, Global global);

        #region ClientFunc

        ListResponse<WMADRT> Cch_GetListByDepoKd_NLog(string depoKd, Global global, bool yetkiKontrol = true);
        StandardResponse<WMADRT> Cch_GetListByDepoKdDpAdrs_NLog(string depoKd, string dpAdrs, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
