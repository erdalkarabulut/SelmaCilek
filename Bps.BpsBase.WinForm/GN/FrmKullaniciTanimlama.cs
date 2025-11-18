using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using BPS.Windows.Forms.Utilities;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace BPS.Windows.Forms
{
    public partial class FrmKullaniciTanimlama : Base.FrmChildBase
    {
        private IGnkullService _sinifService;
        private IGnkxmlService _sinifyerlesimService;
        private GNKXML _sinifyerlesim;
        
        private static IList<GNKULL> list;
        private BindingList<GNKULL> bindingList;
        private BindingList<GNKULL> oldBindingList;

        List<Grid> focusedRowHandler = new List<Grid>();
        private ProjeMenuListed yetkiModel;
        private readonly IGnyetkService _gnyetkService;
        private readonly IGnmenuService _gnmenuService;
        private List<GNYETB> ortamModel;
        private readonly IGnyetbService _gnyetbService;

        public FrmKullaniciTanimlama(IGnkullService sinifService, IGnkxmlService sinifyerlesimService, 
            IGnyetkService gnyetkService, IGnmenuService gnmenuService, IGnyetbService gnyetbService)
        {
            InitializeComponent();
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _gnmenuService = gnmenuService;
            _gnyetbService = gnyetbService;
        }

        private void FrmKullaniciTanimlama_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ortamModel = _gnyetbService.Cch_GetListYetkiId_NLog(yetkiModel.Id, global, false).Items;
            FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);

            LoadData();

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
        }

        private void LoadData()
        {
            list = _sinifService.Cch_GetList_NLog(global).Items.Where(k => k.KULKOD != "admin").ToList();
            bindingList = new BindingList<GNKULL>(list);
            oldBindingList = new BindingList<GNKULL>(bindingList.Select(item => item.ShallowCopy()).ToList());
            gNKULLBindingSource.DataSource = bindingList;

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
                StandardResponse<GNKULL> response;
                var bindigSources = gNKULLBindingSource.List;
                var datas = new List<GNKULL>();
                foreach (var bind in bindigSources)
                {
                    datas.Add((GNKULL)bind);
                }

                var inserted = datas.Where(w => w.Id == 0).ToList();
                if (inserted.Count > 0)
                {
                    var menus = _gnmenuService.Cch_GetList_NLog(global, false).Items;
                    if (menus.Count > 0)
                    {
                        menus = menus.Where(w => w.ACTIVE).ToList();
                    }

                    foreach (var data in inserted)
                    {
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        response = _sinifService.Ncch_Add_NLog(data, global);

                        if (response.Status != ResponseStatusEnum.OK)
                        {
                            LoadData();
                            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                            MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }

                        var yetkis = new List<GNYETK>();
                        foreach (var menu in menus)
                        {
                            var model = new GNYETK()
                            {
                                SIRKID = global.SirketId.Value,
                                KYNKKD = global.KaynakKod,
                                ACTIVE = true,
                                SLINDI = false,
                                EKKULL = global.UserKod,
                                ETARIH = DateTime.Now,
                                PROKOD = menu.PROKOD,
                                MNUNAM = menu.MNUNAM,
                                MNUTAG = menu.MNUTAG,
                                KULKOD = data.KULKOD,
                                EKLEME = false,
                                DEGIST = false,
                                KAYDET = false,
                                SILMEK = false,
                                GRNTLM = false,
                                PDFGOS = false,
                                EXCGOS = false,
                                YAZDIR = false,
                                CSVGOS = false,
                                XMLGOS = false,
                                DOCGOS = false,
                                GNONAY = false,
                            };
                            yetkis.Add(model);
                        }

                        _gnyetkService.Ncch_AddMulti_NLog(yetkis, global, false);
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

                LoadData();
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
                LoadData();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            LoadData();
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            LoadData();
        }

        protected override void barOrtamBelgeAkisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id") == null)
            {
                MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            FrmBelgeAkis form = new FrmBelgeAkis(global, "GNKULL", id);
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
            FrmFileManager form = new FrmFileManager(global, "GNKULL", id);
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

        private GNKULL _copysinif;
        protected override void barKopyala_ItemClick(object sender, ItemClickEventArgs e)
        {
            GNKULL sTFTIP = gNKULLBindingSource.Current as GNKULL;
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
                foreach (var property in typeof(GNKULL).GetProperties())
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
            GNKULL _entity = gNKULLBindingSource.Current as GNKULL;
            GridHelper.ExcelTemplateforEntity(_entity);
        }
        protected override void barButExcelAktar_ItemClick(object sender, ItemClickEventArgs e)
        {
            List<GNKULL> datas = GridHelper.LoadExcelToListEntity<GNKULL>();

            StandardResponse<GNKULL> response;
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    var inserted = datas.Where(w => w.Id == 0).ToList();
                    var menus = _gnmenuService.Cch_GetList_NLog(global, false).Items;
                    if (menus.Count > 0)
                    {
                        menus = menus.Where(w => w.ACTIVE).ToList();
                    }
                    foreach (var data in inserted)
                    {
                        data.SIRKID = (int)global.SirketId;
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        response = _sinifService.Ncch_Add_NLog(data, global);

                        if (response.Status != ResponseStatusEnum.OK)
                        {
                            LoadData();
                            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                            MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                        var yetkis = new List<GNYETK>();
                        foreach (var menu in menus)
                        {
                            var model = new GNYETK()
                            {
                                SIRKID = global.SirketId.Value,
                                KYNKKD = global.KaynakKod,
                                ACTIVE = true,
                                SLINDI = false,
                                EKKULL = global.UserKod,
                                ETARIH = DateTime.Now,
                                PROKOD = menu.PROKOD,
                                MNUNAM = menu.MNUNAM,
                                MNUTAG = menu.MNUTAG,
                                KULKOD = data.KULKOD,
                                EKLEME = false,
                                DEGIST = false,
                                KAYDET = false,
                                SILMEK = false,
                                GRNTLM = false,
                                PDFGOS = false,
                                EXCGOS = false,
                                YAZDIR = false,
                                CSVGOS = false,
                                XMLGOS = false,
                                DOCGOS = false,
                                GNONAY = false,
                            };
                            yetkis.Add(model);
                        }

                        _gnyetkService.Ncch_AddMulti_NLog(yetkis, global, false);
                    }
                    LoadData();
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
