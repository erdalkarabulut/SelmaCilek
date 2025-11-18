using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.UR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.UR
{
    public interface IUragvrService
    {
        ListResponse<URAGVR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URAGVR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URAGVR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URAGVR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URAGVR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<URAGVR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<URAGVR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<URAGVR> Ncch_Add_NLog(URAGVR uragvr, Global global);
        StandardResponse<URAGVR> Ncch_Update_Log(URAGVR uragvr,URAGVR oldUragvr, Global global);
        StandardResponse<URAGVR> Ncch_UpdateAktifPasif_Log(URAGVR uragvr, Global global);
        StandardResponse<URAGVR> Ncch_Delete_Log(URAGVR uragvr, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
