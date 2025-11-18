using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.FY
{
    public interface IFyshopifyoptionService
    {
        ListResponse<FYShopifyOption> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyOption> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyOption> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyOption> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyOption> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<FYShopifyOption> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<FYShopifyOption> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<FYShopifyOption> Ncch_Add_NLog(FYShopifyOption fyshopifyoption, Global global);
        StandardResponse<FYShopifyOption> Ncch_Update_Log(FYShopifyOption fyshopifyoption,FYShopifyOption oldFyshopifyoption, Global global);
        StandardResponse<FYShopifyOption> Ncch_UpdateAktifPasif_Log(FYShopifyOption fyshopifyoption, Global global);
        StandardResponse<FYShopifyOption> Ncch_Delete_Log(FYShopifyOption fyshopifyoption, Global global);

        #region ClientFunc

        #endregion ClientFunc
    }
}
