using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnkoslService
    {
        ListResponse<GNKOSL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKOSL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKOSL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKOSL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKOSL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNKOSL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNKOSL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNKOSL> Ncch_Add_NLog(GNKOSL gnkosl, Global global);
        StandardResponse<GNKOSL> Ncch_Update_Log(GNKOSL gnkosl,GNKOSL oldGnkosl, Global global);
        StandardResponse<GNKOSL> Ncch_UpdateAktifPasif_Log(GNKOSL gnkosl, Global global);
        StandardResponse<GNKOSL> Ncch_Delete_Log(GNKOSL gnkosl, Global global);

        #region ClientFunc

        ListResponse<GNKOSL> Ncch_GetListByProjeKod_NLog(Global global, string projeKod, bool onlyDefaults = false);
        ListResponse<GNKOSL> Ncch_GetListByProjeKodAndLanguage_NLog(Global global, string projeKod, string langkd,
            bool onlyDefaults = false);

        #endregion ClientFunc
    }
}
