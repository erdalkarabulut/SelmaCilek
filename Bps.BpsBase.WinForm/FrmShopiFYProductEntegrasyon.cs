using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.FY;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.Entities.Models.FY.Listed;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.Helpers;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Transactions;
using System.Windows.Forms;

namespace BPS.Windows.Forms
{
    public partial class FrmShopiFYProductEntegrasyon : DevExpress.XtraEditors.XtraForm
    {

        private string imageFilePath = "";
        private string imageFolder = "";
        private string imageFolder1 = "";
        private Global _global;
        private ICrcariService _crcariService;
        private IShopifyService _shopifyService;
        private IFyshopifyimageService _shopifyimageService;

        private IStcrkdService _stcrkdService;
        private IStnameService _stnameService;
        List<FYStKartListMatch> _stkarList  ;
        List<FyProductListMatch> _productList;
        List<STCRKD> _listStCrkd;
        public FrmShopiFYProductEntegrasyon(Global global)
        {

            _global = global;
            if (_global.SirketId == null)
            {
                _global.SirketId = 1;
                _global.DilKod = "tr-TR";
                _global.UserKod = "admin";
                _global.KaynakKod = "3";
            }
            
            _crcariService = InstanceFactory.GetInstance<ICrcariService>();
            _shopifyService = InstanceFactory.GetInstance<IShopifyService>();
            _shopifyimageService = InstanceFactory.GetInstance<IFyshopifyimageService>();
            _stcrkdService = InstanceFactory.GetInstance<IStcrkdService>();
            _stnameService = InstanceFactory.GetInstance<IStnameService>();
            InitializeComponent();

            
        }

        private void FrmOrtamMenu_Load(object sender, EventArgs e)
        {
            _listStCrkd = new List<STCRKD>();
            var crlist = _crcariService.Cch_GetListByTip_NLog(_global, "10", false).Items;
            LkpEditCRKODU.Properties.DataSource = crlist;
          
            GridHelper.ColumnRepositoryItems(gridStCrkdListView, _global);
            groupControl2.Enabled = false;
            groupControl3.Enabled = false;
        }

       
       

       
       
        

        private void butKaydet_Click(object sender, EventArgs e)
        {
            bool _stnameadd = false;
            string secilen1StokKodu = "";
            string Secilen1StokName = "";
            if (LkpEditCRKODU.EditValue.ToString() == "FY0000002")
            {
                secilen1StokKodu = gridStKartListView.GetFocusedRowCellValue(gridStKartListcolSTKODU).ToString();
                Secilen1StokName = gridProductListView.GetFocusedRowCellValue(gridProductListcoltitle).ToString();
                var _stname = _stnameService.Cch_GetListByStokKodu_NLog(_global, secilen1StokKodu).Items;
                if (_stname .Count > 0)
                {
                    _stnameadd = false;
                }
                else
                {
                    _stnameadd = true;
                }
                
            }
            var secilenStokKodu = gridStKartListView.GetFocusedRowCellValue(gridStKartListcolSTKODU).ToString();
            var sonucitems = _stcrkdService.Ncch_MultiAdd_Log(_listStCrkd, _global, false);

            if (sonucitems.Status == ResponseStatusEnum.OK )
            {

                if (_stnameadd)
                {
                    STNAME sistemDilTanim = new STNAME()
                    {
                        SIRKID = _global.SirketId.Value,
                        STKODU = secilen1StokKodu,
                        STKNAM = Secilen1StokName,
                        LANGKD = "EN",
                        ACTIVE = true,
                        SLINDI = false,
                        EKKULL = _global.UserKod,
                        ETARIH = DateTime.Now,
                        KYNKKD = _global.KaynakKod
                    };
                    _stnameService.Ncch_Add_NLog(sistemDilTanim, _global);
                }
                imageFolder = AppDomain.CurrentDomain.BaseDirectory + "images\\stok\\01\\";
                imageFolder1 = AppDomain.CurrentDomain.BaseDirectory + "images\\stok\\01\\" + secilenStokKodu +"\\";
                Directory.CreateDirectory(imageFolder);
                Directory.CreateDirectory(imageFolder1);
                var imageName = secilenStokKodu+ ".jpg";

                if (ImgUrunSlider.Images.Count == 0)
                {
                    if (ImgFYUrunSlider.Images[0] != null)
                    {
                        File.Delete(imageFolder + imageName);
                        Image FirstImage = ImgFYUrunSlider.Images[0];
                        using (Bitmap bmp = new Bitmap(FirstImage))
                        {

                            bmp.Save(imageFolder + imageName, ImageFormat.Jpeg);
                        }

                    }
                    int i = 0;
                    foreach (var itemimage in ImgFYUrunSlider.Images)
                    {
                        i++;
                        var imageName1 = secilenStokKodu + "-" + i + ".jpg";
                        File.Delete(imageFolder1 + imageName1);
                        Image FirstImage = (Image)itemimage;
                        using (Bitmap bmp = new Bitmap(FirstImage))
                        {

                            bmp.Save(imageFolder1 + imageName1 , ImageFormat.Jpeg);
                        }
                    }
                }
                MessageBox.Show("Kayıt Yapıldı");
                _listStCrkd.Clear();
                gridStCrkdList.RefreshDataSource();
                groupControl1.Enabled = true;
                groupControl2.Enabled = false;
                groupControl3.Enabled = false;
            }
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            
            _stkarList = _shopifyService.Ncch_ListFYStKartListMatch_NLog(_global, LkpEditCRKODU.EditValue.ToString()).Items;
            gridStKartList.DataSource = _stkarList;
            _productList = _shopifyService.Ncch_ListProductListMatch_NLog(_global, LkpEditCRKODU.EditValue.ToString()).Items;
            gridProductList.DataSource = _productList;
        }

        private void gridStKartListView_Click(object sender, EventArgs e)
        {
            ImgUrunSlider.Images.Clear();
            ImgFYUrunSlider.Images.Clear();
            if (gridStKartListView.FocusedRowHandle<0)
            {
                return;
            }
            var secilenStokKodu = gridStKartListView.GetFocusedRowCellValue(gridStKartListcolSTKODU).ToString();
            var SecilenStokName = gridStKartListView.GetFocusedRowCellValue(gridStKartListcolSTKNAM).ToString();
            if (LkpEditCRKODU.EditValue.ToString() == "FY0000001")
            { gridProductListView.ApplyFindFilter(SecilenStokName); }
                
            imageFilePath = AppDomain.CurrentDomain.BaseDirectory + "images\\stok\\01\\"+ secilenStokKodu + ".jpg";
            if (File.Exists(imageFilePath))
            {
                ImgUrunSlider.Images.Add(Image.FromFile(imageFilePath));
            }
            else
            {
                ImgUrunSlider.Images.Clear();
            }
             
        }

        private void LoadImagesFromUrls(string[] imageUrls)
        {
            

            foreach (var url in imageUrls)
            {
                Image img = DownloadImage(url);
                if (img != null)
                {
                    ImgFYUrunSlider.Images.Add(img);
                }
            }
        }

        private Image DownloadImage(string url)
        {
            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] imageData = webClient.DownloadData(url);
                    using (MemoryStream stream = new MemoryStream(imageData))
                    {
                        return Image.FromStream(stream);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "İndirme Hatası", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        private void gridProductListView_Click(object sender, EventArgs e)
        {
            if (gridProductListView.FocusedRowHandle < 0)
            {
                return;
            }
            string[] imageUrls= { };
           
            ImgFYUrunSlider.Images.Clear();
            if (LkpEditCRKODU.EditValue.ToString()== "FY0000002")
            {
                
                _global.shopName = null;
            }
            else
            {
                _global.shopName = "selmacilek";
            }
            var secilencid = gridProductListView.GetFocusedRowCellValue(gridProductListcolCid).ToString();
            var producimageList = _shopifyimageService.Cch_GetListCid_NLog(secilencid, _global, false).Items;
            foreach (var item in producimageList)
            {
                Array.Resize(ref imageUrls, imageUrls.Length + 1);
                imageUrls[imageUrls.Length - 1] = item.src;
            }
           
            LoadImagesFromUrls(imageUrls);
        }

        private void ImageSlider1_MouseClick(object sender, MouseEventArgs e)
        {
            var slider = sender as ImageSlider;
            if (slider.CurrentImage != null) 
            {
                ShowImageForm(slider.CurrentImage);
            }
        }

        private void ShowImageForm(Image image)
        {
            FrmImage imageForm = new FrmImage(image);
            imageForm.ShowDialog(); 
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            if (gridProductListView.RowCount > 0 && gridStKartListView.RowCount>0)
            {
                var secilencid = gridProductListView.GetFocusedRowCellValue(gridProductListcolCid).ToString();
                var secilenStokKodu = gridStKartListView.GetFocusedRowCellValue(gridStKartListcolSTKODU).ToString();
                var stbdrnList = _shopifyService.Ncch_ListStbdrnListMatchByStokkodu_NLog(_global, secilenStokKodu, false).Items;
                var variantList = _shopifyService.Ncch_ListVariantListMatchByStokkodu_NLog(_global, secilencid, LkpEditCRKODU.EditValue.ToString(), false).Items;
                gridStBdrnList.DataSource = stbdrnList;
                gridVariantList.DataSource = variantList;
                groupControl1.Enabled = false;
                groupControl2.Enabled = true;
                groupControl3.Enabled = true;

            }
            
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            if (gridStBdrnListView.RowCount >0 && gridVariantListView.RowCount>0 )
            {
                FYStBdrnListMatch secilenStbdrn = (FYStBdrnListMatch)gridStBdrnListView.GetFocusedRow();
                gridStBdrnListView.DeleteSelectedRows(); 
                FYVariantListMatch secilenVariant = (FYVariantListMatch)gridVariantListView.GetFocusedRow();
                gridVariantListView.DeleteSelectedRows();
                var SecilenStokName = gridStKartListView.GetFocusedRowCellValue(gridStKartListcolSTKNAM).ToString();
                STCRKD _stCrkd = new STCRKD();
                _stCrkd.URYRKD = "1000";
                _stCrkd.CRKODU = LkpEditCRKODU.EditValue.ToString();
                _stCrkd.STKODU = secilenStbdrn.STKODU;
                _stCrkd.VRKODU = secilenStbdrn.VRKODU;
                _stCrkd.RENKKD = secilenStbdrn.RENKKD;
                _stCrkd.BEDNKD = secilenStbdrn.BEDNKD;
                _stCrkd.DROPKD = secilenStbdrn.DROPKD;
                _stCrkd.CRSTKO = secilenVariant.product_id;
                _stCrkd.CRSTNM = secilenVariant.title;
                _stCrkd.CRVRKO = secilenVariant.Cid;
                _listStCrkd.Add(_stCrkd);
                gridStCrkdList.DataSource = _listStCrkd;
                gridStCrkdList.RefreshDataSource();
            }
            
            ;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            _listStCrkd.Clear();
            gridStCrkdList.RefreshDataSource();
            gridStBdrnList.DataSource = null;
            gridStBdrnList.RefreshDataSource();
            gridVariantList.DataSource = null;
            gridVariantList.RefreshDataSource();

            groupControl1.Enabled = true;
            groupControl2.Enabled = false;
            groupControl3.Enabled = false;
        }
    }
}