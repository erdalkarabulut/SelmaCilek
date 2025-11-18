namespace BPS.Windows.Forms
{
	partial class TempForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TempForm));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.siparişAktarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fYShopifyOrderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem4 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colCid = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCreatedAt = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUpdated_at = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCustomerName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSource = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFinancialStatus = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colorder_status_url = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemHyperLinkEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit();
            this.colfulfillment_status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colStocks = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colshipment_status = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colshipping_code = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIRKID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSLINDI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEKKULL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colETARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEKULL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKYNKKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHKCTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAmount = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCurrencyCode = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fYShopifyOrderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).BeginInit();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.siparişAktarToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(140, 26);
            // 
            // siparişAktarToolStripMenuItem
            // 
            this.siparişAktarToolStripMenuItem.Name = "siparişAktarToolStripMenuItem";
            this.siparişAktarToolStripMenuItem.Size = new System.Drawing.Size(139, 22);
            this.siparişAktarToolStripMenuItem.Text = "Sipariş Aktar";
            this.siparişAktarToolStripMenuItem.Click += new System.EventHandler(this.siparişAktarToolStripMenuItem_Click);
            // 
            // fYShopifyOrderBindingSource
            // 
            this.fYShopifyOrderBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.FY.FYShopifyOrder);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Top;
            this.button1.Location = new System.Drawing.Point(0, 24);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(799, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Dock = System.Windows.Forms.DockStyle.Top;
            this.button2.Location = new System.Drawing.Point(0, 47);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(799, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Ürünleri Güncelle";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Dock = System.Windows.Forms.DockStyle.Top;
            this.button3.Location = new System.Drawing.Point(0, 70);
            this.button3.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(799, 23);
            this.button3.TabIndex = 4;
            this.button3.Text = "Sipariş Getir";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Sipariş Aktar";
            this.barButtonItem3.Id = 35;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // barButtonItem4
            // 
            this.barButtonItem4.Caption = "Siparis Aktar";
            this.barButtonItem4.Id = 36;
            this.barButtonItem4.Name = "barButtonItem4";
            this.barButtonItem4.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem4_ItemClick);
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.DataSource = this.fYShopifyOrderBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 93);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.MenuManager = this.barManager;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemHyperLinkEdit1});
            this.gridControl1.Size = new System.Drawing.Size(799, 357);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCid,
            this.colSName,
            this.colCreatedAt,
            this.colUpdated_at,
            this.colCustomerId,
            this.colCustomerName,
            this.colSource,
            this.colFinancialStatus,
            this.colorder_status_url,
            this.colfulfillment_status,
            this.colStocks,
            this.colshipment_status,
            this.colshipping_code,
            this.colCRKODU,
            this.colId,
            this.colSIRKID,
            this.colACTIVE,
            this.colSLINDI,
            this.colEKKULL,
            this.colETARIH,
            this.colDEKULL,
            this.colDTARIH,
            this.colKYNKKD,
            this.colCHKCTR,
            this.colAmount,
            this.colCurrencyCode});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            // 
            // colCid
            // 
            this.colCid.FieldName = "Cid";
            this.colCid.Name = "colCid";
            this.colCid.Visible = true;
            this.colCid.VisibleIndex = 0;
            // 
            // colSName
            // 
            this.colSName.FieldName = "SName";
            this.colSName.Name = "colSName";
            this.colSName.Visible = true;
            this.colSName.VisibleIndex = 1;
            // 
            // colCreatedAt
            // 
            this.colCreatedAt.FieldName = "CreatedAt";
            this.colCreatedAt.Name = "colCreatedAt";
            this.colCreatedAt.Visible = true;
            this.colCreatedAt.VisibleIndex = 2;
            // 
            // colUpdated_at
            // 
            this.colUpdated_at.FieldName = "Updated_at";
            this.colUpdated_at.Name = "colUpdated_at";
            // 
            // colCustomerId
            // 
            this.colCustomerId.FieldName = "CustomerId";
            this.colCustomerId.Name = "colCustomerId";
            this.colCustomerId.Visible = true;
            this.colCustomerId.VisibleIndex = 3;
            // 
            // colCustomerName
            // 
            this.colCustomerName.FieldName = "CustomerName";
            this.colCustomerName.Name = "colCustomerName";
            this.colCustomerName.Visible = true;
            this.colCustomerName.VisibleIndex = 4;
            // 
            // colSource
            // 
            this.colSource.FieldName = "Source";
            this.colSource.Name = "colSource";
            this.colSource.Visible = true;
            this.colSource.VisibleIndex = 7;
            // 
            // colFinancialStatus
            // 
            this.colFinancialStatus.FieldName = "FinancialStatus";
            this.colFinancialStatus.Name = "colFinancialStatus";
            this.colFinancialStatus.Visible = true;
            this.colFinancialStatus.VisibleIndex = 8;
            // 
            // colorder_status_url
            // 
            this.colorder_status_url.ColumnEdit = this.repositoryItemHyperLinkEdit1;
            this.colorder_status_url.FieldName = "order_status_url";
            this.colorder_status_url.Name = "colorder_status_url";
            this.colorder_status_url.Visible = true;
            this.colorder_status_url.VisibleIndex = 9;
            // 
            // repositoryItemHyperLinkEdit1
            // 
            this.repositoryItemHyperLinkEdit1.AutoHeight = false;
            this.repositoryItemHyperLinkEdit1.Name = "repositoryItemHyperLinkEdit1";
            // 
            // colfulfillment_status
            // 
            this.colfulfillment_status.FieldName = "fulfillment_status";
            this.colfulfillment_status.Name = "colfulfillment_status";
            this.colfulfillment_status.Visible = true;
            this.colfulfillment_status.VisibleIndex = 10;
            // 
            // colStocks
            // 
            this.colStocks.FieldName = "Stocks";
            this.colStocks.Name = "colStocks";
            this.colStocks.Visible = true;
            this.colStocks.VisibleIndex = 11;
            // 
            // colshipment_status
            // 
            this.colshipment_status.FieldName = "shipment_status";
            this.colshipment_status.Name = "colshipment_status";
            this.colshipment_status.Visible = true;
            this.colshipment_status.VisibleIndex = 12;
            // 
            // colshipping_code
            // 
            this.colshipping_code.FieldName = "shipping_code";
            this.colshipping_code.Name = "colshipping_code";
            this.colshipping_code.Visible = true;
            this.colshipping_code.VisibleIndex = 13;
            // 
            // colCRKODU
            // 
            this.colCRKODU.FieldName = "CRKODU";
            this.colCRKODU.Name = "colCRKODU";
            this.colCRKODU.Visible = true;
            this.colCRKODU.VisibleIndex = 14;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            // 
            // colSIRKID
            // 
            this.colSIRKID.FieldName = "SIRKID";
            this.colSIRKID.Name = "colSIRKID";
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.Name = "colACTIVE";
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.Name = "colSLINDI";
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.Name = "colEKKULL";
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.Name = "colETARIH";
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.Name = "colDEKULL";
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.Name = "colDTARIH";
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.Name = "colKYNKKD";
            // 
            // colCHKCTR
            // 
            this.colCHKCTR.FieldName = "CHKCTR";
            this.colCHKCTR.Name = "colCHKCTR";
            // 
            // colAmount
            // 
            this.colAmount.Caption = "Toplam Tutar";
            this.colAmount.DisplayFormat.FormatString = "d2";
            this.colAmount.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colAmount.FieldName = "Amount";
            this.colAmount.Name = "colAmount";
            this.colAmount.Visible = true;
            this.colAmount.VisibleIndex = 5;
            // 
            // colCurrencyCode
            // 
            this.colCurrencyCode.Caption = "Para Birimi";
            this.colCurrencyCode.FieldName = "CurrencyCode";
            this.colCurrencyCode.Name = "colCurrencyCode";
            this.colCurrencyCode.Visible = true;
            this.colCurrencyCode.VisibleIndex = 6;
            // 
            // TempForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 450);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("TempForm.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(1, 3, 1, 3);
            this.Name = "TempForm";
            this.Text = "TempForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.TempForm_Load);
            this.Controls.SetChildIndex(this.button1, 0);
            this.Controls.SetChildIndex(this.button2, 0);
            this.Controls.SetChildIndex(this.button3, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.fYShopifyOrderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemHyperLinkEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.BarButtonItem barButtonItem4;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem siparişAktarToolStripMenuItem;
        private System.Windows.Forms.BindingSource fYShopifyOrderBindingSource;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colCid;
        private DevExpress.XtraGrid.Columns.GridColumn colSName;
        private DevExpress.XtraGrid.Columns.GridColumn colCreatedAt;
        private DevExpress.XtraGrid.Columns.GridColumn colUpdated_at;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerId;
        private DevExpress.XtraGrid.Columns.GridColumn colCustomerName;
        private DevExpress.XtraGrid.Columns.GridColumn colSource;
        private DevExpress.XtraGrid.Columns.GridColumn colFinancialStatus;
        private DevExpress.XtraGrid.Columns.GridColumn colorder_status_url;
        private DevExpress.XtraGrid.Columns.GridColumn colfulfillment_status;
        private DevExpress.XtraGrid.Columns.GridColumn colStocks;
        private DevExpress.XtraGrid.Columns.GridColumn colshipment_status;
        private DevExpress.XtraGrid.Columns.GridColumn colshipping_code;
        private DevExpress.XtraGrid.Columns.GridColumn colCRKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colSIRKID;
        private DevExpress.XtraGrid.Columns.GridColumn colACTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colSLINDI;
        private DevExpress.XtraGrid.Columns.GridColumn colEKKULL;
        private DevExpress.XtraGrid.Columns.GridColumn colETARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colDEKULL;
        private DevExpress.XtraGrid.Columns.GridColumn colDTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colKYNKKD;
        private DevExpress.XtraGrid.Columns.GridColumn colCHKCTR;
        private DevExpress.XtraEditors.Repository.RepositoryItemHyperLinkEdit repositoryItemHyperLinkEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colAmount;
        private DevExpress.XtraGrid.Columns.GridColumn colCurrencyCode;
    }
}