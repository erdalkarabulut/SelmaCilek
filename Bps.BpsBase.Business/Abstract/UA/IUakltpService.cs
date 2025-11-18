using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.UA
{
    public interface IUakltpService
    {
        ListResponse<UAKLTP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAKLTP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAKLTP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAKLTP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAKLTP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<UAKLTP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<UAKLTP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<UAKLTP> Ncch_Add_NLog(UAKLTP uakltp, Global global);
        StandardResponse<UAKLTP> Ncch_Update_Log(UAKLTP uakltp,UAKLTP oldUakltp, Global global);
        StandardResponse<UAKLTP> Ncch_UpdateAktifPasif_Log(UAKLTP uakltp, Global global);
        StandardResponse<UAKLTP> Ncch_Delete_Log(UAKLTP uakltp, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
