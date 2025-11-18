namespace BPS.Windows.Forms
{
    partial class FrmSaRapor
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
			System.Windows.Forms.Label eTARIHLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSaRapor));
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.pageMasterDetail = new DevExpress.XtraTab.XtraTabPage();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn64 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn60 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn61 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn63 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			this.btnClear = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.LkEdStokKart = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.dtBitis = new DevExpress.XtraEditors.DateEdit();
			this.dtBaslangic = new DevExpress.XtraEditors.DateEdit();
			this.popSaAyrinti = new DevExpress.XtraBars.PopupMenu(this.components);
			this.barButSaSiparis = new DevExpress.XtraBars.BarButtonItem();
			eTARIHLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.pageMasterDetail.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LkEdStokKart.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popSaAyrinti)).BeginInit();
			this.SuspendLayout();
			// 
			// eTARIHLabel
			// 
			eTARIHLabel.AutoSize = true;
			eTARIHLabel.Location = new System.Drawing.Point(15, 11);
			eTARIHLabel.Name = "eTARIHLabel";
			eTARIHLabel.Size = new System.Drawing.Size(67, 13);
			eTARIHLabel.TabIndex = 10;
			eTARIHLabel.Text = "Tarih Aralığı:";
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 24);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.pageMasterDetail;
			this.xtraTabControl1.Size = new System.Drawing.Size(957, 439);
			this.xtraTabControl1.TabIndex = 6;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageMasterDetail});
			// 
			// pageMasterDetail
			// 
			this.pageMasterDetail.Controls.Add(this.gridControl1);
			this.pageMasterDetail.Controls.Add(this.panelControl1);
			this.pageMasterDetail.Name = "pageMasterDetail";
			this.pageMasterDetail.Size = new System.Drawing.Size(955, 414);
			this.pageMasterDetail.Text = "Satınalma Raporu";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 36);
			this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2,
            this.repositoryItemGridLookUpEdit3});
			this.gridControl1.Size = new System.Drawing.Size(955, 378);
			this.gridControl1.TabIndex = 3;
			this.gridControl1.Tag = "1";
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			this.gridControl1.ViewRegistered += new DevExpress.XtraGrid.ViewOperationEventHandler(this.gridControl1_ViewRegistered);
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn64,
            this.gridColumn60,
            this.gridColumn61,
            this.gridColumn62,
            this.gridColumn2,
            this.gridColumn63,
            this.gridColumn1});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsDetail.ShowDetailTabs = false;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.ShowAutoFilterRow = true;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.Tag = "STKART";
			// 
			// gridColumn64
			// 
			this.gridColumn64.Caption = "Şirket Id";
			this.gridColumn64.FieldName = "SIRKID";
			this.gridColumn64.Name = "gridColumn64";
			this.gridColumn64.OptionsColumn.ReadOnly = true;
			// 
			// gridColumn60
			// 
			this.gridColumn60.Caption = "Cari Kodu";
			this.gridColumn60.FieldName = "CRKODU";
			this.gridColumn60.Name = "gridColumn60";
			this.gridColumn60.OptionsColumn.ReadOnly = true;
			this.gridColumn60.Visible = true;
			this.gridColumn60.VisibleIndex = 0;
			// 
			// gridColumn61
			// 
			this.gridColumn61.Caption = "Cari Adı";
			this.gridColumn61.FieldName = "CRUNV1";
			this.gridColumn61.Name = "gridColumn61";
			this.gridColumn61.OptionsColumn.ReadOnly = true;
			this.gridColumn61.Visible = true;
			this.gridColumn61.VisibleIndex = 1;
			// 
			// gridColumn62
			// 
			this.gridColumn62.Caption = "Döviz Cinsi";
			this.gridColumn62.FieldName = "DVCNKD";
			this.gridColumn62.Name = "gridColumn62";
			this.gridColumn62.OptionsColumn.ReadOnly = true;
			this.gridColumn62.Visible = true;
			this.gridColumn62.VisibleIndex = 2;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Döviz Birim Fiyat";
			this.gridColumn2.FieldName = "DVBRFY";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.ReadOnly = true;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 3;
			// 
			// gridColumn63
			// 
			this.gridColumn63.Caption = "Toplam Net Tutar (Döviz)";
			this.gridColumn63.DisplayFormat.FormatString = "n2";
			this.gridColumn63.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn63.FieldName = "TOPKDT";
			this.gridColumn63.Name = "gridColumn63";
			this.gridColumn63.OptionsColumn.ReadOnly = true;
			this.gridColumn63.Visible = true;
			this.gridColumn63.VisibleIndex = 4;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Toplam Net Tutar (TL)";
			this.gridColumn1.DisplayFormat.FormatString = "n2";
			this.gridColumn1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
			this.gridColumn1.FieldName = "TLFIYT";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.ReadOnly = true;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 5;
			// 
			// repositoryItemGridLookUpEdit1
			// 
			this.repositoryItemGridLookUpEdit1.AutoHeight = false;
			this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit1.DisplayMember = "TANIMI";
			this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
			this.repositoryItemGridLookUpEdit1.NullText = "";
			this.repositoryItemGridLookUpEdit1.PopupView = this.gridView6;
			this.repositoryItemGridLookUpEdit1.ValueMember = "HARKOD";
			// 
			// gridView6
			// 
			this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn50,
            this.gridColumn51});
			this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView6.Name = "gridView6";
			this.gridView6.OptionsBehavior.Editable = false;
			this.gridView6.OptionsBehavior.ReadOnly = true;
			this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView6.OptionsView.ShowAutoFilterRow = true;
			this.gridView6.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn50
			// 
			this.gridColumn50.Caption = "Kod";
			this.gridColumn50.FieldName = "HARKOD";
			this.gridColumn50.Name = "gridColumn50";
			this.gridColumn50.Visible = true;
			this.gridColumn50.VisibleIndex = 0;
			// 
			// gridColumn51
			// 
			this.gridColumn51.Caption = "Tanım";
			this.gridColumn51.FieldName = "TANIMI";
			this.gridColumn51.Name = "gridColumn51";
			this.gridColumn51.Visible = true;
			this.gridColumn51.VisibleIndex = 1;
			// 
			// repositoryItemGridLookUpEdit2
			// 
			this.repositoryItemGridLookUpEdit2.AutoHeight = false;
			this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit2.DisplayMember = "TANIMI";
			this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
			this.repositoryItemGridLookUpEdit2.NullText = "";
			this.repositoryItemGridLookUpEdit2.PopupView = this.gridView7;
			this.repositoryItemGridLookUpEdit2.ValueMember = "HARKOD";
			// 
			// gridView7
			// 
			this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn53,
            this.gridColumn54});
			this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView7.Name = "gridView7";
			this.gridView7.OptionsBehavior.Editable = false;
			this.gridView7.OptionsBehavior.ReadOnly = true;
			this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView7.OptionsView.ShowAutoFilterRow = true;
			this.gridView7.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn53
			// 
			this.gridColumn53.Caption = "Kod";
			this.gridColumn53.FieldName = "HARKOD";
			this.gridColumn53.Name = "gridColumn53";
			this.gridColumn53.Visible = true;
			this.gridColumn53.VisibleIndex = 0;
			// 
			// gridColumn54
			// 
			this.gridColumn54.Caption = "Tanım";
			this.gridColumn54.FieldName = "TANIMI";
			this.gridColumn54.Name = "gridColumn54";
			this.gridColumn54.Visible = true;
			this.gridColumn54.VisibleIndex = 1;
			// 
			// repositoryItemGridLookUpEdit3
			// 
			this.repositoryItemGridLookUpEdit3.AutoHeight = false;
			this.repositoryItemGridLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit3.DisplayMember = "TANIMI";
			this.repositoryItemGridLookUpEdit3.Name = "repositoryItemGridLookUpEdit3";
			this.repositoryItemGridLookUpEdit3.NullText = "";
			this.repositoryItemGridLookUpEdit3.PopupView = this.gridView8;
			this.repositoryItemGridLookUpEdit3.ValueMember = "HARKOD";
			// 
			// gridView8
			// 
			this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn56,
            this.gridColumn57});
			this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView8.Name = "gridView8";
			this.gridView8.OptionsBehavior.Editable = false;
			this.gridView8.OptionsBehavior.ReadOnly = true;
			this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView8.OptionsView.ShowAutoFilterRow = true;
			this.gridView8.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn56
			// 
			this.gridColumn56.Caption = "Kod";
			this.gridColumn56.FieldName = "HARKOD";
			this.gridColumn56.Name = "gridColumn56";
			this.gridColumn56.Visible = true;
			this.gridColumn56.VisibleIndex = 0;
			// 
			// gridColumn57
			// 
			this.gridColumn57.Caption = "Tanım";
			this.gridColumn57.FieldName = "TANIMI";
			this.gridColumn57.Name = "gridColumn57";
			this.gridColumn57.Visible = true;
			this.gridColumn57.VisibleIndex = 1;
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.btnClear);
			this.panelControl1.Controls.Add(this.label1);
			this.panelControl1.Controls.Add(this.LkEdStokKart);
			this.panelControl1.Controls.Add(this.dtBitis);
			this.panelControl1.Controls.Add(this.dtBaslangic);
			this.panelControl1.Controls.Add(eTARIHLabel);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
			this.panelControl1.Location = new System.Drawing.Point(0, 0);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(955, 36);
			this.panelControl1.TabIndex = 4;
			// 
			// btnClear
			// 
			this.btnClear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnClear.ImageOptions.Image")));
			this.btnClear.Location = new System.Drawing.Point(829, 8);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(23, 20);
			this.btnClear.TabIndex = 16;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(378, 11);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(52, 13);
			this.label1.TabIndex = 14;
			this.label1.Text = "Stok Ara:";
			// 
			// LkEdStokKart
			// 
			this.LkEdStokKart.EditValue = "";
			this.LkEdStokKart.Location = new System.Drawing.Point(434, 8);
			this.LkEdStokKart.Name = "LkEdStokKart";
			this.LkEdStokKart.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			this.LkEdStokKart.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.LkEdStokKart.Properties.DisplayMember = "STKNAM";
			this.LkEdStokKart.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.LkEdStokKart.Properties.NullText = "";
			this.LkEdStokKart.Properties.PopupView = this.gridLookUpEdit1View;
			this.LkEdStokKart.Properties.ValueMember = "STKODU";
			this.LkEdStokKart.Size = new System.Drawing.Size(389, 20);
			this.LkEdStokKart.TabIndex = 13;
			this.LkEdStokKart.EditValueChanged += new System.EventHandler(this.LkEdStokKart_EditValueChanged);
			// 
			// gridLookUpEdit1View
			// 
			this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
			this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
			this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
			this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Stok Kodu";
			this.gridColumn3.FieldName = "STKODU";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 0;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Stok Adı";
			this.gridColumn4.FieldName = "STKNAM";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 1;
			// 
			// dtBitis
			// 
			this.dtBitis.EditValue = null;
			this.dtBitis.Location = new System.Drawing.Point(225, 8);
			this.dtBitis.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.dtBitis.MenuManager = this.barManager;
			this.dtBitis.Name = "dtBitis";
			this.dtBitis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBitis.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBitis.Size = new System.Drawing.Size(125, 20);
			this.dtBitis.TabIndex = 12;
			// 
			// dtBaslangic
			// 
			this.dtBaslangic.EditValue = null;
			this.dtBaslangic.Location = new System.Drawing.Point(88, 8);
			this.dtBaslangic.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.dtBaslangic.MenuManager = this.barManager;
			this.dtBaslangic.Name = "dtBaslangic";
			this.dtBaslangic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBaslangic.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBaslangic.Size = new System.Drawing.Size(131, 20);
			this.dtBaslangic.TabIndex = 11;
			// 
			// popSaAyrinti
			// 
			this.popSaAyrinti.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButSaSiparis)});
			this.popSaAyrinti.Manager = this.barManager;
			this.popSaAyrinti.Name = "popSaAyrinti";
			// 
			// barButSaSiparis
			// 
			this.barButSaSiparis.Caption = "Satınalma Siparişine Git";
			this.barButSaSiparis.Id = 27;
			this.barButSaSiparis.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButSaSiparis.ImageOptions.Image")));
			this.barButSaSiparis.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButSaSiparis.ImageOptions.LargeImage")));
			this.barButSaSiparis.Name = "barButSaSiparis";
			this.barButSaSiparis.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButSaSiparis_ItemClick);
			// 
			// FrmSaRapor
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(957, 463);
			this.Controls.Add(this.xtraTabControl1);
			this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmSaRapor.IconOptions.Image")));
			this.Name = "FrmSaRapor";
			this.Load += new System.EventHandler(this.FrmSaRapor_Load);
			this.Controls.SetChildIndex(this.xtraTabControl1, 0);
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.pageMasterDetail.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.panelControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LkEdStokKart.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popSaAyrinti)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage pageMasterDetail;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn51;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn54;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn64;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn60;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn61;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn63;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private DevExpress.XtraEditors.DateEdit dtBitis;
        private DevExpress.XtraEditors.DateEdit dtBaslangic;
        private DevExpress.XtraBars.PopupMenu popSaAyrinti;
        private DevExpress.XtraBars.BarButtonItem barButSaSiparis;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GridLookUpEdit LkEdStokKart;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraEditors.SimpleButton btnClear;
    }
}
