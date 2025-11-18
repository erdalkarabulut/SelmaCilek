using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.FY
{
    public interface IFyshopifyimageService
    {
        ListResponse<FYShopifyImage> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyImage> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyImage> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyImage> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<FYShopifyImage> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<FYShopifyImage> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<FYShopifyImage> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<FYShopifyImage> Ncch_Add_NLog(FYShopifyImage fyshopifyimage, Global global);
        StandardResponse<FYShopifyImage> Ncch_Update_Log(FYShopifyImage fyshopifyimage,FYShopifyImage oldFyshopifyimage, Global global);
        StandardResponse<FYShopifyImage> Ncch_UpdateAktifPasif_Log(FYShopifyImage fyshopifyimage, Global global);
        StandardResponse<FYShopifyImage> Ncch_Delete_Log(FYShopifyImage fyshopifyimage, Global global);

        #region ClientFunc
        StandardResponse Ncch_MultiDelete_Log(List<FYShopifyImage> fyshopifyimage, Global global);
        StandardResponse Ncch_MultiAdd_Log(List<FYShopifyImage> fyshopifyimage, Global global);
        ListResponse<FYShopifyImage> Cch_GetListCid_NLog(string cid, Global global, bool yetkiKontrol = true);
        #endregion ClientFunc
    }
}
