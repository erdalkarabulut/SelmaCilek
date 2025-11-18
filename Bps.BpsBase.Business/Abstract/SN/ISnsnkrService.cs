using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SN
{
    public interface ISnsnkrService
    {
        ListResponse<SNSNKR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNSNKR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNSNKR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNSNKR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNSNKR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SNSNKR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SNSNKR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SNSNKR> Ncch_Add_NLog(SNSNKR snsnkr, Global global);
        StandardResponse<SNSNKR> Ncch_Update_Log(SNSNKR snsnkr,SNSNKR oldSnsnkr, Global global);
        StandardResponse<SNSNKR> Ncch_UpdateAktifPasif_Log(SNSNKR snsnkr, Global global);
        StandardResponse<SNSNKR> Ncch_Delete_Log(SNSNKR snsnkr, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
