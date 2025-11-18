using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using BPS.Windows.Forms.SP;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
	public partial class FrmSatisTeklif : BPS.Windows.Base.FrmChildBase
	{
		public string blgNo;
		public int fisTipi;

		private ISpfbasService _sinifService;
		private IGnkxmlService _sinifyerlesimService;

		private GNKXML _sinifyerlesim;

		private ProjeMenuListed yetkiModel;
		private static IList<SPFBAS> list;
		private static SPFBAS oldData;
		private string _action;
		private bool formLoaded = false;
		private bool loadingGrid = false;
		private List<TipHareketListModel> ulasimYoluList = new List<TipHareketListModel>();
		private List<TipHareketListModel> ulasimYoluListEn = new List<TipHareketListModel>();
		private List<TipHareketListModel> teslimSekliList = new List<TipHareketListModel>();

		private readonly IGnyetkService _gnyetkService;
		private readonly IGnthrkService _gnthrkService;
		private readonly IGnlkhrService _gnlkhrService;
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
		private readonly ISpodtbService _spodtbService;
		private readonly IStdepoService _stdepoService;
		private readonly ISthrktService _sthrktService;
		private readonly ISpkoslService _spkoslService;
		private readonly IStnameService _stnameService;
		private readonly IGnkoslService _gnkoslService;
		private readonly IXXService _xxService;
		private readonly IGntipiService _gntipiService;
		private readonly IGnkullService _gnkullService;
		private readonly ISirketService _sirketService;
		private readonly ISpkoslDal _spkoslDal;

		private List<Grid> focusedRowHandler = new List<Grid>();
		public List<CRCARI> CariKarts = new List<CRCARI>();
		private int _satirNo = 0;
		private List<Dictionary<int, List<UrunOpsiyonModel>>> opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();
		private List<DOVKUR> dovkurList = new List<DOVKUR>();
		private string _ulkeTipKod, _sehirTipKod, _ilceTipKod, _semtTipKod, _mahalleTipKod;
		private decimal toplamTutarOnceki = 0;

		public FrmSatisTeklif(ISpfbasService sinifService, IGnthrkService gnthrkService,
			ISpftipService spftipService, ICrcariService crcariService, ICradrsService cradrsService,
			IGndptnService gndptnService, IStkfytService stkfytService, IGnlkhrService gnlkhrService,
			IStkfiyService stkfiyService, IStkartService stkartService, IGnkoslService gnkoslService,
			IStolcuService stolcuService, ISpfharService spfharService, IStnameService stnameService,
			ISpuropService spuropService, IStdepoService stdepoService, ISthrktService sthrktService, ISirketService sirketService,
			IGnoptpService gnoptpService, IGnophrService gnophrService, ISpkoslService spkoslService, ISpkoslDal spkoslDal,
				ICrytklService crytklService, IXXService xxService, ISturopService sturopService, IGnkullService gnkullService,
			IGnyetkService gnyetkService, IGnkxmlService sinifyerlesimService, IDovkurService dovkurService, ISpodtbService spodtbService)
		{
			_gnthrkService = gnthrkService;
			_gnlkhrService = gnlkhrService;
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
			_stnameService = stnameService;
			_xxService = xxService;
			_sinifService = sinifService;
			_sinifyerlesimService = sinifyerlesimService;
			_gnyetkService = gnyetkService;
			_dovkurService = dovkurService;
			_spodtbService = spodtbService;
			_stdepoService = stdepoService;
			_sthrktService = sthrktService;
			_spkoslService = spkoslService;
			_gnkullService = gnkullService;
			_gnkoslService = gnkoslService;
			_sirketService = sirketService;
			_spkoslDal = spkoslDal;
			InitializeComponent();

			xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
			dtBaslangic.EditValue = DateTime.Today.AddDays(-5);
			dtBitis.EditValue = DateTime.Today.AddDays(5);
		}

		private void FrmSiparis_Load(object sender, EventArgs e)
		{
			xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
			yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
			FormIslemleri.FormYetki2(barManager, yetkiModel);

			_satirNo = 0;
			barManager.Bars["Tools"].Visible = false;

			GridHelper.ColumnRepositoryItems(gridView1, global);

			//List<STKART> stokList = _stkartService.Cch_GetListAktif_NLog(global, false).Items;

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

			var teknads = new List<string>() { "OLCUKD", "SPORKD", "SPDGKD", "DVCNKD", "TRMDKD", "TSSRKD", "LANGKD", "TKTRKD", "SPUTKD", "TKDRKD" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, yetkiKontrol: false).Items;

			var dagKanalList = teknadsResponse.Where(w => w.TEKNAD == "SPDGKD").ToList();
			var satOrgList = teknadsResponse.Where(w => w.TEKNAD == "SPORKD").ToList();
			var languageList = teknadsResponse.Where(w => w.TEKNAD == "LANGKD").ToList();
			var teklifTuruList = teknadsResponse.Where(w => w.TEKNAD == "TKTRKD").ToList();
			var urunTipiList = teknadsResponse.Where(w => w.TEKNAD == "SPUTKD").ToList();
			var durumList = teknadsResponse.Where(w => w.TEKNAD == "TKDRKD").ToList();
			ulasimYoluList = teknadsResponse.Where(w => w.TEKNAD == "TRMDKD").ToList();
			teslimSekliList = teknadsResponse.Where(w => w.TEKNAD == "TSSRKD").ToList();

			sPORKDGridLookUpEdit.Properties.DataSource = satOrgList;
			repLkedSporkd.DataSource = satOrgList;
			sPDGKDGridLookUpEdit.Properties.DataSource = dagKanalList;
			repLkedSpdgkd.DataSource = dagKanalList;
			gridLkeDgtKnl.Properties.DataSource = dagKanalList;
			gridLkeSatisOrg.Properties.DataSource = satOrgList;
			gridLkEdLanguage.Properties.DataSource = languageList;
			dVCNKDGridLookUpEdit.Properties.DataSource = repDovizCinsi.DataSource = teknadsResponse.Where(w => w.TEKNAD == "DVCNKD").ToList();
			grLkedUlasimYolu.Properties.DataSource = ulasimYoluList;
			grLkedTeslimSekli.Properties.DataSource = teslimSekliList;
			gridLkeTeklifTuru.Properties.DataSource = teklifTuruList;
			gridLkeUrunTipi.Properties.DataSource = urunTipiList;
			gridLkeDurum.Properties.DataSource = durumList;

			CariKarts = _crcariService.Cch_GetList_NLog(global, false).Items;

			gridLke1Cari1.Properties.DataSource = CariKarts;
			gridLke1Cari2.Properties.DataSource = CariKarts;

			repLkeBaslikCari.DataSource = CariKarts;

			List<SPFTIP> fisTipList = new List<SPFTIP>();
			var lst = _spftipService.Ncch_GetListBySphrtp_NLog(global, 4, yetkiKontrol: false).Items; //Yurtiçi
			fisTipList.AddRange(lst);
			lst = _spftipService.Ncch_GetListBySphrtp_NLog(global, 5, yetkiKontrol: false).Items; //Yurtiçi
			fisTipList.AddRange(lst);

			gridLkeFisTipTab1.Properties.DataSource = fisTipList;
			gridLkeFisTip1.Properties.DataSource = fisTipList;

			var depoList = _gndptnService.Cch_GetListAktif_NLog(global, false).Items;
			gridLkeCikisDepo.Properties.DataSource = depoList;

			#region Kalem

			GetStokMiktarRapor();
			//repSipKalemStokKod.DataSource = stokList;
			//repSipKalemFiyatNo.DataSource = fiyatNoList;
			repLkedOlcuBirimi.DataSource = teknadsResponse.Where(w => w.TEKNAD == "OLCUKD").ToList();
			repLkeDepo.DataSource = depoList;

			#endregion

			teknads = new List<string>() { "TRMDKD" };
			teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, dilKod: "en-GB", yetkiKontrol: false).Items;
			ulasimYoluListEn = teknadsResponse.Where(w => w.TEKNAD == "TRMDKD").ToList();

			grdViewSipKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
			grdViewSipKalem.OptionsNavigation.EnterMoveNextColumn = true;
			grdViewSipKalem.OptionsBehavior.Editable = true;
			grdViewSipKalem.OptionsBehavior.ReadOnly = false;

			GridHelper.ColumnRepositoryItems(grdViewSipKalem, global);
			GridHelper.ColumnRepositoryItems(gridViewVergilendirme, global);
			gridLkEdLanguage.EditValue = "tr-TR";

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

		private void GetStokMiktarRapor()
		{
			var stokMiktarList = _stdepoService.GetStokMiktarRapor(global).Items;

			if (stokMiktarList != null && stokMiktarList.Count > 0)
			{
				var stokMiktarByPartiList = _sthrktService.GetStokMiktarFromHareketByParti(global).Items;

				//SADECE MAMUL
				//stokMiktarList = stokMiktarList.Where(s => s.STMLTR == Param.MAMUL_KODU).ToList();
				//stokMiktarByPartiList = stokMiktarByPartiList.Where(s => s.STMLTR == Param.MAMUL_KODU).ToList();

				DataSet dataSet = new DataSet();
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
		}

		#region Standard

		protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
		{
			toplamTutarOnceki = 0;
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			_action = "insert";
			opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

			var fistip = Convert.ToInt32(gridLkeFisTipTab1.EditValue);

			var rowView = (SPFBAS)sPFBASBindingSource.AddNew();
			if (rowView != null)
			{
				rowView.ACTIVE = true;
				rowView.SPFTNO = fistip;
				rowView.BELTRH = DateTime.Today;
				rowView.GCRTRH = rowView.BELTRH.AddDays(5);
			}

			gridLke1Cari1.EditValue = null;
			gridLke1Cari2.EditValue = null;

			GetDovizKur(DateTime.Today);

			ClearCari1();
			ClearCari2();
			sPFHARBindingSource.DataSource = new List<SPFHAR>();
			xtraTabControl1.SelectedTabPage = xtraTabPage3;
			sPFBASBindingSource.CurrencyManager.Refresh();
		}

		protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			_action = "update";
			toplamTutarOnceki = 0;
			loadingGrid = true;

			var baslik = (SPFBAS)sPFBASBindingSource.Current;
			sPFHARBindingSource.DataSource = _spfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;

			var list = _spfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;
			var opList = _spuropService.Ncch_GetListByBelgeNo_NLog(baslik.BELGEN, global, false).Items;
			opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

			foreach (SPFHAR spfhar in list)
			{
				if (spfhar.GNTUTR.HasValue) toplamTutarOnceki += spfhar.GNTUTR.Value;

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

			xtraTabControl1.SelectedTabPage = xtraTabPage3;

			grdViewSipKalem.BestFitColumns();
			loadingGrid = false;
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

		protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
		{
			this.Validate();
			try
			{
				getVergi();
				getTutar();

				var response = new StandardResponse();
				sPFBASBindingSource.EndEdit();

				var model = new SiparisKayitModel();
				var baslik = (SPFBAS)sPFBASBindingSource.Current;
				SPFTIP spftip = gridLkeFisTipTab1.GetSelectedDataRow() as SPFTIP;
				baslik.SPHRTP = spftip.SPHRTP;
				model.Baslik = baslik;

				if (_action == "insert") model.Baslik.Id = 0;

				model.Baslik.SPORKD = sPORKDGridLookUpEdit.EditValue == null ? "" : sPORKDGridLookUpEdit.EditValue.ToString();
				model.Baslik.SPDGKD = sPDGKDGridLookUpEdit.EditValue == null ? "" : sPDGKDGridLookUpEdit.EditValue.ToString();
				model.Baslik.ACTIVE = true;
				model.Baslik.SLINDI = true;
				if (string.IsNullOrEmpty(model.Baslik.TKDRKD)) model.Baslik.TKDRKD = "01";

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

				LoadGrid();
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
				gridLke1Cari1.EditValue = null;
				gridLke1Cari2.EditValue = null;
				sPFBASBindingSource.CancelEdit();
				sPFHARBindingSource.CancelEdit();
				LoadGrid();
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
			}
		}
		protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
		{
			gridView1.OptionsBehavior.Editable = false;
			gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
			barManager.Bars["Tools"].Visible = false;
			xtraTabControl1.SelectedTabPage = xtraTabPage1;
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

			if (selectedRow != null && selectedRow.KDVFLG == null)
			{
				MessageBox.Show(selectedRow.TANIMI + " fiş tipi için KDV bakımı yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			//var fiyatNoList = _stkfytService.Cch_GetListByKdvFlag_NLog(selectedRow.KDVFLG.Value, global, false).Items;
			var fiyatNoList = _stkfytService.Cch_GetAll_NLog(global, false).Items;
			var satisFiyatNoList = fiyatNoList.Where(f => f.STHRTP == 1 && f.ACTIVE && !f.SLINDI).ToList();

			gridLkeFiyatNo1.Properties.DataSource = satisFiyatNoList;
			repLkeBaslikFiyatNo.DataSource = satisFiyatNoList;
			repSipKalemFiyatNo.DataSource = satisFiyatNoList;
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

		private void LoadGrid()
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

			list = _sinifService.Cch_GetListByParam_NLog(param, global, false).Items;
			sPFBASBindingSource.DataSource = list;

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
							}
				into slc
							select new SPFHAR()
							{
								KDVFLG = slc.Key.KDVFLG,
								VRGORN = slc.Key.VRGORN
							}).ToList();

			var vergilendirme = new List<SPFHAR>();
			foreach (var grpVKdv in grpVKdvs)
			{
				var ilgiliVeriler = harekets.Where(w => w.VRGORN == grpVKdv.VRGORN).ToList();

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
					GNTUTR = Math.Round(ttGtutar, 2),
					GFIYAT = Math.Round(ttGfiyat, 2),
					VRGTUT = Math.Round(ttKdvTutar, 2)
				});
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
			tOPBRTTextEdit.Properties.Mask.EditMask = Convert.ToSingle(currentBas.TOPBRT).ToString("N");

			tOPISKTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPISKTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPISKTextEdit.Properties.Mask.EditMask = Convert.ToSingle(currentBas.TOPISK).ToString("N");

			tOPKDVTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPKDVTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPKDVTextEdit.Properties.Mask.EditMask = Convert.ToSingle(currentBas.TOPKDV).ToString("N");

			tOPKDTTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPKDTTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPKDTTextEdit.Properties.Mask.EditMask = Convert.ToSingle(currentBas.TOPKDT).ToString("N");

			tOPOTVTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPOTVTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPOTVTextEdit.Properties.Mask.EditMask = Convert.ToSingle(currentBas.TOPOTV).ToString("N");

			tOPTUTTextEdit.Properties.Mask.UseMaskAsDisplayFormat = true;
			tOPTUTTextEdit.Properties.Mask.MaskType = MaskType.Numeric;
			tOPTUTTextEdit.Properties.Mask.EditMask = Convert.ToSingle(currentBas.TOPTUT).ToString("N");

			sPFBASBindingSource.CurrencyManager.Refresh();
		}

		private void Cari_EditValueChanged(object sender, EventArgs e)
		{
			if (loadingGrid) return;

			GridLookUpEdit lked = sender as GridLookUpEdit;
			if (lked == gridLke1Cari2) return;

			SPFBAS spfbas = (SPFBAS)sPFBASBindingSource.Current;

			gridLke1Cari2.EditValue = gridLke1Cari1.EditValue;

			if (spfbas != null)
			{
				string cari1 = gridLke1Cari1.EditValue == null ? "" : gridLke1Cari1.EditValue.ToString();
				string cari2 = gridLke1Cari2.EditValue == null ? "" : gridLke1Cari2.EditValue.ToString();
				spfbas.CRKODU = cari1 == "" ? null : cari1;
				spfbas.MALTES = cari2 == "" ? null : cari2;
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

				if (gridLkeFiyatNo1.EditValue != null)
				{


					data.STFYNO = baslik.STFYNO;

					var stkfyt = gridLkeFiyatNo1.GetSelectedDataRow() as STKFYT;
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

		private List<SPODTB> CheckOdemePlani()
		{
			SPFBAS spfbas = sPFBASBindingSource.Current as SPFBAS;

			var odemeList = _spodtbService.Ncch_GetListByBelgeNo_NLog(global, spfbas.BELGEN).Items;
			if (odemeList == null || odemeList.Count == 0)
			{
				MessageBox.Show("Ödeme planı oluşturmadan devam edemezsiniz!", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);

				btnOdemeTablosu_Click(this, EventArgs.Empty);

				odemeList = _spodtbService.Ncch_GetListByBelgeNo_NLog(global, spfbas.BELGEN).Items;
				if (odemeList == null || odemeList.Count == 0) return null;
			}

			return odemeList;
		}

		private void btnTeklif_Click(object sender, EventArgs e)
		{
			List<SPODTB> odemeList = new List<SPODTB>();

			if (Param.ADAPTATION == Adaptation.Bala)
			{
				odemeList = CheckOdemePlani();
				if (odemeList == null || odemeList.Count == 0) return;
			}

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

			decimal topTutar = 0;
			List<SPFHAR> opsiyonsuzUrunList = new List<SPFHAR>();
			foreach (var spfhar in urunList)
			{
				if (spfhar.GNTUTR.HasValue) topTutar += spfhar.GNTUTR.Value;

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
						repSip.lblTitle.Text = "TEKLİF FORMU";
						repSip.cellSipTarLabel.Text = "Teklif Tarihi: ";
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
			rSip.lblTitle.Text = "TEKLİF FORMU";
			rSip.cellSipTarLabel.Text = "Teklif Tarihi: ";
			rSip.cellBelgeNo.Text = spfbas.BELGEN;
			rSip.labelDate.Text = DateTime.Now.ToShortDateString();
			rSip.cellSiparisTarihi.Text = spfbas.BELTRH.ToShortDateString();
			rSip.cellTerminTarihi.Text = spfbas.TERTAR?.ToShortDateString();
			rSip.lblGenelToplam.Text = currency + spfbas.TOPBRT.Value.ToString("n2");
			rSip.lblIskonto.Text = currency + spfbas.TOPISK.Value.ToString("n2");
			rSip.lblKdv.Text = currency + spfbas.TOPKDV.Value.ToString("n2");
			rSip.lblAraToplam.Text = currency + (spfbas.TOPBRT.Value - spfbas.TOPISK.Value).ToString("n2");
			rSip.lblOdenecekTutar.Text = currency + (spfbas.TOPKDT.Value).ToString("n2");
			rSip.cellTeklifGecerlilikTarih.Text = spfbas.BELTRH.AddDays(5).ToShortDateString();
			rSip.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;

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
				rSip.PrintingSystem.ContinuousPageNumbering = true;
			}
			else if (opsiyonsuzUrunList.Count > 0)
			{
				List<SiparisUrunModel> lst = new List<SiparisUrunModel>();
				foreach (SPFHAR urn in opsiyonsuzUrunList)
				{
					lst.Add(new SiparisUrunModel { STKODU = urn.STKODU, STKNAM = urn.STKNAM, URNOPS = "", GNMKTR = urn.GRMKTR, OLCUKD = urn.GROLBR, GFIYAT = urn.GFIYAT, GNTUTR = urn.GNTUTR });
				}

				subRepUrun subReportUrun = new subRepUrun();
				subReportUrun.ApplyLocalization(cultureInfo);
				subReportUrun.Bands.Remove(subReportUrun.ReportHeader);
				subReportUrun.DataSource = lst;
				rSip.subReportUrunler.ReportSource = subReportUrun;
			}

			TipHareketListModel tiphr = gridLkEdLanguage.GetSelectedDataRow() as TipHareketListModel;
			var kosulList = GetSiparisKosulList(tiphr.HARKOD);
			string kosullar = "";

			if (kosulList.Count > 0)
			{
				htmlTdStart = "<td>";
				kosullar = htmlTableStart;

				foreach (SiparisKosulModel spKosul in kosulList)
				{
					string kosul = "- " + spKosul.KOSULL;
					if (kosul.Contains("NAKLİYE ALICIYA AİTTİR"))
						kosul = kosul.Replace("NAKLİYE ALICIYA AİTTİR.", "<b>NAKLİYE ALICIYA AİTTİR.</b>");
					if (kosul.Contains("{gun}"))
						kosul = kosul.Replace("{gun}", spfbas.GCRTRH.Value.Subtract(spfbas.BELTRH).Days.ToString());
					kosullar += htmlTrStart + htmlTdStart + kosul + htmlTdEnd + htmlTrEnd;
				}

				kosullar = kosullar + htmlTableEnd;
				kosullar = "<p style=\"font-family: Calibri; font-size: 12px\">" + kosullar + "</p>";
			}

			subRepAnlasmaKosullari subRepAn = new subRepAnlasmaKosullari();
			subRepAn.ApplyLocalization(cultureInfo);
			subRepAn.richTextAnlasmaKosullari.Html = kosullar;

			subRepOdemeTablosu subRepOd = null;

			if (odemeList != null && odemeList.Count > 0)
			{
				subRepOd = new subRepOdemeTablosu();
				subRepOd.ApplyLocalization(cultureInfo);
				subRepOd.bindingSource1.DataSource = odemeList;
				subRepOd.CreateDocument();
			}
			else
			{

			}

			repBlankPage repBlnkPage = null;
			if (opsiyonsuzUrunList.Count == 0)
			{
				rSip.subRepAnlasmaKos.ReportSource = subRepAn;
				if (subRepOd != null) rSip.subRepOdemeTablosu.ReportSource = subRepOd;
				else rSip.subRepOdemeTablosu.ReportSource = null;
			}
			else
			{
				rSip.subRepAnlasmaKos.ReportSource = null;
				rSip.subRepOdemeTablosu.ReportSource = null;

				rSip.xrLabel1.Visible = false;
				rSip.xrLabel3.Visible = false;
				rSip.xrLabel4.Visible = false;
				rSip.xrLabel5.Visible = false;
				rSip.xrTable1.Visible = false;

				repBlnkPage = new repBlankPage();
				repBlnkPage.ApplyLocalization(cultureInfo);
				repBlnkPage.lblTitle.Text = "TEKLİF FORMU";
				repBlnkPage.cellSipTarLabel.Text = "Teklif Tarihi: ";
				repBlnkPage.subRepAnlasmaKos.ReportSource = subRepAn;
				repBlnkPage.cellBelgeNo.Text = spfbas.BELGEN;
				repBlnkPage.labelDate.Text = DateTime.Now.ToShortDateString();
				repBlnkPage.cellSiparisTarihi.Text = spfbas.BELTRH.ToShortDateString();
				repBlnkPage.cellTerminTarihi.Text = spfbas.TERTAR?.ToShortDateString();

				if (subRepOd != null) repBlnkPage.subRepOdemeTablosu.ReportSource = subRepOd;
				else repBlnkPage.subRepOdemeTablosu.ReportSource = null;
				rSip.richTextBankaBilgileri.Text = null;

				repBlnkPage.CreateDocument();
			}

			if (rSiparis == null)
			{
				rSip.CreateDocument();

				if (repBlnkPage != null)
				{
					rSip.Pages.AddRange(repBlnkPage.Pages);
				}

				rSip.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
				rSip.ShowPreview();
			}
			else
			{
				rSip.CreateDocument();
				rSiparis.Pages.AddRange(rSip.Pages);
				if (repBlnkPage != null)
				{
					rSiparis.Pages.AddRange(repBlnkPage.Pages);
				}
				rSiparis.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
				rSiparis.ShowPreview();
			}
		}

		private string HtmlTdStartOptionalCss(string optionalCss)
		{

			return "<td style=\" border-color:#000000; border-style:solid; border-width:1px; padding: 3px; " + optionalCss + " \">";
		}

		private string SetReportCulture(string currency, XtraReport report, out CultureInfo culture)
		{
			string cur = "";
			culture = new CultureInfo("tr-TR");
			if (currency == "TRY")
			{
				cur = " ₺";
				report.ApplyLocalization(culture);
			}

			if (currency == "EUR")
			{
				culture = new CultureInfo("de-DE");
				cur = " €";
				report.ApplyLocalization(culture);
			}

			if (currency == "USD")
			{
				culture = new CultureInfo("en-US");
				cur = " $";
				report.ApplyLocalization(new CultureInfo("en-US"));
			}

			return cur;
		}

		private void btnProforma_Click(object sender, EventArgs e)
		{
			List<SPFHAR> urunList = sPFHARBindingSource.List as List<SPFHAR>;
			SPFBAS spfbas = sPFBASBindingSource.Current as SPFBAS;

			var cariKod = gridLke1Cari1.EditValue.ToString();

			var billCari = (CRCARI)gridLke1Cari1.GetSelectedDataRow();
			if (billCari == null) return;

			var shipCari = (CRCARI)gridLke1Cari2.GetSelectedDataRow();
			if (shipCari == null) shipCari = billCari;

			var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;
			var faturaAdres = adresler.FirstOrDefault(f => f.Id == billCari.FTADNO);
			var sevkAdres = adresler.FirstOrDefault(f => f.Id == billCari.SVADNO);

			string billAddress = billCari.CRUNV1 + Environment.NewLine;

			if (faturaAdres != null)
			{
				billAddress += faturaAdres != null ? "Address: " + faturaAdres.ADRESS + Environment.NewLine : "";
				billAddress += faturaAdres.ISYTEL != "" ? "Phone: " + faturaAdres.ISYTEL : "";
			}

			string destinationCountry = "";
			string shipAddress = shipCari.CRUNV1 + Environment.NewLine;
			if (sevkAdres != null)
			{
				shipAddress += sevkAdres != null ? "Address: " + sevkAdres.ADRESS + Environment.NewLine : "";
				shipAddress += sevkAdres.ISYTEL != "" ? "Phone: " + sevkAdres.ISYTEL : "";

				var country = _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, "001", sevkAdres.ULKEKD).Nesne;
				if (country != null) destinationCountry = country.TANIMI;
			}

			repProforma2 rProforma = null;
			repProforma2 repProforma = new repProforma2();
			repProforma.cellInvoiceNo.Text = spfbas.BELGEN;
			repProforma.cellInvoiceDate.Text = spfbas.BELTRH.ToShortDateString();
			repProforma.cellOrderNo.Text = spfbas.BELGEN;
			repProforma.cellBillAddress.Text = billAddress;
			repProforma.cellShipAddress.Text = shipAddress;
			repProforma.cellTeslimTarihi.Text = spfbas.TERTAR?.ToShortDateString();
			repProforma.cellUlasimYolu.Text = ulasimYoluListEn == null ? "" : ulasimYoluListEn.FirstOrDefault(u => u.HARKOD == spfbas.TRMDKD).TANIMI;
			repProforma.cellDeliveryTerms.Text = "DELIVERY TERMS: " + teslimSekliList.FirstOrDefault(u => u.HARKOD == spfbas.TSSRKD).TANIMI;
			repProforma.cellDestCountry.Text = destinationCountry;

			string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
			string htmlTableEnd = "</table>";
			string htmlHeaderRowStart = "<tr style=\"color:#000000;\">";
			string htmlHeaderRowEnd = "</tr>";
			string htmlTrStart = "<tr style=\"color:#000000;\">";
			string htmlTrEnd = "</tr>";
			string htmlTdStart = "<td style=\" border-color:#000000; border-style:solid; border-width:1px; padding: 3px; \">";
			//string htmlTdStartMerge = "<td colspan=4 style=\" font-family: Calibri; font-size: 12pt; border-color:#000000; border-style:solid; border-width:1px; padding: 5px;\">";
			string htmlTdEnd = "</td>";

			decimal toplamFiyat = 0;

			CultureInfo culture = new CultureInfo("tr-TR");
			string currency = SetReportCulture(spfbas.DVCNKD, repProforma, out culture);

			int productCount = 0;
			List<SiparisUrunModel> productList = new List<SiparisUrunModel>();

			decimal toplamTutar = Convert.ToDecimal(spfbas.TOPTUT ?? 0);
			decimal navlunUcreti = spfbas.NAVMAS ?? 0;
			decimal digerUcretler = spfbas.DIGMAS ?? 0;

			subRepProformaTotal subRepTotal = new subRepProformaTotal();
			SetReportCulture(spfbas.DVCNKD, subRepTotal, out culture);
			subRepTotal.cellSubTotal.Text = toplamTutar.ToString("c2", culture);
			subRepTotal.cellFreightCharges.Text = navlunUcreti.ToString("c2", culture);
			subRepTotal.cellOtherCharges.Text = digerUcretler.ToString("c2", culture);
			subRepTotal.cellTotalAmount.Text = (toplamTutar + navlunUcreti + digerUcretler).ToString("c2", culture);
			if (spfbas.DVCNKD == "EUR")
			{
				subRepTotal.cellIbanLbl.Text = "Iban (EUR):";
				subRepTotal.cellIbanValue.Text = "TR66 0001 2001 5640 0058 1000 08";
			}

			//subRepTotal.CreateDocument();

			var selectedRow = (CRCARI)gridLke1Cari1.GetSelectedDataRow();

			List<SPFHAR> opsiyonsuzUrunList = new List<SPFHAR>();
			for (int s = 0; s < urunList.Count; s++)
			{
				SPFHAR spfhar = urunList[s];

				int columnC = 4;

				string stokKodu = spfhar.STKODU;
				string stokAdi = spfhar.STKNAM;
				int satirNo = spfhar.SATIRN.Value;
				toplamFiyat += spfhar.GFIYAT.Value;

				STNAME stname = _stnameService.Cch_GetByStokKoduLangkd_NLog(global, stokKodu, "en-GB", false)
					.Nesne;
				if (stname != null) stokAdi = spfhar.STKNAM = stname.STKNAM;
				if (spfhar.GROLBR == "ADT") spfhar.GROLBR = "PC(S)";

				STKART stkart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
				string hsCode = stkart.GTIPNO == null || stkart.GTIPNO == "" ? "" : "<b>HS CODE: " + stkart.GTIPNO + "</b>";
				string opsiyonlar = hsCode; //"<p style=\"font-family: Segoe UI; font-size: 9px\"><b>" + hsCode + "</b></p>";

				if (!string.IsNullOrEmpty(stokKodu))
				{
					STKART stokKart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;
					if (stokKart.UROPTB == null)
					{
						opsiyonsuzUrunList.Add(spfhar);
						continue;
					}
					else
					{
						string aciklama = "";
						var gnoptpList = _gnoptpService.Ncch_GetListByUstTipKod_NLog(global, stokKart.UROPTB).Items;
						var opsiyon = opsiyonList.FirstOrDefault(o => o.ContainsKey(satirNo));

						opsiyonlar += htmlTableStart;
						//opsiyonlar += htmlHeaderRowStart;

						opsiyonlar += "<td colspan=\"2\" style=\" border-color:#000000; border-style:solid; border-width:1px; padding: 3px; font-weight: bold;\">" + "Technical Specifications" + htmlTdEnd;
						opsiyonlar += HtmlTdStartOptionalCss("text-align: center; font-weight: bold;") + "Standard" + htmlTdEnd;
						opsiyonlar += HtmlTdStartOptionalCss("text-align: center; font-weight: bold;") + "Optional" + htmlTdEnd;

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

						productCount++;

						productList = new List<SiparisUrunModel>();
						productList.Add(new SiparisUrunModel { ITEMNO = productCount.ToString(), STKODU = stokKodu, STKNAM = stokAdi, URNOPS = opsiyonlar, GNMKTR = spfhar.GRMKTR, OLCUKD = spfhar.GROLBR, GFIYAT = spfhar.GFIYAT, GNTUTR = spfhar.GNTUTR });
					}
				}
				else continue;

				if (urunList.Count != opsiyonsuzUrunList.Count)
				{
					if (productCount == 1)
					{
						repProforma.bindingSource1.DataSource = productList;
						//repProforma.cellProduct.Controls.Add(new XRRichText() { Html = opsiyonlar, TextAlignment = TextAlignment.TopLeft });
						//repProforma.cellItemNo.Text = productCount.ToString();
						if (urunList.Count == 1) repProforma.subRepTotal.ReportSource = subRepTotal;
						repProforma.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
						repProforma.CreateDocument();
						rProforma = repProforma;
						rProforma.PrintingSystem.ContinuousPageNumbering = true;
					}
					else if (urunList.Count > 1)
					{
						repProforma3 rep3 = new repProforma3();
						SetReportCulture(spfbas.DVCNKD, rep3, out culture);
						rep3.cellTeslimTarihi.Text = spfbas.TERTAR?.ToShortDateString();
						rep3.cellUlasimYolu.Text = ulasimYoluListEn.FirstOrDefault(u => u.HARKOD == spfbas.TRMDKD).TANIMI;
						rep3.cellDeliveryTerms.Text = "DELIVERY TERMS: " + teslimSekliList.FirstOrDefault(u => u.HARKOD == spfbas.TSSRKD).TANIMI;
						rep3.cellDestCountry.Text = destinationCountry;
						//rep3.cellProduct.Controls.Add(new XRRichText() { Html = opsiyonlar, TextAlignment = TextAlignment.TopLeft });
						//rep3.cellItemNo.Text = productCount.ToString();
						rep3.bindingSource1.DataSource = productList;

						if (s == urunList.Count - 1) rep3.subRepTotal.ReportSource = subRepTotal;
						rep3.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
						rep3.CreateDocument();
						rProforma.Pages.AddRange(rep3.Pages);
					}
				}
			}

			List<SiparisUrunModel> lst = new List<SiparisUrunModel>();
			foreach (SPFHAR urn in opsiyonsuzUrunList)
			{
				productCount++;
				lst.Add(new SiparisUrunModel { ITEMNO = productCount.ToString(), STKODU = urn.STKODU, STKNAM = urn.STKNAM, URNOPS = "", GNMKTR = urn.GRMKTR, OLCUKD = urn.GROLBR, GFIYAT = urn.GFIYAT, GNTUTR = urn.GNTUTR });
			}

			if (urunList.Count == opsiyonsuzUrunList.Count)
			{
				repProforma.bindingSource1.DataSource = lst;
				repProforma.subRepTotal.ReportSource = subRepTotal;
				repProforma.Detail.Controls.Remove(repProforma.richTextUrunOpsiyon);
				repProforma.Detail.HeightF = 26.4583f;
				repProforma.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
				repProforma.CreateDocument();
				rProforma = repProforma;
				rProforma.PrintingSystem.ContinuousPageNumbering = true;
			}
			else if (opsiyonsuzUrunList.Count > 0)
			{
				repProforma3 rep3 = new repProforma3();
				SetReportCulture(spfbas.DVCNKD, rep3, out culture);
				rep3.cellTeslimTarihi.Text = spfbas.TERTAR?.ToShortDateString();
				rep3.cellUlasimYolu.Text = ulasimYoluListEn.FirstOrDefault(u => u.HARKOD == spfbas.TRMDKD).TANIMI;
				rep3.cellDeliveryTerms.Text = "DELIVERY TERMS: " + teslimSekliList.FirstOrDefault(u => u.HARKOD == spfbas.TSSRKD).TANIMI;
				rep3.cellDestCountry.Text = destinationCountry;
				rep3.bindingSource1.DataSource = lst;
				rep3.subRepTotal.ReportSource = subRepTotal;
				rep3.Detail.Controls.Remove(rep3.richTextUrunOpsiyon);
				rep3.Detail.HeightF = 26.4583f;
				rep3.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
				rep3.CreateDocument();
				rProforma.Pages.AddRange(rep3.Pages);
			}

			rProforma.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
			rProforma.ShowPreview();
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
			if (e.Column.FieldName == "GFIYAT" || e.Column.FieldName == "GNTUTR" || e.Column.FieldName == "OPSFYT")
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
				}
			}
		}

		private void gridLkeFiyatNo1_EditValueChanged(object sender, EventArgs e)
		{
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

		private void btnAdayCariEkle_Click(object sender, EventArgs e)
		{
			FrmAdayCari fForm = new FrmAdayCari(global);
			fForm.ShowDialog();

			if (fForm.addedCari != null)
			{
				CariKarts.Add(fForm.addedCari);
				gridLke1Cari1.Properties.DataSource = CariKarts;
				gridLke1Cari2.Properties.DataSource = CariKarts;

				gridLke1Cari1.EditValue = fForm.addedCari.CRAKOD;
				gridLke1Cari2.EditValue = fForm.addedCari.CRAKOD;
			}
		}

		private void GetDovizKur(DateTime date)
		{
			var baslik = (SPFBAS)sPFBASBindingSource.Current;

			List<string> dvcnkdList = new List<string> { "USD", "EUR" };
			dovkurList = new List<DOVKUR>();
			foreach (var dovkod in dvcnkdList)
			{
				var response = _dovkurService.Cch_GetByDate_NLog(dovkod, date);
				if (response.Status == ResponseStatusEnum.OK && response.Nesne != null)
				{
					var doviz = response.Nesne;

					dovkurList.Add(doviz);
					if (dovkod == "USD") baslik.USDFYT = Convert.ToDecimal(doviz.DVFYT1);
					else if (dovkod == "EUR") baslik.EURFYT = Convert.ToDecimal(doviz.DVFYT1);
				}
				else
				{
					DOVKUR dovkur = new DOVKUR { DVCNKD = dovkod, DOVTRH = date };
					dovkur = _dovkurService.GetDovizKuru(dovkur);

					if (dovkur != null && dovkur.DVFYT1 > 0)
					{
						dovkur.DOVTRH = date;
						_dovkurService.Ncch_AutoAdd_NLog(dovkur, global);
					}

					if (dovkod == "USD") baslik.USDFYT = dovkur != null ? Convert.ToDecimal(dovkur.DVFYT1) : 0;
					else if (dovkod == "EUR") baslik.EURFYT = dovkur != null ? Convert.ToDecimal(dovkur.DVFYT1) : 0;
				}
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


			decimal fiyat = 0;
			decimal.TryParse(textEdit.Text, out fiyat);
			if (textEdit.Name == "txtUsd") baslik.USDFYT = fiyat;
			else if (textEdit.Name == "txtEur") baslik.EURFYT = fiyat;

			sPFBASBindingSource.CurrencyManager.Refresh();

			OpsiyonFiyatHesapla();
		}

		private void btnSipariseDonustur_Click(object sender, EventArgs e)
		{
			DialogResult Secim;
			Secim = MessageBox.Show("Teklifi siparişe dönüştürmek istediğinizden emin misiniz ?", "Siparişe Dönüştür", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (Secim == DialogResult.Yes)
			{
				var newGlobal = global.ShallowCopy();
				newGlobal.Sira = 1;

				var fisTipList = _spftipService.Ncch_GetListBySphrtp_NLog(newGlobal, yetkiKontrol: false).Items;
				FrmFisTipiSec fForm = new FrmFisTipiSec();
				fForm.gridLkeFisTip.Properties.DataSource = fisTipList;
				fForm.ShowDialog();
				if (fForm.fisTipi == null) return;

				this.Validate();
				try
				{
					getVergi();
					getTutar();

					sPFBASBindingSource.EndEdit();
					var baslik = ((SPFBAS)sPFBASBindingSource.Current).ShallowCopy();
					baslik.Id = 0;
					baslik.SPHRTP = 1;
					baslik.SPFTNO = fForm.fisTipi.SPFTNO;
					baslik.SPORKD = fForm.fisTipi.SPORKD;
					baslik.SPDGKD = fForm.fisTipi.SPDGKD;
					baslik.TKBGNO = baslik.BELGEN;
					baslik.BELTRH = DateTime.Now;
					baslik.ACTIVE = true;
					baslik.SLINDI = true;

					var model = new SiparisKayitModel();
					model.Baslik = baslik;

					if (string.IsNullOrEmpty(model.Baslik.TKDRKD)) model.Baslik.TKDRKD = "01";

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

					var response = new StandardResponse();
					response = _xxService.Ncch_SiparisKaydet_Log(model, newGlobal, false);
					if (response.Status != ResponseStatusEnum.OK)
					{
						MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
						return;
					}

					opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

					LoadGrid();
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
		}

		private List<ReportTemplate> reportTemplates;

		public void GetTempDesignNames(string stokKodu)
		{
			string tempFolder = AppDomain.CurrentDomain.BaseDirectory + "Report Templates\\" + stokKodu + "\\";

			reportTemplates = new List<ReportTemplate>();

			if (!Directory.Exists(tempFolder)) return;

			List<string> files = Directory.GetFiles(tempFolder).ToList();

			if (files.Count > 0)
			{
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

						if (sablon != "")
						{
							ReportTemplate reportTemp = new ReportTemplate();
							reportTemp.filePath = file;
							reportTemp.sablon = sablon;
							reportTemp.sayfa = sayfaNo;
						}
					}
				}
				catch (Exception e)
				{
					Console.WriteLine(e);
				}
			}
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

		private void gridLkeUrunTipi_EditValueChanged(object sender, EventArgs e)
		{
			gridLkedTasarimSablon.Properties.DataSource = null;
			reportTemplates = new List<ReportTemplate>();

			if (gridLkeUrunTipi.EditValue != null && gridLkeUrunTipi.EditValue.ToString() == "01" && grdViewSipKalem.RowCount > 0)
			{
				SPFHAR spfhr = sPFHARBindingSource.List[0] as SPFHAR;
				GetTempDesignNames(spfhr.STKODU);
			}
		}

		private void btnOdemeTablosu_Click(object sender, EventArgs e)
		{
			var baslik = (SPFBAS)sPFBASBindingSource.Current;

			if (baslik != null && baslik.Id > 0)
			{
				double toplamTutar = baslik.TOPKDT ?? 0;
				TipHareketListModel tiphr = gridLkEdLanguage.GetSelectedDataRow() as TipHareketListModel;
				if (tiphr.HARKOD != "tr-TR")
				{
					toplamTutar = (baslik.TOPTUT ?? 0) + Convert.ToDouble(baslik.NAVMAS) + Convert.ToDouble(baslik.DIGMAS);
				}

				//if (baslik.DVCNKD == "EUR") toplamTutar *= Convert.ToDouble(baslik.EURFYT.Value);
				//if (baslik.DVCNKD == "USD") toplamTutar *= Convert.ToDouble(baslik.USDFYT.Value);

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

		private List<SiparisKosulModel> GetSiparisKosulList(string langkd)
		{
			var baslik = (SPFBAS)sPFBASBindingSource.Current;
			List<SiparisKosulModel> kosulList = _spkoslService.Ncch_GetListByBelgeNoJoinGnkosul_NLog(global, baslik.BELGEN, langkd).Items;

			if (kosulList.Count == 0 && langkd != "tr-TR")
			{
				List<GNKOSL> kslList = _gnkoslService.Ncch_GetListByProjeKodAndLanguage_NLog(global, global.ProjeKod, langkd, true).Items;

				foreach (GNKOSL gnkosl in kslList)
				{
					SPKOSL spkosl = new SPKOSL
					{
						BELGEN = baslik.BELGEN,
						KOSLID = gnkosl.Id,
						SIRKID = global.SirketId.Value,
						ACTIVE = true,
						SLINDI = false,
						CHKCTR = false,
						KYNKKD = "3",
						EKKULL = global.UserKod,
						ETARIH = DateTime.Now,
					};
					_spkoslDal.Add(spkosl);
				}

				kosulList = _spkoslService.Ncch_GetListByBelgeNoJoinGnkosul_NLog(global, baslik.BELGEN, langkd).Items;
			}

			return kosulList;
		}

		private void btnTeklifYedekParca_Click(object sender, EventArgs e)
		{
			List<SPODTB> odemeList = new List<SPODTB>();

			if (Param.ADAPTATION == Adaptation.Bala)
			{
				odemeList = CheckOdemePlani();
				if (odemeList == null || odemeList.Count == 0) return;
			}

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

			if (yetkililer.Count == 1) crytkl = yetkililer[0];
			else if (yetkililer.Count > 1)
			{
				FrmYetkiliSec yForm = new FrmYetkiliSec();
				yForm.yetkililer = yetkililer;
				yForm.ShowDialog();
				if (yForm.id == 0) return;

				crytkl = yetkililer.FirstOrDefault(y => y.Id == yForm.id);
			}

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

			rSiparis.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
			rSiparis.lblSiparisNo.Text = spfbas.BELGEN;

			string musteriBilgileri = (docLang == "tr-TR" ? "" : "To: ") + selectedRow.CRUNV1 + "<br><br>" +
									  (docLang == "tr-TR" ? "Yetkili Kişi: " : "Contact Person: ") +
									  (crytkl != null ? crytkl.YETADI + " " + crytkl.YETSOY : "") + "<br>" +
									  (docLang == "tr-TR" ? "İletişim No: " : "Contact Number: ") + (crytkl != null ? crytkl.CEPTEL : "") + "<br>" +
									  (docLang == "tr-TR" ? "E-posta: " : "E-mail: ") + (crytkl != null ? crytkl.GNMAIL : "") + "<br>" +
									  (docLang == "tr-TR" ? "Teslimat Adresi: " : "Delivery Address: ") + (teslimatAdres != null ? teslimatAdres.ADRESS + " " + GetUlkeSehirIlce(teslimatAdres) : "") +
									  "<br>" +
									  (docLang == "tr-TR" ? "Fatura Adresi: " : "Billing Address: ") + (faturaAdres != null ? faturaAdres.ADRESS + " " + GetUlkeSehirIlce(faturaAdres) : "");

			rSiparis.richTextMusteri.Html = "<p style=\"font-family: Noir Pro; font-size: 9.71px\">" + musteriBilgileri + "</p>";

			string siparisInfo = (docLang == "tr-TR" ? "Belge Tarihi: " : "Offer Date: ") + spfbas.BELTRH.ToShortDateString() + "<br><br>" +
								 (docLang == "tr-TR" ? "Teslim Tarihi: " : "Delivery Date: ") + spfbas.TERTAR?.ToShortDateString() + "<br><br>" +
								 (docLang == "tr-TR" ? "Geçerlilik Tarihi: " : "Latest Date of Validity: ") + (spfbas.GCRTRH == null ? "" : spfbas.GCRTRH.Value.ToShortDateString()) + "<br><br>" +
								 (docLang == "tr-TR" ? "Satış Personeli: " : "Contact Person at Bala: ") + (satisPersoneli != null ? (satisPersoneli.GNNAME + " " + satisPersoneli.GNSNAM) : "") + "<br><br>" +
								 (docLang == "tr-TR" ? "İletişim No: " : "Contact Person Phone: ") + (satisPersoneli != null ? satisPersoneli.GNTELF : "") + "<br><br>" +
								 (docLang == "tr-TR" ? "E-posta: " : "E-mail: ") + (satisPersoneli != null ? satisPersoneli.GNMAIL : "") + "<br><br>" +
								 (docLang == "tr-TR" ? "Fabrika Adresi: " + sirket.ADRESS : " Factory Address:  <b>" + sirket.ADRESS + "</b>") + "<br>";

			rSiparis.richTextSiparisInfo.Html = "<p style=\"font-family: Noir Pro; font-size: 12.53px\">" + siparisInfo + "</p>";

			rSiparis.bindingSource1.DataSource = lst;


			repSiparis2LastPage rSip = new repSiparis2LastPage(docLang, spfbas.DVCNKD);
			rSip.ApplyLocalization(cultureInfo);
			rSip.Name = spfbas.BELGEN + " - " + selectedRow.CRUNV1;
			rSip.PrintingSystem.ContinuousPageNumbering = true;

			rSip.lblCompanyInfo.Text = rSiparis.lblCompanyInfo.Text = sirket.GNNAME + "\r\n" + sirket.ADRESS + "\r\n" +
																	  "Telefon: " + sirket.ISYTEL + "\r\n" + "E-posta: " + sirket.EPOSTA + "\r\n" + sirket.WEBSIT;

			if (odemeList != null && odemeList.Count > 0) rSip.bindingSource1.DataSource = odemeList;

			double iskonto = spfbas.TOPISK ?? 0;
			double kdv = spfbas.TOPKDV ?? 0;
			decimal navlun = spfbas.NAVMAS ?? 0;
			decimal diger = spfbas.DIGMAS ?? 0;
			double tevkifat = spfbas.TEVKIF == null ? 0 : ((double)spfbas.TEVKIF / 100 * kdv);
			var odenecekTutar = (spfbas.TOPKDT.Value + Convert.ToDouble((navlun + diger)));

			rSip.lblGenelToplam.Text = spfbas.TOPBRT.Value.ToString("n2");
			rSip.lblIskonto.Text = iskonto.ToString("n2");
			rSip.lblKdv.Text = kdv.ToString("n2");
			rSip.lblAraToplam.Text = (spfbas.TOPBRT.Value - iskonto).ToString("n2");
			rSip.lblNetTutar.Text = odenecekTutar.ToString("n2");
			rSip.lblOdenecekTutar.Text = (odenecekTutar - tevkifat).ToString("n2");
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

			rSip.lblOdenecekTutarTL.Visible = false;
			rSip.lblOdenecekTutarTL1.Visible = false;
			rSip.lblOdenecekTutarTL2.Visible = false;
			rSip.lblDovizFiyat.Visible = false;
			rSip.lblDovizFiyat1.Visible = false;
			rSip.lblDovizFiyat2.Visible = false;

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

			//if (spfbas.DVCNKD != "TRY")
			//{
			//    double dovizFiyat = 0;
			//    if (spfbas.DVCNKD == "USD") dovizFiyat = spfbas.USDFYT == null ? 0 : (double)spfbas.USDFYT.Value;
			//    else if (spfbas.DVCNKD == "EUR") dovizFiyat = spfbas.EURFYT == null ? 0 : (double)spfbas.EURFYT.Value;

			//    rSip.lblOdenecekTutarTL.Text = (odenecekTutar * dovizFiyat).ToString("n2");
			//    rSip.lblOdenecekTutarTL2.Text = "TRY";

			//    rSip.lblDovizFiyat.Text = dovizFiyat.ToString("n4");
			//    rSip.lblDovizFiyat1.Text = "1 " + spfbas.DVCNKD + ": ";
			//}
			//else
			//{
			//    rSip.lblOdenecekTutarTL.Visible = false;
			//    rSip.lblOdenecekTutarTL1.Visible = false;
			//    rSip.lblOdenecekTutarTL2.Visible = false;
			//    rSip.lblDovizFiyat.Visible = false;
			//    rSip.lblDovizFiyat1.Visible = false;
			//    rSip.lblDovizFiyat2.Visible = false;
			//}

			TipHareketListModel tiphr = gridLkEdLanguage.GetSelectedDataRow() as TipHareketListModel;
			var kosulList = GetSiparisKosulList(tiphr.HARKOD);

			string kosullar = "";

			if (kosulList.Count > 0)
			{
				string htmlTdStart = "<td>";
				string htmlTableEnd = "</table>";
				string htmlTableStart = "<table style=\"border-collapse:collapse; text-align:center;\" >";
				string htmlTrStart = "<tr style=\"color:#000000;\">";
				string htmlTrEnd = "</tr>";
				string htmlTdEnd = "</td>";
				kosullar = htmlTableStart;

				if (tiphr.HARKOD.StartsWith("en-"))
				{
					string deliveryTerm = spfbas.TSSRKD == null
						? "---------"
						: teslimSekliList.FirstOrDefault(u => u.HARKOD == spfbas.TSSRKD).TANIMI;

					string kosl = "- Delivery terms: " + deliveryTerm;
					kosullar += htmlTrStart + htmlTdStart + kosl + htmlTdEnd + htmlTrEnd;
				}

				foreach (SiparisKosulModel spKosul in kosulList)
				{
					string kosul = "- " + spKosul.KOSULL;
					if (kosul.Contains("NAKLİYE ALICIYA AİTTİR"))
						kosul = kosul.Replace("NAKLİYE ALICIYA AİTTİR.", "<b>NAKLİYE ALICIYA AİTTİR.</b>");
					if (kosul.Contains("{gun}"))
						kosul = kosul.Replace("{gun}", spfbas.GCRTRH.Value.Subtract(spfbas.BELTRH).Days.ToString());
					kosullar += htmlTrStart + htmlTdStart + kosul + htmlTdEnd + htmlTrEnd;
				}

				kosullar = kosullar + htmlTableEnd;
				kosullar = "<p style=\"font-family: Noir Pro; font-size: 9px\">" + kosullar + "</p>";
			}

			rSip.richTextAnlasmaKosullari.Html = kosullar;

			rSip.CreateDocument();

			rSiparis.CreateDocument();
			rSiparis.Pages.AddRange(rSip.Pages);
			rSiparis.ShowPreview();

		}
	}

	public class ReportTemplate
	{
		public XtraReport report;
		public string filePath;
		public string sablon;
		public int sayfa;
	}
}