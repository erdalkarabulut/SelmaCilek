
namespace BPS.Windows.Forms
{
    partial class repBarkodEtiket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            this.lblStokAdi = new DevExpress.XtraReports.UI.XRLabel();
            this.xrBarcode = new DevExpress.XtraReports.UI.XRBarCode();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.Dpi = 254F;
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.Dpi = 254F;
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.Dpi = 254F;
            this.Detail.HeightF = 0F;
            this.Detail.HierarchyPrintOptions.Indent = 50.8F;
            this.Detail.Name = "Detail";
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrBarcode,
            this.lblStokAdi});
            this.ReportHeader.Dpi = 254F;
            this.ReportHeader.HeightF = 336.2325F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // lblStokAdi
            // 
            this.lblStokAdi.Dpi = 254F;
            this.lblStokAdi.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblStokAdi.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.lblStokAdi.Multiline = true;
            this.lblStokAdi.Name = "lblStokAdi";
            this.lblStokAdi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 5, 0, 0, 254F);
            this.lblStokAdi.SizeF = new System.Drawing.SizeF(1050F, 119.2741F);
            this.lblStokAdi.StylePriority.UseFont = false;
            this.lblStokAdi.StylePriority.UseTextAlignment = false;
            this.lblStokAdi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            // 
            // xrBarcode
            // 
            this.xrBarcode.Alignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
            this.xrBarcode.Dpi = 254F;
            this.xrBarcode.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xrBarcode.LocationFloat = new DevExpress.Utils.PointFloat(0F, 119.2741F);
            this.xrBarcode.Module = 4.5F;
            this.xrBarcode.Name = "xrBarcode";
            this.xrBarcode.Padding = new DevExpress.XtraPrinting.PaddingInfo(0, 0, 0, 0, 254F);
            this.xrBarcode.SizeF = new System.Drawing.SizeF(1050F, 216.9583F);
            this.xrBarcode.StylePriority.UseFont = false;
            this.xrBarcode.StylePriority.UsePadding = false;
            this.xrBarcode.StylePriority.UseTextAlignment = false;
            code128Generator1.CharacterSet = DevExpress.XtraPrinting.BarCode.Code128Charset.CharsetAuto;
            this.xrBarcode.Symbology = code128Generator1;
            this.xrBarcode.TextAlignment = DevExpress.XtraPrinting.TextAlignment.BottomCenter;
            // 
            // repBarkodEtiket
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader});
            this.Dpi = 254F;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(0, 0, 0, 0);
            this.PageHeight = 400;
            this.PageWidth = 1100;
            this.PaperKind = System.Drawing.Printing.PaperKind.Custom;
            this.ReportUnit = DevExpress.XtraReports.UI.ReportUnit.TenthsOfAMillimeter;
            this.SnapGridSize = 25F;
            this.Version = "20.2";
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
        public DevExpress.XtraReports.UI.XRLabel lblStokAdi;
        public DevExpress.XtraReports.UI.XRBarCode xrBarcode;
    }
}
