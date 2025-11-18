using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.MH;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.BpsBase.Entities.Models.CR.Listed;
using Bps.BpsBase.Entities.Models.CR.Single;
using Bps.BpsBase.Entities.Models.GN.Enums;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.Entities.Models.ST.Enums;
using Bps.Core.Response;
using Bps.Core.Utilities.Helpers;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using GridView = DevExpress.XtraGrid.Views.Grid.GridView;

namespace BPS.Windows.Forms
{
	public partial class FrmCariKart : Base.FrmChildBase
	{
		private ICrcariService _cariKartService;
		private ICrytklService _crytklService;
		private ICrbankService _crbankService;
		private ICradrsService _cradrsService;
		private IMhhsplService _mhhsplService;

		private static CRCARI oldData;
		private ProjeMenuListed yetkiModel;
		private IGnyetkService _gnyetkService;
		private IGnthrkService _gnthrkService;
		private IGnlkhrService _gnlkhrService;
		private IGnevrkService _gnevrkService;

		private string _action;
		private List<Grid> focusedRowHandler = new List<Grid>();
		List<CRCARI> adayCariList = new List<CRCARI>();
		private bool ayniKayit;

		public FrmCariKart(ICrcariService cariKartService, ICrytklService crytklService, ICrbankService crbankService,
			ICradrsService cradrsService, IMhhsplService mhhsplService, IGnyetkService gnyetkService,
			IGnthrkService gnthrkService, IGnlkhrService gnlkhrService, IGnevrkService gnevrkService)
		{
			_cariKartService = cariKartService;
			_gnyetkService = gnyetkService;
			_cradrsService = cradrsService;
			_gnthrkService = gnthrkService;
			_gnlkhrService = gnlkhrService;
			_crytklService = crytklService;
			_crbankService = crbankService;
			_mhhsplService = mhhsplService;
			_gnevrkService = gnevrkService;
			InitializeComponent();
			xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
		}

		private void TemplateForm_Load(object sender, EventArgs e)
		{
			xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
			yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
			FormIslemleri.FormYetki2(barManager, yetkiModel);
			barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;

			var teknads = new List<string>() { "CRHRKD", "CRBGKD", "DVCNKD" };
			var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

			var ulkeList = _gnlkhrService.Cch_GetListByTipKod(global, "001", false).Items;
			repLkeUlke.DataSource = ulkeList;


			var cariTurList = teknadsResponse.Items.Where(w => w.TEKNAD == "CRHRKD").ToList();
			var dovizCinsList = teknadsResponse.Items.Where(w => w.TEKNAD == "DVCNKD").ToList();

			var muhHesapPlanList = _mhhsplService.Cch_GetList_NLog(global, false).Items;

			LkEdCariTuru.Properties.DataSource = cariTurList;
			LkEdCariTur.Properties.DataSource = cariTurList;
			LkEdCariBaglanti.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "CRBGKD").ToList();
			LkEdDovizCins.Properties.DataSource = dovizCinsList;
			LkEdDovizCins1.Properties.DataSource = dovizCinsList;
			LkEdDovizCins2.Properties.DataSource = dovizCinsList;
			LkEdStokAlimCins.Properties.DataSource = EnumHelper.GetListItemsFromEnum<StokAlimSatimEnum>();
			LkEdStokSatimCins.Properties.DataSource = EnumHelper.GetListItemsFromEnum<StokAlimSatimEnum>();

			LkEdMHK1.Properties.DataSource = muhHesapPlanList;
			LkEdMHK2.Properties.DataSource = muhHesapPlanList;
			LkEdMHK3.Properties.DataSource = muhHesapPlanList;
			LkEdCariOdemeCins.Properties.DataSource = EnumHelper.GetListItemsFromEnum<CariOdemeCinsEnum>();
			LkEdKurHesaplamaSekli.Properties.DataSource = EnumHelper.GetListItemsFromEnum<KurHesapEnum>();
			LkEdOdemeGun.Properties.DataSource = EnumHelper.GetListItemsFromEnum<GunEnum>();
			LkEdOdemeTercih.Properties.DataSource = EnumHelper.GetListItemsFromEnum<OdemeTercihEnum>();

			GridHelper.ColumnRepositoryItems(gridViewBanka, global);
			GridHelper.ColumnRepositoryItems(gridViewYetki, global);
		}

		private void LoadGrid()
		{
			if (LkEdCariTuru.EditValue == null) return;
			var cariTip = LkEdCariTuru.EditValue.ToString();
			cRCARIBindingSource.DataSource = _cariKartService.Cch_GetListByTip_NLog(global, cariTip, false).Items;
			adayCariList = _cariKartService.Cch_GetAllListByTip_NLog(global, "9", false).Items.OrderByDescending(a => a.ETARIH).ToList();

			gridView1.BestFitColumns();
		}

		private void LkEdCariTuru_EditValueChanged(object sender, EventArgs e)
		{
			LoadGrid();
		}

		#region Standard

		protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
		{
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			_action = "insert";

			txtCariKodu.Enabled = true;

			cRCARIBindingSource.AddNew();
			var crcari = (CRCARI)cRCARIBindingSource.Current;

			var cariTip = LkEdCariTuru.EditValue.ToString();
			string cariKodu = "";

			if (cariTip == "9")
			{
				//txtCariKodu.Enabled = false;
				//txtCariAnaKodu.Enabled = false;

				//string crkodu = adayCariList.Max(c => c.CRKODU);
				string crkodu = adayCariList[0].CRKODU;
				int crkoduInt = Convert.ToInt32(crkodu) + 1;
				crkodu = string.Format("{0:0000000}", crkoduInt);

				crcari.CRKODU = txtCariKodu.Text = txtCariAnaKodu.Text = crkodu;
			}

			if (crcari != null)
			{
				cariKodu = txtCariKodu.Text;

				crcari.CRKODU = cariKodu;
				crcari.CRAKOD = cariKodu;
				crcari.ACTIVE = true;
				crcari.ETARIH = DateTime.Today;
				crcari.EKKULL = global.UserKod;
				crcari.EFATUR = false;
				crcari.OTVTEV = false;
				crcari.CRHRKD = cariTip;
				LkEdCariTur.EditValue = cariTip;

				LkEdFaturaAdrNo.Properties.DataSource = null;
				LkEdSevkAdrNo.Properties.DataSource = null;
			}

			cRYTKLBindingSource.DataSource = new CRYTKL();
			cRBANKBindingSource.DataSource = new CRBANK();
			cRADRSBindingSource.DataSource = new CRADRS();

			//txtCariKodu.Enabled = true;
			txtCariUnvan1.Focus();

			xtraTabControl1.SelectedTabPage = xtraTabPage2;
			xtraTabControl2.SelectedTabPage = xtraTabPage3;
		}

		protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			_action = "update";
			txtCariKodu.Enabled = false;
			oldData = ((CRCARI)cRCARIBindingSource.Current).ShallowCopy();


			if (oldData == null) return;

			var cariKodu =oldData.CRKODU;
			var adresList = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKodu, false).Items;
			LkEdFaturaAdrNo.Properties.DataSource = adresList;
			LkEdSevkAdrNo.Properties.DataSource = adresList;
			repCrYtklAdres.DataSource = adresList;

			cRYTKLBindingSource.DataSource = _crytklService.Cch_GetListByCariKod_NLog(cariKodu, global, false).Items;
			cRBANKBindingSource.DataSource = _crbankService.Cch_GetListByCariKod_NLog(cariKodu, global, false).Items;
			cRADRSBindingSource.DataSource = adresList;

			xtraTabControl1.SelectedTabPage = xtraTabPage2;
			xtraTabControl2.SelectedTabPage = xtraTabPage3;


			SetAdayAsilCariControls();
		}

		private void SetAdayAsilCariControls()
		{
			lblAdayCariKodu.Visible = false;
			txtAdayCariKodu.Visible = false;
			lblAsilCariKodu.Visible = false;
			txtAsilCariKodu.Visible = false;
			btnAsilCari.Visible = false;

			CRCARI cari = (CRCARI)cRCARIBindingSource.Current;

			if (!string.IsNullOrEmpty(cari.ADCRKD))
			{
				lblAdayCariKodu.Visible = true;
				txtAdayCariKodu.Visible = true;
			}

			if (!string.IsNullOrEmpty(cari.ASCRKD))
			{
				lblAsilCariKodu.Visible = true;
				txtAsilCariKodu.Visible = true;
			}

			if (cari.CRHRKD == "9" && string.IsNullOrEmpty(cari.ASCRKD))
			{
				btnAsilCari.Visible = true;
			}
		}

		protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
		{
			this.Validate();
			try
			{
				var crcari = (CRCARI)cRCARIBindingSource.Current;

				CRCARI cari = adayCariList.FirstOrDefault(a => a.CRUNV1 == txtCariUnvan1.Text);
				if (cari != null && cari.Id != crcari.Id)
				{
					MessageBox.Show("Bu ünvana sahip bir cari zaten var!", "Bilgi", MessageBoxButtons.OK,
						MessageBoxIcon.Information);
					return;
				}
                if (_action == "insert")
                {
					var evrakmodel = new EvrakNoUretParamModel();
					evrakmodel.TabloAdi = "CRCARI";
					evrakmodel.TeknikAd = "CRKODU";
					evrakmodel.IslemTur = Convert.ToInt32(crcari.CRHRKD);
					var _gnevrk = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);
					if (_gnevrk.Status == ResponseStatusEnum.OK)
					{
						txtCariKodu.Text = crcari.CRKODU = _gnevrk.Nesne;
					}
				}
                
				

				crcari.CRKODU = txtCariAnaKodu.Text = txtCariKodu.Text;
				cRCARIBindingSource.EndEdit();

				var model = new GenelCariKartModel();

				crcari.CRAKOD = crcari.CRKODU; //BALA için yapıldı
				model.CariKart = crcari;

				//////// CRYTKL ///////////////////// Eklerken zorunluysa aç
				var crYtklList = cRYTKLBindingSource.List;
				model.Crytkls = new List<CRYTKL>();
				foreach (var bind in crYtklList)
				{
					model.Crytkls.Add((CRYTKL)bind);
				}

				//////// CRBANK /////////////////////
				//var crBankList = cRBANKBindingSource.List;
				//model.Crbanks = new List<CRBANK>();
				//foreach (var bind in crBankList)
				//{
				//    model.Crbanks.Add((CRBANK)bind);
				//}

				var response = _cariKartService.Ncch_CariSaving_Log(global, model, focusedRowHandler);
				if (response.Status != ResponseStatusEnum.OK)
				{
					if (response.Message == "Aynı kayıt tekrar girilemez!")
					{
						ayniKayit = true;
					}
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				LoadGrid();
				SetAdayAsilCariControls();
				_action = "";
				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
				xtraTabControl1.SelectedTabPage = xtraTabPage1;
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
				cRCARIBindingSource.EndEdit();
				var data = (CRCARI)cRCARIBindingSource.Current;
				_cariKartService.Ncch_Delete_Log(data, global);
				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
				LoadGrid();
			}
		}

		protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
		{
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			cRCARIBindingSource.CancelEdit();
			cRYTKLBindingSource.DataSource = new CRYTKL();
			cRBANKBindingSource.DataSource = new CRBANK();
			cRADRSBindingSource.DataSource = new CRADRS();
			gridView1.OptionsBehavior.Editable = false;
			gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
			LoadGrid();
			gridView1.RefreshData();
			xtraTabControl1.SelectedTabPage = xtraTabPage1;
			oldData = null;
		}

		protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
		{
			FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
			cRCARIBindingSource.CancelEdit();

			LoadGrid();
			xtraTabControl1.SelectedTabPage = xtraTabPage1;
			oldData = null;
		}

		protected override void barOrtamBelgeAkisi_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.GetFocusedRowCellValue("Id") == null)
			{
				MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
			FrmBelgeAkis form = new FrmBelgeAkis(global, "DOVKUR", id);
			form.ShowDialog();
		}

		protected override void barOrtamEk_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.GetFocusedRowCellValue("Id") == null)
			{
				MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				return;
			}

			int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
			FrmFileManager form = new FrmFileManager(global, "CRCARI", id);
			form.ShowDialog();
		}

		protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!gridControl1.IsPrintingAvailable)
			{
				MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
				return;
			}
			gridView1.ShowRibbonPrintPreview();
		}

		protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
		{
			gridView1.OptionsView.ShowAutoFilterRow = !gridView1.OptionsView.ShowAutoFilterRow;
		}

		protected override bool ProcessDialogKey(Keys keyData)
		{
			if (keyData == Keys.Escape)
			{
				if (!barVazgec.Enabled) base.ProcessDialogKey(keyData);

				DialogResult Secim;
				Secim = MessageBox.Show("Emin misiniz ?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
				if (Secim == DialogResult.Yes)
				{
					barVazgec_ItemClick(barManager, new ItemClickEventArgs(barVazgec, barVazgec.Links[0]));
				}
				return true;
			}
			return base.ProcessDialogKey(keyData);
		}

		private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
		{
			Stream s = new MemoryStream();
			gridView1.SaveLayoutToStream(s);
			s.Seek(0, SeekOrigin.Begin);
			StreamReader sr = new StreamReader(s);
			FrmGridXml gridXml = new FrmGridXml(global);
			gridXml._kullaniciId = global.UserId.ToString();
			gridXml._moduladi = global.ProjeTanim;
			gridXml._menutag = global.MenuTag.ToString();
			gridXml._gridtag = gridControl1.Tag.ToString();
			gridXml._xml = sr.ReadToEnd();
			GridHelper.gridView_PopupMenuShowing(sender, e, gridXml, gridControl1.Tag.ToString(), gridView1);
		}

		private void gridView_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			GridView view = sender as GridView;
			if (view == null) return;
			if (view.GetRowCellValue(e.RowHandle, view.Columns["Id"]) == null) return;

			var cellValue = (int)view.GetRowCellValue(e.RowHandle, view.Columns["Id"]);
			if (cellValue > 0)
			{
				var a = focusedRowHandler.FirstOrDefault(x => x.Id == cellValue);

				if (a == null)
				{
					focusedRowHandler.Add(new Grid(cellValue, "update", view.Tag.ToString()));
				}
			}
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

		#endregion

		private void gridViewYetki_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var crCari = (CRCARI)cRCARIBindingSource.Current;
			if (crCari != null)
			{
				gridViewYetki.SetRowCellValue(e.RowHandle, gridViewYetki.Columns["CRKODU"], crCari.CRKODU);
			}
			gridViewYetki.SetRowCellValue(e.RowHandle, gridViewYetki.Columns["ACTIVE"], true);
		}

		private void gridViewBanka_InitNewRow(object sender, InitNewRowEventArgs e)
		{
			var crCari = (CRCARI)cRCARIBindingSource.Current;
			if (crCari != null)
			{
				gridViewBanka.SetRowCellValue(e.RowHandle, gridViewBanka.Columns["CRKODU"], crCari.CRKODU);
			}
			gridViewBanka.SetRowCellValue(e.RowHandle, gridViewBanka.Columns["ACTIVE"], true);
		}

		private void repLkeUlke_EditValueChanged(object sender, EventArgs e)
		{

			var newe = (ChangingEventArgs)e;

			if (newe.OldValue == null)
			{
				return;
			}

			var data = newe.NewValue as GNLKHR;

			repLkeIl.DataSource = null;
			repLkeIlce.DataSource = null;

			if (data != null)
			{
				var sehirList = _gnlkhrService.Cch_GetListByTipKodAndParent(global, "002", data.Id, false).Items;
				repLkeIl.DataSource = sehirList;

				//current.SEHRKD = current.SEHRKD;
			}
		}

		private void repLkeIl_EditValueChanged(object sender, EventArgs e)
		{
			var baseEdit = (BaseEdit)sender;
			if (baseEdit.OldEditValue.ToString() == "")
			{
				return;
			}

			var newe = (ChangingEventArgs)e;

			var current = (CRADRS)cRADRSBindingSource.Current;
			var data = newe.NewValue as GNLKHR;

			repLkeIlce.DataSource = null;
			if (current.SEHRKD != null && data != null)
			{
				var ilceList = _gnlkhrService.Cch_GetListByTipKodAndParent(global, "003", data.Id, false).Items;
				repLkeIlce.DataSource = ilceList;

				current.ILCEKD = current.ILCEKD;
			}
		}

		private void repLkeIlce_EditValueChanged(object sender, EventArgs e)
		{

		}

		private void btnMuhasebeProgrami_Click(object sender, EventArgs e)
		{
			if (LkEdCariTuru.EditValue == null || LkEdCariTuru.EditValue.ToString() == "")
			{
				MessageBox.Show("Cari türü seçmediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				LkEdCariTuru.ShowPopup();
				return;
			}

			string crhrkd = LkEdCariTuru.EditValue.ToString();

			FrmExternalCari eForm = new FrmExternalCari(global, crhrkd);
			eForm.ShowDialog();

			if (eForm.refresh) LoadGrid();
		}

		private void btnHizliCari_Click(object sender, EventArgs e)
		{
			string cariKodu = "";

			List<CRCARI> caris = cRCARIBindingSource.DataSource as List<CRCARI>;
			if (caris != null && caris.Count > 0)
			{
				caris = caris.OrderBy(c => c.CRKODU).ToList();
				CRCARI cari = caris.Last();
				cariKodu = cari.CRKODU.Substring(0, 4);

				bool allDigits = true;
				string cariSub = cari.CRKODU.Substring(4);
				foreach (char c in cariSub)
				{
					if (!char.IsDigit(c))
					{
						allDigits = false;
						break;
					}
				}

				if (allDigits)
				{
					int siraNo = Convert.ToInt32(cariSub) + 1;
					cariKodu += siraNo.ToString("D5");
				}
				else cariKodu = "";
			}

			FrmHizliCariGiris fForm = new FrmHizliCariGiris(global);
			fForm.LkEdCariTuru.EditValue = LkEdCariTuru.EditValue;
			fForm.txtCariKod.Text = cariKodu;
			fForm.ShowDialog();

			if (fForm.addedCari != null)
			{
				barYenile_ItemClick(null, null);
				MessageBox.Show("Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

				//gridView1.LocateByValue("CRKODU", fForm.addedCari.CRKODU);
			}
		}

		private void btnAsilCari_Click(object sender, EventArgs e)
		{
			var crcari = (CRCARI)cRCARIBindingSource.Current;
			List<CRYTKL> yetkiliList = cRYTKLBindingSource.DataSource as List<CRYTKL>;

			FrmHizliCariGiris frmHizliCari = new FrmHizliCariGiris(global);
			frmHizliCari.sourceCari = crcari;
			frmHizliCari.sourceYetkiliList = yetkiliList;

			frmHizliCari.ShowDialog();

			if (frmHizliCari.addedCari != null)
			{
				crcari.ASCRKD = frmHizliCari.addedCari.CRKODU;
				barKaydet.PerformClick();

			}
		}
	}
}