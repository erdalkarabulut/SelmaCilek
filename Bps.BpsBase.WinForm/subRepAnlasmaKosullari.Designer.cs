namespace BPS.Windows.Forms
{
    partial class subRepAnlasmaKosullari
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(subRepAnlasmaKosullari));
            this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
            this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
            this.Detail = new DevExpress.XtraReports.UI.DetailBand();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.xrLabel7 = new DevExpress.XtraReports.UI.XRLabel();
            this.richTextAnlasmaKosullari = new DevExpress.XtraReports.UI.XRRichText();
            this.ReportHeader = new DevExpress.XtraReports.UI.ReportHeaderBand();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.richTextAnlasmaKosullari)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
            // 
            // TopMargin
            // 
            this.TopMargin.HeightF = 0F;
            this.TopMargin.Name = "TopMargin";
            // 
            // BottomMargin
            // 
            this.BottomMargin.HeightF = 0F;
            this.BottomMargin.Name = "BottomMargin";
            // 
            // Detail
            // 
            this.Detail.HeightF = 0F;
            this.Detail.Name = "Detail";
            // 
            // bindingSource1
            // 
            this.bindingSource1.DataSource = typeof(Bps.BpsBase.Entities.Concrete.SP.SPODTB);
            // 
            // xrLabel7
            // 
            this.xrLabel7.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.xrLabel7.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
            this.xrLabel7.Multiline = true;
            this.xrLabel7.Name = "xrLabel7";
            this.xrLabel7.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
            this.xrLabel7.SizeF = new System.Drawing.SizeF(157.5973F, 35.54167F);
            this.xrLabel7.StylePriority.UseFont = false;
            this.xrLabel7.StylePriority.UseTextAlignment = false;
            this.xrLabel7.Text = "Anlaşma Koşulları:";
            this.xrLabel7.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
            // 
            // richTextAnlasmaKosullari
            // 
            this.richTextAnlasmaKosullari.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
            this.richTextAnlasmaKosullari.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.richTextAnlasmaKosullari.LocationFloat = new DevExpress.Utils.PointFloat(0F, 35.54169F);
            this.richTextAnlasmaKosullari.Name = "richTextAnlasmaKosullari";
            this.richTextAnlasmaKosullari.Padding = new DevExpress.XtraPrinting.PaddingInfo(10, 5, 10, 1, 100F);
            this.richTextAnlasmaKosullari.SerializableRtfString = resources.GetString("richTextAnlasmaKosullari.SerializableRtfString");
            this.richTextAnlasmaKosullari.SizeF = new System.Drawing.SizeF(704.0002F, 30.20833F);
            this.richTextAnlasmaKosullari.StylePriority.UseBorders = false;
            this.richTextAnlasmaKosullari.StylePriority.UseFont = false;
            this.richTextAnlasmaKosullari.StylePriority.UsePadding = false;
            // 
            // ReportHeader
            // 
            this.ReportHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.richTextAnlasmaKosullari,
            this.xrLabel7});
            this.ReportHeader.HeightF = 65.75002F;
            this.ReportHeader.Name = "ReportHeader";
            // 
            // subRepAnlasmaKosullari
            // 
            this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.ReportHeader});
            this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.bindingSource1});
            this.DataSource = this.bindingSource1;
            this.Font = new System.Drawing.Font("Arial", 9.75F);
            this.Margins = new System.Drawing.Printing.Margins(60, 63, 0, 0);
            this.PageHeight = 1169;
            this.PageWidth = 827;
            this.PaperKind = System.Drawing.Printing.PaperKind.A4;
            this.Version = "20.2";
            this.Watermark.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource("img", resources.GetString("subRepAnlasmaKosullari.Watermark.ImageSource"));
            this.Watermark.ImageTransparency = 230;
            this.Watermark.ImageViewMode = DevExpress.XtraPrinting.Drawing.ImageViewMode.Zoom;
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.richTextAnlasmaKosullari)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this)).EndInit();

        }

        #endregion

        private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
        private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
        private DevExpress.XtraReports.UI.DetailBand Detail;
        public System.Windows.Forms.BindingSource bindingSource1;
        public DevExpress.XtraReports.UI.XRLabel xrLabel7;
        public DevExpress.XtraReports.UI.XRRichText richTextAnlasmaKosullari;
        private DevExpress.XtraReports.UI.ReportHeaderBand ReportHeader;
    }
}
