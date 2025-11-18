using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing
using Bps.BpsBase.Entities.Models.ST.Listed;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStdepoService
    {
        ListResponse<STDEPO> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDEPO> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDEPO> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDEPO> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STDEPO> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STDEPO> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STDEPO> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STDEPO> Ncch_Add_NLog(STDEPO stdepo, Global global);
        StandardResponse<STDEPO> Ncch_Update_Log(STDEPO stdepo,STDEPO oldStdepo, Global global);
        StandardResponse<STDEPO> Ncch_UpdateAktifPasif_Log(STDEPO stdepo, Global global);
        StandardResponse<STDEPO> Ncch_Delete_Log(STDEPO stdepo, Global global);

        #region ClientFunc

        ListResponse<STDEPO> Cch_GetByStokKodu_NLog(Global global, string stokKodu, bool yetkiKontrol = true);
        ListResponse<StdepoStokMiktarModel> GetStokMiktarRapor(Global global, string stokKodu = null, string depoKodu = null, bool yetkiKontrol = true);
        ListResponse<StdepoStokMiktarModel> GetStokMiktarRaporWithMipgos(Global global, bool yetkiKontrol = true);
        ListResponse<StdepoStokMiktarModel> GetStokListWithAnaAltGrup(Global global, string stokKodu = null,
            string depoKodu = null, bool yetkiKontrol = true);
        ListResponse<StdepoStokMiktarModel> GetYenidenSiparisSvy(Global global, string stokKodu = null, string depoKodu = null, bool yetkiKontrol = true);
        ListResponse<StdepoStokAdresModel> GetStokAdresRapor(Global global, string adres = null, string stokKodu = null, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
