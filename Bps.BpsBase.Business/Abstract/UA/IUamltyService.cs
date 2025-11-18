using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.UA
{
    public interface IUamltyService
    {
        ListResponse<UAMLTY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAMLTY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAMLTY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAMLTY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UAMLTY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<UAMLTY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<UAMLTY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<UAMLTY> Ncch_Add_NLog(UAMLTY uamlty, Global global);
        StandardResponse<UAMLTY> Ncch_Update_Log(UAMLTY uamlty,UAMLTY oldUamlty, Global global);
        StandardResponse<UAMLTY> Ncch_UpdateAktifPasif_Log(UAMLTY uamlty, Global global);
        StandardResponse<UAMLTY> Ncch_Delete_Log(UAMLTY uamlty, Global global);

        #region ClientFunc

        ListResponse<UAMLTY> Cch_GetListByUaKodAndMaltr_NLog(Global global, string uAKodu, string malzTuru, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
