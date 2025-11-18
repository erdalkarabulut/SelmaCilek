using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SN
{
    public interface ISnkrtyService
    {
        ListResponse<SNKRTY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNKRTY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNKRTY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNKRTY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SNKRTY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SNKRTY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SNKRTY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SNKRTY> Ncch_Add_NLog(SNKRTY snkrty, Global global);
        StandardResponse<SNKRTY> Ncch_Update_Log(SNKRTY snkrty,SNKRTY oldSnkrty, Global global);
        StandardResponse<SNKRTY> Ncch_UpdateAktifPasif_Log(SNKRTY snkrty, Global global);
        StandardResponse<SNKRTY> Ncch_Delete_Log(SNKRTY snkrty, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
