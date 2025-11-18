using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

using Bps.BpsBase.Entities.Models.IS.Listed;
using Bps.BpsBase.Entities.Models.IS.Single;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.IS
{
    public interface IIsplanService
    {
        ListResponse<ISPLAN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISPLAN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISPLAN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISPLAN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<ISPLAN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<ISPLAN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<ISPLAN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<ISPLAN> Ncch_Add_NLog(ISPLAN isplan, Global global);
        StandardResponse<ISPLAN> Ncch_Update_Log(ISPLAN isplan,ISPLAN oldIsplan, Global global);
        StandardResponse<ISPLAN> Ncch_UpdateAktifPasif_Log(ISPLAN isplan, Global global);
        StandardResponse<ISPLAN> Ncch_Delete_Log(ISPLAN isplan, Global global);

		#region ClientFunc

		ListResponse<ISPLAN> Cch_GetListByParam_NLog(IsPlaniParamModel param, Global global, bool yetkiKontrol = true);
		ListResponse<IsplanUrunParcaModel> Ncch_GetIsplanUrunParcaList_NLog(Global global, string planNo = "", bool yetkiKontrol = true);
		ListResponse<IsplanOperasyonModel> Ncch_GetIsplanOperasyonList_NLog(Global global, bool yetkiKontrol = true);
		ListResponse<IsplanOperasyonModel> Ncch_GetIsplanOperasyonDurumList_NLog(Global global, bool yetkiKontrol = true);
		ListResponse<IsplanParcaOperasyonModel> Ncch_GetIsplanParcaOperasyonList_NLog(Global global, string uryrkd, string ispkod, string gnrezv, string urakod, string stkodu, bool yetkiKontrol = true);
		ListResponse<IsyeriOperasyonModel> Ncch_GetIsyeriOperasyonList_NLog(Global global, bool yetkiKontrol = true);
		ListResponse<IsplanBaslikModel> Ncch_GetIsplanBaslikList_NLog(Global global, bool yetkiKontrol = true);
        StandardResponse<ISPLAN> Ncch_UpdatePlan_Log(ISPLAN isplan, Global global);

		#endregion ClientFunc
    }
}
