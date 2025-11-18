using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Params;
using Bps.BpsBase.Entities.Models.GN.Single;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnkullService
    {
        ListResponse<GNKULL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKULL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKULL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKULL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<GNKULL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<GNKULL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<GNKULL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNKULL> Ncch_Add_NLog(GNKULL gnkull, Global global);
        StandardResponse<GNKULL> Ncch_Update_Log(GNKULL gnkull,GNKULL oldGnkull, Global global);
        StandardResponse<GNKULL> Ncch_UpdateAktifPasif_Log(GNKULL gnkull, Global global);
        StandardResponse<GNKULL> Ncch_Delete_Log(GNKULL gnkull, Global global);

        #region ClientFunc

        StandardResponse Ncch_UserLogin_Log(GirisParam girisParam);
        StandardResponse<GNKULL> Ncch_UserLogin_Log(GirisParam girisParam, string platform);
        StandardResponse<GNKULL> UpdateOnlyForLanguage(GNKULL gnkull, Global global);
        StandardResponse<GNKULL> Cch_GetByUserKod_NLog(string kullKod, Global global);
        ListResponse<GNKULL> Ncch_GetListByFilter_NLog(Global global, string prokod, bool yetkiKontrol = true);
        StandardResponse<GNKULL> Ncch_AddWithImage_NLog(GNKULL gnkull, Global global, string imagePath);
        StandardResponse<GNKULL> Ncch_UpdateWithImage_Log(GNKULL ikpers, GNKULL oldGnkull, Global global, string imagePath);
        ListResponse<KullaniciModel> Ncch_GetListPersJoin_NLog(Global global, bool yetkiKontrol = true);
        StandardResponse<GNKULL> SifreKaydet(HesapModel model, Global global);
        StandardResponse<KullaniciModel> Ncch_GetKulPersJoinByFilter_NLog(string filter, Global global, bool yetkiKontrol = true);
        StandardResponse<KullaniciModel> Ncch_GetKulByLoginInfo_NLog(string kulKod, string passWord, Global global);
        ListResponse<GNKULL> Ncch_GetOnlyActiveUsers_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<KullNameSurModel> Ncch_GetOnlyAdSoyad_NLog(Global global, bool yetkiKontrol = true);
        StandardResponse<GNKULL> Ncch_GetByPersId_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<GNKULL> Ncch_ChangePassword_NLog(Global global, GNKULL gnkull);
        ListResponse<KullaniciMinModel> Ncch_GetKullaniciMinData_NLog(Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
