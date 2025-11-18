using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStseriService
    {
        ListResponse<STSERI> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STSERI> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STSERI> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STSERI> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STSERI> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STSERI> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STSERI> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STSERI> Ncch_Add_NLog(STSERI stseri, Global global);
        StandardResponse<STSERI> Ncch_Update_Log(STSERI stseri,STSERI oldStseri, Global global);
        StandardResponse<STSERI> Ncch_UpdateAktifPasif_Log(STSERI stseri, Global global);
        StandardResponse<STSERI> Ncch_Delete_Log(STSERI stseri, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
