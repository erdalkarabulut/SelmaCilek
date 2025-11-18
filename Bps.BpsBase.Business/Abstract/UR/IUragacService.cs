using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.UR;

#region ClientUsing

using System.Data;
using Bps.BpsBase.Entities.Models.UA;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.UR
{
    public interface IUragacService
    {
        ListResponse<URAGAC> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URAGAC> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URAGAC> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URAGAC> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URAGAC> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<URAGAC> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<URAGAC> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<URAGAC> Ncch_Add_NLog(URAGAC uragac, Global global);
        StandardResponse<URAGAC> Ncch_Update_Log(URAGAC uragac,URAGAC oldUragac, Global global);
        StandardResponse<URAGAC> Ncch_UpdateAktifPasif_Log(URAGAC uragac, Global global);
        StandardResponse<URAGAC> Ncch_Delete_Log(URAGAC uragac, Global global);

        #region ClientFunc

        ListResponse<UrunAgaciRevizyonList> Ncch_GetMaxRevizyonNo_NLog(string stokKodu, string kullanimKodu, Global global, string _vrkodu = null);
        StandardResponse Ncch_DeleteList_Log(string urunAgaciKodu, Global global);
        ListResponse<URAGAC> Ncch_GetListByUrakod_Log(string urunAgaciKodu, Global global);
        ListResponse<UrunAgaciRevizyonList> Ncch_GetUrunAgaciRevizyonList_Log(string revizyonNo, string stokKodu, Global global);
        ListResponse<UrunAgaciRevizyonList> Ncch_GetUrunAgaciRevizyonList_Log(string revizyonNo, string stokKodu, Global global, string vrkodu);
        ListResponse<UrunAgaciKalemMalzemeJoin> Ncch_GetUAKalemMalzemeJoin_NLog(string uaKodu, Global global);
        ListResponse<UrunAgaciTreeList> Ncch_GetUrunAgaci_NLog(string urunagaciKodu, Global global);
        StandardResponse<string> GetMaxUrunAgaciKodu(string stokKodu, string uaKullanim, Global global);
        DataTable GetAltUrunAgaci(string conStr, string uaKodu, string uaKoduField, string uaKullanim, Global global, bool onlyParts = true, string tableName = "vwRefakatKarti");
        DataTable GetUrunAgaciUpperLevels(string conStr, string stokKodu, string revizyonNo, string malzemeTuru, Global global);
        ListResponse<UrunAgaciModulPaket> Ncch_GetUrunAgaciModulPaketList_NLog(Global global);
        ListResponse<UrunAgaciModulPaketParca> Ncch_GetUrunAgaciModulPaketParcaList_NLog(Global global,
            string modulPrefix = "", string paketKodu = "", string langKd = "EN");
        ListResponse<UrunAgaciUst> Ncch_GetUrunAgaciUst_NLog(Global global, string stkodu, string langKd = "EN");
        ListResponse<UrunAgaciRota> Ncch_GetUrunAgaciRota_NLog(Global global, List<string> stokList = null);
        ListResponse<UrunAgaciList> Ncch_GetUrunAgaciList_NLog(Global global);


        #endregion ClientFunc
    }
}
