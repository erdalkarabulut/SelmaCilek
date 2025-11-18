using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.FY;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.FY
{
    public interface IFyshopifyorderService
    {
        ListResponse<FYShopifyOrder> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyOrder> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyOrder> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyOrder> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyOrder> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<FYShopifyOrder> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<FYShopifyOrder> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<FYShopifyOrder> Ncch_Add_NLog(FYShopifyOrder fyshopifyorder, Global global);
        StandardResponse<FYShopifyOrder> Ncch_Update_Log(FYShopifyOrder fyshopifyorder,FYShopifyOrder oldFyshopifyorder, Global global);
        StandardResponse<FYShopifyOrder> Ncch_UpdateAktifPasif_Log(FYShopifyOrder fyshopifyorder, Global global);
        StandardResponse<FYShopifyOrder> Ncch_Delete_Log(FYShopifyOrder fyshopifyorder, Global global);


        #region ClientFunc
        StandardResponse Ncch_MultiDelete_Log(List<FYShopifyOrder> fyshopifyorder, Global global);

        StandardResponse Ncch_MultiAdd_Log(List<FYShopifyOrder> fyshopifyorder, Global global);
        StandardResponse<DateTime> Ncch_Get_Max_UpdateTime_NLog(Global global, string crkodu, bool yetkiKontrol = false);
        StandardResponse<FYShopifyOrder> Cch_GetByCId_NLog(string cid, Global global, bool yetkiKontrol = true);
        #endregion ClientFunc
    }
}
