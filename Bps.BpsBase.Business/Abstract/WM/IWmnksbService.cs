using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.WM
{
    public interface IWmnksbService
    {
        ListResponse<WMNKSB> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMNKSB> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMNKSB> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMNKSB> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMNKSB> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<WMNKSB> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<WMNKSB> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<WMNKSB> Ncch_Add_NLog(WMNKSB wmnksb, Global global);
        StandardResponse<WMNKSB> Ncch_Update_Log(WMNKSB wmnksb,WMNKSB oldWmnksb, Global global);
        StandardResponse<WMNKSB> Ncch_UpdateAktifPasif_Log(WMNKSB wmnksb, Global global);
        StandardResponse<WMNKSB> Ncch_Delete_Log(WMNKSB wmnksb, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
