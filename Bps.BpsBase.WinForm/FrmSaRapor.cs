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
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;

namespace BPS.Windows.Forms
{
    public partial class FrmSaRapor : BPS.Windows.Base.FrmChildBase
    {
        private readonly IGnyetkService _gnyetkService;
        private readonly ISpfbasService _spfbasService;
        private readonly IStkartService _stkartService;

        private ProjeMenuListed yetkiModel;
        private List<SaRaporBaslik> saRaporBaslikList;
        private List<SaRaporBaslikAyrinti> saRaporBaslikAyrintiList;
        private List<SaRaporKalem> saRaporKalemList;

        public FrmSaRapor(IGnyetkService gnyetkService, ISpfbasService spfbasService, IStkartService stkartService)
        {
            _gnyetkService = gnyetkService;
            _spfbasService = spfbasService;
            _stkartService = stkartService;
            InitializeComponent();
        }

        private void FrmSaRapor_Load(object sender, EventArgs e)
        {
            dtBaslangic.EditValue = DateTime.Today.AddDays(-30);
            dtBitis.EditValue = DateTime.Today;

            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;

            List<STKART> stkarts = _stkartService.Ncch_GetList_NLog(global, false).Items;
            LkEdStokKart.Properties.DataSource = stkarts;

            GetSaRapor();
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageMasterDetail) GetSaRapor();
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
                              DateTime.Now.ToString("dd.MM.yy_HH-mm-ss") + " Satınalma Rapor.xlsx";
                gridView1.ExportToXlsx(path, options);
                Process.Start(path);
                //ExpandAllRows(gridView1, false);
                return;
                gridView1.OptionsPrint.ExpandAllDetails = true;
                gridView1.ShowPrintPreview();
            }
        }

        private void GetSaRapor(string stokKodu = "")
        {
            DataSet dataSet = new DataSet();

            if (stokKodu == "")
            {
                LkEdStokKart.EditValue = null;
                string basTarih = dtBaslangic.DateTime.ToString("yyyyMMdd");
                string bitTarih = dtBitis.DateTime.ToString("yyyyMMdd");

                saRaporBaslikList = _spfbasService.Ncch_GetSaRaporMasterDetail_NLog<SaRaporBaslik>(global, basTarih, bitTarih).Items;

                if (saRaporBaslikList != null && saRaporBaslikList.Count > 0)
                {
                    saRaporBaslikAyrintiList = _spfbasService.Ncch_GetSaRaporMasterDetail_NLog<SaRaporBaslikAyrinti>(global, basTarih, bitTarih).Items;
                    saRaporKalemList = _spfbasService.Ncch_GetSaRaporMasterDetail_NLog<SaRaporKalem>(global, basTarih, bitTarih).Items;

                    dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(saRaporBaslikList));
                    dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(saRaporBaslikAyrintiList));
                    dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(saRaporKalemList));
                }
            }
            else
            {
                List<SaRaporBaslik> raporBaslikList = new List<SaRaporBaslik>();
                List<SaRaporBaslikAyrinti> baslikAyrintiList = new List<SaRaporBaslikAyrinti>();
                List<SaRaporKalem> kalemList = new List<SaRaporKalem>();

                List<SaRaporKalem> foundKalemList = saRaporKalemList.Where(s => s.STKODU == stokKodu).ToList();
                foreach (SaRaporKalem kalem in foundKalemList)
                {
                    kalemList.AddRange(saRaporKalemList.Where(s => s.BELGEN == kalem.BELGEN).ToList());
                    baslikAyrintiList.AddRange(saRaporBaslikAyrintiList.Where(s => s.BELGEN == kalem.BELGEN).ToList());
                }

                foreach (SaRaporBaslikAyrinti baslikAyrinti in baslikAyrintiList)
                {
                    List<SaRaporBaslik> baslikList =
                        saRaporBaslikList.Where(s => s.CRKODU == baslikAyrinti.CRKODU).ToList();
                    List<SaRaporBaslik> cloneList = new List<SaRaporBaslik>();
                    foreach (SaRaporBaslik baslik in baslikList)
                    {
                        var newBaslik = baslik.ShallowCopy();
                        newBaslik.TLFIYT = 0;
                        newBaslik.TOPKDT = 0;

                        cloneList.Add(newBaslik);
                    }

                    raporBaslikList.AddRange(cloneList);
                }

                DataView dv = new DataView(Bps.Core.Utilities.Converters.Convert.ListToDataTable(raporBaslikList));
                dataSet.Tables.Add(dv.ToTable(true));
                dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(baslikAyrintiList));
                dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(kalemList));

            }

            if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
            {
                DataColumn keyColumn = dataSet.Tables[0].Columns["CRKODU"];
                DataColumn keyColumn2 = dataSet.Tables[0].Columns["DVCNKD"];
                DataColumn keyColumn3 = dataSet.Tables[1].Columns["BELGEN"];
                DataColumn foreignKeyColumn = dataSet.Tables[1].Columns["CRKODU"];
                DataColumn foreignKeyColumn2 = dataSet.Tables[1].Columns["DVCNKD"];
                DataColumn foreignKeyColumn3 = dataSet.Tables[2].Columns["BELGEN"];

                DataRelation dr = new DataRelation("BaslikAyrinti", new[] { keyColumn, keyColumn2 }, new[] { foreignKeyColumn, foreignKeyColumn2 });
                dataSet.Relations.Add(dr);
                DataRelation dr2 = new DataRelation("Kalemler", new[] { keyColumn3 }, new[] { foreignKeyColumn3 });
                dataSet.Relations.Add(dr2);

                CreateMasterDetailView(dataSet);
            }
        }

        private void CreateMasterDetailView(DataSet dataSet)
        {
            int topRow = gridView1.TopRowIndex;
            int focusedRow = gridView1.FocusedRowHandle;

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
            GridView ayrintiView = new GridView(gridControl1);
            ayrintiView.Name = "BaslikAyrinti";
            gridControl1.LevelTree.Nodes.Add("BaslikAyrinti", ayrintiView);
            ayrintiView.OptionsBehavior.ReadOnly = true;
            ayrintiView.OptionsView.EnableAppearanceEvenRow = true;
            ayrintiView.OptionsView.ShowAutoFilterRow = true;
            ayrintiView.OptionsView.ShowFooter = true;
            ayrintiView.ViewCaption = "Başlık Ayrıntı";
            ayrintiView.PopulateColumns(dataSet.Tables[1]);
            ayrintiView.Columns["SIRKID"].Visible = false;
            ayrintiView.Columns["CRKODU"].Visible = false;
            ayrintiView.Columns["SPFTNO"].Visible = false;
            ayrintiView.Columns["TANIMI"].Caption = "Fiş Tipi";
            ayrintiView.Columns["BELGEN"].Caption = "Belge No";
            ayrintiView.Columns["BELTRH"].Caption = "Belge Tarihi";
            ayrintiView.Columns["TOPBRT"].Caption = "Toplam Brüt Tutar";
            ayrintiView.Columns["TOPISK"].Caption = "Toplam İskonto";
            ayrintiView.Columns["TOPTUT"].Caption = "Ara Toplam";
            ayrintiView.Columns["TOPKDV"].Caption = "Toplam KDV";
            ayrintiView.Columns["TOPKDT"].Caption = "Toplam Net Tutar";
            ayrintiView.Columns["DVCNKD"].Caption = "Döviz Cinsi";
            ayrintiView.Columns["TLFIYT"].Caption = "Toplam Net Tutar (TL)";
            ayrintiView.Columns["DVBRFY"].Caption = "Döviz Birim Fiyat";
            ayrintiView.Columns["TERTAR"].Caption = "Termin Tarihi";
            ayrintiView.Columns["FLGKPN"].Caption = "Tamamlandı";
            ayrintiView.Columns["GNNAME"].Caption = "Yetkili";

            ayrintiView.Columns["TOPKDT"].DisplayFormat.FormatType = FormatType.Numeric;
            ayrintiView.Columns["TOPKDT"].DisplayFormat.FormatString = "n2";
            ayrintiView.Columns["TLFIYT"].DisplayFormat.FormatType = FormatType.Numeric;
            ayrintiView.Columns["TLFIYT"].DisplayFormat.FormatString = "n2";
            ayrintiView.OptionsView.ShowGroupPanel = false;
            ayrintiView.PopupMenuShowing += AyrintiView_PopupMenuShowing;

            for (int i = 6; i < 11; i++)
            {
                ayrintiView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                ayrintiView.Columns[i].DisplayFormat.FormatString = "n2";
            }

            ayrintiView.MasterRowExpanded += AyrintiView_MasterRowExpanded;

            //Kalem View
            GridView kalemView = new GridView(gridControl1);
            gridControl1.LevelTree.Nodes[0].Nodes.Add("Kalemler", kalemView);
            kalemView.OptionsBehavior.ReadOnly = true;
            kalemView.OptionsView.EnableAppearanceEvenRow = true;
            kalemView.OptionsView.ShowAutoFilterRow = true;
            kalemView.OptionsView.ShowFooter = true;
            kalemView.ViewCaption = "Kalemler";
            kalemView.PopulateColumns(dataSet.Tables[2]);
            kalemView.Columns["SIRKID"].Visible = false;
            kalemView.Columns["BELGEN"].Visible = false;
            kalemView.Columns["GRDEPO"].Visible = false;
            kalemView.Columns["SATIRN"].Caption = "Satır No";
            kalemView.Columns["STKODU"].Caption = "Stok Kodu";
            kalemView.Columns["STKNAM"].Caption = "Stok Adı";
            kalemView.Columns["PARTIN"].Caption = "Parti No";
            kalemView.Columns["GRMKTR"].Caption = "Giriş Miktar";
            kalemView.Columns["GROLBR"].Caption = "Giriş Ölçü Birimi";
            kalemView.Columns["DPTANM"].Caption = "Giriş Depo";
            kalemView.Columns["GFIYAT"].Caption = "Fiyat";
            kalemView.Columns["GNTUTR"].Caption = "Tutar";
            kalemView.Columns["DVZFYT"].Caption = "Tutar (TL)";
            kalemView.Columns["GISKNT"].Caption = "İskonto";
            kalemView.Columns["VRGORN"].Caption = "KDV";
            kalemView.Columns["DVCNKD"].Caption = "Döviz Cinsi";
            kalemView.Columns["TERTAR"].Caption = "Termin Tarihi";
            kalemView.Columns["FLGKPN"].Caption = "Tamamlandı";
            kalemView.OptionsView.ShowGroupPanel = false;

            for (int i = 10; i < 14; i++)
            {
                kalemView.Columns[i].DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
                kalemView.Columns[i].DisplayFormat.FormatString = "n2";
            }

            kalemView.MasterRowExpanded += AyrintiView_MasterRowExpanded;

        }

        private void AyrintiView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            GridHitInfo info = e.HitInfo;
            if (info.InRow || info.InRowCell)
            {
                if (info.RowHandle < 0) return;
            }

            popSaAyrinti.ShowPopup(MousePosition);
        }

        private void barButSaSiparis_ItemClick(object sender, ItemClickEventArgs e)
        {
            var mForm = this.ParentForm as FrmMain;
            var elements = mForm.accMenu.GetElements();

            ProjeMenuListed yetki = null;
            Global glbl = null;
            var element = elements.FirstOrDefault(a => a.Text == "Satın Alma Siparişi");
            if (element != null)
            {
                yetki = element.TagInternal as ProjeMenuListed;
                glbl = element.Tag as Global;
                glbl.Sira = 0;
            }

            ColumnView detailView = (ColumnView)gridView1.GetDetailView(gridView1.FocusedRowHandle, 0);
            int detailRowHandle = detailView.FocusedRowHandle;
            DataRow row = detailView.GetDataRow(detailRowHandle);

            var newForm = CompositionRoot.Resolve<FrmSiparis>();

            newForm.blgNo = row["BELGEN"].ToString();
            newForm.fisTipi = row["SPFTNO"].ToInt32();
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

        private void btnClear_Click(object sender, EventArgs e)
        {
            LkEdStokKart.EditValue = null;
        }

        private void LkEdStokKart_EditValueChanged(object sender, EventArgs e)
        {
            string stokKodu = LkEdStokKart.EditValue == null || LkEdStokKart.EditValue.ToString() == ""
                ? ""
                : LkEdStokKart.EditValue.ToString();

            GetSaRapor(stokKodu);
        }
    }
}
