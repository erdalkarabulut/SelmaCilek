using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Grid = Bps.Core.Utilities.WinForm.Grid;

namespace BPS.Windows.Forms
{
    public partial class FrmYetki : Base.FrmChildBase
    {
        private readonly IGnkullService _gnkullService;
        private readonly IGnthrkService _gnthrkService;
        private readonly IGnyetkService _gnyetkService;

        private IGnyetkService _sinifService;
        private IGnkxmlService _sinifyerlesimService;

        private GNKXML _sinifyerlesim;

        private ProjeMenuListed yetkiModel;
        private static IList<GNYETK> list;
        private BindingList<GNYETK> bindingList;
        private BindingList<GNYETK> oldBindingList;
        private List<Grid> focusedRowHandler = new List<Grid>();

        public FrmYetki(IGnkullService gnkullService, IGnthrkService gnthrkService,
            IGnyetkService gnyetkService, IGnyetkService sinifService,
            IGnkxmlService sinifyerlesimService)
        {
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnkullService = gnkullService;
            _gnthrkService = gnthrkService;
            _gnyetkService = gnyetkService;
            InitializeComponent();
        }

        private void FrmYetki_Load(object sender, EventArgs e)
        {
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            yetkiModel = _gnyetkService.Ncch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            FormIslemleri.FormYetki2(barManager, yetkiModel);
            barManager.Bars["Tools"].Visible = false;
            barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;

            var kullResponse = _gnkullService.Ncch_GetOnlyActiveUsers_NLog(global, false);
            var projeList = _gnthrkService.Cch_GetListByTeknad(global, "PROJKD", false).Items;
            repGnYetkiProKod.DataSource = projeList;
            if (global.UserKod == "admin")
            {
                LkEdKullanici.Properties.DataSource = kullResponse.Items.ToList();
            }
            else
            {
                LkEdKullanici.Properties.DataSource = kullResponse.Items.Where(k => k.KULKOD != "admin").ToList();
            }
            
            LkEdProje.Properties.DataSource = projeList;
        }

        private void LoadGrid()
        {
            var kulKod = LkEdKullanici.EditValue == null ? "" : LkEdKullanici.EditValue.ToString();
            var projeKod = LkEdProje.EditValue == null ? "" : LkEdProje.EditValue.ToString();

            if (!string.IsNullOrEmpty(kulKod))
            {
                var projeList = LkEdProje.Properties.DataSource as List<GNTHRK>;

                list = _sinifService.Ncch_GetListByFilter_NLog(global, kulKod, projeKod, true).Items.Where(p => p.PROKOD != null && p.PROKOD != "").ToList();
                
                //foreach (GNTHRK proje in projeList)
                //{
                    
                //}

                bindingList = new BindingList<GNYETK>(list);
                oldBindingList = new BindingList<GNYETK>(bindingList.Select(item => item.ShallowCopy()).ToList());
                gNYETKBindingSource.DataSource = bindingList;

                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                focusedRowHandler.Clear();
            }

            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }

        private void btnAra_Click(object sender, EventArgs e)
        {
            var kulKod = LkEdKullanici.EditValue == null ? "" : LkEdKullanici.EditValue.ToString();
            var projeKod = LkEdProje.EditValue == null ? "" : LkEdProje.EditValue.ToString();
            if (string.IsNullOrEmpty(kulKod))
            {
                MessageBox.Show("Lütfen kullanıcı seçiniz! ", "Uyarı");
                return;
            }
            
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

            GridHelper.ColumnRepositoryItems(gridView1, global);

            gridView1.Columns["KULKOD"].OptionsColumn.AllowEdit = false;
            //gridView1.SetRowCellValue(1, gridView1.Columns["KULKOD"], kulKod);

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
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            try
            {
                StandardResponse<GNYETK> response;
                var bindigSources = gNYETKBindingSource.List;
                var datas = new List<GNYETK>();
                foreach (var bind in bindigSources)
                {
                    datas.Add((GNYETK)bind);
                }

                var inserted = datas.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    response = _sinifService.Ncch_Add_NLog(data, global);

                    if (response.Status != ResponseStatusEnum.OK)
                    {
                        LoadGrid();
                        FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
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
                        response = _sinifService.Ncch_Update_Log(data, oldBindingList.FirstOrDefault(f=>f.Id == grid.Id), global);
                        global.IsCompare = false;

                        if (response.Status != ResponseStatusEnum.OK)
                        {
                            MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            break;
                        }
                    }
                }

                LoadGrid();
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
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
                _sinifService.Ncch_Delete_Log(bindingList[Convert.ToInt32(gridView1.GetFocusedDataSourceRowIndex())], global);
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
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            LoadGrid();
        }

        protected override void barOrtamBelgeAkisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id") == null)
            {
                MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            FrmBelgeAkis form = new FrmBelgeAkis(global, "GNYETK", id);
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
            FrmFileManager form = new FrmFileManager(global, "GNYETK", id);
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
        protected override void barKopyala_ItemClick(object sender, ItemClickEventArgs e)
        {
            FrmYetkiKopyala pForm = new FrmYetkiKopyala(global);
            pForm.LkEdTKullanici.EditValue = LkEdKullanici.EditValue;
            pForm.ShowDialog();
            LoadGrid();
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ACTIVE"], true);
            var kulKod = LkEdKullanici.EditValue;
            var projeKod = LkEdProje.EditValue;
            if (kulKod != null) gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["KULKOD"], kulKod);
            if (projeKod != null) gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["PROKOD"], projeKod);
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
            var a = focusedRowHandler.Find(x => x.Id == e.RowHandle);
            if (e.RowHandle >= 0 && view != null)
            {
                var cellValue = (int)view.GetRowCellValue(e.RowHandle, view.Columns["Id"]);
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
            if (info.HitTest == GridHitTest.RowIndicator)
            {
                if (gridView1.OptionsBehavior.Editable)
                {
                    GridColumn column = gridView1.Columns[4];
                    bool value = !Convert.ToBoolean(gridView1.GetRowCellValue(info.RowHandle, column));

                    for (int i = 4; i < 16; i++)
                    {
                        column = gridView1.Columns[i];
                        gridView1.SetRowCellValue(info.RowHandle, column, value);
                    }
                }
            }
            if (info.InRow || info.InRowCell)
            {
                var link = barDegistir.GetVisibleLinks()[0];
                ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
                barDegistir_ItemClick(barDegistir, arg);
            }
        }

        #endregion

        private void repItemButTumYetki_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            gridView1.SetFocusedRowCellValue(colKOPYALA, true);
            gridView1.SetFocusedRowCellValue(colEKLEME, true);
            gridView1.SetFocusedRowCellValue(colDEGIST, true);
            gridView1.SetFocusedRowCellValue(colSILMEK, true);
            gridView1.SetFocusedRowCellValue(colKAYDET, true);
            gridView1.SetFocusedRowCellValue(colGRNTLM, true);
            gridView1.SetFocusedRowCellValue(colPDFGOS, true);
            gridView1.SetFocusedRowCellValue(colEXCGOS, true);
            gridView1.SetFocusedRowCellValue(colYAZDIR, true);
            gridView1.SetFocusedRowCellValue(colCSVGOS, true);
            gridView1.SetFocusedRowCellValue(colXMLGOS, true);
            gridView1.SetFocusedRowCellValue(colDOCGOS, true);
            gridView1.SetFocusedRowCellValue(colGNONAY, true);


        }
        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            FrmOrtamMenu pForm = new FrmOrtamMenu(global);
            pForm._yetkiId = gridView1.GetFocusedRowCellValue(colId).ToInt32();
            pForm.ShowDialog();
         
        }
    }
}