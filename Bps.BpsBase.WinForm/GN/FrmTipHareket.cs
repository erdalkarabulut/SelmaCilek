using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.DataAccess.Concrete.EntityFramework.GN;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.Core.GlobalStaticsVariables;
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
    public partial class FrmTipHareket : Base.FrmChildBase
    {
        private readonly IGnthrkService _sinifService;
        private readonly IGnbnhrService _gnbnhrService;
        private readonly IGnlkhrService _gnlkhrService;
        private readonly IGnyetkService _gnyetkService;
        private readonly IGntipiService _gntipiService;
        private IGnkxmlService _sinifyerlesimService;
        private Global globaldil;
        private GNKXML _sinifyerlesim;
        private static IList<GNTHRK> list;
        private BindingList<GNTHRK> bindingList;
        private BindingList<GNTHRK> oldBindingList;

        private static IList<GNLKHR> gnlkhrList;
        private BindingList<GNLKHR> gnlkhrBindingList;
        private BindingList<GNLKHR> gnlkhrOldBindingList;

        private static IList<GNBNHR> gnbnhrList;
        private BindingList<GNBNHR> gnbnhrBindingList;
        private BindingList<GNBNHR> gnbnhrOldBindingList;

        List<Grid> focusedRowHandler = new List<Grid>();
        private ProjeMenuListed yetkiModel;
        private string sinifTip; 

        public FrmTipHareket(IGnthrkService sinifService, IGnbnhrService gnbnhrService,
            IGnlkhrService gnlkhrService, IGnyetkService gnyetkService,
            IGntipiService gntipiService, IGnkxmlService sinifyerlesimService)
        {
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _gntipiService = gntipiService;
            _gnbnhrService = gnbnhrService;
            _gnlkhrService = gnlkhrService;
            InitializeComponent();
        }

        private void FrmTipHrk_Load(object sender, EventArgs e)
        {
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            FormIslemleri.FormYetki2(barManager, yetkiModel);
            barManager.Bars["Tools"].Visible = false;
            barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;
            
            LoadData();
            GridHelper.ColumnRepositoryItems(gridView16, global);
        }

        private void LoadData()
        {
            var tipList = _gntipiService.Cch_GetAll_NLog(global, yetkiKontrol: false).Items;
            LkEdTip.Properties.DataSource = tipList;
            repHareketTablosu.DataSource = _sinifService.Cch_GetListByTeknad(global, "HRTBKD", false).Items;
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            var teknads = new List<string>() { "LANGKD" };
            var teknadsResponse = _sinifService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            List<TipHareketListModel> dilList = teknadsResponse.Items.Where(w => w.TEKNAD == "LANGKD").ToList();
            LkEdDilKod.Properties.DataSource = dilList;
            LkEdDilKod.Text = global.DilKod;
        }

        private void LoadParentList(GNTIPI tip)
        {
            var parents = new CmbComboModel();
            parents.TipHareketList = new List<TipHareketListModel>();

            if (!string.IsNullOrEmpty(tip.UTPKOD))
            {
                if (tip.UTPKOD == "000")
                {
                    parents.TipHareketList.Add(new TipHareketListModel()
                    {
                        Id = 0,
                        TIPKOD = "000",
                        TANIMI = "ROOT",
                    });
                }
                else
                {
                    if (tip.HRKTBL == "GNTHRK")
                    {
                        parents.TipHareketList = _sinifService
                            .Cch_TipHareketListGetir(globaldil, tip.UTPKOD, false)
                            .Items;
                    }
                    else if (tip.HRKTBL == "GNLKHR")
                    {
                        parents.TipHareketList = _gnlkhrService
                            .Cch_TipHareketListGetir(global, tip.UTPKOD, false)
                            .Items;
                    }
                    else if (tip.HRKTBL == "GNBNHR")
                    {
                        parents.TipHareketList = _gnbnhrService
                            .Cch_TipHareketListGetir(global, tip.UTPKOD, false)
                            .Items;
                    }
                }
            }

            repoParent.DataSource = parents.TipHareketList;
        }

        private void LoadGrid()
        {
            var tipKod = LkEdTip.EditValue == null ? "" : LkEdTip.EditValue.ToString();
            var tip = LkEdTip.GetSelectedDataRow() as GNTIPI;
            sinifTip = tip.HRKTBL;
            if (tip.HRKTBL == "GNTHRK")
            {
                list = _sinifService.Cch_GetListByTipKod(globaldil, tipKod, true).Items;
                bindingList = new BindingList<GNTHRK>(list);
                oldBindingList = new BindingList<GNTHRK>(bindingList.Select(item => item.ShallowCopy()).ToList());
                gNTHRKBindingSource1.DataSource = bindingList;
            }
            else if (tip.HRKTBL == "GNLKHR")
            {
                gnlkhrList = _gnlkhrService.Cch_GetListByTipKod(global, tipKod, false).Items;
                gnlkhrBindingList = new BindingList<GNLKHR>(gnlkhrList);
                gnlkhrOldBindingList = new BindingList<GNLKHR>(gnlkhrBindingList.Select(item => item.ShallowCopy()).ToList());
                gNTHRKBindingSource1.DataSource = gnlkhrBindingList;
            }
            else if (tip.HRKTBL == "GNBNHR")
            {
                gnbnhrList = _gnbnhrService.Cch_GetListByTipKod(global, tipKod, false).Items;
                gnbnhrBindingList = new BindingList<GNBNHR>(gnbnhrList);
                gnbnhrOldBindingList = new BindingList<GNBNHR>(gnbnhrBindingList.Select(item => item.ShallowCopy()).ToList());
                gNTHRKBindingSource1.DataSource = gnbnhrBindingList;
            }

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            focusedRowHandler.Clear();
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            globaldil = global.ShallowCopy();
            globaldil.DilKod = LkEdDilKod.EditValue.ToString(); 
            var tipKod = LkEdTip.EditValue == null ? "" : LkEdTip.EditValue.ToString();
            if (string.IsNullOrEmpty(tipKod))
            {
                MessageBox.Show("Lütfen 'Tip' seçiniz! ", "Uyarı");
                return;
            }

            var tip = LkEdTip.GetSelectedDataRow() as GNTIPI;

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

            LoadParentList(tip);
            GridHelper.ColumnRepositoryItems(gridView1, global);

            gridView1.Columns["TIPKOD"].Visible = false;
            barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
            barManager.Bars["Tools"].Visible = true;
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        #region Standard

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView1.MakeRowVisible(GridControl.NewItemRowHandle);
            globaldil.DilKod = LkEdDilKod.EditValue.ToString();
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            globaldil.DilKod = LkEdDilKod.EditValue.ToString();
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            if (sinifTip == "GNTHRK")
                gnthrkKaydet(e.Item.Tag);
            if (sinifTip == "GNLKHR")
                gnlkhrKaydet(e.Item.Tag);
            if (sinifTip == "GNBNHR")
                gnbnhrKaydet(e.Item.Tag);
        }

        private void gnthrkKaydet(object itemTag)
        {
            try
            {
                StandardResponse<GNTHRK> response;
                var bindigSources = gNTHRKBindingSource1.List;
                var datas = new List<GNTHRK>();

                foreach (var bind in bindigSources)
                {
                    datas.Add((GNTHRK)bind);
                }

                var inserted = datas.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.LANGKD = globaldil.DilKod;
                    response = _sinifService.Ncch_Add_NLog(data, globaldil);

                    if (response.Status != ResponseStatusEnum.OK)
                    {
                        LoadGrid();
                        FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
                        MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                var grids = focusedRowHandler.Where(w => w.Tipi != "Insert").ToList();
                foreach (var grid in grids)
                {
                    var data = datas.FirstOrDefault(f => f.Id == grid.Id);
                    if (data == null) continue;
                    if (grid.Tipi == "Update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.LANGKD = globaldil.DilKod;

                        global.IsCompare = true;
                        response = _sinifService.Ncch_Update_Log(data, oldBindingList.FirstOrDefault(f => f.Id == grid.Id), globaldil);
                        global.IsCompare = false;

                        if (response.Status != ResponseStatusEnum.OK)
                        {
                            MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }

                LoadGrid();
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Kayıt Yapılamadı " + exception.Message);
            }
        }
        

        private void gnlkhrKaydet(object itemTag)
        {
            try
            {
                StandardResponse<GNLKHR> response;
                var bindigSources = gNTHRKBindingSource1.List;
                var datas = new List<GNLKHR>();

                foreach (var bind in bindigSources)
                {
                    datas.Add((GNLKHR)bind);
                }

                var inserted = datas.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    response = _gnlkhrService.Ncch_Add_NLog(data, global);

                    if (response.Status != ResponseStatusEnum.OK)
                    {
                        LoadGrid();
                        FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
                        MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                var grids = focusedRowHandler.Where(w => w.Tipi != "Insert").ToList();
                foreach (var grid in grids)
                {
                    var data = datas.FirstOrDefault(f => f.Id == grid.Id);
                    if (data == null) continue;
                    if (grid.Tipi == "Update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;

                        global.IsCompare = true;
                        response = _gnlkhrService.Ncch_Update_Log(data, gnlkhrOldBindingList.FirstOrDefault(f => f.Id == grid.Id), global);
                        global.IsCompare = false;

                        if (response.Status != ResponseStatusEnum.OK)
                        {
                            MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }

                LoadGrid();
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Kayıt Yapılamadı " + exception.Message);
            }
        }

        private void gnbnhrKaydet(object itemTag)
        {
            try
            {
                StandardResponse<GNBNHR> response;
                var bindigSources = gNTHRKBindingSource1.List;
                var datas = new List<GNBNHR>();

                foreach (var bind in bindigSources)
                {
                    datas.Add((GNBNHR)bind);
                }

                var inserted = datas.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    response = _gnbnhrService.Ncch_Add_NLog(data, global);

                    if (response.Status != ResponseStatusEnum.OK)
                    {
                        LoadGrid();
                        FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
                        MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                var grids = focusedRowHandler.Where(w => w.Tipi != "Insert").ToList();
                foreach (var grid in grids)
                {
                    var data = datas.FirstOrDefault(f => f.Id == grid.Id);
                    if (data == null) continue;
                    if (grid.Tipi == "Update")
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;

                        global.IsCompare = true;
                        response = _gnbnhrService.Ncch_Update_Log(data, gnbnhrOldBindingList.FirstOrDefault(f => f.Id == grid.Id), global);
                        global.IsCompare = false;

                        if (response.Status != ResponseStatusEnum.OK)
                        {
                            MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }

                LoadGrid();
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Kayıt Yapılamadı " + exception.Message);
            }
        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                var tip = LkEdTip.GetSelectedDataRow() as GNTIPI;

                if (tip.HRKTBL == "GNTHRK")
                {
                    _sinifService.Ncch_Delete_Log(bindingList[Convert.ToInt32(gridView1.GetFocusedDataSourceRowIndex())], global);
                }
                else if (tip.HRKTBL == "GNLKHR")
                {
                    _gnlkhrService.Ncch_Delete_Log(gnlkhrBindingList[Convert.ToInt32(gridView1.GetFocusedDataSourceRowIndex())], global);
                }
                else if (tip.HRKTBL == "GNBNHR")
                {
                    _gnbnhrService.Ncch_Delete_Log(gnbnhrBindingList[Convert.ToInt32(gridView1.GetFocusedDataSourceRowIndex())], global);
                }

                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadGrid();
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadGrid();
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }

        protected override void barOrtamBelgeAkisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id") == null)
            {
                MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            FrmBelgeAkis form = new FrmBelgeAkis(global, "GNTHRK", id);
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
            FrmFileManager form = new FrmFileManager(global, "GNTHRK", id);
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

        protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            barManager.Bars["Tools"].Visible = false;
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var tip = LkEdTip.GetSelectedDataRow() as GNTIPI;
            if (tip != null)
            {
                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["TIPKOD"], tip.TIPKOD);
                gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ACTIVE"], true);
            }
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            Stream s = new MemoryStream();
            gridView1.SaveLayoutToStream(s);
            s.Seek(0, SeekOrigin.Begin);
            StreamReader sr = new StreamReader(s);
            FrmGridXml gridXml = new FrmGridXml(global);
            gridXml._kullaniciId = global.UserId.ToString();
            gridXml._moduladi = global.MenuName;
            gridXml._menutag = global.MenuTag.ToString();
            gridXml._gridtag = gridControl1.Tag.ToString();
            gridXml._xml = sr.ReadToEnd();
            GridHelper.gridView_PopupMenuShowing(sender, e, gridXml, gridControl1.Tag.ToString(), gridView1);
        }

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            var cellValue = (int)view.GetRowCellValue(e.RowHandle, view.Columns["Id"]);
            if (cellValue > 0)
            {
                var a = focusedRowHandler.FirstOrDefault(x => x.Id == cellValue);

                if (a == null)
                {
                    focusedRowHandler.Add(new Grid(cellValue, "Update"));
                }
            }
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


        public void topluAktar()
        {
            IGnthrkDal dal = new EfGnthrkDal();
            string con =
                @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Kitap22.xls;" +
                @"Extended Properties='Excel 8.0;HDR=Yes;'";
            using (OleDbConnection connection = new OleDbConnection(con))
            {
                connection.Open();
                OleDbCommand command = new OleDbCommand("select * from [Sayfa1$]", connection);
                OleDbDataAdapter da = new OleDbDataAdapter(command);
                DataTable dt = new DataTable();
                da.Fill(dt);
                for (int x = 0; x < dt.Rows.Count; x++)
                {
                    string rowString = "";

                    //for (int y = 0; y < dt.Columns.Count; y++)
                    //{

                    //}


                    var model = new GNTHRK();
                    model.SIRKID = global.SirketId.Value;
                    model.TIPKOD = "042";
                    model.HARKOD = dt.Rows[x][0].ToString();
                    model.PARENT = 0;
                    model.TANIMI = dt.Rows[x][1].ToString();
                    model.SIRASI = x;
                    model.ACTIVE = true;
                    model.SLINDI = false;
                    model.EKKULL = "admin";
                    model.ETARIH = DateTime.Now;
                    model.KYNKKD = "3";
                    model.CHKCTR = false;
                    if (model.SIRASI > 19)
                    {
                        dal.Add(model);
                    }
                    ;
                }
            }
        }
    }
}