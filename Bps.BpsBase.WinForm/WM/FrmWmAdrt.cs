using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.WM;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
    public partial class FrmWmAdrt : Base.FrmChildBase
    {
        private IWmadrtService _sinifService;
        private IGnkxmlService _sinifyerlesimService;
        private GNKXML _sinifyerlesim;
        private ProjeMenuListed yetkiModel;
        private string _action;
        private static WMADRT oldData;
        private readonly IGnthrkService _gnthrkService;
        private readonly IGndptpService _gndptpService;

        public FrmWmAdrt(IWmadrtService sinifService, IGnkxmlService sinifyerlesimService,
            IGnthrkService gnthrkService, IGndptpService gndptpService)
        {
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnthrkService = gnthrkService;
            _gndptpService = gndptpService;
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            oldData = null;
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            yetkiModel = MenuYetki;
            FormIslemleri.FormYetki2(barManager, yetkiModel);
            LoadData();
            GridHelper.ColumnRepositoryItems(gridView1, global);
            barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }
        
        private void LoadData()
        {
            LoadGrid();
            _sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
                global.MenuName,
                global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
            if (_sinifyerlesim != null)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(_sinifyerlesim.GRDXML);
                MemoryStream stream = new MemoryStream(byteArray);
                gridView1.RestoreLayoutFromStream(stream);
            }

            var teknads = new List<string>() {"DEPOKD", "DPALKD", "DPATKD", "DPACKD"};
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            dEPOKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "DEPOKD").ToList();
            dPALKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "DPALKD").ToList();
            dPATKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "DPATKD").ToList();
            dPACKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "DPACKD").ToList();
            repLkedDepoTip.DataSource = _gndptpService.Cch_GetList_NLog(global, false).Items;

        }

        private void LoadGrid()
        {
            wMADRTBindingSource.DataSource = _sinifService.Cch_GetList_NLog(global).Items;
        }

        #region Standard

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";
            var rowView = (WMADRT)wMADRTBindingSource.AddNew();
            if (rowView != null)
            {
                rowView.ACTIVE = true;
                rowView.DGSTBL = false;
                rowView.DCSTBL = false;
            }
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            oldData = ((WMADRT)wMADRTBindingSource.Current).ShallowCopy();
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            try
            {
                var response = new StandardResponse<WMADRT>();
                wMADRTBindingSource.EndEdit();
                var data = (WMADRT)wMADRTBindingSource.Current;
                if (_action == "insert")
                {
                    response = _sinifService.Ncch_Add_NLog(data, global);
                }

                if (_action == "update")
                {
                    global.IsCompare = true;
                    response = _sinifService.Ncch_Update_Log(data, oldData, global);
                    global.IsCompare = false;
                }

                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                LoadGrid();
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Kayıt Yapılamadı! " + exception.Message);
            }
        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                wMADRTBindingSource.EndEdit();
                var data = (WMADRT)wMADRTBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            wMADRTBindingSource.CancelEdit();

            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            oldData = null;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            wMADRTBindingSource.CancelEdit();

            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            oldData = null;
        }

        protected override void barOrtamBelgeAkisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id") == null)
            {
                MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            FrmBelgeAkis form = new FrmBelgeAkis(global, "WMADRT", id);
            form.ShowDialog();
        }

        protected override void barOrtamEk_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id") == null)
            {
                MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            FrmFileManager form = new FrmFileManager(global, "WMADRT", id);
            form.ShowDialog();
        }

        protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                return;
            }
            gridView1.ShowRibbonPrintPreview();
        }

        protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.OptionsView.ShowAutoFilterRow = !gridView1.OptionsView.ShowAutoFilterRow;
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            Point point = gridView1.GridControl.PointToClient(MousePosition);
            GridHitInfo info = gridView1.CalcHitInfo(point);
            if ((info.InRow || info.InRowCell) && info.RowHandle > -1)
            {
                popEtiket.ShowPopup(MousePosition);
            }

            return;
            Stream s = new MemoryStream();
            gridView1.SaveLayoutToStream(s);
            s.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(s);
            FrmGridXml gridXml = new FrmGridXml(global);
            gridXml._kullaniciId = global.UserId.ToString();
            gridXml._moduladi = global.ProjeTanim;
            gridXml._menutag = global.MenuTag.ToString();
            gridXml._gridtag = gridControl1.Tag.ToString();
            gridXml._xml = sr.ReadToEnd();
            GridHelper.gridView_PopupMenuShowing(sender, e, gridXml, gridControl1.Tag.ToString(), gridView1);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridView1.GridControl.PointToClient(MousePosition);
            GridHitInfo info = gridView1.CalcHitInfo(point);
            if (info.InRow || info.InRowCell)
            {
                var link = barDegistir.GetVisibleLinks()[0];
                ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
                barDegistir_ItemClick(barDegistir, arg);
            }
        }

        #endregion

        private void dEPOKDGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            dPTIPIGridLookUpEdit.Properties.DataSource = null;
            if (dEPOKDGridLookUpEdit.EditValue == null) return;
            var value = dEPOKDGridLookUpEdit.EditValue.ToString();

            dPTIPIGridLookUpEdit.Properties.DataSource =
                _gndptpService.Cch_GetListByDepoKd_NLog(value, global, false).Items;
        }

        private void barButEtiketYazdir_ItemClick(object sender, ItemClickEventArgs e)
        {
            string adres = gridView1.GetFocusedRowCellDisplayText("DPADRS");

            //Aracıkan
            string etiketPath = AppDomain.CurrentDomain.BaseDirectory + "\\100x40.repx";

            var rEtiket = XtraReport.FromFile(etiketPath) as repBarkodEtiket;
            //rEtiket.lblStokAdi.Text = adres;
            rEtiket.xrBarcode.Text = adres;

            rEtiket.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
            rEtiket.Print();
        }

        private void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
        {
            short _etiketSayisi = 1; //Convert.ToInt16(txtEtiketAdet.EditValue);
            e.PrintDocument.PrinterSettings.Copies = _etiketSayisi;
        }
    }
}