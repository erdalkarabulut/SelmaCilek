using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models;
using Bps.BpsBase.Entities.Models.CR.Listed;
using Bps.Core.Response;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraReports.UI;
using Outlook = Microsoft.Office.Interop.Outlook;
using System.Data;
using System.Globalization;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.UA;
using Bps.Core.GlobalStaticsVariables;
using BPS.Windows.Forms.SP;
using DevExpress.Utils.Extensions;


namespace BPS.Windows.Forms
{
	public partial class FrmSiparis : BPS.Windows.Base.FrmChildBase
	{
		public string blgNo;
		public int fisTipi;

		private ISpfbasService _sinifService;
		private IGnkxmlService _sinifyerlesimService;
		public SPFTIP _spftip;
		private GNKXML _sinifyerlesim;

		private ProjeMenuListed yetkiModel;
		private IList<SPFBAS> list;
		private string _action;
		private bool formLoaded = false;
		private bool loadingGrid = false;
		private bool _mailSent = false;
		private List<GNYETB> ortamModel;

		private readonly IGnyetkService _gnyetkService;
		private readonly IGnthrkService _gnthrkService;
		private readonly ISpftipService _spftipService;
		private readonly ICrcariService _crcariService;
		private readonly ICradrsService _cradrsService;
		private readonly IGndptnService _gndptnService;
		private readonly IStkfytService _stkfytService;
		private readonly IStkfiyService _stkfiyService;
		private readonly IStkartService _stkartService;
		private readonly IStolcuService _stolcuService;
		private readonly ISpfharService _spfharService;
		private readonly ISpuropService _spuropService;
		private readonly ISturopService _sturopService;
		private readonly IGnoptpService _gnoptpService;
		private readonly IGnophrService _gnophrService;
		private readonly ICrytklService _crytklService;
		private readonly IDovkurService _dovkurService;
		private readonly IGnkullService _gnkullService;
		private readonly IStdepoService _stdepoService;
		private readonly ISthrktService _sthrktService;
		private readonly ISpodtbService _spodtbService;
		private readonly ISpkoslService _spkoslService;
		private readonly IStnameService _stnameService;
		private readonly IGnlkhrService _gnlkhrService;
		private readonly IUragacService _uragacService;
		private readonly ISirketService _sirketService;
		private readonly ISpfbasDal _spfbasDal;
		private readonly IXXService _xxService;
		private readonly IGnorhrService _gnorhrService;
		private readonly IStbdrnService _stbdrnService;
		private readonly IStcrkdService _stcrkdService;
		private readonly IGnyetbService _gnyetbService;
		private IShopifyService _shopifyService;

		private List<Grid> focusedRowHandler = new List<Grid>();
		public List<CRCARI> CariKarts = new List<CRCARI>();
		private int _satirNo = 0;
		private Image imgRequired;
		private List<Dictionary<int, List<UrunOpsiyonModel>>> opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();
		private List<DOVKUR> dovkurList = new List<DOVKUR>();
		private List<UrunAgaciModulPaket> uaModulPaketList = new List<UrunAgaciModulPaket>();

		public FrmSiparis(ISpfbasService sinifService, IGnthrkService gnthrkService,
			ISpftipService spftipService, ICrcariService crcariService, ICradrsService cradrsService,
			IGndptnService gndptnService, IStkfytService stkfytService,
			IStkfiyService stkfiyService, IStkartService stkartService,
			IStolcuService stolcuService, ISpfharService spfharService, ISirketService sirketService,
			ISpuropService spuropService, IStnameService stnameService, IUragacService uragacService,
			IGnoptpService gnoptpService, IGnophrService gnophrService, IGnlkhrService gnlkhrService,
			ICrytklService crytklService, IXXService xxService, ISturopService sturopService,
			IGnyetkService gnyetkService, IGnkxmlService sinifyerlesimService,
			IDovkurService dovkurService, IGnkullService gnkullService, ISpkoslService spkoslService,
			IStdepoService stdepoService, ISthrktService sthrktService, ISpodtbService spodtbService, ISpfbasDal spfbasDal
			, IGnorhrService gnorhrService, IStbdrnService stbdrnService, IGnyetbService gnyetbService, IStcrkdService stcrkdService)
		{
			_gnthrkService = gnthrkService;
			_spftipService = spftipService;
			_crcariService = crcariService;
			_cradrsService = cradrsService;
			_gndptnService = gndptnService;
			_stkfytService = stkfytService;
			_stkfiyService = stkfiyService;
			_stkartService = stkartService;
			_stolcuService = stolcuService;
			_spfharService = spfharService;
			_spuropService = spuropService;
			_sturopService = sturopService;
			_crytklService = crytklService;
			_gnoptpService = gnoptpService;
			_gnophrService = gnophrService;
			_gnkullService = gnkullService;
			_stdepoService = stdepoService;
			_sthrktService = sthrktService;
			_spodtbService = spodtbService;
			_spkoslService = spkoslService;
			_stnameService = stnameService;
			_gnlkhrService = gnlkhrService;
			_uragacService = uragacService;
			_sirketService = sirketService;
			_xxService = xxService;
			_sinifService = sinifService;
			_sinifyerlesimService = sinifyerlesimService;
			_gnyetkService = gnyetkService;
			_dovkurService = dovkurService;
			_spfbasDal = spfbasDal;
			_gnorhrService = gnorhrService;
			_stbdrnService = stbdrnService;
			_gnyetbService = gnyetbService;
			_stcrkdService = stcrkdService;
			InitializeComponent();

			xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
			dtBaslangic.EditValue = DateTime.Today.AddDays(-5);
			dtBitis.EditValue = DateTime.Today.AddDays(5);
		}

		private void GetTalepList(string belgeNo = "")
		{
			SPFBAS sp = sPFBASBindingSource.Current as SPFBAS;

			if (belgeNo != "" && sp != null && sp.Id > 0)
			{
				var talep = _sinifService.Ncch_GetByBelgeNo_NLog(belgeNo, global, false).Nesne;
				List<SPFBAS> talepList = new List<SPFBAS>();
				talepList.Add(talep);

				tLBLNOGridLookUpEdit.Properties.DataSource = talepList;
				return;
			}

			if (global.Sira == 0 || global.Sira == 6) // Satınalma
			{
				var globalCopy = global.ShallowCopy();
				globalCopy.Sira = 3;

				var talepFisTipList = _spftipService.Ncch_GetListBySphrtp_NLog(globalCopy, yetkiKontrol: false).Items;
				talepFisTipList = talepFisTipList.Where(f => f.TANIMI == "Satın Alma Talebi").ToList();

				var talepList = _sinifService.Ncch_GetActiveTalepList_NLog(talepFisTipList[0].SPFTNO, global, false)
					.Items;
				tLBLNOGridLookUpEdit.Properties.DataSource = talepList;
			}
		}

		private void FrmSiparis_Load(object sender, EventArgs e)
		{
			yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
			ortamModel = _gnyetbService.Cch_GetListYetkiId_NLog(yetkiModel.Id, global, false).Items;
			FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);

			_satirNo = 0;
			barManager.Bars["Tools"].Visible = false;

			GridHelper.ColumnRepositoryItems(gridView1, global);
			
			List<STKART> stokList = _stkartService.Cch_GetListAktif_NLog(global, false).Items;

			if (global.Sira == 0 || global.Sira == 6) // Satınalma
			{
				GetTalepList();

				var kullaniciList = _gnkullService.Ncch_GetOnlyAdSoyad_NLog(global, false).Items;

				repLkedKul1.DataSource = repLkedKul2.DataSource = kullaniciList;

				colMLKBTR.Caption = "Mal Kabul Tarihi";
				colCKDEPO1.Visible = false;
				colURNOPS.Visible = false;

				foreach (Control control in xtraTabPage1.Controls)
				{
					if (control.Tag != null && control.Tag.ToString() == "1")
					{
						control.Visible = false;
					}
				}
			}
			else if (global.Sira == 1) // Satış
			{
				uaModulPaketList = _uragacService.Ncch_GetUrunAgaciModulPaketList_NLog(global).Items;

				//stokList = stokList.Where(s => s.STMLTR == Param.MAMUL_KODU).ToList();
				colGRMKTR.Caption = "Çıkış Miktarı";
				colGROLBR.Caption = "Çıkış Ölçü Birimi";
				colMLKBTR.Caption = "Makine (Ürün) Sevk Tarihi";
				colGRDEPO1.Visible = false;

				foreach (Control control in xtraTabPage1.Controls)
				{
					if (control.Tag != null && control.Tag.ToString() == "0")
					{
						control.Visible = false;
					}
				}
			}
			else if (global.Sira == 3) // Talep
			{

			}

			var teknads = new List<string>() { "OLCUKD", "SPORKD", "SPDGKD", "DVCNKD", "LANGKD", "DNSMKD" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false).Items;

			var dagKanalList = teknadsResponse.Where(w => w.TEKNAD == "SPDGKD").ToList();
			var satOrgList = teknadsResponse.Where(w => w.TEKNAD == "SPORKD").ToList();
			var languageList = teknadsResponse.Where(w => w.TEKNAD == "LANGKD").ToList();
			var dnsmanList = teknadsResponse.Where(w => w.TEKNAD == "DNSMKD").ToList();

			sPORKDGridLookUpEdit.Properties.DataSource = satOrgList;
			repLkedSporkd.DataSource = satOrgList;
			sPDGKDGridLookUpEdit.Properties.DataSource = dagKanalList;
			repLkedSpdgkd.DataSource = dagKanalList;
			gridLkeDgtKnl.Properties.DataSource = dagKanalList;
			gridLkeSatisOrg.Properties.DataSource = satOrgList;
			gridLkEdLanguage.Properties.DataSource = languageList;
			gridLkeSatisDns.Properties.DataSource = dnsmanList;
			dVCNKDGridLookUpEdit.Properties.DataSource = dVCNKDGridLookUpEdit1.Properties.DataSource = repDovizCinsi.DataSource = teknadsResponse.Where(w => w.TEKNAD == "DVCNKD").ToList();

			CariKarts = _crcariService.Cch_GetList_NLog(global, false).Items;

			gridLke1Cari1.Properties.DataSource = CariKarts;
			gridLke1Cari2.Properties.DataSource = CariKarts;
			gridLke0Cari1.Properties.DataSource = CariKarts;
			gridLke0Cari2.Properties.DataSource = CariKarts;

			repLkeBaslikCari.DataSource = CariKarts;

			var fisTipList = _spftipService.Ncch_GetListBySphrtp_NLog(global, yetkiKontrol: false).Items;
			gridLkeFisTipTab1.Properties.DataSource = fisTipList;
			gridLkeFisTip1.Properties.DataSource = fisTipList;
			gridLkeFisTip0.Properties.DataSource = fisTipList;

			if (fisTipList.Count == 1) gridLkeFisTipTab1.EditValue = fisTipList[0].SPFTNO;

			if (global.Sira == 0 || global.Sira == 6) //Satınalma ise satış org. ve dağıtımın kanalı sütunlarını kaldır
			{
				gridLkeFisTipTab1.Properties.View.Columns.RemoveAt(2);
				gridLkeFisTipTab1.Properties.View.Columns.RemoveAt(2);
			}

			var depoList = _gndptnService.Cch_GetListAktif_NLog(global, false).Items;
			gridLkeGirisDepo.Properties.DataSource = depoList;
			gridLkeCikisDepo.Properties.DataSource = depoList;

			#region Kalem

			GetStokMiktarRapor();
			repSipKalemStokKod.DataSource = stokList;
			//repSipKalemFiyatNo.DataSource = fiyatNoList;
			repLkedOlcuBirimi.DataSource = teknadsResponse.Where(w => w.TEKNAD == "OLCUKD").ToList();
			repLkeDepo.DataSource = depoList;

			#endregion

			grdViewSipKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
			grdViewSipKalem.OptionsNavigation.EnterMoveNextColumn = true;
			grdViewSipKalem.OptionsBehavior.Editable = true;
			grdViewSipKalem.OptionsBehavior.ReadOnly = false;

			GridHelper.ColumnRepositoryItems(grdViewSipKalem, global);
			GridHelper.ColumnRepositoryItems(gridViewVergilendirme, global);
			gridLkEdLanguage.EditValue = "tr-TR";

			string exeDir = AppDomain.CurrentDomain.BaseDirectory;
			string path = Path.Combine(exeDir, "images\\required.png");
			imgRequired = Image.FromFile(path);

			if (!string.IsNullOrEmpty(blgNo))
			{
				bELGENTextEdit.EditValue = blgNo;
				gridLkeFisTipTab1.EditValue = fisTipi;
				btnSiparisAra.PerformClick();

				gridView1.LocateByValue("BELGEN", blgNo);

				var link = barDegistir.GetVisibleLinks()[0];
				ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
				barDegistir_ItemClick(barDegistir, arg);
			}
			GridHelper.ColumnRepositoryRenkBedenItems(grdViewSipKalem, global);
			formLoaded = true;
		}

		private DataSet GetStokMiktarRapor()
		{
			DataSet dataSet = new DataSet();
			var stokMiktarList = _stdepoService.GetStokMiktarRapor(global).Items;
			if (global.Sira != 0 || global.Sira != 6)
			{
				var depo = gridLkeCikisDepo.EditValue;
				if (depo == null)
				{
					depo = "";
				}
				stokMiktarList = stokMiktarList.Where(x => x.DPKODU == depo.ToString()).OrderBy(x=>x.STMLTR).ToList();
			}

			
			
			
			if (stokMiktarList != null && stokMiktarList.Count > 0)
			{
				var stokMiktarByPartiList = _sthrktService.GetStokMiktarFromHareketByParti(global).Items;

				//SADECE MAMUL
				//stokMiktarList = stokMiktarList.Where(s => s.STMLTR == Param.MAMUL_KODU).ToList();
				//stokMiktarByPartiList = stokMiktarByPartiList.Where(s => s.STMLTR == Param.MAMUL_KODU).ToList();

				dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarList));
				dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarByPartiList));

				DataColumn keyColumn = dataSet.Tables[0].Columns["STKODU"];
				DataColumn keyColumn2 = dataSet.Tables[0].Columns["DPKODU"];
				DataColumn foreignKeyColumn = dataSet.Tables[1].Columns["STKODU"];
				DataColumn foreignKeyColumn2 = dataSet.Tables[1].Columns["DPKODU"];

				DataRelation dr = new DataRelation("Parti Stok", new[] { keyColumn, keyColumn2 }, new[] { foreignKeyColumn, foreignKeyColumn2 });
				dataSet.Relations.Add(dr);

				repSipKalemStokKod.DataSource = null;
				repSipKalemStokKod.DataSource = dataSet.Tables[0];
				gridView7.BestFitColumns();
			}

			return dataSet;
		}

		#region Standard

		protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
		{
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			_action = "insert";
			opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

			var fistip = Convert.ToInt32(gridLkeFisTipTab1.EditValue);
			_spftip = _spftipService.Cch_GetBySPFTNO_NLog(fistip, global).Nesne;
			tLBLNOGridLookUpEdit.Enabled = true;
			//gridLkeFisTip0.EditValue = fistip;
			//gridLkeFisTip1.EditValue = fistip;

			var rowView = (SPFBAS)sPFBASBindingSource.AddNew();
			if (rowView != null)
			{
				rowView.ACTIVE = true;
				rowView.SPFTNO = fistip;
				rowView.BELTRH = DateTime.Today;
			}

			gridLke0Cari1.EditValue = null;
			gridLke0Cari2.EditValue = null;
			gridLke1Cari1.EditValue = null;
			gridLke1Cari2.EditValue = null;

			GetDovizKur(DateTime.Today);

			ClearCari1();
			ClearCari2();
			sPFHARBindingSource.DataSource = new List<SPFHAR>();
			xtraTabControl1.SelectedTabPage = xtraTabPage3;
			xtraTabControl2.SelectedTabPage = global.Sira == 0 || global.Sira == 6 ? tabGenelVeriler0 : tabGenelVeriler1;
			TabControl();

			sPFBASBindingSource.CurrencyManager.Refresh();
		}
		public void OnayListLoad(SPFBAS _baslik)
		{
			var _model = _gnorhrService.Cch_GetListOnay_NLog(_spftip.ORGTKD, "SPFBAS", _baslik.Id, global).Items;
			var cntrl = new UsrCntOrgOnay(_model, global);
			cntrl._gnkullService = _gnkullService;
			cntrl._xxService = _xxService;
			tabOnaylist.Controls.Clear();
			tabOnaylist.AddControl(cntrl);
			cntrl.toolOnayla.Enabled = true;
			cntrl.toolOnayKaldir.Enabled = true;
		}
		protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			_action = "update";

			loadingGrid = true;

			tLBLNOGridLookUpEdit.Enabled = false;
			var baslik = (SPFBAS)sPFBASBindingSource.Current;
			baslik = _sinifService.Ncch_GetByBelgeNo_NLog(baslik.BELGEN, global).Nesne;

			gridLkeFiyatNo0.EditValue = gridLkeFiyatNo1.EditValue = baslik.STFYNO;

			_spftip = _spftipService.Cch_GetBySPFTNO_NLog(baslik.SPFTNO, global).Nesne;
			OnayListLoad(baslik);
			gNACIKMemoEdit.EditValue = memoEdit2.EditValue = gNACIKMemoEdit.Text = memoEdit2.Text = baslik.GNACIK;
			gNACIKMemoEdit.DoValidate();
			//sPFHARBindingSource.DataSource = _spfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;

			sPFBASBindingSource.CurrencyManager.Refresh();
			if (global.Sira == 1)
			{
				var lst = _spfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;
				var opList = _spuropService.Ncch_GetListByBelgeNo_NLog(baslik.BELGEN, global, false).Items;
				opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

				foreach (SPFHAR spfhar in lst)
				{
					var oList = opList.Where(o => o.SATIRN == spfhar.SATIRN).ToList();
					List<UrunOpsiyonModel> urOpModelList = new List<UrunOpsiyonModel>();
					foreach (SPUROP spurop in oList)
					{
						UrunOpsiyonModel uModel = new UrunOpsiyonModel();
						uModel.TIPKOD = spurop.TIPKOD;
						uModel.HARKOD = spurop.HARKOD;
						uModel.SATIRN = spurop.SATIRN;
						uModel.STKODU = spurop.STKODU;
						uModel.STKNAM = spurop.STKNAM;
						uModel.GFIYAT = spurop.GFIYAT;
						uModel.DVCNKD = spurop.DVCNKD;
						uModel.GNACIK = spurop.GNACIK;

						urOpModelList.Add(uModel);
					}

					Dictionary<int, List<UrunOpsiyonModel>> dict = new Dictionary<int, List<UrunOpsiyonModel>>();
					dict.Add(spfhar.SATIRN.Value, urOpModelList);
					opsiyonList.Add(dict);
				}
			}

			xtraTabControl1.SelectedTabPage = xtraTabPage3;
			xtraTabControl2.SelectedTabPage = global.Sira == 0 || global.Sira == 6 ? tabGenelVeriler0 : tabGenelVeriler1;
			_spftip = _spftipService.Cch_GetBySPFTNO_NLog(baslik.SPFTNO, global).Nesne;
			TabControl();
			sPFHARBindingSource.DataSource = _spfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;
			grdViewSipKalem.BestFitColumns();
			loadingGrid = false;
		}

		protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
		{
			var bslk = sPFBASBindingSource.Current as SPFBAS;
			if (bslk.FLGKPN != null && bslk.FLGKPN.Value)
			{
				MessageBox.Show("Sipariş kapalı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			this.Validate();
			try
			{
				if ((tabGenelVeriler1.PageVisible && gridLke1Cari1.EditValue.ToString() == "") || tabGenelVeriler0.PageVisible && gridLke0Cari1.EditValue.ToString() == "")
				{
					MessageBox.Show("Cari girmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				getVergi();
				getTutar();

				var response = new StandardResponse();
				sPFBASBindingSource.EndEdit();

				var model = new SiparisKayitModel();
				var baslik = (SPFBAS)sPFBASBindingSource.Current;
				var selectedRow = (SPFTIP)gridLkeFisTipTab1.GetSelectedDataRow();
				baslik.SPHRTP = selectedRow.SPHRTP;
				if (tabGenelVeriler0.Visible) baslik.GNACIK = memoEdit2.Text;

				model.Baslik = baslik;

				SPFBAS talepBaslik = tLBLNOGridLookUpEdit.GetSelectedDataRow() as SPFBAS;
				model.TalepBaslik = talepBaslik;

				if (_action == "insert") model.Baslik.Id = 0;

				model.Baslik.SPORKD = sPORKDGridLookUpEdit.EditValue == null ? "" : sPORKDGridLookUpEdit.EditValue.ToString();
				model.Baslik.SPDGKD = sPDGKDGridLookUpEdit.EditValue == null ? "" : sPDGKDGridLookUpEdit.EditValue.ToString();
				model.Baslik.ACTIVE = true;
				model.Baslik.SLINDI = false;

				var spfhars = sPFHARBindingSource.List;
				var harekets = new List<SPFHAR>();

				foreach (var bind in spfhars)
				{
					var hrk = (SPFHAR)bind;
					hrk.ACTIVE = true;
					hrk.SLINDI = false;
					hrk.EVRAKN = model.Baslik.EVRAKN;
					hrk.BELGEN = model.Baslik.BELGEN;
					hrk.BELTRH = model.Baslik.BELTRH;
					hrk.SPHRTP = model.Baslik.SPHRTP;
					hrk.SPORKD = model.Baslik.SPORKD;
					hrk.SPDGKD = model.Baslik.SPDGKD;
					hrk.SPFTNO = model.Baslik.SPFTNO;
					hrk.DVZFYT = hrk.GNTUTR;
					if (hrk.DVCNKD == "USD") hrk.DVZFYT *= baslik.USDFYT ?? 0;
					if (hrk.DVCNKD == "EUR") hrk.DVZFYT *= baslik.EURFYT ?? 0;

					if (hrk.PARTIT.HasValue && hrk.PARTIT.Value && string.IsNullOrEmpty(hrk.PARTIN))
					{
						MessageBox.Show(hrk.STKODU + " - " + hrk.STKNAM + Environment.NewLine + "için parti girmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					harekets.Add(hrk);

					GetUrunOpsiyonRecord(hrk.SATIRN.Value, hrk.STKODU);
				}

				model.Kalems = harekets;

				model.UrunOpsiyons = new List<UrunOpsiyonModel>();
				foreach (var opsiyon in opsiyonList)
				{
					foreach (KeyValuePair<int, List<UrunOpsiyonModel>> urOp in opsiyon)
					{
						model.UrunOpsiyons.AddRange(urOp.Value);
					}
				}

				response = _xxService.Ncch_SiparisKaydet_Log(model, global, false);
				if (response.Status != ResponseStatusEnum.OK)
				{
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();
				if (_spftip.GNONAY == true && _spftip.ORGTKD != null)
				{
					_xxService.Ncch_OrganizasyonHareketKaydet_Log(_spftip.ORGTKD, "SPFBAS", baslik.Id, global);
				}
				LoadGrid(baslik);
				var link = barDegistir.GetVisibleLinks()[0];
				ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
				barDegistir_ItemClick(barDegistir, arg);
				//FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
				//xtraTabControl1.SelectedTabPage = xtraTabPage2;
				MessageBox.Show("Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception ex)
			{
				string errorMessage = ex.GetBaseException().Message;
				MessageBox.Show("Kayıt Yapılamadı " + errorMessage);
			}
		}

		protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
		{
			DialogResult Secim;
			Secim = MessageBox.Show("Silmek istediğinizden Emin misiniz ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Secim == DialogResult.Yes)
			{
				sPFBASBindingSource.EndEdit();
				var data = (SPFBAS)sPFBASBindingSource.Current;
				_sinifService.Ncch_Delete_Log(data, global);
				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
				LoadGrid();
			}
		}

		protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (xtraTabControl1.SelectedTabPage == xtraTabPage1) return;

			DialogResult Secim;
			Secim = MessageBox.Show("Emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Secim == DialogResult.Yes)
			{
				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
				gridLke0Cari1.EditValue = null;
				gridLke0Cari2.EditValue = null;
				gridLke1Cari1.EditValue = null;
				gridLke1Cari2.EditValue = null;

				sPFBASBindingSource.CancelEdit();
				sPFHARBindingSource.CancelEdit();

				gridLkeFiyatNo0.EditValue = null;
				gridLkeFiyatNo1.EditValue = null;

				LoadGrid((SPFBAS)sPFBASBindingSource.Current);
				xtraTabControl1.SelectedTabPage = xtraTabPage2;
			}
		}

		protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
		{
			DialogResult Mesaj = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (Mesaj == DialogResult.Yes)
			{
				FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
				sPFBASBindingSource.CancelEdit();
				sPFHARBindingSource.CancelEdit();
				LoadGrid();
				GetStokMiktarRapor();
				barEkle_ItemClick(null, new ItemClickEventArgs(barEkle, barEkle.Links[0]));
			}
		}
		protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
		{
			sPFBASBindingSource.CancelEdit();
			sPFHARBindingSource.CancelEdit();
			gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
			if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
			{
				gridView1.OptionsBehavior.Editable = false;

				barManager.Bars["Tools"].Visible = false;
				xtraTabControl1.SelectedTabPage = xtraTabPage1;
			}
			else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
			{
				xtraTabControl1.SelectedTabPage = xtraTabPage2;
			}

			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				if (!barVazgec.Enabled) return base.ProcessDialogKey(keyData);

				barVazgec_ItemClick(barManager, new ItemClickEventArgs(barVazgec, barVazgec.Links[0]));
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

		#endregion

		void TabControl()
		{
			if (global.Sira == 0 || global.Sira == 6)
			{
				tabGenelVeriler0.PageVisible = true;
				tabGenelVeriler1.PageVisible = false;
				grpMuh1.Text = "Malı Teslim Eden";
				grpMuh2.Text = "Satıcı";
				if (_action == "update") btnPdf2.Visible = true;
				else btnPdf2.Visible = false;
			}
			else
			{
				tabGenelVeriler0.PageVisible = false;
				tabGenelVeriler1.PageVisible = true;
				grpMuh1.Text = "Malı Teslim Alan";
				grpMuh2.Text = "Sipariş Veren";
				if (_action == "update")
				{
					//btnPdf.Visible = true;
					btnOdemeTablosu.Visible = true;
					btnAnlasmaKosullari.Visible = true;
				}
				else
				{
					btnPdf.Visible = false;
					btnOdemeTablosu.Visible = false;
					btnAnlasmaKosullari.Visible = false;
				}
			}
		}

		private void btnSiparisAra_Click(object sender, EventArgs e)
		{
			var spFistip = (gridLkeFisTipTab1.EditValue == null || gridLkeFisTipTab1.EditValue.ToString() == "") ? (int?)null : Convert.ToInt32(gridLkeFisTipTab1.EditValue);
			var satisOrg = sPORKDGridLookUpEdit.EditValue == null ? "" : sPORKDGridLookUpEdit.EditValue.ToString();
			var dagitimKnl = sPDGKDGridLookUpEdit.EditValue == null ? "" : sPDGKDGridLookUpEdit.EditValue.ToString();
			var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
			var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
			var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

			if (spFistip == null && string.IsNullOrEmpty(belgeNo))
			{
				MessageBox.Show("Fiş tip giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			if (dtBaslangic == null && string.IsNullOrEmpty(belgeNo))
			{
				MessageBox.Show("Sipariş tarihi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}


			var selectedRow = (SPFTIP)gridLkeFisTipTab1.GetSelectedDataRow();


			if (selectedRow.KDVFLG == null)
			{
				MessageBox.Show(selectedRow.TANIMI + " fiş tipi için KDV bakımı yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			//var fiyatNoList = _stkfytService.Cch_GetListByKdvFlag_NLog(selectedRow.KDVFLG.Value, global, false).Items;
			var fiyatNoList = _stkfytService.Cch_GetAll_NLog(global, false).Items;
			var satinAlmaFiyatNoList = fiyatNoList.Where(f => f.STHRTP == 0 && f.ACTIVE && !f.SLINDI).ToList();
			var satisFiyatNoList = fiyatNoList.Where(f => f.STHRTP == 1 && f.ACTIVE && !f.SLINDI).ToList();

			gridLkeFiyatNo0.Properties.DataSource = satinAlmaFiyatNoList;
			gridLkeFiyatNo1.Properties.DataSource = satisFiyatNoList;
			repLkeBaslikFiyatNo.DataSource = global.Sira == 0 || global.Sira == 6 ? satinAlmaFiyatNoList : satisFiyatNoList;
			repSipKalemFiyatNo.DataSource = global.Sira == 0 || global.Sira == 6 ? satinAlmaFiyatNoList : satisFiyatNoList;
			repLkeBaslikFiyatNo.BestFitMode = BestFitMode.BestFitResizePopup;
			repSipKalemFiyatNo.BestFitMode = BestFitMode.BestFitResizePopup;

			LoadGrid();

			_sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
				global.MenuName,
				global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
			if (_sinifyerlesim != null)
			{
				byte[] byteArray = Encoding.ASCII.GetBytes(_sinifyerlesim.GRDXML);
				MemoryStream stream = new MemoryStream(byteArray);
				gridView1.RestoreLayoutFromStream(stream);
			}

			GridHelper.ColumnRepositoryItems(gridView1, global);

			//gridView1.Columns["KULKOD"].OptionsColumn.AllowEdit = false;
			//gridView1.SetRowCellValue(1, gridView1.Columns["KULKOD"], kulKod);

			barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
			barManager.Bars["Tools"].Visible = true;
			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
			xtraTabControl1.SelectedTabPage = xtraTabPage2;
		}

		private void LoadGrid(SPFBAS selectedBaslik = null)
		{
			loadingGrid = true;
			var spFistip = gridLkeFisTipTab1.EditValue == null ? (int?)null : Convert.ToInt32(gridLkeFisTipTab1.EditValue);
			var satisOrg = sPORKDGridLookUpEdit.EditValue == null ? "" : sPORKDGridLookUpEdit.EditValue.ToString();
			var dagitimKnl = sPDGKDGridLookUpEdit.EditValue == null ? "" : sPDGKDGridLookUpEdit.EditValue.ToString();
			var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
			var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
			var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

			var param = new SiparisParamModel()
			{
				SPDGKD = dagitimKnl,
				BELGEN = belgeNo,
				DtBaslangic = dtBas,
				DtBitis = dtBit,
				SPFTNO = spFistip,
				SPORKD = satisOrg
			};

			sPFHARBindingSource.DataSource = new List<SPFHAR>();

			list = _sinifService.Cch_GetListByParam_NLog(param, global, false).Items;
			sPFBASBindingSource.DataSource = list;
			sPFBASBindingSource.Position = -1;
			gridView1.FocusedRowHandle = GridControl.InvalidRowHandle;

			if (selectedBaslik != null)
			{
				int index = list.IndexOf(list.FirstOrDefault(s => s.BELGEN == selectedBaslik.BELGEN));
				sPFBASBindingSource.Position = index;
			}

			gridView1.OptionsBehavior.Editable = false;
			gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
			focusedRowHandler.Clear();
			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
			
			loadingGrid = false;
		}

		private void getmuhatab()
		{
			ClearCari1();
			ClearCari2();
			this.Validate();
			if (global.Sira == 0 || global.Sira == 6)
			{
				if (gridLke0Cari1.EditValue != null)
				{
					var cariKod = gridLke0Cari1.EditValue.ToString();

					var selectedRow = (CRCARI)gridLke0Cari1.GetSelectedDataRow();
					if (selectedRow == null) return;

					var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;

					var faturaAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.FTADNO);

					txtMhCariKod2.Text = cariKod;
					txtCari2Unv1.Text = selectedRow.CRUNV1;
					txtCari2Unv2.Text = selectedRow.CRUNV2;
					txtCari2Mail.Text = selectedRow.GNMAIL;
					txtCari2WebAdr.Text = selectedRow.GNWEBA;
					txtCari2VergiDaire.Text = selectedRow.VERGDA;
					txtCari2VergiNo.Text = selectedRow.VERGNO;

					txtCari2Adres.Text = faturaAdres != null ? faturaAdres.ADRESS : "";

					gridLke0Cari2.EditValue = gridLke0Cari1.EditValue;

					sPFBASBindingSource.CurrencyManager.Refresh();
				}

				sPFBASBindingSource.EndEdit();

				if (gridLke0Cari2.EditValue != null)
				{
					var cariKod = gridLke0Cari2.EditValue.ToString();

					var selectedRow = (CRCARI)gridLke0Cari2.GetSelectedDataRow();

					if (selectedRow == null) return;

					var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;

					var sevkAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.SVADNO);

					txtMhCariKod1.Text = cariKod;
					txtCari1Unv1.Text = selectedRow.CRUNV1;
					txtCari1Unv2.Text = selectedRow.CRUNV2;

					txtCari1Adres.Text = sevkAdres != null ? sevkAdres.ADRESS : "";
				}

				sPFBASBindingSource.EndEdit();
			}
			if (global.Sira == 1)
			{
				if ((gridLke1Cari1.EditValue != null))
				{
					var cariKod = gridLke1Cari1.EditValue.ToString();

					var selectedRow = (CRCARI)gridLke1Cari1.GetSelectedDataRow();
					if (selectedRow == null) return;

					var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;

					var faturaAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.FTADNO);

					txtMhCariKod2.Text = cariKod;
					txtCari2Unv1.Text = selectedRow.CRUNV1;
					txtCari2Unv2.Text = selectedRow.CRUNV2;
					txtCari2Mail.Text = selectedRow.GNMAIL;
					txtCari2WebAdr.Text = selectedRow.GNWEBA;
					txtCari2VergiDaire.Text = selectedRow.VERGDA;
					txtCari2VergiNo.Text = selectedRow.VERGNO;

					txtCari2Adres.Text = faturaAdres != null ? faturaAdres.ADRESS : "";

					gridLke1Cari2.EditValue = gridLke1Cari1.EditValue;

					sPFBASBindingSource.CurrencyManager.Refresh();
				}

				sPFBASBindingSource.EndEdit();
				if (gridLke1Cari2.EditValue != null)
				{
					var cariKod = gridLke1Cari2.EditValue.ToString();

					var selectedRow = (CRCARI)gridLke1Cari2.GetSelectedDataRow();

					if (selectedRow == null) return;

					var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;

					var sevkAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.SVADNO);

					txtMhCariKod1.Text = cariKod;
					txtCari1Unv1.Text = selectedRow.CRUNV1;
					txtCari1Unv2.Text = selectedRow.CRUNV2;

					txtCari1Adres.Text = sevkAdres != null ? sevkAdres.ADRESS : "";
				}

				sPFBASBindingSource.EndEdit();
			}
		}

		private void getVergi()
		{
			var spfhars = sPFHARBindingSource.List;
			var harekets = new List<SPFHAR>();

			foreach (SPFHAR bind in spfhars)
			{
				harekets.Add(bind.ShallowCopy());
			}

			var grpVKdvs = (from sonucP in harekets
							group sonucP by new
							{
								sonucP.KDVFLG,
								sonucP.VRGORN,
								sonucP.TEVKIF
							}
				into slc
							select new SPFHAR()
							{
								KDVFLG = slc.Key.KDVFLG,
								VRGORN = slc.Key.VRGORN,
								TEVKIF = slc.Key.TEVKIF
							}).ToList();

			var vergilendirme = new List<SPFHAR>();
			foreach (var grpVKdv in grpVKdvs)
			{
				var ilgiliVeriler = harekets.Where(w => w.VRGORN == grpVKdv.VRGORN && w.TEVKIF == grpVKdv.TEVKIF).ToList();

				decimal ttGfiyat = 0;
				decimal ttGtutar = 0;
				decimal ttMatrah = 0;
				decimal ttKdvTutar = 0;
				foreach (var hareket in ilgiliVeriler)
				{
					hareket.GISKNT = hareket.GISKNT ?? 0;
					hareket.GNTUTR = hareket.GNTUTR ?? 0;
					hareket.GFIYAT = hareket.GNTUTR ?? 0;
					hareket.VRGORN = hareket.VRGORN ?? 0;
					hareket.TEVKIF = hareket.TEVKIF ?? 0;

					if (hareket.KDVFLG != null && hareket.KDVFLG.Value)
					{
						decimal kdvTutar = hareket.GNTUTR.Value - (decimal)(hareket.GNTUTR / ((hareket.VRGORN.Value / 100) + 1));
						hareket.GFIYAT = hareket.GNTUTR - kdvTutar;
						ttKdvTutar = ttKdvTutar + kdvTutar;
					}
					else
					{
						decimal iskonto = ((hareket.GISKNT.Value * hareket.GNTUTR.Value) / 100);
						decimal kdv = (decimal)(hareket.VRGORN.Value * (hareket.GNTUTR - iskonto) / 100);
						decimal tevkifat = 0;
						if (hareket.TEVKIF != null && hareket.TEVKIF > 0)
						{
							decimal oran = (decimal)hareket.TEVKIF / 100;
							tevkifat = kdv * oran;
							kdv -= tevkifat;
						}

						//hareket.GFIYAT = hareket.GNTUTR - iskonto;
						hareket.GNTUTR = hareket.GNTUTR - iskonto + kdv;
						ttKdvTutar = ttKdvTutar + kdv;
					}

					ttGfiyat += hareket.GFIYAT ?? 0;
					ttGtutar += hareket.GNTUTR ?? 0;
				}

				vergilendirme.Add(new SPFHAR()
				{
					VRGORN = grpVKdv.VRGORN,
					TEVKIF = grpVKdv.TEVKIF,
					GNTUTR = Math.Round(ttGtutar, 2),
					GFIYAT = Math.Round(ttGfiyat, 2),
					VRGTUT = Math.Round(ttKdvTutar, 2)
				});

				var baslik = (SPFBAS)sPFBASBindingSource.Current;
				baslik.TEVKIF = grpVKdv.TEVKIF;
			}


			sPFHARBindingSourceVrg.DataSource = vergilendirme;
		}

		private void getTutar()
		{
			SPFBAS currentBas = (SPFBAS)sPFBASBindingSource.Current;
			var spfhars = sPFHARBindingSource.List;
			var harekets = new List<SPFHAR>();

			foreach (SPFHAR bind in spfhars)
			{
				harekets.Add(bind.ShallowCopy());
			}

			decimal ttBrutTutar = 0;
			decimal ttBirimTutar = 0;
			decimal ttIskontoTutar = 0;
			decimal ttKdvTutar = 0;
			decimal ttKdvliTutar = 0;
			decimal ttOtvTutar = 0;

			foreach (var hareket in harekets)
			{
				hareket.GISKNT = hareket.GISKNT ?? 0;
				hareket.GNTUTR = hareket.GNTUTR ?? 0;
				hareket.VRGORN = hareket.VRGORN ?? 0;
				hareket.OTVORN = hareket.OTVORN ?? 0;

				ttBrutTutar += hareket.GNTUTR.Value;

				decimal iskonto = ((hareket.GISKNT.Value * hareket.GNTUTR.Value) / 100);
				ttIskontoTutar = (decimal)(ttIskontoTutar + iskonto);

				decimal kdv = 0;
				if (hareket.KDVFLG != null && hareket.KDVFLG.Value)
				{
					kdv = hareket.GNTUTR.Value - (decimal)(hareket.GNTUTR / ((hareket.VRGORN.Value / 100) + 1));
					ttKdvTutar = ttKdvTutar + kdv;
					hareket.GFIYAT = hareket.GNTUTR.Value - kdv;
				}
				else
				{
					kdv = (decimal)(hareket.VRGORN.Value * (hareket.GNTUTR - iskonto) / 100);
					//hareket.GFIYAT = hareket.GNTUTR - iskonto;
					hareket.GNTUTR = hareket.GNTUTR - iskonto + kdv;
					ttKdvTutar = ttKdvTutar + kdv;
				}

				ttKdvliTutar = ttKdvliTutar + hareket.GNTUTR.Value;
				ttBirimTutar += hareket.GFIYAT.Value;

				decimal otv = ((hareket.OTVORN.Value * ttKdvliTutar) / 100);

				ttOtvTutar = ttOtvTutar + otv;

			}

			currentBas.TOPBRT = (double?)ttBrutTutar;
			currentBas.TOPISK = (double?)ttIskontoTutar;
			currentBas.TOPKDV = (double?)ttKdvTutar;
			currentBas.TOPKDT = (double?)ttKdvliTutar;
			currentBas.TOPOTV = (decimal?)ttOtvTutar;
			currentBas.TOPTUT = (double?)ttBrutTutar - (double?)ttIskontoTutar + (double)ttOtvTutar;

			string currency = "";
			if (currentBas.DVCNKD == "TRY") currency = " ₺";
			if (currentBas.DVCNKD == "EUR") currency = " €";
			if (currentBas.DVCNKD == "USD") currency = " $";

			tOPBRTTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPBRTTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPBRTTextEdit.Properties.Mask.EditMask = "n2";

			tOPISKTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPISKTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPISKTextEdit.Properties.Mask.EditMask = "n2"; 

			tOPKDVTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPKDVTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPKDVTextEdit.Properties.Mask.EditMask = "n2";

			tOPKDTTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPKDTTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPKDTTextEdit.Properties.Mask.EditMask = "n2";

			tOPOTVTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPOTVTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPOTVTextEdit.Properties.Mask.EditMask = "n2";

			tOPTUTTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPTUTTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPTUTTextEdit.Properties.Mask.EditMask = "n2";

			sPFBASBindingSource.CurrencyManager.Refresh();
		}

		private void Cari_EditValueChanged(object sender, EventArgs e)
		{
			if (loadingGrid || xtraTabControl1.SelectedTabPage != xtraTabPage3) return;

			GridLookUpEdit lked = sender as GridLookUpEdit;
			if (lked == gridLke0Cari2 || lked == gridLke1Cari2) return;

			SPFBAS spfbas = (SPFBAS)sPFBASBindingSource.Current;
			if (global.Sira == 0 || global.Sira == 6)
			{
				if (spfbas != null)
				{
					if (spfbas.Id != 0 && spfbas.SIRKID != 0)
					{
						spfbas.CRKODU = gridLke0Cari1.EditValue == null ? null : gridLke0Cari1.EditValue.ToString(); //Buraya bakılacak
					}


					gridLke0Cari2.EditValue = gridLke0Cari1.EditValue;

					string cari1 = gridLke0Cari1.EditValue == null ? "" : gridLke0Cari1.EditValue.ToString();
					string cari2 = gridLke0Cari2.EditValue == null ? "" : gridLke0Cari2.EditValue.ToString();
					spfbas.CRKODU = cari1 == "" ? null : cari1;
					spfbas.MALTES = cari2 == "" ? null : cari2;
				}
			}
			if (global.Sira == 1)
			{
				if (spfbas != null)
				{
					if (spfbas.Id != 0 && spfbas.SIRKID != 0)
					{
						spfbas.CRKODU = gridLke1Cari1.EditValue == null ? null : gridLke1Cari1.EditValue.ToString(); //Buraya bakılacak//Buraya bakılacak
					}
					gridLke1Cari2.EditValue = gridLke1Cari1.EditValue;

					string cari1 = gridLke1Cari1.EditValue == null ? "" : gridLke1Cari1.EditValue.ToString();
					string cari2 = gridLke1Cari2.EditValue == null ? "" : gridLke1Cari2.EditValue.ToString();
					spfbas.CRKODU = cari1 == "" ? null : cari1;
					spfbas.MALTES = cari2 == "" ? null : cari2;
				}
			}

			sPFBASBindingSource.CurrencyManager.Refresh();
		}

		public void ClearCari1()
		{

			foreach (Control control in grpMuh1.Controls)
			{
				if (control.Tag != null && control.Tag.ToString() == "Sil1")
				{
					control.Text = "";
				}
			}
		}

		public void ClearCari2()
		{
			foreach (Control control in grpMuh2.Controls)
			{
				if (control.Tag != null && control.Tag.ToString() == "Sil2")
				{
					control.Text = "";
				}
			}
		}

		private void grdViewSipKalem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			if (xtraTabControl2.SelectedTabPage.Name == "tabVergi" || xtraTabControl2.SelectedTabPage.Name == "tabTutar")
			{
				xtraTabControl2.SelectedTabPageIndex = 1;
			}

			if (e.Column.FieldName == "STKODU" || e.Column.FieldName == "GROLBR")
			{
				SPFHAR spfhar = (SPFHAR)sPFHARBindingSource.Current;

				var a = repLkedOlcuBirimi.DataSource;
				string olcuBirimi = spfhar.GROLBR;
				string stokKodu = spfhar.STKODU;
				List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(stokKodu, global, false).Items;

				if (e.Column.FieldName == "STKODU")
				{
					STKART stkart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
					if (stkart != null)
					{
						spfhar.PARTIT = stkart.PARTIT;
						if (stkart.PARTIT.HasValue && stkart.PARTIT.Value)
						{
							spfhar.GROLBR = "ADT";
							return;
						}
					}
				}

				if (olcuList != null && olcuList.Count > 0)
				{
					STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == olcuBirimi);
					if (olcu != null) return;
				}

				((SPFHAR)sPFHARBindingSource.Current).GROLBR = null;
				MessageBox.Show(olcuBirimi + " için ölçü çevrimi bulunamadı!", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
			}

			if (e.Column.FieldName == "GRMKTR" || e.Column.FieldName == "GFIYAT")
			{
				TutarHesapla();
			}

			if (e.Column.FieldName == "STFYNO")
			{
				SPFHAR spfhar = grdViewSipKalem.GetFocusedRow() as SPFHAR;
				if (spfhar != null)
				{
					string fiyatNo = grdViewSipKalem.GetRowCellDisplayText(e.RowHandle, "STFYNO");

					if (fiyatNo == "") spfhar.DVCNKD = null;
					else
					{
						List<STKFYT> stkfytList = repSipKalemFiyatNo.DataSource as List<STKFYT>;
						STKFYT stkfyt = stkfytList.FirstOrDefault(f => f.STFYNO == fiyatNo);
						if (stkfyt != null)
						{
							spfhar.DVCNKD = stkfyt.DVCNKD;
							grdViewSipKalem.RefreshData();
						}

					}
				}

				OpsiyonFiyatHesapla();
			}
		}

		private void TutarHesapla()
		{
			if (!formLoaded) return;

			SPFHAR spfhar = (SPFHAR)sPFHARBindingSource.Current;
			if (spfhar == null) return;
			spfhar.GNMKTR = spfhar.GNMKTR ?? 0;
			if (spfhar.GFIYAT == null) spfhar.GFIYAT = 0;
			if (spfhar.OPSFYT == null) spfhar.OPSFYT = 0;
			spfhar.GNTUTR = spfhar.GRMKTR * (spfhar.GFIYAT + spfhar.OPSFYT);
			sPFHARBindingSource.CurrencyManager.Refresh();
		}

		private void grdViewSipKalem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			if (xtraTabControl2.SelectedTabPage.Name == "tabVergi" || xtraTabControl2.SelectedTabPage.Name == "tabTutar")
			{
				xtraTabControl2.SelectedTabPageIndex = 1;
			}

			if (grdViewSipKalem.FocusedRowHandle == GridControl.NewItemRowHandle)
			{

				var spfhars = sPFHARBindingSource.List;
				var kalems = new List<SPFHAR>();

				foreach (var bind in spfhars)
				{
					kalems.Add((SPFHAR)bind);
				}

				_satirNo = 0;
				if (kalems.Count > 0)
				{
					var intPtr = kalems.OrderByDescending(o => o.SATIRN).FirstOrDefault();
					if (intPtr != null)
						_satirNo = intPtr.SATIRN ?? 0;
				}
				var data = new SPFHAR();
				_satirNo = _satirNo + 100;
				data.SATIRN = _satirNo;

				var baslik = ((SPFBAS)sPFBASBindingSource.Current);
				STKFYT stkfyt = null;

				if (global.Sira == 0 || global.Sira == 6)
				{


					if (baslik.STFYNO != 0)
					{
						data.STFYNO = baslik.STFYNO;
						stkfyt = gridLkeFiyatNo0.GetSelectedDataRow() as STKFYT;
						if (stkfyt != null) data.DVCNKD = stkfyt.DVCNKD;
					}
					if (baslik.GRDEPO != null)
					{
						data.GRDEPO = baslik.GRDEPO;
					}
				}

				if (global.Sira == 1 && gridLkeFiyatNo1.EditValue != null)
				{
					data.STFYNO = baslik.STFYNO;

					stkfyt = gridLkeFiyatNo1.GetSelectedDataRow() as STKFYT;
					if (stkfyt != null) data.DVCNKD = stkfyt.DVCNKD;

					var depo = gridLkeCikisDepo.GetSelectedDataRow() as GNDPTN;
					if (depo != null) data.CKDEPO = depo.DPKODU;
				}

				sPFHARBindingSource.Add(data);
			}
		}

		private void grdViewSipKalem_ShowingEditor(object sender, CancelEventArgs e)
		{
			GridView view = sender as GridView;

			if (view.FocusedColumn.FieldName == "PARTIN")
			{
				object parti = view.GetRowCellValue(view.FocusedRowHandle, "PARTIT");
				if (parti == null || !Convert.ToBoolean(parti))
					e.Cancel = true;
			}
		}

		private void repSipKalemStokKod_EditValueChanged(object sender, EventArgs e)
		{
			var newValue = ((ChangingEventArgs)e).NewValue;
			if (newValue == null) return;

			//STKART stkart = (STKART)repSipKalemStokKod.GetRowByKeyValue(newValue);
			STKART stkart = _stkartService.Ncch_GetByStKod_NLog(newValue.ToString(), global, false).Nesne;
			SPFHAR current = sPFHARBindingSource.Current as SPFHAR;
			if (current == null) return;

			current.STKNAM = stkart.STKNAM;
			current.SADEGK = stkart.SADEGK;
			current.KDVFLG = current.KDVFLG ?? false;

			var fytNo = Convert.ToInt32(current.STFYNO);
			var fiyatRespnse =
				_stkfiyService.Ncch_GetFiyatByFytNoStokKod_NLog(fytNo, stkart.STKODU, global);

			if (fiyatRespnse.Nesne != null)
			{
				current.GFIYAT = fiyatRespnse.Nesne.GFIYAT;
				current.GISKNT = fiyatRespnse.Nesne.GISKNT ?? 0;
				current.KDVFLG = fiyatRespnse.Nesne.KDVFLG ?? false;
			}
			else
			{
				current.GFIYAT = 0;
				current.GISKNT = 0;
			}

			var selectedRow = (SPFTIP)gridLkeFisTipTab1.GetSelectedDataRow();

			current.VRGORN = current.KDVFLG.Value ? stkart.KDVORN : 0;

			var hareketTipi = selectedRow.SPHRTP;
			current.GROLBR = hareketTipi == 0 ? stkart.SAOLKD : stkart.OLCUKD;
			current.OLCUKD = stkart.OLCUKD;
			sPFHARBindingSource.CurrencyManager.Refresh();
		}

		private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			if (e.Page.Name == "tabMuhatap")
			{
				getmuhatab();
			}

			if (e.Page.Name == "tabVergi")
			{
				getVergi();
			}

			if (e.Page.Name == "tabTutar")
			{
				getTutar();
			}
		}

		private Dictionary<int, List<UrunOpsiyonModel>> GetUrunOpsiyonRecord(int satirNo, string stokKodu)
		{
			var record = opsiyonList.FirstOrDefault(o => o.ContainsKey(satirNo));
			if (record == null)
			{
				Dictionary<int, List<UrunOpsiyonModel>> dict = new Dictionary<int, List<UrunOpsiyonModel>>();
				dict.Add(satirNo, new List<UrunOpsiyonModel>());
				opsiyonList.Add(dict);
				record = dict;
			}

			var urunOps = record[satirNo];
			if (urunOps == null || urunOps.Count == 0)
			{
				var opList = _sturopService.Ncch_GetByStokKodu_NLog(global, stokKodu, false).Items;
				if (opList != null && opList.Count > 0)
				{
					List<UrunOpsiyonModel> modList = new List<UrunOpsiyonModel>();
					foreach (var sturop in opList)
					{
						UrunOpsiyonModel uropMod = new UrunOpsiyonModel();
						uropMod.STKODU = sturop.STKODU;
						uropMod.STKNAM = sturop.STKNAM;
						uropMod.SATIRN = satirNo;
						uropMod.TIPKOD = sturop.TIPKOD;
						uropMod.HARKOD = sturop.HARKOD;

						GNOPHR gnophr = _gnophrService
							.Ncch_GetByTipAndHarKod(global, uropMod.TIPKOD, uropMod.HARKOD, false).Nesne;
						if (gnophr != null)
						{
							uropMod.GFIYAT = gnophr.GFIYAT;
							uropMod.DVCNKD = gnophr.DVCNKD;
						}

						modList.Add(uropMod);
					}

					record[satirNo] = modList;
				}
			}

			return record;
		}

		private void repButUrunOpsiyon_Click(object sender, EventArgs e)
		{
			string stokKodu = grdViewSipKalem.GetFocusedRowCellDisplayText("STKODU");
			string stokAdi = grdViewSipKalem.GetFocusedRowCellDisplayText("STKNAM");
			int satirNo = Convert.ToInt32(grdViewSipKalem.GetFocusedRowCellDisplayText("SATIRN"));

			if (stokKodu != "")
			{
				var record = GetUrunOpsiyonRecord(satirNo, stokKodu);

				FrmUrunOpsiyon frmUrunOpsiyon = new FrmUrunOpsiyon();
				frmUrunOpsiyon.satirNo = satirNo;
				frmUrunOpsiyon.global = global;
				frmUrunOpsiyon.lblStokKodu.Text = stokKodu;
				frmUrunOpsiyon.lblStokAdi.Text = stokAdi;
				if (record != null) frmUrunOpsiyon.opsiyonList = record[satirNo];

				frmUrunOpsiyon.ShowDialog();

				if (frmUrunOpsiyon.opsiyonDict.Count > 0)
				{
					if (record != null) opsiyonList.Remove(record);
					opsiyonList.Add(frmUrunOpsiyon.opsiyonDict);
				}

				OpsiyonFiyatHesapla();
			}
		}

		private void OpsiyonFiyatHesapla()
		{
			if (!formLoaded) return;

			var ds = sPFHARBindingSource.DataSource as List<SPFHAR>;
			var baslik = sPFBASBindingSource.Current as SPFBAS;

			if (ds == null || baslik == null) return;

			decimal? eur = baslik.EURFYT;
			decimal? usd = baslik.USDFYT;

			if (eur == null || eur == 0) eur = -1;
			if (usd == null || usd == 0) usd = -1;

			foreach (Dictionary<int, List<UrunOpsiyonModel>> dict in opsiyonList)
			{
				var firstPair = dict.First();
				int satirNo = Convert.ToInt32(firstPair.Key);
				List<UrunOpsiyonModel> uropList = firstPair.Value;
				SPFHAR spfhar = ds.FirstOrDefault(s => s.SATIRN == satirNo);
				if (spfhar == null) return;

				uropList = uropList.Where(u => u.GFIYAT != null && u.GFIYAT.Value > 0).ToList();

				decimal totalFiyat = 0;
				foreach (UrunOpsiyonModel urop in uropList)
				{
					if (urop.DVCNKD == spfhar.DVCNKD)
					{
						totalFiyat += urop.GFIYAT.Value;
					}
					else if (spfhar.DVCNKD == "TRY")
					{
						if (urop.DVCNKD == "EUR")
						{
							var tl = urop.GFIYAT.Value * eur;
							totalFiyat += tl.Value;
						}
						else if (urop.DVCNKD == "USD")
						{
							var tl = urop.GFIYAT.Value * usd;
							totalFiyat += tl.Value;
						}
					}
					else if (spfhar.DVCNKD == "USD")
					{
						if (urop.DVCNKD == "EUR")
						{
							var tl = urop.GFIYAT.Value * eur;
							var dvz = tl / usd;
							totalFiyat += dvz.Value;
						}
						else if (urop.DVCNKD == "TRY")
						{
							var dvz = urop.GFIYAT.Value / usd;
							totalFiyat += dvz.Value;
						}
					}
					else if (spfhar.DVCNKD == "EUR")
					{
						if (urop.DVCNKD == "USD")
						{
							var tl = urop.GFIYAT.Value * usd;
							var dvz = tl / eur;
							totalFiyat += dvz.Value;
						}
						else if (urop.DVCNKD == "TRY")
						{
							var dvz = urop.GFIYAT.Value / eur;
							totalFiyat += dvz.Value;
						}
					}
				}

				spfhar.OPSFYT = totalFiyat;
			}

			TutarHesapla();
			grdViewSipKalem.RefreshData();
		}

		private void bindingNavigatorDeleteItem2_Click(object sender, EventArgs e)
		{
			var ds = sPFHARBindingSource.DataSource as List<SPFHAR>;

			for (int i = opsiyonList.Count - 1; i > -1; i--)
			{
				var dict = opsiyonList[i];
				foreach (KeyValuePair<int, List<UrunOpsiyonModel>> urOp in dict)
				{
					int key = Convert.ToInt32(urOp.Key);
					SPFHAR spfhar = ds.FirstOrDefault(s => s.SATIRN == key);
					if (spfhar == null) opsiyonList.Remove(dict);
				}
			}
		}

		//private void btnPdf_Click(object sender, EventArgs e)
		//{
		//    List<SPFHAR> urunList = sPFHARBindingSource.List as List<SPFHAR>;
		//    List<SiparisUrunModel> sipUrModels = new List<SiparisUrunModel>();

		//    foreach (var spfhar in urunList)
		//    {
		//        string stokKodu = spfhar.STKODU;
		//        string stokAdi = spfhar.STKNAM;
		//        int satirNo = spfhar.SATIRN.Value;

		//        if (!string.IsNullOrEmpty(stokKodu))
		//        {
		//            STKART stokKart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;
		//            var gnoptpList = _gnoptpService.Ncch_GetListByUstTipKod_NLog(global, stokKart.UROPTB).Items;

		//            var opsiyon = opsiyonList.FirstOrDefault(o => o.ContainsKey(satirNo));

		//            string opsiyonlar = "";

		//            foreach (KeyValuePair<int, List<UrunOpsiyonModel>> urOp in opsiyon)
		//            {
		//                foreach (UrunOpsiyonModel model in urOp.Value)
		//                {
		//                    GNOPTP tip = gnoptpList.FirstOrDefault(t => t.TIPKOD == model.TIPKOD);
		//                    if (tip != null)
		//                    {
		//                        List<GNOPHR> tipHareketList = _gnophrService.Cch_GetListByTipKod(global, tip.TIPKOD).Items;
		//                        GNOPHR tipHareket = tipHareketList.FirstOrDefault(t => t.HARKOD == model.HARKOD);
		//                        if (tipHareket != null)
		//                        {
		//                            opsiyonlar += "<b>" + tip.TIPADI + ":</b> " + tipHareket.TANIMI + "<br>";
		//                        }
		//                    }
		//                }
		//            }

		//            if (opsiyonlar != "")
		//            {
		//                opsiyonlar = "<p style=\"font-family: Calibri; font-size: 12px\">" + opsiyonlar + "</p>";
		//            }

		//            sipUrModels.Add(new SiparisUrunModel { STKODU = stokKodu, STKNAM = stokAdi, URNOPS = opsiyonlar, GNMKTR = spfhar.GRMKTR, OLCUKD = spfhar.GROLBR, GFIYAT = spfhar.GFIYAT, GNTUTR = spfhar.GNTUTR });
		//        }
		//    }

		//    var cariKod = gridLke1Cari1.EditValue.ToString();

		//    var selectedRow = (CRCARI)gridLke1Cari1.GetSelectedDataRow();
		//    if (selectedRow == null) return;

		//    var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;
		//    var faturaAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.FTADNO);
		//    var yetkililer = _crytklService.Cch_GetListByCariKod_NLog(cariKod, global, false).Items;

		//    CRYTKL crytkl = null;
		//    if (yetkililer.Count > 0) crytkl = yetkililer[0];


		//    List<SPFBAS> spfbasList = sPFBASBindingSource.DataSource as List<SPFBAS>;

		//    repSiparis rSiparis = new repSiparis();
		//    rSiparis.cellBelgeNo.Text = spfbasList[0].BELGEN;
		//    rSiparis.labelDate.Text = DateTime.Now.ToShortDateString();
		//    rSiparis.cellMusteriAdi.Text = selectedRow.CRUNV1;
		//    rSiparis.cellAdres.Text = faturaAdres != null ? faturaAdres.ADRESS : "";
		//    rSiparis.cellEposta.Text = crytkl != null ? crytkl.GNMAIL : selectedRow.GNMAIL;
		//    rSiparis.cellYetkiliKisi.Text = crytkl != null ? crytkl.YETADI + " " + crytkl.YETSOY : "";
		//    rSiparis.cellSiparisTarihi.Text = spfbasList[0].BELTRH.ToShortDateString();
		//    rSiparis.cellTerminTarihi.Text = spfbasList[0].TERTAR?.ToShortDateString();
		//    rSiparis.lblAciklama.Text = spfbasList[0].GNACIK;

		//    rSiparis.bindingSource1.DataSource = sipUrModels;
		//    rSiparis.ShowPreviewDialog();
		//}

		private CultureInfo GetCultureInfo(string currency, out string outCurrency)
		{
			outCurrency = " ₺";
			CultureInfo cultureInfo = new CultureInfo("tr-TR");

			if (currency == "TRY")
			{
				outCurrency = " ₺";
				return new CultureInfo("tr-TR");
			}

			if (currency == "EUR")
			{
				outCurrency = " €";
				return new CultureInfo("de-DE");
			}

			if (currency == "USD")
			{
				outCurrency = " $";
				return new CultureInfo("en-US");
			}

			return cultureInfo;
		}

		private void btnPdf_Click(object sender, EventArgs e)
		{
			List<SPFHAR> urunList = sPFHARBindingSource.List as List<SPFHAR>;
			SPFBAS spfbas = sPFBASBindingSource.Current as SPFBAS;

			var cariKod = gridLke1Cari1.EditValue.ToString();

			var selectedRow = (CRCARI)gridLke1Cari1.GetSelectedDataRow();
			if (selectedRow == null) return;

			var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;
			var faturaAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.FTADNO);
			var yetkililer = _crytklService.Cch_GetListByCariKod_NLog(cariKod, global, false).Items;

			CRYTKL crytkl = null;
			if (yetkililer.Count > 0) crytkl = yetkililer[0];

			string currency = "";
			CultureInfo cultureInfo = GetCultureInfo(spfbas.DVCNKD, out currency);
			decimal toplamFiyat = 0;
			repSiparis rSiparis = null;

			string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
			string htmlTableEnd = "</table>";
			string htmlHeaderRowStart = "<tr style=\"color:#000000;\">";
			string htmlHeaderRowEnd = "</tr>";
			string htmlTrStart = "<tr style=\"color:#000000;\">";
			string htmlTrEnd = "</tr>";
			string htmlTdStart = "<td style=\" border-color:#000000; border-style:solid; border-width:1px; padding: 3px; \">";
			//string htmlTdStartMerge = "<td colspan=4 style=\" font-family: Calibri; font-size: 12pt; border-color:#000000; border-style:solid; border-width:1px; padding: 5px;\">";
			string htmlTdEnd = "</td>";

			List<SPFHAR> opsiyonsuzUrunList = new List<SPFHAR>();
			foreach (var spfhar in urunList)
			{
				string stokKodu = spfhar.STKODU;
				string stokAdi = spfhar.STKNAM;
				int satirNo = spfhar.SATIRN.Value;
				toplamFiyat += spfhar.GFIYAT.Value;

				if (!string.IsNullOrEmpty(stokKodu))
				{
					STKART stokKart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;
					if (stokKart.UROPTB == null)
					{
						opsiyonsuzUrunList.Add(spfhar);
					}
					else
					{
						repSiparis repSip = new repSiparis();
						repSip.ApplyLocalization(cultureInfo);

						int columnC = 4;

						var gnoptpList = _gnoptpService.Ncch_GetListByUstTipKod_NLog(global, stokKart.UROPTB).Items;

						var opsiyon = opsiyonList.FirstOrDefault(o => o.ContainsKey(satirNo));

						string opsiyonlar = "";
						string aciklama = "";

						opsiyonlar += htmlTableStart;
						opsiyonlar += htmlHeaderRowStart;
						//opsiyonlar += htmlTdStartMerge + "title" + htmlTdEnd + htmlHeaderRowEnd; //ilk boş satır + tablo başlığı;

						opsiyonlar += htmlHeaderRowStart;

						opsiyonlar += "<td colspan=\"2\" style=\" border-color:#000000; border-style:solid; border-width:1px; padding: 3px; font-weight: bold;\">" + "Teknik Özellikler" + htmlTdEnd;
						opsiyonlar += HtmlTdStartOptionalCss("text-align: center; font-weight: bold;") + "Standart" + htmlTdEnd;
						opsiyonlar += HtmlTdStartOptionalCss("text-align: center; font-weight: bold;") + "Opsiyon" + htmlTdEnd;

						opsiyonlar += htmlHeaderRowEnd;
						float fontSize = 12;

						foreach (KeyValuePair<int, List<UrunOpsiyonModel>> urOp in opsiyon)
						{
							foreach (UrunOpsiyonModel model in urOp.Value)
							{
								if (urOp.Value.Count > 16) fontSize = 10;
								GNOPTP tip = gnoptpList.FirstOrDefault(t => t.TIPKOD == model.TIPKOD);
								if (tip != null)
								{
									List<GNOPHR> tipHareketList = _gnophrService.Ncch_GetListByTipKod(global, tip.TIPKOD).Items;
									GNOPHR tipHareket = tipHareketList.FirstOrDefault(t => t.HARKOD == model.HARKOD);
									if (tipHareket != null)
									{
										if (tipHareket.TANIMI.Contains("YOK")) continue;
										//opsiyonlar += "<b>" + tip.TIPADI + ":</b> " + tipHareket.TANIMI + "<br>"; önceki
										opsiyonlar = opsiyonlar + htmlTrStart;
										for (int i = 0; i < columnC; i++)
										{
											if (i == 0)
											{
												opsiyonlar = opsiyonlar + HtmlTdStartOptionalCss("width: 240px; font-weight: bold;") + tip.TIPADI + htmlTdEnd;
											}
											else if (i == 1) opsiyonlar = opsiyonlar + HtmlTdStartOptionalCss("width: 254px;") + tipHareket.TANIMI + htmlTdEnd;
											else if (i == 2)
											{
												if (model.GFIYAT == null || model.GFIYAT == 0)
												{
													opsiyonlar = opsiyonlar + HtmlTdStartOptionalCss("width: 70px; text-align: center;") + "✔" +
																 htmlTdEnd;
												}
												else opsiyonlar = opsiyonlar + htmlTdStart + htmlTdEnd;
											}
											else if (i == 3)
											{
												if (model.GFIYAT != null && model.GFIYAT.Value > 0)
												{
													decimal fiyat = EqualizeOpsiyonFiyatCurrency(model.GFIYAT.Value,
														model.DVCNKD, spfbas.DVCNKD);
													opsiyonlar = opsiyonlar + HtmlTdStartOptionalCss("width: 80px; text-align: right; font-weight: bold;") + currency + fiyat.ToString("n2") + htmlTdEnd;
												}
												else opsiyonlar = opsiyonlar + htmlTdStart + htmlTdEnd;
											}
										}
										opsiyonlar = opsiyonlar + htmlTrEnd;
									}
								}
								else
								{
									if (model.TIPKOD == "000" && model.HARKOD == "00")
									{
										aciklama = model.GNACIK;
									}
								}
							}
							opsiyonlar = opsiyonlar + htmlTableEnd;
						}

						if (opsiyonlar != "")
						{
							opsiyonlar = "<p style=\"font-family: Calibri; font-size: " + fontSize + "px\">" + opsiyonlar + "</p>";
						}

						List<SiparisUrunModel> lst = new List<SiparisUrunModel>();
						lst.Add(new SiparisUrunModel { STKODU = stokKodu, STKNAM = stokAdi, URNOPS = opsiyonlar, GNMKTR = spfhar.GRMKTR, OLCUKD = spfhar.GROLBR, GFIYAT = spfhar.GFIYAT, GNTUTR = spfhar.GNTUTR });

						//Thread.CurrentThread.CurrentCulture = new CultureInfo("en-US");
						//localizedReport.ApplyLocalization(new CultureInfo("de-DE"));

						repSip.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
						repSip.cellBelgeNo.Text = spfbas.BELGEN;
						repSip.labelDate.Text = DateTime.Now.ToShortDateString();
						repSip.cellMusteriAdi.Text = selectedRow.CRUNV1;
						repSip.cellAdres.Text = faturaAdres != null ? faturaAdres.ADRESS : "";
						repSip.cellEposta.Text = crytkl != null ? crytkl.GNMAIL : selectedRow.GNMAIL;
						repSip.cellYetkiliKisi.Text = crytkl != null ? crytkl.YETADI + " " + crytkl.YETSOY : "";
						repSip.cellTelefon.Text = crytkl != null ? crytkl.CEPTEL : "";
						repSip.cellSiparisTarihi.Text = spfbas.BELTRH.ToShortDateString();
						repSip.cellTerminTarihi.Text = spfbas.TERTAR?.ToShortDateString();
						repSip.lblAciklama.Text = aciklama;
						repSip.bindingSource1.DataSource = lst;
						repSip.CreateDocument();

						if (rSiparis == null)
						{
							rSiparis = repSip;
							rSiparis.PrintingSystem.ContinuousPageNumbering = true;
						}
						else
						{
							rSiparis.Pages.AddRange(repSip.Pages);
						}
					}
				}
			}

            repSiparisLastPage rSip = new repSiparisLastPage();
            rSip.ApplyLocalization(cultureInfo);
            rSip.cellBelgeNo.Text = spfbas.BELGEN;
            rSip.labelDate.Text = DateTime.Now.ToShortDateString();
            rSip.cellSiparisTarihi.Text = spfbas.BELTRH.ToShortDateString();
            rSip.cellTerminTarihi.Text = spfbas.TERTAR?.ToShortDateString();
            rSip.lblGenelToplam.Text = currency + spfbas.TOPBRT.Value.ToString("n2");
            rSip.lblIskonto.Text = currency + spfbas.TOPISK.Value.ToString("n2");
            rSip.lblKdv.Text = currency + spfbas.TOPKDV.Value.ToString("n2");
            rSip.lblAraToplam.Text = currency + (spfbas.TOPBRT.Value - spfbas.TOPISK.Value).ToString("n2");
            rSip.lblOdenecekTutar.Text = currency + (spfbas.TOPKDT.Value).ToString("n2");
            rSip.xrLabel1.Visible = false;
            rSip.xrLabel3.Visible = false;
            rSip.xrLabel4.Visible = false;
            rSip.xrLabel5.Visible = false;
            rSip.xrTable1.Visible = false;

            if (rSiparis == null && opsiyonsuzUrunList.Count > 0)
			{
				List<SiparisUrunModel> lst = new List<SiparisUrunModel>();
				foreach (SPFHAR urn in opsiyonsuzUrunList)
				{
					lst.Add(new SiparisUrunModel { STKODU = urn.STKODU, STKNAM = urn.STKNAM, URNOPS = "", GNMKTR = urn.GRMKTR, OLCUKD = urn.GROLBR, GFIYAT = urn.GFIYAT, GNTUTR = urn.GNTUTR });
				}

				subRepUrun subReportUrun = new subRepUrun();
				subReportUrun.ApplyLocalization(cultureInfo);
				subReportUrun.DataSource = lst;
				rSip.subReportUrunler.ReportSource = subReportUrun;

				subReportUrun.cellMusteriAdi.Text = selectedRow.CRUNV1;
				subReportUrun.cellAdres.Text = faturaAdres != null ? faturaAdres.ADRESS : "";
				subReportUrun.cellEposta.Text = crytkl != null ? crytkl.GNMAIL : selectedRow.GNMAIL;
				subReportUrun.cellYetkiliKisi.Text = crytkl != null ? crytkl.YETADI + " " + crytkl.YETSOY : "";
				subReportUrun.cellTelefon.Text = crytkl != null ? crytkl.CEPTEL : "";
				//rSiparis.lblAciklama.Text = aciklama;
				rSip.PrintingSystem.ContinuousPageNumbering = false;
			}
			//else if (opsiyonsuzUrunList.Count > 0)
			//{
			//	List<SiparisUrunModel> lst = new List<SiparisUrunModel>();
			//	foreach (SPFHAR urn in opsiyonsuzUrunList)
			//	{
			//		lst.Add(new SiparisUrunModel { STKODU = urn.STKODU, STKNAM = urn.STKNAM, URNOPS = "", GNMKTR = urn.GRMKTR, OLCUKD = urn.GROLBR, GFIYAT = urn.GFIYAT, GNTUTR = urn.GNTUTR });
			//	}

			//	subRepUrun subReportUrun = new subRepUrun();
			//	subReportUrun.ApplyLocalization(cultureInfo);
			//	subReportUrun.Bands.Remove(subReportUrun.ReportHeader);
			//	subReportUrun.DataSource = lst;
			//	rSip.subReportUrunler.ReportSource = subReportUrun;
			//}

			//List<SiparisKosulModel> kosulList = _spkoslService.Ncch_GetListByBelgeNoJoinGnkosul_NLog(global, spfbas.BELGEN, "tr-TR").Items;
			//string kosullar = "";

			//if (kosulList != null && kosulList.Count > 0)
			//{
			//	htmlTdStart = "<td>";
			//	kosullar = htmlTableStart;

			//	foreach (SiparisKosulModel spKosul in kosulList)
			//	{
			//		string kosul = "- " + spKosul.KOSULL;
			//		if (kosul.Contains("NAKLİYE ALICIYA AİTTİR"))
			//			kosul = kosul.Replace("NAKLİYE ALICIYA AİTTİR.", "<b>NAKLİYE ALICIYA AİTTİR.</b>");
			//		kosullar += htmlTrStart + htmlTdStart + kosul + htmlTdEnd + htmlTrEnd;
			//	}

			//	kosullar = kosullar + htmlTableEnd;
			//	kosullar = "<p style=\"font-family: Calibri; font-size: 12px\">" + kosullar + "</p>";
			//}

			//subRepAnlasmaKosullari subRepAn = new subRepAnlasmaKosullari();
			//subRepAn.ApplyLocalization(cultureInfo);
			//subRepAn.richTextAnlasmaKosullari.Html = kosullar;

			//subRepOdemeTablosu subRepOd = null;

			//var odemeList = _spodtbService.Ncch_GetListByBelgeNo_NLog(global, spfbas.BELGEN).Items;

			//if (odemeList != null && odemeList.Count > 0)
			//{
			//	subRepOd = new subRepOdemeTablosu();
			//	subRepOd.ApplyLocalization(cultureInfo);
			//	subRepOd.bindingSource1.DataSource = odemeList;
			//	subRepOd.CreateDocument();
			//}

			//repBlankPage repBlnkPage = null;
			//if (opsiyonsuzUrunList.Count == 0)
			//{
			//	rSip.subRepAnlasmaKos.ReportSource = subRepAn;
			//	if (subRepOd != null) rSip.subRepOdemeTablosu.ReportSource = subRepOd;
			//	else rSip.subRepOdemeTablosu.ReportSource = null;
			//}
			//else
			//{
			//	rSip.subRepAnlasmaKos.ReportSource = null;
			//	rSip.subRepOdemeTablosu.ReportSource = null;

			//	repBlnkPage = new repBlankPage();
			//	repBlnkPage.ApplyLocalization(cultureInfo);
			//	repBlnkPage.subRepAnlasmaKos.ReportSource = subRepAn;
			//	repBlnkPage.cellBelgeNo.Text = spfbas.BELGEN;
			//	repBlnkPage.labelDate.Text = DateTime.Now.ToShortDateString();
			//	repBlnkPage.cellSiparisTarihi.Text = spfbas.BELTRH.ToShortDateString();
			//	repBlnkPage.cellTerminTarihi.Text = spfbas.TERTAR?.ToShortDateString();

			//	repBlnkPage.xrLabel1.Visible = false;
			//	repBlnkPage.xrLabel3.Visible = false;
			//	repBlnkPage.xrLabel4.Visible = false;
			//	repBlnkPage.xrLabel5.Visible = false;

			//	if (subRepOd != null) repBlnkPage.subRepOdemeTablosu.ReportSource = subRepOd;
			//	else repBlnkPage.subRepOdemeTablosu.ReportSource = null;
			//	rSip.richTextBankaBilgileri.Text = null;

			//	repBlnkPage.CreateDocument();
			//}

			if (rSiparis == null)
			{
				rSip.CreateDocument();

				//if (repBlnkPage != null)
				//{
				//	rSip.Pages.AddRange(repBlnkPage.Pages);
				//}

				rSip.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
				rSip.ShowPreview();
			}
			else
			{
				rSip.CreateDocument();
				rSiparis.Pages.AddRange(rSip.Pages);
				//if (repBlnkPage != null)
				//{
				//	rSiparis.Pages.AddRange(repBlnkPage.Pages);
				//}
				rSiparis.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
				rSiparis.ShowPreview();
			}
		}

		private string HtmlTdStartOptionalCss(string optionalCss)
		{

			return "<td style=\" border-color:#000000; border-style:solid; border-width:1px; padding: 3px; " + optionalCss + " \">";
		}

		private decimal EqualizeOpsiyonFiyatCurrency(decimal fiyat, string sourceCurrency, string targetCurrency)
		{
			var baslik = sPFBASBindingSource.Current as SPFBAS;
			decimal? eur = baslik.EURFYT;
			decimal? usd = baslik.USDFYT;

			if (eur == null || eur == 0) eur = -1;
			if (usd == null || usd == 0) usd = -1;

			if (sourceCurrency == targetCurrency) return fiyat;

			if (targetCurrency == "TRY")
			{
				if (sourceCurrency == "EUR") return fiyat * eur.Value;
				if (sourceCurrency == "USD") return fiyat * usd.Value;
			}
			else if (targetCurrency == "USD")
			{
				if (sourceCurrency == "EUR") return fiyat * eur.Value / usd.Value;
				if (sourceCurrency == "TRY") return fiyat / usd.Value;
			}
			else if (targetCurrency == "EUR")
			{
				if (sourceCurrency == "USD") return fiyat * usd.Value / eur.Value;
				if (sourceCurrency == "TRY") return fiyat / eur.Value;
			}

			return -1;
		}

		private void gridControl1_DoubleClick(object sender, EventArgs e)
		{
			Point point = gridView1.GridControl.PointToClient(MousePosition);
			DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = gridView1.CalcHitInfo(point);
			if (info.InRow || info.InRowCell)
			{
				var link = barDegistir.GetVisibleLinks()[0];
				ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
				barDegistir_ItemClick(barDegistir, arg);
			}
		}

		private void grdViewSipKalem_CustomColumnDisplayText(object sender, DevExpress.XtraGrid.Views.Base.CustomColumnDisplayTextEventArgs e)
		{
			if (e.Column.FieldName == "GFIYAT" || e.Column.FieldName == "GNTUTR" || e.Column.FieldName == "OPSFYT" || e.Column.FieldName == "DVZFYT")
			{
				var rowHandle = e.ListSourceRowIndex;

				string stfyno = grdViewSipKalem.GetRowCellDisplayText(rowHandle, "STFYNO");
				List<STKFYT> stkfytList = repSipKalemFiyatNo.DataSource as List<STKFYT>;
				STKFYT stkfyt = stkfytList.FirstOrDefault(s => s.STFYNO == stfyno);

				if (stkfyt != null)
				{
					if (stkfyt.DVCNKD == "TRY" && e.Value != null) e.DisplayText = Convert.ToSingle(e.Value).ToString("n2") + " ₺";
					if (stkfyt.DVCNKD == "USD" && e.Value != null) e.DisplayText = Convert.ToSingle(e.Value).ToString("n2") + " $";
					if (stkfyt.DVCNKD == "EUR" && e.Value != null) e.DisplayText = Convert.ToSingle(e.Value).ToString("n2") + " €";

					if (e.Column.FieldName == "DVZFYT") e.DisplayText = Convert.ToSingle(e.Value).ToString("n2") + " ₺";
				}
			}
		}

		private void gridLkeFiyatNo1_EditValueChanged(object sender, EventArgs e)
		{
			if (global.Sira == 0 || global.Sira == 6) return;

			GridLookUpEdit lookup = sender as GridLookUpEdit;
			STKFYT stkfyt = lookup.GetSelectedDataRow() as STKFYT;

			if (stkfyt != null)
			{
				SPFBAS spfbas = (SPFBAS)sPFBASBindingSource.Current;
				spfbas.STFYNO = Convert.ToInt32(stkfyt.STFYNO);
				spfbas.DVCNKD = stkfyt.DVCNKD;
				sPFBASBindingSource.CurrencyManager.Refresh();
			}
		}

		private void tLBLNOGridLookUpEdit_MouseClick(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				tLBLNOGridLookUpEdit.EditValue = null;
				tLBLNOGridLookUpEdit.EditValue = null;
			}
		}

		private void tLBLNOGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
		{
			var ev = e as ChangingEventArgs;
			string tlblno = "";
			if (ev.NewValue != null && ev.NewValue.ToString() != "") tlblno = ev.NewValue.ToString();
			RefreshTalepKalem(tlblno);
		}

		private void RefreshTalepKalem(string tlblno = "")
		{
			if (!formLoaded) return;

			var baslik = (SPFBAS)sPFBASBindingSource.Current;
			if (baslik == null) return;

			baslik.TLBLNO = tlblno == "" ? null : tlblno;

			if (string.IsNullOrEmpty(tlblno))
			{
				bndNvgHareket.Visible = true;
				grdViewSipKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
				colSTKODU.OptionsColumn.ReadOnly = false;
				colSTKNAM.OptionsColumn.ReadOnly = false;
				//baslik.GNACIK = "";
				sPFHARBindingSource.DataSource = new List<SPFHAR>();
			}
			else
			{
				GetTalepList(tlblno);

				bndNvgHareket.Visible = false;
				grdViewSipKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
				colSTKODU.OptionsColumn.ReadOnly = true;
				colSTKNAM.OptionsColumn.ReadOnly = true;

				STKFYT stkfyt = gridLkeFiyatNo0.GetSelectedDataRow() as STKFYT;
				SPFBAS talepBaslik = tLBLNOGridLookUpEdit.GetSelectedDataRow() as SPFBAS;
				if (talepBaslik != null)
				{
					baslik.TERTAR = talepBaslik.TERTAR;
					baslik.GRDEPO = talepBaslik.GRDEPO;
					baslik.GNACIK = talepBaslik.GNACIK;
				}

				var kalemList = _spfharService.Cch_GetListByBelge_NLog(baslik.TLBLNO, global).Items;

				if (stkfyt != null)
				{
					baslik.STFYNO = Convert.ToInt32(stkfyt.STFYNO);

					foreach (SPFHAR kalem in kalemList)
					{
						kalem.STFYNO = baslik.STFYNO;
						kalem.DVCNKD = baslik.DVCNKD;
						kalem.KDVFLG = stkfyt.KDVFLG;

						var fytNo = Convert.ToInt32(kalem.STFYNO);
						var fiyatRespnse =
							_stkfiyService.Ncch_GetFiyatByFytNoStokKod_NLog(fytNo, kalem.STKODU, global);

						if (fiyatRespnse.Nesne != null)
						{
							kalem.GFIYAT = fiyatRespnse.Nesne.GFIYAT;
							kalem.GISKNT = fiyatRespnse.Nesne.GISKNT ?? 0;
							kalem.KDVFLG = fiyatRespnse.Nesne.KDVFLG ?? false;
							kalem.GNTUTR = kalem.GRMKTR * kalem.GFIYAT;
						}
						else
						{
							kalem.GFIYAT = 0;
							kalem.GISKNT = 0;
						}
					}
				}

				sPFHARBindingSource.DataSource = kalemList;
				grdViewSipKalem.BestFitColumns();
				tERTARDateEdit.RefreshEditValue();

				if (baslik.Id != null && baslik.Id > 0)
				{
					var firstValue = tLBLNOGridLookUpEdit.Properties.GetKeyValue(0);
					tLBLNOGridLookUpEdit.EditValue = firstValue;
				}
			}

			sPFBASBindingSource.CurrencyManager.Refresh();
		}

		private void GetDovizKur(DateTime date)
		{
			bool alis = global.Sira == 1;

			var baslik = (SPFBAS)sPFBASBindingSource.Current;

			List<string> dvcnkdList = new List<string> { "USD", "EUR" };
			dovkurList = new List<DOVKUR>();
			foreach (var dovkod in dvcnkdList)
			{
				var response = _dovkurService.Cch_GetByDate_NLog(dovkod, date);
				if (response.Status == ResponseStatusEnum.OK && response.Nesne != null)
				{
					var doviz = response.Nesne;
					double? dovizFiyat = alis ? doviz.DVFYT1 : doviz.DVFYT2;

					dovkurList.Add(doviz);
					if (dovkod == "USD") baslik.USDFYT = Convert.ToDecimal(dovizFiyat);
					else if (dovkod == "EUR") baslik.EURFYT = Convert.ToDecimal(dovizFiyat);
				}
				else
				{
					if (baslik == null) return;
					DOVKUR dovkur = new DOVKUR { DVCNKD = dovkod, DOVTRH = date };
					dovkur = _dovkurService.GetDovizKuru(dovkur);
					double? dovizFiyat = alis ? dovkur.DVFYT1 : dovkur.DVFYT2;

					if (dovkur != null && dovizFiyat > 0)
					{
						dovkur.DOVTRH = date;
						_dovkurService.Ncch_AutoAdd_NLog(dovkur, global);
					}

					if (dovkod == "USD") baslik.USDFYT = dovkur != null ? Convert.ToDecimal(dovizFiyat) : 0;
					else if (dovkod == "EUR") baslik.EURFYT = dovkur != null ? Convert.ToDecimal(dovizFiyat) : 0;
				}
			}
		}

		private void gridLkeFiyatNo0_EditValueChanged(object sender, EventArgs e)
		{
			if (global.Sira == 1) return;

			GridLookUpEdit lookup = sender as GridLookUpEdit;
			STKFYT stkfyt = lookup.GetSelectedDataRow() as STKFYT;

			if (stkfyt != null)
			{
				SPFBAS spfbas = (SPFBAS)sPFBASBindingSource.Current;
				spfbas.STFYNO = Convert.ToInt32(stkfyt.STFYNO);
				spfbas.DVCNKD = stkfyt.DVCNKD;
			}

			SPFBAS talepBaslik = tLBLNOGridLookUpEdit.GetSelectedDataRow() as SPFBAS;
			if (talepBaslik != null)
			{
				RefreshTalepKalem(talepBaslik.BELGEN);
			}

			sPFBASBindingSource.CurrencyManager.Refresh();
		}

		private void gridLkeFisTipTab1_EditValueChanged(object sender, EventArgs e)
		{
			SPFTIP spftip = gridLkeFisTipTab1.GetSelectedDataRow() as SPFTIP;

			if (spftip == null)
			{
				sPORKDGridLookUpEdit.EditValue = null;
				sPDGKDGridLookUpEdit.EditValue = null;
			}
			else
			{
				sPORKDGridLookUpEdit.EditValue = spftip.SPORKD;
				sPDGKDGridLookUpEdit.EditValue = spftip.SPDGKD;
			}
		}

		private void bELTRHDateEdit_EditValueChanged(object sender, EventArgs e)
		{
			if (_action == "insert")
			{
				if (bELTRHDateEdit.EditValue != null)
				{
					if (bELTRHDateEdit.DateTime > DateTime.Today) GetDovizKur(DateTime.Today);
					else GetDovizKur(bELTRHDateEdit.DateTime);
				}
			}
		}

		private void txtUsd_TextChanged(object sender, EventArgs e)
		{
			if (loadingGrid) return;

			TextEdit textEdit = sender as TextEdit;

			var baslik = (SPFBAS)sPFBASBindingSource.Current;
			if (baslik == null) return;

			decimal fiyat = 0;
			decimal.TryParse(textEdit.Text, out fiyat);
			if (textEdit.Name == "txtUsd") baslik.USDFYT = fiyat;
			else if (textEdit.Name == "txtEur") baslik.EURFYT = fiyat;

			sPFBASBindingSource.CurrencyManager.Refresh();

			OpsiyonFiyatHesapla();
		}

		private void btnEmail_Click(object sender, EventArgs e)
		{
			var baslik = sPFBASBindingSource.Current as SPFBAS;
			var emailList = _crcariService.Ncch_GetCariEmails_NLog(baslik.CRKODU, global, false).Items;

			FrmEposta fEposta = new FrmEposta(emailList);
			fEposta.ShowDialog();

			if (fEposta.emailModel != null) SendMail(fEposta.emailModel);
		}

		private void SendMail(CariEmailModel emailModel)
		{
			try
			{
				string satici = emailModel.ADSYAD;
				string saticiEmail = emailModel.GNMAIL;
				if (saticiEmail == null || saticiEmail.ToString() == "")
				{
					MessageBox.Show("Mail adresi bulunamadı: " + satici, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
					return;
				}

				string startHTML = "<html><head><meta http-equiv=\"Content-Type\" content = \"text/html charset=UTF-8\" /></head><body><br><br>";
				string endHTML = "</body></html>";
				string teklifHTML = DataTableToHTML("ÜRÜNLER / HİZMETLER");
				//string imzaHTML = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + "imza\\imza.html", System.Text.Encoding.Default);
				//string mailHTML = startHTML + teklifHTML + imzaHTML + endHTML;
				string mailHTML = startHTML + teklifHTML + endHTML;
				List<string> lstAllRecipients = new List<string>();
				lstAllRecipients.Add(saticiEmail.ToString());

				Invoke((MethodInvoker)delegate
				{
					OpenOutlook(lstAllRecipients, mailHTML);
				});

			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());
			}
		}

		private void OpenOutlook(List<string> lstAllRecipients, string html)
		{
			bool success = false;
			Outlook.Application outlookApp = null;
			const int ERROR_HRESULT_0x800401E3_MK_E_UNAVAILABLE = -2147221021;

			int procCount = 1;
			//Process[] processList = Process.GetProcessesByName("OUTLOOK");
			//foreach (Process process in processList) procCount++;
			if (procCount > 0)
			{
				try
				{
					outlookApp = Marshal.GetActiveObject("Outlook.Application") as Outlook.Application;
				}
				catch (Exception e)
				{
					outlookApp = new Outlook.Application();
				}

				try
				{
					outlookApp.ItemSend += OutlookApp_ItemSend;
					Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
					Outlook.Inspector oInspector = oMailItem.GetInspector;
					Thread.Sleep(1000);

					// Alıcı
					Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
					foreach (String recipient in lstAllRecipients)
					{
						Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
						oRecip.Resolve();
					}

					// CC
					//Outlook.Recipient oCCRecip = oRecips.Add("ilkaygumus@gmail.com");
					//oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
					//oCCRecip.Resolve();

					oMailItem.Subject = "";
					oMailItem.BodyFormat = Outlook.OlBodyFormat.olFormatHTML;
					oMailItem.HTMLBody = html;

					//WindowState = FormWindowState.Minimized;

					oMailItem.Display(false);
				}
				catch (Exception objEx)
				{
					MessageBox.Show(objEx.ToString(), "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);
				}
				finally
				{
					//outlookApp.Quit();
					Invoke((MethodInvoker)delegate
					{
						WindowState = FormWindowState.Normal;
						//if (success) Close();
					});
				}
			}
		}

		private void OutlookApp_ItemSend(object Item, ref bool Cancel)
		{
			_mailSent = false;
			MessageBox.Show("E-posta gönderildi.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);

		}

		private string DataTableToHTML(string title)
		{
			try
			{
				var kalemList = sPFHARBindingSource.List as List<SPFHAR>;
				List<SaSiparisEpostaModel> epostaModelList = new List<SaSiparisEpostaModel>();

				for (int i = 0; i < kalemList.Count; i++)
				{
					SPFHAR spfhar = kalemList[i];
					epostaModelList.Add(new SaSiparisEpostaModel
					{
						SiraNo = i + 1,
						StokKodu = spfhar.STKODU,
						StokAdi = spfhar.STKNAM,
						Miktar = spfhar.GRMKTR,
						Birim = spfhar.GROLBR
					});
				}

				DataTable table = Bps.Core.Utilities.Converters.Convert.ListToDataTable(epostaModelList);

				string messageBody = "";
				//messageBody = "<h5 style=\"font-family: verdana; font-size: 14pt; color:#6FA1D2; text-align: left;\">" + title + "</h5>";
				int rowC = table.Rows.Count;
				int columnC = table.Columns.Count;
				if (kalemList.Count == 0) return messageBody;

				string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
				string htmlTableEnd = "</table>";
				string htmlHeaderRowStart = "<tr style=\"background-color:#6FA1D2; color:#ffffff;\">";
				string htmlHeaderRowEnd = "</tr>";
				string htmlTrStart = "<tr style=\"color:#555555;\">";
				string htmlTrEnd = "</tr>";
				string htmlTdStart = "<td style=\" font-family: calibri; border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
				string htmlTdStartLeftAligned = "<td style=\" font-family: calibri; border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px; text-align: left;\">";
				string htmlTdStartMerge = "<td colspan=\"" + columnC.ToString() + "\" style=\" font-family: calibri; font-size: 14pt; border-color:#5c87b2; border-style:solid; border-width:thin; padding: 5px;\">";
				string htmlTdEnd = "</td>";

				messageBody += htmlTableStart;
				messageBody += htmlHeaderRowStart;
				messageBody += htmlTdStartMerge + title + htmlTdEnd + htmlHeaderRowEnd; //ilk boş satır + tablo başlığı;

				messageBody += htmlHeaderRowStart;
				foreach (DataColumn col in table.Columns)
				{
					string colName = col.ColumnName;
					if (colName == "SiraNo") colName = "Sıra No";
					else if (colName == "StokKodu") colName = "Stok Kodu";
					else if (colName == "StokAdi") colName = "Stok Adı";

					messageBody += htmlTdStart + colName + htmlTdEnd;
				}
				messageBody += htmlHeaderRowEnd;

				for (int i = 0; i <= table.Rows.Count - 1; i++)
				{
					messageBody = messageBody + htmlTrStart;
					foreach (DataColumn col in table.Columns)
					{
						object val = table.Rows[i][col.ColumnName].ToString();

						if (col.Ordinal == 2) messageBody = messageBody + htmlTdStartLeftAligned + val.ToString() + htmlTdEnd;
						else messageBody = messageBody + htmlTdStart + val.ToString() + htmlTdEnd;
					}
					messageBody = messageBody + htmlTrEnd;
				}
				messageBody = messageBody + htmlTableEnd + "<br><br>";
				return messageBody;
			}
			catch (Exception ex)
			{
				return null;
			}
		}

		private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
		{
			var baslik = (SPFBAS)sPFBASBindingSource.Current;
		}

		private void btnOdemeTablosu_Click(object sender, EventArgs e)
		{
			var baslik = (SPFBAS)sPFBASBindingSource.Current;

			if (baslik != null && baslik.Id > 0)
			{
				double toplamTutar = baslik.TOPKDT ?? 0;
				if (baslik.DVCNKD == "EUR") toplamTutar *= Convert.ToDouble(baslik.EURFYT.Value);
				if (baslik.DVCNKD == "USD") toplamTutar *= Convert.ToDouble(baslik.USDFYT.Value);

				FrmOdemeTablosu oForm = new FrmOdemeTablosu();
				oForm.spfbas = baslik;
				oForm.tutar = toplamTutar;
				oForm.global = global;
				oForm.ShowDialog();
			}
		}

		private void btnAnlasmaKosullari_Click(object sender, EventArgs e)
		{
			var baslik = (SPFBAS)sPFBASBindingSource.Current;

			if (baslik != null && baslik.Id > 0)
			{
				TipHareketListModel tiphr = gridLkEdLanguage.GetSelectedDataRow() as TipHareketListModel;

				FrmAnlasmaKosul oForm = new FrmAnlasmaKosul();
				oForm.belgeNo = baslik.BELGEN;
				oForm.langkd = tiphr.HARKOD;
				oForm.global = global;
				oForm.ShowDialog();
			}
		}

		private void barButSiparisKapat_ItemClick(object sender, ItemClickEventArgs e)
		{
			DialogResult Mesaj = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			if (Mesaj == DialogResult.Yes)
			{
				var index = gridView1.GetFocusedDataSourceRowIndex();
				var baslik = sPFBASBindingSource[index] as SPFBAS;

				baslik.FLGKPN = true;
				_spfbasDal.Update(baslik);

				int topRow = gridView1.TopRowIndex;
				int focusedRow = gridView1.FocusedRowHandle;

				LoadGrid();

				gridView1.TopRowIndex = topRow;
				gridView1.FocusedRowHandle = focusedRow;
			}
		}

		protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
		{
			gridView1.OptionsView.ShowAutoFilterRow = gridView1.OptionsView.ShowAutoFilterRow == false;
		}

		private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			popContext.ShowPopup(MousePosition);

			return;
			var index = gridView1.GetFocusedDataSourceRowIndex();
			if (index < 0) return;

			var baslik = sPFBASBindingSource[index] as SPFBAS;

			if (baslik.FLGKPN == null || !baslik.FLGKPN.Value) popContext.ShowPopup(MousePosition);
		}

		private void grdViewSipKalem_ShownEditor(object sender, EventArgs e)
		{
            GridView view = sender as GridView;
            string col = view.FocusedColumn.FieldName;

            if (col == "GRMKTR" || col == "GFIYAT" || col == "VRGORN" || col == "GISKNT")
            {
                if (view.FocusedValue == null || Convert.ToDecimal(view.FocusedValue) == 0) view.ActiveEditor.Text = "";
                else
                {
                    var edit = ((DevExpress.XtraEditors.TextEdit)((GridView)sender).ActiveEditor);
                    BeginInvoke(new MethodInvoker(() =>
                    {
                        edit.SelectionStart = 0;
                        edit.SelectionLength = edit.Text.Length;
                    }));
                }
            }
        }

		private string GetUlkeSehirIlce(CRADRS cradrs)
		{
			string ulke = "";
			string sehir = "";
			string ilce = "";

			var country = _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, "001", cradrs.ULKEKD).Nesne;
			if (country != null) ulke = country.TANIMI;

			var city = _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, "002", cradrs.SEHRKD).Nesne;
			if (city != null) sehir = city.TANIMI;

			var district = _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, "003", cradrs.ILCEKD).Nesne;
			if (district != null) ilce = district.TANIMI;

			string sonuc = "";
			if (ilce != "") sonuc += ilce;
			if (sehir != "") sonuc = sonuc + " / " + sehir;
			if (ulke != "") sonuc = sonuc + " / " + ulke;

			return sonuc;
		}

		private void btnPdf2_Click(object sender, EventArgs e)
		{
			string docLang = gridLkEdLanguage.EditValue.ToString();

			SIRKET sirket = _sirketService.Ncch_GetById_NLog(1, global, false).Nesne;

			List<SPFHAR> urunList = sPFHARBindingSource.List as List<SPFHAR>;
			SPFBAS spfbas = sPFBASBindingSource.Current as SPFBAS;

			var cariKod = gridLke1Cari1.EditValue.ToString();

			var selectedRow = (CRCARI)gridLke1Cari1.GetSelectedDataRow();
			if (selectedRow == null) return;

			var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;
			var faturaAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.FTADNO);
			var teslimatAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.SVADNO);
			var yetkililer = _crytklService.Cch_GetListByCariKod_NLog(cariKod, global, false).Items;

			CRYTKL crytkl = null;
			if (yetkililer.Count > 0) crytkl = yetkililer[0];

			GNKULL satisPersoneli = _gnkullService.Cch_GetByUserKod_NLog(spfbas.EKKULL, global).Nesne;

			string currency = "";
			CultureInfo cultureInfo = GetCultureInfo(spfbas.DVCNKD, out currency);
			decimal toplamFiyat = 0;
			repSiparis2 rSiparis = new repSiparis2(docLang, spfbas.DVCNKD);
			rSiparis.ApplyLocalization(cultureInfo);

			rSiparis.lblBirimFiyat.TextFormatString = "{0:n2} " + spfbas.DVCNKD;
			rSiparis.lblToplamFiyat.TextFormatString = "{0:n2} " + spfbas.DVCNKD;

			List<SiparisUrunModel> lst = new List<SiparisUrunModel>();
			foreach (var spfhar in urunList)
			{
				string stokKodu = spfhar.STKODU;
				string stokAdi = spfhar.STKNAM;
				string olcukd = spfhar.GROLBR;
				toplamFiyat += spfhar.GFIYAT.Value;
				if (docLang != "tr-TR")
				{
					STNAME stname = _stnameService.Cch_GetByStokKoduLangkd_NLog(global, stokKodu, "en-GB", false)
						.Nesne;
					if (stname != null) stokAdi = stname.STKNAM;
					if (olcukd == "ADT") olcukd = "PC(S)";
				}

				if (!string.IsNullOrEmpty(stokKodu))
				{
					lst.Add(new SiparisUrunModel { STKODU = stokKodu, STKNAM = stokAdi, GNMKTR = spfhar.GRMKTR, OLCUKD = olcukd, GFIYAT = spfhar.GFIYAT, GNTUTR = spfhar.GNTUTR });
				}
			}

			List<decimal?> vergiOranlari = urunList.Select(s => s.VRGORN).Distinct().ToList();

			rSiparis.lblBaslik.Text = "SATINALMA FORMU";
			rSiparis.lblTeklif.Text = "BELGE";
			rSiparis.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
			rSiparis.lblSiparisNo.Text = spfbas.BELGEN;

			string musteriBilgileri = (docLang == "tr-TR" ? "" : "To: ") + "<b>" + selectedRow.CRUNV1 + "</b><br><br>" +
									  (docLang == "tr-TR" ? "Yetkili Kişi: " : "Contact Person: ") + "<b>" +
									  (crytkl != null ? crytkl.YETADI + " " + crytkl.YETSOY : "") + "</b><br>" +
									  (docLang == "tr-TR" ? "İletişim No: " : "Contact Number: ") + "<b>" + (crytkl != null ? crytkl.CEPTEL : "") + "</b><br>" +
									  (docLang == "tr-TR" ? "E-posta: " : "E-mail: ") + "<b>" + (crytkl != null ? crytkl.GNMAIL : "") + "</b><br>" +
									  (docLang == "tr-TR" ? "Fatura Adresi: " : "Billing Address: ") + "<b>" + (faturaAdres != null ? faturaAdres.ADRESS + " " + GetUlkeSehirIlce(faturaAdres) : "") + "</b>";

			rSiparis.richTextMusteri.Html = "<p style=\"font-family: Noir Pro; font-size: 9.71px\">" + musteriBilgileri + "</p>";

			string siparisInfo = (docLang == "tr-TR" ? "Belge Tarihi: " : "Offer Date: ") + "<b>" + spfbas.BELTRH.ToShortDateString() + "</b><br><br>" +
								 (docLang == "tr-TR" ? "Teslim Tarihi: " : "Delivery Date: ") + "<b>" + spfbas.TERTAR?.ToShortDateString() + "</b><br><br>" +
								 //(docLang == "tr-TR" ? "Geçerlilik Tarihi: " : "Latest Date of Validity: ") + "<b>" + spfbas.GCRTRH.Value.ToShortDateString() + "</b><br><br>" +
								 (docLang == "tr-TR" ? "Satınalma Personeli: " : "Contact Person: ") + "<b>" + (satisPersoneli != null ? (satisPersoneli.GNNAME + " " + satisPersoneli.GNSNAM) : "") + "</b><br><br>" +
								 (docLang == "tr-TR" ? "İletişim No: " : "Contact Person Phone: ") + "<b>" + (satisPersoneli != null ? satisPersoneli.GNTELF : "") + "</b><br><br>" +
								 (docLang == "tr-TR" ? "E-posta: " : "E-mail: ") + "<b>" + (satisPersoneli != null ? satisPersoneli.GNMAIL : "") + "</b><br><br>" +
								 (docLang == "tr-TR" ? "Fabrika Adresi: <b>" + sirket.ADRESS + "</b>" : "Factory Address: <b>" + sirket.ADRESS + "</b>") + "<br>";

			rSiparis.richTextSiparisInfo.Html = "<p style=\"font-family: Noir Pro; font-size: 12.53px\">" + siparisInfo + "</p>";

			rSiparis.bindingSource1.DataSource = lst;

			repSiparis2LastPage rSip = new repSiparis2LastPage(docLang, spfbas.DVCNKD);
			rSip.ApplyLocalization(cultureInfo);
			rSip.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
			rSip.PrintingSystem.ContinuousPageNumbering = true;

			rSip.lblCompanyInfo.Text = rSiparis.lblCompanyInfo.Text = sirket.GNNAME + "\r\n" + sirket.ADRESS + "\r\n" +
			"Telefon: " + sirket.ISYTEL + "\r\n" + "E-posta: " + sirket.EPOSTA + "\r\n" + sirket.WEBSIT;

			double iskonto = spfbas.TOPISK ?? 0;
			double kdv = spfbas.TOPKDV ?? 0;
			double tevkifat = spfbas.TEVKIF == null ? 0 : ((double)spfbas.TEVKIF / 100 * kdv);
			decimal navlun = spfbas.NAVMAS ?? 0;
			decimal diger = spfbas.DIGMAS ?? 0;

			rSip.lblBaslik.Text = "SATINALMA FORMU";
			rSip.lblGenelToplam.Text = spfbas.TOPBRT.Value.ToString("n2");
			rSip.lblIskonto.Text = iskonto.ToString("n2");
			if (vergiOranlari.Count == 1 && vergiOranlari[0] > 0) rSip.lblKdv1.Text = "TOPLAM KDV (%" + vergiOranlari[0].ToInt32().ToString() + "):";
			rSip.lblKdv.Text = kdv.ToString("n2");
			rSip.lblAraToplam.Text = (spfbas.TOPBRT.Value - iskonto).ToString("n2");
			rSip.lblNetTutar.Text = (spfbas.TOPKDT.Value + Convert.ToDouble((navlun + diger))).ToString("n2");
			rSip.lblOdenecekTutar.Text = (spfbas.TOPKDT.Value + Convert.ToDouble((navlun + diger)) - tevkifat).ToString("n2");
			rSip.lblGenelToplam2.Text = spfbas.DVCNKD;
			rSip.lblIskonto2.Text = spfbas.DVCNKD;
			rSip.lblAraToplam2.Text = spfbas.DVCNKD;
			rSip.lblKdv2.Text = spfbas.DVCNKD;
			rSip.lblNetTutar2.Text = spfbas.DVCNKD;
			rSip.lblOdenecekTutar2.Text = spfbas.DVCNKD;
			rSip.lblNavlunUcretleri.Text = navlun.ToString("n2");
			rSip.lblNavlunUcretleri2.Text = spfbas.DVCNKD;
			rSip.lblDigerUcretler.Text = diger.ToString("n2");
			rSip.lblDigerUcretler2.Text = spfbas.DVCNKD;
			rSip.lblOdemeTablosu.Visible = false;
			rSip.lblOdemeSekli.Visible = false;
			rSip.lblOdemeTarihi.Visible = false;
			rSip.lblTutar.Visible = false;
			rSip.lblDovizCinsi.Visible = false;
			rSip.xrLabel4.Visible = false;
			rSip.xrLabel6.Visible = false;
			rSip.xrLabel1.Visible = false;
			rSip.xrLabel12.Visible = false;
			rSip.xrPanel1.Visible = false;
			rSip.lblTeklifVeren.Visible = false;
			rSip.lblMusteriOnay.Visible = false;
			rSip.lblSignature1.Visible = false;
			rSip.lblSignature2.Visible = false;
			rSip.xrLine1.Visible = false;
			rSip.xrLine2.Visible = false;

			if (spfbas.TEVKIF == null || spfbas.TEVKIF.Value == 0)
			{
				rSip.lblTevkifat.Text = null;
				rSip.lblTevkifat1.Text = null;
				rSip.lblTevkifat2.Text = null;
			}
			else
			{
				rSip.lblTevkifat1.Text = "KDV TEVKİFAT (%" + spfbas.TEVKIF.ToString() + "):";
				rSip.lblTevkifat.Text = tevkifat.ToString("n2");
				rSip.lblTevkifat2.Text = spfbas.DVCNKD;
			}

			if (spfbas.DVCNKD == "TRY")
			{
				rSip.lblOdenecekTutarTL.Text = null;
				rSip.lblOdenecekTutarTL1.Text = null;
				rSip.lblOdenecekTutarTL2.Text = null;
			}

			rSip.CreateDocument();

			rSiparis.CreateDocument();
			rSiparis.Pages.AddRange(rSip.Pages);
			rSiparis.ShowPreview();
		}

		private void barButStokYenile_ItemClick(object sender, ItemClickEventArgs e)
		{
			GetStokMiktarRapor();
		}

		private void grdViewSipKalem_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
		{
			popKalem.ShowPopup(MousePosition);
		}

		private void grdViewSipKalem_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
		{
            if (e.RowHandle < 0) return;

            string c = e.Column.FieldName;

            if (c == "PARTIN" && e.Column.Visible)
            {
                GridView view = sender as GridView;

                var partiControl = view.GetRowCellValue(e.RowHandle, "PARTIT");

                if (partiControl != null && Convert.ToBoolean(partiControl) &&
                    (e.CellValue == null || e.CellValue.ToString() == ""))
                {
                    e.DefaultDraw();
                    e.Cache.DrawImage(imgRequired, e.Bounds.Location);
                    //e.Appearance.BackColor = Color.MistyRose;
                }
            }
        }

		private void barButRezervasyon_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
			var baslik = (SPFBAS)sPFBASBindingSource.Current;

			FrmSiparisRezervasyon frmSiparisRezervasyon = new FrmSiparisRezervasyon(global, baslik);
			frmSiparisRezervasyon.ShowDialog();
		}

		private void btnPaketEtiketYazdir_Click(object sender, EventArgs e)
		{
			var baslik = (SPFBAS)sPFBASBindingSource.Current;
			var spfhars = sPFHARBindingSource.List;

			repPaketEtiket rEtiket = new repPaketEtiket();
			rEtiket.CreateDocument();
			rEtiket.Pages.Clear();

			foreach (var bind in spfhars)
			{
				SPFHAR spfhar = (SPFHAR)bind;
				List<UrunAgaciModulPaket> modulPaketList = uaModulPaketList.Where(u => u.MDKODU == spfhar.STKODU).ToList();

				foreach (UrunAgaciModulPaket uaModulPaket in modulPaketList)
				{
					for (int i = 0; i < spfhar.GNMKTR; i++)
					{
						repPaketEtiket etiket = PaketEtiketYazdir(uaModulPaket, baslik.GNACIK);
						if (etiket != null)
						{
							etiket.CreateDocument();
							rEtiket.Pages.AddRange(etiket.Pages);
						}

					}
				}
			}

			rEtiket.ShowRibbonPreviewDialog();
		}

		private repPaketEtiket PaketEtiketYazdir(UrunAgaciModulPaket uaModulPaket, string aciklama)
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
			paketEtiket.lblAciklama.Text = aciklama;

			//Aracıkan
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

			return paketEtiket;
			//paketEtiket.ShowRibbonPreviewDialog();
		}

		private void barButMalzIhtiyac_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle < 0) return;

			var baslik = (SPFBAS)sPFBASBindingSource.Current;

			if (baslik.FLGKPN != null && baslik.FLGKPN.Value)
			{
				MessageBox.Show("Sipariş kapalı!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			var urunList = _spfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;

			List<StkartMiktar> stkartMiktarList = new List<StkartMiktar>();

			foreach (SPFHAR spfhar in urunList)
			{
				string stokKodu = spfhar.STKODU;
				if (!string.IsNullOrEmpty(stokKodu))
				{
					STKART stokKart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;
					StkartMiktar stkartMiktar = stkartMiktarList.FirstOrDefault(s => s.stkart.STKODU == stokKodu);
					if (stkartMiktar == null) stkartMiktarList.Add(new StkartMiktar { stkart = stokKart, miktar = spfhar.KLNMKTR.ToInt32() });
					else stkartMiktar.miktar += spfhar.KLNMKTR.ToInt32();
				}
			}

			if (stkartMiktarList.Count > 0)
			{
				FrmMalzemeIhtiyac frmMalzemeIhtiyac = new FrmMalzemeIhtiyac(stkartMiktarList, global);
				frmMalzemeIhtiyac.Show();
			}
		}

		private void barButAcikSipMalzIhtiyac_ItemClick(object sender, ItemClickEventArgs e)
		{
			List<StkartMiktar> stkartMiktarList = new List<StkartMiktar>();

			List<SPFBAS> baslikList = sPFBASBindingSource.DataSource as List<SPFBAS>;
			foreach (SPFBAS baslik in baslikList)
			{
				if (baslik.FLGKPN != null && baslik.FLGKPN.Value) continue;

				var urunList = _spfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;
				foreach (SPFHAR spfhar in urunList)
				{
					string stokKodu = spfhar.STKODU;
					if (!string.IsNullOrEmpty(stokKodu))
					{
						STKART stokKart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;
						StkartMiktar stkartMiktar = stkartMiktarList.FirstOrDefault(s => s.stkart.STKODU == stokKodu);
						if (stkartMiktar == null) stkartMiktarList.Add(new StkartMiktar { stkart = stokKart, miktar = spfhar.KLNMKTR.ToInt32() });
						else stkartMiktar.miktar += spfhar.KLNMKTR.ToInt32();
					}
				}
			}

			if (stkartMiktarList.Count > 0)
			{
				FrmMalzemeIhtiyac frmMalzemeIhtiyac = new FrmMalzemeIhtiyac(stkartMiktarList, global);
				frmMalzemeIhtiyac.Show();
			}
		}

		private void barButIsemri_ItemClick(object sender, ItemClickEventArgs e)
		{
			DialogResult Secim;
			Secim = MessageBox.Show("Seçili siparişe bağlı tüm ürünler için işemri oluşturulacak. Emin misiniz?", "İşemri Oluştur", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Secim == DialogResult.Yes)
			{
				var baslik = (SPFBAS)sPFBASBindingSource.Current;

				var response = _xxService.Ncch_SiparisIsemriOlustur_Log(baslik.BELGEN, global, false);

				if (response.Status == ResponseStatusEnum.OK)
				{
					MessageBox.Show(response.Nesne + " no'lu plan ile işemri oluşturuldu!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
				else
				{
					MessageBox.Show(response.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

        private void gridLkeCikisDepo_EditValueChanged(object sender, EventArgs e)
        {
			GetStokMiktarRapor();

		}

        private void simpleButton1_Click(object sender, EventArgs e)
        {
			SIRKET sirket = _sirketService.Ncch_GetById_NLog((int)global.SirketId, global, false).Nesne;

			List<SPFHAR> urunList = sPFHARBindingSource.List as List<SPFHAR>;
			SPFBAS spfbas = sPFBASBindingSource.Current as SPFBAS;

			var cariKod = gridLke1Cari1.EditValue.ToString();

			var selectedRow = (CRCARI)gridLke1Cari1.GetSelectedDataRow();
			if (selectedRow == null) return;

			var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;
			var faturaAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.FTADNO);
			var teslimatAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.SVADNO);
			var yetkililer = _crytklService.Cch_GetListByCariKod_NLog(cariKod, global, false).Items;

			List<SiparisRaporModel> RaporList = new List<SiparisRaporModel>();
            foreach (var item in urunList)
            {
				SiparisRaporModel RaporModel = new SiparisRaporModel();
				RaporModel.Baslik = spfbas;
				RaporModel.Kalem = item;
				RaporModel.FaturaCari = selectedRow;
				RaporModel.FaturaYetKili = yetkililer.FirstOrDefault();
				RaporModel.SevkAdres = teslimatAdres;
				RaporModel.Varyant = _stbdrnService.Ncch_GetByStkoduByVaryant_NLog(item.STKODU, item.VRKODU, global, false).Nesne;
				RaporModel.UrunImageUrl = AppDomain.CurrentDomain.BaseDirectory + "images\\stok\\" + "01" + "\\" + item.STKODU + ".jpg";
				
				if (File.Exists(RaporModel.UrunImageUrl))
				{
					RaporModel.UrunImage = Image.FromFile(RaporModel.UrunImageUrl);
				}
					RaporList.Add(RaporModel);

			}
			SiparisReportcs rpr = new SiparisReportcs();
			rpr.bindingSource1.DataSource = RaporList;
			rpr.CreateDocument();
			rpr.ShowPreview();

		}
		protected override void barButShopifySip_ItemClick(object sender, ItemClickEventArgs e)
		{
			TempForm form = new TempForm(global);
			form.ShowDialog();
			CariKarts = _crcariService.Cch_GetList_NLog(global, false).Items;

			gridLke1Cari1.Properties.DataSource = CariKarts;
			gridLke1Cari2.Properties.DataSource = CariKarts;
			gridLke0Cari1.Properties.DataSource = CariKarts;
			gridLke0Cari2.Properties.DataSource = CariKarts;
			
			repLkeBaslikCari.DataSource = CariKarts;
			gridLke1Cari1.EditValue = form.crcari.CRKODU;
			gridLke1Cari2.EditValue = form.crcari.CRKODU;
			gridLke0Cari1.EditValue = form.crcari.CRKODU;
			gridLke0Cari2.EditValue = form.crcari.CRKODU;
            if (form.carkodu == "FY0000001")
            {
				gridLkeSatisDns.Text = "001";
				gridLkeFiyatNo1.EditValue = "4";
			}
			if (form.carkodu == "FY0000002")
			{
				gridLkeSatisDns.Text = "002";
				gridLkeFiyatNo1.EditValue = "5";
			}
			foreach (var shopify in form.products)
            {
				int i = 1; 
                foreach (var lineitem in shopify.LineItems)
                {
					SPFHAR siphar = new SPFHAR();
					siphar.SATIRN = i * 100;
					var stok =_stcrkdService.Ncch_GetByCRVRKO_NLog(lineitem.VariantId.ToString(), form.carkodu, global, false).Nesne;
                    if (stok ==null)
                    {
						siphar.GNACIK = lineitem.Name;
                    }
					else
                    {
						siphar.STKODU = stok.STKODU;
						STKART stkart = _stkartService.Ncch_GetByStKod_NLog(siphar.STKODU, global, false).Nesne;
						siphar.STKNAM = stkart.STKNAM;
						siphar.VRKODU = stok.VRKODU;
						siphar.GNACIK = lineitem.Name;
					}
					siphar.GNMKTR = lineitem.Quantity;
					siphar.GRMKTR = lineitem.Quantity;
					siphar.OLCUKD= "ADT";
					siphar.GROLBR = "ADT";
					siphar.GFIYAT = Convert.ToDecimal( lineitem.Price.Replace(".",","));
					siphar.STFYNO = (int)gridLkeFiyatNo1.EditValue;
					siphar.CKDEPO = gridLkeCikisDepo.EditValue.ToString();
					siphar.GNTUTR = siphar.GFIYAT* siphar.GRMKTR;
					siphar.ORDRID = shopify.Id.ToString();
					siphar.LINEID = lineitem.Id.ToString();
					sPFHARBindingSource.Add(siphar);
					i++;
                }

			}
			
		}
	}
	
}