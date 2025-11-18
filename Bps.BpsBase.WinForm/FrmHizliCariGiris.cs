using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Models.CR.Single;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;

namespace BPS.Windows.Forms
{
	public partial class FrmHizliCariGiris : Form
	{
		public CRCARI sourceCari;
		public List<CRYTKL> sourceYetkiliList = new List<CRYTKL>();
		public CRCARI addedCari;
		private Global _global;

		private readonly ICrcariService _crcariService;
		private readonly IGnthrkService _gnthrkService;
		private readonly IGnevrkService _gnevrkService;

		public FrmHizliCariGiris(Global global)
		{
			_global = global;
			_crcariService = InstanceFactory.GetInstance<ICrcariService>();
			_gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
			_gnevrkService = InstanceFactory.GetInstance<IGnevrkService>();

			InitializeComponent();

			LkEdCariTuru.Properties.DataSource = _gnthrkService.Cch_GetListByTeknad(global, "CRHRKD", false).Items;
		}

		private void FrmHizliCariGiris_Load(object sender, EventArgs e)
		{
			FillFieldsIfAvailable();
		}

		private void FillFieldsIfAvailable()
		{
			if (sourceCari != null)
			{
				txtCariUnvan.Text = sourceCari.CRUNV1;
				txtVergiDairesi.Text = sourceCari.VERGDA;
				txtVergiNo.Text = sourceCari.VERGNO;
			}

			if (sourceYetkiliList != null && sourceYetkiliList.Count > 0)
			{
				txtYetkiliAdi.Text = sourceYetkiliList[0].YETADI;
				txtYetkiliSoyadi.Text = sourceYetkiliList[0].YETSOY;
				txtYetkiliIsTel.Text = sourceYetkiliList[0].ISYTEL;
				txtYetkiliCepTel.Text = sourceYetkiliList[0].CEPTEL;
				txtYetkiliEposta.Text = sourceYetkiliList[0].GNMAIL;
				grpYetkili.Enabled = false;
			}
		}

		private void btnEkle_Click(object sender, EventArgs e)
		{
			string cariHareketKodu = LkEdCariTuru.EditValue.ToString();

			var model = new GenelCariKartModel();
			CRCARI cariKart = new CRCARI();
			CRYTKL crytkl = new CRYTKL();

			if (sourceCari != null)
			{
				cariKart = sourceCari.ShallowCopy();
				cariKart.ADCRKD = cariKart.CRKODU; //Yeni carinin aday kodu şimdikinin cari kodu
				cariKart.CRKODU = "";
				cariKart.CRAKOD = "";
				cariKart.Id = 0;
			}

			if (LkEdCariTuru.EditValue == null || LkEdCariTuru.EditValue.ToString() == "")
			{
				MessageBox.Show("Cari türü seçmediniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				LkEdCariTuru.ShowPopup();
				return;
			}

			if (cariHareketKodu == "9" && cariHareketKodu == cariKart.CRHRKD)
			{
				MessageBox.Show("Cari Türü 'Aday Cari'den farklı olmalı!", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				LkEdCariTuru.ShowPopup();
				return;
			}

			if ( txtCariUnvan.Text == "")
			{
				MessageBox.Show("Cari Ünvan alanları boş olamaz!", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			List<CRCARI> cariList = _crcariService.Cch_GetAllListByTip_NLog(_global, cariHareketKodu, false).Items;
			CRCARI cari = cariList.FirstOrDefault(a => a.CRUNV1 == txtCariUnvan.Text);
			if (cari != null && cari.CRHRKD == cariHareketKodu)
			{
				MessageBox.Show("Bu ünvana sahip bir cari zaten var!", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			cari = cariList.FirstOrDefault(a => a.CRKODU == txtCariKod.Text);
			if (cari != null)
			{
				MessageBox.Show("Bu cari kodu kullanımda!", "Bilgi", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			try
			{
				cariKart.CRHRKD = cariHareketKodu;
				cariKart.CRKODU = crytkl.CRKODU = txtCariKod.Text;
				cariKart.CRAKOD = txtCariKod.Text;
				cariKart.CRUNV1 = txtCariUnvan.Text;
				cariKart.VERGDA = txtVergiDairesi.Text == "" ? "VD" : txtVergiDairesi.Text;
				cariKart.VERGNO = txtVergiNo.Text == "" ? "0" : txtVergiNo.Text;
				var evrakmodel = new EvrakNoUretParamModel();
				evrakmodel.TabloAdi = "CRCARI";
				evrakmodel.TeknikAd = "CRKODU";
				evrakmodel.IslemTur = Convert.ToInt32(cariKart.CRHRKD);
				var _gnevrk = _gnevrkService.Ncch_EvrakNoUret_NLog(_global, evrakmodel);
				if (_gnevrk.Status == ResponseStatusEnum.OK)
				{
					cariKart.CRKODU = _gnevrk.Nesne;
				}
				model.CariKart = cariKart;

				if (sourceYetkiliList != null && sourceYetkiliList.Count > 0)
				{
					foreach (CRYTKL cryt in sourceYetkiliList)
					{
						cryt.Id = 0;
						cryt.CRKODU = cariKart.CRKODU;
					}

					model.Crytkls = sourceYetkiliList;
				}
				else
				{
					crytkl.YETADI = txtYetkiliAdi.Text;
					crytkl.YETSOY = txtYetkiliSoyadi.Text;
					crytkl.ISYTEL = txtYetkiliIsTel.Text;
					crytkl.CEPTEL = txtYetkiliCepTel.Text;
					crytkl.GNMAIL = txtYetkiliEposta.Text;

					model.Crytkls = new List<CRYTKL>();
					model.Crytkls.Add(crytkl);
				}

				var response = _crcariService.Ncch_SaveSingleCari_Log(_global, model);
				if (response.Status != ResponseStatusEnum.OK)
				{
					addedCari = null;
					MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
					return;
				}

				addedCari = response.Nesne;

				Close();
			}
			catch (Exception ex)
			{
				addedCari = null;
				string errorMessage = ex.GetBaseException().Message;
				MessageBox.Show("Kayıt Yapılamadı " + errorMessage);
			}
		}

		private void txtCariUnvan_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (e.Handled = !char.IsUpper(e.KeyChar) && !char.IsControl(e.KeyChar))
			{
				TextBox textBox = ((TextBox)sender);

				e.Handled = true;
				int start = textBox.SelectionStart;
				textBox.Text = textBox.Text.Insert(start, e.KeyChar.ToString().ToUpper());
				textBox.Select(start + 1, 0);
			}
		}
	}
}
