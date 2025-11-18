using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.DataAccess.Abstract.IS;
using Bps.BpsBase.Entities.Models.IS.Single;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using DevExpress.Utils;
using System.Linq;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.IS.Listed;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
	public partial class FrmIsPlani : BPS.Windows.Base.FrmChildBase
	{

		private ProjeMenuListed yetkiModel;
		private string activeView = "";

		private readonly IIsplanService _sinifService;
		private readonly ISpfharService _spfharService;

		public FrmIsPlani(IIsplanService isplanService, ISpfharService spfharService)
		{
			InitializeComponent();

			xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
			dtBaslangic.EditValue = DateTime.Today.AddDays(-5);
			dtBitis.EditValue = DateTime.Today.AddDays(5);

			_sinifService = isplanService;
			_spfharService = spfharService;
		}

		private void FrmIsPlani_Load(object sender, EventArgs e)
		{
			yetkiModel = MenuYetki;
			FormIslemleri.FormYetki2(barManager, yetkiModel);
			//gridView1.OptionsView.ShowAutoFilterRow = true;
			LoadData();
			//GridHelper.ColumnRepositoryItems(gridView1, global);
			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
		}

		private void btnPlanAra_Click(object sender, EventArgs e)
		{
			var planNo = txtPlanNo.EditValue == null ? "" : txtPlanNo.EditValue.ToString();

			if (dtBaslangic == null && string.IsNullOrEmpty(planNo))
			{
				MessageBox.Show("Plan tarihi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			LoadGrid();

			barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
			barManager.Bars["Tools"].Visible = true;
			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
			xtraTabControl1.SelectedTabPage = xtraTabPage2;
		}

		private void LoadData()
		{
			//_gntipiList = _gntipiService.Ncch_GetByHareketTable_NLog(global, "GNLKHR", false).Items;
			//ulkeTip = _gntipiList.Find(t => t.TEKNAD == "ULKEKD").TIPKOD;
			//sehirTip = _gntipiList.Find(t => t.TEKNAD == "SEHRKD").TIPKOD;
			//ilceTip = _gntipiList.Find(t => t.TEKNAD == "ILCEKD").TIPKOD;
			//semtTip = _gntipiList.Find(t => t.TEKNAD == "SEMTKD").TIPKOD;
			//mahalleTip = _gntipiList.Find(t => t.TEKNAD == "MAHAKD").TIPKOD;

			////var makineKategoriTip = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "MKNKTG", false).Nesne;
			//_makineKategoriList = _gnthrkService.Cch_GetListByTeknad(global, "STANKD", false).Items;

			//var persList = _ikpersService.Ncch_GetListPersonelSicilAdPoz_NLog(global, false).Items;
			//persList.Remove(p => p.SICILN == "1"); //ADMİNİ LİSTEDEN KALDIR
			//persList.Insert(0, new IkpersSicilAdPozModel());
			//grdLkedServisPersonel.Properties.DataSource = persList;
			//repGrdLkedPersonel.DataSource = persList;

			//_cariList = _crcariService.Ncch_GetAllActive_NLog(global, false).Items;
			//cRKODUGridLookUpEdit.Properties.DataSource = _cariList;
			//repGrdLkedCari.DataSource = _cariList;

			//_sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
			//    global.MenuName,
			//    global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
			//if (_sinifyerlesim != null)
			//{
			//    byte[] byteArray = Encoding.ASCII.GetBytes(_sinifyerlesim.GRDXML);
			//    MemoryStream stream = new MemoryStream(byteArray);
			//    gridView1.RestoreLayoutFromStream(stream);
			//}

			//var teknads = new List<string>() { "SRTRKD", "SRDRKD", "GRDRKD", "MKDRKD", "STALKD", "MKNKTG" };
			//var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
			//grdLkedServisTuru.Properties.DataSource = repGrdLkedServisTuru.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "SRTRKD").ToList();
			//grdLkedServisDurumu.Properties.DataSource = repGrdLkedServisDurumu.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "SRDRKD").ToList();
			//grdLkedGarantiDurumu.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "GRDRKD").ToList();
			//grdLkedMakineDurumu.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "MKDRKD").ToList();
			//grdLkedKategori.Properties.DataSource =
			//    repGrdLkedKategori.DataSource =
			//        _makineKategoriList;
		}

		private void LoadGrid()
		{
			bool tamamlanan = chkTamamlanan.Checked;
			var planNo = txtPlanNo.EditValue == null ? "" : txtPlanNo.EditValue.ToString();
			var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
			var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

			var param = new IsPlaniParamModel()
			{
				PlanNo = planNo,
				DtBaslangic = dtBas,
				DtBitis = dtBit,
				Tamamlanan = tamamlanan,
			};

			DataSet dataSet = new DataSet();

			//LkEdStokKart.EditValue = null;

			var planBaslikList = _sinifService.Ncch_GetIsplanBaslikList_NLog(global, false).Items;
			//var planBaslikList = planParcaIslemList.Select(x => new
			//{
			//	ISPKOD = x.ISPKOD,
			//	ISMETN = x.ISMETN,
			//	CRKODU = x.ISMETN,
			//	CRNAME = x.ISMETN,
			//	GNTARH = x.GNTARH,
			//}).Distinct().ToList();

			List<SPFHAR> spfharList = new List<SPFHAR>();
			foreach (IsplanBaslikModel planBaslik in planBaslikList)
			{
				spfharList.AddRange(_spfharService.Cch_GetListByBelge_NLog(planBaslikList[0].SIPKOD, global).Items);
			}

			var planUrunList = spfharList.Select(x => new
			{
				BELGEN = x.BELGEN,
				ISPKOD = x.ISPKOD,
				SATIRN = x.SATIRN,
				STKODU = x.STKODU,
				STKNAM = x.STKNAM,
				GNMKTR = x.GNMKTR,
				GNACIK = x.GNACIK,
			}).Distinct().ToList();
			
			//var planParcaIslemList = _sinifService.Cch_GetListByParam_NLog(param, global).Items;
			//var planParentStokList = planParcaIslemList.Select(x => new
			//{
			//	ISPKOD = x.ISPKOD,
			//	ISMETN = x.ISMETN,
			//	MXPRKD = x.MXPRKD,
			//	MXPRK2 = x.MXPRKD,
			//	PLMKTR = x.PLMKTR,
			//	URAKOD = x.URAKOD,
			//	GNREZV = x.GNREZV,
			//	STKODU = x.STKODU,
			//}).Distinct().ToList();

			//var planStokParcaList = planParcaIslemList.Select(x => new
			//{
			//	ISPKOD = x.ISPKOD,
			//	ISMETN = x.ISMETN,
			//	MXPRKD = x.MXPRKD,
			//	STKODU = x.STKODU,
			//	STKOD2 = x.STKODU,
			//	URAKOD = x.URAKOD,
			//	GNREZV = x.GNREZV,
			//}).Distinct().ToList();

			if (planBaslikList.Count > 0)
			{
				DataTable planBaslikTable = Bps.Core.Utilities.Converters.Convert.ListToDataTable(planBaslikList);
				planBaslikTable.TableName = "PlanBaslik";
				DataTable planUrunTable = Bps.Core.Utilities.Converters.Convert.ListToDataTable(planUrunList);
				planUrunTable.TableName = "PlanUrun";
				//DataTable planParentStokTable = Bps.Core.Utilities.Converters.Convert.ListToDataTable(planParentStokList);
				//planParentStokTable.TableName = "ParentStok";
				//DataTable planStokParcaTable = Bps.Core.Utilities.Converters.Convert.ListToDataTable(planStokParcaList);
				//planStokParcaTable.TableName = "StokParca";
				//DataTable planParcaIslemTable = Bps.Core.Utilities.Converters.Convert.ListToDataTable(planParcaIslemList);
				//planParcaIslemTable.TableName = "ParcaIslem";

				dataSet.Tables.Add(planBaslikTable);
				dataSet.Tables.Add(planUrunTable);
				//dataSet.Tables.Add(planParentStokTable);
				//dataSet.Tables.Add(planStokParcaTable);
				//dataSet.Tables.Add(planParcaIslemTable);
			}

			if (dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
			{
				//Plan Ürün ilişkisi
				DataColumn keyColumn = dataSet.Tables[0].Columns["ISPKOD"];
				DataColumn keyColumn2 = dataSet.Tables[0].Columns["SIPKOD"];
				DataColumn foreignKeyColumn = dataSet.Tables[1].Columns["ISPKOD"];
				DataColumn foreignKeyColumn2 = dataSet.Tables[1].Columns["BELGEN"];

				//Stok Parça ilişkisi
				//DataColumn keyColumn3 = dataSet.Tables[1].Columns["ISPKOD"];
				//DataColumn keyColumn4 = dataSet.Tables[1].Columns["ISMETN"];
				//DataColumn keyColumn5 = dataSet.Tables[1].Columns["MXPRKD"];
				//DataColumn keyColumn6 = dataSet.Tables[1].Columns["URAKOD"];
				//DataColumn keyColumn7 = dataSet.Tables[1].Columns["GNREZV"];
				//DataColumn keyColumn14 = dataSet.Tables[1].Columns["STKODU"];
				//DataColumn foreignKeyColumn3 = dataSet.Tables[2].Columns["ISPKOD"];
				//DataColumn foreignKeyColumn4 = dataSet.Tables[2].Columns["ISMETN"];
				//DataColumn foreignKeyColumn5 = dataSet.Tables[2].Columns["MXPRKD"];
				//DataColumn foreignKeyColumn6 = dataSet.Tables[2].Columns["URAKOD"];
				//DataColumn foreignKeyColumn7 = dataSet.Tables[2].Columns["GNREZV"];
				//DataColumn foreignKeyColumn14 = dataSet.Tables[2].Columns["STKODU"];

				//Parça İşlem ilişkisi
				//DataColumn keyColumn8 = dataSet.Tables[2].Columns["ISPKOD"];
				//DataColumn keyColumn9 = dataSet.Tables[2].Columns["ISMETN"];
				//DataColumn keyColumn10 = dataSet.Tables[2].Columns["MXPRKD"];
				//DataColumn keyColumn11 = dataSet.Tables[2].Columns["URAKOD"];
				//DataColumn keyColumn12 = dataSet.Tables[2].Columns["GNREZV"];
				//DataColumn keyColumn13 = dataSet.Tables[2].Columns["STKODU"];
				//DataColumn foreignKeyColumn8 = dataSet.Tables[3].Columns["ISPKOD"];
				//DataColumn foreignKeyColumn9 = dataSet.Tables[3].Columns["ISMETN"];
				//DataColumn foreignKeyColumn10 = dataSet.Tables[3].Columns["MXPRKD"];
				//DataColumn foreignKeyColumn11 = dataSet.Tables[3].Columns["URAKOD"];
				//DataColumn foreignKeyColumn12 = dataSet.Tables[3].Columns["GNREZV"];
				//DataColumn foreignKeyColumn13 = dataSet.Tables[3].Columns["STKODU"];

				DataRelation dr = new DataRelation("PlanUrun", new[] { keyColumn, keyColumn2 }, new[] { foreignKeyColumn, foreignKeyColumn2 });
				dataSet.Relations.Add(dr);
				//DataRelation dr2 = new DataRelation("StokParca", new[] { keyColumn3, keyColumn4, keyColumn5, keyColumn6, keyColumn7, keyColumn14 }, new[] { foreignKeyColumn3, foreignKeyColumn4, foreignKeyColumn5, foreignKeyColumn6, foreignKeyColumn7, foreignKeyColumn14 });
				//dataSet.Relations.Add(dr2);
				//DataRelation dr3 = new DataRelation("ParcaIslem", new[] { keyColumn8, keyColumn9, keyColumn10, keyColumn11, keyColumn12, keyColumn13 }, new[] { foreignKeyColumn8, foreignKeyColumn9, foreignKeyColumn10, foreignKeyColumn11, foreignKeyColumn12, foreignKeyColumn13 });
				//dataSet.Relations.Add(dr3);

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
			gridView1.Columns["ISPKOD"].Caption = "Plan No";
			gridView1.Columns["SIPKOD"].Caption = "Sipariş No";
			gridView1.Columns["GNTARH"].Caption = "Plan Tarihi";
			gridView1.Columns["CRKODU"].Caption = "Cari Kodu";
			gridView1.Columns["CRNAME"].Caption = "Cari Adı";
			gridView1.BestFitColumns();
			gridView1.TopRowIndex = topRow;
			gridView1.FocusedRowHandle = focusedRow;
			gridView1.OptionsDetail.AllowZoomDetail = false;
			gridView1.OptionsDetail.ShowDetailTabs = false;
			gridView1.OptionsDetail.SmartDetailExpand = false;
			gridView1.OptionsDetail.ShowEmbeddedDetailIndent = DefaultBoolean.False;
			gridView1.OptionsDetail.AllowZoomDetail = false;
			gridView1.OptionsBehavior.Editable = false;
			gridView1.OptionsBehavior.ReadOnly = false;

			GridView parentStokView = CreateDetailView("PlanUrun", dataSet.Tables[1]);
			//GridView stokParcaView = CreateDetailView("StokParca", dataSet.Tables[2]);
			//GridView parcaIslemView = CreateDetailView("ParcaIslem", dataSet.Tables[3]);
		}

		private GridView CreateDetailView(string name, DataTable table)
		{
			GridView detailView = new GridView(gridControl1);
			detailView.Name = name;
			gridControl1.LevelTree.Nodes.Add(name, detailView);
			detailView.OptionsBehavior.Editable = false;
			detailView.OptionsBehavior.ReadOnly = true;
			detailView.OptionsView.EnableAppearanceEvenRow = true;
			detailView.OptionsView.ShowAutoFilterRow = false;
			detailView.OptionsView.ShowGroupPanel = false;
			detailView.OptionsView.ShowFooter = false;
			detailView.OptionsView.ShowIndicator = false;
			detailView.OptionsDetail.ShowDetailTabs = false;
			detailView.OptionsDetail.SmartDetailExpand = false;
			detailView.OptionsDetail.ShowEmbeddedDetailIndent = DefaultBoolean.False;
			detailView.OptionsDetail.AllowZoomDetail = false;
			detailView.ViewCaption = name;
			detailView.PopulateColumns(table);

			detailView.MasterRowExpanded -= gridView1_MasterRowExpanded;
			detailView.MasterRowExpanded += gridView1_MasterRowExpanded;

			if (name == "ParentStok")
			{
				detailView.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(detailView_PopupMenuShowing);
			}

			return detailView;
		}

		private void gridView1_MasterRowExpanded(object sender, CustomMasterRowEventArgs e)
		{
			GridView view = sender as GridView;
			var detailView = view.GetDetailView(e.RowHandle, e.RelationIndex) as GridView;

			detailView.MasterRowExpanded -= gridView1_MasterRowExpanded;
			detailView.MasterRowExpanded += gridView1_MasterRowExpanded;

			detailView.Columns["ISPKOD"].Visible = false;
			detailView.Columns["BELGEN"].Visible = false;
			detailView.Columns["SATIRN"].Caption = "Satır No";
			detailView.Columns["STKODU"].Caption = "Stok Kodu";
			detailView.BestFitColumns();

			if (detailView.LevelName == "ParentStok")
			{
				detailView.Columns["MXPRKD"].Caption = "Üst Stok Kodu";
				detailView.Columns["MXPRK2"].Caption = "Üst Stok Adı";
			}
			else if (detailView.LevelName == "StokParca")
			{
				detailView.Columns["MXPRKD"].Visible = false;
				detailView.Columns["STKODU"].Caption = "İşlem Gören Stok Kodu";
				detailView.Columns["STKOD2"].Caption = "İşlem Gören Stok Adı";
			}
			else if (detailView.LevelName == "ParcaIslem")
			{
				detailView.Columns["Id"].Visible = false;
				detailView.Columns["SIRASI"].Visible = false;
				detailView.Columns["GNTARH"].Visible = false;
				detailView.Columns["MXPRKD"].Visible = false;
				detailView.Columns["STKODU"].Visible = false;
				detailView.Columns["SIRKID"].Visible = false;
				detailView.Columns["ACTIVE"].Visible = false;
				detailView.Columns["SLINDI"].Visible = false;
				detailView.Columns["EKKULL"].Visible = false;
				detailView.Columns["ETARIH"].Visible = false;
				detailView.Columns["DEKULL"].Visible = false;
				detailView.Columns["DTARIH"].Visible = false;
				detailView.Columns["KYNKKD"].Visible = false;
				detailView.Columns["CHKCTR"].Visible = false;
				detailView.Columns["ISCSUR"].Visible = false;
				detailView.Columns["ISCSUB"].Visible = false;
				detailView.Columns["GCTSUR"].Visible = false;
				detailView.Columns["GCTSUB"].Visible = false;
				detailView.Columns["GNHZOB"].Visible = false;

				detailView.Columns["URYRKD"].Caption = "Üretim Yeri";
				detailView.Columns["ISYKOD"].Caption = "İstasyon";
				detailView.Columns["ISOPKD"].Caption = "İşlem";
				detailView.Columns["ISLMNO"].Caption = "İşlem Sırası";
				detailView.Columns["BASTAR"].Caption = "Başlama Zamanı";
				detailView.Columns["GRMKTR"].Caption = "Yapılan Miktar";
				detailView.Columns["GROLBR"].Caption = "Ölçü Birimi";
				detailView.Columns["GNHZSR"].Caption = "Hazırlık Süresi";
				detailView.Columns["ISLMSR"].Caption = "İşlem Süresi";
				detailView.Columns["ISLMSB"].Caption = "Süre Birimi";
				detailView.Columns["FLGKPN"].Caption = "Tamamlandı";
			}

			detailView.BestFitColumns();
		}

		protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (xtraTabControl1.SelectedTabPage == xtraTabPage2) LoadGrid();
		}

		protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
		{
			//sHSRVSBindingSource.CancelEdit();
			//gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
			if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
			{
				gridView1.OptionsBehavior.Editable = false;

				barManager.Bars["Tools"].Visible = false;
				xtraTabControl1.SelectedTabPage = xtraTabPage1;
			}

			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
		}

		private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			if (gridView1.FocusedRowHandle < 0) return;
			activeView = "master";
			popContext.ShowPopup(MousePosition);
		}

		private void detailView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			GridView view = sender as GridView;
			if (view.FocusedRowHandle < 0) return;
			activeView = "detail";
			popContext.ShowPopup(MousePosition);
		}

		private void barButIsemriYazdir_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (activeView == "master")
			{
				string planNo = gridView1.GetFocusedRowCellValue("ISPKOD").ToString();
				CreateIsemri(planNo);
			}
			else if (activeView == "detail")
			{

			}
		}

		private void CreateIsemri(string planNo, string stokKodu = "")
		{
			List<IsplanUrunParcaModel> urunParcaList = _sinifService.Ncch_GetIsplanUrunParcaList_NLog(global, planNo).Items;
			
			List<string> urunList = new List<string>();
			if (stokKodu != "") urunList.Add(stokKodu);
			else urunList = urunParcaList.Select(x => x.MXPRKD).Distinct().ToList();

			repIsemri rIsemri = new repIsemri();
			rIsemri.Pages.Clear();

			foreach (string urun in urunList)
			{
				string teknikFolder = AppDomain.CurrentDomain.BaseDirectory + "teknik\\" + urun + "\\";
				var uParcaList = urunParcaList.Where(u => u.MXPRKD == urun).ToList();
				foreach (IsplanUrunParcaModel parcaModel in urunParcaList)
				{
					string filePath = teknikFolder + parcaModel.STKODU + ".jpg";
					parcaModel.TEKPTH = filePath.Replace(@"\\", @"\");
				}

				repIsemri isemri = new repIsemri();
				isemri.lblTarih.Text = uParcaList[0].GNTARH.Value.ToShortDateString();
				isemri.lblPlanNo.Text = uParcaList[0].ISPKOD;
				isemri.lblUrunKodu.Text = uParcaList[0].MXPRKD;
				isemri.lblUrunAdi.Text = uParcaList[0].MXPRNM;
				isemri.lblMiktar.Text = uParcaList[0].PLMKTR.Value.ToString();
				isemri.xrPictureBox2.ImageUrl = teknikFolder + uParcaList[0].MXPRKD + ".jpg";
				isemri.xrPictureBox3.ImageUrl = uParcaList[0].TEKPTH;

				isemri.bindingSource1.DataSource = uParcaList;
				isemri.CreateDocument();

				rIsemri.Pages.AddRange(isemri.Pages);
			}

			rIsemri.ShowRibbonPreviewDialog();
		}
	}
}
