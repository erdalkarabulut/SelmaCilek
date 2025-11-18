using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BPS.Windows.Forms
{
    public partial class FrmDovizKur : Base.FrmChildBase
    {
        private IDovkurService _sinifService;

        private IGnkxmlService _sinifyerlesimService;
        private GNKXML _sinifyerlesim;
        private static DOVKUR oldData;
        private ProjeMenuListed yetkiModel;
        private string _action;
        private readonly IGnthrkService _gnthrkService;

        public FrmDovizKur(IDovkurService sinifService, IGnkxmlService sinifyerlesimService, IGnthrkService gnthrkService)
        {
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnthrkService = gnthrkService;
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

            var teknads = new List<string>() { "DVCNKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            List<TipHareketListModel> dovizList = teknadsResponse.Items.Where(w => w.TEKNAD == "DVCNKD").ToList();
            LkEdDovizKod.Properties.DataSource = dovizList;
            if (dovizList != null && dovizList.FirstOrDefault(d => d.HARKOD == "USD") != null)
            {
                LkEdDovizKod.EditValue = "USD";
            }
            dateEdit1.DateTime = DateTime.Now;
        }

        private void LoadGrid()
        {
            dOVKURBindingSource.DataSource = _sinifService.Cch_GetList_NLog(global).Items.OrderByDescending(o=>o.DOVTRH);
        }

        #region Standard

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";
            var rowView = (DOVKUR)dOVKURBindingSource.AddNew();
            if (rowView != null)
            {
                rowView.ACTIVE = true;
                rowView.DOVTRH = DateTime.Today;
            }
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            oldData = ((DOVKUR)dOVKURBindingSource.Current).ShallowCopy();
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            try
            {
                var response = new StandardResponse<DOVKUR>();
                dOVKURBindingSource.EndEdit();
                var data = (DOVKUR)dOVKURBindingSource.Current;
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
                dOVKURBindingSource.EndEdit();
                var data = (DOVKUR)dOVKURBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            dOVKURBindingSource.CancelEdit();

            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            oldData = null;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            dOVKURBindingSource.CancelEdit();

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
            FrmBelgeAkis form = new FrmBelgeAkis(global, "DOVKUR", id);
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
            FrmFileManager form = new FrmFileManager(global, "DOVKUR", id);
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

        #endregion

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

        private void btnMerkezBankasi_Click(object sender, EventArgs e)
        {
            if (LkEdDovizKod.EditValue.ToString() == "" || LkEdDovizKod.EditValue == null || dateEdit1.EditValue == null) return;

            dOVKURBindingSource.EndEdit();
            var model = (DOVKUR)dOVKURBindingSource.Current;
            model = _sinifService.GetDovizKuru(model);

            var response = new StandardResponse<DOVKUR>();
            if (_action == "insert")
            {
                response = _sinifService.Ncch_Add_NLog(model, global);
            }

            if (_action == "update")
            {
                response = _sinifService.Ncch_Update_Log(model, oldData, global);
            }

            if (response.Status != ResponseStatusEnum.OK)
            {
                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            LoadGrid();
            FormIslemleri.ButonKontrol2(barManager, 3, yetkiModel);
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
        }

        private void dOVKURBindingSource_AddingNew(object sender, System.ComponentModel.AddingNewEventArgs e)
        {
            //gridView1.SetRowCellValue(sender., gridView1.Columns["ACTIVE"], true);
            //gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["DOVTRH"], DateTime.Today);
        }
    }
}