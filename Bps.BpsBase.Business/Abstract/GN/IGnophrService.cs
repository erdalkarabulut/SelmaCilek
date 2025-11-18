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
    public interface IGnophrService
    {
        ListResponse<GNOPHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNOPHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNOPHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNOPHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNOPHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNOPHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNOPHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNOPHR> Ncch_Add_NLog(GNOPHR gnophr, Global global);
        StandardResponse<GNOPHR> Ncch_Update_Log(GNOPHR gnophr,GNOPHR oldGnophr, Global global);
        StandardResponse<GNOPHR> Ncch_UpdateAktifPasif_Log(GNOPHR gnophr, Global global);
        StandardResponse<GNOPHR> Ncch_Delete_Log(GNOPHR gnophr, Global global);

        #region ClientFunc

        ListResponse<GNOPHR> Ncch_GetListByTipKod(Global global, string tipKod, bool yetkiKontrol = true);
        ListResponse<GNOPHR> Ncch_GetListByTeknad(Global global, string teknad, bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> TipHareketListGetir(Global global, string tipKod,
            bool yetkiKontrol = true);
        StandardResponse<GNOPHR> Ncch_GetByTipAndHarKod(Global global, string tipKod, string harkod, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
