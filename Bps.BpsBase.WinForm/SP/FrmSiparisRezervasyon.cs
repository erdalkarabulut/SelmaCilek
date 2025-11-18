using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using DevExpress.Data.Filtering;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraRichEdit.Import.OpenXml;

namespace BPS.Windows.Forms.SP
{
    public partial class FrmSiparisRezervasyon : DevExpress.XtraEditors.XtraForm
    {
        public Global global;
        public DataSet stokDataSet;
        public SPFBAS spfbas;

        private IStdepoService _stdepoService;
        private ISpfharService _spfharService;
        private ISprezvService _sprezvService;
        private ICrcariService _crcariService;

        private List<SPREZV> _allRezvList;
        private List<SPREZV> _sipRezvList;

        public FrmSiparisRezervasyon(Global global, SPFBAS spfbas)
        {
            this.global = global;
            this.spfbas = spfbas;

            _stdepoService = InstanceFactory.GetInstance<IStdepoService>();
            _spfharService = InstanceFactory.GetInstance<ISpfharService>();
            _sprezvService = InstanceFactory.GetInstance<ISprezvService>();
            _crcariService = InstanceFactory.GetInstance<ICrcariService>();

            InitializeComponent();
        }

        private void FrmSiparisRezervasyon_Load(object sender, EventArgs e)
        {
            CRCARI crcari = _crcariService.Ncch_GetByCariKod_NLog(spfbas.CRKODU, global, false).Nesne;

            lblSiparisNo.Text = spfbas.BELGEN;
            lblSiparisTarihi.Text = spfbas.BELTRH.ToString();
            lblMusteri.Text = spfbas.CRKODU + " - " + (crcari == null ? "" : crcari.CRUNV1);

            GetSiparisRezervasyon();
        }

        public List<SpRezervasyonOzet> GetSiparisRezervasyon(bool showDetails = true)
        {
            _allRezvList = _sprezvService.Ncch_GetAcikList_NLog(global, false).Items;

            GetStokMiktarRapor();

            _sipRezvList = new List<SPREZV>();
            _allRezvList = _sprezvService.Ncch_GetAcikList_NLog(global, false).Items;
            if (_allRezvList.Count > 0)
            {
                _sipRezvList = _allRezvList.FindAll(r => r.SPBLNO == spfbas.BELGEN);
            }

            List<SpRezervasyonOzet> spRezOzetList = new List<SpRezervasyonOzet>();
            List<SPFHAR> spfharList = _spfharService.Cch_GetListByBelge_NLog(spfbas.BELGEN, global).Items;

            foreach (SPFHAR spfhar in spfharList)
            {
                List<SPREZV> sprezvList = _sipRezvList.FindAll(r => r.SATIRN == spfhar.SATIRN && r.STKODU.Contains(spfhar.STKODU));
                List<string> belgeNoList = sprezvList.Select(x => x.BELGEN).Distinct().ToList();

                decimal totalRez = 0;
                List<SPREZV> sprezvModulList = new List<SPREZV>();
                foreach (string belgeNo in belgeNoList)
                {
                    List<SPREZV> list = sprezvList.FindAll(s => s.BELGEN == belgeNo);
                    totalRez += list[0].RZMKTR ?? 0;
                    decimal maxKalan = list.Max(s => s.KLMKTR) ?? 0;
                    SPREZV sr = list[0].ShallowCopy();
                    sr.STKODU = spfhar.STKODU;
                    sr.STKNAM = spfhar.STKNAM;
                    sr.KLMKTR = maxKalan;
                    sprezvModulList.Add(sr);
                }

                DataView dv = new DataView(stokDataSet.Tables[0]);
                dv.RowFilter = "[STKODU] = '" + spfhar.STKODU +  "' AND [DPKODU] = '" + spfhar.CKDEPO + "'";
                DataTable table = dv.ToTable();
                decimal useStok = table.Rows.Count == 0 ? 0 : Convert.ToDecimal(table.Rows[0]["EMNSTK"]);
                decimal rezervableStok = spfhar.GNMKTR.Value - totalRez;

                spRezOzetList.Add(new SpRezervasyonOzet
                {
                    BELGEN = spfhar.BELGEN,
                    SATIRN = spfhar.SATIRN,
                    STKODU = spfhar.STKODU,
                    STKNAM = spfhar.STKNAM,
                    GNACIK = spfhar.GNACIK,
                    SPMKTR = spfhar.GNMKTR,
                    RZMKTR = totalRez,
                    MXRZMK = rezervableStok > useStok ? useStok : rezervableStok,
                    KLMKTR = sprezvModulList.Sum(r=> r.KLMKTR),
                    USESTK = useStok,
                    OLCUKD = spfhar.OLCUKD,
                    CKDEPO = spfhar.CKDEPO,
                    SPREZV = showDetails ? sprezvModulList : null,
                });
            }

            gridRezervasyon.DataSource = spRezOzetList;
            grdVwRezervasyon.BestFitColumns();

            return spRezOzetList;
        }

        private void GetStokMiktarRapor()
        {
            stokDataSet = new DataSet();
            var stokMiktarList = _stdepoService.GetStokMiktarRapor(global).Items;

            if (stokMiktarList != null && stokMiktarList.Count > 0)
            {
                DataTable stokMiktarTable = Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarList);

                DataView dv = new DataView(stokMiktarTable);
                dv.RowFilter = "STMLNM = 'MODÜL'";
                DataTable modulTable = dv.ToTable();
                modulTable.TableName = "ModulTable";
                modulTable.Columns.Add("PARENT", typeof(string));

                foreach (DataRow row in modulTable.Rows)
                {
                    decimal totalRez = 0;
                    string stokKodu = row["STKODU"].ToString();
                    List<SPREZV> rezList = _allRezvList.FindAll(s => s.STKODU.Contains(stokKodu));

                    if (rezList.Count > 0)
                    {
                        List<string> belgeNoList = rezList.Select(x => x.BELGEN).Distinct().ToList();
                        foreach (string belgeNo in belgeNoList)
                        {
                            List<SPREZV> list = rezList.FindAll(s => s.BELGEN == belgeNo);
                            totalRez += list.Max(s => s.KLMKTR) ?? 0;
                        }
                    }

                    decimal usestk = Convert.ToDecimal(row["USESTK"]);
                    row["EMNSTK"] = usestk - totalRez;
                    row["YNSPSV"] = totalRez;
                }

                dv.RowFilter = "STMLNM = 'PAKET'";
                DataTable paketTable = dv.ToTable();
                paketTable.TableName = "PaketTable";
                paketTable.Columns.Add("PARENT", typeof(string));
                for (int i = paketTable.Rows.Count - 1; i > -1; i--)
                {
                    DataRow row = paketTable.Rows[i];
                    string modulKodu = row["STKODU"].ToString().Substring(0, 10);
                    DataRow modulRow = modulTable.AsEnumerable().FirstOrDefault(m => m["STKODU"].ToString() == modulKodu);
                    if (modulRow == null) paketTable.Rows.Remove(row);
                    else
                    {
                        row["PARENT"] = modulKodu;
                        row["EMNSTK"] = modulRow["EMNSTK"];
                        row["YNSPSV"] = modulRow["YNSPSV"];
                    }
                    //bool exists = modulTable.AsEnumerable().Any(c => DataRowExtensions.Field<string>(c, "STKODU").Equals(modulKodu));

                    //if (!exists) paketTable.Rows.Remove(row);
                    //else row["PARENT"] = modulKodu;
                }

                stokDataSet.Tables.Add(modulTable);
                stokDataSet.Tables.Add(paketTable);

                DataColumn keyColumn = stokDataSet.Tables[0].Columns["STKODU"];
                DataColumn keyColumn2 = stokDataSet.Tables[0].Columns["DPKODU"];
                DataColumn foreignKeyColumn = stokDataSet.Tables[1].Columns["PARENT"];
                DataColumn foreignKeyColumn2 = stokDataSet.Tables[1].Columns["DPKODU"];

                DataRelation dr = new DataRelation("Paketler", new[] { keyColumn, keyColumn2 }, new[] { foreignKeyColumn, foreignKeyColumn2 });
                stokDataSet.Relations.Add(dr);

                stdepoStokMiktarModelBindingSource.DataSource = stokDataSet.Tables[0];
                stdepoStokMiktarModelbsPaket.DataSource = stokDataSet.Tables[1];
            }

            grdVwDepoModul.BestFitColumns();
        }

        private void btnRezervasyon_Click(object sender, EventArgs e)
        {
            FrmRezervasyonOnay frmRezervasyonOnay = new FrmRezervasyonOnay();
            frmRezervasyonOnay.frmSiparisRez = this;

            frmRezervasyonOnay.ShowDialog();

            GetSiparisRezervasyon();
        }

        private void checkStok_CheckedChanged(object sender, EventArgs e)
        {
            if (checkStok.Checked) grdVwDepoModul.Columns["USESTK"].FilterInfo = new ColumnFilterInfo("[USESTK] > 0");
            else grdVwDepoModul.Columns["USESTK"].FilterInfo = new ColumnFilterInfo();
        }

        private void checkSiparis_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSiparis.Checked)
            {
                string filter = "";
                for (int i = 0; i < grdVwRezervasyon.RowCount; i++)
                {
                    string stkodu = grdVwRezervasyon.GetRowCellDisplayText(i, "STKODU");

                    if (i == 0) filter = "[STKODU] = '" + stkodu + "'";
                    else filter += " Or [STKODU] = '" + stkodu + "'";
                }

                grdVwDepoModul.Columns["STKODU"].FilterInfo = new ColumnFilterInfo(filter);
            }
            else grdVwDepoModul.Columns["STKODU"].FilterInfo = new ColumnFilterInfo();
        }

        private void FrmSiparisRezervasyon_Resize(object sender, EventArgs e)
        {
            splitContainerControl1.SplitterPosition = Height / 2;
        }

        private void grdVwRezervasyon_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridView dView = view.GetDetailView(e.RowHandle, 0) as GridView;

            if (dView != null)
            {
                dView.ViewCaption = "Aktif Rezervasyonlar";
                dView.Columns["Id"].Visible = false;
                dView.Columns["SIRKID"].Visible = false;
                dView.Columns["SPBLNO"].Visible = false;
                dView.Columns["SPBLTR"].Visible = false;
                dView.Columns["SPMKTR"].Visible = false;
                dView.Columns["ACTIVE"].Visible = false;
                dView.Columns["SLINDI"].Visible = false;
                dView.Columns["DEKULL"].Visible = false;
                dView.Columns["DTARIH"].Visible = false;
                dView.Columns["KYNKKD"].Visible = false;
                dView.Columns["CHKCTR"].Visible = false;
                dView.Columns["ETARIH"].DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
                dView.Columns["ETARIH"].DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
                dView.BestFitColumns();
            }
        }

        private void grdVwDepo_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridView dView = view.GetDetailView(e.RowHandle, 0) as GridView;

            dView.Columns["Id"].Visible = false;
            dView.Columns["MALGKD"].Visible = false;
            dView.Columns["STANKD"].Visible = false;
            dView.Columns["STALKD"].Visible = false;
            dView.Columns["YNSPSV"].Visible = false;
            dView.Columns["MPPRTB"].Visible = false;
            dView.Columns["SAPRTB"].Visible = false;
            dView.Columns["EMNSTK"].Visible = false;
            dView.Columns["SADEGK"].Visible = false;
            dView.Columns["SAOLKD"].Visible = false;
            dView.Columns["PARENT"].Visible = false;
            dView.Columns["STMLNM"].Caption = "Stok Türü";
            dView.Columns["STKODU"].Caption = "Stok Kodu";
            dView.Columns["STKNAM"].Caption = "Stok Adı";
            dView.Columns["USESTK"].Caption = "Stok Miktarı";
            dView.Columns["OLCUKD"].Caption = "Ölçü Birimi";
            dView.Columns["DPKODU"].Caption = "Depo Kodu";
            dView.Columns["DPTANM"].Caption = "Depo Tanımı";

            dView.BestFitColumns();
        }

        private void grdVwRezervasyon_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            decimal sipMiktar = Convert.ToDecimal(grdVwRezervasyon.GetRowCellValue(e.RowHandle, "SPMKTR"));
            decimal rezMiktar = Convert.ToDecimal(grdVwRezervasyon.GetRowCellValue(e.RowHandle, "RZMKTR"));

            if (rezMiktar == 0)
            {
                e.Appearance.BackColor = Color.LightPink;
                e.Appearance.BackColor2 = Color.Transparent;
            }
            else if (sipMiktar == rezMiktar)
            {
                e.Appearance.BackColor = Color.GreenYellow;
                e.Appearance.BackColor2 = Color.Transparent;
            }
            else
            {
                e.Appearance.BackColor = Color.Gold;
                e.Appearance.BackColor2 = Color.Transparent;
            }

            e.HighPriority = true;
        }

        private void grdVwDepo_RowStyle(object sender, RowStyleEventArgs e)
        {
            if (e.RowHandle < 0) return;

            decimal rezMiktar = Convert.ToDecimal(grdVwDepoModul.GetRowCellValue(e.RowHandle, "YNSPSV"));
            decimal useMiktar = Convert.ToDecimal(grdVwDepoModul.GetRowCellValue(e.RowHandle, "EMNSTK"));

            if (useMiktar == 0 && rezMiktar == 0)
            {
                e.Appearance.BackColor = Color.LightPink;
                e.Appearance.BackColor2 = Color.Transparent;
            }
            else if (useMiktar == 0 && rezMiktar > 0)
            {
                e.Appearance.BackColor = Color.Gold;
                e.Appearance.BackColor2 = Color.Transparent;
            }

            e.HighPriority = true;
        }

        private void repButRezervasyonIptal_Click(object sender, EventArgs e)
        {
            SpRezervasyonOzet srOzet = grdVwRezervasyon.GetRow(grdVwRezervasyon.FocusedRowHandle) as SpRezervasyonOzet;
            if (srOzet == null) return;

            if (srOzet.SPREZV != null && srOzet.SPREZV.Count > 0)
            {
                DialogResult Mesaj = MessageBox.Show("İşlem görmeyen tüm rezervasyonlar iptal edilecek. Emin misiniz?", "Rezervasyon İptal", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (Mesaj != DialogResult.Yes) return;

                List<SpRezervasyonOzet> rezList = gridRezervasyon.DataSource as List<SpRezervasyonOzet>;
            }

            

        }
    }
}