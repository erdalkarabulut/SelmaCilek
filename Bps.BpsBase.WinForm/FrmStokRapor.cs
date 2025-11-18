using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Concrete.WM;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraPrinting.Export.Pdf;

namespace BPS.Windows.Forms
{
    public partial class FrmStokRapor : BPS.Windows.Base.FrmChildBase
    {
        private readonly IStdepoService _stdepoService;
        private readonly ISthbasService _sthbasService;
        private readonly ISthrktService _sthrktService;
        private readonly IGnyetkService _gnyetkService;
        private readonly IGnthrkService _gnthrkService;
        private readonly IStkartService _stokKartService;
        private readonly IStoptmService _stoptmService;
        private readonly IStftipService _stftipService;
        private readonly IWmadrsService _wmadrsService;
        private readonly ICrcariService _crcariService;
        private readonly IUragacService  _uragacService ;
        private readonly IXXService _xxService;

        private ProjeMenuListed yetkiModel;
        private DataTable yssTable = new DataTable();
        private List<TipHareketListModel> stokAnaGrupList = new List<TipHareketListModel>();
        private List<TipHareketListModel> stokAltGrupList = new List<TipHareketListModel>();
        Dictionary<string, RepositoryItemGridLookUpEdit> repositoryList = new Dictionary<string, RepositoryItemGridLookUpEdit>();

        public FrmStokRapor(IStdepoService stdepoService, ISthbasService sthbasService, ISthrktService sthrktService,
            IGnyetkService gnyetkService, IGnthrkService gnthrkService, IStkartService stokKartService, ICrcariService crcariService,
            IStoptmService stoptmService, IStftipService stftipService, IWmadrsService wmadrsService, IXXService xxService, IUragacService uragacService)
        {
            _gnyetkService = gnyetkService;
            _stdepoService = stdepoService;
            _sthbasService = sthbasService;
            _sthrktService = sthrktService;
            _gnthrkService = gnthrkService;
            _stokKartService = stokKartService;
            _stoptmService = stoptmService;
            _stftipService = stftipService;
            _wmadrsService = wmadrsService;
            _crcariService = crcariService;
            _xxService = xxService;
            _uragacService = uragacService;
            InitializeComponent();
        }

        private void FrmStokRapor_Load(object sender, EventArgs e)
        {
            GridHelper gridhelper = new GridHelper();
            dateEdit1.DateTime = DateTime.Now.AddDays(-30);
            dateEdit2.DateTime = DateTime.Now;

            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;

            var teknads = new List<string>() { "MALGKD", "STANKD", "STALKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            repLkedMalGrubu.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
            
            stokAnaGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").ToList();
            stokAltGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();
            repLkedStokAnaGrup.DataSource = stokAnaGrupList;

            foreach (TipHareketListModel tip in stokAnaGrupList)
            {
                var tipHareketList = stokAltGrupList.Where(a => a.PARENT == tip.Id).ToList();
                if (tipHareketList.Count > 0)
                {
                    var repItem = CreateRepositoryItem(tipHareketList);
                    repositoryList.Add(tip.HARKOD, repItem);
                }
            }

            repLkedCari.DataSource = _crcariService.Ncch_GetCariKodAdList_NLog(global,  yetkiKontrol: false).Items;

            gridView2.Columns["MALGKD"].ColumnEdit = repLkedMalGrubu;
            gridView2.Columns["STANKD"].ColumnEdit = repLkedStokAnaGrup;
            gridView2.Columns["STALKD"].ColumnEdit = repLkedStokAltGrup;

            List<WMADRS> adresList = _wmadrsService.Cch_GetAll_NLog(global).Items;
            if (adresList.Count == 0) pageStokAdres.PageVisible = false;

            GridHelper.ColumnRepositoryRenkBedenItems(gridView1, global);

            GetYSS();
            GetUrunAgacRapor();
           
            GetStokMiktarRapor();
        }

        private RepositoryItemGridLookUpEdit CreateRepositoryItem(List<TipHareketListModel> dataSource)
        {
            RepositoryItemGridLookUpEdit repItem = new RepositoryItemGridLookUpEdit();

            repItem.AutoHeight = false;
            repItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            repItem.DisplayMember = "TANIMI";
            repItem.NullText = "";
            repItem.PopupView = this.repositoryItemGridLookUpEdit3View;
            repItem.ValueMember = "HARKOD";
            repItem.DataSource = dataSource;

            return repItem;
        }

        private void SetRepositoryLookups()
        {
            DataTable stkarts = gridControl1.DataSource as DataTable;
            if (stkarts == null || stkarts.Rows.Count == 0) return;

            List<TipHareketListModel> filteredList = new List<TipHareketListModel>();

            DataView dv = new DataView(stkarts);
            dv.RowFilter = "";

            var parentHarkods = dv.ToTable(true, "STANKD"); //stkarts.Select(s => s.STANKD).Distinct().ToList();
            foreach (DataRow row in parentHarkods.Rows)
            {
                string harkod = row["STANKD"].ToString();
                TipHareketListModel anaGrup = stokAnaGrupList.FirstOrDefault(s => s.HARKOD == harkod);
                filteredList.AddRange(stokAltGrupList.Where(s => s.PARENT == anaGrup.Id).ToList());
            }

            repLkedStokAltGrup.DataSource = filteredList;
        }

        private void GetYSS()
        {
            var datas = _stdepoService.GetYenidenSiparisSvy(global).Items;
           
            if (datas != null && datas.Count > 0)
            {
                //var stokMiktarByPartiList = _sthrktService.GetStokMiktarFromHareketByParti(global).Items;

                int topRow = gridView4.TopRowIndex;
                int focusedRow = gridView4.FocusedRowHandle;

                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(datas));
                //dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarByPartiList));

                //DataColumn keyColumn = dataSet.Tables[0].Columns["STKODU"];
                //DataColumn keyColumn2 = dataSet.Tables[0].Columns["DPKODU"];
                //DataColumn foreignKeyColumn = dataSet.Tables[1].Columns["STKODU"];
                //DataColumn foreignKeyColumn2 = dataSet.Tables[1].Columns["DPKODU"];

                //DataRelation dr = new DataRelation("Parti Stok", new[] { keyColumn, keyColumn2 }, new[] { foreignKeyColumn, foreignKeyColumn2 });
                //dataSet.Relations.Add(dr);

                yssTable = dataSet.Tables[0];
                yssTable.Columns.Add("Talep", typeof(bool));

                foreach (DataRow row in yssTable.Rows) row["Talep"] = 0;

                gridControl4.DataSource = null;
                gridControl4.DataSource = yssTable;
                gridControl4.ForceInitialize();
                gridView4.BestFitColumns();

                gridView4.TopRowIndex = topRow;
                gridView4.FocusedRowHandle = focusedRow;

                GridHelper.ColumnRepositoryItems(gridView4, global);
            }
            else
            {
                gridControl4.DataSource = null;
                gridControl4.ForceInitialize();
                gridView4.BestFitColumns();
            }
        }
        private void GetUrunAgacRapor()
        {
            var urunagaclist = _uragacService.Ncch_GetUrunAgaciList_NLog(global).Items;
            gridControl5.DataSource = urunagaclist;
        }
        private void GetStokMiktarRapor()
        {
            GridHelper.ColumnRepositoryRenkBedenItems(gridView1, global);
            var stokMiktarList = _stdepoService.GetStokMiktarRapor(global).Items;

            if (stokMiktarList != null && stokMiktarList.Count > 0)
            {
                DataSet dataSet = new DataSet();
                DataRelation dr;
                int topRow = gridView1.TopRowIndex;
                int focusedRow = gridView1.FocusedRowHandle;
                dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarList));
                if ( ((bool)!global.RenkBeden))
                {
                    var stokMiktarByPartiList = _sthrktService.GetStokMiktarFromHareketByParti(global).Items;

                    
                    dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarByPartiList));

                    DataColumn keyColumn = dataSet.Tables[0].Columns["STKODU"];
                    DataColumn keyColumn2 = dataSet.Tables[0].Columns["DPKODU"];
                    //DataColumn keyColumn3 = dataSet.Tables[0].Columns["URAKOD"];
                    DataColumn foreignKeyColumn = dataSet.Tables[1].Columns["STKODU"];
                    DataColumn foreignKeyColumn2 = dataSet.Tables[1].Columns["DPKODU"];
                    //DataColumn foreignKeyColumn3 = dataSet.Tables[1].Columns["URAKOD"];

                    if ((bool)global.RenkBeden)
                    {
                        DataColumn keyColumn3 = dataSet.Tables[0].Columns["VRKODU"];
                        DataColumn foreignKeyColumn3 = dataSet.Tables[1].Columns["VRKODU"];
                        dr = new DataRelation("Parti Stok", new[] { keyColumn, keyColumn2, keyColumn3 }, new[] { foreignKeyColumn, foreignKeyColumn2, foreignKeyColumn3 });
                    }
                    else
                    {
                        dr = new DataRelation("Parti Stok", new[] { keyColumn, keyColumn2 }, new[] { foreignKeyColumn, foreignKeyColumn2 });
                    }
                    dataSet.Relations.Add(dr);
                }


               
              
               
              
                gridControl1.DataSource = null;
                gridControl1.DataSource = dataSet.Tables[0];
                gridControl1.ForceInitialize();
                gridView1.BestFitColumns();

                gridView1.TopRowIndex = topRow;
                gridView1.FocusedRowHandle = focusedRow;
                SetRepositoryLookups();

            }
           
        }

        private void GetStokAdresRapor()
        {
            int topRow = gridView2.TopRowIndex;
            int focusedRow = gridView2.FocusedRowHandle;

            gridControl2.DataSource = null;

            var stokAdresRapor = _stdepoService.GetStokAdresRapor(global);
            gridControl2.DataSource = stokAdresRapor.Items;
            gridView2.BestFitColumns();

            gridView2.TopRowIndex = topRow;
            gridView2.FocusedRowHandle = focusedRow;
        }

        private void GetStokHareketRapor()
        {
            GridHelper.ColumnRepositoryRenkBedenItems(gridView3, global);
            int topRow = gridView3.TopRowIndex;
            int focusedRow = gridView3.FocusedRowHandle;

            gridControl3.DataSource = null;

            var stokHareketRapor = _sthrktService.GetStokHareketRapor(dateEdit1.DateTime, dateEdit2.DateTime, global);
            gridControl3.DataSource = stokHareketRapor.Items;
            gridView3.BestFitColumns();

            gridView3.TopRowIndex = topRow;
            gridView3.FocusedRowHandle = focusedRow;
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageStokMiktar) GetStokMiktarRapor();
            else if (xtraTabControl1.SelectedTabPage == pageStokAdres) GetStokAdresRapor();
            else if (xtraTabControl1.SelectedTabPage == pageStokHareket) GetStokHareketRapor();
            else if (xtraTabControl1.SelectedTabPage == pageStokYSS) GetYSS();
        }

        protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {
            //DockPanel p1 = dockManager1.AddPanel(DockingStyle.Float);
            //p1.Text = "Panel 1";
            //// ...
            //p1.FloatSize = new Size(100, 150);
            //Point pt = new Point(Screen.PrimaryScreen.WorkingArea.Width - p1.Width,
            //    Screen.PrimaryScreen.WorkingArea.Height - p1.Height);
            //// Move the panel to the bottom right corner of the screen.
            //p1.MakeFloat(pt);
            //return;

            XlsxExportOptionsEx options = new XlsxExportOptionsEx();
            options.ExportType = DevExpress.Export.ExportType.WYSIWYG;

            if (xtraTabControl1.SelectedTabPage == pageStokMiktar)
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
                              DateTime.Now.ToString("dd.MM.yy_HH-mm-ss") + " Stok Rapor.xlsx";
                gridView1.ExportToXlsx(path, options);
                Process.Start(path);
                //ExpandAllRows(gridView1, false);
                return;
                gridView1.OptionsPrint.ExpandAllDetails = true;
                gridView1.ShowPrintPreview();
            }
            else if (xtraTabControl1.SelectedTabPage == pageStokAdres)
            {
                if (!gridControl2.IsPrintingAvailable)
                {
                    MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                    return;
                }

                gridView2.ShowPrintPreview();
            }
            else if (xtraTabControl1.SelectedTabPage == pageStokHareket)
            {
                if (!gridControl3.IsPrintingAvailable)
                {
                    MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                    return;
                }

                gridView3.ShowPrintPreview();
            }
        }

        private void ExpandAllRows(GridView View, bool expand = true)
        {
            View.BeginUpdate();
            try
            {
                int dataRowCount = View.DataRowCount;
                for (int rHandle = 0; rHandle < dataRowCount; rHandle++)
                    View.SetMasterRowExpanded(rHandle, expand);
            }
            finally
            {
                View.EndUpdate();
            }
        }

        protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == pageStokMiktar)
            {
                gridView1.OptionsView.ShowAutoFilterRow = gridView1.OptionsView.ShowAutoFilterRow == false;
            }
            else if (xtraTabControl1.SelectedTabPage == pageStokAdres)
            {
                gridView2.OptionsView.ShowAutoFilterRow = gridView2.OptionsView.ShowAutoFilterRow == false;
            }
            else if (xtraTabControl1.SelectedTabPage == pageStokHareket)
            {
                gridView3.OptionsView.ShowAutoFilterRow = gridView3.OptionsView.ShowAutoFilterRow == false;
            }
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            barYenile_ItemClick(null, null);
        }

        private void gridControl3_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridView3.GridControl.PointToClient(MousePosition);

            GridHitInfo info = gridView3.CalcHitInfo(point);
            if (info.InRow || info.InRowCell)
            {
                string stokKodu = gridView3.GetFocusedRowCellDisplayText("STKODU");

                int rowHandle = gridView1.LocateByValue("STKODU", stokKodu);
                string stokAdi = gridView1.GetRowCellDisplayText(rowHandle, "STKNAM");
                string malzTuru = gridView1.GetRowCellDisplayText(rowHandle, "STMLNM");
                string malGrubu = gridView1.GetRowCellDisplayText(rowHandle, "MALGKD");
                string stokAnaGrup = gridView1.GetRowCellDisplayText(rowHandle, "STANKD");
                string stokAltGrup = gridView1.GetRowCellDisplayText(rowHandle, "STALKD");
                string olcuBirimi = "";
                string saOlcuBirimi = "";

                STKART stkart = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;
                if (stkart != null)
                {
                    olcuBirimi = stkart.OLCUKD;
                    saOlcuBirimi = stkart.SAOLKD;
                }

                FrmStokKartBilgi sForm = new FrmStokKartBilgi();

                sForm.lblStokKodu.Text = stokKodu;
                sForm.lblStokAdi.Text = stokAdi;
                sForm.lblMalzemeTuru.Text = malzTuru;
                sForm.lblMalGrubu.Text = malGrubu;
                sForm.lblAnaGrup.Text = stokAnaGrup;
                sForm.lblAltGrup.Text = stokAltGrup;
                sForm.lblOlcuBirimi.Text = olcuBirimi;
                sForm.lblSaOlcuBirimi.Text = saOlcuBirimi;

                sForm.Location = MousePosition;
                sForm.ShowDialog();
            }
        }

        private void gridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView detailView = gridView1.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;

            detailView.Columns["STKODU"].Caption = "Stok Kodu";
            detailView.Columns["STKNAM"].Caption = "Stok Adı";
            detailView.Columns["GRMKTR"].Caption = "Kullanılabilir Stok";
            detailView.Columns["OLCUKD"].Caption = "Ölçü Birimi";
            detailView.Columns["PARTIN"].Caption = "Parti";
            detailView.Columns["DPKODU"].Caption = "Depo Kodu";
            detailView.Columns["DPTANM"].Caption = "Depo Adı";
        }

        private void barButOptimizasyon_ItemClick(object sender, ItemClickEventArgs e)
        {
            string belgeNo = gridView3.GetFocusedRowCellDisplayText("BELGEN");

            STOPTM stoptm = _stoptmService.Ncch_GetByBelgeNo_NLog(belgeNo, global, false).Nesne;
            if (stoptm != null)
            {
                Optimizasyon optimizasyon = Bps.Core.Utilities.Converters.Convert.Deserialize(stoptm.OPTMZS) as Optimizasyon;
                List<STHRKT> sthrktList = _sthrktService.Ncch_GetListKalemByBelgeNo_NLog(global, stoptm.MCBELG, false).Items;
                if (sthrktList == null) return;

                var form = this.MdiParent.MdiChildren.FirstOrDefault(f => f.Name == "FrmProfilOptimizasyon");

                FrmMain mainForm = this.MdiParent as FrmMain;
                mainForm.barModulAdi.Caption = "";
                mainForm.barMenuTag.Caption = "";
                mainForm.barMenuAdi.Caption = "Profil Optimizasyonu";

                if (form != null) form.Activate();
                else
                {
                    FrmProfilOptimizasyon pForm = new FrmProfilOptimizasyon();
                    pForm.MdiParent = mainForm;
                    pForm.global = global;
                    pForm._stokKodu = sthrktList[0].STKODU;
                    pForm._stokAdi = sthrktList[0].STKNAM;
                    pForm.gecmisOptimizasyon = optimizasyon;
                    pForm.Show();
                }
            }
        }

        private void gridView3_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            //GridView view = sender as GridView;
            //GridToExcel(view.GridControl);

            //return;
            var optimizasyon = gridView3.GetFocusedRowCellValue("OPTMZS");

            if (optimizasyon != null && Convert.ToBoolean(optimizasyon))
            {
                barButOptimizasyon.Visibility = BarItemVisibility.Always;
                barButTersKayitOpt.Visibility = BarItemVisibility.Always;
                barButTersKayitBelge.Visibility = BarItemVisibility.Never;
                barButTersKayitKalem.Visibility = BarItemVisibility.Never;
            }
            else
            {
                barButTersKayitBelge.Visibility = BarItemVisibility.Always;
                barButTersKayitKalem.Visibility = BarItemVisibility.Always;
                barButOptimizasyon.Visibility = BarItemVisibility.Never;
                barButTersKayitOpt.Visibility = BarItemVisibility.Never;
            }

            popContext.ShowPopup(Cursor.Position);
        }

        private void barButTersKayitOpt_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Mesaj = MessageBox.Show("Belgeye bağlı tüm stok hareketleri iptal edilecek. Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj != DialogResult.Yes) return;

            string belgeNo = gridView3.GetFocusedRowCellDisplayText("BELGEN");

            STOPTM stoptm = _stoptmService.Ncch_GetByBelgeNo_NLog(belgeNo, global, false).Nesne;
            if (stoptm != null)
            {
                //STHBAS girisBas = _sthbasService.Ncch_GetByBelgeNo_NLog(stoptm.MGBELG, global, false).Nesne;
                //STHBAS cikisBas = _sthbasService.Ncch_GetByBelgeNo_NLog(stoptm.MCBELG, global, false).Nesne;

                string girisBelgeNo = stoptm.MGBELG;
                string cikisBelgeNo = stoptm.MCBELG;

                BelgeTersKayit(girisBelgeNo);
                BelgeTersKayit(cikisBelgeNo);
            }
        }

        private void barButTersKayitBelge_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Mesaj = MessageBox.Show("Belgeye bağlı tüm stok hareketleri iptal edilecek. Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj != DialogResult.Yes) return;

            string belgeNo = gridView3.GetFocusedRowCellDisplayText("BELGEN");

            if (!string.IsNullOrEmpty(belgeNo)) BelgeTersKayit(belgeNo);
        }

        private void barButTersKayitKalem_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Mesaj = MessageBox.Show("Belgeye bağlı stok hareketi iptal edilecek. Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj != DialogResult.Yes) return;

            string belgeNo = gridView3.GetFocusedRowCellDisplayText("BELGEN");

            if (!string.IsNullOrEmpty(belgeNo)) BelgeTersKayit(belgeNo, true);
        }

        private void BelgeTersKayit(string belgeNo, bool tekKalem = false)
        {
            string tekKlem = tekKalem ? " (tek kalem)" : "";
            var model = new StokHareketModel();

            STHBAS sthbas = _sthbasService.Ncch_GetByBelgeNo_NLog(belgeNo, global, false).Nesne;
            int sthrtp = sthbas.STHRTP == 0 ? 1 : 0;

            int stftno = 0;
            if (sthbas.STFTNO == 4) stftno = 6;
            else if (sthbas.STFTNO == 5) stftno = 6;
            else if (sthbas.STFTNO == 6) stftno = 5;
            else if (sthbas.STFTNO == 7) stftno = 8;
            else if (sthbas.STFTNO == 8) stftno = 7;
            else if (sthbas.STFTNO == 10) stftno = 11;
            else if (sthbas.STFTNO == 11) stftno = 10;
            else if (sthbas.STFTNO == 13) stftno = 6;

            if (sthbas != null)
            {
                STHBAS tersBaslik = sthbas.ShallowCopy();
                tersBaslik.Id = 0;
                tersBaslik.STHRTP = sthrtp;
                tersBaslik.STFTNO = stftno;
                tersBaslik.GRDEPO = sthbas.CKDEPO;
                tersBaslik.CKDEPO = sthbas.GRDEPO;
                tersBaslik.BELTRH = DateTime.Now;
                tersBaslik.DEKULL = null;
                tersBaslik.DTARIH = null;
                tersBaslik.GNACIK = sthbas.BELGEN + " belge no ters kaydı" + tekKlem;

                model.Baslik = tersBaslik;

                model.Kalemler = new List<STHRKT>();
                List<STHRKT> sthrktList = new List<STHRKT>();

                if (tekKalem)
                {
                    int id = gridView3.GetFocusedRowCellValue("Id").ToInt32();
                    var sth = _sthrktService.Ncch_GetById_NLog(id, global, false).Nesne;
                    if (sth != null) sthrktList.Add(sth);
                }
                else sthrktList = _sthrktService.Ncch_GetListKalemByBelgeNo_NLog(global, belgeNo, false).Items;

                foreach (STHRKT sthrkt in sthrktList)
                {
                    STHRKT tersKalem = sthrkt.ShallowCopy();
                    tersKalem.Id = 0;
                    tersKalem.STHRTP = sthrtp;
                    tersKalem.STFTNO = stftno;
                    tersKalem.GRDEPO = sthrkt.CKDEPO;
                    tersKalem.CKDEPO = sthrkt.GRDEPO;
                    tersKalem.BELTRH = DateTime.Now;
                    tersKalem.DEKULL = null;
                    tersKalem.DTARIH = null;

                    model.Kalemler.Add(tersKalem);
                }

                model.KaynakWmAdresList = new List<string>();
                model.HedefWmAdresList = new List<string>();

                List<WMADRS> adresList = _wmadrsService.Ncch_GetByBelgeNo_NLog(global, belgeNo, false).Items;
                adresList = adresList.OrderBy(wmadrs => wmadrs.SATIRN).ToList();
                foreach (var adres in adresList)
                {
                    if (sthrtp == 0) model.HedefWmAdresList.Add(adres.DPADRS);
                    else model.KaynakWmAdresList.Add(adres.DPADRS);
                }

                var response = new StandardResponse();
                STFTIP fisTip = _stftipService.Cch_GetByFisTipNo_NLog(model.Baslik.STFTNO, global, false).Nesne;

                switch (fisTip.FUNCNM)
                {
                    case "Ncch_StokSayim_Log":
                        response = _xxService.Ncch_StokSayim_Log(model, global, false);
                        break;
                    case "Ncch_StokMalGirisCikis_Log":
                        response = _xxService.Ncch_StokMalGirisCikis_Log(model, global, false);
                        break;
                    case "Ncch_StokDepoTransfer_Log":
                        response = _xxService.Ncch_StokDepoTransfer_Log(model, global, false);
                        break;
                    case "Ncch_SasGiris_Log":
                        response = _xxService.Ncch_SasGiris_Log(model, global, false);
                        break;
                }

                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                barYenile_ItemClick(this, null);
                MessageBox.Show(response.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void GridToExcel(GridControl grid)
        {
            GridView view = grid.MainView as GridView;

            if (view.RowCount == 0) return;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\StokRapor_" + DateTime.Now.ToString("dd.MM.yy_HH - mm - ss") + ".xlsx";
            view.ExportToXlsx(filePath);
            Process.Start(filePath);
        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
	        barButImage.AccessibleDescription = "";
            GridView view = sender as GridView;
	        string stkodu = view.GetFocusedRowCellValue("STKODU").ToString();

            STKART stkart = _stokKartService.Ncch_GetByStKod_NLog(stkodu, global, false).Nesne;
	        string imageFolder = AppDomain.CurrentDomain.BaseDirectory + "images\\stok\\" + stkart.STMLTR + "\\";

	        var imageName = stkart.STKODU + ".jpg";
	        var imagePath = imageFolder + imageName;
	        if (File.Exists(imagePath))
	        {
		        barButImage.AccessibleDescription = imagePath;
                popImage.ShowPopup(MousePosition);
	        }

            //GridToExcel(view.GridControl);
        }

        private void gridView4_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (!gridView4.IsLastVisibleRow)
                    gridView4.MoveNext();
                else
                    gridView4.MoveFirst();
            }
        }

        private void gridView4_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            popYss.ShowPopup(Cursor.Position);
        }

        private void btnYssIsaretli_ItemClick(object sender, ItemClickEventArgs e)
        {
            DataView dv = new DataView(yssTable);
            dv.RowFilter = "Talep IS NOT NULL AND Talep <> 0";
            DataTable table = dv.ToTable();

            dv = new DataView(table);
            DataTable depoTable = dv.ToTable(true, "DPKODU");

            var response = new StandardResponse();

            foreach (DataRow row in depoTable.Rows)
            {
                string depo = row["DPKODU"].ToString();
                DataView dtv = new DataView(table);
                dtv.RowFilter = "DPKODU = '" + depo + "'";
                DataTable talepTable = dtv.ToTable();

                var model = new SiparisKayitModel();
                model.Baslik = new SPFBAS
                {
                    Id = 0,
                    SIRKID = global.SirketId.Value,
                    ACTIVE = true,
                    SLINDI = false,
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now,
                    KYNKKD = "3",
                    CHKCTR = false,
                    SPHRTP = 3,
                    SPFTNO = 6,
                    DVCNKD = "TLP",
                    GRDEPO = depo,
                    GNACIK = "YSS Raporudan talep",
                    BELTRH = DateTime.Now
                };

                var harekets = new List<SPFHAR>();
                int satir = 100;
                foreach (DataRow tRow in talepTable.Rows)
                {
                    decimal miktar = Convert.ToDecimal(tRow["SAPRTB"]);

                    var hrk = new SPFHAR();
                    hrk.ACTIVE = true;
                    hrk.SLINDI = false;
                    hrk.SATIRN = satir;
                    hrk.BELGEN = model.Baslik.BELGEN;
                    hrk.BELTRH = model.Baslik.BELTRH;
                    hrk.SPHRTP = model.Baslik.SPHRTP;
                    hrk.SPFTNO = model.Baslik.SPFTNO;
                    hrk.DVCNKD = model.Baslik.DVCNKD;
                    hrk.STKODU = tRow["STKODU"].ToString();
                    hrk.STKNAM = tRow["STKNAM"].ToString();
                    hrk.STFYNO = 0;
                    hrk.GRDEPO = depo;
                    hrk.DVCNKD = "TLP";
                    hrk.GRMKTR = miktar;
                    hrk.GNMKTR = miktar;
                    hrk.KLNMKTR = miktar;
                    hrk.OLCUKD = tRow["OLCUKD"].ToString();
                    hrk.GROLBR = tRow["OLCUKD"].ToString();
                    hrk.MLKBTR = DateTime.Now;
                    harekets.Add(hrk);

                    satir += 100;
                }

                model.Kalems = harekets;

                response = _xxService.Ncch_SiparisKaydet_Log(model, global, false);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            MessageBox.Show("Satınalma talebi oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnYssTumunuSec_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in yssTable.Rows) row["Talep"] = 1;
        }

        private void btnYssSecimTemizle_Click(object sender, EventArgs e)
        {
            foreach (DataRow row in yssTable.Rows) row["Talep"] = 0;
        }

        private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
        {
            //GridView gridView = (GridView)sender;
            //if (e.RowHandle > -1 && e.Column.FieldName == "STALKD")
            //{
            //    string tipHarkod = gridView.GetRowCellValue(e.RowHandle, "STANKD").ToString();
            //    if (repositoryList.ContainsKey(tipHarkod)) e.RepositoryItem = repositoryList[tipHarkod];
            //}
        }

        private void barButImage_ItemClick(object sender, ItemClickEventArgs e)
        {
	        BarButtonItem button = e.Item as BarButtonItem;
	        Process.Start(button.AccessibleDescription);

        }
    }
}
