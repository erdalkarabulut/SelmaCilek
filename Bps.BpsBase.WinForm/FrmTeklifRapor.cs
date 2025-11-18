using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Base;
using BPS.Windows.Forms.SP;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPrinting;

namespace BPS.Windows.Forms
{
    public partial class FrmTeklifRapor : BPS.Windows.Base.FrmChildBase
    {
        private readonly IGnyetkService _gnyetkService;
        private readonly ISpfbasService _spfbasService;
        private readonly IGnthrkService _gnthrkService;
        private readonly IStkartService _stkartService;

        private ProjeMenuListed yetkiModel;
        private List<TipHareketListModel> teklifTuruList;
        private List<TipHareketListModel> urunTipiList;
        private List<TipHareketListModel> durumList;

        public FrmTeklifRapor(IGnyetkService gnyetkService, ISpfbasService spfbasService, IGnthrkService gnthrkService, IStkartService stkartService)
        {
            _gnyetkService = gnyetkService;
            _spfbasService = spfbasService;
            _gnthrkService = gnthrkService;
            _stkartService = stkartService;
            InitializeComponent();
        }

        private void FrmTeklifRapor_Load(object sender, EventArgs e)
        {
            dtBaslangic.EditValue = DateTime.Today.AddDays(-30);
            dtBitis.EditValue = DateTime.Today;

            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;

            var teknads = new List<string>() { "TKTRKD", "SPUTKD", "SPDRKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false).Items;

            teklifTuruList = teknadsResponse.Where(w => w.TEKNAD == "TKTRKD").ToList();
            urunTipiList = teknadsResponse.Where(w => w.TEKNAD == "SPUTKD").ToList();
            durumList = teknadsResponse.Where(w => w.TEKNAD == "SPDRKD").ToList();

            List<STKART> stkarts = _stkartService.Ncch_GetList_NLog(global, false).Items;
            LkEdStokKart.Properties.DataSource = stkarts;

            GetTeklifMasterDetail();
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageMasterDetail) GetTeklifMasterDetail();
        }

        protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {
            XlsxExportOptionsEx options = new XlsxExportOptionsEx();
            options.ExportType = DevExpress.Export.ExportType.WYSIWYG;

            if (xtraTabControl1.SelectedTabPage == pageMasterDetail)
            {
                if (!gridControl1.IsPrintingAvailable)
                {
                    MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                    return;
                }

                //ExpandAllRows(gridView1);
                gridView1.OptionsPrint.ExpandAllDetails = true;
                gridView1.OptionsPrint.PrintDetails = true;
                string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" +
                              DateTime.Now.ToString("dd.MM.yy_HH-mm-ss") + " Teklif Rapor.xlsx";
                gridView1.ExportToXlsx(path, options);
                Process.Start(path);
                //ExpandAllRows(gridView1, false);
                return;
                gridView1.OptionsPrint.ExpandAllDetails = true;
                gridView1.ShowPrintPreview();
            }
        }

        private void GetTeklifMasterDetail(string stokKodu = "")
        {
            string basTarih = dtBaslangic.DateTime.ToString("yyyyMMdd");
            string bitTarih = dtBitis.DateTime.ToString("yyyyMMdd");

            var teklifBaslikList = _spfbasService.Ncch_GetTeklifRaporMasterDetail_NLog<TeklifRaporBaslik>(global, basTarih, bitTarih).Items;

            if (teklifBaslikList != null && teklifBaslikList.Count > 0)
            {
                foreach (TeklifRaporBaslik trb in teklifBaslikList)
                {
                    if (!string.IsNullOrEmpty(trb.TKTRKD))
                    {
                        trb.TKTRKD = teklifTuruList.Find(t => t.HARKOD == trb.TKTRKD).TANIMI;
                    }

                    if (!string.IsNullOrEmpty(trb.SPUTKD))
                    {
                        trb.SPUTKD = urunTipiList.Find(t => t.HARKOD == trb.SPUTKD).TANIMI;
                    }

                    if (!string.IsNullOrEmpty(trb.TKDRKD))
                    {
                        trb.TKDRKD = durumList.Find(t => t.HARKOD == trb.TKDRKD).TANIMI;
                    }
                }

                //var saBaslikAyrintiList = _spfbasService.Ncch_GetSaRaporMasterDetail_NLog<SaRaporBaslikAyrinti>(global, basTarih, bitTarih).Items;
                var teklifKalemList = _spfbasService.Ncch_GetTeklifRaporMasterDetail_NLog<SaRaporKalem>(global, basTarih, bitTarih).Items;

                if (stokKodu != "")
                {
                    List<TeklifRaporBaslik> filteredBaslikList = new List<TeklifRaporBaslik>();

                    List<SaRaporKalem> foundKalemList = teklifKalemList.Where(s => s.STKODU == stokKodu).ToList();
                    foreach (SaRaporKalem kalem in foundKalemList)
                    {
                        filteredBaslikList.Add(teklifBaslikList.FirstOrDefault(s => s.BELGEN == kalem.BELGEN));
                    }

                    teklifBaslikList = filteredBaslikList;
                    teklifKalemList = foundKalemList;
                }

                int topRow = gridView1.TopRowIndex;
                int focusedRow = gridView1.FocusedRowHandle;

                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(teklifBaslikList));
                //dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(saBaslikAyrintiList));
                dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(teklifKalemList));

                //DataColumn keyColumn = dataSet.Tables[0].Columns["CRKODU"];
                DataColumn keyColumn2 = dataSet.Tables[0].Columns["DVCNKD"];
                DataColumn keyColumn3 = dataSet.Tables[0].Columns["BELGEN"];
                //DataColumn foreignKeyColumn = dataSet.Tables[1].Columns["CRKODU"];
                DataColumn foreignKeyColumn2 = dataSet.Tables[1].Columns["DVCNKD"];
                DataColumn foreignKeyColumn3 = dataSet.Tables[1].Columns["BELGEN"];

                DataRelation dr = new DataRelation("Kalemler", new[] { keyColumn2, keyColumn3 }, new[] { foreignKeyColumn2, foreignKeyColumn3 });
                dataSet.Relations.Add(dr);
                //DataRelation dr2 = new DataRelation("Kalemler", new[] { keyColumn3 }, new[] { foreignKeyColumn3 });
                //dataSet.Relations.Add(dr2);

                gridControl1.DataSource = null;
                gridControl1.LevelTree.Nodes.Clear();
                if (gridControl1.Views.Count > 1)
                {
                    for (int i = gridControl1.Views.Count - 1; i > 0; i--) gridControl1.Views[i].Dispose();
                }

                gridControl1.DataSource = dataSet.Tables[0];
                gridControl1.ForceInitialize();
                gridView1.BestFitColumns();

                gridView1.TopRowIndex = topRow;
                gridView1.FocusedRowHandle = focusedRow;

                //Başlık Ayrıntı View
                //GridView ayrintiView = new GridView(gridControl1);
                //gridControl1.LevelTree.Nodes.Add("BaslikAyrinti", ayrintiView);
                //ayrintiView.OptionsBehavior.ReadOnly = true;
                //ayrintiView.OptionsView.EnableAppearanceEvenRow = true;
                //ayrintiView.OptionsView.ShowAutoFilterRow = true;
                //ayrintiView.OptionsView.ShowFooter = true;
                //ayrintiView.ViewCaption = "Başlık Ayrıntı";
                //ayrintiView.PopulateColumns(dataSet.Tables[1]);
                //ayrintiView.Columns["SIRKID"].Visible = false;
                //ayrintiView.Columns["CRKODU"].Visible = false;
                //ayrintiView.Columns["TANIMI"].Caption = "Fiş Tipi";
                //ayrintiView.Columns["BELGEN"].Caption = "Belge No";
                //ayrintiView.Columns["BELTRH"].Caption = "Belge Tarihi";
                //ayrintiView.Columns["TOPBRT"].Caption = "Toplam Brüt Tutar";
                //ayrintiView.Columns["TOPISK"].Caption = "Toplam İskonto";
                //ayrintiView.Columns["TOPTUT"].Caption = "Ara Toplam";
                //ayrintiView.Columns["TOPKDV"].Caption = "Toplam KDV";
                //ayrintiView.Columns["TOPKDT"].Caption = "Toplam Net Tutar";
                //ayrintiView.Columns["DVCNKD"].Caption = "Döviz Cinsi";
                //ayrintiView.Columns["TERTAR"].Caption = "Termin Tarihi";
                //ayrintiView.Columns["FLGKPN"].Caption = "Tamamlandı";
                //ayrintiView.Columns["GNNAME"].Caption = "Yetkili";

                //for (int i = 5; i < 10; i++)
                //{
                //    ayrintiView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                //    ayrintiView.Columns[i].DisplayFormat.FormatString = "n2";
                //}

                //ayrintiView.MasterRowExpanded += AyrintiView_MasterRowExpanded;

                //Kalem View
                GridView kalemView = new GridView(gridControl1);
                gridControl1.LevelTree.Nodes.Add("Kalemler", kalemView);
                kalemView.OptionsBehavior.ReadOnly = true;
                kalemView.OptionsView.EnableAppearanceEvenRow = true;
                kalemView.OptionsView.ShowAutoFilterRow = true;
                kalemView.OptionsView.ShowFooter = true;
                kalemView.ViewCaption = "Kalemler";
                kalemView.PopulateColumns(dataSet.Tables[1]);
                kalemView.Columns["SIRKID"].Visible = false;
                kalemView.Columns["BELGEN"].Visible = false;
                kalemView.Columns["GRDEPO"].Visible = false;
                kalemView.Columns["SATIRN"].Caption = "Satır No";
                kalemView.Columns["STKODU"].Caption = "Stok Kodu";
                kalemView.Columns["STKNAM"].Caption = "Stok Adı";
                kalemView.Columns["PARTIN"].Caption = "Parti No";
                kalemView.Columns["GRMKTR"].Caption = "Çıkış Miktar";
                kalemView.Columns["GROLBR"].Caption = "Çıkış Ölçü Birimi";
                kalemView.Columns["DPTANM"].Caption = "Çıkış Depo";
                kalemView.Columns["GFIYAT"].Caption = "Fiyat";
                kalemView.Columns["GNTUTR"].Caption = "Tutar";
                kalemView.Columns["GISKNT"].Caption = "İskonto";
                kalemView.Columns["VRGORN"].Caption = "KDV";
                kalemView.Columns["DVCNKD"].Caption = "Döviz Cinsi";
                kalemView.Columns["TERTAR"].Caption = "Termin Tarihi";
                kalemView.Columns["FLGKPN"].Caption = "Tamamlandı";

                for (int i = 10; i < 14; i++)
                {
                    kalemView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                    kalemView.Columns[i].DisplayFormat.FormatString = "n2";
                }

                kalemView.MasterRowExpanded += AyrintiView_MasterRowExpanded;
            }
        }

        private void AyrintiView_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            if (e.RowHandle == 0 && ((GridView)view.GetDetailView(e.RowHandle, e.RelationIndex)) != null)
                ((GridView)view.GetDetailView(e.RowHandle, e.RelationIndex)).BestFitColumns();
        }

        private void gridControl1_ViewRegistered(object sender, DevExpress.XtraGrid.ViewOperationEventArgs e)
        {
            GridView view = e.View as GridView;
            if (view != null)
                view.DetailHeight = 1000;
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (gridView1.FocusedRowHandle < 0) return;

            popContext.ShowPopup(MousePosition);
        }

        private void barButTeklif_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mForm = this.ParentForm as FrmMain;
            var elements = mForm.accMenu.GetElements();

            ProjeMenuListed yetki = null;
            Global glbl = null;
            var element = elements.FirstOrDefault(a => a.Text == "Satış Teklifi");
            if (element != null)
            {
                yetki = element.TagInternal as ProjeMenuListed;
                glbl = element.Tag as Global;
            }

            var newForm = CompositionRoot.Resolve<FrmSatisTeklif>();

            newForm.blgNo = gridView1.GetFocusedRowCellValue("BELGEN").ToString();
            newForm.fisTipi = gridView1.GetFocusedRowCellValue("SPFTNO").ToInt32();
            newForm.MdiParent = this.ParentForm;
            newForm.Name = glbl.FormName;
            newForm.Text = glbl.MenuName;
            newForm.SetStatusBarInfo = SetStatusBarInfo;
            newForm.Tag = glbl;
            newForm.global = glbl;
            newForm.MenuYetki = yetki;
            newForm.AccessibleName = glbl.ProjeKod;
            newForm.Show();
        }

        private void LkEdStokKart_EditValueChanged(object sender, EventArgs e)
        {
            string stokKodu = LkEdStokKart.EditValue == null || LkEdStokKart.EditValue.ToString() == ""
                ? ""
                : LkEdStokKart.EditValue.ToString();

            GetTeklifMasterDetail(stokKodu);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            LkEdStokKart.EditValue = null;
        }
    }
}
