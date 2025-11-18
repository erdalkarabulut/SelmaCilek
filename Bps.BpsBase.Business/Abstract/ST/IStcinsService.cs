using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStcinsService
    {
        ListResponse<STCINS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STCINS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STCINS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STCINS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STCINS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STCINS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STCINS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STCINS> Ncch_Add_NLog(STCINS stcins, Global global);
        StandardResponse<STCINS> Ncch_Update_Log(STCINS stcins,STCINS oldStcins, Global global);
        StandardResponse<STCINS> Ncch_UpdateAktifPasif_Log(STCINS stcins, Global global);
        StandardResponse<STCINS> Ncch_Delete_Log(STCINS stcins, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
