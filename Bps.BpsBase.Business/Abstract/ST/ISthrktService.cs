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
    public interface ISthrktService
    {
        ListResponse<STHRKT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STHRKT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STHRKT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STHRKT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STHRKT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STHRKT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STHRKT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STHRKT> Ncch_Add_NLog(STHRKT sthrkt, Global global);
        StandardResponse<STHRKT> Ncch_Update_Log(STHRKT sthrkt,STHRKT oldSthrkt, Global global);
        StandardResponse<STHRKT> Ncch_UpdateAktifPasif_Log(STHRKT sthrkt, Global global);
        StandardResponse<STHRKT> Ncch_Delete_Log(STHRKT sthrkt, Global global);

        #region ClientFunc

        ListResponse<STHRKT> Cch_GetListBaslikByFisTip_NLog(Global global, int? fisTip, bool yetkiKontrol = true);
        ListResponse<STHRKT> Ncch_GetListKalemByFisTip_NLog(Global global, int? fisTip, bool yetkiKontrol = true);
        ListResponse<STHRKT> Ncch_GetListKalemByBelgeNo_NLog(Global global, string belgeNo, bool yetkiKontrol = true);
        ListResponse<SthrktStokHareketModel> GetStokHareketRapor(DateTime date1, DateTime date2, Global global,
	        bool yetkiKontrol = true);
        ListResponse<SthrktMiktarByPartiModel> GetStokMiktarFromHareketByParti(Global global, string whereFilter = "", bool yetkiKontrol = true);
        ListResponse<STHRKT> Ncch_GetListKalemByUstBelgeNo_NLog(Global global, string ustBelgeNo,  bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
