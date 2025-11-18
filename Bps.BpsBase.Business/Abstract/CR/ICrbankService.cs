using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.CR
{
    public interface ICrbankService
    {
        ListResponse<CRBANK> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRBANK> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRBANK> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRBANK> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRBANK> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<CRBANK> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<CRBANK> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<CRBANK> Ncch_Add_NLog(CRBANK crbank, Global global);
        StandardResponse<CRBANK> Ncch_Update_Log(CRBANK crbank,CRBANK oldCrbank, Global global);
        StandardResponse<CRBANK> Ncch_UpdateAktifPasif_Log(CRBANK crbank, Global global);
        StandardResponse<CRBANK> Ncch_Delete_Log(CRBANK crbank, Global global);

        #region ClientFunc

        ListResponse<CRBANK> Cch_GetListByCariKod_NLog(string cariKod, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
