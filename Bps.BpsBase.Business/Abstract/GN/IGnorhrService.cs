using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnorhrService
    {
        ListResponse<GNORHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNORHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNORHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNORHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNORHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNORHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNORHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNORHR> Ncch_Add_NLog(GNORHR gnorhr, Global global);
        StandardResponse<GNORHR> Ncch_Update_Log(GNORHR gnorhr,GNORHR oldGnorhr, Global global);
        StandardResponse<GNORHR> Ncch_UpdateAktifPasif_Log(GNORHR gnorhr, Global global);
        StandardResponse<GNORHR> Ncch_Delete_Log(GNORHR gnorhr, Global global);

        #region ClientFunc
        ListResponse<GNORHR> Cch_GetListOnay_NLog(string orgKod, string tablnm, int tabid, Global global, bool yetkiKontrol = true);
        StandardResponse<GNORHR> Ncch_UpdateOnay_Log(GNORHR gnorhr, GNORHR oldGnorhr, Global global, bool _onay);
        #endregion ClientFunc
    }
}
