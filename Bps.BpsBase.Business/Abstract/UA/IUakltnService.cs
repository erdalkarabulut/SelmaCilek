using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.UA
{
    public interface IUakltnService
    {
        ListResponse<UAKLTN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAKLTN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAKLTN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAKLTN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAKLTN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<UAKLTN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<UAKLTN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<UAKLTN> Ncch_Add_NLog(UAKLTN uakltn, Global global);
        StandardResponse<UAKLTN> Ncch_Update_Log(UAKLTN uakltn,UAKLTN oldUakltn, Global global);
        StandardResponse<UAKLTN> Ncch_UpdateAktifPasif_Log(UAKLTN uakltn, Global global);
        StandardResponse<UAKLTN> Ncch_Delete_Log(UAKLTN uakltn, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
