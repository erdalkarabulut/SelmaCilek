using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Listed;
using DevExpress.XtraEditors;
using Microsoft.Office.Interop.Excel;
using Global = Bps.Core.GlobalStaticsVariables.Global;

namespace BPS.Windows.Forms.SP
{
    public partial class FrmEksikPaketEdit : DevExpress.XtraEditors.XtraForm
    {
        private SiparisPaketIhtiyac _paketIhtiyac;
        private Global _global;
        private readonly ISphrplService _sphrplService;

        public FrmEksikPaketEdit(SiparisPaketIhtiyac pIhtiyac, Global global)
        {
            InitializeComponent();
            _paketIhtiyac = pIhtiyac;
            _global = global;
            _sphrplService = InstanceFactory.GetInstance<ISphrplService>();
        }

        private void FrmEksikPaketEdit_Load(object sender, EventArgs e)
        {
            txtBelgen.Text = _paketIhtiyac.BELGEN;
            txtSiparisTarihi.Text = _paketIhtiyac.BELTRH.ToShortDateString();
            txtTerminTarihi.Text = _paketIhtiyac.TERTAR.Value.ToShortDateString();
            txtMusteri.Text = _paketIhtiyac.CRUNV1;
            txtModulKodu.Text = _paketIhtiyac.MDKODU;
            txtModulAdi.Text = _paketIhtiyac.MDLNAM;
            txtSiparisMiktari.Text = _paketIhtiyac.SPMKTR.ToString();
            txtSiparisTuru.Text = _paketIhtiyac.TANIMI;
            txtAciklama.Text = _paketIhtiyac.BSACIK;

            txtPaketKodu.Text = _paketIhtiyac.PKKODU;
            txtPaketAdi.Text = _paketIhtiyac.PKTNAM;
            txtIhtiyac.Text = _paketIhtiyac.IHTIYC.ToString();

            GetPaketPlanList();
        }

        private void GetPaketPlanList()
        {
            List<SPHRPL> sphrplList = _sphrplService
                .Ncch_GetListBySiparisPaketBilgi_NLog(_paketIhtiyac.BELGEN, _paketIhtiyac.SATIRN, _paketIhtiyac.PKKODU, _global, false)
                .Items;

            gridControl1.DataSource = sphrplList;
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            decimal planMiktar = 0;
            decimal.TryParse(txtPlanMiktar.Text, out planMiktar);

            if (planMiktar <= 0)
            {
                MessageBox.Show("Planlanan miktar 0'dan büyük olmalı!", "Hata", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            DialogResult Secim;
            Secim = MessageBox.Show("Emin misiniz?", "Plan Kayıt", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Secim != DialogResult.Yes) return;

            SPHRPL sphrpl = new SPHRPL
            {
                ACTIVE = true,
                SLINDI = false,
                CHKCTR = false,

                BELGEN = _paketIhtiyac.BELGEN,
                GNREZV = _paketIhtiyac.GNREZV,
                URAKOD = _paketIhtiyac.URAKOD,
                SATIRN = _paketIhtiyac.SATIRN,
                PKKODU = _paketIhtiyac.PKKODU,
                PKTNAM = _paketIhtiyac.PKTNAM,
                ACIKLM = txtPlanAciklama.Text,
                PLNMKT = planMiktar
            };

            _sphrplService.Ncch_AddWithoutYetki_NLog(sphrpl, _global);
            GetPaketPlanList();
            //else
            //{
            //    SPHRPL oldSphrpl = _sphrpl.ShallowCopy();

            //    _sphrpl.ACIKLM = txtPlanAciklama.Text;
            //    //_sphrpl.PLNMKT = planMiktar + oncedenPlanlanan;
            //    _sphrplService.Ncch_UpdateWithoutYetki_Log(_sphrpl, oldSphrpl, _global);
            //    Close();
            //}
        }

        private void repButtonSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Emin misiniz?", "Plan Sil", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
            if (Secim != DialogResult.Yes) return;

            SPHRPL sphrpl = gridView1.GetFocusedRow() as SPHRPL;
            _sphrplService.Ncch_DeleteWithoutYetki_Log(sphrpl, _global);
            GetPaketPlanList();
        }
    }
}