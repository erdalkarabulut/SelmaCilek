using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.WM;


#region ClientUsing
using Bps.BpsBase.Entities.Models.SP.Listed;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.WM
{
    public interface IWmadrsService
    {
        ListResponse<WMADRS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMADRS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMADRS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMADRS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMADRS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<WMADRS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<WMADRS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<WMADRS> Ncch_Add_NLog(WMADRS wmadrs, Global global);
        StandardResponse<WMADRS> Ncch_Update_Log(WMADRS wmadrs,WMADRS oldWmadrs, Global global);
        StandardResponse<WMADRS> Ncch_UpdateAktifPasif_Log(WMADRS wmadrs, Global global);
        StandardResponse<WMADRS> Ncch_Delete_Log(WMADRS wmadrs, Global global);

        #region ClientFunc
        ListResponse<WMADRS> Ncch_GetByBelgeNo_NLog(Global global, string belgeNo, bool yetkiKontrol = true);

        ListResponse<SpStokAdresMiktar> GetSiparisStokAdresMiktar(Global global, string sipBelgeNo, bool rezervasyon,
            bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
