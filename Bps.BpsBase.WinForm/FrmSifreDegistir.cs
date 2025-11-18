using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.GlobalStaticsVariables;
using DevExpress.XtraEditors;

namespace BPS.Windows.Forms
{
	public partial class FrmSifreDegistir : DevExpress.XtraEditors.XtraForm
	{
		private IGnkullService _gnkullService;
		private Global _global;
		private GNKULL _gnkull;

		public FrmSifreDegistir(Global global)
		{
			_global = global;
			_gnkullService = InstanceFactory.GetInstance<IGnkullService>();
			InitializeComponent();
		}

		private void FrmSifreDegistir_Load(object sender, EventArgs e)
		{
			_gnkull =  _gnkullService.Cch_GetByUserKod_NLog(_global.UserKod, _global).Nesne;
		}

		private void btnSKaydet_Click(object sender, EventArgs e)
		{
			if (txtMevcutSifre.Text == "" || txtYeniSifre.Text == "" || txtYeniSifreTekrar.Text == "")
			{
				MessageBox.Show("Lütfen tüm alanları doldurun!", "Uyarı", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			if (txtYeniSifre.Text.Length < 4 || txtYeniSifreTekrar.Text.Length < 4)
			{
				MessageBox.Show("Yeni şifreniz 4 karakterden az olamaz!", "Uyarı", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			if (txtMevcutSifre.Text != _gnkull.PASSWD)
			{
				MessageBox.Show("Mevcut şifrenizi yanlış girdiniz!", "Uyarı", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			if (txtYeniSifre.Text != txtYeniSifreTekrar.Text)
			{
				MessageBox.Show("Yeni şifreler eşleşmiyor!", "Uyarı", MessageBoxButtons.OK,
					MessageBoxIcon.Information);
				return;
			}

			GNKULL gnkull = _gnkull.ShallowCopy();
			gnkull.PASSWD = txtYeniSifre.Text;
			gnkull = _gnkullService.Ncch_ChangePassword_NLog(_global, gnkull).Nesne;

			if (gnkull != null)
			{
				MessageBox.Show("Şifreniz değişti!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
				Close();
			}
		}
	}
}