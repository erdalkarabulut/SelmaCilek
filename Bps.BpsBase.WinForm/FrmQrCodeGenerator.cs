using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using DevExpress.XtraPrinting.BarCode;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
	public partial class FrmQrCodeGenerator : Form
	{
		private Global _global;
		private STKART _stkart;
		private STKART _oldStkart;
		private readonly IStkartService _stkartService;

		public FrmQrCodeGenerator(STKART stkart, Global global)
		{
			_oldStkart = stkart;
			_stkart = _oldStkart.ShallowCopy();
			_global = global;
			_stkartService = InstanceFactory.GetInstance<IStkartService>();
			InitializeComponent();
		}

		private void FrmQrCodeGenerator_Load(object sender, EventArgs e)
		{
			memoQr.Text = _stkart.STKIMG ?? "";
		}

		private void btnKaydet_Click(object sender, EventArgs e)
		{
			_stkart.STKIMG = memoQr.Text;
			var response = _stkartService.Ncch_Update_Log(_stkart, _oldStkart, _global);

			if (response.Status == ResponseStatusEnum.OK)
			{
				MessageBox.Show("Kaydedildi", "QR Kayıt", MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}

		private void btnQrOlustur_Click(object sender, EventArgs e)
		{
			CreateQRCode();
		}

		public void CreateQRCode()
		{
			// Create a new report
			XtraReport report = new XtraReport();

			// Create a new XRBarCode control
			XRBarCode qrCode = new XRBarCode();

			// Set the barcode symbology to QR Code
			QRCodeGenerator qrCodeGenerator = new QRCodeGenerator();
			qrCode.Symbology = qrCodeGenerator;

			// Set the QR code content
			qrCode.Text = "https://example.com";

			// Set the size of the QR Code
			qrCode.SizeF = new System.Drawing.SizeF(150f, 150f); // Width and height in pixels

			// Set the location of the QR Code on the report
			qrCode.LocationF = new System.Drawing.PointF(10f, 10f);

			// Add the QR code to the report's detail band
			DetailBand detailBand = new DetailBand();
			detailBand.Controls.Add(qrCode);
			report.Bands.Add(detailBand);

			// Show the report preview (optional)
			ReportPrintTool printTool = new ReportPrintTool(report);
			printTool.ShowPreviewDialog();
		}
	}
}
