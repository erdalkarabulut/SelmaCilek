using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bps.BpsBase.Entities.Concrete.FY;
using Bps.BpsBase.Entities.Concrete.SH;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.FY.Listed;
using Bps.BpsBase.Entities.Models.Shopify.Stok;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.BpsBase.Entities.Models.TS;
using Bps.BpsBase.Entities.Models.WM.Api;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;

namespace Bps.BpsBase.Business.Abstract.XX
{
    public interface IShopifyService
    {

        Task<dynamic> Ncch_Get_Shopify_LogAsync(Global global, DateTime tarih,  bool yetkiKontrol = false, string ShopifyJson = "products", string ekstring = null);
        ListResponse<FYStKartListMatch> Ncch_ListFYStKartListMatch_NLog(Global global, string _crKodu, bool yetkiKontrol = false);
        ListResponse<FyProductListMatch> Ncch_ListProductListMatch_NLog(Global global, string _crKodu, bool yetkiKontrol = false);
        ListResponse<FYStBdrnListMatch> Ncch_ListStbdrnListMatchByStokkodu_NLog(Global global, string stokkodu, bool yetkiKontrol = false);
        ListResponse<FYVariantListMatch> Ncch_ListVariantListMatchByStokkodu_NLog(Global global, string stokkodu, string carikodu, bool yetkiKontrol = false);
        StandardResponse<List<FYShopifyOrder>> Ncch_Save_Order_Shopify_Log(Global global, bool yetkiKontrol = false, string ekler = "&status=any");
        StandardResponse<List<ShopifyProduct>> Ncch_Save_Product_Shopify_Log(Global global, bool yetkiKontrol = false);
        StandardResponse<List<FYShopifyVariant>> Ncch_Save_Variants_Shopify_Log(Global global, bool yetkiKontrol = false);
    }
}
