using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract
{
    public interface IDovkurService
    {
        ListResponse<DOVKUR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<DOVKUR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<DOVKUR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<DOVKUR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<DOVKUR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<DOVKUR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<DOVKUR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<DOVKUR> Ncch_Add_NLog(DOVKUR dovkur, Global global);
        StandardResponse<DOVKUR> Ncch_Update_Log(DOVKUR dovkur,DOVKUR oldDovkur, Global global);
        StandardResponse<DOVKUR> Ncch_UpdateAktifPasif_Log(DOVKUR dovkur, Global global);
        StandardResponse<DOVKUR> Ncch_Delete_Log(DOVKUR dovkur, Global global);

        #region ClientFunc

        DOVKUR GetDovizKuru(DOVKUR dovkur);

        StandardResponse<DOVKUR> Cch_GetByDate_NLog(string dvcnkd, DateTime dovDate);

        StandardResponse<DOVKUR> Ncch_AutoAdd_NLog(DOVKUR dovkur, Global global);
        ListResponse<DOVKUR> GetRecentCurrencies(Global global);

        #endregion ClientFunc
    }
}
