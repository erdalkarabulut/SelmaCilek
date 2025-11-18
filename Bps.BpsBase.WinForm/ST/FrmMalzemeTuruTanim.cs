using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Exception = System.Exception;

namespace BPS.Windows.Forms
{
    public partial class FrmMalzemeTuruTanim : Base.FrmChildBase
    {
        private IStmaltService _sinifService;
        private IGnkxmlService _sinifyerlesimService;
        private GNKXML _sinifyerlesim;
        private STMALT _copysinif;

        private static IList<StokDurumModel> durumTanimGridIList;
        private BindingList<StokDurumModel> bindingListDurumTanimGridList;
        private string _action;
        private ProjeMenuListed yetkiModel;
        private readonly IGnyetkService _gnyetkService;
        private readonly IGnthrkService _gnthrkService;
        private static STMALT oldData;
        private List<GNYETB> ortamModel;
        private readonly IGnyetbService _gnyetbService;

        public FrmMalzemeTuruTanim(IStmaltService sinifService, IGnkxmlService sinifyerlesimService, 
            IGnyetkService gnyetkService, IGnthrkService gnthrkService, IGnyetbService gnyetbService)
        {
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _gnthrkService = gnthrkService;
            _gnyetbService = gnyetbService;
        }

        private void FrmMalzemeTuruTanim_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ortamModel = _gnyetbService.Cch_GetListYetkiId_NLog(yetkiModel.Id, global, false).Items;
            FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);
            LoadData();
            LoadDataGridList();
            gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            GridHelper.ColumnRepositoryItems(gridView1, global);
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }

        private void LoadData()
        {
            LoadGrid();

            var teknads = new List<string>() { "STCNKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            LkEdMalzemeKategori.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "STCNKD").ToList();

            _sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
                global.MenuName,
                global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
            if (_sinifyerlesim != null)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(_sinifyerlesim.GRDXML);
                MemoryStream stream = new MemoryStream(byteArray);
                gridView1.RestoreLayoutFromStream(stream);
            }
        }

        private void LoadGrid()
        {
            sTMALTBindingSource.DataSource = _sinifService.Cch_GetList_NLog(global).Items;
        }

        private void LoadDataGridList()
        {
            var teknads = new List<string>() { "STSKKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            var durumList = teknadsResponse.Items.Where(w => w.TEKNAD == "STSKKD").ToList();
            durumTanimGridIList = new List<StokDurumModel>();
            foreach (var durum in durumList)
            {
                var model = new StokDurumModel(false, durum.HARKOD, durum.TANIMI);
                durumTanimGridIList.Add(model);
            }
            bindingListDurumTanimGridList = new BindingList<StokDurumModel>(durumTanimGridIList);
            gridControl2.DataSource = bindingListDurumTanimGridList;
            gridView2.Columns[1].OptionsColumn.AllowEdit = false;
            gridView2.Columns[2].OptionsColumn.AllowEdit = false;
            gridView2.BestFitColumns();
        }

        #region Standard

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";
            LoadDataGridList();
            TxtMalzemeTuru.Enabled = true;
            TxtMalzemeTuru.Text = "";
            TxtMalzemeTuruText.Text = "";

            var rowView = (STMALT)sTMALTBindingSource.AddNew();
            if (rowView != null)
            {
                rowView.ACTIVE = true;
            }
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";
            string bakimDurum = gridView1.GetFocusedRowCellDisplayText("STBKDR");
            gridControl2.DataSource = BakimDurumBinding(bakimDurum);
            gridControl2.RefreshDataSource();
            TxtMalzemeTuru.Enabled = false;
            //TxtMalzemeTuru.Text = gridView1.GetFocusedRowCellDisplayText("STMLTR");
            //TxtMalzemeTuruText.Text = gridView1.GetFocusedRowCellDisplayText("STMLNM");
            //LkEdMalzemeKategori.EditValue = gridView1.GetFocusedRowCellValue("STCNKD");
            //LkEdMalzemeKategori.Properties.View.FocusedRowHandle = kategoriRow;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            oldData = ((STMALT)sTMALTBindingSource.Current).ShallowCopy();
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            try
            {
                var response = new StandardResponse<STMALT>();
                var newDurums = BakimDurumStr(bindingListDurumTanimGridList);
                sTMALTBindingSource.EndEdit();
                var data = (STMALT)sTMALTBindingSource.Current;
                if (((bool)data.OTMTIK) && ((data.FORMUL == null) || (data.FORMUL == "")))
                {
                    MessageBox.Show("Otomatik alanı işaretlendiyse formül alanı boş olmaz", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                data.STBKDR = newDurums;

                if (_action == "insert")
                {
                    response = _sinifService.Ncch_Add_NLog(data, global);
                }
                else if (_action == "update")
                {
                    global.IsCompare = true;
                    response = _sinifService.Ncch_Update_Log(data, oldData, global);
                    global.IsCompare = false;
                }

                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                LoadGrid();
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
            }
            catch (Exception exception)
            {
                MessageBox.Show("Kayıt Yapılamadı " + exception.Message);
            }
        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Eminmisiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                sTMALTBindingSource.EndEdit();
                var data = (STMALT)sTMALTBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            sTMALTBindingSource.CancelEdit();

            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            oldData = null;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            sTMALTBindingSource.CancelEdit();

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
            FrmBelgeAkis form = new FrmBelgeAkis(global, "STMALT", id);
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
            FrmFileManager form = new FrmFileManager(global, "STMALT", id);
            form.ShowDialog();
        }
        protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                return;
            }

            gridView1.ShowPrintPreview();
        }

        protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.OptionsView.ShowAutoFilterRow = gridView1.OptionsView.ShowAutoFilterRow == false;

        }
        protected override void barKopyala_ItemClick(object sender, ItemClickEventArgs e)
        {
            STMALT sTMALT = sTMALTBindingSource.Current as STMALT;
            _copysinif = sTMALT.ShallowCopy();
            _copysinif.Id = 0;
            _action = "insert";
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            
            string bakimDurum = gridView1.GetFocusedRowCellDisplayText("STBKDR");
            gridControl2.DataSource = BakimDurumBinding(bakimDurum);
            gridControl2.RefreshDataSource();
            
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
           
            sTMALTBindingSource.Add(_copysinif);
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

        public string BakimDurumStr(BindingList<StokDurumModel> durumTanimGL)
        {
            string bakimDurumStr = "";
            foreach (var durum in durumTanimGL)
            {
                if (durum.checkState)
                {
                    bakimDurumStr = bakimDurumStr + durum.DurumKodu;
                }
            }
            return bakimDurumStr;
        }

        public BindingList<StokDurumModel> BakimDurumBinding(string bakimDurumStr)
        {
            LoadDataGridList();
            foreach (char letter in bakimDurumStr)
            {
                foreach (var item in bindingListDurumTanimGridList)
                {
                    if (item.DurumKodu == letter.ToString())
                    {
                        item.checkState = true;
                    }
                }
            }
            return bindingListDurumTanimGridList;
        }

        private void rNKBDNCheckEdit_CheckedChanged(object sender, EventArgs e)
        {
            //var _sender = (CheckEdit)sender;
            bool _checkstate;

            if (sTBDENCheckEdit.CheckState == CheckState.Checked || sTRNKCheckEdit.CheckState == CheckState.Checked || sTDROPCheckEdit.CheckState == CheckState.Checked)
            {
                _checkstate = true; 
            }
            else
            {
                _checkstate = false;
            }

            foreach (var item in bindingListDurumTanimGridList)
            {
                if (item.DurumKodu == "R")
                {
                    item.checkState = _checkstate;
                }
            }
            gridControl2.RefreshDataSource();
        }
    }
}