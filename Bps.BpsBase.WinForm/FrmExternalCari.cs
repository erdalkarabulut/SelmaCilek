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
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.DataAccess.Abstract.CR;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.BpsBase.Entities.Models.CR.Listed;
using Bps.Core.GlobalStaticsVariables;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BPS.Windows.Forms
{
	public partial class FrmExternalCari : Form
	{
		public bool refresh = false;

		private Global _global;
		private string _cariTuru;
		private List<CRCARI> crList = new List<CRCARI>();

		private readonly ICrcariService _crcariService;
		private readonly ICrcariDal _crcariDal;

		public FrmExternalCari(Global global, string cariTuru)
		{
			_global = global;
			_cariTuru = cariTuru;
			_crcariService = InstanceFactory.GetInstance<ICrcariService>();
			_crcariDal = InstanceFactory.GetInstance<ICrcariDal>();

			InitializeComponent();
		}

		private void FrmExternalCari_Load(object sender, EventArgs e)
		{
			crList = _crcariService.Cch_GetListAktif_NLog(_global, false).Items;
			GetExternalCariList();
		}

		private void GetExternalCariList()
		{
			string sqlQuery = "";

			if (Param.ADAPTATION == Adaptation.Aracikan)
			{
				sqlQuery = @"SELECT cari_kod AS CRKODU, cari_unvan1 AS CRUNV1, cari_unvan2 AS CRUNV2, cari_vdaire_adi AS VERGDA, cari_vdaire_no AS VERGNO
				                    FROM MIKRO.MikroDB_V16_01.dbo.CARI_HESAPLAR ORDER BY cari_unvan1"; //TÜMÜ için aç

				//string notFilter = "";
				//if (_cariTuru != "0") notFilter = "NOT"; //Müşteri değilse

				//string sqlQuery = @"SELECT cari_kod AS CRKODU, cari_unvan1 AS CRUNV1, cari_unvan2 AS CRUNV2, cari_vdaire_adi AS VERGDA, cari_vdaire_no AS VERGNO
				//            FROM MIKRO.MikroDB_V16_01.dbo.CARI_HESAPLAR LEFT OUTER JOIN CRCARI
				//            ON cari_kod = CRCARI.CRKODU COLLATE SQL_Latin1_General_CP1_CI_AS
				//            WHERE CRCARI.CRKODU IS NULL AND cari_kod " + notFilter + " LIKE '120%' ORDER BY cari_unvan1";

			}
			else if (Param.ADAPTATION == Adaptation.Bala)
			{
				string operatr = "=";
				if (_cariTuru != "0") operatr = "!="; //Müşteri değilse

				sqlQuery = @"SELECT CRK AS CRKODU, STA AS CRUNV1, STA AS CRUNV2, ISNULL((ADRES1 + ' ' + SEMT + ' ' + SEHIR + ' ' + ULKE), '.') AS ADRESS, 
                            ISNULL((AKTEL + ' ' + TEL), '0') AS TLEFON, VERGID AS VERGDA, VERGINO AS VERGNO, EPOSTA AS GNMAIL, 
                            CASE WHEN EFATURAMI = 'E' THEN 1 ELSE 0 END AS EFATUR
                            FROM ZIRVE.BALA_MAKİNA_2024T.dbo.CARIGEN LEFT OUTER JOIN CRCARI
                            ON CRK = CRCARI.CRKODU COLLATE SQL_Latin1_General_CP1_CI_AS
                            WHERE CRCARI.CRKODU IS NULL AND ALICIORSATICI " + operatr + " 1 ORDER BY STA";
			}

			if (sqlQuery == "")
			{
				MessageBox.Show("Muhasebe entegrasyonu yapılmadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			List<CariExternalSourceModel> cariList = _crcariService.GetCariListFromExternalSource(sqlQuery, _global, false).Items;
			cariExternalSourceModelBindingSource.DataSource = cariList;

			gridView1.BestFitColumns();
		}

		private void btnTumCarileriAl_Click(object sender, EventArgs e)
		{
			if (cariExternalSourceModelBindingSource.Count == 0) return;

			List<CariExternalSourceModel> cariModelList = cariExternalSourceModelBindingSource.DataSource as List<CariExternalSourceModel>;

			DialogResult Secim;
			Secim = MessageBox.Show("Listedeki tüm cariler sisteme aktarılacak. Emin misiniz?", "Cari Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
			if (Secim == DialogResult.Yes)
			{
				List<CRCARI> cariList = new List<CRCARI>();

				foreach (CariExternalSourceModel cariModel in cariModelList)
				{
					CRCARI cari = new CRCARI
					{
						SIRKID = _global.SirketId.Value,
						CRHRKD = _cariTuru,
						CRKODU = cariModel.CRKODU.Trim(),
						CRUNV1 = cariModel.CRUNV1.Replace("\"", "").Trim(),
						CRUNV2 = cariModel.CRUNV2.Replace("\"", "").Trim(),
						CRBGKD = "0",
						VERGDA = string.IsNullOrEmpty(cariModel.VERGDA) ? "." : cariModel.VERGDA.Trim() == "" ? "." : cariModel.VERGDA.Trim(),
						VERGNO = string.IsNullOrEmpty(cariModel.VERGNO) ? "0" : cariModel.VERGNO.Trim() == "" ? "0" : cariModel.VERGNO.Trim(),
						CRAKOD = cariModel.CRKODU.Trim(),
						GNMAIL = cariModel.GNMAIL == null ? null : !cariModel.GNMAIL.Contains("@") ? null : cariModel.GNMAIL.Trim(),
						EFATUR = cariModel.EFATUR == 1,
						OTVTEV = false,
						ACTIVE = true,
						SLINDI = false,
						EKKULL = _global.UserKod,
						ETARIH = DateTime.Now,
						KYNKKD = "3",
						CHKCTR = false
					};

					cariList.Add(cari);
				}

				_crcariDal.MultiAdd(cariList);

				refresh = true;
				Close();
			}
		}

		private void gridControl1_DoubleClick(object sender, EventArgs e)
		{
			Point point = gridView1.GridControl.PointToClient(MousePosition);

			GridHitInfo info = gridView1.CalcHitInfo(point);
			if ((info.InRow || info.InRowCell) && info.RowHandle > -1)
			{
				CariExternalSourceModel cariModel = cariExternalSourceModelBindingSource.Current as CariExternalSourceModel;
				if (cariModel == null) return;

				DialogResult Secim;
				Secim = MessageBox.Show(cariModel.CRUNV1 + " sisteme aktarılacak. Emin misiniz?", "Cari Ekle", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
				if (Secim == DialogResult.Yes)
				{
					CRCARI cari = new CRCARI
					{
						SIRKID = _global.SirketId.Value,
						CRHRKD = _cariTuru,
						CRKODU = cariModel.CRKODU.Trim(),
						CRUNV1 = cariModel.CRUNV1.Replace("\"", "").Trim(),
						CRUNV2 = cariModel.CRUNV2.Replace("\"", "").Trim(),
						CRBGKD = "0",
						VERGDA = string.IsNullOrEmpty(cariModel.VERGDA) ? "." : cariModel.VERGDA.Trim() == "" ? "." : cariModel.VERGDA.Trim(),
						VERGNO = string.IsNullOrEmpty(cariModel.VERGNO) ? "0" : cariModel.VERGNO.Trim() == "" ? "0" : cariModel.VERGNO.Trim(),
						CRAKOD = cariModel.CRKODU.Trim(),
						GNMAIL = cariModel.GNMAIL == null ? null : !cariModel.GNMAIL.Contains("@") ? null : cariModel.GNMAIL.Trim(),
						EFATUR = cariModel.EFATUR == 1,
						OTVTEV = false,
						ACTIVE = true,
						SLINDI = false,
						EKKULL = _global.UserKod,
						ETARIH = DateTime.Now,
						KYNKKD = "3",
						CHKCTR = false
					};

					_crcariDal.Add(cari);
					refresh = true;
					Close();
				}
			}
		}

		private void gridView1_RowStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowStyleEventArgs e)
		{
			GridView view = sender as GridView;
			if (e.RowHandle < 0) return;

			string crkodu = view.GetFocusedRowCellValue("CRKODU").ToString();

			CRCARI cr = crList.Find(c => c.CRKODU == crkodu);

			if (cr != null)
			{
				e.Appearance.BackColor = Color.Red;
				e.HighPriority = true;
			}

			//if (view.IsValidRowHandle(e.RowHandle) && e.RowHandle != view.FocusedRowHandle)
			//{

			//}
		}
	}
}
