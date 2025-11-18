using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.FY
{
    public interface IFyshopifyvariantService
    {
        ListResponse<FYShopifyVariant> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyVariant> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyVariant> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyVariant> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyVariant> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<FYShopifyVariant> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<FYShopifyVariant> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<FYShopifyVariant> Ncch_Add_NLog(FYShopifyVariant fyshopifyvariant, Global global);
        StandardResponse<FYShopifyVariant> Ncch_Update_Log(FYShopifyVariant fyshopifyvariant,FYShopifyVariant oldFyshopifyvariant, Global global);
        StandardResponse<FYShopifyVariant> Ncch_UpdateAktifPasif_Log(FYShopifyVariant fyshopifyvariant, Global global);
        StandardResponse<FYShopifyVariant> Ncch_Delete_Log(FYShopifyVariant fyshopifyvariant, Global global);

        #region ClientFunc
        StandardResponse Ncch_MultiAdd_Log(List<FYShopifyVariant> fyshopifyvariant, Global global);

        StandardResponse Ncch_MultiDelete_Log(List<FYShopifyVariant> fyshopifyvariant, Global global);
        StandardResponse<DateTime> Ncch_Get_Max_UpdateTime_NLog(Global global, string crkodu, bool yetkiKontrol = false);
        StandardResponse<FYShopifyVariant> Cch_GetByCId_NLog(string cid, Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyVariant> NCch_GetList_CrKodu_NLog(Global global, string crkodu, bool yetkiKontrol = true);
        ListResponse<FYShopifyVariant> NCch_GetList_Product_NLog(Global global, string product, string crkodu, bool yetkiKontrol = true);
        ListResponse<FYShopifyVariant> Cch_GetListCid_NLog(string cid, Global global, bool yetkiKontrol = true);
        #endregion ClientFunc
    }
}
