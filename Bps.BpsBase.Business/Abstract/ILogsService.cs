using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

using Bps.BpsBase.Entities.Models.GN.Listed;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract
{
    public interface ILogsService
    {
        ListResponse<Logs> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<Logs> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<Logs> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<Logs> Ncch_Add_NLog(Logs logs, Global global);
        StandardResponse<Logs> Ncch_Update_Log(Logs logs,Logs oldLogs, Global global);
        StandardResponse<Logs> Ncch_Delete_Log(Logs logs, Global global);

        #region ClientFunc
        
        ListResponse<BelgeAkisModel> Ncch_GetLogsByType_NLog(int? id, string type, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
