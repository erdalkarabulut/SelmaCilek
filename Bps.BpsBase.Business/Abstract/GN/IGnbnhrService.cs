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
    public interface IGnbnhrService
    {
        ListResponse<GNBNHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNBNHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNBNHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNBNHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNBNHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNBNHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNBNHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNBNHR> Ncch_Add_NLog(GNBNHR gnbnhr, Global global);
        StandardResponse<GNBNHR> Ncch_Update_Log(GNBNHR gnbnhr,GNBNHR oldGnbnhr, Global global);
        StandardResponse<GNBNHR> Ncch_UpdateAktifPasif_Log(GNBNHR gnbnhr, Global global);
        StandardResponse<GNBNHR> Ncch_Delete_Log(GNBNHR gnbnhr, Global global);

        #region ClientFunc

        ListResponse<GNBNHR> Cch_GetListByTipKod(Global global, string tipKod, bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> Cch_TipHareketListGetir(Global global, string tipKod,
            bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> Ncch_GetThrkByMultiTeknad_NLog(Global global, List<String> teknads,
            bool yetkiKontrol = true);
        #endregion ClientFunc
    }
}
