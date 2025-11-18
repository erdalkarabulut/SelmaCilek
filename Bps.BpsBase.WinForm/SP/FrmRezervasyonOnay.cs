using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.Core.Response;
using DevExpress.XtraEditors;

namespace BPS.Windows.Forms.SP
{
    public partial class FrmRezervasyonOnay : XtraForm
    {
        public FrmSiparisRezervasyon frmSiparisRez;

        private IXXService _xxService;

        public FrmRezervasyonOnay()
        {
            _xxService = InstanceFactory.GetInstance<IXXService>();

            InitializeComponent();
        }

        private void FrmRezervasyonOnay_Load(object sender, EventArgs e)
        {
            List<SpRezervasyonOzet> rezList = frmSiparisRez.GetSiparisRezervasyon(false);
            if (rezList.Count > 0) rezList = rezList.FindAll(r => r.RZMKTR < r.SPMKTR);
            

            gridRezervasyon.DataSource = rezList;
            grdVwRezervasyon.BestFitColumns();
        }

        private void grdVwRezervasyon_ValidatingEditor(object sender, DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventArgs e)
        {
            decimal miktar;
            decimal.TryParse(e.Value.ToString(), out miktar);
            if (miktar < 0) miktar = 0;
            else
            {
                decimal spmktr = Convert.ToDecimal(grdVwRezervasyon.GetFocusedRowCellValue("SPMKTR"));
                decimal rzmktr = Convert.ToDecimal(grdVwRezervasyon.GetFocusedRowCellValue("RZMKTR"));
                decimal usestk = Convert.ToDecimal(grdVwRezervasyon.GetFocusedRowCellValue("USESTK"));

                if (miktar + rzmktr > spmktr)
                {
                    miktar = usestk;
                    e.ErrorText = "Toplam rezervasyon miktarı sipariş miktarından fazla olamaz!";
                    e.Valid = false;
                }
                else if (miktar > usestk)
                {
                    miktar = usestk;
                    e.ErrorText = "Bu rezervasyon için yeterli stok yok!";
                    e.Valid = false;
                }
                else if (rzmktr >= spmktr)
                {
                    miktar = 0;
                    e.ErrorText = "Bu stok için sipariş miktarı kadar rezervasyon zaten yapılmış!";
                    e.Valid = false;
                }
            }

            e.Value = miktar;
        }

        private void btnOnay_Click(object sender, EventArgs e)
        {
            DialogResult Mesaj = MessageBox.Show("Emin misiniz?", "Rezervasyon Onay", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj != DialogResult.Yes) return;

            if (CreateRezervasyon()) Close();
        }

        private bool CreateRezervasyon()
        {
            List<SpRezervasyonOzet> rezervasyonList = gridRezervasyon.DataSource as List<SpRezervasyonOzet>;

            List<SPREZV> sprezvList = new List<SPREZV>();
            foreach (var rez in rezervasyonList)
            {
                if (rez.MXRZMK <= 0) continue;

                DataView dv = new DataView(frmSiparisRez.stokDataSet.Tables[1]);
                dv.RowFilter = "[PARENT] = '" + rez.STKODU + "' AND DPKODU = '" + rez.CKDEPO + "'";

                DataTable table = dv.ToTable();

                foreach (DataRow row in table.Rows)
                {
                    SPREZV sprezv = new SPREZV
                    {
                        SIRKID = frmSiparisRez.global.SirketId.Value,
                        KYNKKD = frmSiparisRez.global.KaynakKod,
                        CHKCTR = false,
                        ACTIVE = true,
                        SLINDI = false,
                        EKKULL = frmSiparisRez.global.UserKod,
                        ETARIH = DateTime.Now,

                        SPBLNO = frmSiparisRez.spfbas.BELGEN,
                        SPBLTR = frmSiparisRez.spfbas.BELTRH,
                        SATIRN = rez.SATIRN,
                        STKODU = row["STKODU"].ToString(),
                        STKNAM = row["STKNAM"].ToString(),
                        SPMKTR = rez.SPMKTR,
                        RZMKTR = rez.MXRZMK,
                        KLMKTR = rez.MXRZMK,
                        OLCUKD = rez.OLCUKD,
                        CKDEPO = rez.CKDEPO,
                    };

                    sprezvList.Add(sprezv);
                }
            }

            var response = _xxService.Ncch_SiparisRezervasyonKaydet_Log(sprezvList, frmSiparisRez.global, false);
            if (response.Status != ResponseStatusEnum.OK)
            {
                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
    }
}