using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.TS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.TS
{
    public interface ITsftipService
    {
        ListResponse<TSFTIP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFTIP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFTIP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFTIP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFTIP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<TSFTIP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<TSFTIP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<TSFTIP> Ncch_Add_NLog(TSFTIP tsftip, Global global);
        StandardResponse<TSFTIP> Ncch_Update_Log(TSFTIP tsftip,TSFTIP oldTsftip, Global global);
        StandardResponse<TSFTIP> Ncch_UpdateAktifPasif_Log(TSFTIP tsftip, Global global);
        StandardResponse<TSFTIP> Ncch_Delete_Log(TSFTIP tsftip, Global global);

        #region ClientFunc

        ListResponse<TSFTIP> Ncch_GetListBySira_NLog(Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
