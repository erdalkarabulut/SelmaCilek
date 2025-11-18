using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.ST.Enums;
using Bps.Core.Response;
using Bps.Core.Utilities.Helpers;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.Grid;

namespace BPS.Windows.Forms
{
    public partial class FrmStkFiy : Base.FrmChildBase
    {
        private IStkfiyService _sinifService;
        private IGnkxmlService _sinifyerlesimService;
        private STKFIY _sinifyerlesim;
        private ProjeMenuListed yetkiModel;
        private readonly IGnthrkService _gnthrkService;
        private readonly IStkfytService _stkfytService;
        private readonly IStkartService _stkartService;
        private List<GNYETB> ortamModel;
        private readonly IGnyetbService _gnyetbService;

        public FrmStkFiy(IStkfiyService sinifService, IGnkxmlService sinifyerlesimService, IGnthrkService gnthrkService,
                IStkfytService stkfytService, IStkartService stkartService, IGnyetbService gnyetbService)
        {
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnthrkService = gnthrkService;
            _stkfytService = stkfytService;
            _stkartService = stkartService;
            _gnyetbService = gnyetbService;
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            yetkiModel = MenuYetki;
            ortamModel = _gnyetbService.Cch_GetListYetkiId_NLog(yetkiModel.Id, global, false).Items;
            FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);
            LoadStkFyt();
            GridHelper.ColumnRepositoryRenkBedenItems(grdViewStkFiy, global);
            GridHelper.ColumnRepositoryItems(gridView1, global);


            barManager.Bars["Tools"].Visible = false;
            barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;
            //barManager.Items["barOrtam"].Visibility = BarItemVisibility.Never;
            barManager.Items["barFiltre"].Visibility = BarItemVisibility.Never;
            barManager.Items["barListe"].Visibility = BarItemVisibility.Never;
            barManager.Items["barSil"].Visibility = BarItemVisibility.Never;
            barManager.Items["barDegistir"].Visibility = BarItemVisibility.Never;
            barManager.Items["barEkle"].Visibility = BarItemVisibility.Never;
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);

            var teknads = new List<string>() { "SPORKD", "SPDGKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            repLkedsPDGKD.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "SPDGKD").ToList();
            repLkdsPORKD.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "SPORKD").ToList();
            sTHRTPGridLookUpEdit.Properties.DataSource = EnumHelper.GetListItemsFromEnum<HareketTipEnum>();
            repLkdStkFytHareketTip.DataSource = EnumHelper.GetListItemsFromEnum<HareketTipEnum>();
            repLkdStkFiyStokKodu.DataSource = repLkdStkFiyStokKodu2.DataSource = _stkartService.Cch_GetList_NLog(global, false).Items;

            grdViewStkFiy.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grdViewStkFiy.OptionsNavigation.EnterMoveNextColumn = true;
            grdViewStkFiy.OptionsBehavior.Editable = true;
            grdViewStkFiy.OptionsBehavior.ReadOnly = false;
        }

        private void LoadStkFyt()
        {
            sTKFYTBindingSource.DataSource = _stkfytService.Cch_GetList_NLog(global, false).Items;
        }

        private void btnYurut_Click(object sender, System.EventArgs e)
        {
            if (LkEdStkFyt.EditValue == null || LkEdStkFyt.EditValue.ToString() == "") return;

            int stfyno = LkEdStkFyt.EditValue == null ? 0 : Convert.ToInt32(LkEdStkFyt.EditValue);
            if (stfyno == 0)
            {
                MessageBox.Show("Lütfen fiyat tanımı seçiniz! ", "Uyarı");
                return;
            }

            STKFYT stkfyt = LkEdStkFyt.GetSelectedDataRow() as STKFYT;

            if (stkfyt.STHRTP == 0)
            {
                lblSPORKD.Visible = false;
                repLkdsPORKD.Visible = false;
            }

            var stkFiyList = _sinifService.Cch_GetListByStfyno_NLog(global, stfyno, false).Items;
            sTKFIYBindingSource.DataSource = stkFiyList;

            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(1), yetkiModel);
            barManager.Bars["Tools"].Visible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
            bndNvgHareket.Enabled = true;
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            Kaydet(e); 
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            barManager.Bars["Tools"].Visible = false;
            //barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;
            xtraTabControl1.SelectedTabPage = xtraTabPage1;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
        }

        protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!grdControlStHrkt.IsPrintingAvailable)
            {
                MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                return;
            }

            grdViewStkFiy.ShowPrintPreview();
        }
        protected override void barButOrnekDosya_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            STKFIY _stkFiy = new STKFIY();
            GridHelper.ExcelTemplateforEntity(_stkFiy, "STOKFIYAT");
          

        }
        protected override void barButExcelAktar_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (grdViewStkFiy.RowCount > 0)
            {
                MessageBox.Show("Yeni Fiyat Listesine Excelden aktarım yapabilirsiniz");
                return;
            }
            List<STKFIY> stkFiys = GridHelper.LoadExcelToListEntity<STKFIY>();
            e.Item.Tag = 3;
            Kaydet(e,stkFiys);
        }

        private void grdViewStkFiy_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            var stkfyt = (STKFYT)sTKFYTBindingSource.Current;
            if (stkfyt != null)
            {
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["ACTIVE"], true);
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["BASTAR"], stkfyt.BASTAR);
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["BITTAR"], stkfyt.BITTAR);
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["SPDGKD"], stkfyt.SPDGKD);
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["SPORKD"], stkfyt.SPORKD);
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["DVCNKD"], stkfyt.DVCNKD);
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["TANIMI"], stkfyt.TANIMI);
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["STHRTP"], stkfyt.STHRTP);
                grdViewStkFiy.SetRowCellValue(e.RowHandle, grdViewStkFiy.Columns["STFYNO"], stkfyt.STFYNO);
            }
        }

        private void LkEdStkFyt_EditValueChanged(object sender, EventArgs e)
        {
            GridLookUpEdit lookup = sender as GridLookUpEdit;
            BindingManagerBase bm = BindingContext[lookup.Properties.DataSource];
            bm.Position = lookup.Properties.View.GetDataSourceRowIndex(lookup.Properties.GetIndexByKeyValue(lookup.EditValue));
        }

        private void grdViewStkFiy_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {

        }

        private void grdViewStkFiy_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName == "GFIYAT")
            {
                STKFYT stkfyt = sTKFYTBindingSource.Current as STKFYT;
                if (stkfyt != null)
                {
                    if (stkfyt.DVCNKD == "TRY" && e.Value != null) e.DisplayText = (Convert.ToSingle(e.Value)).ToString("f2") + " ₺";
                    if (stkfyt.DVCNKD == "USD" && e.Value != null) e.DisplayText = (Convert.ToSingle(e.Value)).ToString("f2") + " $";
                    if (stkfyt.DVCNKD == "EUR" && e.Value != null) e.DisplayText = (Convert.ToSingle(e.Value)).ToString("f2") + " €";
                }
            }
        }
        private void Kaydet(ItemClickEventArgs e,List<STKFIY> listStkFiys = null)
        {
            this.Validate();
            try
            {
                StandardResponse<STKFIY> response;
                var stkfyt = (STKFYT)sTKFYTBindingSource.Current;
                List<STKFIY> stkFiyList = new List<STKFIY>();
                if (listStkFiys == null)
                {
                    stkFiyList = (List<STKFIY>)sTKFIYBindingSource.List;
                }
                else
                {
                    stkFiyList = listStkFiys;
                }
                 

                if (stkFiyList.Count == 0)
                {
                    MessageBox.Show("Hiç bir kayıt okunamadı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                foreach (STKFIY stkfiy in stkFiyList)
                {
                    //stkfiy.BASTAR = stkfyt.BASTAR;
                    //stkfiy.BITTAR = stkfyt.BITTAR;
                    stkfiy.SPDGKD = stkfyt.SPDGKD;
                    stkfiy.SPORKD = stkfyt.SPORKD;
                    stkfiy.DVCNKD = stkfyt.DVCNKD;
                    stkfiy.TANIMI = stkfyt.TANIMI;
                    if (listStkFiys != null)
                    {
                        stkfiy.BASTAR = stkfyt.BASTAR;
                        stkfiy.BITTAR = stkfyt.BITTAR;
                    }
                    stkfiy.STHRTP = stkfyt.STHRTP;
                    stkfiy.STFYNO = Convert.ToInt32(stkfyt.STFYNO);
                    stkfiy.ACTIVE = true;
                    stkfiy.SLINDI = false;
                }

                response = _sinifService.Ncch_Save_NLog(stkFiyList, stkfyt, global);

                if (response.Status != ResponseStatusEnum.OK)
                {
                    //LoadGrid();
                    FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }


                xtraTabControl1.SelectedTabPage = xtraTabPage1;
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            }
            catch (Exception exception)
            {
                MessageBox.Show("Kayıt Yapılamadı " + exception.Message);
            }
        }
    }
}
