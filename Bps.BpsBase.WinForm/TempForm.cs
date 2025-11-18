using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.FY;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.FY;
using Bps.BpsBase.Entities.Models.Shopify.Siparis;
using Bps.BpsBase.Entities.Models.Shopify.Stok;
using Bps.Core.GlobalStaticsVariables;
using Newtonsoft.Json;
using RestSharp;

namespace BPS.Windows.Forms
{
    public partial class TempForm : Base.FrmChildBase
    {
        private IShopifyService _shopifyService;
        private ICrcariService _cariKartService;
        private ICradrsService _cradrsService;
        private ICrytklService _crytklService;
        private IFyshopifyorderService _fyshopifyorderService;
        public CRCARI crcari = new CRCARI();
        public CRADRS crcadrs = new CRADRS();
        public CRYTKL crytkl = new CRYTKL();
        private Global _global;
        public string carkodu = "";
        public List<ShopifyOrder> products;
        public TempForm(Global global)
        {
            _shopifyService = InstanceFactory.GetInstance<IShopifyService>();
            _cradrsService = InstanceFactory.GetInstance<ICradrsService>();
            _crytklService = InstanceFactory.GetInstance<ICrytklService>();
            _cariKartService = InstanceFactory.GetInstance<ICrcariService>();
            _fyshopifyorderService = InstanceFactory.GetInstance<IFyshopifyorderService>();
            _global = global;
            InitializeComponent();
        }

        private void TempForm_Load(object sender, EventArgs e)
        {
            //string filePath = "D:\\products.json";

            //try
            //{
            //	string jsonContent = File.ReadAllText(filePath);
            //	List<ShopifyProduct> products = JsonConvert.DeserializeObject<List<ShopifyProduct>>(jsonContent);
            //	gridControl1.DataSource = products;
            //}
            //catch (Exception ex)
            //{
            //	Console.WriteLine($"Error reading JSON file: {ex.Message}");
            //}

            //// URL of the API endpoint
            //string url = "https://1d7ae30f26554e23188c957c829197c8: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@selmacilek.myshopify.com/admin/api/2024-01/products.json";

            //// Create an HttpClient instance
            //using (HttpClient client = new HttpClient())
            //{
            //	try
            //	{

            //		   // Send GET request
            //		   HttpResponseMessage response = await client.GetAsync(url);

            //		// Ensure the response status code is successful
            //		response.EnsureSuccessStatusCode();

            //		// Read response content as string
            //		string jsonResponse = await response.Content.ReadAsStringAsync();

            //		// Deserialize JSON to an object (if needed)
            //		var result = JsonConvert.DeserializeObject(jsonResponse);

            //		// Print the result
            //		Console.WriteLine("JSON Response:");
            //		Console.WriteLine(jsonResponse);

            //		Console.WriteLine("\nDeserialized Object:");
            //		Console.WriteLine(JsonConvert.SerializeObject(result, Formatting.Indented));
            //	}
            //	catch (HttpRequestException ex)
            //	{
            //		Console.WriteLine($"Request error: {ex.Message}");
            //	}
            //}
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            //string shopName = "selmacilek"; // Shopify mağaza adı
            //string apiKey = "1d7ae30f26554e23188c957c829197c8"; // Shopify API anahtarı
            //string apiPassword = "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"; // Shopify API parolası
            string shopName = ConfigurationManager.AppSettings["shopName"]; // Shopify mağaza adı
            string apiKey = ConfigurationManager.AppSettings["apiKey"]; // Shopify API anahtarı
            string apiPassword = ConfigurationManager.AppSettings["apiPassword"]; // Shopify API parolası
            string baseUrl = $"https://{shopName}.myshopify.com/admin/api/2023-10/products.json?limit=20";

            var client = new RestClient(baseUrl);
            //client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(apiKey, apiPassword);
            string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{apiPassword}"));


            List<ShopifyProduct> allProducts = new List<ShopifyProduct>();
            string nextPageUrl = null;

            try
            {
                do
                {
                    // İlk isteği oluştur veya bir sonraki sayfa URL'sini kullan
                    var request = new RestRequest(nextPageUrl ?? baseUrl, Method.Get);
                    request.AddHeader("Authorization", $"Basic {credentials}");
                    // İsteği gönder
                    var response = await client.ExecuteAsync(request);
                    if (!response.IsSuccessful)
                    {
                        Console.WriteLine($"Hata: {response.StatusCode} - {response.ErrorMessage}");
                        break;
                    }

                    // JSON verisini deserialize et
                    var responseJson = JsonConvert.DeserializeObject<dynamic>(response.Content);
                    var products = JsonConvert.DeserializeObject<List<ShopifyProduct>>(responseJson.products.ToString());
                    allProducts.AddRange(products);

                    // Link başlığından bir sonraki sayfa URL'sini al
                    var linkHeader = response.Headers.FirstOrDefault(h => h.Name == "link");
                    if (linkHeader != null)
                    {
                        nextPageUrl = GetNextPageUrl(linkHeader.Value.ToString());
                    }
                    else
                    {
                        nextPageUrl = null; // Daha fazla sayfa yok
                    }

                } while (!string.IsNullOrEmpty(nextPageUrl));
                gridControl1.DataSource = allProducts;
                MessageBox.Show($"Toplam Ürün Sayısı: {allProducts.Count}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hata: {ex.Message}");
            }
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
                    return link.Substring(startIndex, endIndex - startIndex);  // C# 7.3 uyumu için Substring kullanılıyor
                }
            }
            return null;
        }

        private void button2_Click(object sender, EventArgs e)

        {
            var shopname = _global.shopName;
            var products = _shopifyService.Ncch_Save_Product_Shopify_Log(_global);
            //var variants = _shopifyService.Ncch_Save_Variants_Shopify_Log(_global);
            //_global.shopName = null;
            //var productsen = _shopifyService.Ncch_Save_Product_Shopify_Log(_global);
            ////var variantsen = _shopifyService.Ncch_Save_Variants_Shopify_Log(_global);
            _global.shopName = shopname;

            MessageBox.Show("İşlem Tamamlandı");
            //gridControl1.DataSource = products.Nesne;
        }

        private async void button3_Click(object sender, EventArgs e)

        {
            var crkodu = _global.shopName;
            var products = _shopifyService.Ncch_Save_Order_Shopify_Log(_global);
            _global.shopName = null;
            var productsen = _shopifyService.Ncch_Save_Order_Shopify_Log(_global);
            _global.shopName = crkodu;

            fYShopifyOrderBindingSource.DataSource = _fyshopifyorderService.Cch_GetList_NLog(_global).Items;
            ////string shopName = "selmacilek"; // Shopify mağaza adı
            ////string apiKey = "1d7ae30f26554e23188c957c829197c8"; // Shopify API anahtarı
            ////string apiPassword = "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"; // Shopify API parolası
            //string shopName = ConfigurationManager.AppSettings["shopName"]; // Shopify mağaza adı
            //string apiKey = ConfigurationManager.AppSettings["apiKey"]; // Shopify API anahtarı
            //string apiPassword = ConfigurationManager.AppSettings["apiPassword"]; // Shopify API parolası
            //string baseUrl = $"https://{shopName}.myshopify.com/admin/api/2024-01/orders.json?limit=20&fulfillment_status=unshipped";

            //var client = new RestClient(baseUrl);
            ////client.Authenticator = new RestSharp.Authenticators.HttpBasicAuthenticator(apiKey, apiPassword);
            //string credentials = Convert.ToBase64String(Encoding.ASCII.GetBytes($"{apiKey}:{apiPassword}"));


            //List<ShopifyOrder> allProducts = new List<ShopifyOrder>();
            //string nextPageUrl = null;

            //try
            //{
            //    do
            //    {
            //        // İlk isteği oluştur veya bir sonraki sayfa URL'sini kullan
            //        var request = new RestRequest(nextPageUrl ?? baseUrl, Method.Get);
            //        request.AddHeader("Authorization", $"Basic {credentials}");
            //        // İsteği gönder
            //        var response = await client.ExecuteAsync(request);
            //        if (!response.IsSuccessful)
            //        {
            //            Console.WriteLine($"Hata: {response.StatusCode} - {response.ErrorMessage}");
            //            break;
            //        }

            //        // JSON verisini deserialize et
            //        var responseJson = JsonConvert.DeserializeObject<dynamic>(response.Content);
            //        var products = JsonConvert.DeserializeObject<List<ShopifyOrder>>(responseJson.orders.ToString());
            //        allProducts.AddRange(products);

            //        // Link başlığından bir sonraki sayfa URL'sini al
            //        var linkHeader = response.Headers.FirstOrDefault(h => h.Name == "link");
            //        if (linkHeader != null)
            //        {
            //            nextPageUrl = GetNextPageUrl(linkHeader.Value.ToString());
            //        }
            //        else
            //        {
            //            nextPageUrl = null; // Daha fazla sayfa yok
            //        }

            //    } while (!string.IsNullOrEmpty(nextPageUrl));
            //    orderBindingSource.DataSource = allProducts;
            //    MessageBox.Show($"Toplam Ürün Sayısı: {allProducts.Count}");
            //}
            //catch (Exception ex)
            //{
            //    Console.WriteLine($"Hata: {ex.Message}");
            //}
        }

        private void barButtonItem4_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var shopify = gridView1.GetFocusedDataRow();
        }

        private void siparişAktarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string crkodu = "";
            var baslik = (FYShopifyOrder)fYShopifyOrderBindingSource.Current;
            if (baslik == null)
            {
                return;
            }
            crkodu = _global.shopName;
            if (baslik.CRKODU == "FY0000001")
            {
                carkodu = "FY0000001";
            }
            else
            {
                carkodu = "FY0000002";
                _global.shopName = null;
            }
            DateTime utcTime = Convert.ToDateTime("01.01.2000").ToUniversalTime().Date; ;
            var products1 = Task.Run(() => _shopifyService.Ncch_Get_Shopify_LogAsync(_global, utcTime, false, "orders", $"&id={baslik.Cid}&status=any")).Result;
            string jsonString = JsonConvert.SerializeObject(products1);
            FYShopifyOrder fYShopifyProduct = new FYShopifyOrder();
            products = JsonConvert.DeserializeObject<List<ShopifyOrder>>(jsonString);
            foreach (var product in products)
            {
                var carivarmi = _cariKartService.Ncch_GetByCariKod_NLog(product.Customer.Id.ToString(), _global, false).Nesne;

                if (carivarmi==null)
                {


                    crcadrs.SIRKID = (int)_global.SirketId;
                    crcadrs.CRKODU = product.Customer.Id.ToString();
                    crcadrs.TANIMI = "Varsayılan Adress";
                    crcadrs.ADRESS = product.BillingAddress.Address1 + " " + product.BillingAddress.Address2;
                    crcadrs.CEPTEL = product.BillingAddress.Phone;
                    crcadrs.GPSENL = product.BillingAddress.Latitude;
                    crcadrs.GPSBOY = product.BillingAddress.Longitude;
                    crcadrs.ULKEKD = product.BillingAddress.CountryCode;
                    crcadrs.ACTIVE = true;
                    crcadrs.SLINDI = false;
                    crcadrs.EKKULL = global.UserKod;
                    crcadrs.ETARIH = DateTime.Now;
                    var sonucadr = _cradrsService.Ncch_Add_NLog(crcadrs, _global);
                    crytkl.SIRKID = (int)_global.SirketId;
                    crytkl.CRKODU = product.Customer.Id.ToString();
                    crytkl.CRADID = sonucadr.Nesne.Id;
                    crytkl.YETADI = product.Customer.FirstName;
                    crytkl.YETSOY = product.Customer.LastName;
                    crytkl.CEPTEL = product.BillingAddress.Phone;
                    crytkl.GNMAIL = product.Customer.Email;
                    crytkl.ACTIVE = true;
                    crytkl.SLINDI = false;
                    crytkl.EKKULL = global.UserKod;
                    crytkl.ETARIH = DateTime.Now;
                    var sonucytk = _crytklService.Ncch_Add_NLog(crytkl, _global);
                    crcari.SIRKID = (int)_global.SirketId;
                    crcari.CRHRKD = "0";
                    crcari.CRKODU = product.Customer.Id.ToString();
                    //crcari.ADCRKD
                    //crcari.ASCRKD
                    crcari.CRUNV1 = product.Customer.FirstName + " " + product.Customer.LastName;
                    //crcari.CRUNV2= 
                    //crcari.CRBGKD
                    //crcari.CRSACN
                    //crcari.CRSSCN
                    //crcari.CRHSP1
                    //crcari.CRHSP2
                    //crcari.CRHSP3
                    //crcari.CRDVCN
                    //crcari.CRDVC1
                    //crcari.CRDVC2
                    //crcari.CRVDYZ
                    //crcari.CRVDY1
                    //crcari.CRVDY2
                    //crcari.KURHSK
                    crcari.VERGDA = product.BillingAddress.Country;
                    crcari.VERGNO = "1";
                    crcari.TSICNO = "1";
                    //crcari.VERKMLKD
                    //crcari.CRODCN
                    crcari.FTADNO = sonucadr.Nesne.Id;
                    crcari.SVADNO = sonucadr.Nesne.Id;
                    crcari.CRAKOD = product.Customer.Id.ToString();
                    //crcari.EFATUR
                    //crcari.ODGUNU
                    //crcari.ODTERC
                    //crcari.OTVTEV
                    //crcari.CRSKOD
                    //crcari.GNMAIL
                    //crcari.GNWEBA
                    crcari.ACTIVE = true;
                    crcari.SLINDI = false;
                    crcari.EKKULL = global.UserKod;
                    crcari.ETARIH = DateTime.Now;
                    //crcari.DEKULL
                    //crcari.DTARIH
                    crcari.KYNKKD = "0";
                    var sonuccari = _cariKartService.Ncch_Add_NLog(crcari, _global);
                }
                else
                {
                    crcari = carivarmi;
                }
            }
            _global.shopName = crkodu;
            this.Close();

        }
    }
}


