using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Transactions;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;
using Exception = System.Exception;

namespace BPS.Windows.Forms
{
    public partial class FrmFisTip : Base.FrmChildBase
    {
        private IStftipService _sinifService;
        private IGnkxmlService _sinifyerlesimService;
        private GNKXML _sinifyerlesim;
        private STFTIP _copysinif;

        private static IList<STFTIP> list;
        private BindingList<STFTIP> bindingList;
        private BindingList<STFTIP> oldBindingList;

        List<Grid> focusedRowHandler = new List<Grid>();
        private ProjeMenuListed yetkiModel;
        private readonly IGnyetkService _gnyetkService;
        private List<GNYETB> ortamModel;
        private readonly IGnyetbService _gnyetbService;

        public FrmFisTip(IStftipService sinifService, IGnkxmlService sinifyerlesimService, IGnyetkService gnyetkService, IGnyetbService gnyetbService)
        {
            InitializeComponent();
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _gnyetbService = gnyetbService;
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ortamModel = _gnyetbService.Cch_GetListYetkiId_NLog(yetkiModel.Id, global, false).Items;
            FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);

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

            //gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            GridHelper.ColumnRepositoryItems(gridView1, global);
        }

        private void LoadGrid()
        {
            list = _sinifService.Cch_GetList_NLog(global).Items;
            bindingList = new BindingList<STFTIP>(list);
            oldBindingList = new BindingList<STFTIP>(bindingList.Select(item => item.ShallowCopy()).ToList());
            sTFTIPBindingSource.DataSource = bindingList;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            focusedRowHandler.Clear();
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
                StandardResponse<STFTIP> response;
                var bindigSources = sTFTIPBindingSource.List;
                var datas = new List<STFTIP>();
                foreach (var bind in bindigSources)
                {
                    datas.Add((STFTIP)bind);
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
            FrmBelgeAkis form = new FrmBelgeAkis(global, "STFTIP", id);
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
            FrmFileManager form = new FrmFileManager(global, "STFTIP", id);
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
            STFTIP sTFTIP = sTFTIPBindingSource.Current as STFTIP;
            _copysinif = sTFTIP.ShallowCopy();
            _copysinif.Id = 0;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            gridView1.InitNewRow -= gridView1_InitNewRow;
            gridView1.InitNewRow += gridView1_InitNewRow;
            gridView1.AddNewRow();
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            GridView view = sender as GridView;

            if (_copysinif != null)
            {
                foreach (var property in typeof(STFTIP).GetProperties())
                {
                    if (view.Columns[property.Name] != null)
                    {
                        view.SetRowCellValue(e.RowHandle, view.Columns[property.Name], property.GetValue(_copysinif));
                    }
                }
                _copysinif = null;
            }
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["ACTIVE"], true);
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["GNEVID"], 0);
        }
        protected override void barButOrnekDosya_ItemClick(object sender, ItemClickEventArgs e)
        {
            STFTIP _entity = sTFTIPBindingSource.Current as STFTIP;
            GridHelper.ExcelTemplateforEntity(_entity);
        }
        protected override void barButExcelAktar_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<STFTIP> datas = GridHelper.LoadExcelToListEntity<STFTIP>();

            StandardResponse<STFTIP> response;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    var inserted = datas.Where(w => w.Id == 0).ToList();
                    foreach (var data in inserted)
                    {
                        data.SIRKID = (int)global.SirketId;
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
                    LoadGrid();
                    FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                    ts.Complete();
                }
                catch (Exception)
                {


                }

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

        #endregion
    }
}