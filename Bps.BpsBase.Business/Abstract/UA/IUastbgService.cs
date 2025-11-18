using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

using Bps.BpsBase.Entities.Models.UA;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.UA
{
    public interface IUastbgService
    {
        ListResponse<UASTBG> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UASTBG> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UASTBG> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UASTBG> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<UASTBG> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<UASTBG> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<UASTBG> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<UASTBG> Ncch_Add_NLog(UASTBG uastbg, Global global);
        StandardResponse<UASTBG> Ncch_Update_Log(UASTBG uastbg,UASTBG oldUastbg, Global global);
        StandardResponse<UASTBG> Ncch_UpdateAktifPasif_Log(UASTBG uastbg, Global global);
        StandardResponse<UASTBG> Ncch_Delete_Log(UASTBG uastbg, Global global);

        #region ClientFunc

        ListResponse<UrunAgaciRevizyonlar> Ncch_GetByStokKoduUaKullanim_NLog(string stokKodu, string uaKullanim, Global global);
        StandardResponse<string> Ncch_GetUrunAgaciKodu_NLog(string stokKodu, string revizyonNo, string uaKullanim, Global global, string vrkodu = null);
        ListResponse<UrunAgaciRevizyonlar> Ncch_GetByStokKoduUaKullanim_NLog(string stokKodu, string uaKullanim, Global global, bool yetkiKontrol = true, string _vrkodu = null);
        #endregion ClientFunc
    }
}
