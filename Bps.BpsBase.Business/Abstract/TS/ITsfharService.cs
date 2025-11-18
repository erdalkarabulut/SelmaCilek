using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.TS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.TS
{
    public interface ITsfharService
    {
        ListResponse<TSFHAR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFHAR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFHAR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFHAR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<TSFHAR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<TSFHAR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<TSFHAR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<TSFHAR> Ncch_Add_NLog(TSFHAR tsfhar, Global global);
        StandardResponse<TSFHAR> Ncch_Update_Log(TSFHAR tsfhar,TSFHAR oldTsfhar, Global global);
        StandardResponse<TSFHAR> Ncch_UpdateAktifPasif_Log(TSFHAR tsfhar, Global global);
        StandardResponse<TSFHAR> Ncch_Delete_Log(TSFHAR tsfhar, Global global);

        #region ClientFunc

        ListResponse<TSFHAR> Cch_GetListByBelge_NLog(string belgeNo, Global global);

        #endregion ClientFunc
    }
}
