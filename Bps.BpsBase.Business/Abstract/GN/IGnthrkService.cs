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
    public interface IGnthrkService
    {
        ListResponse<GNTHRK> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNTHRK> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNTHRK> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNTHRK> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNTHRK> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNTHRK> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNTHRK> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNTHRK> Ncch_Add_NLog(GNTHRK gnthrk, Global global);
        StandardResponse<GNTHRK> Ncch_Update_Log(GNTHRK gnthrk,GNTHRK oldGnthrk, Global global);
        StandardResponse<GNTHRK> Ncch_UpdateAktifPasif_Log(GNTHRK gnthrk, Global global);
        StandardResponse<GNTHRK> Ncch_Delete_Log(GNTHRK gnthrk, Global global);

        #region ClientFunc
        StandardResponse<GNTHRK> Cch_GetByTipAndHarKod(Global global, string tipKod, string harKod, bool yetkiKontrol = true);
        ListResponse<GNTHRK> Cch_GetListByTipKod(Global global, string tipKod, bool yetkiKontrol = true);
        ListResponse<GNTHRK> Cch_GetListByTeknad(Global global, string teknad, bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> Cch_TipHareketListGetir(Global global, string tipKod, bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> Cch_TipHareketListByUstTip(Global global, string ustTipKod, int? parentId, bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> Cch_TipHareketListByUstTipAltTip(Global global, string ustTipKod, string tipkod, int? parentId, bool yetkiKontrol = true);
        StandardResponse<GNTHRK> Cch_GetAltTipByTipKodAndHarKod(Global global, string tipKod, string harKod, bool yetkiKontrol = true);
        ListResponse<TipHareketListModel> Ncch_GetThrkByMultiTeknad_NLog(Global global, List<string> teknads, bool yetkiKontrol = true, string dilKod = "");

        #endregion ClientFunc
    }
}
