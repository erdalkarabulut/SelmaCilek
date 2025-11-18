using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SA;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;

namespace BPS.Windows.Forms
{
    public partial class FrmOdemeTablosu : BPS.Windows.Base.FrmChildBase
    {
        public SPFBAS spfbas;
        public double? tutar;

        private ISpodtbService _sinifService;

        private IGnkxmlService _sinifyerlesimService;
        private GNKXML _sinifyerlesim;

        private BindingList<SPODTB> bindingList;
        private BindingList<SPODTB> oldBindingList;

        List<Grid> focusedRowHandler = new List<Grid>();

        private ProjeMenuListed yetkiModel;
        private readonly IGnyetkService _gnyetkService;

        public FrmOdemeTablosu()
        {
            InitializeComponent();
            _sinifService = InstanceFactory.GetInstance<ISpodtbService>();
            _sinifyerlesimService = InstanceFactory.GetInstance<IGnkxmlService>();
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            lblTutar.Text = "Ödenecek Tutar: " + tutar.Value.ToString("n2") + " " + spfbas.DVCNKD;
            //yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            yetkiModel = new ProjeMenuListed();
            yetkiModel.EKLEME = true;
            yetkiModel.DEGIST = true;
            yetkiModel.KAYDET = true;
            yetkiModel.SILMEK = true;
            FormIslemleri.FormYetki2(barManager, yetkiModel);
            GridHelper.ColumnRepositoryItems(gridView1, global);
            LoadGrid();

            //_sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
            //    global.MenuName,
            //    global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
            //if (_sinifyerlesim != null)
            //{
            //    byte[] byteArray = Encoding.ASCII.GetBytes(_sinifyerlesim.GRDXML);
            //    MemoryStream stream = new MemoryStream(byteArray);
            //    gridView1.RestoreLayoutFromStream(stream);
            //}

            //gridView1.Columns[0].OptionsColumn.AllowEdit = false;
        }

        private void LoadGrid()
        {
            var odemeList = _sinifService.Ncch_GetListByBelgeNo_NLog(global, spfbas.BELGEN).Items;
            bindingList = new BindingList<SPODTB>(odemeList);
            oldBindingList = new BindingList<SPODTB>(bindingList.Select(item => item.ShallowCopy()).ToList());
            sPODTBBindingSource.DataSource = bindingList;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            focusedRowHandler.Clear();

            gridView1.Columns["ODMTTR"].Summary.Clear();
            gridView1.Columns["ODMORN"].Summary.Clear();

            GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ODMTTR", "{0:c2}");
            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "ODMORN", "%{0:n2}");
            gridView1.Columns["ODMTTR"].Summary.Add(item1);
            gridView1.Columns["ODMORN"].Summary.Add(item2);
            gridView1.BestFitColumns();

            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
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
                double oran = 0;
                double currentTutar = GetTutar(out oran);
                if (oran > 99.5 && oran < 100.5 && currentTutar != tutar.Value) currentTutar = tutar.Value;

                if (currentTutar > tutar)
                {
                    MessageBox.Show("Girilen ödeme tutarlarının toplamı ödenecek tutarı geçemez!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                StandardResponse<SPODTB> response;
                var bindigSources = sPODTBBindingSource.List;
                var datas = new List<SPODTB>();
                foreach (var bind in bindigSources)
                {
                    var odeme = (SPODTB) bind;
                    if (odeme.ODMTRH == DateTime.Parse("01.01.0001"))
                    {
                        MessageBox.Show("Ödeme tarihi girmeden devam edemezsiniz", "Bilgi", MessageBoxButtons.OK,
                            MessageBoxIcon.Information);
                        return;
                    }
                    datas.Add(odeme);
                }

                var inserted = datas.Where(w => w.Id == 0).ToList();
                foreach (var data in inserted)
                {
                    data.SIRKID = global.SirketId.Value;
                    data.BELGEN = spfbas.BELGEN;
                    data.ACTIVE = true;
                    data.SLINDI = false;
                    data.EKKULL = global.UserKod;
                    data.ETARIH = DateTime.Now;
                    data.KYNKKD = "3";

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
                        data.DEKULL = global.UserKod;
                        data.DTARIH = DateTime.Now;

                        global.IsCompare = true;
                        response = _sinifService.Ncch_Update_Log(data, oldBindingList.FirstOrDefault(f => f.Id == grid.Id), global);
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
                _sinifService.Ncch_DeleteKosul_Log(bindingList[Convert.ToInt32(gridView1.GetFocusedDataSourceRowIndex())], global);
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
            FrmBelgeAkis form = new FrmBelgeAkis(global, "SPFTIP", id);
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
            FrmFileManager form = new FrmFileManager(global, "SPFTIP", id);
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

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["BELGEN"], spfbas.BELGEN);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ODMTRH"], null);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["DVCNKD"], spfbas.DVCNKD);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ACTIVE"], true);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["SPFTNO"], "-");
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["KDVFLG"], false);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["OTVFLG"], false);
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

        private double GetTutar(out double oran)
        {
            oran = 0;
            double toplamTutar = 0;
            foreach (SPODTB spodtb in bindingList)
            {
                toplamTutar += Convert.ToDouble(spodtb.ODMTTR);
                oran += Convert.ToDouble(spodtb.ODMORN);
            }

            return toplamTutar;
        }

        #endregion

        private void gridView1_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            string columnName = gridView1.FocusedColumn.FieldName;
            if (columnName == "ODMTTR" && e.Valid)
            {
                double odeme = Convert.ToDouble(e.Value);
                double oran = odeme / tutar.Value * 100;

                gridView1.SetFocusedRowCellValue("ODMORN", oran);
            }
            else if (columnName == "ODMORN" && e.Valid)
            {
                double oran = 0;
                if (e.Value.ToString() != "") oran = Convert.ToDouble(e.Value);
                double odeme = tutar.Value / 100 * oran;

                gridView1.SetFocusedRowCellValue("ODMTTR", odeme);
            }
        }
    }
}
