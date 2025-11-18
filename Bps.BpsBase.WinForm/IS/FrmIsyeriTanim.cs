using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Validation;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.IS;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.Core.Entities;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.XtraBars;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BPS.Windows.Forms
{
	public partial class FrmIsyeriTanim : BPS.Windows.Base.FrmChildBase
	{
		private delegate void ThreadCleanControlsDlg();
		private delegate void FrmProgressCloseDlg(FrmProgress frmProgress);

		private IGnevrkService _gnevrkService;
		private IIsyrtnService _isyrtnService;
		private IIsyropService _isyropService;
		private readonly IGnyetkService _gnyetkService;
		private readonly IGnthrkService _gnthrkService;
		private readonly IXXService _xxService;
		private IGnkullService _kullaniciService;
		private BindingList<ISYRTN> _bindingList;
		private ProjeMenuListed yetkiModel;
		private List<TipHareketListModel> TeknadsResponse;
		private List<List<IEntity>> entitiesFromExcel;
		private ISYRTN _isyrtn;
		private List<Grid> focusedRowHandler = new List<Grid>();
		private string _action;
		private bool kayitException;
		private Thread _thread;

		public FrmIsyeriTanim(IGnevrkService gnevrkService, IIsyrtnService isyrtnService, IXXService xxService,
			IGnyetkService gnyetkService, IGnthrkService gnthrkService, IGnkullService kullaniciService, IIsyropService isyropService)
		{
			InitializeComponent();
			_isyrtnService = isyrtnService;
			_xxService = xxService;
			_gnyetkService = gnyetkService;
			_gnthrkService = gnthrkService;
			_gnevrkService = gnevrkService;
			_isyropService = isyropService;
			_kullaniciService = kullaniciService;
			xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
		}

		private void FrmIsyeriTanim_Load(object sender, EventArgs e)
		{
			yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;

			FormIslemleri.FormYetki2(barManager, yetkiModel);
			barManager.Items["barGeri"].Visibility = BarItemVisibility.Never;

			var teknads = new List<string>() { "URYRKD", "SRBRKD", "ISBLKD", "ISOPKD" };
			TeknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false).Items;

			LkEdUretimYeriKod.Properties.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "URYRKD").ToList();
			LkedIsyeriBolum.Properties.DataSource = repLkedIsyeriBolum.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "ISBLKD").ToList();
			LkEdBSB.Properties.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "SRBRKD").ToList();
			LkEdGTB.Properties.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "SRBRKD").ToList();
			LkEdSAB.Properties.DataSource = TeknadsResponse.Where(w => w.TEKNAD == "SRBRKD").ToList();

			LoadGrid();
			//InitValidationRules();
			//dxValidationProvider.ValidationMode = ValidationMode.Auto;
		}

		private void LoadGrid(bool clearFields = true)
		{
			if (clearFields) ClearFields();

			int focusedRow = gridView1.FocusedRowHandle;
			int topRowIndex = gridView1.TopRowIndex;

			gridControl1.DataSource = _isyrtnService.Cch_GetList_NLog(global).Items.OrderBy(i => i.ISBLKD).ThenBy(i => i.ISYKOD).ToList();
			focusedRowHandler.Clear();

			gridView1.FocusedRowHandle = focusedRow;
			gridView1.TopRowIndex = topRowIndex;
		}

		private void ClearFields()
		{
			txtIsYeriKod.Text = "";
			TxtId.Text = "";
			txtTanim.Text = "";
			LkEdUretimYeriKod.EditValue = null;
			LkedIsyeriBolum.EditValue = null;
			txtStandartAdam.Text = "";
			LkEdSAB.EditValue = null;
			txtGTS.Text = "";
			LkEdGTB.EditValue = null;
			txtBeklemeSuresi.Text = "";
			LkEdBSB.EditValue = null;
			chkListOperasyon.DataSource = null;

			DatOlusturma.EditValue = null;
			DatDegistirme.EditValue = null;
			TxtOlusturan.Text = "";
			TxtOlusturan.Properties.AccessibleName = "";
			TxtDegistiren.Text = "";

			if (_isyrtn != null)
			{
				TimOlusturma.Time = _isyrtn.ETARIH == null ? DateTime.Now : (DateTime)_isyrtn.ETARIH;
				TimDegistirme.Time = _isyrtn.DTARIH == null ? DateTime.Now : (DateTime)_isyrtn.DTARIH;
			}

			_isyrtn = new ISYRTN();
		}

		private void InitValidationRules()
		{
			//dxValidationProvider = ValidationRules.GroupControlValidation(groupControl3);
		}

		protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
		{
			groupOperasyon.Enabled = false;
			ClearFields();
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
			_action = "insert";
			////TxtMalzemeTuru.Text = LkEdMalzTuru.Text;


			txtTanim.Focus();
			checkEditAktif.Checked = true;
			xtraTabControl1.SelectedTabPage = xtraTabPage2;
		}

		protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;

			groupOperasyon.Enabled = true;
			ClearFields();
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;

			GetData();
			txtTanim.Focus();
			_action = "update";
			xtraTabControl1.SelectedTabPage = xtraTabPage2;
		}

		protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
		{
			this.Validate();

			if (e.Item.Tag.ToString() == "3" && !VisibleTabPagesReady()) return;
			try
			{
				SaveAllToDatabase();

				gridView1.RefreshData();
				////gridView15.RefreshData();

				focusedRowHandler.Clear();
			}
			catch (DbEntityValidationException ex)
			{
				kayitException = true;
				List<DbEntityValidationResult> valRes = ex.EntityValidationErrors.ToList();
				List<DbValidationError> valErr = valRes[0].ValidationErrors.ToList();
				MessageBox.Show("Kayıt Yapılamadı " + valErr[0].ErrorMessage);
			}
			catch (Exception ex)
			{
				kayitException = true;
				string errorMessage = ex.GetBaseException().Message;

				MessageBox.Show("Kayıt Yapılamadı " + errorMessage);
			}
			finally
			{
				entitiesFromExcel = null;

				if (!kayitException)
				{
					LoadGrid(false);
					FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(2), yetkiModel);
					groupOperasyon.Enabled = true;
					GetData();
					MessageBox.Show("Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
					xtraTabControl1.SelectedTabPage = xtraTabPage1;
				}
				kayitException = false;
			}
		}

		protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (gridView1.FocusedRowHandle < 0 || gridView1.FocusedRowHandle == GridControl.InvalidRowHandle ||
				gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;

			DialogResult Secim;
			Secim = MessageBox.Show("Silmek istediğinizden Emin misiniz ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
			if (Secim == DialogResult.Yes)
			{
				int topRow = gridView1.TopRowIndex;
				int focusedRow = gridView1.FocusedRowHandle;

				gridControl1.DataSource = _isyrtnService.Cch_GetList_NLog(global, false).Items;
				gridView1.BestFitColumns();

				gridView1.TopRowIndex = topRow;
				gridView1.FocusedRowHandle = focusedRow;

				_isyrtnService.Ncch_Delete_Log(_bindingList[Convert.ToInt32(gridView1.GetFocusedDataSourceRowIndex())], global);

				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
				gridView1.RefreshData();
			}
		}

		protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
		{
			ClearFields();
			_isyrtn = null;
			focusedRowHandler.Clear();
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
			////gridViewP13.OptionsBehavior.Editable = false;
			////gridViewP13.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
			xtraTabControl1.SelectedTabPage = xtraTabPage1;
		}

		protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (xtraTabControl1.SelectedTabPage == xtraTabPage1)
			{
				LoadGrid();
				FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
			}
			else barDegistir_ItemClick(barDegistir, e);
		}

		protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
		{
			if (!gridControl1.IsPrintingAvailable)
			{
				MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
				return;
			}

			// Open the Preview window.
			gridView1.ShowRibbonPrintPreview();
		}

		protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
		{
			gridView1.OptionsView.ShowAutoFilterRow = !gridView1.OptionsView.ShowAutoFilterRow;
			////gridViewP13.OptionsView.ShowAutoFilterRow = !gridViewP13.OptionsView.ShowAutoFilterRow;
		}

		protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
		{
			ClearFields();
			_isyrtn = null;
			focusedRowHandler.Clear();
			gridView1.OptionsBehavior.Editable = false;
			gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
			barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
			FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(barVazgec.Tag), yetkiModel);

			xtraTabControl1.SelectedTabPage = xtraTabPage1;
		}

		private bool GetData()
		{
			try
			{
				int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
				_isyrtn = _isyrtnService.Cch_GetById_NLog(id, global, false).Nesne;

				GNKULL yKullanici = _kullaniciService.Cch_GetByUserKod_NLog(_isyrtn.EKKULL, global).Nesne;
				GNKULL dKullanici = _kullaniciService.Cch_GetByUserKod_NLog(_isyrtn.DEKULL, global).Nesne;

				txtIsYeriKod.Text = _isyrtn.ISYKOD;
				TxtId.Text = _isyrtn.Id.ToString();
				txtTanim.Text = _isyrtn.TANIMI;
				LkEdUretimYeriKod.EditValue = _isyrtn.URYRKD;
				LkedIsyeriBolum.EditValue = _isyrtn.ISBLKD;
				txtStandartAdam.Text = _isyrtn.STDADM.ToString();
				LkEdSAB.EditValue = _isyrtn.STADBR;
				txtGTS.Text = _isyrtn.GCTSUR.ToString();
				LkEdGTB.EditValue = _isyrtn.GCTSUB;
				txtBeklemeSuresi.Text = _isyrtn.BEKSUR.ToString();
				LkEdBSB.EditValue = _isyrtn.BEKSUB;

				var isyeriOperasyonList = _isyropService.Ncch_GetListByIsyeriId_NLog(id, global, false).Items;
				var checkList = chkListOperasyon.DataSource as List<TipHareketListModel>;
				if (checkList != null)
				{
					for (int i = 0; i < checkList.Count; i++)
					{
						TipHareketListModel gnthrk = checkList[i];
						var operasyon = isyeriOperasyonList.FirstOrDefault(s => s.ISOPKD == gnthrk.HARKOD);
						if (operasyon != null) chkListOperasyon.SetItemChecked(i, true);
						else chkListOperasyon.SetItemChecked(i, false);
					}
				}


				DatOlusturma.EditValue = _isyrtn.ETARIH;
				TimOlusturma.Time = (DateTime)_isyrtn.ETARIH;
				DatDegistirme.EditValue = _isyrtn.DTARIH;
				TimDegistirme.Time = _isyrtn.DTARIH == null ? DateTime.Now : (DateTime)_isyrtn.DTARIH;
				TxtOlusturan.Text = yKullanici.GNNAME + " " + yKullanici.GNSNAM;
				TxtOlusturan.Properties.AccessibleName = yKullanici.KULKOD;
				TxtDegistiren.Text = dKullanici == null ? "" : (dKullanici.GNNAME + " " + dKullanici.GNSNAM);
				checkEditAktif.EditValue = _isyrtn.ACTIVE;
			}
			catch (Exception ex)
			{
				MessageBox.Show("GetGenelVeriler() " + ex.GetBaseException().Message);
				return false;
			}
			return true;
		}

		private ISYRTN GenelVerilerReadyForTransaction()
		{
			try
			{
				if (_action == "insert")
				{
					//var list = gridControl1.DataSource as List<ISYRTN>;
					//list = list.OrderByDescending(i => i.ISYKOD).ToList();
					//txtIsYeriKod.Text = (Convert.ToInt32(list[0].ISYKOD) + 1).ToString();

					_isyrtn = new ISYRTN();
				}
				else if (_action == "update")
				{
					_isyrtn = new ISYRTN();
					_isyrtn.EKKULL = TxtOlusturan.Properties.AccessibleName;
					_isyrtn.ETARIH = TimOlusturma.Time;
					_isyrtn.Id = TxtId.Text.ToInt32();
				}

				_isyrtn.ACTIVE = true;
				_isyrtn.SLINDI = false;
				string uretimYeriKod = LkEdUretimYeriKod.EditValue == null || LkEdUretimYeriKod.EditValue == "" ? null : LkEdUretimYeriKod.EditValue.ToString();
				string bolumKod = LkedIsyeriBolum.EditValue == null || LkedIsyeriBolum.EditValue == "" ? null : LkedIsyeriBolum.EditValue.ToString();
				string sab = LkEdSAB.EditValue == null || LkEdSAB.EditValue == "" ? null : LkEdSAB.EditValue.ToString();
				string gtb = LkEdGTB.EditValue == null || LkEdGTB.EditValue == "" ? null : LkEdGTB.EditValue.ToString();
				string bsb = LkEdBSB.EditValue == null || LkEdBSB.EditValue == "" ? null : LkEdBSB.EditValue.ToString();

				_isyrtn.ISYKOD = (string)txtIsYeriKod.EditValue;
				_isyrtn.TANIMI = (string)txtTanim.EditValue;
				_isyrtn.URYRKD = uretimYeriKod;
				_isyrtn.ISBLKD = bolumKod;
				_isyrtn.STDADM = txtStandartAdam.EditValue == "" ? (decimal?)null : Convert.ToDecimal(txtStandartAdam.EditValue);
				_isyrtn.STADBR = sab;
				_isyrtn.GCTSUR = txtGTS.EditValue == "" ? (int?)null : Convert.ToInt32(txtGTS.EditValue);
				_isyrtn.GCTSUB = gtb;
				_isyrtn.BEKSUR = txtBeklemeSuresi.EditValue == "" ? (int?)null : Convert.ToInt32(txtBeklemeSuresi.EditValue);
				_isyrtn.BEKSUB = bsb;

				return _isyrtn;
			}
			catch (Exception ex)
			{
				MessageBox.Show("GenelVerilerReadyForTransaction()" + ex.GetBaseException().Message);
				return null;
			}
		}

		private void SaveAllToDatabase()
		{
			if (SaveExcelToDatabase()) return;

			if (_action == "insert")
			{
				var evrakmodel = new EvrakNoUretParamModel();
				evrakmodel.TabloAdi = "ISYRTN";
				evrakmodel.TeknikAd = "ISYKOD";
				evrakmodel.IslemTur = 0;
				var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);

				if (evrakResponse.Status != ResponseStatusEnum.OK)
				{
					MessageBox.Show("İşlem yapılamadı! " + evrakResponse.Message);
					return;
				}

				_isyrtn.ISYKOD = evrakResponse.Nesne;
				var response = _isyrtnService.Ncch_Add_NLog(_isyrtn, global);
				if (response.Status != ResponseStatusEnum.OK)
				{
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
			else if (_action == "update")
			{
				List<string> operasyonList = new List<string>();
				foreach (var checkedItem in chkListOperasyon.CheckedItems)
				{
					var operasyon = checkedItem as TipHareketListModel;
					operasyonList.Add(operasyon.HARKOD);
				}

				var response = _xxService.Ncch_IsyeriOperasyonKaydet_Log(_isyrtn, operasyonList, global, false);
				if (response.Status != ResponseStatusEnum.OK)
				{
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
				}
			}
		}

		private bool SaveExcelToDatabase()
		{
			if (entitiesFromExcel == null) return false;

			foreach (List<IEntity> entityList in entitiesFromExcel)
			{
				foreach (IEntity entity in entityList)
				{
					//switch (entity)
					//{
					//    case StokKart s:
					//        _stokKartService.Add((StokKart)entity);
					//        break;
					//    case StokKartSinif s:
					//        _stokKartSinifService.Add((StokKartSinif)entity);
					//        break;
					//    case StokTanim s:
					//        _stokTanimService.Add((StokTanim)entity);
					//        break;
					//}
				}
			}

			return true;
		}

		private bool VisibleTabPagesReady()
		{
			_isyrtn = GenelVerilerReadyForTransaction();
			if (_isyrtn == null) return false;

			return true;
		}

		private void gridControl1_DoubleClick(object sender, EventArgs e)
		{
			Point point = gridView1.GridControl.PointToClient(MousePosition);
			RowDoubleClick(gridView1, point);
		}

		private void RowDoubleClick(DevExpress.XtraGrid.Views.Grid.GridView gridView, Point point)
		{
			GridHitInfo info = gridView.CalcHitInfo(point);
			if (info.InRow || info.InRowCell)
			{
				var link = barDegistir.GetVisibleLinks()[0];
				ItemClickEventArgs e = new ItemClickEventArgs(barDegistir, link);
				barDegistir_ItemClick(barDegistir, e);
			}
		}

		private void navButton34_ElementClick(object sender, NavElementEventArgs e)
		{
			OpenFileDialog fdlg = new OpenFileDialog();
			fdlg.Title = "Dosya seç";
			fdlg.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
			fdlg.Filter = "Excel 2007(*.xlsx)|*.xlsx|Excel 2003(*.xls)|*.xls";
			fdlg.FilterIndex = 1;
			fdlg.RestoreDirectory = true;

			if (fdlg.ShowDialog() == DialogResult.OK)
			{
				entitiesFromExcel = new List<List<IEntity>>();

				_thread = new Thread(new ParameterizedThreadStart(ThreadMethod));
				_thread.ApartmentState = ApartmentState.STA;
				_thread.IsBackground = true;

				FrmProgress frmProgress = new FrmProgress(_thread);
				frmProgress.NavBaslik.Caption = "Excel'den alınıyor...";

				object[] threadParams = new object[] { frmProgress, fdlg.FileName };
				_thread.Start(threadParams);

				frmProgress.ShowDialog();
			}
			else
			{
				entitiesFromExcel = null;
				return;
			}
		}

		private void ThreadMethod(object threadParams)
		{
			object[] obj = (object[])threadParams;
			FrmProgress frmProgress = (FrmProgress)obj[0];
			string excelPath = obj[1].ToString();

			SaveExcelToDatabase(frmProgress, excelPath);
		}

		private void SaveExcelToDatabase(FrmProgress frmProgress, string excelPath, int skIndex = 0, bool recursiveCall = false, int completed = 0)
		{
			if (entitiesFromExcel == null) return;

			Control[] frmControls = new Control[] { frmProgress.lblTablo, frmProgress.lblToplamKayit,
					frmProgress.lblAktarilanKayit, frmProgress.lblYuzde, frmProgress.progressBar };

			if (!recursiveCall)
			{
				entitiesFromExcel = FormIslemleri.GetEntitiesFromExcel(excelPath, global.UserId.ToString(), frmControls);
			}

			int transactionCount = 0;
			byte stkKart = 0;
			int totalEntity = 0;
			bool success = true;


			for (byte i = 0; i < entitiesFromExcel.Count; i++)
			{
				try
				{
					if (entitiesFromExcel[i][0] is STKART) stkKart = i;
					totalEntity += entitiesFromExcel[i].Count;
				}
				catch (Exception ex)
				{
					//MessageBox.Show(ex.GetBaseException().Message);
					continue;
				}
			}

			frmProgress.NavBaslik.Caption = "Veritabanına aktarılıyor...";

			////using (TransactionScope ts = new TransactionScope())
			////{
			////    try
			////    {
			////        if (entitiesFromExcel == null) return;

			////        for (int i = skIndex; i < entitiesFromExcel[stkKart].Count; i++)
			////        {
			////            STKART sEntity = (STKART)entitiesFromExcel[stkKart][i];
			////            _cariKartService.Ncch_Add_NLog(sEntity,global);
			////            string stokKodu = sEntity.STKODU;
			////            completed++;

			////            foreach (Control control in frmControls)
			////            {
			////                FormIslemleri.UpdateControlText(control, sEntity.GetType().ToString(), completed, totalEntity);
			////            }

			////            for (int j = 0; j < entitiesFromExcel.Count; j++)
			////            {
			////                if (j == stkKart) continue;
			////                for (int k = 0; k < entitiesFromExcel[j].Count; k++)
			////                {
			////                    IEntity entity = entitiesFromExcel[j][k];
			////                    //switch (entity)
			////                    //{
			////                    //    case StokKartSinif s:
			////                    //        if (s.StokKodu == stokKodu)
			////                    //        {
			////                    //            _stokKartSinifService.Add((StokKartSinif)entity);
			////                    //            completed++;
			////                    //        }
			////                    //        break;
			////                    //    case StokTanim s:
			////                    //        if (s.StokKodu == stokKodu)
			////                    //        {
			////                    //            _stokTanimService.Add((StokTanim)entity);
			////                    //            completed++;
			////                    //        }
			////                    //        break;
			////                    //}
			////                    foreach (Control control in frmControls)
			////                    {
			////                        FormIslemleri.UpdateControlText(control, entity.GetType().ToString(), completed, totalEntity);
			////                    }
			////                }
			////            }

			////            transactionCount++;
			////            if (transactionCount == 10)
			////            {
			////                ts.Complete();
			////                ts.Dispose();
			////                SaveExcelToDatabase(frmProgress, excelPath, i + 1, true, completed);
			////                if (entitiesFromExcel == null) return;
			////            }
			////            else if (i == entitiesFromExcel[stkKart].Count - 1)
			////            {
			////                ts.Complete();
			////                ts.Dispose();
			////                FrmProgressClose(frmProgress);
			////            }
			////        }
			////        ThreadCleanControls();
			////    }
			////    catch (Exception ex)
			////    {
			////        ts.Complete();
			////        ts.Dispose();
			////        success = false;
			////        FrmProgressClose(frmProgress);
			////        MessageBox.Show("Kayıt Yapılamadı " + ex.GetBaseException().ToString());
			////    }
			////}
		}

		private void ThreadCleanControls()
		{
			if (InvokeRequired)
			{
				ThreadCleanControlsDlg del = new ThreadCleanControlsDlg(ThreadCleanControls);
				Invoke(del);
			}
			else
			{
				entitiesFromExcel = null;
				focusedRowHandler.Clear();
				FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(barVazgec.Tag), yetkiModel);
				////gridViewP13.OptionsBehavior.Editable = false;
				////gridViewP13.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
				xtraTabControl1.SelectedTabPage = xtraTabPage1;
			}
		}

		private void FrmProgressClose(FrmProgress frmProgress)
		{
			if (InvokeRequired)
			{
				FrmProgressCloseDlg del = new FrmProgressCloseDlg(FrmProgressClose);
				Invoke(del, frmProgress);
			}
			else
			{
				frmProgress.Close();
			}
		}

		private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
		{
			GridView gridView = (GridView)sender;
			GridControl gridControl = gridView.GridControl;
			Stream s = new MemoryStream();
			gridView.SaveLayoutToStream(s);
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

		private void LkedIsyeriRota_EditValueChanged(object sender, EventArgs e)
		{
			chkListOperasyon.DataSource = null;

			if (LkedIsyeriBolum.EditValue != null && LkedIsyeriBolum.EditValue.ToString() != "")
			{
				var tip = LkedIsyeriBolum.GetSelectedDataRow() as TipHareketListModel;
				chkListOperasyon.DataSource = TeknadsResponse.Where(t => t.PARENT == tip.Id).ToList();
				//if (!string.IsNullOrEmpty(_isyrtn.ISOPKD)) repLkedOperasyon.EditValue = _isyrtn.ISOPKD;
			}
		}
	}
}
