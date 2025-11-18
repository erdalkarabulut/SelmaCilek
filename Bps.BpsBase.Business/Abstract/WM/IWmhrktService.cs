using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.WM
{
    public interface IWmhrktService
    {
        ListResponse<WMHRKT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMHRKT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMHRKT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMHRKT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMHRKT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<WMHRKT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<WMHRKT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<WMHRKT> Ncch_Add_NLog(WMHRKT wmhrkt, Global global);
        StandardResponse<WMHRKT> Ncch_Update_Log(WMHRKT wmhrkt,WMHRKT oldWmhrkt, Global global);
        StandardResponse<WMHRKT> Ncch_UpdateAktifPasif_Log(WMHRKT wmhrkt, Global global);
        StandardResponse<WMHRKT> Ncch_Delete_Log(WMHRKT wmhrkt, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
