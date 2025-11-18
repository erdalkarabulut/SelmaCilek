using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BPS.Windows.Forms
{
    public partial class FrmCariKartAdres : Base.FrmChildBase
    {
        private ICradrsService _cariKartAdresService;
        private ICrcariService _cariKartService;

        private ProjeMenuListed yetkiModel;
        private readonly IGnlkhrService _gnlkhrService;
        private readonly IGntipiService _gntipiService;
        //private List<TipHareketListModel> TeknadsResponse;

        private string _action;
        //private static CRADRS oldData;

        private string _ulkeTipKod, _sehirTipKod, _ilceTipKod, _semtTipKod, _mahalleTipKod;

        public FrmCariKartAdres(ICradrsService cariKartAdresService, ICrcariService cariKartService,
            IGnlkhrService gnlkhrService, IGntipiService gntipiService)
        {
            _cariKartAdresService = cariKartAdresService;
            _cariKartService = cariKartService;
            _gnlkhrService = gnlkhrService;
            _gntipiService = gntipiService;
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            yetkiModel = MenuYetki;
            FormIslemleri.FormYetki2(barManager, yetkiModel);

            _ulkeTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "ULKEKD", false).Nesne.TIPKOD;
            _sehirTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "SEHRKD", false).Nesne.TIPKOD;
            _ilceTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "ILCEKD", false).Nesne.TIPKOD;
            _semtTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "SEMTKD", false).Nesne.TIPKOD;
            _mahalleTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "MAHAKD", false).Nesne.TIPKOD;

            var cariKartList = _cariKartService.Ncch_GetAllActive_NLog(global, false).Items;
            LkEdCariKart.Properties.DataSource = cariKartList;

            var ulkeList = _gnlkhrService.Cch_GetListByTipKod(global, _ulkeTipKod, false).Items;
            LkEdUlke.Properties.DataSource = ulkeList;

            GridHelper.ColumnRepositoryItems(gridView1, global);
            barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }

        private void LkEdCariKart_EditValueChanged(object sender, EventArgs e)
        {
            LoadGrid();
        }

        private void LoadGrid()
        {
            if (LkEdCariKart.EditValue != null)
            {
                string cariKart = LkEdCariKart.EditValue.ToString();
                cRADRSBindingSource.DataSource = _cariKartAdresService.Cch_GetListByCariKod_NLog(global, cariKart, false).Items;
            }
        }

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (LkEdCariKart.EditValue == null || LkEdCariKart.EditValue.ToString() == "") return;

            LkEdSehir.Properties.DataSource = null;
            LkEdSehir.EditValue = null;
            LkEdIlce.Properties.DataSource = null;
            LkEdIlce.EditValue = null;
            LkEdSemt.Properties.DataSource = null;
            LkEdSemt.EditValue = null;
            LkEdMahalle.Properties.DataSource = null;
            LkEdMahalle.EditValue = null;

            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";

            cRADRSBindingSource.AddNew();

            var rowView = (CRADRS)cRADRSBindingSource.Current;
            if (rowView != null)
            {
                rowView.ACTIVE = true;
                rowView.ETARIH = DateTime.Today;
                rowView.EKKULL = global.UserKod;
                rowView.CRKODU = LkEdCariKart.EditValue.ToString();

                rowView.ULKEKD = rowView.SEHRKD = rowView.ILCEKD = rowView.SEMTKD = rowView.MAHAKD = null;
            }

            LkEdUlke.EditValue = null;
            txtAdrTanim.Focus();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";

            txtAdrTanim.Focus();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;

            var data = ((CRADRS)cRADRSBindingSource.Current).ShallowCopy();

            LkEdUlke.EditValue = null;
            LkEdUlke.EditValue = data.ULKEKD;
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            try
            {
                var response = new StandardResponse<CRADRS>();
                cRADRSBindingSource.EndEdit();
                var data = (CRADRS)cRADRSBindingSource.Current;

                data.ULKEKD = LkEdUlke.EditValue.ToString();
                if (data.ULKEKD == "TR")
                {
                    data.SEHRKD = LkEdSehir.EditValue == null ? null : LkEdSehir.EditValue.ToString();
                    data.ILCEKD = LkEdIlce.EditValue == null ? null : LkEdIlce.EditValue.ToString();
                    data.SEMTKD = LkEdSemt.EditValue == null ? null : LkEdSemt.EditValue.ToString();
                    data.MAHAKD = LkEdMahalle.EditValue == null ? null : LkEdMahalle.EditValue.ToString();
                }
                else
                {
                    data.SEHRKD = "";
                    data.ILCEKD = "";
                    data.SEMTKD = "";
                    data.MAHAKD = "";
                }

                if (_action == "insert")
                {
                    List<CRADRS> adresList = _cariKartAdresService.Cch_GetListByCariKod_NLog(global, txtAdrCariKodu.Text).Items;
                    if (adresList.Count == 0) response = _cariKartAdresService.Ncch_AddWithDefaultAdres_NLog(data, global);
                    else response = _cariKartAdresService.Ncch_Add_NLog(data, global);
                }

                if (_action == "update")
                {
                    global.IsCompare = true;
                    response = _cariKartAdresService.Ncch_Update_Log(data, data, global);
                    global.IsCompare = false;
                }

                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                LoadGrid();
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
            }
            catch (Exception ex)
            {
                string errorMessage = ex.GetBaseException().Message;
                MessageBox.Show("Kayıt Yapılamadı " + errorMessage);
            }
        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0 || gridView1.FocusedRowHandle == GridControl.InvalidRowHandle ||
                gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;

            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Emin misiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                cRADRSBindingSource.EndEdit();
                var data = (CRADRS)cRADRSBindingSource.Current;
                _cariKartAdresService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            cRADRSBindingSource.CancelEdit();

            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            //oldData = null;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            cRADRSBindingSource.CancelEdit();

            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            //oldData = null;
        }

        protected override void barOrtamBelgeAkisi_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id") == null)
            {
                MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            FrmBelgeAkis form = new FrmBelgeAkis(global, "CRADRS", id);
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
            FrmFileManager form = new FrmFileManager(global, "CRADRS", id);
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

        private void LkEdUlke_EditValueChanged(object sender, EventArgs e)
        {
            LkEdSehir.EditValue = null;
            LkEdSehir.Properties.DataSource = null;
            //LkEdIlce.Properties.DataSource = null;
            //LkEdIlce.EditValue = null;
            //LkEdSemt.Properties.DataSource = null;
            //LkEdSemt.EditValue = null;
            //LkEdMahalle.Properties.DataSource = null;
            //LkEdMahalle.EditValue = null;

            var tip = LkEdUlke.GetSelectedDataRow() as GNLKHR;
            if (tip == null) return;

            if (LkEdUlke.EditValue != null)
            {
                var data = (CRADRS)cRADRSBindingSource.Current;

                var sehirList = _gnlkhrService.Cch_GetListByTipKodAndParent(global, _sehirTipKod, tip.Id, false).Items;
                LkEdSehir.Properties.DataSource = sehirList;
                if (_action == "update") LkEdSehir.EditValue = data.SEHRKD;
            }
        }

        private void LkEdSehir_EditValueChanged(object sender, EventArgs e)
        {
            LkEdIlce.Properties.DataSource = null;
            LkEdIlce.EditValue = null;
            //LkEdSemt.Properties.DataSource = null;
            //LkEdSemt.EditValue = null;
            //LkEdMahalle.Properties.DataSource = null;
            //LkEdMahalle.EditValue = null;

            var tip = LkEdSehir.GetSelectedDataRow() as GNLKHR;
            if (tip == null) return;

            if (LkEdSehir.EditValue != null)
            {
                var data = (CRADRS)cRADRSBindingSource.Current;

                var ilceList = _gnlkhrService.Cch_GetListByTipKodAndParent(global, _ilceTipKod, tip.Id, false).Items;
                LkEdIlce.Properties.DataSource = ilceList;
                if (_action == "update") LkEdIlce.EditValue = data.ILCEKD;
            }
        }

        private void LkEdUlke_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                LkEdUlke.EditValue = null;
            }
        }

        private void LkEdIlce_EditValueChanged(object sender, EventArgs e)
        {
            LkEdSemt.Properties.DataSource = null;
            LkEdSemt.EditValue = null;
            //LkEdMahalle.Properties.DataSource = null;
            //LkEdMahalle.EditValue = null;

            var tip = LkEdIlce.GetSelectedDataRow() as GNLKHR;
            if (tip == null) return;

            if (LkEdIlce.EditValue != null)
            {
                var data = (CRADRS)cRADRSBindingSource.Current;

                var semtList = _gnlkhrService.Cch_GetListByTipKodAndParent(global, _semtTipKod, tip.Id, false).Items;
                LkEdSemt.Properties.DataSource = semtList;
                if (_action == "update") LkEdSemt.EditValue = data.SEMTKD;
            }
        }

        private void LkEdSemt_EditValueChanged(object sender, EventArgs e)
        {
            //var baseEdit = (BaseEdit)sender;
            //if (baseEdit.OldEditValue.ToString() == "")
            //{
            //    return;
            //}

            LkEdMahalle.Properties.DataSource = null;
            LkEdMahalle.EditValue = null;

            var tip = LkEdSemt.GetSelectedDataRow() as GNLKHR;
            if (tip == null) return;

            if (LkEdSemt.EditValue != null)
            {
                var data = (CRADRS)cRADRSBindingSource.Current;

                var mahalleList = _gnlkhrService.Cch_GetListByTipKodAndParent(global, _mahalleTipKod, tip.Id, false).Items;
                LkEdMahalle.Properties.DataSource = mahalleList;
                if (_action == "update") LkEdMahalle.EditValue = data.MAHAKD;
            }
        }

        private void LkEdMahalle_EditValueChanged(object sender, EventArgs e)
        {
            var tip = LkEdMahalle.GetSelectedDataRow() as GNLKHR;
            if (tip == null) return;
        }

        private void LkEdUlke_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }
    }
}