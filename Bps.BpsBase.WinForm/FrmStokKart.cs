using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SA;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.Entities;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraTab;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.MH;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.ST.Enums;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.Core.Utilities.Helpers;
using BPS.Windows.Forms.Helper;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Transactions;
using System.Xml;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.Entities.Models;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.Entities.Models.UA;
using Bps.Core.GlobalStaticsVariables;
using DevExpress.LookAndFeel;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using CommandVisibility = DevExpress.XtraReports.UserDesigner.CommandVisibility;
using System.Reflection;


namespace BPS.Windows.Forms
{
	public partial class FrmStokKart : Base.FrmChildBase
	{
		private IStkartService _stokKartService;

		private IXXService _stokService;

		//private IStokKartSinifService _stokKartSinifService;
		private BindingList<STKART> _stokKartBindingList;
		private BindingList<STNAME> _stokTanimBindingList;
		private ProjeMenuListed yetkiModel;
		private readonly IGnyetkService _gnyetkService;
		private readonly IStmaltService _stmaltService;
		private readonly ISadegaService _sadegaService;
		private readonly IUragacService _uragacService;
		private readonly IGnthrkService _gnthrkService;
		private readonly IGndptnService _gndptnService;
		private readonly IGnevrkService _gnevrkService;
		private readonly ISttdtrService _sttdtrService;
		private readonly IStdepoService _stdepoService;
		private readonly IStmhsbService _stmhsbService;
		private readonly IStftipService _stftipService;
		private readonly IMhhsplService _mhhsplService;
		private readonly IStsaleService _stsaleService;
		private readonly IStolcuService _stolcuService;
		private readonly IStkmizService _stkmizService;
		private readonly IStnameService _stnameService;
		private readonly ISturyrService _sturyrService;
		private readonly IStdpynService _stdpynService;
		private readonly IGndptpService _gndptpService;
		private readonly IGnoptpService _gnoptpService;
		private readonly ISturopService _sturopService;
		private readonly IUastbgService _uastbgService;
		private readonly IStbdrnService _stbdrnService;
		private readonly IStcrkdService _stcrkdService;
		private List<GNYETB> ortamModel;
		private readonly IGnyetbService _gnyetbService;

		private BindingList<STOLCU> oldBindingList;

		private List<List<IEntity>> entitiesFromExcel;
		private int? deletedId { get; set; }

		private STKART _stokKart;
		int maxAltId = 0;

		private List<Grid> focusedRowHandler = new List<Grid>();
		private List<Grid> ExcelfocusedRowHandler = new List<Grid>();
		private string _action;
		private short _etiketSayisi;
		private string imageFolder = "";
		private string saveFolder = "";

		private List<Dictionary<int, List<UrunOpsiyonModel>>> opsiyonList =
			new List<Dictionary<int, List<UrunOpsiyonModel>>>();

		private List<TipHareketListModel> malGrubuTanimList = new List<TipHareketListModel>();
		private List<TipHareketListModel> stokAnaGrupList = new List<TipHareketListModel>();
		private List<TipHareketListModel> stokAltGrupList = new List<TipHareketListModel>();
		private List<TipHareketListModel> stokGrup1List = new List<TipHareketListModel>();
		private List<TipHareketListModel> stokGrup2List = new List<TipHareketListModel>();
		private List<TipHareketListModel> stokGrup3List = new List<TipHareketListModel>();
		private List<UrunAgaciModulPaket> uaModulPaketList = new List<UrunAgaciModulPaket>();

		Dictionary<string, RepositoryItemGridLookUpEdit> repositoryList =
			new Dictionary<string, RepositoryItemGridLookUpEdit>();

		public FrmStokKart(IStkartService stokKartService, IXXService stokService, IGnyetkService gnyetkService,
			IStmaltService stmaltService, ISadegaService sadegaService, IGntipiService gntipiService,
			IGnthrkService gnthrkService, IGndptnService gndptnService, ISttdtrService sttdtrService,
			IStdepoService stdepoService, IStmhsbService stmhsbService, IStftipService stftipService,
			IMhhsplService mhhsplService, IStsaleService stsaleService, IStolcuService stolcuService,
			IStkmizService stkmizService, IStnameService stnameService, ISturyrService sturyrService,
			IStdpynService stdpynService, IGndptpService gndptpService, IGnoptpService gnoptpService, IStcrkdService stcrkdService,
			ISturopService sturopService, IUragacService uragacService, IGnevrkService gnevrkService, IUastbgService uastbgService, IGnyetbService gnyetbService
			, IStbdrnService stbdrnService)
		{
			_stokKartService = stokKartService;
			_gnyetkService = gnyetkService;
			_stmaltService = stmaltService;
			_sadegaService = sadegaService;
			_uragacService = uragacService;
			_gnthrkService = gnthrkService;
			_gndptnService = gndptnService;
			_sttdtrService = sttdtrService;
			_stokService = stokService;
			_stdepoService = stdepoService;
			_stmhsbService = stmhsbService;
			_stftipService = stftipService;
			_mhhsplService = mhhsplService;
			_stsaleService = stsaleService;
			_stolcuService = stolcuService;
			_stkmizService = stkmizService;
			_stnameService = stnameService;
			_sturyrService = sturyrService;
			_stdpynService = stdpynService;
			_gndptpService = gndptpService;
			_gnoptpService = gnoptpService;
			_sturopService = sturopService;
			_gnevrkService = gnevrkService;
			_uastbgService = uastbgService;
			_gnyetbService = gnyetbService;
			_stbdrnService = stbdrnService;
			_stcrkdService = stcrkdService;
			InitializeComponent();
			xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
			_etiketSayisi = 1;
		}

		private void FrmStokKart_Load(object sender, EventArgs e)
		{
			//barManager.Items["barGoruntule"].Visibility = BarItemVisibility.Always;
			yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
			ortamModel = _gnyetbService.Cch_GetListYetkiId_NLog(yetkiModel.Id, global, false).Items;
			FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);

			var teknads = new List<string>() { "MALGKD", "OLCUKD", "LANGKD", "STANKD", "STALKD", "SPORKD", "STG1KD", "STG2KD", "STG3KD" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

			var tedarikTurList = _sttdtrService.Cch_GetList_NLog(global, false).Items;
			var depoTanims = _gndptnService.Cch_GetListAktif_NLog(global, false).Items;
			repStMhsbDepo.DataSource = depoTanims;
			repStDepoDpKodu.DataSource = depoTanims;
			repSTDepoTedKod.DataSource = tedarikTurList;

			//repTedTur.DataSource = _sttdtrService.Cch_GetList_NLog(global, false).Items;

			repStMhsbStokFisTip.DataSource = _stftipService.Cch_GetList_NLog(global, false).Items;
			repStMhsbHesapKod.DataSource = _mhhsplService.Cch_GetList_NLog(global, false).Items;
			//repStmhsbDepo.DataSource = _gndptnService.Cch_GetList_NLog(global, false).Items;



			var olcuBirimiTanimList = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();
			var saDegerAnahtariList = _sadegaService.Cch_GetListAktif_NLog(global, false).Items;
			var dilTanimList = teknadsResponse.Items.Where(w => w.TEKNAD == "LANGKD").ToList();
			var malzemeTuruTanimList = _stmaltService.Cch_GetListAktif_NLog(global, false).Items;
			malGrubuTanimList = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
			stokAnaGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").ToList();
			stokAltGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();
			stokGrup1List = teknadsResponse.Items.Where(w => w.TEKNAD == "STG1KD").ToList();
			stokGrup2List = teknadsResponse.Items.Where(w => w.TEKNAD == "STG2KD").ToList();
			stokGrup3List = teknadsResponse.Items.Where(w => w.TEKNAD == "STG3KD").ToList();

			repLkedMalGrubu.DataSource = malGrubuTanimList;
			repLkedStokAnaGrup.DataSource = stokAnaGrupList;
			//repLkedStokAltGrup.DataSource = stokAltGrupList;

			foreach (TipHareketListModel tip in stokAnaGrupList)
			{
				var tipHareketList = stokAltGrupList.Where(a => a.PARENT == tip.Id).ToList();
				if (tipHareketList.Count > 0)
				{
					var repItem = CreateRepositoryItem(tipHareketList);
					repositoryList.Add(tip.HARKOD, repItem);
				}
			}

			repHdfOlcu.DataSource = olcuBirimiTanimList;
			LkEdMalzTuru.Properties.DataSource = malzemeTuruTanimList.OrderBy(m => m.STMLTR).ToList();
			LkEdMalzTuru.Properties.View.Columns["STBKDR"].Visible = false;

			uaModulPaketList = _uragacService.Ncch_GetUrunAgaciModulPaketList_NLog(global).Items;

			if (Param.ADAPTATION == Adaptation.Nesto)
			{
				gridView1.OptionsBehavior.Editable = true;
				gridView1.OptionsBehavior.ReadOnly = false;

				foreach (GridColumn column in gridView1.Columns)
				{
					column.OptionsColumn.AllowEdit = false;
					column.OptionsColumn.ReadOnly = true;
				}
			}

			#region Genel Veriler

			LkEdMalGrubu.Properties.DataSource = malGrubuTanimList;
			LkEdOlcuBirimi.Properties.DataSource = olcuBirimiTanimList;
			LkEdSaOlcuBirimi.Properties.DataSource = olcuBirimiTanimList;
			LkEdUgyBirimi.Properties.DataSource = olcuBirimiTanimList;
			LkEdAgirlikBirimi.Properties.DataSource = olcuBirimiTanimList;
			LkEdHacimBirimi.Properties.DataSource = olcuBirimiTanimList;
			LkEdSaDegerAnahtari.Properties.DataSource = saDegerAnahtariList;
			//repKKaynakKodu.DataSource = olcuBirimiTanimList;
			LkEdMalGrubu.Properties.DataSource = malGrubuTanimList;
			LkEdAnaGrup.Properties.DataSource = stokAnaGrupList;
			LkEdStokGrup1.Properties.DataSource = stokGrup1List;
			LkEdStokGrup2.Properties.DataSource = stokGrup2List;
			LkEdStokGrup3.Properties.DataSource = stokGrup3List;

			List<GNOPTP> urunOpsiyonList = new List<GNOPTP>();
			GNOPTP gnoptp = _gnoptpService.Ncch_GetByTeknikAd_NLog(global, "UROPKD", false).Nesne;
			if (gnoptp != null)
			{
				urunOpsiyonList = _gnoptpService.Ncch_GetListByUstTipKod_NLog(global, gnoptp.TIPKOD).Items;
			}

			uROPTBGridLookUpEdit.Properties.DataSource = urunOpsiyonList;

			#endregion

			#region Sınıflandırma

			//LkEdSuntaKodu.Properties.DataSource = _stokKartService.GetStokKartKategori(LkEdSuntaKodu.Tag.ToString());

			//var stokKartKategoriList = _stokKartService.GetStokKartKategori(LkEdUstKenarKodu.Tag.ToString());
			//LkEdUstKenarKodu.Properties.DataSource = stokKartKategoriList;
			//LkEdSagKenarKodu.Properties.DataSource = stokKartKategoriList;
			//LkEdAltKenarKodu.Properties.DataSource = stokKartKategoriList;
			//LkEdSolKenarKodu.Properties.DataSource = stokKartKategoriList;
			//LkEdKavisKenarKodu.Properties.DataSource = stokKartKategoriList;

			#endregion

			#region Malzeme Dil Tanım

			//repLkEdDilTanim.DataSource = dilTanimList;

			#endregion

			#region Satış

			repStsaleMalgrb1.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
			repStsaleMalgrb2.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
			repStsaleMalgrb3.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();

			#endregion

			#region Maliyet Hesaplama

			mALHSOLKED.Properties.DataSource = EnumHelper.GetListItemsFromEnum<MaliyetHesapTipEnum>();
			mALHSPTLKE.Properties.DataSource = EnumHelper.GetListItemsFromEnum<MaliyetHesapTipEnum>();
			mALHSYLKE.Properties.DataSource = EnumHelper.GetListItemsFromEnum<MaliyetHesapTipEnum>();

			#endregion

			#region Üretim Yeri

			repoStUryr.DataSource = EnumHelper.GetListItemsFromEnum<TedarikTurEnum>();

			#endregion

			#region WM Depo Yönetimi

			repLkedStkartDepoTip.DataSource = _gndptpService.Cch_GetList_NLog(global, false).Items;

			#endregion

			GridHelper.ColumnRepositoryItems(gridViewB, global);
			GridHelper.ColumnRepositoryItems(gridViewOlcu, global);
			GridHelper.ColumnRepositoryItems(gridViewStDepo, global);
			GridHelper.ColumnRepositoryItems(gridViewStSale, global);
			GridHelper.ColumnRepositoryItems(gridViewSTURYR, global);
			GridHelper.ColumnRepositoryItems(gridViewStDpyn, global, new List<string>() { "DEPOKD" });
			GridHelper.ColumnRepositoryItems(gridViewRenk, global);
		}

		protected override void barGoruntule_ItemClick(object sender, ItemClickEventArgs e)
		{
			FormIslemleri.SetControlsReadonlyProperty(groupControl3);
			FormIslemleri.SetControlsReadonlyProperty(groupControl4);
			FormIslemleri.SetControlsReadonlyProperty(groupControl5);
			FormIslemleri.SetControlsReadonlyProperty(groupControl6);
			FormIslemleri.SetControlsReadonlyProperty(groupControl10);
			FormIslemleri.SetControlsReadonlyProperty(grpSablonTasarim);
		}

		protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
		{
			deletedId = null;
			TxtStokKodu.Enabled = true;
			TxtMalzemeTuru.Enabled = false;
			btnKodOlustur.Enabled = true;
			var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;

			if (tur != null)
			{
				if (tur.OTMTIK == true) { TxtStokKodu.Enabled = false; }
				imageFolder = AppDomain.CurrentDomain.BaseDirectory + "images\\stok\\" + tur.STMLTR + "\\";
				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
				string bakimDurum = tur.STBKDR;
				sTKARTBindingSource.CancelEdit();

				gridView1.RefreshData();
				xtraTabControl1.SelectedTabPage = xtraTabPage2;
				xtraTabControl1.SelectedTabPage = xtraTabPage1;
				gridView1.AddNewRow();


				_action = "insert";
				opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();
				gridView1.SetRowCellValue(GridControl.NewItemRowHandle, gridView1.Columns["STMLTR"], tur.STMLTR);

				foreach (XtraTabPage xtraTabPage in xtraTabControl2.TabPages) xtraTabPage.PageVisible = false;
				foreach (char c in bakimDurum)
				{
					foreach (XtraTabPage xtraTabPage in xtraTabControl2.TabPages)
					{
						if (xtraTabPage.Tag.ToString() == c.ToString())
						{
							xtraTabPage.PageVisible = true;
							switch (c.ToString())
							{
								case "F":
									grpSTkMlyspDonem.Visible = false;
									grpSTkMlyspYıl.Visible = false;
									mALHSPTLKE.Enabled = true;
									grpDeger.Visible = false;
									break;
								case "B":
									break;
							}
						}
					}
				}

				//Validation hatası yüzünden kaldırıldı. Tekrar bakılacak

				//sTKARTBindingSource.RemoveCurrent();
				sTMHSBBindingSource.DataSource = new STMHSB();
				sTMHSBBindingSource.RemoveCurrent();
				sTSALEBindingSource.DataSource = new STSALE();
				sTSALEBindingSource.RemoveCurrent();
				sTDEPOBindingSource.DataSource = new STDEPO();
				sTDEPOBindingSource.RemoveCurrent();
				sTOLCUBindingSource.DataSource = new STOLCU();
				sTOLCUBindingSource.RemoveCurrent();
				sTNAMEBindingSource.DataSource = new STNAME();
				sTNAMEBindingSource.RemoveCurrent();
				sTURYRBindingSource.DataSource = new STURYR();
				sTURYRBindingSource.RemoveCurrent();
				sTDPYNBindingSource.DataSource = new STDPYN();
				sTDPYNBindingSource.RemoveCurrent();
				sTKMIZBindingSource.DataSource = new STKMIZ()
				{
					ACTIVE = true,
					MALIYL = DateTime.Today.Year,
					MALIAY = DateTime.Today.Month,
					KAYORT = 0,
					STNFIY = 0,
					DGMKTR = 0,
					DGSTDG = 0
				};
				sTBDRNBindingSource1.DataSource = new STBDRN();
				sTBDRNBindingSource1.RemoveCurrent();

				LkEdSaDegerAnahtari.Properties.View.FocusedRowHandle = 0;
				LkEdSaDegerAnahtari.EditValue = "1000";
				LkEdSaDegerAnahtari.RefreshEditValue();

				xtraTabControl1.SelectedTabPage = xtraTabPage2;
			}
		}

		protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
		{
			deletedId = null;
			TxtStokKodu.Enabled = false;
			TxtMalzemeTuru.Enabled = false;
			btnKodOlustur.Enabled = false;
			btnStandartOps.Enabled = true;
			btnRaporDizayn.Visible = true;
			focusedRowHandler.Clear();
			var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
			{
				if (tur == null) return;

				if (tur != null && gridView1.FocusedRowHandle > -1) FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);

				string bakimDurum = tur.STBKDR;
				_action = "update";

				STKART sKart = sTKARTBindingSource.Current as STKART;
				var opList = _sturopService.Ncch_GetByStokKodu_NLog(global, sKart.STKODU, false).Items;
				opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();
				saveFolder = AppDomain.CurrentDomain.BaseDirectory + "Report Templates\\" + sKart.STKODU + "\\";
				imageFolder = AppDomain.CurrentDomain.BaseDirectory + "images\\stok\\" + tur.STMLTR + "\\";

				GetTempDesignFileNames();

				List<STNAME> list_stname = _stnameService.Cch_GetListByStokKodu_NLog(global,
										gridView1.GetFocusedRowCellValue("STKODU").ToString(), false).Items;
				foreach (var item in list_stname)
				{
					if (item.LANGKD == "EN")
					{
						TxtStokAdiIng.Text = item.STKNAM;
					}
				}

				List<UrunOpsiyonModel> urOpModelList = new List<UrunOpsiyonModel>();
				foreach (STUROP sturop in opList)
				{
					UrunOpsiyonModel uModel = new UrunOpsiyonModel();
					uModel.TIPKOD = sturop.TIPKOD;
					uModel.HARKOD = sturop.HARKOD;
					uModel.STKODU = sturop.STKODU;
					uModel.STKNAM = sturop.STKNAM;

					urOpModelList.Add(uModel);
				}

				Dictionary<int, List<UrunOpsiyonModel>> dict = new Dictionary<int, List<UrunOpsiyonModel>>();
				dict.Add(0, urOpModelList);
				opsiyonList.Add(dict);

				foreach (XtraTabPage xtraTabPage in xtraTabControl2.TabPages) xtraTabPage.PageVisible = false;
				foreach (char c in bakimDurum)
				{
					foreach (XtraTabPage xtraTabPage in xtraTabControl2.TabPages)
					{
						if (xtraTabPage.Tag.ToString() == c.ToString())
						{
							xtraTabPage.PageVisible = true;

							if (xtraTabPage.Tag.ToString() == "H")
							{
								sTDEPOBindingSource.DataSource =
									_stdepoService.Cch_GetByStokKodu_NLog(global,
										gridView1.GetFocusedRowCellValue("STKODU").ToString(), false).Items;
							}

							if (xtraTabPage.Tag.ToString() == "B")
							{
								sTMHSBBindingSource.DataSource =
									_stmhsbService.Cch_GetByStokKodu_NLog(global,
										gridView1.GetFocusedRowCellValue("STKODU").ToString(), false).Items;
							}

							if (xtraTabPage.Tag.ToString() == "I")
							{
								sTSALEBindingSource.DataSource =
									_stsaleService.Cch_GetListByStokKodu_NLog(global,
										gridView1.GetFocusedRowCellValue("STKODU").ToString(), false).Items;
							}

							if (xtraTabPage.Tag.ToString() == "K")
							{
								var olcuSource = _stolcuService
									.Ncch_GetByStKod_NLog(gridView1.GetFocusedRowCellValue("STKODU").ToString(), global,
										false).Items;
								sTOLCUBindingSource.DataSource = olcuSource;
								if (olcuSource == null) return;
								oldBindingList = new BindingList<STOLCU>(olcuSource);
							}

							if (xtraTabPage.Tag.ToString() == "J")
							{
								sTNAMEBindingSource.DataSource =
									list_stname;
							}

							if (xtraTabPage.Tag.ToString() == "F")
							{
								var src = _stkmizService
									.Ncch_GetByStokKod_NLog(gridView1.GetFocusedRowCellValue("STKODU").ToString(),
										global, false).Nesne;
								sTKMIZBindingSource.DataSource = src;

								if (src == null)
								{
									sTKMIZBindingSource.DataSource = new STKMIZ()
									{
										ACTIVE = true,
										MALIYL = DateTime.Today.Year,
										MALIAY = DateTime.Today.Month,
										KAYORT = 0,
										STNFIY = 0,
										DGMKTR = 0,
										DGSTDG = 0
									};
									grpSTkMlyspDonem.Visible = false;
									grpSTkMlyspYıl.Visible = false;
									mALHSPTLKE.Enabled = true;
									grpDeger.Visible = false;
								}
								else
								{
									mALHSPTLKE.Enabled = false;
									grpSTkMlyspDonem.Visible = true;
									grpSTkMlyspYıl.Visible = true;
									grpDeger.Visible = true;
								}
							}

							if (xtraTabPage.Tag.ToString() == "L")
							{
								sTURYRBindingSource.DataSource =
									_sturyrService
										.Cch_GetListByStokKodu_NLog(
											gridView1.GetFocusedRowCellValue("STKODU").ToString(), global, false).Items;

								var lDepos = new List<GNDPTN>();
								var depoTanims = _gndptnService.Cch_GetList_NLog(global, false).Items;
								var stDepos = _stdepoService.Cch_GetByStokKodu_NLog(global,
									gridView1.GetFocusedRowCellValue("STKODU").ToString(), false).Items;

								foreach (var stdepo in stDepos)
								{
									var tnm = depoTanims.FirstOrDefault(f => f.DPKODU == stdepo.DPKODU);
									if (tnm != null)
									{
										lDepos.Add(tnm);
									}
								}

								repLkeUYUretimDepoKodu.DataSource = lDepos;
							}

							if (xtraTabPage.Tag.ToString() == "E")
							{
								sTDPYNBindingSource.DataSource =
									_stdpynService
										.Cch_GetListByStokKodu_NLog(
											gridView1.GetFocusedRowCellValue("STKODU").ToString(), global, false).Items;
							}
							if (xtraTabPage.Tag.ToString() == "R")
							{
								sTBDRNBindingSource1.DataSource =
									_stbdrnService
										.Cch_GetListByStokKodu_NLog(
											gridView1.GetFocusedRowCellValue("STKODU").ToString(), global, false).Items;
							}
						}
					}
				}

				xtraTabControl1.SelectedTabPage = xtraTabPage2;
			}
		}

		protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (xtraTabControl1.SelectedTabPage == xtraTabPage1) return;

			if (Validate())
			{
				var ayni = 0;
				var response = new StandardResponse();
				var model = new GenelStokKartModel();
				sTKARTBindingSource.EndEdit();
				_stokKart = sTKARTBindingSource.Current as STKART;
				var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
				var evrakmodel = new EvrakNoUretParamModel();
				evrakmodel.TabloAdi = "STKART";
				evrakmodel.TeknikAd = "STKODU";
				evrakmodel.IslemTur = tur.Id;
				var _gnevrk = _gnevrkService.Ncch_GetEvrak_NLog(global, evrakmodel, 0);
				if (_gnevrk.Status == ResponseStatusEnum.OK)
				{
					var _response = _stokService.Ncch_StokKodOlustur_NLog(global, tur, _stokKart, "D" + _gnevrk.Nesne.KARSAY, true);
					if (_response.Status == ResponseStatusEnum.OK)
					{
						_stokKart.STKODU = _response.Nesne;

					}
				}

				model.Stkart = _stokKart;

				//////// STDEPO /////////////////////
				var stDepoBindingList = sTDEPOBindingSource.List;
				model.Stdepos = new List<STDEPO>();
				foreach (var bind in stDepoBindingList)
				{
					model.Stdepos.Add((STDEPO)bind);
				}

				//////// STMHSB /////////////////////
				var stMhsbBindingList = sTMHSBBindingSource.List;
				model.Stmhsbs = new List<STMHSB>();

				foreach (var bind in stMhsbBindingList)
				{
					model.Stmhsbs.Add((STMHSB)bind);
				}

				//////// STSALE /////////////////////
				var stSaleBindingList = sTSALEBindingSource.List;
				model.Stsales = new List<STSALE>();

				foreach (var bind in stSaleBindingList)
				{
					model.Stsales.Add((STSALE)bind);
				}

				//////// STOLCU /////////////////////
				var stOlcuBindingList = sTOLCUBindingSource.List;
				model.Stolcus = new List<STOLCU>();
				foreach (var bind in stOlcuBindingList)
				{
					model.Stolcus.Add((STOLCU)bind);
				}

				//////// STNAME /////////////////////
				var stNameBindingList = sTNAMEBindingSource.List;
				STNAME _stname = new STNAME();
				model.Stnames = new List<STNAME>();

				if (stNameBindingList.Count == 0)
				{
					if (TxtStokAdiIng.Text != "")
					{
						_stname.SIRKID = (int)global.SirketId;
						_stname.STKODU = model.Stkart.STKODU;
						_stname.STKNAM = TxtStokAdiIng.Text;
						_stname.LANGKD = "EN";
						_stname.ACTIVE = true;

						_stname.SLINDI = false;
						_stname.EKKULL = global.UserKod;
						_stname.ETARIH = DateTime.Now;
						_stname.KYNKKD = global.KaynakKod;
						model.Stnames.Add(_stname);
					}


				}


				foreach (STNAME bind in stNameBindingList)
				{
					if (bind.LANGKD == "EN")
					{
						bind.STKNAM = TxtStokAdiIng.Text;
					}
					model.Stnames.Add(bind);

				}

				//////// STKMIZ /////////////////////
				model.Stkmiz = (STKMIZ)sTKMIZBindingSource.Current;

				//////// STURYR /////////////////////
				var stUryrBindingList = sTURYRBindingSource.List;
				model.Sturyrs = new List<STURYR>();

				foreach (var bind in stUryrBindingList)
				{
					model.Sturyrs.Add((STURYR)bind);
				}

				//////// STDPYN /////////////////////
				var stDpynBindingList = sTDPYNBindingSource.List;
				model.Stdpyns = new List<STDPYN>();

				foreach (var bind in stDpynBindingList)
				{
					model.Stdpyns.Add((STDPYN)bind);
				}

				//////// Ürün Opsiyon /////////////////////
				model.UrunOpsiyons = new List<UrunOpsiyonModel>();
				foreach (var opsiyon in opsiyonList)
				{
					foreach (KeyValuePair<int, List<UrunOpsiyonModel>> urOp in opsiyon)
					{
						model.UrunOpsiyons.AddRange(urOp.Value);
					}
				}

				//////// STBDRN/////////////////////
				var stBdrnBindingList = sTBDRNBindingSource1.List;
				model.Stbdrns = new List<STBDRN>();
				foreach (var bind in stBdrnBindingList)
				{
					model.Stbdrns.Add((STBDRN)bind);
				}

				model.Stkart.SADEGK = LkEdSaDegerAnahtari.EditValue.ToString();

				response = _stokService.Ncch_StokKartKaydet_Log(global, model, focusedRowHandler, _action);
				//var response = _stokService.Ncch_StokKartKaydet_Log(global, model, focusedRowHandler);
				if (response.Status != ResponseStatusEnum.OK)
				{
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				Directory.CreateDirectory(imageFolder);
				var imageName = TxtStokKodu.Text + ".jpg";
				File.Delete(imageFolder + imageName);
				if (PicStokResim.Image != null)
				{
					PicStokResim.Image.Save(imageFolder + imageName, ImageFormat.Jpeg);
				}

				opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

				//var sistemDilTanim = _stnameService.Cch_GetListByStokKoduLangkd_NLog(global, _stokKart.STKODU, false).Nesne;
				//if (sistemDilTanim == null)
				//{
				//    sistemDilTanim = new STNAME()
				//    {
				//        SIRKID = global.SirketId.Value,
				//        STKODU = _stokKart.STKODU,
				//        STKNAM = _stokKart.STKNAM,
				//        LANGKD = global.DilKod,
				//        ACTIVE = true,
				//        SLINDI = false,
				//        EKKULL = global.UserKod,
				//        ETARIH = DateTime.Now,
				//        KYNKKD = global.KaynakKod
				//    };
				//    _stnameService.Ncch_Add_NLog(sistemDilTanim, global);
				//}
				//else
				//{
				//    sistemDilTanim.STKNAM = _stokKart.STKNAM;
				//    sistemDilTanim.DEKULL = global.UserKod;
				//    sistemDilTanim.DTARIH = DateTime.Now;
				//    sistemDilTanim.KYNKKD = global.KaynakKod;
				//    sistemDilTanim.SLINDI = false;
				//    _stnameService.Ncch_Update_Log(sistemDilTanim, sistemDilTanim, global);
				//}

				gridView1.RefreshData();
				_action = "";
				var stkodu = model.Stkart.STKODU;
				gridView1.FocusedRowHandle = gridView1.LocateByValue("STKODU", stkodu);

				xtraTabControl1.SelectedTabPage = xtraTabPage1;
				if (yetkiModel == null)
					yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			}
		}

		protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle < 0) return;

			DialogResult Secim;
			Secim = MessageBox.Show("Silmek istediğinizden Eminmisiniz?", "Silme İşlemi", MessageBoxButtons.YesNo,
				MessageBoxIcon.Warning);
			if (Secim == DialogResult.Yes)
			{
				string stokKodu = gridView1.GetFocusedRowCellDisplayText("STKODU");
				var response = new StandardResponse();
				var model = new GenelStokKartModel();

				_stokKart = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;

				model.Stkart = _stokKart;
				model.Stdepos = _stdepoService.Cch_GetByStokKodu_NLog(global, stokKodu).Items;
				model.Stmhsbs = _stmhsbService.Cch_GetByStokKodu_NLog(global, stokKodu).Items;
				model.Stsales = _stsaleService.Cch_GetListByStokKodu_NLog(global, stokKodu).Items;
				model.Stolcus = _stolcuService.Ncch_GetByStKod_NLog(stokKodu, global).Items;
				model.Stnames = _stnameService.Cch_GetListByStokKodu_NLog(global, stokKodu).Items;
				model.Stkmiz = _stkmizService.Ncch_GetByStokKod_NLog(stokKodu, global).Nesne;
				model.Sturyrs = _sturyrService.Cch_GetListByStokKodu_NLog(stokKodu, global).Items;
				model.Stdpyns = _stdpynService.Cch_GetListByStokKodu_NLog(stokKodu, global).Items;
				model.Stbdrns = _stbdrnService.Cch_GetListByStokKodu_NLog(stokKodu, global).Items;

				response = _stokService.Ncch_StokKartKaydet_Log(global, model, focusedRowHandler, "delete");

				if (response.Status != ResponseStatusEnum.OK)
				{
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}

				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);

				string malzemeTuru = LkEdMalzTuru.EditValue.ToString();
				sTKARTBindingSource.DataSource =
					_stokKartService.Cch_GetListByMalTur_NLog(global, malzemeTuru, false).Items;
				gridView1.BestFitColumns();
				//gridView1.RefreshData();
			}
		}

		protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
		{
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			sTKARTBindingSource.CancelEdit();
			//gridView1.OptionsBehavior.Editable = false;
			//gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
			gridView1.RefreshData();
			xtraTabControl1.SelectedTabPage = xtraTabPage1;
			//focusedRowHandler.Clear();
			//LoadData();
			//this.Validate();
		}

		protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
		{
			gridControl4.RefreshDataSource();
		}

		protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!gridControl1.IsPrintingAvailable)
			{
				MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
				return;
			}

			gridView1.ShowPrintPreview();
		}

		protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
		{
			gridView1.OptionsView.ShowAutoFilterRow = gridView1.OptionsView.ShowAutoFilterRow == false;
		}

		protected override void barButQrKod_ItemClick(object sender, ItemClickEventArgs e)
		{
			STKART stkart = sTKARTBindingSource.Current as STKART;
			FrmQrCodeGenerator qForm = new FrmQrCodeGenerator(stkart, global);
			qForm.ShowDialog();
		}
		protected override void barButShopify_ItemClick(object sender, ItemClickEventArgs e)
		{
			FrmShopiFYProductEntegrasyon _shopify = new FrmShopiFYProductEntegrasyon(global);
			_shopify.ShowDialog();
		}


		private void LkEdMalzTuru_EditValueChanged(object sender, EventArgs e)
		{
			if (LkEdMalzTuru.EditValue != null)
			{
				var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
				string malzemeTuru = LkEdMalzTuru.EditValue.ToString();
				List<STKART> stkarts = _stokKartService.Cch_GetListByMalTur_NLog(global, malzemeTuru, false).Items;
				sTKARTBindingSource.DataSource = stkarts;
				gridView1.BestFitColumns();

				SetRepositoryLookups();
				LkEdMalGrubu.Properties.DataSource = malGrubuTanimList.Where(x => x.EXTRA1 == tur.STMLTR || x.EXTRA1 == "" || x.EXTRA1 == null).ToList();
				LkEdAnaGrup.Properties.DataSource = stokAnaGrupList.Where(x => x.EXTRA1 == tur.STMLTR || x.EXTRA1 == "" || x.EXTRA1 == null).ToList();
				LkEdStokGrup1.Properties.DataSource = stokGrup1List.Where(x => x.EXTRA1 == tur.STMLTR || x.EXTRA1 == "" || x.EXTRA1 == null).ToList();
				LkEdStokGrup2.Properties.DataSource = stokGrup2List.Where(x => x.EXTRA1 == tur.STMLTR || x.EXTRA1 == "" || x.EXTRA1 == null).ToList();
				LkEdStokGrup3.Properties.DataSource = stokGrup3List.Where(x => x.EXTRA1 == tur.STMLTR || x.EXTRA1 == "" || x.EXTRA1 == null).ToList();
				colRENKKD.Visible = tur.STRENK ?? false;
				colBEDNKD.Visible = tur.STBDEN ?? false;
				colDROPKD.Visible = tur.STDROP ?? false;
			}
		}

		private void SetRepositoryLookups()
		{
			List<STKART> stkarts = new List<STKART>();
			for (int i = 0; i < gridView1.RowCount; i++)
			{
				STKART cust = gridView1.GetRow(i) as STKART;
				stkarts.Add(cust);
			}

			List<TipHareketListModel> filteredList = new List<TipHareketListModel>();

			var parentHarkods = stkarts.Select(s => s.STANKD).Distinct().ToList();
			foreach (string harkod in parentHarkods)
			{
				TipHareketListModel anaGrup = stokAnaGrupList.FirstOrDefault(s => s.HARKOD == harkod);
				filteredList.AddRange(stokAltGrupList.Where(s => s.PARENT == anaGrup.Id).ToList());
			}

			repLkedStokAltGrup.DataSource = filteredList;
		}

		private void LkEdAnaGrup_EditValueChanged(object sender, EventArgs e)
		{
			if (LkEdAnaGrup.EditValue != null)
			{
				var teknads = new List<string>() { "STALKD" };
				var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
				var list = (List<TipHareketListModel>)LkEdAnaGrup.Properties.DataSource;
				var anaGrup = list.FirstOrDefault(f => f.HARKOD == LkEdAnaGrup.EditValue.ToString());
				if (anaGrup != null)
				{
					LkEdAltGrup.Properties.DataSource = teknadsResponse.Items
						.Where(w => w.TEKNAD == "STALKD" && w.PARENT == anaGrup.Id).ToList();
				}
				else
				{
					LkEdAltGrup.Properties.DataSource = null;
				}
			}
			else
			{
				LkEdAltGrup.Properties.DataSource = null;
			}
		}

		private void gridView_CellValueChanged(object sender,
			DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			GridView view = sender as GridView;
			if (view == null) return;

			var cellValue = (int)view.GetRowCellValue(e.RowHandle, view.Columns["Id"]);
			if (cellValue > 0)
			{
				var a = focusedRowHandler.FirstOrDefault(x => x.Id == cellValue);

				if (a == null)
				{
					focusedRowHandler.Add(new Grid(cellValue, "update", view.Tag.ToString()));
				}
			}

			if (view.Tag.ToString() == "STDEPO" && e.Column.FieldName == "URYRKD" && e.Value != null)
			{
				repStDepoDpKodu.DataSource = null;
				repSTDepoTedKod.DataSource = null;
				repStDepoDpKodu.DataSource =
					_gndptnService.Cch_GetListByUretimYeri_NLog(e.Value.ToString(), global).Items ?? new List<GNDPTN>();
				repSTDepoTedKod.DataSource =
					_sttdtrService.Cch_GetListByUretimYeri_NLog(e.Value.ToString(), global).Items ?? new List<STTDTR>();
				repSTDepoTedKod.View.RefreshEditor(true);

				//view.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.Default;
				//view.OptionsBehavior.EditingMode = DevExpress.XtraGrid.Views.Grid.GridEditingMode.EditForm;
			}

			if (view == gridView1)
			{
				var oldStkart = (STKART)sTKARTBindingSource.Current;
				var stkart = oldStkart.ShallowCopy();
				stkart.STEKOD = e.Value != null ? e.Value.ToString() : "";

				oldStkart = _stokKartService.Ncch_Update_Log(stkart, oldStkart, global).Nesne;
				gridView1.RefreshData();
			}
		}

		private void gridViewB_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewB.SetRowCellValue(e.RowHandle, gridViewB.Columns["STKODU"], stKart.STKODU);
			}

			gridViewB.SetRowCellValue(e.RowHandle, gridViewB.Columns["ACTIVE"], true);
		}

		private void gridViewB_RowUpdated(object sender, DevExpress.XtraGrid.Views.Base.RowObjectEventArgs e)
		{
			//var dtSrc = ((List<STMHSB>)sTMHSBBindingSource.DataSource).Select(s => s.ShallowCopy()).ToList();
			//var stMhsb = (STMHSB)sTMHSBBindingSource.Current;

			//dtSrc.RemoveAll(f =>
			//    f.STKODU == stMhsb.STKODU && f.STFTNO == stMhsb.STFTNO && f.HSPKOD == stMhsb.HSPKOD &&
			//    f.DPKODU == stMhsb.DPKODU && f.Id == stMhsb.Id);

			//var control = dtSrc.FirstOrDefault(f =>
			//    f.STKODU == stMhsb.STKODU && f.STFTNO == stMhsb.STFTNO && f.HSPKOD == stMhsb.HSPKOD &&
			//    f.DPKODU == stMhsb.DPKODU && f.Id != 0);

			//if (control != null)
			//{
			//    MessageBox.Show("Aynı kayıttan birden fazla ekleyemezsiniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			//    gridViewB.CancelUpdateCurrentRow();
			//}
			//gridViewB.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
		}

		private void gridViewB_ValidatingEditor(object sender,
			DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
		{
			var dtSrc = ((List<STMHSB>)sTMHSBBindingSource.DataSource).Select(s => s.ShallowCopy()).ToList();
			var stMhsb = (STMHSB)sTMHSBBindingSource.Current;

			dtSrc.RemoveAll(f =>
				f.STKODU == stMhsb.STKODU && f.STFTNO == stMhsb.STFTNO && f.HSPKOD == stMhsb.HSPKOD &&
				f.DPKODU == stMhsb.DPKODU && f.Id == stMhsb.Id);

			var control = dtSrc.FirstOrDefault(f =>
				f.STKODU == stMhsb.STKODU && f.STFTNO == stMhsb.STFTNO && f.HSPKOD == stMhsb.HSPKOD &&
				f.DPKODU == stMhsb.DPKODU && f.Id != 0);

			if (control != null)
			{
				MessageBox.Show("Aynı kayıttan birden fazla ekleyemezsiniz!", "Hata", MessageBoxButtons.OK,
					MessageBoxIcon.Error);
				gridViewB.CloseEditForm();
			}
		}

		private void mALHSPTLKE_EditValueChanged(object sender, EventArgs e)
		{
			if (mALHSPTLKE.EditValue != null && !string.IsNullOrEmpty(mALHSPTLKE.EditValue.ToString()))
			{
				var tip = (MaliyetHesapTipEnum)mALHSPTLKE.EditValue.ToInt32();
				if (tip == MaliyetHesapTipEnum.Standart)
				{
					kAYORTEdtText.Text = "0";
					kAYORTEdtText.Enabled = false;
					sTNFIYEdtText.Focus();
					sTNFIYEdtText.Enabled = true;
				}
				else
				{
					sTNFIYEdtText.Text = "0";
					sTNFIYEdtText.Enabled = false;
					kAYORTEdtText.Focus();
					kAYORTEdtText.Enabled = true;
				}
			}
		}

		private void gridViewOlcu_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewOlcu.SetRowCellValue(e.RowHandle, gridViewOlcu.Columns["STKODU"], stKart.STKODU);
				gridViewOlcu.SetRowCellValue(e.RowHandle, gridViewOlcu.Columns["OLCUKD"], stKart.OLCUKD);
			}

			gridViewOlcu.SetRowCellValue(e.RowHandle, gridViewOlcu.Columns["ACTIVE"], true);
		}

		private void gridViewStDepo_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewStDepo.SetRowCellValue(e.RowHandle, gridViewStDepo.Columns["STKODU"], stKart.STKODU);
			}

			gridViewStDepo.SetRowCellValue(e.RowHandle, gridViewStDepo.Columns["ACTIVE"], true);
		}

		private void gridViewStSale_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewStSale.SetRowCellValue(e.RowHandle, gridViewStSale.Columns["STKODU"], stKart.STKODU);
			}

			gridViewStSale.SetRowCellValue(e.RowHandle, gridViewStSale.Columns["ACTIVE"], true);
		}

		private void gridViewStName_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewStName.SetRowCellValue(e.RowHandle, gridViewStName.Columns["STKODU"], stKart.STKODU);
			}

			gridViewStName.SetRowCellValue(e.RowHandle, gridViewStName.Columns["ACTIVE"], true);
		}

		private void gridViewSTURYR_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewStName.SetRowCellValue(e.RowHandle, gridViewStName.Columns["STKODU"], stKart.STKODU);
			}

			gridViewStName.SetRowCellValue(e.RowHandle, gridViewStName.Columns["ACTIVE"], true);
		}

		private void gridViewStDpyn_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewStName.SetRowCellValue(e.RowHandle, gridViewStName.Columns["STKODU"], stKart.STKODU);
			}

			gridViewStName.SetRowCellValue(e.RowHandle, gridViewStName.Columns["ACTIVE"], true);
		}

		private void gridViewRenk_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewRenk.SetRowCellValue(e.RowHandle, gridViewRenk.Columns["STKODU"], stKart.STKODU);
				///gel//
			}

			gridViewRenk.SetRowCellValue(e.RowHandle, gridViewRenk.Columns["ACTIVE"], true);
		}

		private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
		{
			if (deletedId != null)
			{
				ToolStripButton toolStripButton = sender as ToolStripButton;
				if (toolStripButton == null) return;
				var tag = toolStripButton.Tag.ToString();
				//var a = focusedRowHandler.FirstOrDefault(f => f.View == tag);
				//if (a != null)
				//{
				//    focusedRowHandler.Remove(a);
				//}

				focusedRowHandler.Add(new Grid(deletedId.Value, "delete", tag));
				deletedId = null;
			}
		}

		private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
		{
			ToolStripButton toolStripButton = sender as ToolStripButton;
			if (toolStripButton == null) return;
			var tag = toolStripButton.Tag.ToString();

			deletedId = null;

			if (tag == "STDEPO")
			{
				var current = (STDEPO)sTDEPOBindingSource.Current;
				if (current != null && current.Id > 0)
				{
					deletedId = current.Id;
				}
			}
			else if (tag == "STOLCU")
			{
				var current = (STOLCU)sTOLCUBindingSource.Current;
				if (current != null && current.Id > 0)
				{
					deletedId = current.Id;
				}
			}
			else if (tag == "STURYR")
			{
				var current = (STURYR)sTURYRBindingSource.Current;
				if (current != null && current.Id > 0)
				{
					deletedId = current.Id;
				}
			}
			else if (tag == "STNAME")
			{
				var current = (STNAME)sTNAMEBindingSource.Current;
				if (current != null && current.Id > 0)
				{
					deletedId = current.Id;
				}
			}
			else if (tag == "STBDRN")
			{
				var current = (STBDRN)sTBDRNBindingSource1.Current;
				if (current != null && current.Id > 0)
				{
					deletedId = current.Id;
				}
			}

		}

		private void gridControl1_DoubleClick(object sender, EventArgs e)
		{
			Point point = gridView1.GridControl.PointToClient(MousePosition);
			DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = gridView1.CalcHitInfo(point);
			if (info.InRow || info.InRowCell)
			{
				if (info.Column.FieldName == "STEKOD" && gridView1.OptionsBehavior.Editable)
				{
					info.Column.OptionsColumn.AllowEdit = true;
					info.Column.OptionsColumn.ReadOnly = false;
				}
				else
				{
					var link = barDegistir.GetVisibleLinks()[0];
					ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
					barDegistir_ItemClick(barDegistir, arg);
				}
			}
		}

		private void repLkedStkartDepoTip_Popup(object sender, EventArgs e)
		{
			GridLookUpEdit editor = (GridLookUpEdit)gridView1.ActiveEditor;
			//editor.Properties.View.ActiveFilterCriteria = null;
			//editor.Properties.View.ActiveFilterString = "";

			string depoKod = gridView1.GetFocusedRowCellValue("DEPOKD").ToString();
			if (depoKod != "")
			{
				((STDPYN)sTDPYNBindingSource.Current).DEPOKD = depoKod;
				sTDPYNBindingSource.CurrencyManager.Refresh();

				editor.Properties.View.ActiveFilterCriteria = null;
				editor.Properties.View.ActiveFilterCriteria =
					DevExpress.Data.Filtering.CriteriaOperator.Parse("DEPOKD == " + depoKod);
			}
		}

		private void repLkedStDpynDepoNo_EditValueChanged(object sender, EventArgs e)
		{
			((STDPYN)sTDPYNBindingSource.Current).DPTIPI = null;
			sTDPYNBindingSource.CurrencyManager.Refresh();
		}

		private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			Point point = gridView1.GridControl.PointToClient(MousePosition);
			GridHitInfo info = gridView1.CalcHitInfo(point);
			if ((info.InRow || info.InRowCell) && info.RowHandle > -1)
			{
				STKART stkart = sTKARTBindingSource.Current as STKART;
				string maxUaKodu = _uragacService.GetMaxUrunAgaciKodu(stkart.STKODU, "1", global).Nesne;

				if (stkart.STMLTR == Param.MAMUL_KODU && string.IsNullOrEmpty(maxUaKodu))
					barButPaketKodu.Visibility = BarItemVisibility.Always;
				else barButPaketKodu.Visibility = BarItemVisibility.Never;

				var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
				if (tur != null && tur.STMLTR == Param.MAMUL_KODU) barButModulPaketEkle.Visibility = BarItemVisibility.Always;
				else barButModulPaketEkle.Visibility = BarItemVisibility.Never;

				popEtiket.ShowPopup(MousePosition);
			}
		}

		private void barButYazdir_ItemClick(object sender, ItemClickEventArgs e)
		{
			short.TryParse(txtEtiketAdet.EditValue.ToString(), out _etiketSayisi);
			//if (_etiketSayisi > 100)
			//{
			//    MessageBox.Show("Tek seferde en fazla 100 adet etiket yazdırabilirsiniz!", "Bilgi",
			//        MessageBoxButtons.OK, MessageBoxIcon.Information);
			//    return;
			//}

			var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
			if (tur == null) return;

			string stokKodu = gridView1.GetFocusedRowCellDisplayText("STKODU");
			string stokAdi = gridView1.GetFocusedRowCellDisplayText("STKNAM");

			if (Param.ADAPTATION == Adaptation.Aracikan)
			{
				if (e.Item.Caption == "Etiket Yazdır (Büyük)")
				{
					repPaketEtiket rEtiket = new repPaketEtiket();
					rEtiket.CreateDocument();
					rEtiket.Pages.Clear();

					List<UrunAgaciModulPaket> modulPaketList = new List<UrunAgaciModulPaket>();
					if (tur.STMLTR == Param.MAMUL_KODU) modulPaketList = uaModulPaketList.Where(u => u.MDKODU == stokKodu).ToList();
					else if (tur.STMLTR == "002") modulPaketList = uaModulPaketList.Where(u => u.PKKODU == stokKodu).ToList();
					else return;

					foreach (UrunAgaciModulPaket uaModulPaket in modulPaketList)
					{
						for (int i = 0; i < _etiketSayisi; i++)
						{
							repPaketEtiket etiket = PaketEtiketYazdir(uaModulPaket);
							if (etiket != null)
							{
								etiket.CreateDocument();
								rEtiket.Pages.AddRange(etiket.Pages);
							}

						}
					}

					rEtiket.ShowRibbonPreviewDialog();
				}
				else
				{
					string etiketPath = AppDomain.CurrentDomain.BaseDirectory + "\\100x40.repx";

					var rEtiket = XtraReport.FromFile(etiketPath) as repBarkodEtiket;
					rEtiket.lblStokAdi.Text = stokAdi;
					rEtiket.xrBarcode.Text = stokKodu;

					rEtiket.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
					rEtiket.Print();
				}
			}
			else if (Param.ADAPTATION == Adaptation.Bala)
			{
				OpenFileDialog openFileDialog1 = new OpenFileDialog
				{
					InitialDirectory = AppDomain.CurrentDomain.BaseDirectory,
					Title = "Etiket Şablonu",

					CheckFileExists = true,
					CheckPathExists = true,

					DefaultExt = "repx",
					Filter = "repx Dosyaları (*.repx)|*.repx",
					FilterIndex = 2,
					RestoreDirectory = true,
					ReadOnlyChecked = true,
					ShowReadOnly = true
				};

				if (openFileDialog1.ShowDialog() == DialogResult.OK)
				{
					var rEtiket = XtraReport.FromFile(openFileDialog1.FileName) as repBarkodEtiket;
					rEtiket.lblStokAdi.Text = stokAdi;
					rEtiket.xrBarcode.Text = stokKodu;

					rEtiket.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
					rEtiket.ShowRibbonPreviewDialog();
				}
			}

			//önceki------------------------------------------------
			//ReportDesignTool designTool = new ReportDesignTool(rEtiket);
			//designTool.ShowRibbonDesignerDialog(UserLookAndFeel.Default);

			//Aracıkan
			//string stokKodu = gridView1.GetFocusedRowCellDisplayText("STKODU");
			//string stokAdi = gridView1.GetFocusedRowCellDisplayText("STKNAM");

			//repBarkodEtiket rEtiket = new repBarkodEtiket();
			//rEtiket.lblStokAdi.Text = stokAdi;
			//rEtiket.xrBarcode.Text = stokKodu;

			//rEtiket.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
			//rEtiket.Print();
		}

		private void PrintingSystem_StartPrint(object sender, PrintDocumentEventArgs e)
		{
			_etiketSayisi = Convert.ToInt16(txtEtiketAdet.EditValue);
			e.PrintDocument.PrinterSettings.Copies = _etiketSayisi;
		}

		private repPaketEtiket PaketEtiketYazdir(UrunAgaciModulPaket uaModulPaket)
		{
			//var paketModul = _uragacService.Ncch_GetUrunAgaciUst_NLog(global, stkart.STKODU).Items.OrderByDescending(o => o.BASTAR).ToList();
			//if (paketModul.Count == 0)
			//{
			//    MessageBox.Show("Paket herhangi bir modüle bağlı değil. Ürün Ağacı menüsünden modül bağlantısı yapmadan etiket yazdıramazsınız.", stkart.STKODU + " - " + stkart.STKNAM, MessageBoxButtons.OK, MessageBoxIcon.Information);
			//    return;
			//}

			repPaketEtiket paketEtiket = new repPaketEtiket();

			decimal genislik = uaModulPaket.GENSLK;
			decimal yukseklik = uaModulPaket.YUKSLK;
			decimal uzunluk = uaModulPaket.UZUNLK;
			int brutAgirlik = uaModulPaket.BRTAGR.ToInt32();
			//int netAgirlik = stKart.NETAGR.HasValue ? stKart.NETAGR.ToInt32() : 0;
			decimal hacim = 0;

			if (uaModulPaket.UGYBKD == "MM") hacim = genislik * yukseklik * uzunluk / 1000000000;
			if (uaModulPaket.UGYBKD == "CM") hacim = genislik * yukseklik * uzunluk / 1000000;
			if (uaModulPaket.UGYBKD == "M") hacim = genislik * yukseklik * uzunluk;

			paketEtiket.cellModulKodu.Text = uaModulPaket.MDKODU;
			paketEtiket.cellModulAdi.Text = paketEtiket.cellModulAdi2.Text = uaModulPaket.MDLNAM + " / " + uaModulPaket.MDNMEN;
			paketEtiket.cellPaketKodu.Text = uaModulPaket.PKKODU;
			paketEtiket.cellPaketAdi.Text = uaModulPaket.PKTNAM + " / " + uaModulPaket.PKNMEN;
			paketEtiket.barcodeHorizontal.Text = uaModulPaket.PKKODU;
			paketEtiket.barcodeVertical.Text = uaModulPaket.PKKODU;
			paketEtiket.lblOlcu.Text = $@"{genislik.ToInt32()}x{uzunluk.ToInt32()}x{yukseklik.ToInt32()}";
			paketEtiket.lblAgirlik.Text = $@"{brutAgirlik} {uaModulPaket.AGOLKD}";
			paketEtiket.lblHacim.Text = $@"{hacim.ToString("N6")} M3";

			if (Param.ADAPTATION == Adaptation.Aracikan)
			{
				var parcaList = _uragacService.Ncch_GetUrunAgaciModulPaketParcaList_NLog(global, paketKodu: uaModulPaket.PKKODU, langKd: "en-EN").Items;
				if (parcaList == null || parcaList.Count == 0)
				{
					//DialogResult secim = MessageBox.Show("Pakete bağlı parça bulunamadı. Yazdırma işlemine devam etmek istiyor musunuz?", uaModulPaket.PKKODU + " - " + uaModulPaket.PKTNAM, MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
					//if (secim != DialogResult.Yes) return null;
				}
				else
				{
					for (int i = 0; i < parcaList.Count; i++)
					{
						var parca = parcaList[i];
						string sira = (i + 1).ToString();

						paketEtiket.ReportHeader.Controls["lblParca" + sira].Text = parca.PRNAME + " / " + parca.PRYBNM ?? "";
						paketEtiket.ReportHeader.Controls["lblParcaAdet" + sira].Text = parca.GNMKTR.ToInt32().ToString();
					}
				}

				//imageFolder = AppDomain.CurrentDomain.BaseDirectory + "images\\stok\\20\\"; //Arin'de 20
				//var imageName = paketModul[0].USKODU + ".jpg";
				//var imagePath = imageFolder + imageName;
				//if (File.Exists(imagePath))
				//{
				//    Bitmap origbmp = new Bitmap(imagePath);
				//    Bitmap bitmap = new Bitmap(origbmp);
				//    origbmp.Dispose();

				//    paketEtiket.picStok.Image = bitmap;
				//}

				var paketler = _uragacService.Ncch_GetUrunAgaci_NLog(uaModulPaket.URAKOD, global).Items;
				var paketNo = uaModulPaket.PKKODU.Substring(uaModulPaket.PKKODU.Length - 2).ToInt32(); //Paket numarası son iki karakter

				paketEtiket.lblPaketNo.Text =
					paketEtiket.lblPaketNo1.Text = paketNo.ToString() + "/" + paketler.Count.ToString();

				//paketEtiket.ShowRibbonPreviewDialog();
			}

			return paketEtiket;
		}

		private void btnParcaSec_Click(object sender, EventArgs e)
		{
			if (LkEdMalGrubu.EditValue.ToString() == "" || LkEdAnaGrup.EditValue.ToString() == "" ||
				LkEdAltGrup.EditValue.ToString() == "")
			{
				MessageBox.Show("Mal Grubu, Ana Grup ve Alt Grubu seçmeden parça ekleyemezsiniz!", "Bilgi",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			FrmParcaSecim pForm = new FrmParcaSecim();
			pForm.global = global;
			pForm.SetDesktopLocation(Cursor.Position.X, Cursor.Position.Y);
			pForm.ShowDialog(this);

			if (pForm.parcaKodu != "")
			{
				string stokKodu = "";
				var malGrubu = LkEdMalGrubu.GetSelectedDataRow() as TipHareketListModel;
				var stokAltGrubu = LkEdAltGrup.GetSelectedDataRow() as TipHareketListModel;
				string stokAdi = "";

				string altGrup = "";
				if (stokAltGrubu != null) altGrup = stokAltGrubu.TANIMI;

				if (Param.ADAPTATION == Adaptation.Aracikan)
				{
					stokKodu = LkEdMalGrubu.EditValue.ToString() + "." + LkEdAnaGrup.EditValue.ToString() +
								   LkEdAltGrup.EditValue.ToString() + ".01." + pForm.parcaKodu;
					stokAdi = malGrubu.TANIMI + " " + stokAltGrubu.TANIMI + " - " + pForm.parcaAdi;
				}

				TxtStokKodu.Focus();
				TxtStokKodu.EditValue = stokKodu;
				TxtStokAdi.Focus();
				TxtStokAdi.EditValue = stokAdi;

				LkEdOlcuBirimi.Focus();
				LkEdOlcuBirimi.EditValue = "ADT";
				LkEdSaOlcuBirimi.Focus();
				LkEdSaOlcuBirimi.EditValue = "ADT";

				btnParcaSec.Focus();
			}
		}

		private void xtraTabControl1_SelectedPageChanged(object sender, TabPageChangedEventArgs e)
		{
			btnParcaSec.Visible = false;
			btnKodOlustur.Visible = false;

			if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
			{
				if (Param.ADAPTATION == Adaptation.Nesto)
				{
					btnKodOlustur.Visible = true;
				}
				else
				{
					var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
					if (tur != null && (tur.STMLTR == "003" || tur.STMLTR == "28" || tur.STMLTR == "18"))
						btnParcaSec.Visible = true;
					else btnKodOlustur.Visible = true;
				}

				var imageName = TxtStokKodu.Text + ".jpg";
				var imagePath = imageFolder + imageName;
				if (File.Exists(imagePath))
				{
					Bitmap origbmp = new Bitmap(imagePath);
					Bitmap bitmap = new Bitmap(origbmp);
					origbmp.Dispose();

					PicStokResim.Image = bitmap;
				}
			}
			else
			{
				PicStokResim.Image = null;
			}
		}

		private void btnKodOlustur_Click(object sender, EventArgs e)
		{
			LkEdOlcuBirimi.Focus();
			LkEdOlcuBirimi.EditValue = "ADT";
			LkEdOlcuBirimi.Text = "ADT";
			LkEdSaOlcuBirimi.Focus();
			LkEdSaOlcuBirimi.EditValue = "ADT";
			LkEdSaOlcuBirimi.Text = "ADT";

			string tur = TxtMalzemeTuru.Text;

			if (Param.ADAPTATION == Adaptation.Bala)
			{
				if (LkEdAnaGrup.EditValue.ToString() == "")
				{
					MessageBox.Show("Ana Grup seçmeden kod oluşturamazsınız!", "Bilgi",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				var malGrubu = LkEdMalGrubu.GetSelectedDataRow() as TipHareketListModel;
				string malgrubuKodu = malGrubu.HARKOD;

				string stokKodu = malgrubuKodu + ".";

				var stokKart = _stokKartService.Ncch_GetByStKodLike_NLog(stokKodu, tur, global).Nesne;

				int siraNo = stokKart == null ? 1 : Convert.ToInt32(stokKart.STKODU.Substring(stokKodu.Length)) + 1;
				stokKodu += siraNo.ToString("D4");

				TxtStokKodu.Focus();
				TxtStokKodu.EditValue = stokKodu;
				TxtStokAdi.Focus();
			}
			else if (Param.ADAPTATION == Adaptation.Ironsan)
			{
				if (LkEdAnaGrup.EditValue.ToString() == "")
				{
					MessageBox.Show("Ana Grup seçmeden kod oluşturamazsınız!", "Bilgi",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				if (tur == "01")
				{
					var altDataSource = LkEdAltGrup.Properties.DataSource as List<TipHareketListModel>;
					if (altDataSource != null && altDataSource.Count > 0 && LkEdAltGrup.EditValue.ToString() == "")
					{
						MessageBox.Show("Alt grup seçmediniz!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}

				var stokAnaGrup = LkEdAnaGrup.GetSelectedDataRow() as TipHareketListModel;
				var stokAltGrup = LkEdAltGrup.GetSelectedDataRow() as TipHareketListModel;

				string anaGrupKodu = stokAnaGrup.HARKOD;
				string altGrupKodu = stokAltGrup == null ? "00" : stokAltGrup.HARKOD;

				string stokKodu = anaGrupKodu + "." + altGrupKodu + ".";

				var stokKart = _stokKartService.Ncch_GetByStKodLike_NLog(stokKodu, tur, global).Nesne;

				int siraNo = stokKart == null ? 1 : Convert.ToInt32(stokKart.STKODU.Substring(stokKodu.Length)) + 1;

				if (tur == "01" || tur == "03") stokKodu += siraNo.ToString("D5");
				else stokKodu += siraNo.ToString("D4");

				TxtStokKodu.Focus();
				TxtStokKodu.EditValue = stokKodu;
				TxtStokAdi.Focus();
			}
			else if (Param.ADAPTATION == Adaptation.Aracikan)
			{
				string stokKodu = "";
				string stokAdi = "";
				if (tur == Param.MAMUL_KODU)
				{
					if (LkEdMalGrubu.EditValue.ToString() == "")
					{
						MessageBox.Show("Mal Grubu seçmeden kod oluşturamazsınız!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					if (LkEdAnaGrup.EditValue.ToString() == "")
					{
						MessageBox.Show("Ana Grup seçmeden kod oluşturamazsınız!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					var altDataSource = LkEdAltGrup.Properties.DataSource as List<TipHareketListModel>;
					if (altDataSource != null && altDataSource.Count > 0 && LkEdAltGrup.EditValue.ToString() == "")
					{
						MessageBox.Show("Alt Grup seçmeden kod oluşturamazsınız!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					var malGrubu = LkEdMalGrubu.GetSelectedDataRow() as TipHareketListModel;
					var stokAnaGrup = LkEdAnaGrup.GetSelectedDataRow() as TipHareketListModel;
					var stokAltGrup = LkEdAltGrup.GetSelectedDataRow() as TipHareketListModel;

					string malGrupKodu = malGrubu.HARKOD;
					string anaGrupKodu = stokAnaGrup.HARKOD;
					string altGrupKodu = stokAltGrup == null ? "00" : stokAltGrup.HARKOD;

					stokKodu = malGrupKodu + "." + anaGrupKodu + altGrupKodu + ".";
					stokAdi = malGrubu.TANIMI + " " + stokAltGrup.TANIMI;

					var stokKart = _stokKartService.Ncch_GetByStKodLike_NLog(stokKodu, tur, global).Nesne;

					int siraNo = stokKart == null ? 1 : Convert.ToInt32(stokKart.STKODU.Substring(stokKodu.Length)) + 1;
					stokKodu += siraNo.ToString("D2");
				}
				else if (tur != Param.MAMUL_KODU && tur != "002" && tur != "003")
				{
					if (LkEdAnaGrup.EditValue.ToString() == "")
					{
						MessageBox.Show("Ana Grup seçmeden kod oluşturamazsınız!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					var altDataSource = LkEdAltGrup.Properties.DataSource as List<TipHareketListModel>;
					if (altDataSource != null && altDataSource.Count > 0 && LkEdAltGrup.EditValue.ToString() == "")
					{
						MessageBox.Show("Alt grup seçmediniz!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					var stokAnaGrup = LkEdAnaGrup.GetSelectedDataRow() as TipHareketListModel;
					var stokAltGrup = LkEdAltGrup.GetSelectedDataRow() as TipHareketListModel;

					string anaGrupKodu = stokAnaGrup.HARKOD;
					string altGrupKodu = stokAltGrup == null ? "00" : stokAltGrup.HARKOD;

					stokKodu = anaGrupKodu + "." + altGrupKodu + ".";

					var stokKart = _stokKartService.Ncch_GetByStKodLike_NLog(stokKodu, tur, global).Nesne;

					int siraNo = stokKart == null ? 1 : Convert.ToInt32(stokKart.STKODU.Substring(stokKodu.Length)) + 1;
					stokKodu += siraNo.ToString("D4");
				}

				TxtStokKodu.Focus();
				TxtStokKodu.EditValue = stokKodu;
				TxtStokAdi.Focus();
				TxtStokAdi.EditValue = stokAdi;
			}
			else if (Param.ADAPTATION == Adaptation.Otonom)
			{
				if (LkEdAnaGrup.EditValue.ToString() == "")
				{
					MessageBox.Show("Ana Grup seçmeden kod oluşturamazsınız!", "Bilgi",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				if (tur == "01")
				{
					var altDataSource = LkEdAltGrup.Properties.DataSource as List<TipHareketListModel>;
					if (altDataSource != null && altDataSource.Count > 0 && LkEdAltGrup.EditValue.ToString() == "")
					{
						MessageBox.Show("Alt grup seçmediniz!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}

				var malGrubu = LkEdMalGrubu.GetSelectedDataRow() as TipHareketListModel;
				var stokAnaGrup = LkEdAnaGrup.GetSelectedDataRow() as TipHareketListModel;
				var stokAltGrup = LkEdAltGrup.GetSelectedDataRow() as TipHareketListModel;

				string anaGrupKodu = stokAnaGrup.HARKOD;
				string altGrupKodu = stokAltGrup == null ? "00" : stokAltGrup.HARKOD;

				string stokKodu = anaGrupKodu + "." + altGrupKodu + ".";

				var stokKart = _stokKartService.Ncch_GetByStKodLike_NLog(stokKodu, tur, global).Nesne;

				int siraNo = stokKart == null ? 1 : Convert.ToInt32(stokKart.STKODU.Substring(stokKodu.Length)) + 1;

				stokKodu += siraNo.ToString("D4");
				string stokAdi = "";
				if (LkEdMalGrubu.EditValue.ToString() != "") stokAdi = malGrubu.TANIMI + " ";

				if (anaGrupKodu == "01") stokAdi = stokAdi + stokAnaGrup.TANIMI;
				else if (anaGrupKodu == "02") stokAdi = stokAdi + stokAltGrup.TANIMI;

				TxtStokKodu.Focus();
				TxtStokKodu.EditValue = stokKodu;
				TxtStokAdi.Focus();
				TxtStokAdi.EditValue = stokAdi;
			}
			else if (Param.ADAPTATION == Adaptation.Nesto)
			{
				if (LkEdAnaGrup.EditValue.ToString() == "")
				{
					MessageBox.Show("Ana Grup seçmeden kod oluşturamazsınız!", "Bilgi",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				string stokKodu = "";
				string malzemeTuru = LkEdMalzTuru.EditValue.ToString();
				if (malzemeTuru != Param.MAMUL_KODU && malzemeTuru != "002")
				{
					STKART stokKart = _stokKartService.Ncch_GetRecentByMalTur_NLog(global, malzemeTuru, false).Nesne;
					int siraNo = stokKart == null ? 1 : Convert.ToInt32(stokKart.STKODU) + 1;
					stokKodu = siraNo.ToString("D7");
				}

				TxtStokKodu.Focus();
				TxtStokKodu.EditValue = stokKodu;
				TxtStokAdi.Focus();
			}
			else if (Param.ADAPTATION == Adaptation.SelmaCilek)
			{
				if (LkEdAnaGrup.EditValue.ToString() == "")
				{
					MessageBox.Show("Ana Grup seçmeden kod oluşturamazsınız!", "Bilgi",
						MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				if (tur == "01")
				{
					var sezon = LkEdMalGrubu.Properties.DataSource as List<TipHareketListModel>;
					if (sezon != null && sezon.Count > 0 && LkEdMalGrubu.EditValue.ToString() == "")
					{
						MessageBox.Show("Sezon seçmediniz!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					var altDataSource = LkEdAltGrup.Properties.DataSource as List<TipHareketListModel>;
					if (altDataSource != null && altDataSource.Count > 0 && LkEdAltGrup.EditValue.ToString() == "")
					{
						MessageBox.Show("Alt grup seçmediniz!", "Bilgi",
							MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}
				}

				var malGrubu = LkEdMalGrubu.GetSelectedDataRow() as TipHareketListModel;
				var stokAnaGrup = LkEdAnaGrup.GetSelectedDataRow() as TipHareketListModel;
				var stokAltGrup = LkEdAltGrup.GetSelectedDataRow() as TipHareketListModel;

				string anaGrupKodu = stokAnaGrup.HARKOD;
				string altGrupKodu = stokAltGrup == null ? "00" : stokAltGrup.HARKOD;

				string stokKodu = anaGrupKodu;

				var stokKart = _stokKartService.Ncch_GetByStKodLike_NLog(altGrupKodu, tur, global).Nesne;
				int siraNo = stokKart == null ? 1 : Convert.ToInt32(stokKart.STKODU.Substring(2, 4)) + 1;
				stokKodu = altGrupKodu + siraNo.ToString("D5");

				string stokAdi = "";
				if (LkEdMalGrubu.EditValue.ToString() != "") stokAdi = malGrubu.TANIMI + " ";

				//if (anaGrupKodu == "01") stokAdi = stokAdi + stokAnaGrup.TANIMI;
				//else if (anaGrupKodu == "02") stokAdi = stokAdi + stokAltGrup.TANIMI;

				TxtStokKodu.Focus();
				TxtStokKodu.EditValue = stokKodu;
				TxtStokAdi.Focus();
				TxtStokAdi.EditValue = stokAdi;
			}
		}

		private void gridViewOlcu_EditFormShowing(object sender, EditFormShowingEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewOlcu.SetRowCellValue(e.RowHandle, gridViewOlcu.Columns["STKODU"], stKart.STKODU);
				gridViewOlcu.SetRowCellValue(e.RowHandle, gridViewOlcu.Columns["OLCUKD"], stKart.OLCUKD);
			}

			gridViewOlcu.SetRowCellValue(e.RowHandle, gridViewOlcu.Columns["ACTIVE"], true);

			gridViewStDepo_EditFormShowing(sender, e);
		}
		private void gridViewRenk_EditFormShowing(object sender, EditFormShowingEventArgs e)
		{
			var stKart = (STKART)sTKARTBindingSource.Current;
			if (stKart != null)
			{
				gridViewRenk.SetRowCellValue(e.RowHandle, gridViewRenk.Columns["STKODU"], stKart.STKODU);
				//gridViewRenk.SetRowCellValue(e.RowHandle, gridViewRenk.Columns["OLCUKD"], stKart.OLCUKD);
			}

			gridViewRenk.SetRowCellValue(e.RowHandle, gridViewRenk.Columns["ACTIVE"], true);

			gridViewStDepo_EditFormShowing(sender, e);
		}

		private void gridViewStDepo_EditFormShowing(object sender, EditFormShowingEventArgs e)
		{
			GridView view = sender as GridView;
			view.OptionsEditForm.FormCaptionFormat = TxtStokKodu.Text + " - " + TxtStokAdi.Text;
		}

		private void barButYazdir2_ItemClick(object sender, ItemClickEventArgs e)
		{
			short.TryParse(txtEtiketAdet.EditValue.ToString(), out _etiketSayisi);
			if (_etiketSayisi > 100)
			{
				MessageBox.Show("Tek seferde en fazla 100 adet etiket yazdırabilirsiniz!", "Bilgi",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			string stokKodu = gridView1.GetFocusedRowCellDisplayText("STKODU");
			var sKart = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;

			if (sKart != null)
			{
				repBarkodEtiket rEtiket = new repBarkodEtiket();
				rEtiket.lblStokAdi.Text = "";
				rEtiket.xrBarcode.Text = sKart.STEKOD;

				rEtiket.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
				rEtiket.Print();
			}
		}

		private void barButExcel_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.RowCount == 0) return;
			string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + LkEdMalzTuru.Text +
							  "_" + DateTime.Now.ToString("dd.MM.yy_HH - mm - ss") + ".xlsx";
			gridView1.ExportToXlsx(filePath);
			Process.Start(filePath);
		}

		private void btnStandartOps_Click(object sender, EventArgs e)
		{
			STKART sKart = sTKARTBindingSource.Current as STKART;
			string stokKodu = sKart.STKODU;
			string stokAdi = sKart.STKNAM;

			if (stokKodu != "")
			{
				var record = opsiyonList.FirstOrDefault(o => o.ContainsKey(0));

				FrmUrunOpsiyon frmUrunOpsiyon = new FrmUrunOpsiyon();
				frmUrunOpsiyon.global = global;
				frmUrunOpsiyon.standartOpsiyon = true;
				frmUrunOpsiyon.lblStokKodu.Text = stokKodu;
				frmUrunOpsiyon.lblStokAdi.Text = stokAdi;
				if (record != null) frmUrunOpsiyon.opsiyonList = record[0];

				frmUrunOpsiyon.ShowDialog();

				if (frmUrunOpsiyon.opsiyonDict.Count > 0)
				{
					if (record != null) opsiyonList.Remove(record);
					opsiyonList.Add(frmUrunOpsiyon.opsiyonDict);
				}
			}
		}

		private void barButYazdirEn_ItemClick(object sender, ItemClickEventArgs e)
		{
			short.TryParse(txtEtiketAdet.EditValue.ToString(), out _etiketSayisi);
			if (_etiketSayisi > 100)
			{
				MessageBox.Show("Tek seferde en fazla 100 adet etiket yazdırabilirsiniz!", "Bilgi",
					MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			string stokKodu = gridView1.GetFocusedRowCellDisplayText("STKODU");
			string stokAdi = gridView1.GetFocusedRowCellDisplayText("STKNAM");

			STNAME stname = _stnameService.Cch_GetByStokKoduLangkd_NLog(global, stokKodu, "EN", false)
				.Nesne;

			if (stname == null)
			{
				MessageBox.Show(stokAdi + " için İngilizce stok adı tanımlanmamış", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			stokAdi = stname.STKNAM;

			if (Param.ADAPTATION == Adaptation.Aracikan)
			{
				string etiketPath = AppDomain.CurrentDomain.BaseDirectory + "\\100x40.repx";

				var rEtiket = XtraReport.FromFile(etiketPath) as repBarkodEtiket;
				rEtiket.lblStokAdi.Text = stokAdi;
				rEtiket.xrBarcode.Text = stokKodu;

				rEtiket.PrintingSystem.StartPrint += new PrintDocumentEventHandler(PrintingSystem_StartPrint);
				rEtiket.Print();
			}
		}

		private void LkEdMalGrubu_MouseClick(object sender, MouseEventArgs e)
		{
			GridLookUpEdit lked = sender as GridLookUpEdit;

			if (e.Button == MouseButtons.Right)
			{
				STKART sKart = sTKARTBindingSource.Current as STKART;

				lked.EditValue = null;
				if (lked.Name == "LkEdMalGrubu") sKart.MALGKD = null;
				else if (lked.Name == "LkEdAltGrup") sKart.STALKD = null;
			}
		}

		protected override void barOrtamEk_ItemClick(object sender, ItemClickEventArgs e)
		{

			var _accessName = xtraTabControl2.SelectedTabPage.AccessibleName;
			if (_accessName == "STBDRN")
			{
				if (gridViewRenk.GetFocusedRowCellValue("Id") == null)
				{
					MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				int id = Convert.ToInt32(gridViewRenk.GetFocusedRowCellValue("Id"));
				FrmFileManager form = new FrmFileManager(global, _accessName, id);
				form.ShowDialog();
			}
			else
			{
				if (gridView1.GetFocusedRowCellValue("Id") == null)
				{
					MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					return;
				}

				int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
				FrmFileManager form = new FrmFileManager(global, "STKART", id);
				form.ShowDialog();
			}

		}

		protected override void barButOrnekDosya_ItemClick(object sender, ItemClickEventArgs e)
		{
			STKART _stkart = new STKART();
			GridHelper.ExcelTemplateforEntity(_stkart, "STKART");
			STDEPO _STDEPO = new STDEPO();
			GridHelper.ExcelTemplateforEntity(_STDEPO, "STDEPO");
			STMHSB _STMHSB = new STMHSB();
			GridHelper.ExcelTemplateforEntity(_STMHSB, "STMHSB");
			STSALE _STSALE = new STSALE();
			GridHelper.ExcelTemplateforEntity(_STSALE, "STSALE");
			STOLCU _STOLCU = new STOLCU();
			GridHelper.ExcelTemplateforEntity(_STOLCU, "STOLCU");
			STNAME _STNAME = new STNAME();
			GridHelper.ExcelTemplateforEntity(_STNAME, "STNAME");
			STKMIZ _STKMIZ = new STKMIZ();
			GridHelper.ExcelTemplateforEntity(_STKMIZ, "STKMIZ");
			STURYR _STURYR = new STURYR();
			GridHelper.ExcelTemplateforEntity(_STURYR, "STURYR");
			STDPYN _STDPYN = new STDPYN();
			GridHelper.ExcelTemplateforEntity(_STDPYN, "STDPYN");
			//UrunOpsiyonModel _UrunOpsiyonModel = new UrunOpsiyonModel();
			//GridHelper.ExcelTemplateforEntity(_UrunOpsiyonModel, "UrunOpsiyonModel");
			STBDRN _STBDRN = new STBDRN();
			GridHelper.ExcelTemplateforEntity(_STBDRN, "STBDRN");

		}
		protected override void barButExcelAktar_ItemClick(object sender, ItemClickEventArgs e)
		{
			List<STKART> STKARTs = GridHelper.LoadExcelToListEntity<STKART>();
			List<STDEPO> STDEPOs = GridHelper.LoadExcelToListEntity<STDEPO>();
			//List<STMHSB> STMHSBs = GridHelper.LoadExcelToListEntity<STMHSB>();
			//List<STSALE> STSALEs = GridHelper.LoadExcelToListEntity<STSALE>();
			//List<STOLCU> STOLCUs = GridHelper.LoadExcelToListEntity<STOLCU>();
			//List<STNAME> STNAMEs = GridHelper.LoadExcelToListEntity<STNAME>();
			//List<STKMIZ> STKMIZs = GridHelper.LoadExcelToListEntity<STKMIZ>();
			//List<STURYR> STURYRs = GridHelper.LoadExcelToListEntity<STURYR>();
			//List<STDPYN> STDPYNs = GridHelper.LoadExcelToListEntity<STDPYN>();
			List<STBDRN> STBDRNs = GridHelper.LoadExcelToListEntity<STBDRN>();
			foreach (var _stokkartim in STKARTs)
			{
				var ListDepo = STDEPOs.Where(x => x.STKODU == _stokkartim.STKODU).ToList();
				foreach (var item in ListDepo)
				{
					item.STKODU = null;
				}
				var ListRenk = STBDRNs.Where(x => x.STKODU == _stokkartim.STKODU).ToList();
				foreach (var item in ListRenk)
				{
					item.STKODU = null;
				}
				_stokkartim.STKODU = null;
				List<STMHSB> _STMHSB1 = new List<STMHSB>();
				List<STSALE> _STSALE1 = new List<STSALE>();
				List<STOLCU> _STOLCU1 = new List<STOLCU>();
				List<STNAME> _STNAME1 = new List<STNAME>();
				List<STKMIZ> _STKMIZ1 = new List<STKMIZ>();
				List<STURYR> _STURYR1 = new List<STURYR>();
				List<STDPYN> _STDPYN1 = new List<STDPYN>();
				//List<STBDRN> _STBDRN1 = new List<STBDRN>();
				Excelden_Stok_Kaydet(_stokkartim, ListDepo, _STMHSB1, _STSALE1, _STOLCU1, _STNAME1, _STKMIZ1, _STURYR1, _STDPYN1, ListRenk, ExcelfocusedRowHandler);
			}


			//Excelden_Stok_Kaydet
		}

		private void btnRaporDizayn_Click(object sender, EventArgs e)
		{
			CreateOpenTemplate();
		}

		private void CreateOpenTemplate(string filePath = "")
		{
			if (TxtStokKartId.Text == "") return;

			repSatisTeklifEndUser rep = new repSatisTeklifEndUser();

			if (filePath == "")
			{
				rep = new repSatisTeklifEndUser();
				rep.DisplayName = "Yeni Şablon";
				rep.Tag = ".";
			}
			else
			{
				rep.LoadLayoutFromXml(filePath);
			}

			ReportDesignTool designTool = new ReportDesignTool(rep);

			XRDesignMdiController mdiController = designTool.DesignRibbonForm.DesignMdiController;
			mdiController.AddCommandHandler(new DesignerCommandHandler(mdiController,
				sTKARTBindingSource.Current as STKART, saveFolder, GetTempDesignFileNames));
			mdiController.SetCommandVisibility(ReportCommand.SaveAll, CommandVisibility.None);
			mdiController.SetCommandVisibility(ReportCommand.SaveFileAs, CommandVisibility.None);
			designTool.ShowRibbonDesigner(UserLookAndFeel.Default);
		}

		private void gridSablonTasarim_MouseDoubleClick(object sender, MouseEventArgs e)
		{
			Point point = gridSablonTasarim.PointToClient(MousePosition);

			GridHitInfo info = grdVwSablonTasarim.CalcHitInfo(point);
			if (info.InRow || info.InRowCell)
			{
				if (info.RowHandle < 0) return;
				if (info.Column.FieldName == "Dosya")
				{

				}
			}
		}

		private RepositoryItemGridLookUpEdit CreateRepositoryItem(List<TipHareketListModel> dataSource)
		{
			RepositoryItemGridLookUpEdit repItem = new RepositoryItemGridLookUpEdit();

			repItem.AutoHeight = false;
			repItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
			{
				new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
			});
			repItem.DisplayMember = "TANIMI";
			repItem.NullText = "";
			repItem.PopupView = this.repositoryItemGridLookUpEdit25View;
			repItem.ValueMember = "HARKOD";
			repItem.DataSource = dataSource;

			return repItem;
		}

		public string ReadAttributeFromXml(MemoryStream xmlStream, string attribute)
		{
			string value = "";

			xmlStream.Seek(0, SeekOrigin.Begin);
			XmlDocument doc = new XmlDocument();
			doc.Load(xmlStream);

			var attributes = doc.ChildNodes[1].Attributes;
			if (attributes != null) value = attributes[attribute].InnerText;

			return value;
		}

		public void GetTempDesignFileNames()
		{
			gridSablonTasarim.DataSource = null;

			if (!Directory.Exists(saveFolder)) return;

			List<string> files = Directory.GetFiles(saveFolder).ToList();

			if (files.Count > 0)
			{
				gridSablonTasarim.DataSource = null;

				DataTable table = new DataTable();
				table.Columns.Add("DosyaYolu", typeof(string));
				table.Columns.Add("Dosya", typeof(string));
				table.Columns.Add("Sablon", typeof(string));
				table.Columns.Add("Sayfa", typeof(int));

				try
				{
					foreach (string file in files)
					{
						string fileName = Path.GetFileName(file);
						string sablon = "";
						int sayfaNo = 0;

						MemoryStream stream = new MemoryStream();
						using (FileStream fs = File.OpenRead(file))
						{
							fs.CopyTo(stream);
						}

						string attrValue = ReadAttributeFromXml(stream, "Tag");
						if (attrValue.Length > 1)
						{
							string[] vals = attrValue.Split(';');
							sablon = vals[0];
							sayfaNo = Convert.ToInt32(vals[1]);
						}

						table.Rows.Add(file, fileName, sablon, sayfaNo);
					}

					gridSablonTasarim.DataSource = table;
					grdVwSablonTasarim.BestFitColumns();
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
		}

		public string EditXml(string filePath, string attribute, string value)
		{
			string result;

			try
			{
				XmlDocument doc = new XmlDocument();
				doc.Load(filePath);

				var attributes = doc.ChildNodes[1].Attributes;
				if (attributes != null) attributes[attribute].InnerText = value;

				doc.Save(filePath);
				result = "";
			}
			catch (Exception e)
			{
				Console.WriteLine(e);
				result = e.ToString();
			}

			return result;
		}

		private void repDuzenleButton_ButtonClick(object sender,
			DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			string filePath = grdVwSablonTasarim.GetFocusedRowCellDisplayText("DosyaYolu");
			CreateOpenTemplate(filePath);
		}

		private void repSilButton_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			DialogResult Secim;
			Secim = MessageBox.Show("Şablonu silmek istediğinizden emin misiniz ?", "Silme İşlemi",
				MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Secim == DialogResult.Yes)
			{
				string filePath = grdVwSablonTasarim.GetFocusedRowCellDisplayText("DosyaYolu");
				File.Delete(filePath);
				GetTempDesignFileNames();
			}
		}

		private void grdVwSablonTasarim_CellValueChanged(object sender,
			DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			string filePath = grdVwSablonTasarim.GetFocusedRowCellDisplayText("DosyaYolu");
			string sablon = "";
			int sayfa = 0;
			string val;

			if (e.Column.FieldName == "Sablon")
			{
				sablon = e.Value.ToString();
				int.TryParse(grdVwSablonTasarim.GetFocusedRowCellDisplayText("Sayfa"), out sayfa);
			}
			else if (e.Column.FieldName == "Sayfa")
			{
				int.TryParse(e.Value.ToString(), out sayfa);
				sablon = grdVwSablonTasarim.GetFocusedRowCellDisplayText("Sablon");
			}

			val = sablon + ";" + sayfa.ToString();

			EditXml(filePath, "Tag", val);
		}

		private void gridView1_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e)
		{
			if (e.RowHandle > -1 && e.Column.FieldName == "STALKD")
			{
				string tipHarkod = gridView1.GetRowCellValue(e.RowHandle, "STANKD").ToString();
				if (repositoryList.ContainsKey(tipHarkod)) e.RepositoryItem = repositoryList[tipHarkod];
			}
		}

		private void CreatePaket(bool createUrunAgaci = true, int mevcutPaketSayisi = 0)
		{
			_action = "insert";

			int paketSayisi = 0;
			int.TryParse(txtEtiketAdet.EditValue.ToString(), out paketSayisi);

			if ((paketSayisi + mevcutPaketSayisi) > 15)
			{
				MessageBox.Show("En fazla 15 paket oluşturabilirsiniz!", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			if (paketSayisi < 1)
			{
				MessageBox.Show("Geçersiz paket sayısı!", "Hata", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			DialogResult Secim;
			Secim = MessageBox.Show("Toplam " + paketSayisi.ToString() + " adet paket oluşturulacak. Emin misiniz?",
				"Stok Oluşturma", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Secim != DialogResult.Yes) return;

			STKART sKart = sTKARTBindingSource.Current as STKART;
			List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(sKart.STKODU, global, false).Items
				.OrderBy(s => s.Id).ToList();
			STNAME sName = _stnameService.Cch_GetByStokKoduLangkd_NLog(global, sKart.STKODU, "EN").Nesne;
			string numara = "";

			using (TransactionScope ts = new TransactionScope())
			{
				try
				{
					List<string> paketKoduList = new List<string>();

					for (int i = 0; i < paketSayisi; i++)
					{
						focusedRowHandler.Clear();

						string paketNo = (i + 1 + mevcutPaketSayisi).ToString("D2");
						string paketKodu = sKart.STKODU + "." + paketNo;
						paketKoduList.Add(paketKodu);

						STOLCU stolcu = olcuList[0].ShallowCopy();
						stolcu.STKODU = paketKodu;
						stolcu.Id = 0;

						STNAME stname = sName.ShallowCopy();
						stname.STKODU = paketKodu;
						stname.STKNAM = stname.STKNAM + " " + (i + 1 + mevcutPaketSayisi).ToString() + ". PACKAGE";
						stname.Id = 0;

						sTMHSBBindingSource.DataSource = new STMHSB();
						sTMHSBBindingSource.RemoveCurrent();
						sTSALEBindingSource.DataSource = new STSALE();
						sTSALEBindingSource.RemoveCurrent();
						sTURYRBindingSource.DataSource = new STURYR();
						sTURYRBindingSource.RemoveCurrent();
						sTDPYNBindingSource.DataSource = new STDPYN();
						sTDPYNBindingSource.RemoveCurrent();
						sTOLCUBindingSource.DataSource = stolcu;
						sTNAMEBindingSource.DataSource = stname;
						sTDEPOBindingSource.DataSource = new STDEPO()
						{
							SIRKID = 1,
							ACTIVE = true,
							STKODU = paketKodu,
							URYRKD = "1000",
							DPKODU = "001",
							ENBLKJ = false,
							USESTK = 0,
							BLKSTK = 0,
							MIPGOS = false,
							TEDKOD = "001",
							ULKEKD = "TR",
							KYNKKD = "3"
						};
						sTKMIZBindingSource.DataSource = new STKMIZ()
						{
							SIRKID = 1,
							ACTIVE = true,
							MALIYL = DateTime.Today.Year,
							MALIAY = DateTime.Today.Month,
							KAYORT = 0,
							STNFIY = 0,
							DGMKTR = 0,
							DGSTDG = 0,
							KYNKKD = "3"
						};

						var model = new GenelStokKartModel();

						STKART paketStokKart = sKart.ShallowCopy();
						paketStokKart.STKODU = paketKodu;
						paketStokKart.STKNAM = sKart.STKNAM + " " + (i + 1 + mevcutPaketSayisi).ToString() + ". PAKET";
						paketStokKart.STMLTR = "002";

						model.Stkart = paketStokKart;

						var stDepoBindingList = sTDEPOBindingSource.List;
						model.Stdepos = new List<STDEPO>();
						foreach (var bind in stDepoBindingList) model.Stdepos.Add((STDEPO)bind);

						var stMhsbBindingList = sTMHSBBindingSource.List;
						model.Stmhsbs = new List<STMHSB>();
						foreach (var bind in stMhsbBindingList) model.Stmhsbs.Add((STMHSB)bind);

						var stSaleBindingList = sTSALEBindingSource.List;
						model.Stsales = new List<STSALE>();
						foreach (var bind in stSaleBindingList) model.Stsales.Add((STSALE)bind);

						var stOlcuBindingList = sTOLCUBindingSource.List;
						model.Stolcus = new List<STOLCU>();
						foreach (var bind in stOlcuBindingList) model.Stolcus.Add((STOLCU)bind);

						var stNameBindingList = sTNAMEBindingSource.List;
						model.Stnames = new List<STNAME>();
						foreach (var bind in stNameBindingList) model.Stnames.Add((STNAME)bind);

						model.Stkmiz = (STKMIZ)sTKMIZBindingSource.Current;
						if (model.Stkmiz == null) model.Stkmiz = new STKMIZ();

						var stUryrBindingList = sTURYRBindingSource.List;
						model.Sturyrs = new List<STURYR>();
						foreach (var bind in stUryrBindingList) model.Sturyrs.Add((STURYR)bind);

						var stDpynBindingList = sTDPYNBindingSource.List;
						model.Stdpyns = new List<STDPYN>();
						foreach (var bind in stDpynBindingList) model.Stdpyns.Add((STDPYN)bind);


						var response = _stokService.Ncch_StokKartKaydet_Log(global, model, focusedRowHandler, _action);
						if (response.Status != ResponseStatusEnum.OK)
						{
							gridView1.RefreshData();
							_action = "";
							throw new Exception(response.Message);
						}
					}

					if (createUrunAgaci)
					{
						// Ürün Ağacı
						var evrakmodel = new EvrakNoUretParamModel();
						evrakmodel.TabloAdi = "URAGAC";
						evrakmodel.TeknikAd = "URAKOD";
						evrakmodel.IslemTur = 0;
						var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

						if (evrakResponse.Status != ResponseStatusEnum.OK)
						{
							throw new Exception(evrakResponse.Message);
						}

						numara = evrakResponse.Nesne;

						UASTBG uastbg = new UASTBG()
						{
							STKODU = sKart.STKODU,
							URYRKD = "1000",
							KLNKOD = "1",
							URAKOD = numara,
							ALTERN = 1,
							GNREZV = "00001",
							ACTIVE = true,
						};

						_uastbgService.Ncch_Add_NLog(uastbg, global);

						for (int i = 0; i < paketKoduList.Count; i++)
						{
							URAGAC urAgac = new URAGAC()
							{
								STKODU = paketKoduList[i],
								CHILDD = i,
								PARENT = i,
								GNREZV = "00001",
								SEVIYE = 0,
								URAKOD = numara,
								SLINDI = false,
								URYRKD = "1000",
								URKLTP = "L",
								//SIRALM = rowView["Siralama"].ToString() == "" ? null : rowView["Siralama"].ToString(),
								GNMKTR = 1,
								OLCUKD = "ADT",
								SBTMIK = 0,
								STKKLM = true,
								MTNKLM = false,
								FTNKLM = false,
								STMLTR = "002",
								AURKOD = numara,
								ACTIVE = true
							};

							_uragacService.Ncch_Add_NLog(urAgac, global);
						}
					}

					ts.Complete();
				}
				catch (Exception exception)
				{
					gridView1.RefreshData();
					_action = "";
					MessageBox.Show("Kayıt Yapılamadı " + exception.GetBaseException().Message);
				}
				finally
				{
					ts.Dispose();
				}


				gridView1.RefreshData();
				_action = "";
				MessageBox.Show("Paket kodları oluşturuldu!", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}
		}

		private void barButPaketKodu_ItemClick(object sender, ItemClickEventArgs e)
		{
			CreatePaket();
		}

		private void barButModulPaketEkle_ItemClick(object sender, ItemClickEventArgs e)
		{
			STKART sKart = sTKARTBindingSource.Current as STKART;
			if (sKart == null) return;

			List<STKART> stokList = _stokKartService.Ncch_GetListByStKodLike_NLog(sKart.STKODU, "002", global, false).Items;
			CreatePaket(false, stokList.Count);
		}

		public class DesignerCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
		{
			XRDesignMdiController mdiController;
			STKART stkart;
			string saveFolder;
			private Action callbackAction;

			public DesignerCommandHandler(XRDesignMdiController mdiController, STKART stkart, string saveFolder,
				Action callBackAction)
			{
				this.mdiController = mdiController;
				this.stkart = stkart;
				this.saveFolder = saveFolder;
				this.callbackAction = callBackAction;
			}

			public void HandleCommand(ReportCommand command, object[] args)
			{
				if (command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs ||
					command == ReportCommand.SaveAll)
				{
					Directory.CreateDirectory(saveFolder);

					SaveFileDialog saveFileDialog1 = new SaveFileDialog();
					saveFileDialog1.InitialDirectory = saveFolder;
					saveFileDialog1.Title = "Şablonu Kaydet";
					saveFileDialog1.CheckFileExists = false;
					saveFileDialog1.CheckPathExists = false;
					saveFileDialog1.DefaultExt = "xml";
					saveFileDialog1.Filter = "Şablon Dosyası (*.xml)|*.xml";
					saveFileDialog1.FilterIndex = 1;
					saveFileDialog1.RestoreDirectory = true;
					if (saveFileDialog1.ShowDialog() == DialogResult.OK)
					{
						string fileNameOnly = Path.GetFileName(saveFileDialog1.FileName);
						EditXml("DisplayName", fileNameOnly, saveFileDialog1.FileName);
						mdiController.ActiveDesignPanel.Report.DisplayName = fileNameOnly;
						mdiController.ActiveDesignPanel.ReportState = ReportState.Saved;

						callbackAction.Invoke();
					}
				}
				else if (command == ReportCommand.OpenFile)
				{
					Directory.CreateDirectory(saveFolder);

					OpenFileDialog openFileDialog = new OpenFileDialog();
					openFileDialog.InitialDirectory = saveFolder;
					openFileDialog.Title = "Şablon Dosyası Aç";
					openFileDialog.DefaultExt = "xml";
					openFileDialog.Filter = "Şablon Dosyası (*.xml)|*.xml";
					openFileDialog.FilterIndex = 1;
					openFileDialog.RestoreDirectory = true;
					if (openFileDialog.ShowDialog() == DialogResult.OK)
					{
						if (mdiController.ActiveDesignPanel != null)
						{
							MemoryStream stream = new MemoryStream();
							using (FileStream fs = File.OpenRead(openFileDialog.FileName))
							{
								fs.CopyTo(stream);
							}

							EditXml("DisplayName", openFileDialog.SafeFileName, openFileDialog.FileName, stream);
							mdiController.ActiveDesignPanel.OpenReport(openFileDialog.FileName);
							mdiController.ActiveDesignPanel.Report.DisplayName = openFileDialog.SafeFileName;
						}
					}
				}
			}

			public void EditXml(string attribute, string value, string filePath, MemoryStream stream = null)
			{
				if (stream == null)
				{
					stream = new MemoryStream();
					stream.Seek(0, SeekOrigin.Begin);
					mdiController.ActiveDesignPanel.Report.SaveLayoutToXml(stream);
				}

				stream.Seek(0, SeekOrigin.Begin);

				XmlDocument doc = new XmlDocument();
				doc.Load(stream);

				var attributes = doc.ChildNodes[1].Attributes;
				if (attributes != null) attributes[attribute].InnerText = value;

				stream = new MemoryStream();
				stream.Seek(0, SeekOrigin.Begin);
				doc.Save(stream);
				stream.Seek(0, SeekOrigin.Begin);

				using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
				{
					stream.WriteTo(file);
				}
			}

			public bool CanHandleCommand(ReportCommand command,
				ref bool useNextHandler)
			{
				useNextHandler = !(command == ReportCommand.SaveFile ||
								   command == ReportCommand.OpenFile);
				return !useNextHandler;
			}

		}

		private void barButMalzemeIhtiyac_ItemClick(object sender, ItemClickEventArgs e)
		{
			STKART stkart = sTKARTBindingSource.Current as STKART;
			List<StkartMiktar> stkartList = new List<StkartMiktar> { new StkartMiktar { stkart = stkart } };

			FrmMalzemeIhtiyac frmMalzemeIhtiyac = new FrmMalzemeIhtiyac(stkartList, global);
			frmMalzemeIhtiyac.Show();
		}

		private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
		{
			SetRepositoryLookups();
		}

		private void gridView1_FocusedColumnChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedColumnChangedEventArgs e)
		{
			if (gridView1.OptionsBehavior.Editable)
			{
				gridView1.Columns["STEKOD"].OptionsColumn.AllowEdit = false;
				gridView1.Columns["STEKOD"].OptionsColumn.ReadOnly = true;
			}
		}

		private void barButTeknikResim_ItemClick(object sender, ItemClickEventArgs e)
		{
			STKART sKart = sTKARTBindingSource.Current as STKART;
			if (sKart == null) return;

			List<UrunAgaciUst> uaUstList = new List<UrunAgaciUst>();
			GetUrunAgaciUpperLevels(sKart.STKODU, uaUstList);
			if (uaUstList.Count == 0) return;
			string masterStokKodu = uaUstList.Last().USKODU;

			string teknikFolder = AppDomain.CurrentDomain.BaseDirectory + $@"\servis\teknik\{masterStokKodu}\{sKart.STKODU}\";
			if (Directory.Exists(teknikFolder)) Process.Start(teknikFolder);
		}

		private void GetUrunAgaciUpperLevels(string stokKodu, List<UrunAgaciUst> uaUstList)
		{
			try
			{
				List<UrunAgaciUst> list = _uragacService.Ncch_GetUrunAgaciUst_NLog(global, stokKodu).Items;
				if (list != null && list.Count > 0)
				{
					uaUstList.AddRange(list);
					GetUrunAgaciUpperLevels(list[0].USKODU, uaUstList);
				}
			}
			catch (Exception)
			{
			}
		}

		private void gridViewRenk_ValidateRow(object sender, DevExpress.XtraGrid.Views.Base.ValidateRowEventArgs e)
		{
			var stbdrnlist = ((List<STBDRN>)sTBDRNBindingSource1.DataSource).Select(s => s.ShallowCopy()).ToList();
			var erow = (STBDRN)e.Row;
			stbdrnlist.RemoveAt(e.RowHandle);
			var varmi = stbdrnlist.Where(x => x.URYRKD == erow.URYRKD && x.RENKKD == erow.RENKKD && x.BEDNKD == erow.BEDNKD && x.DROPKD == erow.DROPKD);
			if (varmi.ToList().Count > 0)
			{
				e.Valid = false;
				e.ErrorText = "Aynı kayıttan birden fazla ekleyemezsiniz!";
			}

		}
		private void Excelden_Stok_Kaydet(STKART _STKART, List<STDEPO> _STDEPO, List<STMHSB> _STMHSB, List<STSALE> _STSALE,
			List<STOLCU> _STOLCU, List<STNAME> _STNAME, List<STKMIZ> _STKMIZ, List<STURYR> _STURYR, List<STDPYN> _STDPYN, List<STBDRN> _STBDRN,
			List<Grid> _ExcelfocusedRowHandler)
		{
			_action = "insert";
			var ayni = 0;
			var response = new StandardResponse();
			var model = new GenelStokKartModel();

			_stokKart = _STKART;
			var tur = _stmaltService.Cch_GetByMalTur_NLog(_stokKart.STMLTR, global, false).Nesne;
			var evrakmodel = new EvrakNoUretParamModel();
			evrakmodel.TabloAdi = "STKART";
			evrakmodel.TeknikAd = "STKODU";
			evrakmodel.IslemTur = tur.Id;
			var _gnevrk = _gnevrkService.Ncch_GetEvrak_NLog(global, evrakmodel, 0);
			if (_gnevrk.Status == ResponseStatusEnum.OK)
			{
				var _response = _stokService.Ncch_StokKodOlustur_NLog(global, tur, _stokKart, "D" + _gnevrk.Nesne.KARSAY, true);
				if (_response.Status == ResponseStatusEnum.OK)
				{
					_stokKart.STKODU = _response.Nesne;

				}
			}

			model.Stkart = _stokKart;

			//////// STDEPO /////////////////////
			var stDepoBindingList = _STDEPO.ToList();
			model.Stdepos = new List<STDEPO>();
			foreach (var bind in stDepoBindingList)
			{
				model.Stdepos.Add((STDEPO)bind);
			}

			//////// STMHSB /////////////////////
			var stMhsbBindingList = _STMHSB.ToList();
			model.Stmhsbs = new List<STMHSB>();

			foreach (var bind in stMhsbBindingList)
			{
				model.Stmhsbs.Add((STMHSB)bind);
			}

			//////// STSALE /////////////////////
			var stSaleBindingList = _STSALE.ToList();
			model.Stsales = new List<STSALE>();

			foreach (var bind in stSaleBindingList)
			{
				model.Stsales.Add((STSALE)bind);
			}

			//////// STOLCU /////////////////////
			var stOlcuBindingList = _STOLCU.ToList();
			model.Stolcus = new List<STOLCU>();
			foreach (var bind in stOlcuBindingList)
			{
				model.Stolcus.Add((STOLCU)bind);
			}

			//////// STNAME /////////////////////
			var stNameBindingList = _STNAME.ToList();
			STNAME _stname = new STNAME();
			model.Stnames = new List<STNAME>();

			if (stNameBindingList.Count == 0)
			{
				if (TxtStokAdiIng.Text != "")
				{
					_stname.SIRKID = (int)global.SirketId;
					_stname.STKODU = model.Stkart.STKODU;
					_stname.STKNAM = TxtStokAdiIng.Text;
					_stname.LANGKD = "EN";
					_stname.ACTIVE = true;

					_stname.SLINDI = false;
					_stname.EKKULL = global.UserKod;
					_stname.ETARIH = DateTime.Now;
					_stname.KYNKKD = global.KaynakKod;
					model.Stnames.Add(_stname);
				}


			}


			foreach (STNAME bind in stNameBindingList)
			{
				if (bind.LANGKD == "EN")
				{
					bind.STKNAM = TxtStokAdiIng.Text;
				}
				model.Stnames.Add(bind);

			}

			//////// STKMIZ /////////////////////
			var StkmizBindingList = _STKMIZ.ToList();
			model.Stkmiz = new STKMIZ();

			//////// STURYR /////////////////////
			var stUryrBindingList = _STURYR.ToList();
			model.Sturyrs = new List<STURYR>();

			foreach (var bind in stUryrBindingList)
			{
				model.Sturyrs.Add((STURYR)bind);
			}

			//////// STDPYN /////////////////////
			var stDpynBindingList = _STDPYN.ToList();
			model.Stdpyns = new List<STDPYN>();

			foreach (var bind in stDpynBindingList)
			{
				model.Stdpyns.Add((STDPYN)bind);
			}

			//////// Ürün Opsiyon /////////////////////
			model.UrunOpsiyons = new List<UrunOpsiyonModel>();
			foreach (var opsiyon in opsiyonList)
			{
				foreach (KeyValuePair<int, List<UrunOpsiyonModel>> urOp in opsiyon)
				{
					model.UrunOpsiyons.AddRange(urOp.Value);
				}
			}

			//////// STBDRN/////////////////////
			var stBdrnBindingList = _STBDRN.ToList();
			model.Stbdrns = new List<STBDRN>();
			foreach (var bind in stBdrnBindingList)
			{
				model.Stbdrns.Add((STBDRN)bind);
			}

			//model.Stkart.SADEGK = LkEdSaDegerAnahtari.EditValue.ToString();

			response = _stokService.Ncch_StokKartKaydet_Log(global, model, _ExcelfocusedRowHandler, _action);
			//var response = _stokService.Ncch_StokKartKaydet_Log(global, model, focusedRowHandler);
			if (response.Status != ResponseStatusEnum.OK)
			{
				MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return;
			}

			//Directory.CreateDirectory(imageFolder);
			//var imageName = TxtStokKodu.Text + ".jpg";
			//File.Delete(imageFolder + imageName);
			//if (PicStokResim.Image != null)
			//{
			//    PicStokResim.Image.Save(imageFolder + imageName, ImageFormat.Jpeg);
			//}

			//opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

			//var sistemDilTanim = _stnameService.Cch_GetListByStokKoduLangkd_NLog(global, _stokKart.STKODU, false).Nesne;
			//if (sistemDilTanim == null)
			//{
			//    sistemDilTanim = new STNAME()
			//    {
			//        SIRKID = global.SirketId.Value,
			//        STKODU = _stokKart.STKODU,
			//        STKNAM = _stokKart.STKNAM,
			//        LANGKD = global.DilKod,
			//        ACTIVE = true,
			//        SLINDI = false,
			//        EKKULL = global.UserKod,
			//        ETARIH = DateTime.Now,
			//        KYNKKD = global.KaynakKod
			//    };
			//    _stnameService.Ncch_Add_NLog(sistemDilTanim, global);
			//}
			//else
			//{
			//    sistemDilTanim.STKNAM = _stokKart.STKNAM;
			//    sistemDilTanim.DEKULL = global.UserKod;
			//    sistemDilTanim.DTARIH = DateTime.Now;
			//    sistemDilTanim.KYNKKD = global.KaynakKod;
			//    sistemDilTanim.SLINDI = false;
			//    _stnameService.Ncch_Update_Log(sistemDilTanim, sistemDilTanim, global);
			//}

			gridView1.RefreshData();
			//_action = "";
			//var stkodu = model.Stkart.STKODU;
			//gridView1.FocusedRowHandle = gridView1.LocateByValue("STKODU", stkodu);

			//xtraTabControl1.SelectedTabPage = xtraTabPage1;
			//if (yetkiModel == null)
			//    yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
			//FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
		}

		private void repButSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
		{
			DialogResult res = MessageBox.Show("Emin misiniz?", "Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (res == DialogResult.Yes)
			{
				string stkodu = gridView1.GetFocusedRowCellValue("STKODU").ToString();

				var result = _stcrkdService.Ncch_HardDelete_Log(stkodu, global);

				MessageBox.Show(result, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
	}
}