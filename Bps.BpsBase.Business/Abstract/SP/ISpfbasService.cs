using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.SP.Listed;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISpfbasService
    {
        ListResponse<SPFBAS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFBAS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFBAS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFBAS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFBAS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPFBAS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPFBAS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPFBAS> Ncch_Add_NLog(SPFBAS spfbas, Global global);
        StandardResponse<SPFBAS> Ncch_Update_Log(SPFBAS spfbas,SPFBAS oldSpfbas, Global global);
        StandardResponse<SPFBAS> Ncch_UpdateAktifPasif_Log(SPFBAS spfbas, Global global);
        StandardResponse<SPFBAS> Ncch_Delete_Log(SPFBAS spfbas, Global global);

        #region ClientFunc

        StandardResponse<SPFBAS> Ncch_GetByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true);
        ListResponse<SPFBAS> Cch_GetListByParam_NLog(SiparisParamModel param,Global global, bool yetkiKontrol = true);
        ListResponse<SPFBAS> Ncch_GetActiveTalepList_NLog(int spftno, Global global, bool yetkiKontrol = true);
        ListResponse<SPFBAS> Ncch_GetListByCariByFlag_NLog(string cariKod, int sthrtp, bool flagKapandi, Global global);

        ListResponse<SPFBAS> Ncch_GetListByTesFisTip_NLog(int tesFistip, Global global, bool yetkiKontrol = true);

        ListResponse<T> Ncch_GetSaRaporMasterDetail_NLog<T>(Global global, string basTarih, string bitTarih, bool yetkiKontrol = true);

        ListResponse<T> Ncch_GetTeklifRaporMasterDetail_NLog<T>(Global global, string basTarih, string bitTarih,
            bool yetkiKontrol = true);

        ListResponse<SpBaslikAcikModel> Ncch_GetAcikSiparisList_NLog(Global global, int sphrtp, bool yetkiKontrol = true);

        ListResponse<SpRezervasyonPaket> Ncch_GetRezervasyonPaketList_NLog(string spBelgeNo, Global global,
            bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
