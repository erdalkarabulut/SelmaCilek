using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface ISthbasService
    {
        ListResponse<STHBAS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STHBAS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STHBAS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STHBAS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STHBAS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STHBAS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STHBAS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STHBAS> Ncch_Add_NLog(STHBAS sthbas, Global global);
        StandardResponse<STHBAS> Ncch_Update_Log(STHBAS sthbas,STHBAS oldSthbas, Global global);
        StandardResponse<STHBAS> Ncch_UpdateAktifPasif_Log(STHBAS sthbas, Global global);
        StandardResponse<STHBAS> Ncch_Delete_Log(STHBAS sthbas, Global global);

        #region ClientFunc
        StandardResponse<STHBAS> Ncch_GetByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true);
        #endregion ClientFunc
    }
}
