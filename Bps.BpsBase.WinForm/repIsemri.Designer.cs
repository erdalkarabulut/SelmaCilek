namespace BPS.Windows.Forms
{
	partial class repIsemri
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
			DevExpress.XtraReports.UI.XRSummary xrSummary1 = new DevExpress.XtraReports.UI.XRSummary();
			this.TopMargin = new DevExpress.XtraReports.UI.TopMarginBand();
			this.BottomMargin = new DevExpress.XtraReports.UI.BottomMarginBand();
			this.Detail = new DevExpress.XtraReports.UI.DetailBand();
			this.xrPictureBox3 = new DevExpress.XtraReports.UI.XRPictureBox();
			this.xrLabel10 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel12 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel13 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel14 = new DevExpress.XtraReports.UI.XRLabel();
			this.PageHeader = new DevExpress.XtraReports.UI.PageHeaderBand();
			this.lblUrunKodu = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel15 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrTable1 = new DevExpress.XtraReports.UI.XRTable();
			this.xrTableRow1 = new DevExpress.XtraReports.UI.XRTableRow();
			this.xrTableCell1 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell2 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell3 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell4 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrTableCell5 = new DevExpress.XtraReports.UI.XRTableCell();
			this.xrPictureBox2 = new DevExpress.XtraReports.UI.XRPictureBox();
			this.xrLabel8 = new DevExpress.XtraReports.UI.XRLabel();
			this.lblUrunAdi = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel6 = new DevExpress.XtraReports.UI.XRLabel();
			this.lblMiktar = new DevExpress.XtraReports.UI.XRLabel();
			this.lblPlanNo = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel5 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel3 = new DevExpress.XtraReports.UI.XRLabel();
			this.lblTarih = new DevExpress.XtraReports.UI.XRLabel();
			this.xrLabel1 = new DevExpress.XtraReports.UI.XRLabel();
			this.xrPictureBox1 = new DevExpress.XtraReports.UI.XRPictureBox();
			this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			((System.ComponentModel.ISupportInitialize)(this.xrTable1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
			// 
			// TopMargin
			// 
			this.TopMargin.HeightF = 26.35294F;
			this.TopMargin.Name = "TopMargin";
			// 
			// BottomMargin
			// 
			this.BottomMargin.HeightF = 30F;
			this.BottomMargin.Name = "BottomMargin";
			// 
			// Detail
			// 
			this.Detail.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.xrPictureBox3,
            this.xrLabel10,
            this.xrLabel12,
            this.xrLabel13,
            this.xrLabel14});
			this.Detail.HeightF = 133.5069F;
			this.Detail.Name = "Detail";
			// 
			// xrPictureBox3
			// 
			this.xrPictureBox3.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrPictureBox3.LocationFloat = new DevExpress.Utils.PointFloat(46.5653F, 0F);
			this.xrPictureBox3.Name = "xrPictureBox3";
			this.xrPictureBox3.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
			this.xrPictureBox3.SizeF = new System.Drawing.SizeF(151.0622F, 133.5069F);
			this.xrPictureBox3.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
			this.xrPictureBox3.StylePriority.UseBorders = false;
			this.xrPictureBox3.StylePriority.UsePadding = false;
			// 
			// xrLabel10
			// 
			this.xrLabel10.BackColor = System.Drawing.Color.Transparent;
			this.xrLabel10.BorderColor = System.Drawing.Color.Black;
			this.xrLabel10.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.xrLabel10.Borders = ((DevExpress.XtraPrinting.BorderSide)(((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrLabel10.BorderWidth = 1F;
			this.xrLabel10.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "sumRecordNumber()")});
			this.xrLabel10.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel10.ForeColor = System.Drawing.Color.Black;
			this.xrLabel10.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrLabel10.Multiline = true;
			this.xrLabel10.Name = "xrLabel10";
			this.xrLabel10.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel10.SizeF = new System.Drawing.SizeF(46.5653F, 133.5069F);
			this.xrLabel10.StylePriority.UseBackColor = false;
			this.xrLabel10.StylePriority.UseBorderColor = false;
			this.xrLabel10.StylePriority.UseBorderDashStyle = false;
			this.xrLabel10.StylePriority.UseBorders = false;
			this.xrLabel10.StylePriority.UseBorderWidth = false;
			this.xrLabel10.StylePriority.UseFont = false;
			this.xrLabel10.StylePriority.UseForeColor = false;
			this.xrLabel10.StylePriority.UsePadding = false;
			this.xrLabel10.StylePriority.UseTextAlignment = false;
			xrSummary1.Running = DevExpress.XtraReports.UI.SummaryRunning.Report;
			this.xrLabel10.Summary = xrSummary1;
			this.xrLabel10.Text = "SIRA";
			this.xrLabel10.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrLabel12
			// 
			this.xrLabel12.BackColor = System.Drawing.Color.Transparent;
			this.xrLabel12.BorderColor = System.Drawing.Color.Black;
			this.xrLabel12.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.xrLabel12.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrLabel12.BorderWidth = 1F;
			this.xrLabel12.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[STKODU]")});
			this.xrLabel12.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel12.ForeColor = System.Drawing.Color.Black;
			this.xrLabel12.LocationFloat = new DevExpress.Utils.PointFloat(197.6276F, 0F);
			this.xrLabel12.Multiline = true;
			this.xrLabel12.Name = "xrLabel12";
			this.xrLabel12.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
			this.xrLabel12.SizeF = new System.Drawing.SizeF(144.4988F, 133.5069F);
			this.xrLabel12.StylePriority.UseBackColor = false;
			this.xrLabel12.StylePriority.UseBorderColor = false;
			this.xrLabel12.StylePriority.UseBorderDashStyle = false;
			this.xrLabel12.StylePriority.UseBorders = false;
			this.xrLabel12.StylePriority.UseBorderWidth = false;
			this.xrLabel12.StylePriority.UseFont = false;
			this.xrLabel12.StylePriority.UseForeColor = false;
			this.xrLabel12.StylePriority.UsePadding = false;
			this.xrLabel12.StylePriority.UseTextAlignment = false;
			this.xrLabel12.Text = "PARÇA KODU";
			this.xrLabel12.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel13
			// 
			this.xrLabel13.BackColor = System.Drawing.Color.Transparent;
			this.xrLabel13.BorderColor = System.Drawing.Color.Black;
			this.xrLabel13.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.xrLabel13.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrLabel13.BorderWidth = 1F;
			this.xrLabel13.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[STKNAM]")});
			this.xrLabel13.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel13.ForeColor = System.Drawing.Color.Black;
			this.xrLabel13.LocationFloat = new DevExpress.Utils.PointFloat(342.1263F, 0F);
			this.xrLabel13.Multiline = true;
			this.xrLabel13.Name = "xrLabel13";
			this.xrLabel13.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
			this.xrLabel13.SizeF = new System.Drawing.SizeF(309.0652F, 133.5069F);
			this.xrLabel13.StylePriority.UseBackColor = false;
			this.xrLabel13.StylePriority.UseBorderColor = false;
			this.xrLabel13.StylePriority.UseBorderDashStyle = false;
			this.xrLabel13.StylePriority.UseBorders = false;
			this.xrLabel13.StylePriority.UseBorderWidth = false;
			this.xrLabel13.StylePriority.UseFont = false;
			this.xrLabel13.StylePriority.UseForeColor = false;
			this.xrLabel13.StylePriority.UsePadding = false;
			this.xrLabel13.StylePriority.UseTextAlignment = false;
			this.xrLabel13.Text = "PARÇA ADI";
			this.xrLabel13.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel14
			// 
			this.xrLabel14.BackColor = System.Drawing.Color.Transparent;
			this.xrLabel14.BorderColor = System.Drawing.Color.Black;
			this.xrLabel14.BorderDashStyle = DevExpress.XtraPrinting.BorderDashStyle.Solid;
			this.xrLabel14.Borders = ((DevExpress.XtraPrinting.BorderSide)((DevExpress.XtraPrinting.BorderSide.Right | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrLabel14.BorderWidth = 1F;
			this.xrLabel14.ExpressionBindings.AddRange(new DevExpress.XtraReports.UI.ExpressionBinding[] {
            new DevExpress.XtraReports.UI.ExpressionBinding("BeforePrint", "Text", "[PLMKTR]")});
			this.xrLabel14.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel14.ForeColor = System.Drawing.Color.Black;
			this.xrLabel14.LocationFloat = new DevExpress.Utils.PointFloat(651.1916F, 0F);
			this.xrLabel14.Multiline = true;
			this.xrLabel14.Name = "xrLabel14";
			this.xrLabel14.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 0, 0, 100F);
			this.xrLabel14.SizeF = new System.Drawing.SizeF(106.8085F, 133.5069F);
			this.xrLabel14.StylePriority.UseBackColor = false;
			this.xrLabel14.StylePriority.UseBorderColor = false;
			this.xrLabel14.StylePriority.UseBorderDashStyle = false;
			this.xrLabel14.StylePriority.UseBorders = false;
			this.xrLabel14.StylePriority.UseBorderWidth = false;
			this.xrLabel14.StylePriority.UseFont = false;
			this.xrLabel14.StylePriority.UseForeColor = false;
			this.xrLabel14.StylePriority.UsePadding = false;
			this.xrLabel14.StylePriority.UseTextAlignment = false;
			this.xrLabel14.Text = "MİKTAR";
			this.xrLabel14.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// PageHeader
			// 
			this.PageHeader.Controls.AddRange(new DevExpress.XtraReports.UI.XRControl[] {
            this.lblUrunKodu,
            this.xrLabel15,
            this.xrTable1,
            this.xrPictureBox2,
            this.xrLabel8,
            this.lblUrunAdi,
            this.xrLabel6,
            this.lblMiktar,
            this.lblPlanNo,
            this.xrLabel5,
            this.xrLabel3,
            this.lblTarih,
            this.xrLabel1,
            this.xrPictureBox1});
			this.PageHeader.HeightF = 280.6483F;
			this.PageHeader.Name = "PageHeader";
			// 
			// lblUrunKodu
			// 
			this.lblUrunKodu.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblUrunKodu.LocationFloat = new DevExpress.Utils.PointFloat(98.81378F, 174.8067F);
			this.lblUrunKodu.Multiline = true;
			this.lblUrunKodu.Name = "lblUrunKodu";
			this.lblUrunKodu.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
			this.lblUrunKodu.SizeF = new System.Drawing.SizeF(383.6177F, 23.00002F);
			this.lblUrunKodu.StylePriority.UseFont = false;
			this.lblUrunKodu.StylePriority.UsePadding = false;
			this.lblUrunKodu.StylePriority.UseTextAlignment = false;
			this.lblUrunKodu.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel15
			// 
			this.xrLabel15.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel15.LocationFloat = new DevExpress.Utils.PointFloat(0F, 174.8067F);
			this.xrLabel15.Multiline = true;
			this.xrLabel15.Name = "xrLabel15";
			this.xrLabel15.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel15.SizeF = new System.Drawing.SizeF(98.81378F, 23.00001F);
			this.xrLabel15.StylePriority.UseFont = false;
			this.xrLabel15.StylePriority.UseTextAlignment = false;
			this.xrLabel15.Text = "ÜRÜN KODU:";
			this.xrLabel15.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// xrTable1
			// 
			this.xrTable1.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrTable1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrTable1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 255.6483F);
			this.xrTable1.Name = "xrTable1";
			this.xrTable1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 96F);
			this.xrTable1.Rows.AddRange(new DevExpress.XtraReports.UI.XRTableRow[] {
            this.xrTableRow1});
			this.xrTable1.SizeF = new System.Drawing.SizeF(758F, 24.99998F);
			this.xrTable1.StylePriority.UseBorders = false;
			this.xrTable1.StylePriority.UseFont = false;
			this.xrTable1.StylePriority.UseTextAlignment = false;
			this.xrTable1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrTableRow1
			// 
			this.xrTableRow1.Cells.AddRange(new DevExpress.XtraReports.UI.XRTableCell[] {
            this.xrTableCell1,
            this.xrTableCell2,
            this.xrTableCell3,
            this.xrTableCell4,
            this.xrTableCell5});
			this.xrTableRow1.Name = "xrTableRow1";
			this.xrTableRow1.Weight = 1D;
			// 
			// xrTableCell1
			// 
			this.xrTableCell1.Multiline = true;
			this.xrTableCell1.Name = "xrTableCell1";
			this.xrTableCell1.Text = "SIRA";
			this.xrTableCell1.Weight = 0.30715900612380703D;
			// 
			// xrTableCell2
			// 
			this.xrTableCell2.Multiline = true;
			this.xrTableCell2.Name = "xrTableCell2";
			this.xrTableCell2.Text = "TEKNİK RESİM";
			this.xrTableCell2.Weight = 0.99645291028991545D;
			// 
			// xrTableCell3
			// 
			this.xrTableCell3.Multiline = true;
			this.xrTableCell3.Name = "xrTableCell3";
			this.xrTableCell3.Text = "PARÇA KODU";
			this.xrTableCell3.Weight = 0.953158335824126D;
			// 
			// xrTableCell4
			// 
			this.xrTableCell4.Multiline = true;
			this.xrTableCell4.Name = "xrTableCell4";
			this.xrTableCell4.Text = "PARÇA ADI";
			this.xrTableCell4.Weight = 2.0386888207105978D;
			// 
			// xrTableCell5
			// 
			this.xrTableCell5.Multiline = true;
			this.xrTableCell5.Name = "xrTableCell5";
			this.xrTableCell5.Text = "MİKTAR";
			this.xrTableCell5.Weight = 0.70454092705155436D;
			// 
			// xrPictureBox2
			// 
			this.xrPictureBox2.Borders = ((DevExpress.XtraPrinting.BorderSide)((((DevExpress.XtraPrinting.BorderSide.Left | DevExpress.XtraPrinting.BorderSide.Top) 
            | DevExpress.XtraPrinting.BorderSide.Right) 
            | DevExpress.XtraPrinting.BorderSide.Bottom)));
			this.xrPictureBox2.LocationFloat = new DevExpress.Utils.PointFloat(495.8536F, 0F);
			this.xrPictureBox2.Name = "xrPictureBox2";
			this.xrPictureBox2.Padding = new DevExpress.XtraPrinting.PaddingInfo(3, 3, 3, 3, 100F);
			this.xrPictureBox2.SizeF = new System.Drawing.SizeF(262.1464F, 243.8068F);
			this.xrPictureBox2.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
			this.xrPictureBox2.StylePriority.UseBorders = false;
			this.xrPictureBox2.StylePriority.UsePadding = false;
			// 
			// xrLabel8
			// 
			this.xrLabel8.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel8.LocationFloat = new DevExpress.Utils.PointFloat(0F, 197.8068F);
			this.xrLabel8.Multiline = true;
			this.xrLabel8.Name = "xrLabel8";
			this.xrLabel8.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel8.SizeF = new System.Drawing.SizeF(98.81378F, 23.00001F);
			this.xrLabel8.StylePriority.UseFont = false;
			this.xrLabel8.StylePriority.UseTextAlignment = false;
			this.xrLabel8.Text = "ÜRÜN ADI:";
			this.xrLabel8.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// lblUrunAdi
			// 
			this.lblUrunAdi.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblUrunAdi.LocationFloat = new DevExpress.Utils.PointFloat(98.81378F, 197.8068F);
			this.lblUrunAdi.Multiline = true;
			this.lblUrunAdi.Name = "lblUrunAdi";
			this.lblUrunAdi.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
			this.lblUrunAdi.SizeF = new System.Drawing.SizeF(383.6177F, 23.00002F);
			this.lblUrunAdi.StylePriority.UseFont = false;
			this.lblUrunAdi.StylePriority.UsePadding = false;
			this.lblUrunAdi.StylePriority.UseTextAlignment = false;
			this.lblUrunAdi.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel6
			// 
			this.xrLabel6.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel6.LocationFloat = new DevExpress.Utils.PointFloat(0F, 220.8068F);
			this.xrLabel6.Multiline = true;
			this.xrLabel6.Name = "xrLabel6";
			this.xrLabel6.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel6.SizeF = new System.Drawing.SizeF(98.81378F, 23.00001F);
			this.xrLabel6.StylePriority.UseFont = false;
			this.xrLabel6.StylePriority.UseTextAlignment = false;
			this.xrLabel6.Text = "MİKTAR:";
			this.xrLabel6.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// lblMiktar
			// 
			this.lblMiktar.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblMiktar.LocationFloat = new DevExpress.Utils.PointFloat(98.81378F, 220.8068F);
			this.lblMiktar.Multiline = true;
			this.lblMiktar.Name = "lblMiktar";
			this.lblMiktar.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
			this.lblMiktar.SizeF = new System.Drawing.SizeF(383.6177F, 23.00002F);
			this.lblMiktar.StylePriority.UseFont = false;
			this.lblMiktar.StylePriority.UsePadding = false;
			this.lblMiktar.StylePriority.UseTextAlignment = false;
			this.lblMiktar.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// lblPlanNo
			// 
			this.lblPlanNo.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblPlanNo.LocationFloat = new DevExpress.Utils.PointFloat(98.81378F, 136.7574F);
			this.lblPlanNo.Multiline = true;
			this.lblPlanNo.Name = "lblPlanNo";
			this.lblPlanNo.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
			this.lblPlanNo.SizeF = new System.Drawing.SizeF(98.81378F, 23.00001F);
			this.lblPlanNo.StylePriority.UseFont = false;
			this.lblPlanNo.StylePriority.UsePadding = false;
			this.lblPlanNo.StylePriority.UseTextAlignment = false;
			this.lblPlanNo.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel5
			// 
			this.xrLabel5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel5.LocationFloat = new DevExpress.Utils.PointFloat(0F, 136.7574F);
			this.xrLabel5.Multiline = true;
			this.xrLabel5.Name = "xrLabel5";
			this.xrLabel5.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel5.SizeF = new System.Drawing.SizeF(98.81378F, 23.00001F);
			this.xrLabel5.StylePriority.UseFont = false;
			this.xrLabel5.StylePriority.UseTextAlignment = false;
			this.xrLabel5.Text = "PLAN NO:";
			this.xrLabel5.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// xrLabel3
			// 
			this.xrLabel3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel3.LocationFloat = new DevExpress.Utils.PointFloat(0F, 113.7573F);
			this.xrLabel3.Multiline = true;
			this.xrLabel3.Name = "xrLabel3";
			this.xrLabel3.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel3.SizeF = new System.Drawing.SizeF(98.81378F, 23.00001F);
			this.xrLabel3.StylePriority.UseFont = false;
			this.xrLabel3.StylePriority.UseTextAlignment = false;
			this.xrLabel3.Text = "TARİH:";
			this.xrLabel3.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleRight;
			// 
			// lblTarih
			// 
			this.lblTarih.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.lblTarih.LocationFloat = new DevExpress.Utils.PointFloat(98.81378F, 113.7573F);
			this.lblTarih.Multiline = true;
			this.lblTarih.Name = "lblTarih";
			this.lblTarih.Padding = new DevExpress.XtraPrinting.PaddingInfo(5, 2, 0, 0, 100F);
			this.lblTarih.SizeF = new System.Drawing.SizeF(98.81378F, 23.00001F);
			this.lblTarih.StylePriority.UseFont = false;
			this.lblTarih.StylePriority.UsePadding = false;
			this.lblTarih.StylePriority.UseTextAlignment = false;
			this.lblTarih.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleLeft;
			// 
			// xrLabel1
			// 
			this.xrLabel1.Font = new System.Drawing.Font("Calibri", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
			this.xrLabel1.LocationFloat = new DevExpress.Utils.PointFloat(98.81378F, 54.22795F);
			this.xrLabel1.Multiline = true;
			this.xrLabel1.Name = "xrLabel1";
			this.xrLabel1.Padding = new DevExpress.XtraPrinting.PaddingInfo(2, 2, 0, 0, 100F);
			this.xrLabel1.SizeF = new System.Drawing.SizeF(151.6459F, 35.94606F);
			this.xrLabel1.StylePriority.UseFont = false;
			this.xrLabel1.StylePriority.UseTextAlignment = false;
			this.xrLabel1.Text = "İŞ EMRİ";
			this.xrLabel1.TextAlignment = DevExpress.XtraPrinting.TextAlignment.MiddleCenter;
			// 
			// xrPictureBox1
			// 
			this.xrPictureBox1.ImageSource = new DevExpress.XtraPrinting.Drawing.ImageSource(global::BPS.Windows.Forms.Properties.Resources.ironsan1, true);
			this.xrPictureBox1.LocationFloat = new DevExpress.Utils.PointFloat(0F, 0F);
			this.xrPictureBox1.Name = "xrPictureBox1";
			this.xrPictureBox1.SizeF = new System.Drawing.SizeF(342.1264F, 54.22795F);
			this.xrPictureBox1.Sizing = DevExpress.XtraPrinting.ImageSizeMode.ZoomImage;
			// 
			// bindingSource1
			// 
			this.bindingSource1.DataSource = typeof(Bps.BpsBase.Entities.Models.IS.Listed.IsplanUrunParcaModel);
			// 
			// repIsemri
			// 
			this.Bands.AddRange(new DevExpress.XtraReports.UI.Band[] {
            this.TopMargin,
            this.BottomMargin,
            this.Detail,
            this.PageHeader});
			this.ComponentStorage.AddRange(new System.ComponentModel.IComponent[] {
            this.bindingSource1});
			this.DataSource = this.bindingSource1;
			this.Font = new System.Drawing.Font("Arial", 9.75F);
			this.Margins = new System.Drawing.Printing.Margins(35, 34, 26, 30);
			this.PageHeight = 1169;
			this.PageWidth = 827;
			this.PaperKind = System.Drawing.Printing.PaperKind.A4;
			this.Version = "20.2";
			((System.ComponentModel.ISupportInitialize)(this.xrTable1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this)).EndInit();

		}

		#endregion

		private DevExpress.XtraReports.UI.TopMarginBand TopMargin;
		private DevExpress.XtraReports.UI.BottomMarginBand BottomMargin;
		private DevExpress.XtraReports.UI.DetailBand Detail;
		private DevExpress.XtraReports.UI.PageHeaderBand PageHeader;
		private DevExpress.XtraReports.UI.XRLabel xrLabel3;
		private DevExpress.XtraReports.UI.XRLabel xrLabel1;
		private DevExpress.XtraReports.UI.XRPictureBox xrPictureBox1;
		private DevExpress.XtraReports.UI.XRLabel xrLabel5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel8;
		private DevExpress.XtraReports.UI.XRLabel xrLabel6;
		private DevExpress.XtraReports.UI.XRTable xrTable1;
		private DevExpress.XtraReports.UI.XRTableRow xrTableRow1;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell1;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell2;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell3;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell4;
		private DevExpress.XtraReports.UI.XRTableCell xrTableCell5;
		private DevExpress.XtraReports.UI.XRLabel xrLabel10;
		private DevExpress.XtraReports.UI.XRLabel xrLabel12;
		private DevExpress.XtraReports.UI.XRLabel xrLabel13;
		private DevExpress.XtraReports.UI.XRLabel xrLabel14;
		private DevExpress.XtraReports.UI.XRLabel xrLabel15;
		public System.Windows.Forms.BindingSource bindingSource1;
		public DevExpress.XtraReports.UI.XRLabel lblTarih;
		public DevExpress.XtraReports.UI.XRLabel lblPlanNo;
		public DevExpress.XtraReports.UI.XRLabel lblUrunAdi;
		public DevExpress.XtraReports.UI.XRLabel lblMiktar;
		public DevExpress.XtraReports.UI.XRLabel lblUrunKodu;
		public DevExpress.XtraReports.UI.XRPictureBox xrPictureBox3;
		public DevExpress.XtraReports.UI.XRPictureBox xrPictureBox2;
	}
}
