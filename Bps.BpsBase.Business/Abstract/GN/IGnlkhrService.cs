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
    public interface IGnlkhrService
    {
        ListResponse<GNLKHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNLKHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNLKHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNLKHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNLKHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNLKHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNLKHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNLKHR> Ncch_Add_NLog(GNLKHR gnlkhr, Global global);
        StandardResponse<GNLKHR> Ncch_Update_Log(GNLKHR gnlkhr,GNLKHR oldGnlkhr, Global global);
        StandardResponse<GNLKHR> Ncch_UpdateAktifPasif_Log(GNLKHR gnlkhr, Global global);
        StandardResponse<GNLKHR> Ncch_Delete_Log(GNLKHR gnlkhr, Global global);

        #region ClientFunc

        StandardResponse<GNLKHR> Ncch_GetByTipKodAndHarKod_NLog(Global global, string tipKod, string harKod, bool yetkiKontrol = true);
        ListResponse<GNLKHR> Cch_GetListByTipKod(Global global, string tipKod, bool yetkiKontrol = true);
        ListResponse<GNLKHR> Cch_GetListByTipKodAndParent(Global global, string tipKod, int parent, bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> Cch_TipHareketListGetir(Global global, string tipKod,
            bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> Ncch_GetThrkByMultiTeknad_NLog(Global global, List<String> teknads,
            bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
