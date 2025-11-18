using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnyetbService
    {
        ListResponse<GNYETB> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNYETB> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNYETB> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNYETB> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNYETB> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNYETB> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNYETB> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNYETB> Ncch_Add_NLog(GNYETB gnyetb, Global global);
        StandardResponse<GNYETB> Ncch_Update_Log(GNYETB gnyetb,GNYETB oldGnyetb, Global global);
        StandardResponse<GNYETB> Ncch_UpdateAktifPasif_Log(GNYETB gnyetb, Global global);
        StandardResponse<GNYETB> Ncch_Delete_Log(GNYETB gnyetb, Global global);

        #region ClientFunc
        StandardResponse Ncch_MultiDelete_Log(List<GNYETB> gnyetb, Global global);
        StandardResponse Ncch_MultiAdd_Log(List<GNYETB> gnyetb, Global global);
        ListResponse<GNYETB> Cch_GetListYetkiId_NLog(int yetkiid, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
