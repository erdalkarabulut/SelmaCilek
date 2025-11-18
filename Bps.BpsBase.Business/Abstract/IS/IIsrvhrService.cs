using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.IS
{
    public interface IIsrvhrService
    {
        ListResponse<ISRVHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISRVHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISRVHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISRVHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISRVHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<ISRVHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<ISRVHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<ISRVHR> Ncch_Add_NLog(ISRVHR isrvhr, Global global);
        StandardResponse<ISRVHR> Ncch_Update_Log(ISRVHR isrvhr,ISRVHR oldIsrvhr, Global global);
        StandardResponse<ISRVHR> Ncch_UpdateAktifPasif_Log(ISRVHR isrvhr, Global global);
        StandardResponse<ISRVHR> Ncch_Delete_Log(ISRVHR isrvhr, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
