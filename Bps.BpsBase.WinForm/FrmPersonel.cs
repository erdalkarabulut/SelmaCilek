using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.IK;
using Bps.BpsBase.Entities.Concrete.IS;
using Bps.BpsBase.Entities.Models.GN.Listed;
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

namespace BPS.Windows.Forms
{
    public partial class FrmPersonel : BPS.Windows.Base.FrmChildBase
    {
        private readonly IIkpersService _sinifService;
        private readonly IGnkxmlService _sinifyerlesimService;
        private readonly IGnthrkService _gnthrkService;
        private readonly IGndptnService _gndptnService;
        private readonly IGndpzmService _gndpzmService;
        private readonly IGnklopService _gnklopService;
        private readonly IIsyrtnService _isyrtnService;

        private ProjeMenuListed yetkiModel;
        private string _action;
        private GNKXML _sinifyerlesim;
        private List<GNDPTN> _depolar;
        private List<Grid> _focusedRowHandler = new List<Grid>();
        private List<TipHareketListModel> operasyonList = new List<TipHareketListModel>();

        private int? deletedId;
        private static IKPERS oldData;

        public FrmPersonel(IIkpersService sinifService, IGnkxmlService sinifyerlesimService, IGnthrkService gnthrkService,
            IGndptnService gndptnService, IGndpzmService gndpzmService, IGnklopService gnklopService, IIsyrtnService isyrtnService)
        {
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gndptnService = gndptnService;
            _gndpzmService = gndpzmService;
            _gnthrkService = gnthrkService;
            _gnklopService = gnklopService;
            _isyrtnService = isyrtnService;
            _focusedRowHandler = new List<Grid>();
            oldData = null;
        }

        private void FrmPersonel_Load(object sender, EventArgs e)
        {
            yetkiModel = MenuYetki;
            FormIslemleri.FormYetki2(barManager, yetkiModel);
            LoadData();
            GridHelper.ColumnRepositoryItems(gridView1, global);
            //barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;
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

            _depolar = _gndptnService.Cch_GetListAktif_NLog(global, false).Items;
            repGrdLkedDepo.DataSource = _depolar;

            var teknads = new List<string>() { "LOKAKD", "DEPAKD", "POZSKD", "CINSKD", "CLDRKD", "ISOPKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            lOKAKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "LOKAKD").ToList();
            dEPAKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "DEPAKD").ToList();
            pOZSKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "POZSKD").ToList();
            cINSKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "CINSKD").ToList();
            cLDRKDGridLookUpEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "CLDRKD").ToList();
            operasyonList = teknadsResponse.Items.Where(w => w.TEKNAD == "ISOPKD").ToList();
            chkListOperasyon.DataSource = operasyonList;

            iSYKODGridLookUpEdit.Properties.DataSource = _isyrtnService.Cch_GetListAktif_NLog(global, false).Items;
        }

        private void LoadGrid()
        {
            iKPERSBindingSource.DataSource = _sinifService.Cch_GetList_NLog(global).Items;
            _focusedRowHandler.Clear();
            gNDPZMBindingSource.Clear();
        }

        private void GetPersonelOperasyon()
        {
            try
            {
	            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                var personelOperasyonList = _gnklopService.Ncch_GetListByPersonelId_NLog(id, global, false).Items;
	            var checkList = chkListOperasyon.DataSource as List<TipHareketListModel>;
	            if (checkList != null)
	            {
		            for (int i = 0; i < checkList.Count; i++)
		            {
			            TipHareketListModel gnthrk = checkList[i];
			            var operasyon = personelOperasyonList.FirstOrDefault(s => s.ISOPKD == gnthrk.HARKOD);
			            if (operasyon != null) chkListOperasyon.SetItemChecked(i, true);
			            else chkListOperasyon.SetItemChecked(i, false);
		            }
	            }

            }
            catch (Exception ex)
            {
                MessageBox.Show("GetPersonelOperasyon() " + ex.GetBaseException().Message);
            }
        }

        #region Standard

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            deletedId = null;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";
            var rowView = (IKPERS)iKPERSBindingSource.AddNew();
            if (rowView != null)
            {
                rowView.ACTIVE = true;
            }

            sICILNTextEdit.Enabled = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            deletedId = null;
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";

            sICILNTextEdit.Enabled = false;
            oldData = ((IKPERS)iKPERSBindingSource.Current).ShallowCopy();

            var depolar = _gndpzmService.Ncch_GetByPersonelId_NLog(oldData.Id, global, false).Items;
            for (int i = depolar.Count - 1; i > -1; i--)
            {
                var gndpzm = depolar[i];
                var depo = _depolar.FirstOrDefault(d => d.DPKODU == gndpzm.DPKODU);
                if (depo == null) depolar.Remove(gndpzm);
            }

            gNDPZMBindingSource.DataSource = depolar;

            GetPersonelOperasyon();

            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            try
            {
                var response = new StandardResponse();
                iKPERSBindingSource.EndEdit();

                var data = (IKPERS)iKPERSBindingSource.Current;
                var depos = new List<GNDPZM>();

                foreach (var depo in gNDPZMBindingSource.List)
                {
                    var dpZim = (GNDPZM) depo;
                    dpZim.PERSID = data.Id;
                    dpZim.DPTANM = _depolar.Find(d => d.DPKODU == dpZim.DPKODU).DPTANM;
                    depos.Add(dpZim);
                }

                int persId = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
                List<GNKLOP> personelOperasyonList = new List<GNKLOP>();
                foreach (var checkedItem in chkListOperasyon.CheckedItems)
                {
	                var operasyon = checkedItem as TipHareketListModel;
                    personelOperasyonList.Add(new GNKLOP
                    {
                        SIRKID = global.SirketId.Value,
                        PERSID = persId,
                        ISOPKD = operasyon.HARKOD,
                        ACTIVE = true,
                        SLINDI = false,
                        EKKULL = global.UserKod,
                        ETARIH = DateTime.Now,
                        CHKCTR = false,
                        KYNKKD = "3"
                    });
                }

                response = _sinifService.Ncch_PersonelKaydet_Log(global, data, depos, personelOperasyonList, _focusedRowHandler, _action);
                //var response = _stokService.Ncch_StokKartKaydet_Log(global, model, focusedRowHandler);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                //if (_action == "insert")
                //{
                //    response = _sinifService.Ncch_Add_NLog(data, global);
                //}

                //if (_action == "update")
                //{
                //    global.IsCompare = true;
                //    response = _sinifService.Ncch_Update_Log(data, oldData, global);
                //    global.IsCompare = false;
                //}

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
                iKPERSBindingSource.EndEdit();
                var data = (IKPERS)iKPERSBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            iKPERSBindingSource.CancelEdit();

            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            oldData = null;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            iKPERSBindingSource.CancelEdit();

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
            FrmBelgeAkis form = new FrmBelgeAkis(global, "IKPERS", id);
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
            FrmFileManager form = new FrmFileManager(global, "IKPERS", id);
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

        private void gridView2_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            var cellValue = (int)view.GetRowCellValue(e.RowHandle, view.Columns["Id"]);
            if (cellValue > 0)
            {
                var a = _focusedRowHandler.FirstOrDefault(x => x.Id == cellValue);

                if (a == null)
                {
                    _focusedRowHandler.Add(new Grid(cellValue, "update", view.Tag.ToString()));
                }
            }
        }

        private void gridView2_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;

            var value = view.GetRowCellValue(e.RowHandle, "DPKODU");
            var foundRow = view.LocateByValue(0, view.Columns[1], value);

            if (foundRow >= 0 && foundRow != view.FocusedRowHandle)
            {
                MessageBox.Show("Seçilen depo zaten listede.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Valid = false;
                return;
            }

            if (view.IsNewItemRow(e.RowHandle))
            {
                var a = _focusedRowHandler.Find(x => x.Id == e.RowHandle);
                if (a == null)
                {
                    int rowCount = view.RowCount;
                    if (view.IsNewItemRow(e.RowHandle))
                    {
                        _focusedRowHandler.Add(new Grid(0, "insert"));
                    }
                }
            }
        }

        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            if (toolStripButton == null) return;
            var tag = toolStripButton.Tag.ToString();

            deletedId = null;

            if (tag == "GNDPZM")
            {
                var current = (GNDPZM)gNDPZMBindingSource.Current;
                if (current != null && current.Id > 0)
                {
                    deletedId = current.Id;
                }
            }
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (deletedId != null)
            {
                ToolStripButton toolStripButton = sender as ToolStripButton;
                if (toolStripButton == null) return;
                var tag = toolStripButton.Tag.ToString();
                //var a = _focusedRowHandler.FirstOrDefault(f => f.View == tag);
                //if (a != null)
                //{
                //    _focusedRowHandler.Remove(a);
                //}

                _focusedRowHandler.Add(new Grid(deletedId.Value, "delete", tag));
                deletedId = null;
            }
        }

        private void btnTumunuSec_Click(object sender, EventArgs e)
        {
            var checkList = chkListOperasyon.DataSource as List<TipHareketListModel>;
            if (checkList != null)
            {
                for (int i = 0; i < checkList.Count; i++) chkListOperasyon.SetItemChecked(i, true);
            }
        }

        private void btnTumSecimiKaldır_Click(object sender, EventArgs e)
        {
	        var checkList = chkListOperasyon.DataSource as List<TipHareketListModel>;
	        if (checkList != null)
	        {
		        for (int i = 0; i < checkList.Count; i++) chkListOperasyon.SetItemChecked(i, false);
	        }
        }

        private void iSYKODGridLookUpEdit_MouseClick(object sender, MouseEventArgs e)
        {
	        GridLookUpEdit lked = sender as GridLookUpEdit;

	        if (e.Button == MouseButtons.Right)
	        {
		        IKPERS ikpers = iKPERSBindingSource.Current as IKPERS;

		        lked.EditValue = null;
		        ikpers.ISYKOD = null;
	        }
        }
    }
}