using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.FY;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.DataAccess.Abstract.FY;
using Bps.BpsBase.Entities.Concrete.FY;
using Bps.BpsBase.Entities.Models.FY.Listed;
using Bps.BpsBase.Entities.Models.Shopify.Siparis;
using Bps.BpsBase.Entities.Models.Shopify.Stok;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Business.Concrete.Managers.XX
{
    public class ShopifyManager : IShopifyService
    {

        private IGnService _gnService;
        private ILockedService _lockedService;
        private IFyshopifyproductService _fyshopifyproductService;
        private IFyshopifyimageService _fyshopifyimageService;
        private IFyshopifyvariantService _fyshopifyvariantService;
        private IFyshopifyoptionService _fyshopifyoptionService;
        private IFyshopifyorderService _fyshopifyorderService;
        private IStkartService _stkartService;
        private IStbdrnService _stbdrnService;
        private IStcrkdService _stcrkdService;
        public ShopifyManager(IGnService gnService, ILockedService lockedService,
            IFyshopifyproductService fyshopifyproductService, IFyshopifyvariantService fyshopifyvariantService, IFyshopifyimageService fyshopifyimageService
            , IStkartService stkartService, IStbdrnService stbdrnService, IStcrkdService stcrkdService, IFyshopifyorderService fyshopifyorderService)
        {

            _gnService = gnService;
            _lockedService = lockedService;
            _fyshopifyproductService = fyshopifyproductService;
            _fyshopifyvariantService = fyshopifyvariantService;
            _fyshopifyimageService = fyshopifyimageService;
            _stkartService = stkartService;
            _stbdrnService = stbdrnService;
            _stcrkdService = stcrkdService;
            _fyshopifyorderService = fyshopifyorderService;

        }
        static string GetNextPageUrl(string linkHeader)
        {
            var links = linkHeader.Split(',');
            foreach (var link in links)
            {
                if (link.Contains("rel=\"next\""))
                {
                    var startIndex = link.IndexOf('<') + 1;
                    var endIndex = link.IndexOf('>');
                    return link.Substring(startIndex, endIndex - startIndex);
                }
            }
            return null;
        }

        public async Task<dynamic> Ncch_Get_Shopify_LogAsync(Global global, DateTime tarih, bool yetkiKontrol = false, string ShopifyJson = "products", string ekstring = null)
        {
            string shopName = "";
            string apiKey = "";
            string apiPassword = "";
            if (global.shopName == null)
            {
                shopName = "en-selmacilek";
                apiKey = "730716e6167d671e42c66ead1cc72639";
                apiPassword = "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";
            }
            else
            {
                shopName = global.shopName;
                apiKey = global.apiKey;
                apiPassword = global.apiPassword;
            }


            string baseUrl = $"https://{shopName}.myshopify.com/admin/api/2024-01/{ShopifyJson}.json?updated_at_min={tarih}&limit=250" + ekstring;

            var client = new RestClient(baseUrl);
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{apiPassword}"));

            var allProducts = new List<dynamic>();
            string nextPageUrl = null;

            try
            {
                do
                {

                    var request = new RestRequest(nextPageUrl ?? baseUrl, Method.Get);
                    request.AddHeader("Authorization", $"Basic {credentials}");

                    var response = await client.ExecuteAsync(request);
                    if (!response.IsSuccessful)
                    {
                        Console.WriteLine($"Hata: {response.StatusCode} - {response.ErrorMessage}");
                        break;
                    }

                    var responseJson = JsonConvert.DeserializeObject<dynamic>(response.Content);
                    var products = JsonConvert.DeserializeObject<dynamic>(responseJson[$"{ShopifyJson}"].ToString());
                    allProducts.AddRange(products);

                    var linkHeader = response.Headers.FirstOrDefault(h => h.Name == "link");
                    if (linkHeader != null)
                    {
                        nextPageUrl = GetNextPageUrl(linkHeader.Value.ToString());
                    }
                    else
                    {
                        nextPageUrl = null;
                    }

                } while (!string.IsNullOrEmpty(nextPageUrl));
                return allProducts;

            }
            catch (Exception ex)
            {
                return null;

            }

        }

        public StandardResponse<List<ShopifyProduct>> Ncch_Save_Product_Shopify_Log(Global global, bool yetkiKontrol = false)
        {
            string crkodu = "";
            if (global.shopName == "selmacilek")
            {
                crkodu = "FY0000001";
            }
            else
            {
                crkodu = "FY0000001";

            }

            DateTime tarih = _fyshopifyproductService.Ncch_Get_Max_UpdateTime_NLog(global,crkodu).Nesne.AddSeconds(1);
            DateTime utcTime = tarih.ToUniversalTime();
            List<ShopifyProduct> _product = new List<ShopifyProduct>();
            var sonuc = new StandardResponse<List<ShopifyProduct>>();
            var sonucCid = new StandardResponse<FYShopifyProduct>();
            var sonucProduct = new StandardResponse<FYShopifyProduct>();
            var products1 = Task.Run(() => Ncch_Get_Shopify_LogAsync(global, utcTime, false, "products", "&status=active")).Result;
            string jsonString = JsonConvert.SerializeObject(products1);
            FYShopifyProduct fYShopifyProduct = new FYShopifyProduct();
            List<ShopifyProduct> products = JsonConvert.DeserializeObject<List<ShopifyProduct>>(jsonString);

            foreach (var product in products.OrderBy(v => v.updated_at).ToList())
            {
                //ShopifyProduct product = JsonConvert.DeserializeObject<ShopifyProduct>(product1.ToString()) ;
                //_product.Add(product);
                fYShopifyProduct.Cid = product.Cid;
                fYShopifyProduct.title = product.title;
                fYShopifyProduct.body_html = product.body_html;
                fYShopifyProduct.vendor = product.vendor;
                fYShopifyProduct.product_type = product.product_type;
                fYShopifyProduct.created_at = product.created_at;
                fYShopifyProduct.handle = product.handle;
                fYShopifyProduct.updated_at = product.updated_at;
                fYShopifyProduct.published_at = product.published_at;
                fYShopifyProduct.template_suffix = product.template_suffix;
                fYShopifyProduct.published_scope = product.published_scope;
                fYShopifyProduct.tags = product.tags;
                fYShopifyProduct.status = product.status;
                fYShopifyProduct.admin_graphql_api_id = product.admin_graphql_api_id;
                fYShopifyProduct.ACTIVE = true;

                fYShopifyProduct.CRKODU = crkodu;




                sonucCid = _fyshopifyproductService.Cch_GetByCId_NLog(product.Cid, global, false);
                if (sonucCid.Nesne != null)
                {
                    fYShopifyProduct.Id = sonucCid.Nesne.Id;
                    fYShopifyProduct.EKKULL = sonucCid.Nesne.EKKULL;
                    fYShopifyProduct.ETARIH = sonucCid.Nesne.ETARIH;
                    sonucProduct = _fyshopifyproductService.Ncch_Update_Log(fYShopifyProduct, sonucCid.Nesne, global);
                }
                else
                {

                    sonucProduct = _fyshopifyproductService.Ncch_Add_NLog(fYShopifyProduct, global);

                }


                if (sonucProduct.Status == ResponseStatusEnum.OK)
                {
                    //var sonucvariant = _fyshopifyvariantService.Ncch_MultiAdd_Log(product.variants.Where(x=>x.updated_at>=tarih).ToList() , global);
                    var sonucsilinecek = _fyshopifyimageService.Cch_GetListCid_NLog(product.Cid, global, false);
                    var sonucsilindi = _fyshopifyimageService.Ncch_MultiDelete_Log(sonucsilinecek.Items, global);
                    var sonucimage = _fyshopifyimageService.Ncch_MultiAdd_Log(product.images, global);

                    var sonucsilinecekv = _fyshopifyvariantService.Cch_GetListCid_NLog(product.Cid, global, false);
                    var sonucsilindiv = _fyshopifyvariantService.Ncch_MultiDelete_Log(sonucsilinecekv.Items, global);
                    var sonucVariant = _fyshopifyvariantService.Ncch_MultiAdd_Log(product.variants, global);
                }
                else
                {
                    sonuc.Status = ResponseStatusEnum.ERROR;
                    return sonuc;
                }
            }
            sonuc.Nesne = products;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public StandardResponse<List<FYShopifyVariant>> Ncch_Save_Variants_Shopify_Log(Global global, bool yetkiKontrol = false)
        {
            string crkodu = "";
            if (global.shopName == "selmacilek")
            {
                crkodu = "FY0000001";
            }
            else
            {
                crkodu = " ";

            }

            DateTime tarih = _fyshopifyvariantService.Ncch_Get_Max_UpdateTime_NLog(global, crkodu).Nesne.AddSeconds(1);
            DateTime utcTime = tarih.ToUniversalTime();
            List<FYShopifyVariant> _product = new List<FYShopifyVariant>();
            var sonuc = new StandardResponse<List<FYShopifyVariant>>();
            var sonucCid = new StandardResponse<FYShopifyVariant>();
            var sonucProduct = new StandardResponse<FYShopifyVariant>();
            var products1 = Task.Run(() => Ncch_Get_Shopify_LogAsync(global, utcTime, false, "variants")).Result;
            string jsonString = JsonConvert.SerializeObject(products1);
            FYShopifyVariant fYShopifyProduct = new FYShopifyVariant();
            List<FYShopifyVariant> products = JsonConvert.DeserializeObject<List<FYShopifyVariant>>(jsonString);

            foreach (var product in products.Where(x => x.updated_at > tarih).OrderBy(v => v.updated_at).ToList())
            {
                fYShopifyProduct.Cid = product.Cid;
                fYShopifyProduct.product_id = product.product_id;
                fYShopifyProduct.title = product.title;
                fYShopifyProduct.price = product.price;
                fYShopifyProduct.position = product.position;
                fYShopifyProduct.inventory_policy = product.inventory_policy;
                fYShopifyProduct.compare_at_price = product.compare_at_price;
                fYShopifyProduct.option1 = product.option1;
                fYShopifyProduct.option2 = product.option2;
                fYShopifyProduct.option3 = product.option3;
                fYShopifyProduct.created_at = product.created_at;
                fYShopifyProduct.updated_at = product.updated_at;
                fYShopifyProduct.taxable = product.taxable;
                fYShopifyProduct.barcode = product.barcode;
                fYShopifyProduct.fulfillment_service = product.fulfillment_service;
                fYShopifyProduct.grams = product.grams;
                fYShopifyProduct.inventory_management = product.inventory_management;
                fYShopifyProduct.requires_shipping = product.requires_shipping;
                fYShopifyProduct.sku = product.sku;
                fYShopifyProduct.weight = product.weight;
                fYShopifyProduct.weight_unit = product.weight_unit;
                fYShopifyProduct.inventory_item_id = product.inventory_item_id;
                fYShopifyProduct.inventory_quantity = product.inventory_quantity;
                fYShopifyProduct.old_inventory_quantity = product.old_inventory_quantity;
                fYShopifyProduct.admin_graphql_api_id = product.admin_graphql_api_id;
                fYShopifyProduct.image_id = product.image_id;
                fYShopifyProduct.ACTIVE = true;
                fYShopifyProduct.CRKODU = crkodu;

                sonucCid = _fyshopifyvariantService.Cch_GetByCId_NLog(product.Cid, global, false);
                if (sonucCid.Nesne != null)
                {
                    fYShopifyProduct.Id = sonucCid.Nesne.Id;
                    fYShopifyProduct.EKKULL = sonucCid.Nesne.EKKULL;
                    fYShopifyProduct.ETARIH = sonucCid.Nesne.ETARIH;
                    sonucProduct = _fyshopifyvariantService.Ncch_Update_Log(fYShopifyProduct, sonucCid.Nesne, global);
                }
                else
                {

                    sonucProduct = _fyshopifyvariantService.Ncch_Add_NLog(product, global);

                }


                //if (sonucProduct.Status == ResponseStatusEnum.OK)
                //{
                //	//var sonucvariant = _fyshopifyvariantService.Ncch_MultiAdd_Log(product.variants.Where(x=>x.updated_at>=tarih).ToList() , global);
                //	//var sonucsilinecek = _fyshopifyimageService.Cch_GetListCid_NLog(product.Cid, global, false);
                //	//var sonucsilindi = _fyshopifyimageService.Ncch_MultiDelete_Log(sonucsilinecek.Items, global);
                //	//var sonucimage = _fyshopifyimageService.Ncch_MultiAdd_Log(product.images, global);
                //}
                //else
                //{
                //	sonuc.Status = ResponseStatusEnum.ERROR;
                //	return sonuc;
                //}
            }
            sonuc.Nesne = products;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public ListResponse<FYStKartListMatch> Ncch_ListFYStKartListMatch_NLog(Global global, string _crKodu, bool yetkiKontrol = false)
        {
            var stkoduList = _stkartService.Cch_GetListByMalTur_NLog(global, "01", false).Items;

            var sonuc = new ListResponse<FYStKartListMatch>();
            var copylist = new List<FYStKartListMatch>();
            foreach (var stokitem in stkoduList)
            {
                FYStKartListMatch stKartListMatch = new FYStKartListMatch();
                stKartListMatch.Id = stokitem.Id;
                stKartListMatch.SIRKID = (int)global.SirketId;
                stKartListMatch.STMLTR = stokitem.STMLTR;
                stKartListMatch.STKODU = stokitem.STKODU;
                stKartListMatch.STKNAM = stokitem.STKNAM;
                var stbdrnList = _stbdrnService.Cch_GetListByStokKodu_NLog(stokitem.STKODU, global, false).Items;
                stKartListMatch.VRYSAY = stbdrnList.Count;
                copylist.Add(stKartListMatch);
            }

            sonuc.Items = copylist;
            sonuc.Status = ResponseStatusEnum.OK; ;
            return sonuc;
        }
        public ListResponse<FyProductListMatch> Ncch_ListProductListMatch_NLog(Global global, string _crKodu, bool yetkiKontrol = false)
        {
            var productList = _fyshopifyproductService.NCch_GetList_CrKodu_NLog(global, _crKodu, false).Items;

            var sonuc = new ListResponse<FyProductListMatch>();
            var copylist = new List<FyProductListMatch>();
            foreach (var stokitem in productList)
            {
                FyProductListMatch productListMatch = new FyProductListMatch();
                productListMatch.Id = stokitem.Id;
                productListMatch.SIRKID = (int)global.SirketId;
                productListMatch.Cid = stokitem.Cid;
                productListMatch.title = stokitem.title;

                var variantList = _fyshopifyvariantService.NCch_GetList_Product_NLog(global, stokitem.Cid, _crKodu, false).Items;
                productListMatch.VRYSAY = variantList.Count;
                copylist.Add(productListMatch);
            }

            sonuc.Items = copylist;
            sonuc.Status = ResponseStatusEnum.OK; ;
            return sonuc;
        }
        public ListResponse<FYStBdrnListMatch> Ncch_ListStbdrnListMatchByStokkodu_NLog(Global global, string stokkodu, bool yetkiKontrol = false)
        {
            var variantList = _stbdrnService.Cch_GetListModelByStok_NLog(stokkodu, global, false).Items;

            var sonuc = new ListResponse<FYStBdrnListMatch>();
            var copylist = new List<FYStBdrnListMatch>();
            foreach (var stokitem in variantList)
            {
                FYStBdrnListMatch variantListMatch = new FYStBdrnListMatch();
                variantListMatch.Id = stokitem.Id;
                variantListMatch.SIRKID = (int)global.SirketId;
                variantListMatch.VRKODU = stokitem.VRKODU;
                variantListMatch.VRYTNM = stokitem.VRYTNM;
                variantListMatch.RENKKD = stokitem.RENKKD;
                variantListMatch.RENKTN = stokitem.RENKTN;
                variantListMatch.BEDNKD = stokitem.BEDNKD;
                variantListMatch.BEDNTN = stokitem.BEDNTN;
                variantListMatch.DROPKD = stokitem.DROPKD;
                variantListMatch.DROPTN = stokitem.DROPTN;
                variantListMatch.STKODU = stokitem.STKODU;


                copylist.Add(variantListMatch);
            }

            sonuc.Items = copylist;
            sonuc.Status = ResponseStatusEnum.OK; ;
            return sonuc;
        }
        public ListResponse<FYVariantListMatch> Ncch_ListVariantListMatchByStokkodu_NLog(Global global, string stokkodu, string carikodu, bool yetkiKontrol = false)
        {
            var variantList = _fyshopifyvariantService.NCch_GetList_Product_NLog(global, stokkodu, carikodu, false).Items;

            var sonuc = new ListResponse<FYVariantListMatch>();
            var copylist = new List<FYVariantListMatch>();
            foreach (var stokitem in variantList)
            {
                var _stcrkd = _stcrkdService.Ncch_GetByCRVRKO_NLog(stokitem.Cid, carikodu, global, false);
                if (_stcrkd.Nesne == null)
                {
                    FYVariantListMatch variantListMatch = new FYVariantListMatch();
                    variantListMatch.Id = stokitem.Id;
                    variantListMatch.SIRKID = (int)global.SirketId;
                    variantListMatch.Cid = stokitem.Cid;
                    variantListMatch.product_id = stokitem.product_id;
                    variantListMatch.title = stokitem.title;
                    variantListMatch.VMATCH = false;


                    //var variantList = _fyshopifyvariantService.NCch_GetList_CrKodu_NLog( global,_crKodu, false).Items;
                    //productListMatch.VRYSAY = variantList.Where(x=>x.Cid == stokitem.Cid).ToList().Count;
                    copylist.Add(variantListMatch);
                }

            }

            sonuc.Items = copylist;
            sonuc.Status = ResponseStatusEnum.OK; ;
            return sonuc;
        }

        public StandardResponse<List<FYShopifyOrder>> Ncch_Save_Order_Shopify_Log(Global global, bool yetkiKontrol = false,string ekler = "&status=any")
        {

            string crkodu = "";
            if (global.shopName == "selmacilek")
            {
                crkodu = "FY0000001";
            }
            else
            {
                crkodu = "FY0000002";

            }

            DateTime tarih = _fyshopifyorderService.Ncch_Get_Max_UpdateTime_NLog(global, crkodu).Nesne.AddSeconds(1);
            DateTime utcTime = tarih.ToUniversalTime();
            List<FYShopifyOrder> _product = new List<FYShopifyOrder>();
            var sonuc = new StandardResponse<List<FYShopifyOrder>>();
            var sonucCid = new FYShopifyOrder();
            var sonucProduct = new StandardResponse<FYShopifyOrder>();
            var products1 = Task.Run(() => Ncch_Get_Shopify_LogAsync(global, utcTime, false, "orders", $"{ekler}")).Result;
            string jsonString = JsonConvert.SerializeObject(products1);
            FYShopifyOrder fYShopifyProduct = new FYShopifyOrder();
            List<ShopifyOrder> products = JsonConvert.DeserializeObject<List<ShopifyOrder>>(jsonString);

            foreach (var product in products.OrderBy(v => v.UpdatedAt).ToList())
            {
                
                
                //ShopifyProduct product = JsonConvert.DeserializeObject<ShopifyProduct>(product1.ToString()) ;
                //_product.Add(product);
                fYShopifyProduct.Cid = product.Id.ToString();
                fYShopifyProduct.SName = product.Name;
                fYShopifyProduct.CreatedAt = product.CreatedAt;
                fYShopifyProduct.Updated_at = product.UpdatedAt;
                fYShopifyProduct.CustomerId = product.Customer.Id.ToString();
                fYShopifyProduct.CustomerName = product.Customer.FirstName + " " + product.Customer.LastName;
                fYShopifyProduct.Source = product.ShippingLines[0].Source;
                fYShopifyProduct.FinancialStatus = product.FinancialStatus;
                fYShopifyProduct.order_status_url = product.OrderStatusUrl;
                fYShopifyProduct.fulfillment_status = product.FulfillmentStatus;
                fYShopifyProduct.Stocks = product.LineItems.Count.ToString() + " Ürün";
                if (product.Fulfillments.Count > 0)
                {
                    fYShopifyProduct.shipment_status = product.Fulfillments[0].ShipmentStatus;
                }
                else
                {
                    fYShopifyProduct.shipment_status = "";
                }

                fYShopifyProduct.shipping_code = product.ShippingLines[0].Code;
                //fYShopifyProduct.admin_graphql_api_id = product.admin_graphql_api_id;
                fYShopifyProduct.ACTIVE = true;

                fYShopifyProduct.CRKODU = crkodu;
                fYShopifyProduct.Amount = product.CurrentTotalPriceSet.PresentmentMoney.Amount;
                    fYShopifyProduct.CurrencyCode = product.CurrentTotalPriceSet.PresentmentMoney.CurrencyCode;
                sonucCid = _fyshopifyorderService.Cch_GetByCId_NLog(product.Id.ToString(), global).Nesne;
                if (sonucCid != null)
                {
                    fYShopifyProduct.Id = sonucCid.Id;
                    fYShopifyProduct.EKKULL = sonucCid.EKKULL;
                    fYShopifyProduct.ETARIH = sonucCid.ETARIH;
                    sonucProduct = _fyshopifyorderService.Ncch_Update_Log(fYShopifyProduct, sonucCid, global);
                }
                else { 
                sonucProduct = _fyshopifyorderService.Ncch_Add_NLog(fYShopifyProduct, global);
                }



            }
            sonuc.Nesne = _product;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
    }
}
