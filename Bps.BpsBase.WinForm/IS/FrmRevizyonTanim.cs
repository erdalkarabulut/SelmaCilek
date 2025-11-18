using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.IS;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid;

namespace BPS.Windows.Forms
{
    public partial class FrmRevizyonTanim : BPS.Windows.Base.FrmChildBase
    {
        public Thread thread;

        private IIsrevzService _revizyonTanimService;
        private IGnkxmlService _sinifyerlesimService;
        private IGnevrkService _numaraRevizyonService;
        private IGnkullService _kullaniciService;
        private readonly IGnyetkService _gnyetkService;

        private IList<GNKULL> _kullaniciList;
        private static IList<ISREVZ> list;
        private BindingList<ISREVZ> bindingList;
        private GNKXML _sinifyerlesim;
        private ProjeMenuListed yetkiModel;
        private List<Grid> focusedRowHandler = new List<Grid>();

        private delegate void kaydetDlg(object button);

        public FrmRevizyonTanim(IIsrevzService revizyonTanimService, IGnkxmlService sinifyerlesimService,
            IGnevrkService numaraRevizyonService, IGnkullService kullaniciService, IGnyetkService gnyetkService)
        {
            InitializeComponent();
            _revizyonTanimService = revizyonTanimService;
            _sinifyerlesimService = sinifyerlesimService;
            _numaraRevizyonService = numaraRevizyonService;
            _kullaniciService = kullaniciService;
            _gnyetkService = gnyetkService;
        }

        private void FrmRevizyonTanim_Load(object sender, EventArgs e)
        {
            //_frmWait = new FrmWait();
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;

            FormIslemleri.FormYetki2(barManager, yetkiModel);
            LoadData();
            //gridView1.Columns[0].OptionsColumn.AllowEdit = false;
            repositoryItemDateEdit1.MinValue = DateTime.Today.AddDays(-5);
        }

        private void LoadData()
        {
            list = _revizyonTanimService.Cch_GetList_NLog(global, false).Items;
            _kullaniciList = _kullaniciService.Cch_GetList_NLog(global, false).Items;
            repYaratmaadiLkUp.DataSource = _kullaniciList;
            repDegistirenAdiLkUp.DataSource = _kullaniciList;
            bindingList = new BindingList<ISREVZ>(list);
            gridControl1.DataSource = bindingList;
            _sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
                global.MenuName, global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
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
            Secim = MessageBox.Show("Silmek için  değiştir butonuna basıp satırdaki silindi alanını tıklayıp kaydet yapmalısınız", "Silme İşlemi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            //if (Secim == DialogResult.Yes)
            //{

            //    _revizyonTanimService.Delete(bindingList[Convert.ToInt32(gridView1.GetFocusedDataSourceRowIndex())]);
            //    NavButton btn = (NavButton)sender;
            //    FormIslemleri.ButonKontrol(MenuPane, barModulAdi.Caption, Convert.ToInt32(btn.Tag), Convert.ToInt32(barKullaniciId.Caption), Convert.ToInt32(barMenuTag.Caption), ImageList1);
            //    LoadData();
            //    gridView1.RefreshData();
            //}
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
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

        public void kaydet(object itemTag)
        {
            if (InvokeRequired)
            {
                kaydetDlg dlg = kaydet;
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
                            var evrakmodel = new EvrakNoUretParamModel();
                            evrakmodel.TabloAdi = "ISREVZ";
                            evrakmodel.TeknikAd = "GNREZV";
                            evrakmodel.IslemTur = 0;
                            var evrakResponse = _numaraRevizyonService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

                            if (evrakResponse.Status != ResponseStatusEnum.OK)
                            {
                                MessageBox.Show("İşlem yapılamadı " + evrakResponse.Message);
                                return;
                            }

                            //_numaraRevizyonService.Update(new NumaraRevizyon { Numara = _Numara.ToString(), Id = 1 });
                            bindingList[item.Id].GNREZV = evrakResponse.Nesne ?? "";
                            _revizyonTanimService.Ncch_Add_NLog(bindingList[item.Id], global);
                        }

                        if (item.Tipi == "Update")
                        {
                            _revizyonTanimService.Ncch_Update_Log(bindingList[item.Id], bindingList[item.Id], global);
                        }
                    }
                    gridView1.RefreshData();
                    focusedRowHandler.Clear();
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
                    MessageBox.Show("Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //_frmWait.close = true;
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
            gridXml._kullaniciId = global.UserId.ToString(); //barKullaniciId.Caption;
            gridXml._moduladi = global.ProjeTanim; //barModulAdi.Caption;
            gridXml._menutag = global.MenuTag.ToString(); //barMenuTag.Caption;
            gridXml._gridtag = gridControl1.Tag.ToString();
            gridXml._xml = sr.ReadToEnd();
            GridHelper.gridView_PopupMenuShowing(sender, e, gridXml, gridControl1.Tag.ToString(), gridView1);
        }

        private void gridView1_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridView1.SetRowCellValue(e.RowHandle, gridView1.Columns["BASTAR"], DateTime.Today);
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
    }
}
