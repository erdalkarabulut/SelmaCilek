using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.FY
{
    public interface IFyshopifyproductService
    {
        ListResponse<FYShopifyProduct> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyProduct> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyProduct> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyProduct> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyProduct> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<FYShopifyProduct> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<FYShopifyProduct> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<FYShopifyProduct> Ncch_Add_NLog(FYShopifyProduct fyshopifyproduct, Global global);
        StandardResponse<FYShopifyProduct> Ncch_Update_Log(FYShopifyProduct fyshopifyproduct,FYShopifyProduct oldFyshopifyproduct, Global global);
        StandardResponse<FYShopifyProduct> Ncch_UpdateAktifPasif_Log(FYShopifyProduct fyshopifyproduct, Global global);
        StandardResponse<FYShopifyProduct> Ncch_Delete_Log(FYShopifyProduct fyshopifyproduct, Global global);


        #region ClientFunc
        StandardResponse<DateTime> Ncch_Get_Max_UpdateTime_NLog(Global global, string crkodu, bool yetkiKontrol = false);
        StandardResponse<FYShopifyProduct> Cch_GetByCId_NLog(string cid, Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyProduct> NCch_GetList_CrKodu_NLog(Global global, string crkodu, bool yetkiKontrol = true);
        #endregion ClientFunc
    }
}
