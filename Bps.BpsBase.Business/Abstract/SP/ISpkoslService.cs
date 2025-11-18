using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

using Bps.BpsBase.Entities.Models.SP.Listed;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISpkoslService
    {
        ListResponse<SPKOSL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPKOSL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPKOSL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPKOSL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPKOSL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPKOSL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPKOSL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPKOSL> Ncch_Add_NLog(SPKOSL spkosl, Global global);
        StandardResponse<SPKOSL> Ncch_Update_Log(SPKOSL spkosl,SPKOSL oldSpkosl, Global global);
        StandardResponse<SPKOSL> Ncch_UpdateAktifPasif_Log(SPKOSL spkosl, Global global);
        StandardResponse<SPKOSL> Ncch_Delete_Log(SPKOSL spkosl, Global global);

        #region ClientFunc

        ListResponse<SPKOSL> Ncch_GetListByBelgeNo_NLog(Global global, string belgeNo);
        ListResponse<SiparisKosulModel> Ncch_GetListByBelgeNoJoinGnkosul_NLog(Global global, string belgeNo, string langkd);
        StandardResponse<SPKOSL> Ncch_DeleteKosul_Log(SPKOSL spkosl, Global global);

        #endregion ClientFunc
    }
}
