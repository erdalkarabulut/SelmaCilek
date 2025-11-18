using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.DataAccess.Abstract.CR;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.CR.Single;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;

namespace BPS.Windows.Forms
{
    public partial class FrmAdayCari : Form
    {
        public CRCARI addedCari;
        private Global _global;

        private readonly ICrcariService _crcariService;

        public FrmAdayCari(Global global)
        {
            _global = global;
            _crcariService = InstanceFactory.GetInstance<ICrcariService>();
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtCariUnvan.Text == "") return;

            List<CRCARI> adayCariList = _crcariService.Cch_GetAllListByTip_NLog(_global, "9", false).Items;
            CRCARI cari = adayCariList.FirstOrDefault(a => a.CRUNV1 == txtCariUnvan.Text);
            if (cari != null)
            {
                MessageBox.Show("Bu ünvana sahip bir cari zaten var!", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            //string crkodu = adayCariList.Max(c => c.CRKODU);
            string crkodu = adayCariList[0].CRKODU;
            int crkoduInt = Convert.ToInt32(crkodu) + 1;
            crkodu = string.Format("{0:0000000}", crkoduInt);

            try
            {
                CRCARI cariKart = new CRCARI();
                CRYTKL crytkl = new CRYTKL();

                cariKart.CRHRKD = "9";
                cariKart.CRKODU = crytkl.CRKODU = crkodu;
                cariKart.CRAKOD = crkodu;
                cariKart.CRUNV1 = txtCariUnvan.Text;
                cariKart.VERGDA = txtVergiDairesi.Text == "" ? "VD" : txtVergiDairesi.Text;
                cariKart.VERGNO = txtVergiNo.Text == "" ? "0" : txtVergiNo.Text;

                crytkl.YETADI = txtYetkiliAdi.Text;
                crytkl.YETSOY = txtYetkiliSoyadi.Text;
                crytkl.ISYTEL = txtYetkiliIsTel.Text;
                crytkl.CEPTEL = txtYetkiliCepTel.Text;
                crytkl.GNMAIL = txtYetkiliEposta.Text;

                var model = new GenelCariKartModel();
                model.CariKart = cariKart;
                model.Crytkls = new List<CRYTKL>();
                model.Crytkls.Add(crytkl);

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

        private void txtCariUnvan_KeyUp(object sender, KeyEventArgs e)
        {

        }

        private void txtCariUnvan_TextChanged(object sender, EventArgs e)
        {
            TextBox textBox = ((TextBox)sender);

            textBox.SelectionStart = textBox.Text.Length;
            textBox.Text = textBox.Text.ToUpper();
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
