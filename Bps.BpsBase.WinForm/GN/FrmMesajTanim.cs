using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace BPS.Windows.Forms
{
    public partial class FrmMesajTanim : BPS.Windows.Base.FrmChildBase
    {
        private IGnmesjService _sinifService;
        private GNMESJ _sinif;

        private IGnkxmlService _sinifyerlesimService;
        private GNKXML _sinifyerlesim;

        private static IList<GNMESJ> list;
        private BindingList<GNMESJ> bindingList;

        List<Grid> focusedRowHandler = new List<Grid>();
        private FrmWait _frmWait;
        public Thread thread;
        private ProjeMenuListed yetkiModel;
        private readonly IGnyetkService _gnyetkService;

        private delegate void kaydetDlg(object button);

        public FrmMesajTanim(IGnmesjService sinifService, IGnkxmlService sinifyerlesimService, IGnyetkService gnyetkService)
        {
            InitializeComponent();
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _frmWait = new FrmWait();
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            FormIslemleri.FormYetki2(barManager, yetkiModel);
            LoadData();
            //gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            GridHelper.ColumnRepositoryItems(gridView1, global);
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }

        private void LoadData()
        {
            list = _sinifService.Cch_GetList_NLog(global).Items;
            bindingList = new BindingList<GNMESJ>(list);
            gridControl1.DataSource = bindingList;
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

        private void gridView1_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            var a = focusedRowHandler.Find(x => x.Id == e.RowHandle);
            if (e.RowHandle >= 0)
            {
                if (a == null)
                {
                    focusedRowHandler.Add(new Grid(e.RowHandle, "Update"));
                }
            }
        }

        private void gridView1_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (view.IsNewItemRow(e.RowHandle))
            {
                var a = focusedRowHandler.Find(x => x.Id == e.RowHandle);
                if (a == null)
                {
                    int _rowcount = gridView1.RowCount;
                    if (view.IsNewItemRow(e.RowHandle))
                    {
                        focusedRowHandler.Add(new Grid(_rowcount, "Insert"));
                    }
                }
            }
        }

        #region Menu elements

        protected override void barOrtamEk_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id") == null)
            {
                MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            FrmFileManager form = new FrmFileManager(global, "GNMESJ", id);
            form.ShowDialog();
        }

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            gridView1.RefreshData();
            focusedRowHandler.Clear();
            LoadData();
        }

        public void kaydet(object itemTag)
        {
            if (this.InvokeRequired)
            {
                kaydetDlg dlg = new kaydetDlg(kaydet);
                this.Invoke(dlg, itemTag);
            }
            else
            {
                this.Validate();
                try
                {
                    var response = new StandardResponse<GNMESJ>();
                    foreach (var item in focusedRowHandler)
                    {
                        switch (item.Tipi)
                        {
                            case "Insert":
                                response = _sinifService.Ncch_Add_NLog(bindingList[item.Id], global);
                                break;
                            case "Update":
                                response = _sinifService.Ncch_Update_Log(bindingList[item.Id], bindingList[item.Id], global);
                                break;
                        }
                    }

                    if (response.Status != ResponseStatusEnum.OK)
                    {
                        MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                    else
                    {
                        gridView1.RefreshData();
                        focusedRowHandler.Clear();

                        gridView1.OptionsBehavior.Editable = false;
                        gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                        FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
                        //MessageBox.Show("Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        _frmWait.close = true;
                    }

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Kayıt Yapılamadı " + exception.Message);

                }
                finally
                {
                    
                }
            }
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            thread = new Thread(kaydet);
            thread.IsBackground = true;
            thread.Start(e.Item.Tag);
            //_frmWait.thread = thread;

            //_frmWait.Top = (this.Top + (this.Height / 2) - (_frmWait.Height / 2));
            //_frmWait.Left = this.Left + (this.Width / 2) - (_frmWait.Width / 2);
            //_frmWait.parameter = sender;
            //_frmWait.Show();
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
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
                gridView1.RefreshData();
            }
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

        #endregion

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
    }
}
