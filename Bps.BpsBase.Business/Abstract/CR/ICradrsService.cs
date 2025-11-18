using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.CR
{
    public interface ICradrsService
    {
        ListResponse<CRADRS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRADRS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRADRS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRADRS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRADRS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<CRADRS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<CRADRS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<CRADRS> Ncch_Add_NLog(CRADRS cradrs, Global global);
        StandardResponse<CRADRS> Ncch_Update_Log(CRADRS cradrs,CRADRS oldCradrs, Global global);
        StandardResponse<CRADRS> Ncch_UpdateAktifPasif_Log(CRADRS cradrs, Global global);
        StandardResponse<CRADRS> Ncch_Delete_Log(CRADRS cradrs, Global global);

        #region ClientFunc

        ListResponse<CRADRS> Cch_GetListByCariKod_NLog(Global global, string cariKod, bool yetkiKontrol = true);
        StandardResponse<CRADRS> Ncch_AddWithDefaultAdres_NLog(CRADRS cradrs, Global global);
        #endregion ClientFunc
    }
}
