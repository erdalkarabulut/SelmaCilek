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
    public interface IGntipiService
    {
        ListResponse<GNTIPI> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNTIPI> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNTIPI> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNTIPI> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNTIPI> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNTIPI> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNTIPI> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNTIPI> Ncch_Add_NLog(GNTIPI gntipi, Global global);
        StandardResponse<GNTIPI> Ncch_Update_Log(GNTIPI gntipi,GNTIPI oldGntipi, Global global);
        StandardResponse<GNTIPI> Ncch_UpdateAktifPasif_Log(GNTIPI gntipi, Global global);
        StandardResponse<GNTIPI> Ncch_Delete_Log(GNTIPI gntipi, Global global);

        #region ClientFunc

        ListResponse<TipListModel> TipListGetir(Global global, bool yetkiKontrol = true);
        ListResponse<GNTIPI>Ncch_GetByHareketTable_NLog(Global global, string hrktbl, bool yetkiKontrol = true);
        ListResponse<GNTIPI> Ncch_GetListByUstTipKod_NLog(Global global, string utpkod, bool yetkiKontrol = true);
        StandardResponse<GNTIPI> Ncch_GetByTeknikAd_NLog(Global global, string teknad, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
