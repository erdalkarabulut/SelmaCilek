using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace BPS.Windows.Forms
{
    public partial class FrmUrunAgaciMalzemeTuruTayin : BPS.Windows.Base.FrmChildBase
    {
        public Thread thread;

        private IUamltyService _sinifService;
        private IUakltpService _urunAgacKullanimTipiService;
        private IStmaltService _malzemeTuruTanimService;
        private IGnkxmlService _sinifyerlesimService;
        private readonly IGnyetkService _gnyetkService;
        private ProjeMenuListed yetkiModel;
        private UAMLTY _sinif;
        private GNKXML _sinifyerlesim;

        private static IList<UAMLTY> list;
        private BindingList<UAMLTY> bindingList;
        List<Grid> focusedRowHandler = new List<Grid>();

        private delegate void kaydetDlg(object itemTag);

        public FrmUrunAgaciMalzemeTuruTayin(IUamltyService sinifService, IUakltpService urunAgacKullanimTipiService,
            IStmaltService malzemeTuruTanimService, IGnkxmlService sinifyerlesimService, IGnyetkService gnyetkService)
        {
            InitializeComponent();
            _sinifService = sinifService;
            _urunAgacKullanimTipiService = urunAgacKullanimTipiService;
            _malzemeTuruTanimService = malzemeTuruTanimService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            //_frmWait = new FrmWait();
        }

        private void FrmUrunAgaciMalzemeTuruTayin_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            FormIslemleri.FormYetki2(barManager, yetkiModel);
            LoadData();
            repUAKodu.DataSource = _urunAgacKullanimTipiService.Cch_GetList_NLog(global, false).Items;
            repMalzemeTuru.DataSource = _malzemeTuruTanimService.Cch_GetList_NLog(global, false).Items;
            gridView1.Columns[0].OptionsColumn.AllowEdit = false;
        }

        private void LoadData()
        {
            list = _sinifService.Cch_GetList_NLog(global, false).Items;
            bindingList = new BindingList<UAMLTY>(list);
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

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.Top;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = true;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
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

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Eminmisiniz ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {

                _sinifService.Ncch_Delete_Log(bindingList[Convert.ToInt32(gridView1.GetFocusedDataSourceRowIndex())], global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadData();
                gridView1.RefreshData();
            }
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

        protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                return;
            }

            // Open the Preview window.
            gridView1.ShowPrintPreview();
        }

        protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.OptionsView.ShowAutoFilterRow == false)
            {
                gridView1.OptionsView.ShowAutoFilterRow = true;
            }
            else
            {
                gridView1.OptionsView.ShowAutoFilterRow = false;
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

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
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

        public void kaydet(object itemTag)
        {
            if (InvokeRequired)
            {
                kaydetDlg dlg = new kaydetDlg(kaydet);
                Invoke(dlg, itemTag);
            }
            else
            {
                Validate();

                try
                {
                    foreach (var item in focusedRowHandler)
                    {
                        if (item.Tipi == "Insert")
                        {
                            _sinifService.Ncch_Add_NLog(bindingList[item.Id], global);
                        }

                        if (item.Tipi == "Update")
                        {
                            _sinifService.Ncch_Update_Log(bindingList[item.Id], bindingList[item.Id], global);
                        }
                    }

                    gridView1.RefreshData();
                    focusedRowHandler.Clear();
                    MessageBox.Show("Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Kayıt Yapılamadı " + exception.Message);
                }
                finally
                {
                    gridView1.OptionsBehavior.Editable = false;
                    gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                    FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(itemTag), yetkiModel);
                    //_frmWait.close = true;
                }
            }
        }
    }
}