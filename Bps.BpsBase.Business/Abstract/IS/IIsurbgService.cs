using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.IS
{
    public interface IIsurbgService
    {
        ListResponse<ISURBG> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISURBG> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISURBG> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISURBG> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISURBG> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<ISURBG> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<ISURBG> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<ISURBG> Ncch_Add_NLog(ISURBG isurbg, Global global);
        StandardResponse<ISURBG> Ncch_Update_Log(ISURBG isurbg,ISURBG oldIsurbg, Global global);
        StandardResponse<ISURBG> Ncch_UpdateAktifPasif_Log(ISURBG isurbg, Global global);
        StandardResponse<ISURBG> Ncch_Delete_Log(ISURBG isurbg, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
