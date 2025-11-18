using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

using Bps.BpsBase.Entities.Models.GN.Listed;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnkukrService
    {
        ListResponse<GNKUKR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKUKR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKUKR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKUKR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKUKR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNKUKR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNKUKR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNKUKR> Ncch_Add_NLog(GNKUKR gnkukr, Global global);
        StandardResponse<GNKUKR> Ncch_Update_Log(GNKUKR gnkukr,GNKUKR oldGnkukr, Global global);
        StandardResponse<GNKUKR> Ncch_UpdateAktifPasif_Log(GNKUKR gnkukr, Global global);
        StandardResponse<GNKUKR> Ncch_Delete_Log(GNKUKR gnkukr, Global global);

        #region ClientFunc

        ListResponse<KullaniciKartModel> Ncch_GetKulKartList_NLog(Global global, string kulKod, bool yetkiKontrol = true);
        StandardResponse Ncch_DashboardGuncelle_Log(Global global, List<KullaniciKartModel> model);

        #endregion ClientFunc
    }
}
