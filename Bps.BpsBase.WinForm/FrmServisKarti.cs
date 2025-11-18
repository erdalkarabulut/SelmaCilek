using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Business.Abstract.SH;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SH;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.Entities.Models.IK.Listed;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using BPS.Google.Firestore;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Newtonsoft.Json;
using Bps.Core.GlobalStaticsVariables;


namespace BPS.Windows.Forms
{
	public partial class FrmServisKarti : BPS.Windows.Base.FrmChildBase
	{
		private readonly IShsrvsService _sinifService;
		private readonly IGnkxmlService _sinifyerlesimService;
		private readonly ICrcariService _crcariService;
		private readonly ICrytklService _crytklService;
		private readonly ICradrsService _cradrsService;
		private readonly IIkpersService _ikpersService;
		private readonly IGntipiService _gntipiService;
		private readonly IGnthrkService _gnthrkService;
		private readonly IGnlkhrService _gnlkhrService;
		private readonly IGndptnService _gndptnService;
		private readonly IGnevrkService _gnevrkService;
		private ProjeMenuListed yetkiModel;
		private string _action;
		private string _pdfPath = "";
		private GNKXML _sinifyerlesim;
		private List<CRCARI> _cariList;
		private List<GNTIPI> _gntipiList;
		private List<GNTIPI> _makineKategoriList;
		private static SHSRVS oldData;

		private string ulkeTip = "";
		private string sehirTip = "";
		private string ilceTip = "";
		private string semtTip = "";
		private string mahalleTip = "";

		public FrmServisKarti(IShsrvsService sinifService, IGnkxmlService sinifyerlesimService, ICrcariService crcariService,
				ICrytklService crytklService, ICradrsService cradrsService, IIkpersService ikpersService,
				IGntipiService gntipiService, IGnthrkService gnthrkService, IGnlkhrService gnlkhrService,
				IGndptnService gndptnService, IGnevrkService gnevrkService)
		{
			InitializeComponent();

			xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
			dtBaslangic.EditValue = DateTime.Today.AddDays(-5);
			dtBitis.EditValue = DateTime.Today.AddDays(5);

			_sinifService = sinifService;
			_sinifyerlesimService = sinifyerlesimService;
			_crcariService = crcariService;
			_crytklService = crytklService;
			_cradrsService = cradrsService;
			_ikpersService = ikpersService;
			_gntipiService = gntipiService;
			_gnthrkService = gnthrkService;
			_gnlkhrService = gnlkhrService;
			_gndptnService = gndptnService;
			_gnevrkService = gnevrkService;
			oldData = null;
		}

		private async void FrmServisKarti_Load(object sender, EventArgs e)
		{
			yetkiModel = MenuYetki;
			FormIslemleri.FormYetki2(barManager, yetkiModel);
			gridView1.OptionsView.ShowAutoFilterRow = true;
			LoadData();
			GridHelper.ColumnRepositoryItems(gridView1, global);
			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);

			Firestore.Initialize();
		}

		private void LoadData()
		{
			_gntipiList = _gntipiService.Ncch_GetByHareketTable_NLog(global, "GNLKHR", false).Items;
			ulkeTip = _gntipiList.Find(t => t.TEKNAD == "ULKEKD").TIPKOD;
			sehirTip = _gntipiList.Find(t => t.TEKNAD == "SEHRKD").TIPKOD;
			ilceTip = _gntipiList.Find(t => t.TEKNAD == "ILCEKD").TIPKOD;
			semtTip = _gntipiList.Find(t => t.TEKNAD == "SEMTKD").TIPKOD;
			mahalleTip = _gntipiList.Find(t => t.TEKNAD == "MAHAKD").TIPKOD;

			var makineKategoriTip = _gntipiService.Ncch_GetByTeknikAd_NLog(global, "MKNKTG", false).Nesne;
			_makineKategoriList = _gntipiService.Ncch_GetListByUstTipKod_NLog(global, makineKategoriTip.TIPKOD, false).Items;

			var persList = _ikpersService.Ncch_GetListPersonelSicilAdPoz_NLog(global, false).Items;
			persList.Insert(0, new IkpersSicilAdPozModel());
			grdLkedServisPersonel.Properties.DataSource = persList;
			repGrdLkedPersonel.DataSource = persList;

			_cariList = _crcariService.Ncch_GetAllActive_NLog(global, false).Items;
			cRKODUGridLookUpEdit.Properties.DataSource = _cariList;
			repGrdLkedCari.DataSource = _cariList;

			_sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
				global.MenuName,
				global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
			if (_sinifyerlesim != null)
			{
				byte[] byteArray = Encoding.ASCII.GetBytes(_sinifyerlesim.GRDXML);
				MemoryStream stream = new MemoryStream(byteArray);
				gridView1.RestoreLayoutFromStream(stream);
			}

			var teknads = new List<string>() { "SRTRKD", "SRDRKD", "GRDRKD", "MKDRKD", "STALKD", "MKNKTG" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
			grdLkedServisTuru.Properties.DataSource = repGrdLkedServisTuru.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "SRTRKD").ToList();
			grdLkedServisDurumu.Properties.DataSource = repGrdLkedServisDurumu.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "SRDRKD").ToList();
			grdLkedGarantiDurumu.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "GRDRKD").ToList();
			grdLkedMakineDurumu.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "MKDRKD").ToList();
			grdLkedKategori.Properties.DataSource =
				repGrdLkedKategori.DataSource =
					_makineKategoriList;

			//teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();

			//List<GNTHRK> makineModelList = new List<GNTHRK>();
			//foreach (GNTIPI gntipi in _makineKategoriList)
			//{
			//    var modelList = _gnthrkService.Cch_GetListByTeknad(global, gntipi.TEKNAD, false).Items;
			//    makineModelList.AddRange(modelList);
			//}
		}

		private void LoadGrid()
		{
			bool tamamlanan = chkTamamlanan.Checked;
			var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
			var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
			var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

			var param = new SshParamModel()
			{
				BELGEN = belgeNo,
				DtBaslangic = dtBas,
				DtBitis = dtBit,
				Tamamlanan = tamamlanan,
			};

			sHSRVSBindingSource.DataSource = _sinifService.Cch_GetListByParam_NLog(param, global).Items;
		}

		protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
		{
			grdIslemSure.DataSource = null;
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			_action = "insert";
			timeEdit1.Time = DateTime.Now;
			var rowView = (SHSRVS)sHSRVSBindingSource.AddNew();
			if (rowView != null)
			{
				rowView.SRTLTR = DateTime.Now;
				rowView.ACTIVE = true;

				grdLkedServisDurumu.EditValue = "01";
				rowView.SRVDRM = "01";

				cmbTalebiAcan.Text = global.FirstName + " " + global.LastName;
				rowView.TLPACN = cmbTalebiAcan.Text;
			}

			cRKODUGridLookUpEdit.Enabled = true;
			xtraTabControl1.SelectedTabPage = xtraTabPage3;
		}

		protected override async void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			_action = "update";
			oldData = ((SHSRVS)sHSRVSBindingSource.Current).ShallowCopy();
			timeEdit1.Time = oldData.SRTLTR;

			if (oldData.SRVDRM == "03") barKaydet.Enabled = false;
			else barKaydet.Enabled = true;

			grdIslemSure.DataSource = null;

			cRKODUGridLookUpEdit.Enabled = false;

			//var modelList = _gnthrkService.Cch_GetListByTipKod(global, oldData.URKTGR, false).Items;
			//grdLkedModel.Properties.DataSource = modelList;
			//grdLkedModel.EditValue = oldData.URMODL;

			_pdfPath = AppDomain.CurrentDomain.BaseDirectory + @"service\Servis Raporları\" + oldData.BELGEN + " - " + oldData.CRUNVN + ".pdf";
			if (File.Exists(_pdfPath))
			{
				btnPdf.Visible = true;
				btnWord.Visible = true;
			}
			else
			{
				_pdfPath = "";
				btnPdf.Visible = false;
				btnWord.Visible = false;
			}

			try
			{
				string strstpJson = oldData.STRSTP ?? "";

				if (strstpJson != "")
				{
					DataTable table = new DataTable();
					table.Columns.Add("ACCODE", typeof(int));
					table.Columns.Add("ACTION", typeof(string));
					table.Columns.Add("TMSTMP", typeof(DateTime));
					table.Columns.Add("TOPDAK", typeof(int));

					var dataMap = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(strstpJson);

					foreach (object o in dataMap)
					{
						var strstp = o as Dictionary<string, object>;
						var h = strstp["TMSTMP"].ToString();
						DateTime dateTime = DateTime.ParseExact(strstp["TMSTMP"].ToString().Replace("Timestamp:", "").Trim(),
							"yyyy-MM-ddTHH:mm:ss.ffffffK", null);

						DataRow row = table.NewRow();
						int kod = Convert.ToInt32(strstp["ACCODE"]);
						row["ACCODE"] = kod;
						row["ACTION"] = strstp["ACTION"].ToString();
						row["TMSTMP"] = dateTime;

						if (kod == 1)
						{
							DataRow rw = table.Rows[table.Rows.Count - 1];
							if (Convert.ToInt32(rw["ACCODE"]) == 0)
							{
								DateTime previousTime = DateTime.Parse(rw["TMSTMP"].ToString());
								TimeSpan ts = dateTime - previousTime;
								int minDifference = (int)ts.TotalMinutes;
								rw["TOPDAK"] = minDifference;
							}
						}

						table.Rows.Add(row);
					}

					if (table.Rows.Count > 0)
					{
						DataRow r = table.Rows[table.Rows.Count - 1];
						if (Convert.ToInt32(r["ACCODE"]) == 0)
						{
							DateTime previousTime = DateTime.Parse(r["TMSTMP"].ToString());
							TimeSpan ts = DateTime.Now - previousTime;
							int minDifference = (int)ts.TotalMinutes;
							r["TOPDAK"] = minDifference;
						}
					}

					grdIslemSure.DataSource = table;
					grdVwIslemSure.BestFitColumns();
				}
			}
			catch (Exception exception)
			{
				grdIslemSure.DataSource = null;
				//MessageBox.Show(exception.ToString(), "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}

			xtraTabControl1.SelectedTabPage = xtraTabPage3;
			cRKODUGridLookUpEdit_EditValueChanged(null, EventArgs.Empty);
		}

		//protected override async void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
		//{

		//}

		public override async void Save()
		{
			Validate();
			bool error = false;
			try
			{
				barKaydet.Enabled = false;

				var response = new StandardResponse<SHSRVS>();
				sHSRVSBindingSource.EndEdit();
				var data = (SHSRVS)sHSRVSBindingSource.Current;
				data.SRTLTR = data.SRTLTR.Date.Add(timeEdit1.Time.TimeOfDay);

				CRCARI cari = cRKODUGridLookUpEdit.GetSelectedDataRow() as CRCARI;
				IkpersSicilAdPozModel pers = grdLkedServisPersonel.GetSelectedDataRow() as IkpersSicilAdPozModel;
				if (pers == null) pers = new IkpersSicilAdPozModel { Id = 0 };

				var kategori = grdLkedKategori.GetSelectedDataRow() as GNTIPI;
				var model = grdLkedModel.GetSelectedDataRow() as GNTHRK;

				float gpsEnlem = 0;
				float gpsBoylam = 0;

				float.TryParse(txtGpsEnlem.Text, out gpsEnlem);
				float.TryParse(txtGpsBoylam.Text, out gpsBoylam);

				data.CRUNVN = cari.CRUNV1;
				data.CRADRS = cmbAdres.Text;
				data.GPSENL = gpsEnlem == 0 ? (double?)null : gpsEnlem;
				data.GPSBOY = gpsBoylam == 0 ? (double?)null : gpsBoylam;
				data.CRTLFN = cmbTelefon.Text;
				data.CRYTKL = cmbYetkili.Text;
				data.URKTGR = kategori == null ? "" : kategori.TIPKOD;
				data.URMODL = model == null ? "" : model.HARKOD;
				data.SRVPRS = pers != null ? pers.GNNAME : "";
				data.SRSYNC = true;

				if (grdLkedServisPersonel.Text == "") data.SRPRID = 0;

				if (_action == "insert")
				{
					var evrakmodel = new EvrakNoUretParamModel();
					evrakmodel.TabloAdi = "SHSRVS";
					evrakmodel.TeknikAd = "BELGEN";
					evrakmodel.IslemTur = 0;
					var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

					if (evrakResponse.Status != ResponseStatusEnum.OK)
					{
						barKaydet.Enabled = true;
						throw new BusinessException(evrakResponse.Message);
					}

					data.BELGEN = evrakResponse.Nesne;
					data.BELTRH = DateTime.Now;

					response = _sinifService.Ncch_Add_NLog(data, global);
				}

				string writeStrstp = "";
				if (_action == "update")
				{
					if (data.SRPRID == 0)
					{
						data.SRVDRM = "01";
						data.SRVPRS = null;

						if (oldData.SRPRID > 0 && data.STRSTP != null) writeStrstp = "BİTİR";
					}
					else if (oldData.SRPRID > 0 && data.SRPRID != oldData.SRPRID)
					{
						if (data.STRSTP != null) writeStrstp = "BİTİR";
						data.SRVDRM = "01";
					}

					global.IsCompare = true;
					response = _sinifService.Ncch_Update_Log(data, oldData, global);
					global.IsCompare = false;
				}

				if (response.Status != ResponseStatusEnum.OK)
				{
					barKaydet.Enabled = true;
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				//var extraData = new List<Dictionary<string, object>>();
				//if (workOrder != null && workOrder.ContainsKey("STRSTP"))
				//{
				//    var strstpDict = new Dictionary<string, object>();
				//    strstpDict.Add("STRSTP", workOrder["STRSTP"] as List<object>);
				//    extraData.Add(strstpDict);
				//}

				SHSRVS savedData = response.Nesne;

				bool firestoreSaved =
					await Firestore.SetEntity("workOrders", savedData, writeStrstp: writeStrstp, global: global);
				if (firestoreSaved)
				{
					savedData.CLSYNC = true;
					response = _sinifService.Ncch_Update_Log(savedData, savedData, global);

					if (response.Status != ResponseStatusEnum.OK)
					{
						MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

				string notificationTitle = "EFI Servis";

				if (Param.ADAPTATION == Adaptation.Bala) notificationTitle = "Bala Servis";
				if (Param.ADAPTATION == Adaptation.Nesto) notificationTitle = "Nesto Servis";

				if (pers.Id != 0 && _action == "insert")
				{
					List<string> tokenList = await Firestore.GetUserTokenById(pers.Id);
					Firestore.SendNotification(notificationTitle, "Yeni servis kartı oluşturuldu! \r\n" + savedData.CRUNVN,
						tokenList);
				}
				else if (pers.Id == 0 && _action == "insert")
				{
					List<string> tokenList = await Firestore.GetUserTokenById(null);
					Firestore.SendNotification(notificationTitle, "Yeni servis kartı oluşturuldu! \r\n" + savedData.CRUNVN,
						tokenList);
				}
				else if (pers.Id > 0 && _action == "update")
				{
					if (oldData.SRVPRS == null || oldData.SRPRID != pers.Id)
					{
						List<string> tokenList = await Firestore.GetUserTokenById(pers.Id);
						Firestore.SendNotification(notificationTitle,
							"Yeni servis kartı oluşturuldu! \r\n" + savedData.CRUNVN, tokenList);
					}
				}

				LoadGrid();
				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(toolBarButtonArgs.Item.Tag), yetkiModel);
				xtraTabControl1.SelectedTabPage = xtraTabPage2;
			}
			catch (Exception exception)
			{
				barKaydet.Enabled = true;
				error = true;
				MessageBox.Show("Kayıt Yapılamadı! " + exception.Message);
			}

			if (error == false) oldData = null;
		}

		protected override async void barSil_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle < 0) return;

			DialogResult Secim;
			Secim = MessageBox.Show("Silmek istediğinizden Eminmisiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Secim == DialogResult.Yes)
			{
				string belgeNo = gridView1.GetFocusedRowCellDisplayText("BELGEN");
				var shsrvs = _sinifService.Ncch_GetByBelgeNo_NLog(belgeNo, global).Nesne;
				shsrvs.SRVPRS = "";
				shsrvs.SRSYNC = true;

				var response = new StandardResponse<SHSRVS>();

				global.IsCompare = true;
				response = _sinifService.Ncch_Update_Log(shsrvs, oldData, global);
				global.IsCompare = false;


				if (response.Status != ResponseStatusEnum.OK)
				{
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				_sinifService.Ncch_Delete_Log(shsrvs, global);

				SHSRVS savedData = response.Nesne;
				bool firestoreSaved = await Firestore.SetEntity("workOrders", savedData);
				if (firestoreSaved)
				{
					if (response.Status != ResponseStatusEnum.OK)
					{
						MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
				}

				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
				LoadData();
				gridView1.RefreshData();
				gridView1.BestFitColumns();
				//gridView1.RefreshData();
			}
		}

		protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
		{
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			sHSRVSBindingSource.CancelEdit();

			LoadGrid();
			xtraTabControl1.SelectedTabPage = xtraTabPage2;
			oldData = null;
		}

		protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
		{
			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
			sHSRVSBindingSource.CancelEdit();

			LoadGrid();
			xtraTabControl1.SelectedTabPage = xtraTabPage2;
			oldData = null;
		}

		protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
		{
			gridView1.OptionsView.ShowAutoFilterRow = gridView1.OptionsView.ShowAutoFilterRow == false;
		}

		protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!gridControl1.IsPrintingAvailable)
			{
				MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
				return;
			}

			if (xtraTabControl1.SelectedTabPage == xtraTabPage2) gridView1.ShowPrintPreview();
		}

		private void cRKODUGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
		{
			cmbAdres.Items.Clear();
			cmbAdres.Text = "";
			txtGpsEnlem.Text = "";
			txtGpsBoylam.Text = "";
			cmbTelefon.Items.Clear();
			cmbTelefon.Text = "";
			cmbYetkili.DataSource = null;
			cmbYetkili.Text = "";

			if (xtraTabControl1.SelectedTabPage == xtraTabPage2) return;

			try
			{
				CRCARI cari = (CRCARI)cRKODUGridLookUpEdit.GetSelectedDataRow();

				if (cari != null)
				{
					List<CRADRS> adresList = _cradrsService.Cch_GetListByCariKod_NLog(global, cari.CRKODU, false).Items;

					foreach (CRADRS cradrs in adresList)
					{
						string ulke = string.IsNullOrEmpty(cradrs.ULKEKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, ulkeTip, cradrs.ULKEKD, false).Nesne.TANIMI;
						string sehir = string.IsNullOrEmpty(cradrs.SEHRKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, sehirTip, cradrs.SEHRKD.Length == 1 ? "0" + cradrs.SEHRKD : cradrs.SEHRKD, false).Nesne.TANIMI + " ";
						string ilce = string.IsNullOrEmpty(cradrs.ILCEKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, ilceTip, cradrs.ILCEKD, false).Nesne.TANIMI + " ";
						string semt = string.IsNullOrEmpty(cradrs.SEMTKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, semtTip, cradrs.SEMTKD, false).Nesne.TANIMI + " / ";
						string mahalle = string.IsNullOrEmpty(cradrs.MAHAKD) ? "" : _gnlkhrService.Ncch_GetByTipKodAndHarKod_NLog(global, mahalleTip, cradrs.MAHAKD, false).Nesne.TANIMI + " ";
						string adres = cradrs.ADRESS + " ";

						string tamAdres = mahalle + adres + ilce + semt + sehir + ulke;

						cmbAdres.Items.Add(tamAdres);
					}

					if (cmbAdres.Items.Count > 0)
					{
						CRADRS adres = adresList[0];
						cmbAdres.SelectedIndex = 0;
						txtGpsEnlem.Text = adres.GPSENL == null ? "" : Convert.ToDouble(adres.GPSENL.Value).ToString();
						txtGpsBoylam.Text = adres.GPSBOY == null ? "" : Convert.ToDouble(adres.GPSBOY.Value).ToString();
					}

					var yetkiliList = new[]
					{
						new { Id = 0, AdSoyad = "" }
					}.ToList();

					List<CRYTKL> crytklList =
						_crytklService.Cch_GetListByCariKod_NLog(cari.CRKODU, global, false).Items;

					foreach (CRYTKL crytkl in crytklList)
					{
						int id = crytkl.Id;
						string adSoyad = crytkl.YETADI + " " + crytkl.YETSOY;
						yetkiliList.Add(new { Id = id, AdSoyad = adSoyad });
					}

					yetkiliList.RemoveAt(0);

					if (crytklList.Count > 0)
					{
						cmbYetkili.DataSource = yetkiliList;
						cmbYetkili.ValueMember = "Id";
						cmbYetkili.DisplayMember = "AdSoyad";
						cmbYetkili.SelectedIndex = 0;
					}
				}

				if (_action == "update")
				{
					cmbAdres.Text = oldData.CRADRS;
					cmbYetkili.Text = oldData.CRYTKL;
					cmbTelefon.Text = oldData.CRTLFN;
					txtGpsEnlem.Text = oldData.GPSENL == null ? "" : Convert.ToDouble(oldData.GPSENL.Value).ToString();
					txtGpsBoylam.Text = oldData.GPSBOY == null ? "" : Convert.ToDouble(oldData.GPSBOY.Value).ToString();
				}
			}
			catch (Exception ex)
			{
				Console.WriteLine(ex.ToString());
			}
		}

		private void cmbYetkili_SelectedIndexChanged(object sender, EventArgs e)
		{
			cmbTelefon.Items.Clear();
			int selectedIndex = cmbYetkili.SelectedIndex;

			if (selectedIndex > -1)
			{
				int id = cmbYetkili.SelectedValue.ToInt32();
				CRYTKL crytkl = _crytklService.Ncch_GetById_NLog(id, global, false).Nesne;

				if (crytkl.CEPTEL != null) cmbTelefon.Items.Add(crytkl.CEPTEL);
				if (crytkl.ISYTEL != null) cmbTelefon.Items.Add(crytkl.ISYTEL);

				if (cmbTelefon.Items.Count > 0) cmbTelefon.SelectedIndex = 0;
			}
		}

		private void cmbYetkili_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
			ComboBox control = ((ComboBox)sender);
			int pos = control.SelectionStart;

			control.Text = control.Text.ToUpper();
			control.SelectionStart = pos++;
		}

		private void gridControl1_DoubleClick(object sender, EventArgs e)
		{
			Point point = gridView1.GridControl.PointToClient(MousePosition);
			GridHitInfo info = gridView1.CalcHitInfo(point);
			if (info.InRow || info.InRowCell)
			{
				var link = barDegistir.GetVisibleLinks()[0];
				ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
				barDegistir_ItemClick(barDegistir, arg);
			}
		}

		private void grdLkedKategori_EditValueChanged(object sender, EventArgs e)
		{
			if (xtraTabControl1.SelectedTabPage != xtraTabPage3) return;

			grdLkedModel.EditValue = null;
			grdLkedModel.Properties.DataSource = null;
			((SHSRVS)sHSRVSBindingSource.Current).URMODL = null;

			if (grdLkedKategori.EditValue.ToString() != "")
			{
				var tip = grdLkedKategori.GetSelectedDataRow() as GNTIPI;
				if (tip != null)
				{
					var modelList = _gnthrkService.Cch_GetListByTeknad(global, tip.TEKNAD, false).Items;
					grdLkedModel.Properties.DataSource = modelList;
				}
			}
		}

		private void btnAdayCariEkle_Click(object sender, EventArgs e)
		{
			FrmAdayCari fForm = new FrmAdayCari(global);
			fForm.ShowDialog();

			if (fForm.addedCari != null)
			{
				_cariList.Add(fForm.addedCari);
				cRKODUGridLookUpEdit.Properties.DataSource = _cariList;
				repGrdLkedCari.DataSource = _cariList;
				cRKODUGridLookUpEdit.EditValue = fForm.addedCari.CRAKOD;
			}
		}

		private void btnPdf_Click(object sender, EventArgs e)
		{
			Process.Start(_pdfPath);
		}

		private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
		{
			if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
			{
				if (_action == "update")
				{
					var modelList = _gnthrkService.Cch_GetListByTipKod(global, oldData.URKTGR, false).Items;
					grdLkedModel.Properties.DataSource = modelList;
					grdLkedModel.EditValue = oldData.URMODL;
				}
			}
		}

		private void btnServisAra_Click(object sender, EventArgs e)
		{
			var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();

			if (dtBaslangic == null && string.IsNullOrEmpty(belgeNo))
			{
				MessageBox.Show("Servis talep tarihi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			LoadGrid();

			barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
			barManager.Bars["Tools"].Visible = true;
			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
			xtraTabControl1.SelectedTabPage = xtraTabPage2;
		}

		protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
		{
			sHSRVSBindingSource.CancelEdit();
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

		private async void pdfBut_Click(object sender, EventArgs e)
		{
			SHSRVS servis = (SHSRVS)sHSRVSBindingSource.Current;

			string filePath = await Firestore.CreateServisRapor(servis, new List<STHRKT>(), global);
		}

		private async void btnWord_Click(object sender, EventArgs e)
		{
			SHSRVS servis = (SHSRVS)sHSRVSBindingSource.Current;
			string filePath = await Firestore.CreateServisRapor(servis, new List<STHRKT>(), global, "docx");
			Process.Start(filePath);
		}
	}
}