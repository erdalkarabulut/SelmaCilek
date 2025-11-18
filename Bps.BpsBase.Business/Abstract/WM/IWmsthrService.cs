using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.WM
{
    public interface IWmsthrService
    {
        ListResponse<WMSTHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMSTHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMSTHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMSTHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMSTHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<WMSTHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<WMSTHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<WMSTHR> Ncch_Add_NLog(WMSTHR wmsthr, Global global);
        StandardResponse<WMSTHR> Ncch_Update_Log(WMSTHR wmsthr,WMSTHR oldWmsthr, Global global);
        StandardResponse<WMSTHR> Ncch_UpdateAktifPasif_Log(WMSTHR wmsthr, Global global);
        StandardResponse<WMSTHR> Ncch_Delete_Log(WMSTHR wmsthr, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
