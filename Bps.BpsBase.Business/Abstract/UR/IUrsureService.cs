using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.UR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.UR
{
    public interface IUrsureService
    {
        ListResponse<URSURE> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URSURE> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URSURE> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URSURE> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<URSURE> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<URSURE> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<URSURE> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<URSURE> Ncch_Add_NLog(URSURE ursure, Global global);
        StandardResponse<URSURE> Ncch_Update_Log(URSURE ursure,URSURE oldUrsure, Global global);
        StandardResponse<URSURE> Ncch_UpdateAktifPasif_Log(URSURE ursure, Global global);
        StandardResponse<URSURE> Ncch_Delete_Log(URSURE ursure, Global global);

        #region ClientFunc

        ListResponse<URSURE> Ncch_GetUretimSureListByIsplanId_NLog(Global global, int isplanId,
	        bool yetkiKontrol = true);

        ListResponse<URSURE> Ncch_GetUretimAcikSureList_NLog(Global global, bool yetkiKontrol = true);

        ListResponse<URSURE> Ncch_GetUretimSureListByStokKodu_NLog(Global global, string ispkod, string stokKodu,
	        string gnrezv, string urakod, string uryrkd, bool yetkiKontrol = true);

        StandardResponse<URSURE> Ncch_UretimSureKaydet_NLog(URSURE ursure, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
