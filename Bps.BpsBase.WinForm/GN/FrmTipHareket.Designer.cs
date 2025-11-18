namespace BPS.Windows.Forms
{
    partial class FrmTipHareket
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipHareket));
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.label2 = new System.Windows.Forms.Label();
			this.LkEdDilKod = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView16 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.btnAra = new DevExpress.XtraEditors.SimpleButton();
			this.label1 = new System.Windows.Forms.Label();
			this.LkEdTip = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repHareketTablosu = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gNTHRKBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colTIPKOD = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTANIMI = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colHARKOD = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPARENT = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repoParent = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSIRASI = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGNICON = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSIRKID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSLINDI = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colEKKULL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colETARIH = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDEKULL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colKYNKKD = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCHKCTR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gNTHRKBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
			this.colEXTRA1 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LkEdDilKod.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView16)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.LkEdTip.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repHareketTablosu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gNTHRKBindingSource1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repoParent)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gNTHRKBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
			this.SuspendLayout();
			// 
			// xtraTabControl1
			// 
			resources.ApplyResources(this.xtraTabControl1, "xtraTabControl1");
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.label2);
			this.xtraTabPage1.Controls.Add(this.LkEdDilKod);
			this.xtraTabPage1.Controls.Add(this.btnAra);
			this.xtraTabPage1.Controls.Add(this.label1);
			this.xtraTabPage1.Controls.Add(this.LkEdTip);
			this.xtraTabPage1.Name = "xtraTabPage1";
			resources.ApplyResources(this.xtraTabPage1, "xtraTabPage1");
			// 
			// label2
			// 
			resources.ApplyResources(this.label2, "label2");
			this.label2.Name = "label2";
			// 
			// LkEdDilKod
			// 
			resources.ApplyResources(this.LkEdDilKod, "LkEdDilKod");
			this.LkEdDilKod.Name = "LkEdDilKod";
			this.LkEdDilKod.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			this.LkEdDilKod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("LkEdDilKod.Properties.Buttons"))))});
			this.LkEdDilKod.Properties.DisplayMember = "TANIMI";
			this.LkEdDilKod.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
			this.LkEdDilKod.Properties.NullText = resources.GetString("LkEdDilKod.Properties.NullText");
			this.LkEdDilKod.Properties.PopupView = this.gridView16;
			this.LkEdDilKod.Properties.ValueMember = "HARKOD";
			// 
			// gridView16
			// 
			this.gridView16.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn27,
            this.gridColumn28});
			this.gridView16.DetailHeight = 512;
			this.gridView16.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView16.Name = "gridView16";
			this.gridView16.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView16.OptionsView.ShowAutoFilterRow = true;
			this.gridView16.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn27
			// 
			this.gridColumn27.FieldName = "HARKOD";
			this.gridColumn27.MinWidth = 30;
			this.gridColumn27.Name = "gridColumn27";
			resources.ApplyResources(this.gridColumn27, "gridColumn27");
			// 
			// gridColumn28
			// 
			this.gridColumn28.FieldName = "TANIMI";
			this.gridColumn28.MinWidth = 30;
			this.gridColumn28.Name = "gridColumn28";
			resources.ApplyResources(this.gridColumn28, "gridColumn28");
			// 
			// btnAra
			// 
			this.btnAra.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnAra.ImageOptions.Image")));
			resources.ApplyResources(this.btnAra, "btnAra");
			this.btnAra.Name = "btnAra";
			this.btnAra.TabStop = false;
			this.btnAra.Click += new System.EventHandler(this.btnAra_Click);
			// 
			// label1
			// 
			resources.ApplyResources(this.label1, "label1");
			this.label1.Name = "label1";
			// 
			// LkEdTip
			// 
			resources.ApplyResources(this.LkEdTip, "LkEdTip");
			this.LkEdTip.Name = "LkEdTip";
			this.LkEdTip.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			this.LkEdTip.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("LkEdTip.Properties.Buttons"))))});
			this.LkEdTip.Properties.DisplayMember = "TIPADI";
			this.LkEdTip.Properties.NullText = resources.GetString("LkEdTip.Properties.NullText");
			this.LkEdTip.Properties.PopupView = this.gridView2;
			this.LkEdTip.Properties.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repHareketTablosu});
			this.LkEdTip.Properties.ValueMember = "TIPKOD";
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn1,
            this.gridColumn6});
			this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView2.OptionsView.ShowAutoFilterRow = true;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn4
			// 
			resources.ApplyResources(this.gridColumn4, "gridColumn4");
			this.gridColumn4.FieldName = "TIPADI";
			this.gridColumn4.MinWidth = 15;
			this.gridColumn4.Name = "gridColumn4";
			// 
			// gridColumn1
			// 
			resources.ApplyResources(this.gridColumn1, "gridColumn1");
			this.gridColumn1.FieldName = "TIPKOD";
			this.gridColumn1.Name = "gridColumn1";
			// 
			// gridColumn6
			// 
			this.gridColumn6.ColumnEdit = this.repHareketTablosu;
			this.gridColumn6.FieldName = "HRKTBL";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.ReadOnly = true;
			// 
			// repHareketTablosu
			// 
			this.repHareketTablosu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repHareketTablosu.Buttons"))))});
			this.repHareketTablosu.DisplayMember = "TANIMI";
			this.repHareketTablosu.Name = "repHareketTablosu";
			resources.ApplyResources(this.repHareketTablosu, "repHareketTablosu");
			this.repHareketTablosu.PopupView = this.gridView3;
			this.repHareketTablosu.ValueMember = "HARKOD";
			// 
			// gridView3
			// 
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn7,
            this.gridColumn8});
			this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn7
			// 
			this.gridColumn7.FieldName = "HARKOD";
			this.gridColumn7.Name = "gridColumn7";
			// 
			// gridColumn8
			// 
			this.gridColumn8.FieldName = "TANIMI";
			this.gridColumn8.Name = "gridColumn8";
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.gridControl1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			resources.ApplyResources(this.xtraTabPage2, "xtraTabPage2");
			// 
			// gridControl1
			// 
			this.gridControl1.DataSource = this.gNTHRKBindingSource1;
			resources.ApplyResources(this.gridControl1, "gridControl1");
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repoParent});
			this.gridControl1.Tag = "1";
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
			// 
			// gNTHRKBindingSource1
			// 
			this.gNTHRKBindingSource1.DataSource = typeof(Bps.BpsBase.Entities.Concrete.GN.GNTHRK);
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTIPKOD,
            this.colHARKOD,
            this.colTANIMI,
            this.colPARENT,
            this.colSIRASI,
            this.colGNICON,
            this.colACTIVE,
            this.colId,
            this.colEXTRA1,
            this.colSIRKID,
            this.colSLINDI,
            this.colEKKULL,
            this.colETARIH,
            this.colDEKULL,
            this.colDTARIH,
            this.colKYNKKD,
            this.colCHKCTR});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsScrollAnnotations.ShowErrors = DevExpress.Utils.DefaultBoolean.False;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
			this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
			this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
			// 
			// colTIPKOD
			// 
			this.colTIPKOD.FieldName = "TIPKOD";
			this.colTIPKOD.Name = "colTIPKOD";
			resources.ApplyResources(this.colTIPKOD, "colTIPKOD");
			// 
			// colTANIMI
			// 
			this.colTANIMI.FieldName = "TANIMI";
			this.colTANIMI.Name = "colTANIMI";
			resources.ApplyResources(this.colTANIMI, "colTANIMI");
			// 
			// colHARKOD
			// 
			this.colHARKOD.FieldName = "HARKOD";
			this.colHARKOD.Name = "colHARKOD";
			resources.ApplyResources(this.colHARKOD, "colHARKOD");
			// 
			// colPARENT
			// 
			this.colPARENT.ColumnEdit = this.repoParent;
			this.colPARENT.FieldName = "PARENT";
			this.colPARENT.Name = "colPARENT";
			resources.ApplyResources(this.colPARENT, "colPARENT");
			// 
			// repoParent
			// 
			resources.ApplyResources(this.repoParent, "repoParent");
			this.repoParent.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(((DevExpress.XtraEditors.Controls.ButtonPredefines)(resources.GetObject("repoParent.Buttons"))))});
			this.repoParent.DisplayMember = "TANIMI";
			this.repoParent.Name = "repoParent";
			this.repoParent.PopupView = this.repositoryItemGridLookUpEdit1View;
			this.repoParent.ValueMember = "Id";
			// 
			// repositoryItemGridLookUpEdit1View
			// 
			this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn5,
            this.gridColumn2});
			this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
			this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
			this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn3
			// 
			resources.ApplyResources(this.gridColumn3, "gridColumn3");
			this.gridColumn3.FieldName = "Id";
			this.gridColumn3.Name = "gridColumn3";
			// 
			// gridColumn5
			// 
			resources.ApplyResources(this.gridColumn5, "gridColumn5");
			this.gridColumn5.FieldName = "TIPKOD";
			this.gridColumn5.Name = "gridColumn5";
			// 
			// gridColumn2
			// 
			resources.ApplyResources(this.gridColumn2, "gridColumn2");
			this.gridColumn2.FieldName = "TANIMI";
			this.gridColumn2.Name = "gridColumn2";
			// 
			// colSIRASI
			// 
			this.colSIRASI.FieldName = "SIRASI";
			this.colSIRASI.Name = "colSIRASI";
			resources.ApplyResources(this.colSIRASI, "colSIRASI");
			// 
			// colGNICON
			// 
			this.colGNICON.FieldName = "GNICON";
			this.colGNICON.Name = "colGNICON";
			resources.ApplyResources(this.colGNICON, "colGNICON");
			// 
			// colACTIVE
			// 
			this.colACTIVE.FieldName = "ACTIVE";
			this.colACTIVE.Name = "colACTIVE";
			resources.ApplyResources(this.colACTIVE, "colACTIVE");
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			resources.ApplyResources(this.colId, "colId");
			// 
			// colSIRKID
			// 
			this.colSIRKID.FieldName = "SIRKID";
			this.colSIRKID.Name = "colSIRKID";
			resources.ApplyResources(this.colSIRKID, "colSIRKID");
			// 
			// colSLINDI
			// 
			this.colSLINDI.FieldName = "SLINDI";
			this.colSLINDI.Name = "colSLINDI";
			resources.ApplyResources(this.colSLINDI, "colSLINDI");
			// 
			// colEKKULL
			// 
			this.colEKKULL.FieldName = "EKKULL";
			this.colEKKULL.Name = "colEKKULL";
			resources.ApplyResources(this.colEKKULL, "colEKKULL");
			// 
			// colETARIH
			// 
			this.colETARIH.FieldName = "ETARIH";
			this.colETARIH.Name = "colETARIH";
			resources.ApplyResources(this.colETARIH, "colETARIH");
			// 
			// colDEKULL
			// 
			this.colDEKULL.FieldName = "DEKULL";
			this.colDEKULL.Name = "colDEKULL";
			resources.ApplyResources(this.colDEKULL, "colDEKULL");
			// 
			// colDTARIH
			// 
			this.colDTARIH.FieldName = "DTARIH";
			this.colDTARIH.Name = "colDTARIH";
			resources.ApplyResources(this.colDTARIH, "colDTARIH");
			// 
			// colKYNKKD
			// 
			this.colKYNKKD.FieldName = "KYNKKD";
			this.colKYNKKD.Name = "colKYNKKD";
			resources.ApplyResources(this.colKYNKKD, "colKYNKKD");
			// 
			// colCHKCTR
			// 
			this.colCHKCTR.FieldName = "CHKCTR";
			this.colCHKCTR.Name = "colCHKCTR";
			resources.ApplyResources(this.colCHKCTR, "colCHKCTR");
			// 
			// gNTHRKBindingSource
			// 
			this.gNTHRKBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.GN.GNTHRK);
			// 
			// dxErrorProvider1
			// 
			this.dxErrorProvider1.ContainerControl = this;
			this.dxErrorProvider1.DataSource = this.gNTHRKBindingSource1;
			// 
			// colEXTRA1
			// 
			this.colEXTRA1.FieldName = "EXTRA1";
			this.colEXTRA1.Name = "colEXTRA1";
			resources.ApplyResources(this.colEXTRA1, "colEXTRA1");
			// 
			// FrmTipHareket
			// 
			resources.ApplyResources(this, "$this");
			this.Controls.Add(this.xtraTabControl1);
			this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmTipHareket.IconOptions.Image")));
			this.Name = "FrmTipHareket";
			this.Load += new System.EventHandler(this.FrmTipHrk_Load);
			this.Controls.SetChildIndex(this.xtraTabControl1, 0);
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.xtraTabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LkEdDilKod.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView16)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.LkEdTip.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repHareketTablosu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gNTHRKBindingSource1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repoParent)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gNTHRKBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraEditors.SimpleButton btnAra;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.GridLookUpEdit LkEdTip;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource gNTHRKBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPKOD;
        private DevExpress.XtraGrid.Columns.GridColumn colHARKOD;
        private DevExpress.XtraGrid.Columns.GridColumn colPARENT;
        private DevExpress.XtraGrid.Columns.GridColumn colTANIMI;
        private DevExpress.XtraGrid.Columns.GridColumn colSIRASI;
        private DevExpress.XtraGrid.Columns.GridColumn colGNICON;
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
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repoParent;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private System.Windows.Forms.BindingSource gNTHRKBindingSource1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repHareketTablosu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private System.Windows.Forms.Label label2;
        private DevExpress.XtraEditors.GridLookUpEdit LkEdDilKod;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraGrid.Columns.GridColumn colEXTRA1;
    }
}
