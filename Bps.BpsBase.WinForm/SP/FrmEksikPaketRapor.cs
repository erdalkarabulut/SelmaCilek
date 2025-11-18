using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.Core.GlobalStaticsVariables;
using BPS.Windows.Forms.SP;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraPivotGrid;

namespace BPS.Windows.Forms
{
    public partial class FrmEksikPaketRapor : BPS.Windows.Base.FrmChildBase
    {
        private bool tumPaketler;
        private readonly ISpfharService _spfharService;


        public FrmEksikPaketRapor(Global global)
        {
	        this.global = global;
            InitializeComponent();
            _spfharService = InstanceFactory.GetInstance<ISpfharService>();
        }

        private void FrmEksikPaketRapor_Load(object sender, EventArgs e)
        {
            GetData();
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            GetData();
        }

        private void GetData()
        {
            List<SiparisPaketIhtiyac> paketIhtiyacList = _spfharService.Ncch_GetSiparisPaketIhtiyacList_NLog(global, false).Items;

            if (paketIhtiyacList == null || paketIhtiyacList.Count == 0) return;

            //Termin Süresi Bazlı

            List<SiparisPaketIhtiyac> paketStokList = paketIhtiyacList
	            .Select(p => new SiparisPaketIhtiyac { PKKODU = p.PKKODU, PKTNAM = p.PKTNAM, USESTK = p.USESTK })
	            .Distinct().OrderBy(p => p.PKKODU)
	            .ToList();

            List<SiparisPaketIhtiyac> paketBazliList = new List<SiparisPaketIhtiyac>();

            foreach (SiparisPaketIhtiyac paketIhtiyac in paketIhtiyacList)
            {
	            SiparisPaketIhtiyac paketStok = paketStokList.FirstOrDefault(p => p.PKKODU == paketIhtiyac.PKKODU);
	            decimal fark = paketStok.USESTK - paketIhtiyac.IHTIYC;
	            if (paketIhtiyac.IHTIYC < 0) fark = 0;

	            if (fark >= 0)
	            {
		            if (paketIhtiyac.IHTIYC >= 0)
		            {
			            paketStok.USESTK -= paketIhtiyac.IHTIYC;
			            paketIhtiyac.IHTIYC = 0;
		            }
	            }
	            else
	            {
		            paketStok.USESTK = 0;
		            paketIhtiyac.IHTIYC = fark;
	            }

	            paketIhtiyac.USESTK = paketStok.USESTK;

	            paketBazliList.Add(paketIhtiyac.ShallowCopy());
            }

            if (!tumPaketler)
            {
	            paketIhtiyacList = paketIhtiyacList.Where(p => p.IHTIYC < 0 || (p.EKSIKK > 0 && p.EKSIKK - p.PLNMKT == 0)).ToList();
	            paketBazliList = paketBazliList.Where(p => p.IHTIYC < 0 || (p.EKSIKK > 0 && p.EKSIKK - p.PLNMKT == 0)).ToList();

            }

            paketBazliList.ForEach(f => f.IHTIYC *= (-1));
            paketIhtiyacList.ForEach(f => f.IHTIYC *= (-1));

            siparisPaketIhtiyacBindingSource.DataSource = paketIhtiyacList;
            gridView1.BestFitColumns();

            //Paket Bazlı

            List<SiparisPaketIhtiyac> paketBazliSumList = paketBazliList
                .GroupBy(s => new { s.MDKODU, s.MDLNAM, s.PKKODU, s.PKTNAM, s.OLCUKD })
                .Select(group => new SiparisPaketIhtiyac
                {
                    MDKODU = group.Key.MDKODU,
                    MDLNAM = group.Key.MDLNAM,
                    PKKODU = group.Key.PKKODU,
                    PKTNAM = group.Key.PKTNAM,
                    OLCUKD = group.Key.OLCUKD,
                    SPMKTR = group.Sum(item => item.SPMKTR),
                    KLNMKTR = group.Sum(item => item.KLNMKTR),
                    RZMKTR = group.Sum(item => item.RZMKTR),
                    RZKLMK = group.Sum(item => item.RZKLMK),
                    EKSIKK = group.Sum(item => item.EKSIKK),
                    PLNMKT = group.Sum(item => item.PLNMKT),
                    IHTIYC = group.Sum(item => item.IHTIYC),
                }).OrderBy(o => o.PKTNAM).ToList();

            //gridControl2.DataSource = paketBazliSumList;
            //gridView3.BestFitColumns();

            DataSet dataSet = new DataSet();
            dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(paketBazliSumList));
            dataSet.Tables[0].TableName = "Paket";
            dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(paketBazliList));
            dataSet.Tables[1].TableName = "Musteri";

            DataColumn keyColumn = dataSet.Tables[0].Columns["PKKODU"];
            DataColumn foreignKeyColumn = dataSet.Tables[1].Columns["PKKODU"];

            DataRelation dr = new DataRelation("Sipariş", new[] { keyColumn }, new[] { foreignKeyColumn });
            dataSet.Relations.Add(dr);

            gridControl2.DataSource = null;
            gridControl2.DataSource = dataSet.Tables[0];
            gridView3.BestFitColumns();

            //Paket Bazlı Pivot
            CreatePivotFields(paketBazliSumList);

            SetButtonColor();
        }

        private void CreatePivotFields(List<SiparisPaketIhtiyac> paketBazliSumList)
        {
	        List<SiparisPaketIhtiyac> paketBazliPivotList = new List<SiparisPaketIhtiyac>();
	        foreach (SiparisPaketIhtiyac paketIhtiyac in paketBazliSumList)
	        {
		        SiparisPaketIhtiyac sp = paketIhtiyac.ShallowCopy();
		        sp.PKTNAM =
			        "P" + Convert.ToInt32(paketIhtiyac.PKKODU.Substring(paketIhtiyac.PKKODU.Length - 2)).ToString();
		        if (sp.IHTIYC > 0) paketBazliPivotList.Add(sp);
	        }

	        pivotGridControl1.DataSource = paketBazliPivotList;

	        pivotGridControl1.Fields.Clear();

            PivotGridField modulKodu = new PivotGridField("MDKODU", DevExpress.XtraPivotGrid.PivotArea.RowArea)
	        {
		        Caption = "Modül Kodu"
            };
	        pivotGridControl1.Fields.Add(modulKodu);

	        PivotGridField modulAdi = new PivotGridField("MDLNAM", DevExpress.XtraPivotGrid.PivotArea.RowArea)
	        {
		        Caption = "Modül Adı"
	        };
	        pivotGridControl1.Fields.Add(modulAdi);

            PivotGridField paketNo = new PivotGridField("PKTNAM", DevExpress.XtraPivotGrid.PivotArea.ColumnArea)
	        {
		        Caption = "Paket No"
            };
	        pivotGridControl1.Fields.Add(paketNo);

	        PivotGridField eksikMiktar = new PivotGridField("IHTIYC", DevExpress.XtraPivotGrid.PivotArea.DataArea)
	        {
		        Caption = "Eksik Paket",
            };

	        eksikMiktar.CellFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
	        eksikMiktar.CellFormat.FormatString = "0";

            pivotGridControl1.Fields.Add(eksikMiktar);
	        pivotGridControl1.BestFitRowArea();

            //PivotGridField fieldSaleDate = new PivotGridField("SaleDate", DevExpress.XtraPivotGrid.PivotArea.FilterArea)
            //{
            // Caption = "Sale Date"
            //};
            //pivotGridControl1.Fields.Add(fieldSaleDate);
        }

        private void btnTumPaketler_Click(object sender, EventArgs e)
        {
            tumPaketler = true;
            GetData();
        }

        private void btnEksikPaketler_Click(object sender, EventArgs e)
        {
            tumPaketler = false;
            GetData();
        }

        private void SetButtonColor()
        {
            if (tumPaketler)
            {
                btnTumPaketler.Appearance.BackColor = Color.LightGreen;
                btnEksikPaketler.Appearance.BackColor = Color.Transparent;
            }
            else
            {
                btnTumPaketler.Appearance.BackColor = Color.Transparent;
                btnEksikPaketler.Appearance.BackColor = Color.LightGreen;
            }
        }

        private void gridView3_MasterRowExpanded(object sender, DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventArgs e)
        {
            GridView view = sender as GridView;
            GridView dView = view.GetDetailView(e.RowHandle, 0) as GridView;
            dView.OptionsBehavior.Editable = true;

            dView.RowCellStyle += gridView3_RowCellStyle;

            if (dView != null)
            {
                dView.ViewCaption = "Siparişler";
                dView.Columns["SIRKID"].Visible = false;
                dView.Columns["SPHRTP"].Visible = false;
                dView.Columns["SPFTNO"].Visible = false;
                dView.Columns["FLGKPN"].Visible = false;
                dView.Columns["MDKODU"].Visible = false;
                dView.Columns["MDLNAM"].Visible = false;
                dView.Columns["CKDEPO"].Visible = false;
                dView.Columns["DPTANM"].Visible = false;
                dView.Columns["HRACIK"].Visible = false;
                dView.Columns["GNREZV"].Visible = false;
                dView.Columns["URAKOD"].Visible = false;
                dView.Columns["SATIRN"].Visible = false;
                dView.Columns["PKKODU"].Visible = false;
                dView.Columns["PKTNAM"].Visible = false;
                dView.Columns["OLCUKD"].Visible = false;
                dView.Columns["SPMKTR"].Visible = false;
                dView.Columns["KLNMKTR"].Visible = false;
                dView.Columns["RZMKTR"].Visible = false;
                dView.Columns["RZKLMK"].Visible = false;
                dView.Columns["USESTK"].Visible = false;

                dView.Columns["TANIMI"].Caption = "Sipariş Tipi";
                dView.Columns["BELGEN"].Caption = "Sipariş No";
                dView.Columns["BELTRH"].Caption = "Sipariş Tarihi";
                dView.Columns["TERTAR"].Caption = "Termin Tarihi";
                dView.Columns["TERTAR"].VisibleIndex = dView.Columns["BELTRH"].VisibleIndex + 1;
                dView.Columns["CRKODU"].Caption = "Cari Kodu";
                dView.Columns["CRUNV1"].Caption = "Cari Ünvan";
                dView.Columns["BSACIK"].Caption = "Sipariş Açıklama";
                dView.Columns["HRACIK"].Caption = "Kalem Açıklama";
                dView.Columns["EKSIKK"].Caption = "Eksik Miktar";
                dView.Columns["PLNMKT"].Caption = "Planlanan Miktar";
                dView.Columns["IHTIYC"].Caption = "İhtiyaç";

                dView.Columns.ForEach(f => f.OptionsColumn.AllowEdit = false);

                RepositoryItemButtonEdit button = new RepositoryItemButtonEdit();
                button.TextEditStyle = TextEditStyles.HideTextEditor;
                button.Buttons[0].Kind = ButtonPredefines.Glyph;
                button.Buttons[0].ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/edit/edit_16x16.png");
                button.ButtonClick += Button_ButtonClick;

                dView.Columns.Add(new DevExpress.XtraGrid.Columns.GridColumn()
                {
                    Caption = "Düzenle",
                    ColumnEdit = button,
                    VisibleIndex = 20,
                    Width = 25,
                    UnboundType = DevExpress.Data.UnboundColumnType.String
                });

                dView.BestFitColumns();
            }
        }

        private void Button_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            ButtonEdit editor = sender as ButtonEdit;
            GridControl grid = editor.Parent as GridControl;
            GridView view = grid.FocusedView as GridView;

            SiparisPaketIhtiyac pIhtiyac = new SiparisPaketIhtiyac();

            DataRow row = view.GetFocusedDataRow() as DataRow;
            foreach (DataColumn c in row.Table.Columns)
            {
                PropertyInfo p = pIhtiyac.GetType().GetProperty(c.ColumnName);
                if (p != null && row[c] != DBNull.Value)
                {
                    p.SetValue(pIhtiyac, row[c], null);
                }
            }

            FrmEksikPaketEdit pForm = new FrmEksikPaketEdit(pIhtiyac, global);
            pForm.ShowDialog();

            GetData();
        }

        private void gridView3_RowCellStyle(object sender, RowCellStyleEventArgs e)
        {
            if ((e.Column.FieldName == "EKSIKK" || e.Column.FieldName == "PLNMKT" || e.Column.FieldName == "IHTIYC") && e.RowHandle > -1)
            {
                GridView view = sender as GridView;
                decimal eksikMiktar = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "EKSIKK"));
                decimal planlananMiktar = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "PLNMKT"));
                decimal ihtiyac = Convert.ToDecimal(view.GetRowCellValue(e.RowHandle, "IHTIYC"));

                if (planlananMiktar == 0 && ihtiyac == 0)
                {
                    e.Appearance.BackColor = Color.GreenYellow;
                    return;
                }

                if (planlananMiktar == 0) e.Appearance.BackColor = Color.LightCoral;
                else if (planlananMiktar < eksikMiktar) e.Appearance.BackColor = Color.Gold;
                else e.Appearance.BackColor = Color.DeepSkyBlue;
            }
        }
    }
}
