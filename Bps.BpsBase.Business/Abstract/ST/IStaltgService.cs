using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStaltgService
    {
        ListResponse<STALTG> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STALTG> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STALTG> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STALTG> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STALTG> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STALTG> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STALTG> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STALTG> Ncch_Add_NLog(STALTG staltg, Global global);
        StandardResponse<STALTG> Ncch_Update_Log(STALTG staltg,STALTG oldStaltg, Global global);
        StandardResponse<STALTG> Ncch_UpdateAktifPasif_Log(STALTG staltg, Global global);
        StandardResponse<STALTG> Ncch_Delete_Log(STALTG staltg, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
