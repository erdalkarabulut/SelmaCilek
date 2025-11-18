using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Models.CR.Listed;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.CR
{
    public interface ICrytklService
    {
        ListResponse<CRYTKL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRYTKL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRYTKL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRYTKL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<CRYTKL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<CRYTKL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<CRYTKL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<CRYTKL> Ncch_Add_NLog(CRYTKL crytkl, Global global);
        StandardResponse<CRYTKL> Ncch_Update_Log(CRYTKL crytkl,CRYTKL oldCrytkl, Global global);
        StandardResponse<CRYTKL> Ncch_UpdateAktifPasif_Log(CRYTKL crytkl, Global global);
        StandardResponse<CRYTKL> Ncch_Delete_Log(CRYTKL crytkl, Global global);

        #region ClientFunc

        ListResponse<CRYTKL> Cch_GetListByCariKod_NLog(string cariKod, Global global, bool yetkiKontrol = true);
        ListResponse<CariYetkiliModel> Ncch_GetCariYetkiliList_NLog(Global global, string crkodu = "",
	        bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
