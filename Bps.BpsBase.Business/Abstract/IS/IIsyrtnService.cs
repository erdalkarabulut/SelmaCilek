using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.IS
{
    public interface IIsyrtnService
    {
        ListResponse<ISYRTN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISYRTN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISYRTN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISYRTN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISYRTN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<ISYRTN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<ISYRTN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<ISYRTN> Ncch_Add_NLog(ISYRTN isyrtn, Global global);
        StandardResponse<ISYRTN> Ncch_Update_Log(ISYRTN isyrtn,ISYRTN oldIsyrtn, Global global);
        StandardResponse<ISYRTN> Ncch_UpdateAktifPasif_Log(ISYRTN isyrtn, Global global);
        StandardResponse<ISYRTN> Ncch_Delete_Log(ISYRTN isyrtn, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
