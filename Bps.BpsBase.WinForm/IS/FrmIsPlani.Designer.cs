namespace BPS.Windows.Forms
{
	partial class FrmIsPlani
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
			System.Windows.Forms.Label bELGENLabel;
			System.Windows.Forms.Label eTARIHLabel;
			System.Windows.Forms.Label sTFYNOLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmIsPlani));
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.chkTamamlanan = new System.Windows.Forms.CheckBox();
			this.btnPlanAra = new DevExpress.XtraEditors.SimpleButton();
			this.txtPlanNo = new DevExpress.XtraEditors.TextEdit();
			this.dtBitis = new DevExpress.XtraEditors.DateEdit();
			this.dtBaslangic = new DevExpress.XtraEditors.DateEdit();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
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
			this.popContext = new DevExpress.XtraBars.PopupMenu(this.components);
			this.barButIsemriYazdir = new DevExpress.XtraBars.BarButtonItem();
			bELGENLabel = new System.Windows.Forms.Label();
			eTARIHLabel = new System.Windows.Forms.Label();
			sTFYNOLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPlanNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popContext)).BeginInit();
			this.SuspendLayout();
			// 
			// bELGENLabel
			// 
			bELGENLabel.AutoSize = true;
			bELGENLabel.Location = new System.Drawing.Point(25, 71);
			bELGENLabel.Name = "bELGENLabel";
			bELGENLabel.Size = new System.Drawing.Size(47, 13);
			bELGENLabel.TabIndex = 18;
			bELGENLabel.Text = "Plan No:";
			// 
			// eTARIHLabel
			// 
			eTARIHLabel.AutoSize = true;
			eTARIHLabel.Location = new System.Drawing.Point(25, 44);
			eTARIHLabel.Name = "eTARIHLabel";
			eTARIHLabel.Size = new System.Drawing.Size(60, 13);
			eTARIHLabel.TabIndex = 15;
			eTARIHLabel.Text = "Plan Tarihi:";
			// 
			// sTFYNOLabel
			// 
			sTFYNOLabel.AutoSize = true;
			sTFYNOLabel.Location = new System.Drawing.Point(25, 17);
			sTFYNOLabel.Name = "sTFYNOLabel";
			sTFYNOLabel.Size = new System.Drawing.Size(83, 13);
			sTFYNOLabel.TabIndex = 13;
			sTFYNOLabel.Text = "Tamamlananlar:";
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 24);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.Size = new System.Drawing.Size(957, 439);
			this.xtraTabControl1.TabIndex = 5;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.chkTamamlanan);
			this.xtraTabPage1.Controls.Add(this.btnPlanAra);
			this.xtraTabPage1.Controls.Add(bELGENLabel);
			this.xtraTabPage1.Controls.Add(this.txtPlanNo);
			this.xtraTabPage1.Controls.Add(this.dtBitis);
			this.xtraTabPage1.Controls.Add(this.dtBaslangic);
			this.xtraTabPage1.Controls.Add(eTARIHLabel);
			this.xtraTabPage1.Controls.Add(sTFYNOLabel);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(955, 414);
			this.xtraTabPage1.Text = "xtraTabPage1";
			// 
			// chkTamamlanan
			// 
			this.chkTamamlanan.AutoSize = true;
			this.chkTamamlanan.Location = new System.Drawing.Point(139, 18);
			this.chkTamamlanan.Name = "chkTamamlanan";
			this.chkTamamlanan.Size = new System.Drawing.Size(15, 14);
			this.chkTamamlanan.TabIndex = 21;
			this.chkTamamlanan.UseVisualStyleBackColor = true;
			// 
			// btnPlanAra
			// 
			this.btnPlanAra.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnPlanAra.ImageOptions.Image")));
			this.btnPlanAra.Location = new System.Drawing.Point(139, 103);
			this.btnPlanAra.Name = "btnPlanAra";
			this.btnPlanAra.Size = new System.Drawing.Size(75, 24);
			this.btnPlanAra.TabIndex = 20;
			this.btnPlanAra.Text = "ARA";
			this.btnPlanAra.Click += new System.EventHandler(this.btnPlanAra_Click);
			// 
			// txtPlanNo
			// 
			this.txtPlanNo.Location = new System.Drawing.Point(139, 68);
			this.txtPlanNo.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.txtPlanNo.MenuManager = this.barManager;
			this.txtPlanNo.Name = "txtPlanNo";
			this.txtPlanNo.Size = new System.Drawing.Size(131, 20);
			this.txtPlanNo.TabIndex = 19;
			// 
			// dtBitis
			// 
			this.dtBitis.EditValue = null;
			this.dtBitis.Location = new System.Drawing.Point(273, 41);
			this.dtBitis.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.dtBitis.MenuManager = this.barManager;
			this.dtBitis.Name = "dtBitis";
			this.dtBitis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBitis.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBitis.Size = new System.Drawing.Size(125, 20);
			this.dtBitis.TabIndex = 17;
			// 
			// dtBaslangic
			// 
			this.dtBaslangic.EditValue = null;
			this.dtBaslangic.Location = new System.Drawing.Point(139, 41);
			this.dtBaslangic.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.dtBaslangic.MenuManager = this.barManager;
			this.dtBaslangic.Name = "dtBaslangic";
			this.dtBaslangic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBaslangic.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBaslangic.Size = new System.Drawing.Size(131, 20);
			this.dtBaslangic.TabIndex = 16;
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.gridControl1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(955, 414);
			this.xtraTabPage2.Text = "xtraTabPage2";
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2,
            this.repositoryItemGridLookUpEdit3});
			this.gridControl1.Size = new System.Drawing.Size(955, 414);
			this.gridControl1.TabIndex = 4;
			this.gridControl1.Tag = "1";
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsDetail.ShowDetailTabs = false;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.ShowAutoFilterRow = true;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.Tag = "STKART";
			this.gridView1.MasterRowExpanded += new DevExpress.XtraGrid.Views.Grid.CustomMasterRowEventHandler(this.gridView1_MasterRowExpanded);
			this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
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
			// popContext
			// 
			this.popContext.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButIsemriYazdir)});
			this.popContext.Manager = this.barManager;
			this.popContext.Name = "popContext";
			// 
			// barButIsemriYazdir
			// 
			this.barButIsemriYazdir.Caption = "İşemri Yazdır";
			this.barButIsemriYazdir.Id = 28;
			this.barButIsemriYazdir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButIsemriYazdir.ImageOptions.Image")));
			this.barButIsemriYazdir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButIsemriYazdir.ImageOptions.LargeImage")));
			this.barButIsemriYazdir.Name = "barButIsemriYazdir";
			this.barButIsemriYazdir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButIsemriYazdir_ItemClick);
			// 
			// FrmIsPlani
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(957, 463);
			this.Controls.Add(this.xtraTabControl1);
			this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmIsPlani.IconOptions.Image")));
			this.Name = "FrmIsPlani";
			this.Load += new System.EventHandler(this.FrmIsPlani_Load);
			this.Controls.SetChildIndex(this.xtraTabControl1, 0);
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.xtraTabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtPlanNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popContext)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
		private System.Windows.Forms.CheckBox chkTamamlanan;
		private DevExpress.XtraEditors.SimpleButton btnPlanAra;
		private DevExpress.XtraEditors.TextEdit txtPlanNo;
		private DevExpress.XtraEditors.DateEdit dtBitis;
		private DevExpress.XtraEditors.DateEdit dtBaslangic;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
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
		private DevExpress.XtraBars.PopupMenu popContext;
		private DevExpress.XtraBars.BarButtonItem barButIsemriYazdir;
	}
}
