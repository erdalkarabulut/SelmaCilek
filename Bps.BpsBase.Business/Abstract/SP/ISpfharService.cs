using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.Firestore;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SP
{
    public interface ISpfharService
    {
        ListResponse<SPFHAR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFHAR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFHAR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFHAR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SPFHAR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SPFHAR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SPFHAR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SPFHAR> Ncch_Add_NLog(SPFHAR spfhar, Global global);
        StandardResponse<SPFHAR> Ncch_Update_Log(SPFHAR spfhar,SPFHAR oldSpfhar, Global global);
        StandardResponse<SPFHAR> Ncch_UpdateAktifPasif_Log(SPFHAR spfhar, Global global);
        StandardResponse<SPFHAR> Ncch_Delete_Log(SPFHAR spfhar, Global global);

        #region ClientFunc

        ListResponse<SPFHAR> Cch_GetListByBelge_NLog(string belgeNo, Global global);
        ListResponse<SaKalemFiyat> Ncch_GetSatinalmaSonFiyat_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SaAcikSiparisMiktar> Ncch_GetAcikSaSiparisAndTalepMiktar_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SiparisPaketIhtiyac> Ncch_GetSiparisPaketIhtiyacList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<Product> Ncch_GetProformaProducts_NLog(string belgeNo, Global global, bool yetkiKontrol = false);

        #endregion ClientFunc
    }
}
