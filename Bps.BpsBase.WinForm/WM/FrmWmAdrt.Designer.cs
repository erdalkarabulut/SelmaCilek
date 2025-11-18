namespace BPS.Windows.Forms
{
    partial class FrmWmAdrt
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
            System.Windows.Forms.Label aCTIVELabel;
            System.Windows.Forms.Label dCSTBLLabel;
            System.Windows.Forms.Label dEPOKDLabel;
            System.Windows.Forms.Label dGSTBLLabel;
            System.Windows.Forms.Label dPACKDLabel;
            System.Windows.Forms.Label dPADRSLabel;
            System.Windows.Forms.Label dPALKDLabel;
            System.Windows.Forms.Label dPASRLLabel;
            System.Windows.Forms.Label dPATKDLabel;
            System.Windows.Forms.Label dPCSRLLabel;
            System.Windows.Forms.Label dPTIPILabel;
            System.Windows.Forms.Label sTARIHLabel;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmWmAdrt));
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.wMADRTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colDEPOKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPTIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkedDepoTip = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPADRS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPALKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPATKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPACKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDGSTBL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDCSTBL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPASRL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPCSRL = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.aCTIVECheckBox = new System.Windows.Forms.CheckBox();
            this.dCSTBLCheckBox = new System.Windows.Forms.CheckBox();
            this.dEPOKDGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.dEPOKDGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dGSTBLCheckBox = new System.Windows.Forms.CheckBox();
            this.dPACKDGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.dPACKDGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dPADRSTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dPALKDGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.dPALKDGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dPASRLTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dPATKDGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.dPATKDGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dPCSRLTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.dPTIPIGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.dPTIPIGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sTARIHDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.popEtiket = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButEtiketYazdir = new DevExpress.XtraBars.BarButtonItem();
            aCTIVELabel = new System.Windows.Forms.Label();
            dCSTBLLabel = new System.Windows.Forms.Label();
            dEPOKDLabel = new System.Windows.Forms.Label();
            dGSTBLLabel = new System.Windows.Forms.Label();
            dPACKDLabel = new System.Windows.Forms.Label();
            dPADRSLabel = new System.Windows.Forms.Label();
            dPALKDLabel = new System.Windows.Forms.Label();
            dPASRLLabel = new System.Windows.Forms.Label();
            dPATKDLabel = new System.Windows.Forms.Label();
            dPCSRLLabel = new System.Windows.Forms.Label();
            dPTIPILabel = new System.Windows.Forms.Label();
            sTARIHLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMADRTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedDepoTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEPOKDGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPOKDGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPACKDGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPACKDGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPADRSTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPALKDGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPALKDGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPASRLTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPATKDGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPATKDGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPCSRLTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPTIPIGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPTIPIGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTARIHDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTARIHDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popEtiket)).BeginInit();
            this.SuspendLayout();
            // 
            // aCTIVELabel
            // 
            aCTIVELabel.AutoSize = true;
            aCTIVELabel.Location = new System.Drawing.Point(40, 217);
            aCTIVELabel.Name = "aCTIVELabel";
            aCTIVELabel.Size = new System.Drawing.Size(42, 13);
            aCTIVELabel.TabIndex = 0;
            aCTIVELabel.Text = "Durum:";
            // 
            // dCSTBLLabel
            // 
            dCSTBLLabel.AutoSize = true;
            dCSTBLLabel.Location = new System.Drawing.Point(365, 53);
            dCSTBLLabel.Name = "dCSTBLLabel";
            dCSTBLLabel.Size = new System.Drawing.Size(126, 13);
            dCSTBLLabel.TabIndex = 4;
            dCSTBLLabel.Text = "Depodan Çikarma Blokaj:";
            // 
            // dEPOKDLabel
            // 
            dEPOKDLabel.AutoSize = true;
            dEPOKDLabel.Location = new System.Drawing.Point(40, 28);
            dEPOKDLabel.Name = "dEPOKDLabel";
            dEPOKDLabel.Size = new System.Drawing.Size(83, 13);
            dEPOKDLabel.TabIndex = 8;
            dEPOKDLabel.Text = "Depo Numarasi:";
            // 
            // dGSTBLLabel
            // 
            dGSTBLLabel.AutoSize = true;
            dGSTBLLabel.Location = new System.Drawing.Point(365, 28);
            dGSTBLLabel.Name = "dGSTBLLabel";
            dGSTBLLabel.Size = new System.Drawing.Size(89, 13);
            dGSTBLLabel.TabIndex = 10;
            dGSTBLLabel.Text = "Depolama Blokaj:";
            // 
            // dPACKDLabel
            // 
            dPACKDLabel.AutoSize = true;
            dPACKDLabel.Location = new System.Drawing.Point(40, 159);
            dPACKDLabel.Name = "dPACKDLabel";
            dPACKDLabel.Size = new System.Drawing.Size(130, 13);
            dPACKDLabel.TabIndex = 12;
            dPACKDLabel.Text = "Depo Adresi Çekme Alani:";
            // 
            // dPADRSLabel
            // 
            dPADRSLabel.AutoSize = true;
            dPADRSLabel.Location = new System.Drawing.Point(40, 80);
            dPADRSLabel.Name = "dPADRSLabel";
            dPADRSLabel.Size = new System.Drawing.Size(69, 13);
            dPADRSLabel.TabIndex = 14;
            dPADRSLabel.Text = "Depo Adresi:";
            // 
            // dPALKDLabel
            // 
            dPALKDLabel.AutoSize = true;
            dPALKDLabel.Location = new System.Drawing.Point(40, 107);
            dPALKDLabel.Name = "dPALKDLabel";
            dPALKDLabel.Size = new System.Drawing.Size(62, 13);
            dPALKDLabel.TabIndex = 16;
            dPALKDLabel.Text = "Depo Alani:";
            // 
            // dPASRLLabel
            // 
            dPASRLLabel.AutoSize = true;
            dPASRLLabel.Location = new System.Drawing.Point(365, 80);
            dPASRLLabel.Name = "dPASRLLabel";
            dPASRLLabel.Size = new System.Drawing.Size(79, 13);
            dPASRLLabel.TabIndex = 18;
            dPASRLLabel.Text = "Depo Siralama:";
            // 
            // dPATKDLabel
            // 
            dPATKDLabel.AutoSize = true;
            dPATKDLabel.Location = new System.Drawing.Point(40, 132);
            dPATKDLabel.Name = "dPATKDLabel";
            dPATKDLabel.Size = new System.Drawing.Size(86, 13);
            dPATKDLabel.TabIndex = 20;
            dPATKDLabel.Text = "Depo Adres Tipi:";
            // 
            // dPCSRLLabel
            // 
            dPCSRLLabel.AutoSize = true;
            dPCSRLLabel.Location = new System.Drawing.Point(365, 106);
            dPCSRLLabel.Name = "dPCSRLLabel";
            dPCSRLLabel.Size = new System.Drawing.Size(114, 13);
            dPCSRLLabel.TabIndex = 22;
            dPCSRLLabel.Text = "Depo Çekme Siralama:";
            // 
            // dPTIPILabel
            // 
            dPTIPILabel.AutoSize = true;
            dPTIPILabel.Location = new System.Drawing.Point(40, 53);
            dPTIPILabel.Name = "dPTIPILabel";
            dPTIPILabel.Size = new System.Drawing.Size(76, 13);
            dPTIPILabel.TabIndex = 24;
            dPTIPILabel.Text = "WM Depo Tipi:";
            // 
            // sTARIHLabel
            // 
            sTARIHLabel.AutoSize = true;
            sTARIHLabel.Location = new System.Drawing.Point(40, 187);
            sTARIHLabel.Name = "sTARIHLabel";
            sTARIHLabel.Size = new System.Drawing.Size(99, 13);
            sTARIHLabel.TabIndex = 40;
            sTARIHLabel.Text = "Son Hareket Tarihi:";
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
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(955, 414);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.wMADRTBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLkedDepoTip});
            this.gridControl1.Size = new System.Drawing.Size(955, 414);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // wMADRTBindingSource
            // 
            this.wMADRTBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.WM.WMADRT);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colDEPOKD,
            this.colDPTIPI,
            this.colDPADRS,
            this.colDPALKD,
            this.colDPATKD,
            this.colDPACKD,
            this.colDGSTBL,
            this.colDCSTBL,
            this.colSTARIH,
            this.colDPASRL,
            this.colDPCSRL,
            this.colId,
            this.colSIRKID,
            this.colACTIVE,
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
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // colDEPOKD
            // 
            this.colDEPOKD.FieldName = "DEPOKD";
            this.colDEPOKD.Name = "colDEPOKD";
            this.colDEPOKD.Visible = true;
            this.colDEPOKD.VisibleIndex = 0;
            // 
            // colDPTIPI
            // 
            this.colDPTIPI.ColumnEdit = this.repLkedDepoTip;
            this.colDPTIPI.FieldName = "DPTIPI";
            this.colDPTIPI.Name = "colDPTIPI";
            this.colDPTIPI.Visible = true;
            this.colDPTIPI.VisibleIndex = 1;
            // 
            // repLkedDepoTip
            // 
            this.repLkedDepoTip.AutoHeight = false;
            this.repLkedDepoTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkedDepoTip.DisplayMember = "DPTIPT";
            this.repLkedDepoTip.Name = "repLkedDepoTip";
            this.repLkedDepoTip.NullText = "";
            this.repLkedDepoTip.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repLkedDepoTip.ValueMember = "DPTIPI";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn12,
            this.gridColumn11});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Tanım";
            this.gridColumn12.FieldName = "DPTIPT";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 0;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Kod";
            this.gridColumn11.FieldName = "DPTIPI";
            this.gridColumn11.Name = "gridColumn11";
            this.gridColumn11.Visible = true;
            this.gridColumn11.VisibleIndex = 1;
            // 
            // colDPADRS
            // 
            this.colDPADRS.FieldName = "DPADRS";
            this.colDPADRS.Name = "colDPADRS";
            this.colDPADRS.Visible = true;
            this.colDPADRS.VisibleIndex = 2;
            // 
            // colDPALKD
            // 
            this.colDPALKD.FieldName = "DPALKD";
            this.colDPALKD.Name = "colDPALKD";
            this.colDPALKD.Visible = true;
            this.colDPALKD.VisibleIndex = 3;
            // 
            // colDPATKD
            // 
            this.colDPATKD.FieldName = "DPATKD";
            this.colDPATKD.Name = "colDPATKD";
            this.colDPATKD.Visible = true;
            this.colDPATKD.VisibleIndex = 4;
            // 
            // colDPACKD
            // 
            this.colDPACKD.FieldName = "DPACKD";
            this.colDPACKD.Name = "colDPACKD";
            this.colDPACKD.Visible = true;
            this.colDPACKD.VisibleIndex = 5;
            // 
            // colDGSTBL
            // 
            this.colDGSTBL.FieldName = "DGSTBL";
            this.colDGSTBL.Name = "colDGSTBL";
            this.colDGSTBL.Visible = true;
            this.colDGSTBL.VisibleIndex = 6;
            // 
            // colDCSTBL
            // 
            this.colDCSTBL.FieldName = "DCSTBL";
            this.colDCSTBL.Name = "colDCSTBL";
            this.colDCSTBL.Visible = true;
            this.colDCSTBL.VisibleIndex = 7;
            // 
            // colSTARIH
            // 
            this.colSTARIH.FieldName = "STARIH";
            this.colSTARIH.Name = "colSTARIH";
            this.colSTARIH.Visible = true;
            this.colSTARIH.VisibleIndex = 8;
            // 
            // colDPASRL
            // 
            this.colDPASRL.FieldName = "DPASRL";
            this.colDPASRL.Name = "colDPASRL";
            this.colDPASRL.Visible = true;
            this.colDPASRL.VisibleIndex = 9;
            // 
            // colDPCSRL
            // 
            this.colDPCSRL.FieldName = "DPCSRL";
            this.colDPCSRL.Name = "colDPCSRL";
            this.colDPCSRL.Visible = true;
            this.colDPCSRL.VisibleIndex = 10;
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
            // xtraTabPage2
            // 
            this.xtraTabPage2.AutoScroll = true;
            this.xtraTabPage2.Controls.Add(aCTIVELabel);
            this.xtraTabPage2.Controls.Add(this.aCTIVECheckBox);
            this.xtraTabPage2.Controls.Add(dCSTBLLabel);
            this.xtraTabPage2.Controls.Add(this.dCSTBLCheckBox);
            this.xtraTabPage2.Controls.Add(dEPOKDLabel);
            this.xtraTabPage2.Controls.Add(this.dEPOKDGridLookUpEdit);
            this.xtraTabPage2.Controls.Add(dGSTBLLabel);
            this.xtraTabPage2.Controls.Add(this.dGSTBLCheckBox);
            this.xtraTabPage2.Controls.Add(dPACKDLabel);
            this.xtraTabPage2.Controls.Add(this.dPACKDGridLookUpEdit);
            this.xtraTabPage2.Controls.Add(dPADRSLabel);
            this.xtraTabPage2.Controls.Add(this.dPADRSTextEdit);
            this.xtraTabPage2.Controls.Add(dPALKDLabel);
            this.xtraTabPage2.Controls.Add(this.dPALKDGridLookUpEdit);
            this.xtraTabPage2.Controls.Add(dPASRLLabel);
            this.xtraTabPage2.Controls.Add(this.dPASRLTextEdit);
            this.xtraTabPage2.Controls.Add(dPATKDLabel);
            this.xtraTabPage2.Controls.Add(this.dPATKDGridLookUpEdit);
            this.xtraTabPage2.Controls.Add(dPCSRLLabel);
            this.xtraTabPage2.Controls.Add(this.dPCSRLTextEdit);
            this.xtraTabPage2.Controls.Add(dPTIPILabel);
            this.xtraTabPage2.Controls.Add(this.dPTIPIGridLookUpEdit);
            this.xtraTabPage2.Controls.Add(sTARIHLabel);
            this.xtraTabPage2.Controls.Add(this.sTARIHDateEdit);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(955, 414);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // aCTIVECheckBox
            // 
            this.aCTIVECheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.wMADRTBindingSource, "ACTIVE", true));
            this.aCTIVECheckBox.Location = new System.Drawing.Point(208, 214);
            this.aCTIVECheckBox.Name = "aCTIVECheckBox";
            this.aCTIVECheckBox.Size = new System.Drawing.Size(104, 16);
            this.aCTIVECheckBox.TabIndex = 1;
            this.aCTIVECheckBox.UseVisualStyleBackColor = true;
            // 
            // dCSTBLCheckBox
            // 
            this.dCSTBLCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.wMADRTBindingSource, "DCSTBL", true));
            this.dCSTBLCheckBox.Location = new System.Drawing.Point(529, 53);
            this.dCSTBLCheckBox.Name = "dCSTBLCheckBox";
            this.dCSTBLCheckBox.Size = new System.Drawing.Size(104, 16);
            this.dCSTBLCheckBox.TabIndex = 5;
            this.dCSTBLCheckBox.UseVisualStyleBackColor = true;
            // 
            // dEPOKDGridLookUpEdit
            // 
            this.dEPOKDGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "DEPOKD", true));
            this.dEPOKDGridLookUpEdit.Location = new System.Drawing.Point(208, 25);
            this.dEPOKDGridLookUpEdit.MenuManager = this.barManager;
            this.dEPOKDGridLookUpEdit.Name = "dEPOKDGridLookUpEdit";
            this.dEPOKDGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dEPOKDGridLookUpEdit.Properties.DisplayMember = "TANIMI";
            this.dEPOKDGridLookUpEdit.Properties.NullText = "";
            this.dEPOKDGridLookUpEdit.Properties.PopupView = this.dEPOKDGridLookUpEditView;
            this.dEPOKDGridLookUpEdit.Properties.ValueMember = "HARKOD";
            this.dEPOKDGridLookUpEdit.Size = new System.Drawing.Size(104, 20);
            this.dEPOKDGridLookUpEdit.TabIndex = 9;
            this.dEPOKDGridLookUpEdit.EditValueChanged += new System.EventHandler(this.dEPOKDGridLookUpEdit_EditValueChanged);
            // 
            // dEPOKDGridLookUpEditView
            // 
            this.dEPOKDGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn2,
            this.gridColumn1});
            this.dEPOKDGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.dEPOKDGridLookUpEditView.Name = "dEPOKDGridLookUpEditView";
            this.dEPOKDGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dEPOKDGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tanım";
            this.gridColumn2.FieldName = "TANIMI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kod";
            this.gridColumn1.FieldName = "HARKOD";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // dGSTBLCheckBox
            // 
            this.dGSTBLCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.wMADRTBindingSource, "DGSTBL", true));
            this.dGSTBLCheckBox.Location = new System.Drawing.Point(529, 28);
            this.dGSTBLCheckBox.Name = "dGSTBLCheckBox";
            this.dGSTBLCheckBox.Size = new System.Drawing.Size(104, 16);
            this.dGSTBLCheckBox.TabIndex = 11;
            this.dGSTBLCheckBox.UseVisualStyleBackColor = true;
            // 
            // dPACKDGridLookUpEdit
            // 
            this.dPACKDGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "DPACKD", true));
            this.dPACKDGridLookUpEdit.Location = new System.Drawing.Point(208, 156);
            this.dPACKDGridLookUpEdit.MenuManager = this.barManager;
            this.dPACKDGridLookUpEdit.Name = "dPACKDGridLookUpEdit";
            this.dPACKDGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dPACKDGridLookUpEdit.Properties.DisplayMember = "TANIMI";
            this.dPACKDGridLookUpEdit.Properties.NullText = "";
            this.dPACKDGridLookUpEdit.Properties.PopupView = this.dPACKDGridLookUpEditView;
            this.dPACKDGridLookUpEdit.Properties.ValueMember = "HARKOD";
            this.dPACKDGridLookUpEdit.Size = new System.Drawing.Size(104, 20);
            this.dPACKDGridLookUpEdit.TabIndex = 13;
            // 
            // dPACKDGridLookUpEditView
            // 
            this.dPACKDGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn7});
            this.dPACKDGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.dPACKDGridLookUpEditView.Name = "dPACKDGridLookUpEditView";
            this.dPACKDGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dPACKDGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Tanım";
            this.gridColumn8.FieldName = "TANIMI";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Kod";
            this.gridColumn7.FieldName = "HARKOD";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // dPADRSTextEdit
            // 
            this.dPADRSTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "DPADRS", true));
            this.dPADRSTextEdit.Location = new System.Drawing.Point(208, 77);
            this.dPADRSTextEdit.MenuManager = this.barManager;
            this.dPADRSTextEdit.Name = "dPADRSTextEdit";
            this.dPADRSTextEdit.Size = new System.Drawing.Size(104, 20);
            this.dPADRSTextEdit.TabIndex = 15;
            // 
            // dPALKDGridLookUpEdit
            // 
            this.dPALKDGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "DPALKD", true));
            this.dPALKDGridLookUpEdit.Location = new System.Drawing.Point(208, 104);
            this.dPALKDGridLookUpEdit.MenuManager = this.barManager;
            this.dPALKDGridLookUpEdit.Name = "dPALKDGridLookUpEdit";
            this.dPALKDGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dPALKDGridLookUpEdit.Properties.DisplayMember = "TANIMI";
            this.dPALKDGridLookUpEdit.Properties.NullText = "";
            this.dPALKDGridLookUpEdit.Properties.PopupView = this.dPALKDGridLookUpEditView;
            this.dPALKDGridLookUpEdit.Properties.ValueMember = "HARKOD";
            this.dPALKDGridLookUpEdit.Size = new System.Drawing.Size(104, 20);
            this.dPALKDGridLookUpEdit.TabIndex = 17;
            // 
            // dPALKDGridLookUpEditView
            // 
            this.dPALKDGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.dPALKDGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.dPALKDGridLookUpEditView.Name = "dPALKDGridLookUpEditView";
            this.dPALKDGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dPALKDGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kod";
            this.gridColumn3.FieldName = "HARKOD";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 1;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tanım";
            this.gridColumn4.FieldName = "TANIMI";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 0;
            // 
            // dPASRLTextEdit
            // 
            this.dPASRLTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "DPASRL", true));
            this.dPASRLTextEdit.Location = new System.Drawing.Point(529, 78);
            this.dPASRLTextEdit.MenuManager = this.barManager;
            this.dPASRLTextEdit.Name = "dPASRLTextEdit";
            this.dPASRLTextEdit.Size = new System.Drawing.Size(104, 20);
            this.dPASRLTextEdit.TabIndex = 19;
            // 
            // dPATKDGridLookUpEdit
            // 
            this.dPATKDGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "DPATKD", true));
            this.dPATKDGridLookUpEdit.Location = new System.Drawing.Point(208, 129);
            this.dPATKDGridLookUpEdit.MenuManager = this.barManager;
            this.dPATKDGridLookUpEdit.Name = "dPATKDGridLookUpEdit";
            this.dPATKDGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dPATKDGridLookUpEdit.Properties.DisplayMember = "TANIMI";
            this.dPATKDGridLookUpEdit.Properties.NullText = "";
            this.dPATKDGridLookUpEdit.Properties.PopupView = this.dPATKDGridLookUpEditView;
            this.dPATKDGridLookUpEdit.Properties.ValueMember = "HARKOD";
            this.dPATKDGridLookUpEdit.Size = new System.Drawing.Size(104, 20);
            this.dPATKDGridLookUpEdit.TabIndex = 21;
            // 
            // dPATKDGridLookUpEditView
            // 
            this.dPATKDGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn6,
            this.gridColumn5});
            this.dPATKDGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.dPATKDGridLookUpEditView.Name = "dPATKDGridLookUpEditView";
            this.dPATKDGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dPATKDGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tanım";
            this.gridColumn6.FieldName = "TANIMI";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 0;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Kod";
            this.gridColumn5.FieldName = "HARKOD";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 1;
            // 
            // dPCSRLTextEdit
            // 
            this.dPCSRLTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "DPCSRL", true));
            this.dPCSRLTextEdit.Location = new System.Drawing.Point(529, 104);
            this.dPCSRLTextEdit.MenuManager = this.barManager;
            this.dPCSRLTextEdit.Name = "dPCSRLTextEdit";
            this.dPCSRLTextEdit.Size = new System.Drawing.Size(104, 20);
            this.dPCSRLTextEdit.TabIndex = 23;
            // 
            // dPTIPIGridLookUpEdit
            // 
            this.dPTIPIGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "DPTIPI", true));
            this.dPTIPIGridLookUpEdit.Location = new System.Drawing.Point(208, 50);
            this.dPTIPIGridLookUpEdit.MenuManager = this.barManager;
            this.dPTIPIGridLookUpEdit.Name = "dPTIPIGridLookUpEdit";
            this.dPTIPIGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dPTIPIGridLookUpEdit.Properties.DisplayMember = "DPTIPT";
            this.dPTIPIGridLookUpEdit.Properties.NullText = "";
            this.dPTIPIGridLookUpEdit.Properties.PopupView = this.dPTIPIGridLookUpEditView;
            this.dPTIPIGridLookUpEdit.Properties.ValueMember = "DPTIPI";
            this.dPTIPIGridLookUpEdit.Size = new System.Drawing.Size(104, 20);
            this.dPTIPIGridLookUpEdit.TabIndex = 25;
            // 
            // dPTIPIGridLookUpEditView
            // 
            this.dPTIPIGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn9});
            this.dPTIPIGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.dPTIPIGridLookUpEditView.Name = "dPTIPIGridLookUpEditView";
            this.dPTIPIGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.dPTIPIGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Tanım";
            this.gridColumn10.FieldName = "DPTIPT";
            this.gridColumn10.Name = "gridColumn10";
            this.gridColumn10.Visible = true;
            this.gridColumn10.VisibleIndex = 0;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Kod";
            this.gridColumn9.FieldName = "DPTIPI";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            // 
            // sTARIHDateEdit
            // 
            this.sTARIHDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.wMADRTBindingSource, "STARIH", true));
            this.sTARIHDateEdit.EditValue = null;
            this.sTARIHDateEdit.Location = new System.Drawing.Point(208, 184);
            this.sTARIHDateEdit.MenuManager = this.barManager;
            this.sTARIHDateEdit.Name = "sTARIHDateEdit";
            this.sTARIHDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sTARIHDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sTARIHDateEdit.Properties.ReadOnly = true;
            this.sTARIHDateEdit.Size = new System.Drawing.Size(104, 20);
            this.sTARIHDateEdit.TabIndex = 41;
            // 
            // popEtiket
            // 
            this.popEtiket.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButEtiketYazdir)});
            this.popEtiket.Manager = this.barManager;
            this.popEtiket.Name = "popEtiket";
            // 
            // barButEtiketYazdir
            // 
            this.barButEtiketYazdir.Caption = "Etiket Yazdır";
            this.barButEtiketYazdir.Id = 27;
            this.barButEtiketYazdir.Name = "barButEtiketYazdir";
            this.barButEtiketYazdir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButEtiketYazdir_ItemClick);
            // 
            // FrmWmAdrt
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.xtraTabControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmWmAdrt.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmWmAdrt";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMADRTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedDepoTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            this.xtraTabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dEPOKDGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dEPOKDGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPACKDGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPACKDGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPADRSTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPALKDGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPALKDGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPASRLTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPATKDGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPATKDGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPCSRLTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPTIPIGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dPTIPIGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTARIHDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTARIHDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popEtiket)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private System.Windows.Forms.BindingSource wMADRTBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colDEPOKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDPTIPI;
        private DevExpress.XtraGrid.Columns.GridColumn colDPADRS;
        private DevExpress.XtraGrid.Columns.GridColumn colDPALKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDPATKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDPACKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDGSTBL;
        private DevExpress.XtraGrid.Columns.GridColumn colDCSTBL;
        private DevExpress.XtraGrid.Columns.GridColumn colSTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colDPASRL;
        private DevExpress.XtraGrid.Columns.GridColumn colDPCSRL;
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
        private System.Windows.Forms.CheckBox aCTIVECheckBox;
        private System.Windows.Forms.CheckBox dCSTBLCheckBox;
        private DevExpress.XtraEditors.GridLookUpEdit dEPOKDGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView dEPOKDGridLookUpEditView;
        private System.Windows.Forms.CheckBox dGSTBLCheckBox;
        private DevExpress.XtraEditors.GridLookUpEdit dPACKDGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView dPACKDGridLookUpEditView;
        private DevExpress.XtraEditors.TextEdit dPADRSTextEdit;
        private DevExpress.XtraEditors.GridLookUpEdit dPALKDGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView dPALKDGridLookUpEditView;
        private DevExpress.XtraEditors.TextEdit dPASRLTextEdit;
        private DevExpress.XtraEditors.GridLookUpEdit dPATKDGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView dPATKDGridLookUpEditView;
        private DevExpress.XtraEditors.TextEdit dPCSRLTextEdit;
        private DevExpress.XtraEditors.GridLookUpEdit dPTIPIGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView dPTIPIGridLookUpEditView;
        private DevExpress.XtraEditors.DateEdit sTARIHDateEdit;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkedDepoTip;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraBars.PopupMenu popEtiket;
        private DevExpress.XtraBars.BarButtonItem barButEtiketYazdir;
    }
}
