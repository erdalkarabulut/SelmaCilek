using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.Response;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BPS.Windows.Forms
{
    public partial class FrmSirketTanim : Base.FrmChildBase
    {
        private ISirketService _sinifService;
        private SIRKET _sinif;

        private IGnkxmlService _sinifyerlesimService;
        private GNKXML _sinifyerlesim;
        private readonly IGnyetkService _gnyetkService;
        private readonly IGnthrkService _gnthrkService;

        private static SIRKET oldData;

        List<Grid> focusedRowHandler = new List<Grid>();
        private FrmWait _frmWait;
        public Thread thread;
        private ProjeMenuListed yetkiModel;
        private string _action;


        private delegate void kaydetDlg(object button);

        private List<TipHareketListModel> TeknadsResponse;

        public FrmSirketTanim(ISirketService sinifService, IGnkxmlService sinifyerlesimService, 
            IGnyetkService gnyetkService, IGnthrkService gnthrkService)
        {
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _gnthrkService = gnthrkService;
            oldData = null;
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            FormIslemleri.FormYetki2(barManager, yetkiModel);
            LoadData();
            //gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            GridHelper.ColumnRepositoryItems(gridView1, global);
        }

        private void LoadData()
        {
            RefreshGrid();
            _sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
                global.MenuName,
                global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
            if (_sinifyerlesim != null)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(_sinifyerlesim.GRDXML);
                MemoryStream stream = new MemoryStream(byteArray);
                gridView1.RestoreLayoutFromStream(stream);
            }

            var teknads = new List<string>() { "MAHAKD", "ILCEKD", "SEHRKD", "ULKEKD" };
            TeknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false).Items;
            LkEdUlke.Properties.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "ULKEKD").ToList();
            LkEdSehir.Properties.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "SEHRKD").ToList();
            LkEdIlce.Properties.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "ILCEKD").ToList();
            LkEdMahalle.Properties.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "MAHAKD").ToList();
        }

        private void RefreshGrid()
        {
            sIRKETBindingSource.DataSource = _sinifService.Cch_GetList_NLog(global).Items;
        }

        #region Menu elements

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";
            sIRKETBindingSource.AddNew();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            oldData = ((SIRKET)sIRKETBindingSource.Current).ShallowCopy();
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            sIRKETBindingSource.CancelEdit();

            RefreshGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            oldData = null;
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            //thread = new Thread(kaydet);
            //thread.IsBackground = true;
            kaydet(e.Item.Tag);
            //_frmWait.thread = thread;

            //_frmWait.Top = (this.Top + (this.Height / 2) - (_frmWait.Height / 2));
            //_frmWait.Left = this.Left + (this.Width / 2) - (_frmWait.Width / 2);
            //_frmWait.parameter = sender;
            //_frmWait.Show();
        }

        public void kaydet(object itemTag)
        {
            //if (this.InvokeRequired)
            if (false)
            {
                kaydetDlg dlg = new kaydetDlg(kaydet);
                this.Invoke(dlg, itemTag);
            }
            else
            {
                //this.Validate();
                try
                {
                    var response = new StandardResponse<SIRKET>();
                    sIRKETBindingSource.EndEdit();
                    var data = (SIRKET)sIRKETBindingSource.Current;
                    if (_action == "insert")
                    {
                        response = _sinifService.Ncch_Add_NLog(data, global);
                    }

                    if (_action == "update")
                    {
                        response = _sinifService.Ncch_Update_Log(data, oldData, global);
                    }

                    if (response.Status != ResponseStatusEnum.OK)
                    {
                        MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    RefreshGrid();
                    focusedRowHandler.Clear();
                    FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
                    xtraTabControl1.SelectedTabPage = xtraTabPage1;
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Kayıt Yapılamadı! " + exception.Message);
                }
            }
        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Eminmisiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                sIRKETBindingSource.EndEdit();
                var data = (SIRKET)sIRKETBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                RefreshGrid();
            }
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
            ////gridViewP13.OptionsView.ShowAutoFilterRow = !gridViewP13.OptionsView.ShowAutoFilterRow;
        }

        #endregion

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

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridView1.GridControl.PointToClient(MousePosition);
            RowDoubleClick(gridView1, point);
        }

        private void RowDoubleClick(GridView gridView, Point point)
        {
            GridHitInfo info = gridView.CalcHitInfo(point);
            if (info.InRow || info.InRowCell)
            {
                var link = barDegistir.GetVisibleLinks()[0];
                ItemClickEventArgs e = new ItemClickEventArgs(barDegistir, link);
                barDegistir_ItemClick(barDegistir, e);
            }
        }
        private void LkEdUlke_EditValueChanged(object sender, EventArgs e)
        {
            var edit = sender as GridLookUpEdit;
            TipHareketListModel data = (TipHareketListModel)edit.Properties.GetRowByKeyValue(edit.EditValue);

            LkEdSehir.Properties.DataSource = null;
            LkEdIlce.Properties.DataSource = null;
            LkEdMahalle.Properties.DataSource = null;

            if (LkEdUlke.EditValue != null && TeknadsResponse != null && data != null)
            {
                var sehirList = TeknadsResponse.Where(w => w.TEKNAD == "SEHRKD" && w.PARENT == data.Id).ToList();
                LkEdSehir.Properties.DataSource = sehirList;

                //LkEdSehir.EditValue = s.SEHRKD;
            }
        }

        private void LkEdSehir_EditValueChanged(object sender, EventArgs e)
        {
            var edit = sender as GridLookUpEdit;
            TipHareketListModel data = (TipHareketListModel)edit.Properties.GetRowByKeyValue(edit.EditValue);

            LkEdIlce.Properties.DataSource = null;
            LkEdMahalle.Properties.DataSource = null;
            if (LkEdSehir.EditValue != null && TeknadsResponse != null && data != null)
            {
                var ılceList = TeknadsResponse.Where(w => w.TEKNAD == "ILCEKD" && w.PARENT == data.Id).ToList();
                LkEdIlce.Properties.DataSource = ılceList;

                //LkEdIlce.EditValue = _cariKartAdres.ILCEKD;
            }
        }

        private void LkEdIlce_EditValueChanged(object sender, EventArgs e)
        {
            var edit = sender as GridLookUpEdit;
            TipHareketListModel data = (TipHareketListModel)edit.Properties.GetRowByKeyValue(edit.EditValue);

            LkEdMahalle.Properties.DataSource = null;

            if (LkEdIlce.EditValue != null && TeknadsResponse != null && data != null)
            {
                var mahalleList = TeknadsResponse.Where(w => w.TEKNAD == "MAHAKD" && w.PARENT == data.Id).ToList();
                LkEdMahalle.Properties.DataSource = mahalleList;

                //LkEdMahalle.EditValue = _cariKartAdres.MAHAKD;
            }
        }
    }
}
