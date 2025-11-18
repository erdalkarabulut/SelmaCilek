namespace BPS.Windows.Forms
{
    partial class FrmOdemeTablosu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmOdemeTablosu));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sPODTBBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colBELGEN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODMSKL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODMORN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODMTTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVCNKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODMTRH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colODMACK = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.repYaratmaSaatTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repDegisiklikSaatiTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repYaratmaadiLkUp = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcol1KullaniciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDegistirenAdiLkUp = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcol2KullaniciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.lblTutar = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPODTBBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaSaatTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegisiklikSaatiTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaadiLkUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegistirenAdiLkUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sPODTBBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 53);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repYaratmaSaatTimeEdit,
            this.repDegisiklikSaatiTimeEdit,
            this.repYaratmaadiLkUp,
            this.repDegistirenAdiLkUp,
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(829, 410);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sPODTBBindingSource
            // 
            this.sPODTBBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.SP.SPODTB);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colBELGEN,
            this.colODMSKL,
            this.colODMORN,
            this.colODMTTR,
            this.colDVCNKD,
            this.colODMTRH,
            this.colODMACK,
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
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowFooter = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidatingEditor += new DevExpress.XtraEditors.Controls.BaseContainerValidateEditorEventHandler(this.gridView1_ValidatingEditor);
            // 
            // colBELGEN
            // 
            this.colBELGEN.FieldName = "BELGEN";
            this.colBELGEN.Name = "colBELGEN";
            // 
            // colODMSKL
            // 
            this.colODMSKL.Caption = "Ödeme Şekli";
            this.colODMSKL.FieldName = "ODMSKL";
            this.colODMSKL.Name = "colODMSKL";
            this.colODMSKL.Visible = true;
            this.colODMSKL.VisibleIndex = 0;
            // 
            // colODMORN
            // 
            this.colODMORN.Caption = "Ödeme Oranı (%)";
            this.colODMORN.DisplayFormat.FormatString = "n2";
            this.colODMORN.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colODMORN.FieldName = "ODMORN";
            this.colODMORN.Name = "colODMORN";
            this.colODMORN.Visible = true;
            this.colODMORN.VisibleIndex = 1;
            // 
            // colODMTTR
            // 
            this.colODMTTR.Caption = "Tutar";
            this.colODMTTR.DisplayFormat.FormatString = "n2";
            this.colODMTTR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colODMTTR.FieldName = "ODMTTR";
            this.colODMTTR.Name = "colODMTTR";
            this.colODMTTR.Visible = true;
            this.colODMTTR.VisibleIndex = 2;
            // 
            // colDVCNKD
            // 
            this.colDVCNKD.FieldName = "DVCNKD";
            this.colDVCNKD.Name = "colDVCNKD";
            this.colDVCNKD.Visible = true;
            this.colDVCNKD.VisibleIndex = 3;
            // 
            // colODMTRH
            // 
            this.colODMTRH.Caption = "Ödeme Tarihi";
            this.colODMTRH.FieldName = "ODMTRH";
            this.colODMTRH.Name = "colODMTRH";
            this.colODMTRH.Visible = true;
            this.colODMTRH.VisibleIndex = 4;
            // 
            // colODMACK
            // 
            this.colODMACK.Caption = "Açıklama";
            this.colODMACK.FieldName = "ODMACK";
            this.colODMACK.Name = "colODMACK";
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
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.lblTutar);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl1.Location = new System.Drawing.Point(0, 24);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(829, 29);
            this.panelControl1.TabIndex = 6;
            // 
            // lblTutar
            // 
            this.lblTutar.AutoSize = true;
            this.lblTutar.Location = new System.Drawing.Point(8, 8);
            this.lblTutar.Name = "lblTutar";
            this.lblTutar.Size = new System.Drawing.Size(0, 13);
            this.lblTutar.TabIndex = 0;
            // 
            // FrmOdemeTablosu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(829, 463);
            this.Controls.Add(this.gridControl1);
            this.Controls.Add(this.panelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmOdemeTablosu.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmOdemeTablosu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ödeme Tablosu";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.panelControl1, 0);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPODTBBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaSaatTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegisiklikSaatiTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaadiLkUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegistirenAdiLkUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
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
        private System.Windows.Forms.BindingSource sPODTBBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGEN;
        private DevExpress.XtraGrid.Columns.GridColumn colODMSKL;
        private DevExpress.XtraGrid.Columns.GridColumn colODMTRH;
        private DevExpress.XtraGrid.Columns.GridColumn colODMACK;
        private DevExpress.XtraGrid.Columns.GridColumn colODMTTR;
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
        private DevExpress.XtraGrid.Columns.GridColumn colDVCNKD;
        private DevExpress.XtraGrid.Columns.GridColumn colODMORN;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label lblTutar;
    }
}
