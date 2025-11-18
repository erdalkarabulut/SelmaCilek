using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract
{
    public interface ILockedService
    {
        ListResponse<LOCKED> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<LOCKED> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<LOCKED> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<LOCKED> Ncch_Add_NLog(LOCKED locked, Global global);
        StandardResponse<LOCKED> Ncch_Update_Log(LOCKED locked,LOCKED oldLocked, Global global);
        StandardResponse<LOCKED> Ncch_Delete_Log(LOCKED locked, Global global);

        #region ClientFunc

        StandardResponse LockControlRead(string tableName, int? id, Global global, int lockTime = 60);
        StandardResponse LockControlWrite(string tableName, int? id, Global global);

        #endregion ClientFunc
    }
}
