using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnoptpService
    {
        ListResponse<GNOPTP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNOPTP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNOPTP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNOPTP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNOPTP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNOPTP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNOPTP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNOPTP> Ncch_Add_NLog(GNOPTP gnoptp, Global global);
        StandardResponse<GNOPTP> Ncch_Update_Log(GNOPTP gnoptp,GNOPTP oldGnoptp, Global global);
        StandardResponse<GNOPTP> Ncch_UpdateAktifPasif_Log(GNOPTP gnoptp, Global global);
        StandardResponse<GNOPTP> Ncch_Delete_Log(GNOPTP gnoptp, Global global);

        #region ClientFunc

        ListResponse<GNOPTP> Ncch_GetListByUstTipKod_NLog(Global global, string utpkod, bool yetkiKontrol = true);
        StandardResponse<GNOPTP> Ncch_GetByTeknikAd_NLog(Global global, string teknad, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
