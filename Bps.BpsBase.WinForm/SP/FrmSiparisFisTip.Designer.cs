namespace BPS.Windows.Forms
{
    partial class FrmSiparisFisTip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSiparisFisTip));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sPFTIPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSPFTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTANIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPHRTP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPORKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPDGKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNONAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNEVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNACIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFUNCNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIZAYN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDVFLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTVFLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTSFTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFTFTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colORGTKD = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colSPHRTY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTFYNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repYaratmaSaatTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repDegisiklikSaatiTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repYaratmaadiLkUp = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcol1KullaniciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDegistirenAdiLkUp = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcol2KullaniciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.repLkeSTFYNO = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridSTYFNOView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridSTYFNOcolKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridSTYFNOcolTANIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPFTIPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaSaatTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegisiklikSaatiTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaadiLkUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegistirenAdiLkUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkeSTFYNO)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSTYFNOView)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sPFTIPBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repYaratmaSaatTimeEdit,
            this.repDegisiklikSaatiTimeEdit,
            this.repYaratmaadiLkUp,
            this.repDegistirenAdiLkUp,
            this.repositoryItemDateEdit1,
            this.repLkeSTFYNO});
            this.gridControl1.Size = new System.Drawing.Size(957, 439);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sPFTIPBindingSource
            // 
            this.sPFTIPBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.SP.SPFTIP);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSPFTNO,
            this.colTANIMI,
            this.colSPHRTP,
            this.colSPORKD,
            this.colSPDGKD,
            this.colGNONAY,
            this.colGNEVID,
            this.colGNACIK,
            this.colFUNCNM,
            this.colDIZAYN,
            this.colKDVFLG,
            this.colOTVFLG,
            this.colTSFTNO,
            this.colFTFTNO,
            this.colORGTKD,
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
            this.colSPHRTY,
            this.colSTFYNO});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colSPFTNO
            // 
            this.colSPFTNO.FieldName = "SPFTNO";
            this.colSPFTNO.MinWidth = 21;
            this.colSPFTNO.Name = "colSPFTNO";
            this.colSPFTNO.Visible = true;
            this.colSPFTNO.VisibleIndex = 0;
            this.colSPFTNO.Width = 81;
            // 
            // colTANIMI
            // 
            this.colTANIMI.FieldName = "TANIMI";
            this.colTANIMI.MinWidth = 21;
            this.colTANIMI.Name = "colTANIMI";
            this.colTANIMI.Visible = true;
            this.colTANIMI.VisibleIndex = 1;
            this.colTANIMI.Width = 81;
            // 
            // colSPHRTP
            // 
            this.colSPHRTP.FieldName = "SPHRTP";
            this.colSPHRTP.Name = "colSPHRTP";
            this.colSPHRTP.Visible = true;
            this.colSPHRTP.VisibleIndex = 2;
            this.colSPHRTP.Width = 64;
            // 
            // colSPORKD
            // 
            this.colSPORKD.FieldName = "SPORKD";
            this.colSPORKD.MinWidth = 21;
            this.colSPORKD.Name = "colSPORKD";
            this.colSPORKD.Visible = true;
            this.colSPORKD.VisibleIndex = 4;
            this.colSPORKD.Width = 81;
            // 
            // colSPDGKD
            // 
            this.colSPDGKD.FieldName = "SPDGKD";
            this.colSPDGKD.MinWidth = 21;
            this.colSPDGKD.Name = "colSPDGKD";
            this.colSPDGKD.Visible = true;
            this.colSPDGKD.VisibleIndex = 5;
            this.colSPDGKD.Width = 81;
            // 
            // colGNONAY
            // 
            this.colGNONAY.FieldName = "GNONAY";
            this.colGNONAY.MinWidth = 21;
            this.colGNONAY.Name = "colGNONAY";
            this.colGNONAY.Visible = true;
            this.colGNONAY.VisibleIndex = 6;
            this.colGNONAY.Width = 81;
            // 
            // colGNEVID
            // 
            this.colGNEVID.FieldName = "GNEVID";
            this.colGNEVID.MinWidth = 21;
            this.colGNEVID.Name = "colGNEVID";
            this.colGNEVID.Visible = true;
            this.colGNEVID.VisibleIndex = 7;
            this.colGNEVID.Width = 81;
            // 
            // colGNACIK
            // 
            this.colGNACIK.FieldName = "GNACIK";
            this.colGNACIK.MinWidth = 21;
            this.colGNACIK.Name = "colGNACIK";
            this.colGNACIK.Visible = true;
            this.colGNACIK.VisibleIndex = 8;
            this.colGNACIK.Width = 81;
            // 
            // colFUNCNM
            // 
            this.colFUNCNM.FieldName = "FUNCNM";
            this.colFUNCNM.MinWidth = 21;
            this.colFUNCNM.Name = "colFUNCNM";
            this.colFUNCNM.Visible = true;
            this.colFUNCNM.VisibleIndex = 9;
            this.colFUNCNM.Width = 81;
            // 
            // colDIZAYN
            // 
            this.colDIZAYN.FieldName = "DIZAYN";
            this.colDIZAYN.MinWidth = 21;
            this.colDIZAYN.Name = "colDIZAYN";
            this.colDIZAYN.Visible = true;
            this.colDIZAYN.VisibleIndex = 10;
            this.colDIZAYN.Width = 81;
            // 
            // colKDVFLG
            // 
            this.colKDVFLG.FieldName = "KDVFLG";
            this.colKDVFLG.MinWidth = 21;
            this.colKDVFLG.Name = "colKDVFLG";
            this.colKDVFLG.Visible = true;
            this.colKDVFLG.VisibleIndex = 11;
            this.colKDVFLG.Width = 81;
            // 
            // colOTVFLG
            // 
            this.colOTVFLG.FieldName = "OTVFLG";
            this.colOTVFLG.MinWidth = 21;
            this.colOTVFLG.Name = "colOTVFLG";
            this.colOTVFLG.Visible = true;
            this.colOTVFLG.VisibleIndex = 12;
            this.colOTVFLG.Width = 81;
            // 
            // colTSFTNO
            // 
            this.colTSFTNO.FieldName = "TSFTNO";
            this.colTSFTNO.MinWidth = 21;
            this.colTSFTNO.Name = "colTSFTNO";
            this.colTSFTNO.Visible = true;
            this.colTSFTNO.VisibleIndex = 13;
            this.colTSFTNO.Width = 81;
            // 
            // colFTFTNO
            // 
            this.colFTFTNO.FieldName = "FTFTNO";
            this.colFTFTNO.MinWidth = 21;
            this.colFTFTNO.Name = "colFTFTNO";
            this.colFTFTNO.Visible = true;
            this.colFTFTNO.VisibleIndex = 14;
            this.colFTFTNO.Width = 81;
            // 
            // colORGTKD
            // 
            this.colORGTKD.Caption = "Onay Organizasyon";
            this.colORGTKD.FieldName = "ORGTKD";
            this.colORGTKD.FilterMode = DevExpress.XtraGrid.ColumnFilterMode.DisplayText;
            this.colORGTKD.Name = "colORGTKD";
            this.colORGTKD.Visible = true;
            this.colORGTKD.VisibleIndex = 15;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 21;
            this.colId.Name = "colId";
            this.colId.Width = 81;
            // 
            // colSIRKID
            // 
            this.colSIRKID.FieldName = "SIRKID";
            this.colSIRKID.MinWidth = 21;
            this.colSIRKID.Name = "colSIRKID";
            this.colSIRKID.Width = 81;
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.MinWidth = 21;
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Width = 81;
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.MinWidth = 21;
            this.colSLINDI.Name = "colSLINDI";
            this.colSLINDI.Width = 81;
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.MinWidth = 21;
            this.colEKKULL.Name = "colEKKULL";
            this.colEKKULL.Width = 81;
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.MinWidth = 21;
            this.colETARIH.Name = "colETARIH";
            this.colETARIH.Width = 81;
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.MinWidth = 21;
            this.colDEKULL.Name = "colDEKULL";
            this.colDEKULL.Width = 81;
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.MinWidth = 21;
            this.colDTARIH.Name = "colDTARIH";
            this.colDTARIH.Width = 81;
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.MinWidth = 21;
            this.colKYNKKD.Name = "colKYNKKD";
            this.colKYNKKD.Width = 81;
            // 
            // colCHKCTR
            // 
            this.colCHKCTR.FieldName = "CHKCTR";
            this.colCHKCTR.MinWidth = 21;
            this.colCHKCTR.Name = "colCHKCTR";
            this.colCHKCTR.Width = 81;
            // 
            // colSPHRTY
            // 
            this.colSPHRTY.FieldName = "SPHRTY";
            this.colSPHRTY.Name = "colSPHRTY";
            this.colSPHRTY.Visible = true;
            this.colSPHRTY.VisibleIndex = 3;
            this.colSPHRTY.Width = 50;
            // 
            // colSTFYNO
            // 
            this.colSTFYNO.ColumnEdit = this.repLkeSTFYNO;
            this.colSTFYNO.FieldName = "STFYNO";
            this.colSTFYNO.Name = "colSTFYNO";
            this.colSTFYNO.Visible = true;
            this.colSTFYNO.VisibleIndex = 16;
            this.colSTFYNO.Width = 50;
            // 
            // repYaratmaSaatTimeEdit
            // 
            this.repYaratmaSaatTimeEdit.AutoHeight = false;
            this.repYaratmaSaatTimeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repYaratmaSaatTimeEdit.Name = "repYaratmaSaatTimeEdit";
            // 
            // repDegisiklikSaatiTimeEdit
            // 
            this.repDegisiklikSaatiTimeEdit.AutoHeight = false;
            this.repDegisiklikSaatiTimeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDegisiklikSaatiTimeEdit.Name = "repDegisiklikSaatiTimeEdit";
            // 
            // repYaratmaadiLkUp
            // 
            this.repYaratmaadiLkUp.AutoHeight = false;
            this.repYaratmaadiLkUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repYaratmaadiLkUp.DisplayMember = "KullaniciAdi";
            this.repYaratmaadiLkUp.Name = "repYaratmaadiLkUp";
            this.repYaratmaadiLkUp.NullText = "";
            this.repYaratmaadiLkUp.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repYaratmaadiLkUp.ValueMember = "Id";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repcol1KullaniciAdi});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repcol1KullaniciAdi
            // 
            this.repcol1KullaniciAdi.Caption = "Kullanici Adi";
            this.repcol1KullaniciAdi.FieldName = "KullaniciAdi";
            this.repcol1KullaniciAdi.Name = "repcol1KullaniciAdi";
            this.repcol1KullaniciAdi.Visible = true;
            this.repcol1KullaniciAdi.VisibleIndex = 0;
            // 
            // repDegistirenAdiLkUp
            // 
            this.repDegistirenAdiLkUp.AutoHeight = false;
            this.repDegistirenAdiLkUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDegistirenAdiLkUp.DisplayMember = "KullaniciAdi";
            this.repDegistirenAdiLkUp.Name = "repDegistirenAdiLkUp";
            this.repDegistirenAdiLkUp.NullText = "";
            this.repDegistirenAdiLkUp.PopupView = this.gridView2;
            this.repDegistirenAdiLkUp.ValueMember = "Id";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repcol2KullaniciAdi});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // repcol2KullaniciAdi
            // 
            this.repcol2KullaniciAdi.Caption = "Kullanici Adı";
            this.repcol2KullaniciAdi.FieldName = "KullaniciAdi";
            this.repcol2KullaniciAdi.Name = "repcol2KullaniciAdi";
            this.repcol2KullaniciAdi.Visible = true;
            this.repcol2KullaniciAdi.VisibleIndex = 0;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.TodayDate = new System.DateTime(2019, 3, 15, 20, 29, 8, 0);
            // 
            // repLkeSTFYNO
            // 
            this.repLkeSTFYNO.AutoHeight = false;
            this.repLkeSTFYNO.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkeSTFYNO.DisplayMember = "TANIMI";
            this.repLkeSTFYNO.Name = "repLkeSTFYNO";
            this.repLkeSTFYNO.NullText = "";
            this.repLkeSTFYNO.PopupView = this.gridSTYFNOView;
            this.repLkeSTFYNO.ValueMember = "STFYNO";
            // 
            // gridSTYFNOView
            // 
            this.gridSTYFNOView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridSTYFNOcolKOD,
            this.gridSTYFNOcolTANIMI});
            this.gridSTYFNOView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridSTYFNOView.Name = "gridSTYFNOView";
            this.gridSTYFNOView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridSTYFNOView.OptionsView.ShowGroupPanel = false;
            // 
            // gridSTYFNOcolKOD
            // 
            this.gridSTYFNOcolKOD.Caption = "Kod";
            this.gridSTYFNOcolKOD.FieldName = "STFYNO";
            this.gridSTYFNOcolKOD.Name = "gridSTYFNOcolKOD";
            this.gridSTYFNOcolKOD.Visible = true;
            this.gridSTYFNOcolKOD.VisibleIndex = 0;
            // 
            // gridSTYFNOcolTANIMI
            // 
            this.gridSTYFNOcolTANIMI.Caption = "Tanımı";
            this.gridSTYFNOcolTANIMI.FieldName = "TANIMI";
            this.gridSTYFNOcolTANIMI.Name = "gridSTYFNOcolTANIMI";
            this.gridSTYFNOcolTANIMI.Visible = true;
            this.gridSTYFNOcolTANIMI.VisibleIndex = 1;
            // 
            // FrmSiparisFisTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmSiparisFisTip.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmSiparisFisTip";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPFTIPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaSaatTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegisiklikSaatiTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaadiLkUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegistirenAdiLkUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkeSTFYNO)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridSTYFNOView)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repYaratmaadiLkUp;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn repcol1KullaniciAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repDegistirenAdiLkUp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn repcol2KullaniciAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repYaratmaSaatTimeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repDegisiklikSaatiTimeEdit;
        private System.Windows.Forms.BindingSource sPFTIPBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSPFTNO;
        private DevExpress.XtraGrid.Columns.GridColumn colTANIMI;
        private DevExpress.XtraGrid.Columns.GridColumn colSPORKD;
        private DevExpress.XtraGrid.Columns.GridColumn colSPDGKD;
        private DevExpress.XtraGrid.Columns.GridColumn colGNONAY;
        private DevExpress.XtraGrid.Columns.GridColumn colGNEVID;
        private DevExpress.XtraGrid.Columns.GridColumn colGNACIK;
        private DevExpress.XtraGrid.Columns.GridColumn colFUNCNM;
        private DevExpress.XtraGrid.Columns.GridColumn colDIZAYN;
        private DevExpress.XtraGrid.Columns.GridColumn colKDVFLG;
        private DevExpress.XtraGrid.Columns.GridColumn colOTVFLG;
        private DevExpress.XtraGrid.Columns.GridColumn colTSFTNO;
        private DevExpress.XtraGrid.Columns.GridColumn colFTFTNO;
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
        private DevExpress.XtraGrid.Columns.GridColumn colSPHRTP;
        private DevExpress.XtraGrid.Columns.GridColumn colORGTKD;
        private DevExpress.XtraGrid.Columns.GridColumn colSPHRTY;
        private DevExpress.XtraGrid.Columns.GridColumn colSTFYNO;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkeSTFYNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridSTYFNOView;
        private DevExpress.XtraGrid.Columns.GridColumn gridSTYFNOcolKOD;
        private DevExpress.XtraGrid.Columns.GridColumn gridSTYFNOcolTANIMI;
    }
}
