using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStoptmService
    {
        ListResponse<STOPTM> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STOPTM> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STOPTM> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STOPTM> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STOPTM> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STOPTM> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STOPTM> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STOPTM> Ncch_Add_NLog(STOPTM stoptm, Global global);
        StandardResponse<STOPTM> Ncch_Update_Log(STOPTM stoptm,STOPTM oldStoptm, Global global);
        StandardResponse<STOPTM> Ncch_UpdateAktifPasif_Log(STOPTM stoptm, Global global);
        StandardResponse<STOPTM> Ncch_Delete_Log(STOPTM stoptm, Global global);

        #region ClientFunc

        StandardResponse<STOPTM> Ncch_GetByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
