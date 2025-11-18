
namespace BPS.Windows.Forms
{
    partial class FrmStokHareket
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
            System.Windows.Forms.Label sTHRTPLabel;
            System.Windows.Forms.Label sTFTNOLabel;
            System.Windows.Forms.Label bELTRHLabel;
            System.Windows.Forms.Label gNACIKLabel;
            System.Windows.Forms.Label eVRAKNLabel;
            System.Windows.Forms.Label cRKODULabel;
            System.Windows.Forms.Label label1;
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStokHareket));
            this.grdViewDetail = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.grdControlStHrkt = new DevExpress.XtraGrid.GridControl();
            this.sTHRKTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grdViewStHrkt = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTHRTP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTFTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTNMIA = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSATIRN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBELGEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBELTRH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkedStHrktStokKod = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTKNAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISM1KD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISM2KD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISM3KD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISMSM1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISMSM2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISMSM3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISMSD1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISMSD2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISMSD3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPROFLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRHRKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCRKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVCNKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVZFYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVZALT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTDVCN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTDFYT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNMKTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOLCUKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGRMKTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGROLBR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkedOlcuBirimi = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNTUTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVRGORN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNACIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGRDEPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCKDEPO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMLKBTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVRGTUT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colVRGSIZ = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTVORN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOTVTUT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBRTAGR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colNETAGR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colAGOLKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOIVORN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOIVTUT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEVKIF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colILVKDV = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colPARTIN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPARTIT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTSALAN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkedTeslimAlan = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTSTARH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDtoTeslimTarihi = new DevExpress.XtraEditors.Repository.RepositoryItemDateTimeOffsetEdit();
            this.unboundKYADRS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkedWmAdresTanim = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.unboundHDADRS = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrnkbdnVRKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrnkbdnRENKTN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrnkbdnBEDNTN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colrnkbdnDROPTN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gRDEPOLabel = new System.Windows.Forms.Label();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.grpBox2 = new System.Windows.Forms.GroupBox();
            this.cRKODUGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.sTHBASBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.cRKODUGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridLkeSASNO = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.sTHRTPGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.sTHRTPGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.sTFTNOGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.sTFTNOGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.eVRAKNTextEdit = new DevExpress.XtraEditors.TextEdit();
            this.btnProfil = new DevExpress.XtraEditors.SimpleButton();
            this.cKDEPOLabel = new DevExpress.XtraEditors.LabelControl();
            this.cKDEPOGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.cKDEPOGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.btnStHrktKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.gRDEPOGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gRDEPOGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gNACIKMemoEdit = new DevExpress.XtraEditors.MemoEdit();
            this.bELTRHDateEdit = new DevExpress.XtraEditors.DateEdit();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.bndNvgHareket = new System.Windows.Forms.BindingNavigator(this.components);
            this.bindingNavigatorAddNewItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorCountItem2 = new System.Windows.Forms.ToolStripLabel();
            this.bindingNavigatorDeleteItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveFirstItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMovePreviousItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorPositionItem2 = new System.Windows.Forms.ToolStripTextBox();
            this.bindingNavigatorSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.bindingNavigatorMoveNextItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorMoveLastItem2 = new System.Windows.Forms.ToolStripButton();
            this.bindingNavigatorSeparator8 = new System.Windows.Forms.ToolStripSeparator();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.dxErrorProvider2 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            this.wMADRTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.popMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButGrmktrSifirla = new DevExpress.XtraBars.BarButtonItem();
            this.barCheckItem1 = new DevExpress.XtraBars.BarCheckItem();
            sTHRTPLabel = new System.Windows.Forms.Label();
            sTFTNOLabel = new System.Windows.Forms.Label();
            bELTRHLabel = new System.Windows.Forms.Label();
            gNACIKLabel = new System.Windows.Forms.Label();
            eVRAKNLabel = new System.Windows.Forms.Label();
            cRKODULabel = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDetail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlStHrkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHRKTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewStHrkt)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedStHrktStokKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedOlcuBirimi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedTeslimAlan)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDtoTeslimTarihi)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedWmAdresTanim)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            this.grpBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRKODUGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHBASBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cRKODUGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLkeSASNO.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sTHRTPGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHRTPGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTFTNOGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTFTNOGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.eVRAKNTextEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cKDEPOGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.cKDEPOGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRDEPOGridLookUpEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRDEPOGridLookUpEditView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNACIKMemoEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bELTRHDateEdit.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bELTRHDateEdit.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bndNvgHareket)).BeginInit();
            this.bndNvgHareket.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMADRTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // sTHRTPLabel
            // 
            sTHRTPLabel.AutoSize = true;
            sTHRTPLabel.Location = new System.Drawing.Point(7, 19);
            sTHRTPLabel.Name = "sTHRTPLabel";
            sTHRTPLabel.Size = new System.Drawing.Size(92, 13);
            sTHRTPLabel.TabIndex = 0;
            sTHRTPLabel.Text = "Stok Hareket Tipi:";
            // 
            // sTFTNOLabel
            // 
            sTFTNOLabel.AutoSize = true;
            sTFTNOLabel.Location = new System.Drawing.Point(19, 82);
            sTFTNOLabel.Name = "sTFTNOLabel";
            sTFTNOLabel.Size = new System.Drawing.Size(81, 13);
            sTFTNOLabel.TabIndex = 2;
            sTFTNOLabel.Text = "Stok Fis Tip No:";
            // 
            // bELTRHLabel
            // 
            bELTRHLabel.AutoSize = true;
            bELTRHLabel.Location = new System.Drawing.Point(580, 82);
            bELTRHLabel.Name = "bELTRHLabel";
            bELTRHLabel.Size = new System.Drawing.Size(64, 13);
            bELTRHLabel.TabIndex = 6;
            bELTRHLabel.Text = "Belge Tarih:";
            // 
            // gNACIKLabel
            // 
            gNACIKLabel.AutoSize = true;
            gNACIKLabel.Location = new System.Drawing.Point(314, 110);
            gNACIKLabel.Name = "gNACIKLabel";
            gNACIKLabel.Size = new System.Drawing.Size(52, 13);
            gNACIKLabel.TabIndex = 8;
            gNACIKLabel.Text = "Açiklama:";
            // 
            // eVRAKNLabel
            // 
            eVRAKNLabel.AutoSize = true;
            eVRAKNLabel.Location = new System.Drawing.Point(314, 82);
            eVRAKNLabel.Name = "eVRAKNLabel";
            eVRAKNLabel.Size = new System.Drawing.Size(54, 13);
            eVRAKNLabel.TabIndex = 17;
            eVRAKNLabel.Text = "Evrak No:";
            // 
            // cRKODULabel
            // 
            cRKODULabel.AutoSize = true;
            cRKODULabel.Location = new System.Drawing.Point(20, 19);
            cRKODULabel.Name = "cRKODULabel";
            cRKODULabel.Size = new System.Drawing.Size(57, 13);
            cRKODULabel.TabIndex = 18;
            cRKODULabel.Tag = "s1";
            cRKODULabel.Text = "Cari Kodu:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(286, 19);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(46, 13);
            label1.TabIndex = 21;
            label1.Tag = "s1";
            label1.Text = "SAS No:";
            // 
            // grdViewDetail
            // 
            this.grdViewDetail.GridControl = this.grdControlStHrkt;
            this.grdViewDetail.Name = "grdViewDetail";
            // 
            // grdControlStHrkt
            // 
            this.grdControlStHrkt.DataSource = this.sTHRKTBindingSource;
            this.grdControlStHrkt.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdControlStHrkt.Location = new System.Drawing.Point(2, 50);
            this.grdControlStHrkt.MainView = this.grdViewStHrkt;
            this.grdControlStHrkt.Name = "grdControlStHrkt";
            this.grdControlStHrkt.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLkedStHrktStokKod,
            this.repLkedOlcuBirimi,
            this.repLkedTeslimAlan,
            this.repDtoTeslimTarihi,
            this.repLkedWmAdresTanim});
            this.grdControlStHrkt.Size = new System.Drawing.Size(1269, 305);
            this.grdControlStHrkt.TabIndex = 6;
            this.grdControlStHrkt.Tag = "1";
            this.grdControlStHrkt.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdViewStHrkt,
            this.grdViewDetail});
            // 
            // sTHRKTBindingSource
            // 
            this.sTHRKTBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.ST.STHRKT);
            // 
            // grdViewStHrkt
            // 
            this.grdViewStHrkt.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTHRTP,
            this.colSTFTNO,
            this.colSTNMIA,
            this.colSATIRN,
            this.colBELGEN,
            this.colBELTRH,
            this.colSTKODU,
            this.colSTKNAM,
            this.colISM1KD,
            this.colISM2KD,
            this.colISM3KD,
            this.colISMSM1,
            this.colISMSM2,
            this.colISMSM3,
            this.colISMSD1,
            this.colISMSD2,
            this.colISMSD3,
            this.colPROFLG,
            this.colCRHRKD,
            this.colCRKODU,
            this.colDVCNKD,
            this.colDVZFYT,
            this.colDVZALT,
            this.colSTDVCN,
            this.colSTDFYT,
            this.colGNMKTR,
            this.colOLCUKD,
            this.colGRMKTR,
            this.colGROLBR,
            this.colGNTUTR,
            this.colVRGORN,
            this.colGNACIK,
            this.colGRDEPO,
            this.colCKDEPO,
            this.colMLKBTR,
            this.colVRGTUT,
            this.colVRGSIZ,
            this.colOTVORN,
            this.colOTVTUT,
            this.colBRTAGR,
            this.colNETAGR,
            this.colAGOLKD,
            this.colOIVORN,
            this.colOIVTUT,
            this.colTEVKIF,
            this.colILVKDV,
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
            this.colPARTIN,
            this.colPARTIT,
            this.colTSALAN,
            this.colTSTARH,
            this.unboundKYADRS,
            this.unboundHDADRS,
            this.colrnkbdnVRKODU,
            this.colrnkbdnRENKTN,
            this.colrnkbdnBEDNTN,
            this.colrnkbdnDROPTN});
            this.grdViewStHrkt.GridControl = this.grdControlStHrkt;
            this.grdViewStHrkt.Name = "grdViewStHrkt";
            this.grdViewStHrkt.OptionsBehavior.Editable = false;
            this.grdViewStHrkt.OptionsLayout.Columns.StoreAllOptions = true;
            this.grdViewStHrkt.OptionsView.EnableAppearanceEvenRow = true;
            this.grdViewStHrkt.OptionsView.ShowGroupPanel = false;
            this.grdViewStHrkt.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.colGRDEPO, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.grdViewStHrkt.CustomDrawCell += new DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventHandler(this.grdViewStHrkt_CustomDrawCell);
            this.grdViewStHrkt.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.grdViewStHrkt_PopupMenuShowing);
            this.grdViewStHrkt.ShowingEditor += new System.ComponentModel.CancelEventHandler(this.grdViewStHrkt_ShowingEditor);
            this.grdViewStHrkt.FocusedRowChanged += new DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventHandler(this.grdViewStHrkt_FocusedRowChanged);
            this.grdViewStHrkt.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.grdViewStHrkt_CellValueChanged);
            this.grdViewStHrkt.CustomUnboundColumnData += new DevExpress.XtraGrid.Views.Base.CustomColumnDataEventHandler(this.grdViewStHrkt_CustomUnboundColumnData);
            this.grdViewStHrkt.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.grdViewStHrkt_ValidatingEditor);
            // 
            // colSTHRTP
            // 
            this.colSTHRTP.FieldName = "STHRTP";
            this.colSTHRTP.Name = "colSTHRTP";
            // 
            // colSTFTNO
            // 
            this.colSTFTNO.FieldName = "STFTNO";
            this.colSTFTNO.Name = "colSTFTNO";
            // 
            // colSTNMIA
            // 
            this.colSTNMIA.FieldName = "STNMIA";
            this.colSTNMIA.Name = "colSTNMIA";
            // 
            // colSATIRN
            // 
            this.colSATIRN.FieldName = "SATIRN";
            this.colSATIRN.Name = "colSATIRN";
            // 
            // colBELGEN
            // 
            this.colBELGEN.FieldName = "BELGEN";
            this.colBELGEN.Name = "colBELGEN";
            // 
            // colBELTRH
            // 
            this.colBELTRH.FieldName = "BELTRH";
            this.colBELTRH.Name = "colBELTRH";
            // 
            // colSTKODU
            // 
            this.colSTKODU.ColumnEdit = this.repLkedStHrktStokKod;
            this.colSTKODU.FieldName = "STKODU";
            this.colSTKODU.Name = "colSTKODU";
            // 
            // repLkedStHrktStokKod
            // 
            this.repLkedStHrktStokKod.AutoHeight = false;
            this.repLkedStHrktStokKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkedStHrktStokKod.DisplayMember = "STKODU";
            this.repLkedStHrktStokKod.Name = "repLkedStHrktStokKod";
            this.repLkedStHrktStokKod.PopupView = this.gridView1;
            this.repLkedStHrktStokKod.ValueMember = "STKODU";
            this.repLkedStHrktStokKod.EditValueChanged += new System.EventHandler(this.repLkedStHrktStokKod_EditValueChanged);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn11});
            this.gridView1.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Kod";
            this.gridColumn8.FieldName = "STKODU";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 0;
            this.gridColumn8.Width = 85;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Tanım";
            this.gridColumn9.FieldName = "STKNAM";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.Visible = true;
            this.gridColumn9.VisibleIndex = 1;
            this.gridColumn9.Width = 292;
            // 
            // gridColumn11
            // 
            this.gridColumn11.Caption = "Ölçü Birim Kod";
            this.gridColumn11.FieldName = "OLCUKD";
            this.gridColumn11.Name = "gridColumn11";
            // 
            // colSTKNAM
            // 
            this.colSTKNAM.FieldName = "STKNAM";
            this.colSTKNAM.Name = "colSTKNAM";
            // 
            // colISM1KD
            // 
            this.colISM1KD.FieldName = "ISM1KD";
            this.colISM1KD.Name = "colISM1KD";
            // 
            // colISM2KD
            // 
            this.colISM2KD.FieldName = "ISM2KD";
            this.colISM2KD.Name = "colISM2KD";
            // 
            // colISM3KD
            // 
            this.colISM3KD.FieldName = "ISM3KD";
            this.colISM3KD.Name = "colISM3KD";
            // 
            // colISMSM1
            // 
            this.colISMSM1.FieldName = "ISMSM1";
            this.colISMSM1.Name = "colISMSM1";
            // 
            // colISMSM2
            // 
            this.colISMSM2.FieldName = "ISMSM2";
            this.colISMSM2.Name = "colISMSM2";
            // 
            // colISMSM3
            // 
            this.colISMSM3.FieldName = "ISMSM3";
            this.colISMSM3.Name = "colISMSM3";
            // 
            // colISMSD1
            // 
            this.colISMSD1.FieldName = "ISMSD1";
            this.colISMSD1.Name = "colISMSD1";
            // 
            // colISMSD2
            // 
            this.colISMSD2.FieldName = "ISMSD2";
            this.colISMSD2.Name = "colISMSD2";
            // 
            // colISMSD3
            // 
            this.colISMSD3.FieldName = "ISMSD3";
            this.colISMSD3.Name = "colISMSD3";
            // 
            // colPROFLG
            // 
            this.colPROFLG.FieldName = "PROFLG";
            this.colPROFLG.Name = "colPROFLG";
            // 
            // colCRHRKD
            // 
            this.colCRHRKD.FieldName = "CRHRKD";
            this.colCRHRKD.Name = "colCRHRKD";
            // 
            // colCRKODU
            // 
            this.colCRKODU.FieldName = "CRKODU";
            this.colCRKODU.Name = "colCRKODU";
            // 
            // colDVCNKD
            // 
            this.colDVCNKD.FieldName = "DVCNKD";
            this.colDVCNKD.Name = "colDVCNKD";
            // 
            // colDVZFYT
            // 
            this.colDVZFYT.FieldName = "DVZFYT";
            this.colDVZFYT.Name = "colDVZFYT";
            // 
            // colDVZALT
            // 
            this.colDVZALT.FieldName = "DVZALT";
            this.colDVZALT.Name = "colDVZALT";
            // 
            // colSTDVCN
            // 
            this.colSTDVCN.FieldName = "STDVCN";
            this.colSTDVCN.Name = "colSTDVCN";
            // 
            // colSTDFYT
            // 
            this.colSTDFYT.FieldName = "STDFYT";
            this.colSTDFYT.Name = "colSTDFYT";
            // 
            // colGNMKTR
            // 
            this.colGNMKTR.FieldName = "GNMKTR";
            this.colGNMKTR.Name = "colGNMKTR";
            // 
            // colOLCUKD
            // 
            this.colOLCUKD.FieldName = "OLCUKD";
            this.colOLCUKD.Name = "colOLCUKD";
            // 
            // colGRMKTR
            // 
            this.colGRMKTR.Caption = "Giriş Miktarı";
            this.colGRMKTR.FieldName = "GRMKTR";
            this.colGRMKTR.Name = "colGRMKTR";
            // 
            // colGROLBR
            // 
            this.colGROLBR.Caption = "Giriş Ölçü Birimi";
            this.colGROLBR.ColumnEdit = this.repLkedOlcuBirimi;
            this.colGROLBR.FieldName = "GROLBR";
            this.colGROLBR.Name = "colGROLBR";
            // 
            // repLkedOlcuBirimi
            // 
            this.repLkedOlcuBirimi.AutoHeight = false;
            this.repLkedOlcuBirimi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkedOlcuBirimi.DisplayMember = "TANIMI";
            this.repLkedOlcuBirimi.Name = "repLkedOlcuBirimi";
            this.repLkedOlcuBirimi.PopupView = this.gridView2;
            this.repLkedOlcuBirimi.ValueMember = "HARKOD";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn14
            // 
            this.gridColumn14.Caption = "KOD";
            this.gridColumn14.FieldName = "HARKOD";
            this.gridColumn14.Name = "gridColumn14";
            // 
            // gridColumn15
            // 
            this.gridColumn15.Caption = "Ölçü Birimi";
            this.gridColumn15.FieldName = "TANIMI";
            this.gridColumn15.Name = "gridColumn15";
            this.gridColumn15.Visible = true;
            this.gridColumn15.VisibleIndex = 0;
            // 
            // colGNTUTR
            // 
            this.colGNTUTR.FieldName = "GNTUTR";
            this.colGNTUTR.Name = "colGNTUTR";
            // 
            // colVRGORN
            // 
            this.colVRGORN.FieldName = "VRGORN";
            this.colVRGORN.Name = "colVRGORN";
            // 
            // colGNACIK
            // 
            this.colGNACIK.FieldName = "GNACIK";
            this.colGNACIK.Name = "colGNACIK";
            // 
            // colGRDEPO
            // 
            this.colGRDEPO.FieldName = "GRDEPO";
            this.colGRDEPO.Name = "colGRDEPO";
            // 
            // colCKDEPO
            // 
            this.colCKDEPO.FieldName = "CKDEPO";
            this.colCKDEPO.Name = "colCKDEPO";
            // 
            // colMLKBTR
            // 
            this.colMLKBTR.FieldName = "MLKBTR";
            this.colMLKBTR.Name = "colMLKBTR";
            // 
            // colVRGTUT
            // 
            this.colVRGTUT.FieldName = "VRGTUT";
            this.colVRGTUT.Name = "colVRGTUT";
            // 
            // colVRGSIZ
            // 
            this.colVRGSIZ.FieldName = "VRGSIZ";
            this.colVRGSIZ.Name = "colVRGSIZ";
            // 
            // colOTVORN
            // 
            this.colOTVORN.FieldName = "OTVORN";
            this.colOTVORN.Name = "colOTVORN";
            // 
            // colOTVTUT
            // 
            this.colOTVTUT.FieldName = "OTVTUT";
            this.colOTVTUT.Name = "colOTVTUT";
            // 
            // colBRTAGR
            // 
            this.colBRTAGR.FieldName = "BRTAGR";
            this.colBRTAGR.Name = "colBRTAGR";
            // 
            // colNETAGR
            // 
            this.colNETAGR.FieldName = "NETAGR";
            this.colNETAGR.Name = "colNETAGR";
            // 
            // colAGOLKD
            // 
            this.colAGOLKD.FieldName = "AGOLKD";
            this.colAGOLKD.Name = "colAGOLKD";
            // 
            // colOIVORN
            // 
            this.colOIVORN.FieldName = "OIVORN";
            this.colOIVORN.Name = "colOIVORN";
            // 
            // colOIVTUT
            // 
            this.colOIVTUT.FieldName = "OIVTUT";
            this.colOIVTUT.Name = "colOIVTUT";
            // 
            // colTEVKIF
            // 
            this.colTEVKIF.FieldName = "TEVKIF";
            this.colTEVKIF.Name = "colTEVKIF";
            // 
            // colILVKDV
            // 
            this.colILVKDV.FieldName = "ILVKDV";
            this.colILVKDV.Name = "colILVKDV";
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
            this.colSLINDI.OptionsColumn.AllowEdit = false;
            this.colSLINDI.OptionsColumn.ReadOnly = true;
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
            // colPARTIN
            // 
            this.colPARTIN.Caption = "Parti";
            this.colPARTIN.FieldName = "PARTIN";
            this.colPARTIN.Name = "colPARTIN";
            // 
            // colPARTIT
            // 
            this.colPARTIT.FieldName = "PARTIT";
            this.colPARTIT.Name = "colPARTIT";
            // 
            // colTSALAN
            // 
            this.colTSALAN.Caption = "Teslim Alan";
            this.colTSALAN.ColumnEdit = this.repLkedTeslimAlan;
            this.colTSALAN.FieldName = "TSALAN";
            this.colTSALAN.Name = "colTSALAN";
            // 
            // repLkedTeslimAlan
            // 
            this.repLkedTeslimAlan.AutoHeight = false;
            this.repLkedTeslimAlan.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkedTeslimAlan.DisplayMember = "GNNAME";
            this.repLkedTeslimAlan.Name = "repLkedTeslimAlan";
            this.repLkedTeslimAlan.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repLkedTeslimAlan.ValueMember = "SICILN";
            this.repLkedTeslimAlan.Popup += new System.EventHandler(this.repLkedTeslimAlan_Popup);
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn16,
            this.gridColumn17,
            this.gridColumn18});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn16
            // 
            this.gridColumn16.Caption = "Sicil No";
            this.gridColumn16.FieldName = "SICILN";
            this.gridColumn16.Name = "gridColumn16";
            this.gridColumn16.Visible = true;
            this.gridColumn16.VisibleIndex = 0;
            this.gridColumn16.Width = 40;
            // 
            // gridColumn17
            // 
            this.gridColumn17.Caption = "Ad Soyad";
            this.gridColumn17.FieldName = "GNNAME";
            this.gridColumn17.Name = "gridColumn17";
            this.gridColumn17.Visible = true;
            this.gridColumn17.VisibleIndex = 1;
            // 
            // gridColumn18
            // 
            this.gridColumn18.Caption = "Pozisyon";
            this.gridColumn18.FieldName = "POZSYN";
            this.gridColumn18.Name = "gridColumn18";
            this.gridColumn18.Visible = true;
            this.gridColumn18.VisibleIndex = 2;
            // 
            // colTSTARH
            // 
            this.colTSTARH.ColumnEdit = this.repDtoTeslimTarihi;
            this.colTSTARH.FieldName = "TSTARH";
            this.colTSTARH.Name = "colTSTARH";
            this.colTSTARH.Width = 120;
            // 
            // repDtoTeslimTarihi
            // 
            this.repDtoTeslimTarihi.AutoHeight = false;
            this.repDtoTeslimTarihi.BeepOnError = false;
            this.repDtoTeslimTarihi.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDtoTeslimTarihi.MaskSettings.Set("mask", "g");
            this.repDtoTeslimTarihi.MaskSettings.Set("useAdvancingCaret", true);
            this.repDtoTeslimTarihi.Name = "repDtoTeslimTarihi";
            this.repDtoTeslimTarihi.UseMaskAsDisplayFormat = true;
            // 
            // unboundKYADRS
            // 
            this.unboundKYADRS.ColumnEdit = this.repLkedWmAdresTanim;
            this.unboundKYADRS.FieldName = "KYADRS";
            this.unboundKYADRS.Name = "unboundKYADRS";
            this.unboundKYADRS.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // repLkedWmAdresTanim
            // 
            this.repLkedWmAdresTanim.AutoHeight = false;
            this.repLkedWmAdresTanim.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkedWmAdresTanim.DisplayMember = "DPADRS";
            this.repLkedWmAdresTanim.Name = "repLkedWmAdresTanim";
            this.repLkedWmAdresTanim.NullText = "";
            this.repLkedWmAdresTanim.PopupView = this.gridView3;
            this.repLkedWmAdresTanim.ValueMember = "DPADRS";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.gridColumn20});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Id";
            this.gridColumn19.FieldName = "Id";
            this.gridColumn19.Name = "gridColumn19";
            // 
            // gridColumn20
            // 
            this.gridColumn20.Caption = "Depo Adresi";
            this.gridColumn20.FieldName = "DPADRS";
            this.gridColumn20.Name = "gridColumn20";
            this.gridColumn20.Visible = true;
            this.gridColumn20.VisibleIndex = 0;
            // 
            // unboundHDADRS
            // 
            this.unboundHDADRS.ColumnEdit = this.repLkedWmAdresTanim;
            this.unboundHDADRS.FieldName = "HDADRS";
            this.unboundHDADRS.Name = "unboundHDADRS";
            this.unboundHDADRS.UnboundType = DevExpress.Data.UnboundColumnType.String;
            // 
            // colrnkbdnVRKODU
            // 
            this.colrnkbdnVRKODU.Caption = "Varyant Kodu";
            this.colrnkbdnVRKODU.FieldName = "VRKODU";
            this.colrnkbdnVRKODU.Name = "colrnkbdnVRKODU";
            // 
            // colrnkbdnRENKTN
            // 
            this.colrnkbdnRENKTN.Caption = "Renk";
            this.colrnkbdnRENKTN.FieldName = "VRKODU";
            this.colrnkbdnRENKTN.Name = "colrnkbdnRENKTN";
            // 
            // colrnkbdnBEDNTN
            // 
            this.colrnkbdnBEDNTN.Caption = "Beden";
            this.colrnkbdnBEDNTN.FieldName = "VRKODU";
            this.colrnkbdnBEDNTN.Name = "colrnkbdnBEDNTN";
            // 
            // colrnkbdnDROPTN
            // 
            this.colrnkbdnDROPTN.Caption = "Drop";
            this.colrnkbdnDROPTN.FieldName = "VRKODU";
            this.colrnkbdnDROPTN.Name = "colrnkbdnDROPTN";
            // 
            // gRDEPOLabel
            // 
            this.gRDEPOLabel.AutoSize = true;
            this.gRDEPOLabel.Location = new System.Drawing.Point(19, 110);
            this.gRDEPOLabel.Name = "gRDEPOLabel";
            this.gRDEPOLabel.Size = new System.Drawing.Size(86, 13);
            this.gRDEPOLabel.TabIndex = 10;
            this.gRDEPOLabel.Text = "Giris Depo Kodu:";
            this.gRDEPOLabel.Visible = false;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.grpBox2);
            this.groupControl1.Controls.Add(this.groupBox1);
            this.groupControl1.Controls.Add(this.sTFTNOGridLookUpEdit);
            this.groupControl1.Controls.Add(eVRAKNLabel);
            this.groupControl1.Controls.Add(sTFTNOLabel);
            this.groupControl1.Controls.Add(this.eVRAKNTextEdit);
            this.groupControl1.Controls.Add(this.btnProfil);
            this.groupControl1.Controls.Add(this.cKDEPOLabel);
            this.groupControl1.Controls.Add(this.cKDEPOGridLookUpEdit);
            this.groupControl1.Controls.Add(this.btnStHrktKaydet);
            this.groupControl1.Controls.Add(this.gRDEPOLabel);
            this.groupControl1.Controls.Add(this.gRDEPOGridLookUpEdit);
            this.groupControl1.Controls.Add(gNACIKLabel);
            this.groupControl1.Controls.Add(this.gNACIKMemoEdit);
            this.groupControl1.Controls.Add(bELTRHLabel);
            this.groupControl1.Controls.Add(this.bELTRHDateEdit);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 24);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1273, 218);
            this.groupControl1.TabIndex = 4;
            // 
            // grpBox2
            // 
            this.grpBox2.Controls.Add(cRKODULabel);
            this.grpBox2.Controls.Add(label1);
            this.grpBox2.Controls.Add(this.cRKODUGridLookUpEdit);
            this.grpBox2.Controls.Add(this.gridLkeSASNO);
            this.grpBox2.Location = new System.Drawing.Point(294, 26);
            this.grpBox2.Name = "grpBox2";
            this.grpBox2.Size = new System.Drawing.Size(596, 47);
            this.grpBox2.TabIndex = 22;
            this.grpBox2.TabStop = false;
            // 
            // cRKODUGridLookUpEdit
            // 
            this.cRKODUGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sTHBASBindingSource, "CRKODU", true));
            this.cRKODUGridLookUpEdit.EditValue = "";
            this.cRKODUGridLookUpEdit.Location = new System.Drawing.Point(113, 17);
            this.cRKODUGridLookUpEdit.MenuManager = this.barManager;
            this.cRKODUGridLookUpEdit.Name = "cRKODUGridLookUpEdit";
            this.cRKODUGridLookUpEdit.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.cRKODUGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cRKODUGridLookUpEdit.Properties.DisplayMember = "CRUNV1";
            this.cRKODUGridLookUpEdit.Properties.NullText = "";
            this.cRKODUGridLookUpEdit.Properties.PopupView = this.cRKODUGridLookUpEditView;
            this.cRKODUGridLookUpEdit.Properties.ValueMember = "CRKODU";
            this.cRKODUGridLookUpEdit.Size = new System.Drawing.Size(157, 20);
            this.cRKODUGridLookUpEdit.TabIndex = 19;
            this.cRKODUGridLookUpEdit.Tag = "s1";
            this.cRKODUGridLookUpEdit.EditValueChanged += new System.EventHandler(this.cRKODUGridLookUpEdit_EditValueChanged);
            // 
            // sTHBASBindingSource
            // 
            this.sTHBASBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.ST.STHBAS);
            // 
            // cRKODUGridLookUpEditView
            // 
            this.cRKODUGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn21,
            this.gridColumn22});
            this.cRKODUGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cRKODUGridLookUpEditView.Name = "cRKODUGridLookUpEditView";
            this.cRKODUGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cRKODUGridLookUpEditView.OptionsView.ShowAutoFilterRow = true;
            this.cRKODUGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn21
            // 
            this.gridColumn21.Caption = "Cari Kod";
            this.gridColumn21.FieldName = "CRKODU";
            this.gridColumn21.Name = "gridColumn21";
            this.gridColumn21.Visible = true;
            this.gridColumn21.VisibleIndex = 0;
            // 
            // gridColumn22
            // 
            this.gridColumn22.Caption = "Ünvan1";
            this.gridColumn22.FieldName = "CRUNV1";
            this.gridColumn22.Name = "gridColumn22";
            this.gridColumn22.Visible = true;
            this.gridColumn22.VisibleIndex = 1;
            // 
            // gridLkeSASNO
            // 
            this.gridLkeSASNO.EditValue = "";
            this.gridLkeSASNO.Location = new System.Drawing.Point(397, 17);
            this.gridLkeSASNO.MenuManager = this.barManager;
            this.gridLkeSASNO.Name = "gridLkeSASNO";
            this.gridLkeSASNO.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gridLkeSASNO.Properties.DisplayMember = "BELGEN";
            this.gridLkeSASNO.Properties.NullText = "";
            this.gridLkeSASNO.Properties.PopupView = this.gridView4;
            this.gridLkeSASNO.Properties.ValueMember = "BELGEN";
            this.gridLkeSASNO.Size = new System.Drawing.Size(182, 20);
            this.gridLkeSASNO.TabIndex = 20;
            this.gridLkeSASNO.Tag = "s1";
            this.gridLkeSASNO.EditValueChanged += new System.EventHandler(this.gridLkeSASNO_EditValueChanged);
            // 
            // gridView4
            // 
            this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn24,
            this.gridColumn25,
            this.gridColumn26});
            this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView4.Name = "gridView4";
            this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView4.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn24
            // 
            this.gridColumn24.Caption = "Belge No";
            this.gridColumn24.FieldName = "BELGEN";
            this.gridColumn24.Name = "gridColumn24";
            this.gridColumn24.Visible = true;
            this.gridColumn24.VisibleIndex = 0;
            // 
            // gridColumn25
            // 
            this.gridColumn25.Caption = "Belge Tarihi";
            this.gridColumn25.FieldName = "BELTRH";
            this.gridColumn25.Name = "gridColumn25";
            this.gridColumn25.Visible = true;
            this.gridColumn25.VisibleIndex = 1;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Evrak No";
            this.gridColumn26.FieldName = "EVRAKN";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 2;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.sTHRTPGridLookUpEdit);
            this.groupBox1.Controls.Add(sTHRTPLabel);
            this.groupBox1.Location = new System.Drawing.Point(12, 26);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(265, 47);
            this.groupBox1.TabIndex = 20;
            this.groupBox1.TabStop = false;
            // 
            // sTHRTPGridLookUpEdit
            // 
            this.sTHRTPGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sTHBASBindingSource, "STHRTP", true));
            this.sTHRTPGridLookUpEdit.EditValue = "";
            this.sTHRTPGridLookUpEdit.Location = new System.Drawing.Point(151, 17);
            this.sTHRTPGridLookUpEdit.MenuManager = this.barManager;
            this.sTHRTPGridLookUpEdit.Name = "sTHRTPGridLookUpEdit";
            this.sTHRTPGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sTHRTPGridLookUpEdit.Properties.DisplayMember = "Text";
            this.sTHRTPGridLookUpEdit.Properties.NullText = "";
            this.sTHRTPGridLookUpEdit.Properties.PopupView = this.sTHRTPGridLookUpEditView;
            this.sTHRTPGridLookUpEdit.Properties.ValueMember = "Value";
            this.sTHRTPGridLookUpEdit.Size = new System.Drawing.Size(109, 20);
            this.sTHRTPGridLookUpEdit.TabIndex = 1;
            this.sTHRTPGridLookUpEdit.EditValueChanged += new System.EventHandler(this.sTHRTPGridLookUpEdit_EditValueChanged);
            // 
            // sTHRTPGridLookUpEditView
            // 
            this.sTHRTPGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.sTHRTPGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.sTHRTPGridLookUpEditView.Name = "sTHRTPGridLookUpEditView";
            this.sTHRTPGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.sTHRTPGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kod";
            this.gridColumn1.FieldName = "Value";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 1;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tanım";
            this.gridColumn2.FieldName = "Text";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 0;
            // 
            // sTFTNOGridLookUpEdit
            // 
            this.sTFTNOGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sTHBASBindingSource, "STFTNO", true));
            this.sTFTNOGridLookUpEdit.EditValue = "";
            this.sTFTNOGridLookUpEdit.Location = new System.Drawing.Point(163, 80);
            this.sTFTNOGridLookUpEdit.MenuManager = this.barManager;
            this.sTFTNOGridLookUpEdit.Name = "sTFTNOGridLookUpEdit";
            this.sTFTNOGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.sTFTNOGridLookUpEdit.Properties.DisplayMember = "TANIMI";
            this.sTFTNOGridLookUpEdit.Properties.NullText = "";
            this.sTFTNOGridLookUpEdit.Properties.PopupView = this.sTFTNOGridLookUpEditView;
            this.sTFTNOGridLookUpEdit.Properties.ValueMember = "STFTNO";
            this.sTFTNOGridLookUpEdit.Size = new System.Drawing.Size(109, 20);
            this.sTFTNOGridLookUpEdit.TabIndex = 3;
            this.sTFTNOGridLookUpEdit.EditValueChanged += new System.EventHandler(this.sTFTNOGridLookUpEdit_EditValueChanged);
            // 
            // sTFTNOGridLookUpEditView
            // 
            this.sTFTNOGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6});
            this.sTFTNOGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.sTFTNOGridLookUpEditView.Name = "sTFTNOGridLookUpEditView";
            this.sTFTNOGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.sTFTNOGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn10
            // 
            this.gridColumn10.Caption = "Fonksiyon";
            this.gridColumn10.FieldName = "FUNCNM";
            this.gridColumn10.Name = "gridColumn10";
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Kod";
            this.gridColumn4.FieldName = "STFTNO";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "TANIMI";
            this.gridColumn5.FieldName = "TANIMI";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 0;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Tip";
            this.gridColumn6.FieldName = "STHRTP";
            this.gridColumn6.Name = "gridColumn6";
            // 
            // eVRAKNTextEdit
            // 
            this.eVRAKNTextEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sTHBASBindingSource, "EVRAKN", true));
            this.eVRAKNTextEdit.Location = new System.Drawing.Point(407, 80);
            this.eVRAKNTextEdit.MenuManager = this.barManager;
            this.eVRAKNTextEdit.Name = "eVRAKNTextEdit";
            this.eVRAKNTextEdit.Size = new System.Drawing.Size(157, 20);
            this.eVRAKNTextEdit.TabIndex = 18;
            // 
            // btnProfil
            // 
            this.btnProfil.Location = new System.Drawing.Point(407, 185);
            this.btnProfil.Name = "btnProfil";
            this.btnProfil.Size = new System.Drawing.Size(147, 28);
            this.btnProfil.TabIndex = 16;
            this.btnProfil.Text = "Profil Kesim Optimizasyonu";
            this.btnProfil.Click += new System.EventHandler(this.btnProfil_Click);
            // 
            // cKDEPOLabel
            // 
            this.cKDEPOLabel.Location = new System.Drawing.Point(22, 136);
            this.cKDEPOLabel.Name = "cKDEPOLabel";
            this.cKDEPOLabel.Size = new System.Drawing.Size(80, 13);
            this.cKDEPOLabel.TabIndex = 15;
            this.cKDEPOLabel.Text = "Çıkış Depo Kodu:";
            this.cKDEPOLabel.Visible = false;
            // 
            // cKDEPOGridLookUpEdit
            // 
            this.cKDEPOGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sTHBASBindingSource, "CKDEPO", true));
            this.cKDEPOGridLookUpEdit.Location = new System.Drawing.Point(163, 134);
            this.cKDEPOGridLookUpEdit.MenuManager = this.barManager;
            this.cKDEPOGridLookUpEdit.Name = "cKDEPOGridLookUpEdit";
            this.cKDEPOGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.cKDEPOGridLookUpEdit.Properties.DisplayMember = "DPTANM";
            this.cKDEPOGridLookUpEdit.Properties.NullText = "";
            this.cKDEPOGridLookUpEdit.Properties.PopupView = this.cKDEPOGridLookUpEditView;
            this.cKDEPOGridLookUpEdit.Properties.ValueMember = "DPKODU";
            this.cKDEPOGridLookUpEdit.Size = new System.Drawing.Size(109, 20);
            this.cKDEPOGridLookUpEdit.TabIndex = 14;
            this.cKDEPOGridLookUpEdit.Visible = false;
            this.cKDEPOGridLookUpEdit.EditValueChanged += new System.EventHandler(this.cKDEPOGridLookUpEdit_EditValueChanged);
            // 
            // cKDEPOGridLookUpEditView
            // 
            this.cKDEPOGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn13,
            this.gridColumn12});
            this.cKDEPOGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.cKDEPOGridLookUpEditView.Name = "cKDEPOGridLookUpEditView";
            this.cKDEPOGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.cKDEPOGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn13
            // 
            this.gridColumn13.Caption = "Tanım";
            this.gridColumn13.FieldName = "DPTANM";
            this.gridColumn13.Name = "gridColumn13";
            this.gridColumn13.Visible = true;
            this.gridColumn13.VisibleIndex = 0;
            // 
            // gridColumn12
            // 
            this.gridColumn12.Caption = "Kod";
            this.gridColumn12.FieldName = "DPKODU";
            this.gridColumn12.Name = "gridColumn12";
            this.gridColumn12.Visible = true;
            this.gridColumn12.VisibleIndex = 1;
            // 
            // btnStHrktKaydet
            // 
            this.btnStHrktKaydet.Location = new System.Drawing.Point(813, 109);
            this.btnStHrktKaydet.Name = "btnStHrktKaydet";
            this.btnStHrktKaydet.Size = new System.Drawing.Size(77, 62);
            this.btnStHrktKaydet.TabIndex = 12;
            this.btnStHrktKaydet.Text = "Kaydet";
            this.btnStHrktKaydet.Click += new System.EventHandler(this.btnStHrktKaydet_Click);
            // 
            // gRDEPOGridLookUpEdit
            // 
            this.gRDEPOGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sTHBASBindingSource, "GRDEPO", true));
            this.gRDEPOGridLookUpEdit.Location = new System.Drawing.Point(163, 108);
            this.gRDEPOGridLookUpEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gRDEPOGridLookUpEdit.MenuManager = this.barManager;
            this.gRDEPOGridLookUpEdit.Name = "gRDEPOGridLookUpEdit";
            this.gRDEPOGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.gRDEPOGridLookUpEdit.Properties.DisplayMember = "DPTANM";
            this.gRDEPOGridLookUpEdit.Properties.NullText = "";
            this.gRDEPOGridLookUpEdit.Properties.PopupView = this.gRDEPOGridLookUpEditView;
            this.gRDEPOGridLookUpEdit.Properties.ValueMember = "DPKODU";
            this.gRDEPOGridLookUpEdit.Size = new System.Drawing.Size(109, 20);
            this.gRDEPOGridLookUpEdit.TabIndex = 11;
            this.gRDEPOGridLookUpEdit.Visible = false;
            this.gRDEPOGridLookUpEdit.EditValueChanged += new System.EventHandler(this.gRDEPOGridLookUpEdit_EditValueChanged);
            // 
            // gRDEPOGridLookUpEditView
            // 
            this.gRDEPOGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn7});
            this.gRDEPOGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gRDEPOGridLookUpEditView.Name = "gRDEPOGridLookUpEditView";
            this.gRDEPOGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gRDEPOGridLookUpEditView.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kod";
            this.gridColumn3.FieldName = "DPKODU";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Tanım";
            this.gridColumn7.FieldName = "DPTANM";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 1;
            // 
            // gNACIKMemoEdit
            // 
            this.gNACIKMemoEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sTHBASBindingSource, "GNACIK", true));
            this.gNACIKMemoEdit.Location = new System.Drawing.Point(407, 109);
            this.gNACIKMemoEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.gNACIKMemoEdit.MenuManager = this.barManager;
            this.gNACIKMemoEdit.Name = "gNACIKMemoEdit";
            this.gNACIKMemoEdit.Size = new System.Drawing.Size(393, 62);
            this.gNACIKMemoEdit.TabIndex = 9;
            // 
            // bELTRHDateEdit
            // 
            this.bELTRHDateEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sTHBASBindingSource, "BELTRH", true));
            this.bELTRHDateEdit.EditValue = null;
            this.bELTRHDateEdit.Location = new System.Drawing.Point(691, 80);
            this.bELTRHDateEdit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.bELTRHDateEdit.MenuManager = this.barManager;
            this.bELTRHDateEdit.Name = "bELTRHDateEdit";
            this.bELTRHDateEdit.Properties.BeepOnError = false;
            this.bELTRHDateEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bELTRHDateEdit.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.bELTRHDateEdit.Properties.MaskSettings.Set("mask", "d");
            this.bELTRHDateEdit.Properties.MaskSettings.Set("useAdvancingCaret", false);
            this.bELTRHDateEdit.Size = new System.Drawing.Size(182, 20);
            this.bELTRHDateEdit.TabIndex = 7;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.grdControlStHrkt);
            this.groupControl2.Controls.Add(this.bndNvgHareket);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 242);
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(1273, 357);
            this.groupControl2.TabIndex = 5;
            // 
            // bndNvgHareket
            // 
            this.bndNvgHareket.AddNewItem = this.bindingNavigatorAddNewItem2;
            this.bndNvgHareket.BindingSource = this.sTHRKTBindingSource;
            this.bndNvgHareket.CountItem = this.bindingNavigatorCountItem2;
            this.bndNvgHareket.DeleteItem = this.bindingNavigatorDeleteItem2;
            this.bndNvgHareket.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.bndNvgHareket.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.bindingNavigatorMoveFirstItem2,
            this.bindingNavigatorMovePreviousItem2,
            this.bindingNavigatorSeparator6,
            this.bindingNavigatorPositionItem2,
            this.bindingNavigatorCountItem2,
            this.bindingNavigatorSeparator7,
            this.bindingNavigatorMoveNextItem2,
            this.bindingNavigatorMoveLastItem2,
            this.bindingNavigatorSeparator8,
            this.bindingNavigatorAddNewItem2,
            this.bindingNavigatorDeleteItem2});
            this.bndNvgHareket.Location = new System.Drawing.Point(2, 23);
            this.bndNvgHareket.MoveFirstItem = this.bindingNavigatorMoveFirstItem2;
            this.bndNvgHareket.MoveLastItem = this.bindingNavigatorMoveLastItem2;
            this.bndNvgHareket.MoveNextItem = this.bindingNavigatorMoveNextItem2;
            this.bndNvgHareket.MovePreviousItem = this.bindingNavigatorMovePreviousItem2;
            this.bndNvgHareket.Name = "bndNvgHareket";
            this.bndNvgHareket.PositionItem = this.bindingNavigatorPositionItem2;
            this.bndNvgHareket.Size = new System.Drawing.Size(1269, 27);
            this.bndNvgHareket.TabIndex = 7;
            this.bndNvgHareket.Tag = "";
            this.bndNvgHareket.Text = "bindingNavigator3";
            // 
            // bindingNavigatorAddNewItem2
            // 
            this.bindingNavigatorAddNewItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorAddNewItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorAddNewItem2.Image")));
            this.bindingNavigatorAddNewItem2.Name = "bindingNavigatorAddNewItem2";
            this.bindingNavigatorAddNewItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorAddNewItem2.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorAddNewItem2.Text = "Add new";
            this.bindingNavigatorAddNewItem2.Visible = false;
            // 
            // bindingNavigatorCountItem2
            // 
            this.bindingNavigatorCountItem2.Name = "bindingNavigatorCountItem2";
            this.bindingNavigatorCountItem2.Size = new System.Drawing.Size(35, 24);
            this.bindingNavigatorCountItem2.Text = "of {0}";
            this.bindingNavigatorCountItem2.ToolTipText = "Total number of items";
            this.bindingNavigatorCountItem2.Visible = false;
            // 
            // bindingNavigatorDeleteItem2
            // 
            this.bindingNavigatorDeleteItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorDeleteItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorDeleteItem2.Image")));
            this.bindingNavigatorDeleteItem2.Name = "bindingNavigatorDeleteItem2";
            this.bindingNavigatorDeleteItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorDeleteItem2.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorDeleteItem2.Tag = "STDEPO";
            this.bindingNavigatorDeleteItem2.Text = "Delete";
            // 
            // bindingNavigatorMoveFirstItem2
            // 
            this.bindingNavigatorMoveFirstItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveFirstItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveFirstItem2.Image")));
            this.bindingNavigatorMoveFirstItem2.Name = "bindingNavigatorMoveFirstItem2";
            this.bindingNavigatorMoveFirstItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveFirstItem2.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveFirstItem2.Text = "Move first";
            this.bindingNavigatorMoveFirstItem2.Visible = false;
            // 
            // bindingNavigatorMovePreviousItem2
            // 
            this.bindingNavigatorMovePreviousItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMovePreviousItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMovePreviousItem2.Image")));
            this.bindingNavigatorMovePreviousItem2.Name = "bindingNavigatorMovePreviousItem2";
            this.bindingNavigatorMovePreviousItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMovePreviousItem2.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMovePreviousItem2.Text = "Move previous";
            this.bindingNavigatorMovePreviousItem2.Visible = false;
            // 
            // bindingNavigatorSeparator6
            // 
            this.bindingNavigatorSeparator6.Name = "bindingNavigatorSeparator6";
            this.bindingNavigatorSeparator6.Size = new System.Drawing.Size(6, 27);
            this.bindingNavigatorSeparator6.Visible = false;
            // 
            // bindingNavigatorPositionItem2
            // 
            this.bindingNavigatorPositionItem2.AccessibleName = "Position";
            this.bindingNavigatorPositionItem2.AutoSize = false;
            this.bindingNavigatorPositionItem2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bindingNavigatorPositionItem2.Name = "bindingNavigatorPositionItem2";
            this.bindingNavigatorPositionItem2.Size = new System.Drawing.Size(43, 23);
            this.bindingNavigatorPositionItem2.Text = "0";
            this.bindingNavigatorPositionItem2.ToolTipText = "Current position";
            this.bindingNavigatorPositionItem2.Visible = false;
            // 
            // bindingNavigatorSeparator7
            // 
            this.bindingNavigatorSeparator7.Name = "bindingNavigatorSeparator7";
            this.bindingNavigatorSeparator7.Size = new System.Drawing.Size(6, 27);
            this.bindingNavigatorSeparator7.Visible = false;
            // 
            // bindingNavigatorMoveNextItem2
            // 
            this.bindingNavigatorMoveNextItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveNextItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveNextItem2.Image")));
            this.bindingNavigatorMoveNextItem2.Name = "bindingNavigatorMoveNextItem2";
            this.bindingNavigatorMoveNextItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveNextItem2.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveNextItem2.Text = "Move next";
            this.bindingNavigatorMoveNextItem2.Visible = false;
            // 
            // bindingNavigatorMoveLastItem2
            // 
            this.bindingNavigatorMoveLastItem2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.bindingNavigatorMoveLastItem2.Image = ((System.Drawing.Image)(resources.GetObject("bindingNavigatorMoveLastItem2.Image")));
            this.bindingNavigatorMoveLastItem2.Name = "bindingNavigatorMoveLastItem2";
            this.bindingNavigatorMoveLastItem2.RightToLeftAutoMirrorImage = true;
            this.bindingNavigatorMoveLastItem2.Size = new System.Drawing.Size(24, 24);
            this.bindingNavigatorMoveLastItem2.Text = "Move last";
            this.bindingNavigatorMoveLastItem2.Visible = false;
            // 
            // bindingNavigatorSeparator8
            // 
            this.bindingNavigatorSeparator8.Name = "bindingNavigatorSeparator8";
            this.bindingNavigatorSeparator8.Size = new System.Drawing.Size(6, 27);
            this.bindingNavigatorSeparator8.Visible = false;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            this.dxErrorProvider1.DataSource = this.sTHRKTBindingSource;
            // 
            // dxErrorProvider2
            // 
            this.dxErrorProvider2.ContainerControl = this;
            this.dxErrorProvider2.DataSource = this.sTHBASBindingSource;
            // 
            // wMADRTBindingSource
            // 
            this.wMADRTBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.WM.WMADRT);
            // 
            // popMenu
            // 
            this.popMenu.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButGrmktrSifirla)});
            this.popMenu.Manager = this.barManager;
            this.popMenu.Name = "popMenu";
            // 
            // barButGrmktrSifirla
            // 
            this.barButGrmktrSifirla.Caption = "Giriş miktarlarını sıfırla";
            this.barButGrmktrSifirla.Id = 28;
            this.barButGrmktrSifirla.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButGrmktrSifirla.ImageOptions.Image")));
            this.barButGrmktrSifirla.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButGrmktrSifirla.ImageOptions.LargeImage")));
            this.barButGrmktrSifirla.Name = "barButGrmktrSifirla";
            this.barButGrmktrSifirla.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButGrmktrSifirla_ItemClick);
            // 
            // barCheckItem1
            // 
            this.barCheckItem1.Caption = "barCheckItem1";
            this.barCheckItem1.Id = 27;
            this.barCheckItem1.Name = "barCheckItem1";
            // 
            // FrmStokHareket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(1273, 599);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmStokHareket.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmStokHareket";
            this.Load += new System.EventHandler(this.FrmStokHareket_Load);
            this.Controls.SetChildIndex(this.groupControl1, 0);
            this.Controls.SetChildIndex(this.groupControl2, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewDetail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdControlStHrkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHRKTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdViewStHrkt)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedStHrktStokKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedOlcuBirimi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedTeslimAlan)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDtoTeslimTarihi)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedWmAdresTanim)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            this.grpBox2.ResumeLayout(false);
            this.grpBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.cRKODUGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHBASBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cRKODUGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLkeSASNO.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sTHRTPGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTHRTPGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTFTNOGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTFTNOGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.eVRAKNTextEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cKDEPOGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.cKDEPOGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRDEPOGridLookUpEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gRDEPOGridLookUpEditView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNACIKMemoEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bELTRHDateEdit.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bELTRHDateEdit.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bndNvgHareket)).EndInit();
            this.bndNvgHareket.ResumeLayout(false);
            this.bndNvgHareket.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wMADRTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl grdControlStHrkt;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewStHrkt;
        private System.Windows.Forms.BindingSource sTHRKTBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSTHRTP;
        private DevExpress.XtraGrid.Columns.GridColumn colSTFTNO;
        private DevExpress.XtraGrid.Columns.GridColumn colSTNMIA;
        private DevExpress.XtraGrid.Columns.GridColumn colSATIRN;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGEN;
        private DevExpress.XtraGrid.Columns.GridColumn colBELTRH;
        private DevExpress.XtraGrid.Columns.GridColumn colSTKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colSTKNAM;
        private DevExpress.XtraGrid.Columns.GridColumn colISM1KD;
        private DevExpress.XtraGrid.Columns.GridColumn colISM2KD;
        private DevExpress.XtraGrid.Columns.GridColumn colISM3KD;
        private DevExpress.XtraGrid.Columns.GridColumn colISMSM1;
        private DevExpress.XtraGrid.Columns.GridColumn colISMSM2;
        private DevExpress.XtraGrid.Columns.GridColumn colISMSM3;
        private DevExpress.XtraGrid.Columns.GridColumn colISMSD1;
        private DevExpress.XtraGrid.Columns.GridColumn colISMSD2;
        private DevExpress.XtraGrid.Columns.GridColumn colISMSD3;
        private DevExpress.XtraGrid.Columns.GridColumn colPROFLG;
        private DevExpress.XtraGrid.Columns.GridColumn colCRHRKD;
        private DevExpress.XtraGrid.Columns.GridColumn colCRKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colDVCNKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDVZFYT;
        private DevExpress.XtraGrid.Columns.GridColumn colDVZALT;
        private DevExpress.XtraGrid.Columns.GridColumn colSTDVCN;
        private DevExpress.XtraGrid.Columns.GridColumn colSTDFYT;
        private DevExpress.XtraGrid.Columns.GridColumn colGNMKTR;
        private DevExpress.XtraGrid.Columns.GridColumn colOLCUKD;
        private DevExpress.XtraGrid.Columns.GridColumn colGRMKTR;
        private DevExpress.XtraGrid.Columns.GridColumn colGROLBR;
        private DevExpress.XtraGrid.Columns.GridColumn colGNTUTR;
        private DevExpress.XtraGrid.Columns.GridColumn colVRGORN;
        private DevExpress.XtraGrid.Columns.GridColumn colGNACIK;
        private DevExpress.XtraGrid.Columns.GridColumn colGRDEPO;
        private DevExpress.XtraGrid.Columns.GridColumn colCKDEPO;
        private DevExpress.XtraGrid.Columns.GridColumn colMLKBTR;
        private DevExpress.XtraGrid.Columns.GridColumn colVRGTUT;
        private DevExpress.XtraGrid.Columns.GridColumn colVRGSIZ;
        private DevExpress.XtraGrid.Columns.GridColumn colOTVORN;
        private DevExpress.XtraGrid.Columns.GridColumn colOTVTUT;
        private DevExpress.XtraGrid.Columns.GridColumn colBRTAGR;
        private DevExpress.XtraGrid.Columns.GridColumn colNETAGR;
        private DevExpress.XtraGrid.Columns.GridColumn colAGOLKD;
        private DevExpress.XtraGrid.Columns.GridColumn colOIVORN;
        private DevExpress.XtraGrid.Columns.GridColumn colOIVTUT;
        private DevExpress.XtraGrid.Columns.GridColumn colTEVKIF;
        private DevExpress.XtraGrid.Columns.GridColumn colILVKDV;
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
        private DevExpress.XtraEditors.GridLookUpEdit gRDEPOGridLookUpEdit;
        private System.Windows.Forms.BindingSource sTHBASBindingSource;
        private DevExpress.XtraGrid.Views.Grid.GridView gRDEPOGridLookUpEditView;
        private DevExpress.XtraEditors.MemoEdit gNACIKMemoEdit;
        private DevExpress.XtraEditors.DateEdit bELTRHDateEdit;
        private DevExpress.XtraEditors.GridLookUpEdit sTFTNOGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView sTFTNOGridLookUpEditView;
        private DevExpress.XtraEditors.GridLookUpEdit sTHRTPGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView sTHRTPGridLookUpEditView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private System.Windows.Forms.BindingNavigator bndNvgHareket;
        private System.Windows.Forms.ToolStripButton bindingNavigatorAddNewItem2;
        private System.Windows.Forms.ToolStripLabel bindingNavigatorCountItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorDeleteItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveFirstItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMovePreviousItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator6;
        private System.Windows.Forms.ToolStripTextBox bindingNavigatorPositionItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator7;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveNextItem2;
        private System.Windows.Forms.ToolStripButton bindingNavigatorMoveLastItem2;
        private System.Windows.Forms.ToolStripSeparator bindingNavigatorSeparator8;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkedStHrktStokKod;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.SimpleButton btnStHrktKaydet;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider2;
        private DevExpress.XtraEditors.GridLookUpEdit cKDEPOGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView cKDEPOGridLookUpEditView;
        private DevExpress.XtraEditors.LabelControl cKDEPOLabel;
        private System.Windows.Forms.Label gRDEPOLabel;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private System.Windows.Forms.BindingSource wMADRTBindingSource;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkedOlcuBirimi;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraEditors.SimpleButton btnProfil;
        private DevExpress.XtraGrid.Columns.GridColumn colPARTIN;
        private DevExpress.XtraGrid.Columns.GridColumn colPARTIT;
        private DevExpress.XtraGrid.Columns.GridColumn colTSALAN;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkedTeslimAlan;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraEditors.TextEdit eVRAKNTextEdit;
        private DevExpress.XtraGrid.Columns.GridColumn colTSTARH;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateTimeOffsetEdit repDtoTeslimTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn unboundHDADRS;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkedWmAdresTanim;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn unboundKYADRS;
        private System.Windows.Forms.GroupBox groupBox1;
        private DevExpress.XtraEditors.GridLookUpEdit cRKODUGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView cRKODUGridLookUpEditView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraEditors.GridLookUpEdit gridLkeSASNO;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private System.Windows.Forms.GroupBox grpBox2;
        private DevExpress.XtraBars.PopupMenu popMenu;
        private DevExpress.XtraBars.BarButtonItem barButGrmktrSifirla;
        private DevExpress.XtraBars.BarCheckItem barCheckItem1;
        private DevExpress.XtraGrid.Views.Grid.GridView grdViewDetail;
        private DevExpress.XtraGrid.Columns.GridColumn colrnkbdnVRKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colrnkbdnRENKTN;
        private DevExpress.XtraGrid.Columns.GridColumn colrnkbdnBEDNTN;
        private DevExpress.XtraGrid.Columns.GridColumn colrnkbdnDROPTN;
    }
}
