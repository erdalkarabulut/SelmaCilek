namespace BPS.Windows.Forms
{
    partial class FrmStokFiyat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmStokFiyat));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sTKFYTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTFYNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTHRTP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repStkFytHareketTip = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTANIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVCNKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKDVFLG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGISKNT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGISKNT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGISKNT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPORKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPDGKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBASTAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBITTAR = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTKFYTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStkFytHareketTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaSaatTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegisiklikSaatiTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaadiLkUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegistirenAdiLkUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sTKFYTBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repYaratmaSaatTimeEdit,
            this.repDegisiklikSaatiTimeEdit,
            this.repYaratmaadiLkUp,
            this.repDegistirenAdiLkUp,
            this.repositoryItemDateEdit1,
            this.repStkFytHareketTip});
            this.gridControl1.Size = new System.Drawing.Size(1116, 520);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sTKFYTBindingSource
            // 
            this.sTKFYTBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.ST.STKFYT);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTFYNO,
            this.colSTHRTP,
            this.colTANIMI,
            this.colDVCNKD,
            this.colKDVFLG,
            this.colGISKNT1,
            this.colGISKNT2,
            this.colGISKNT3,
            this.colSPORKD,
            this.colSPDGKD,
            this.colBASTAR,
            this.colBITTAR,
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
            this.gridView1.DetailHeight = 431;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colSTFYNO
            // 
            this.colSTFYNO.FieldName = "STFYNO";
            this.colSTFYNO.MinWidth = 25;
            this.colSTFYNO.Name = "colSTFYNO";
            this.colSTFYNO.Visible = true;
            this.colSTFYNO.VisibleIndex = 0;
            this.colSTFYNO.Width = 94;
            // 
            // colSTHRTP
            // 
            this.colSTHRTP.ColumnEdit = this.repStkFytHareketTip;
            this.colSTHRTP.FieldName = "STHRTP";
            this.colSTHRTP.MinWidth = 25;
            this.colSTHRTP.Name = "colSTHRTP";
            this.colSTHRTP.Visible = true;
            this.colSTHRTP.VisibleIndex = 1;
            this.colSTHRTP.Width = 94;
            // 
            // repStkFytHareketTip
            // 
            this.repStkFytHareketTip.AutoHeight = false;
            this.repStkFytHareketTip.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repStkFytHareketTip.DisplayMember = "Text";
            this.repStkFytHareketTip.Name = "repStkFytHareketTip";
            this.repStkFytHareketTip.PopupView = this.gridView3;
            this.repStkFytHareketTip.ValueMember = "Value";
            // 
            // gridView3
            // 
            this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView3.Name = "gridView3";
            this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView3.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Kod";
            this.gridColumn1.FieldName = "Value";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tanım";
            this.gridColumn2.FieldName = "Text";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // colTANIMI
            // 
            this.colTANIMI.FieldName = "TANIMI";
            this.colTANIMI.MinWidth = 25;
            this.colTANIMI.Name = "colTANIMI";
            this.colTANIMI.Visible = true;
            this.colTANIMI.VisibleIndex = 2;
            this.colTANIMI.Width = 94;
            // 
            // colDVCNKD
            // 
            this.colDVCNKD.FieldName = "DVCNKD";
            this.colDVCNKD.MinWidth = 25;
            this.colDVCNKD.Name = "colDVCNKD";
            this.colDVCNKD.Visible = true;
            this.colDVCNKD.VisibleIndex = 3;
            this.colDVCNKD.Width = 94;
            // 
            // colKDVFLG
            // 
            this.colKDVFLG.FieldName = "KDVFLG";
            this.colKDVFLG.MinWidth = 25;
            this.colKDVFLG.Name = "colKDVFLG";
            this.colKDVFLG.Visible = true;
            this.colKDVFLG.VisibleIndex = 4;
            this.colKDVFLG.Width = 94;
            // 
            // colGISKNT1
            // 
            this.colGISKNT1.FieldName = "GISKNT1";
            this.colGISKNT1.MinWidth = 25;
            this.colGISKNT1.Name = "colGISKNT1";
            this.colGISKNT1.Visible = true;
            this.colGISKNT1.VisibleIndex = 5;
            this.colGISKNT1.Width = 94;
            // 
            // colGISKNT2
            // 
            this.colGISKNT2.FieldName = "GISKNT2";
            this.colGISKNT2.MinWidth = 25;
            this.colGISKNT2.Name = "colGISKNT2";
            this.colGISKNT2.Visible = true;
            this.colGISKNT2.VisibleIndex = 6;
            this.colGISKNT2.Width = 94;
            // 
            // colGISKNT3
            // 
            this.colGISKNT3.FieldName = "GISKNT3";
            this.colGISKNT3.MinWidth = 25;
            this.colGISKNT3.Name = "colGISKNT3";
            this.colGISKNT3.Visible = true;
            this.colGISKNT3.VisibleIndex = 7;
            this.colGISKNT3.Width = 94;
            // 
            // colSPORKD
            // 
            this.colSPORKD.FieldName = "SPORKD";
            this.colSPORKD.MinWidth = 25;
            this.colSPORKD.Name = "colSPORKD";
            this.colSPORKD.Visible = true;
            this.colSPORKD.VisibleIndex = 8;
            this.colSPORKD.Width = 94;
            // 
            // colSPDGKD
            // 
            this.colSPDGKD.FieldName = "SPDGKD";
            this.colSPDGKD.MinWidth = 25;
            this.colSPDGKD.Name = "colSPDGKD";
            this.colSPDGKD.Visible = true;
            this.colSPDGKD.VisibleIndex = 9;
            this.colSPDGKD.Width = 94;
            // 
            // colBASTAR
            // 
            this.colBASTAR.FieldName = "BASTAR";
            this.colBASTAR.MinWidth = 25;
            this.colBASTAR.Name = "colBASTAR";
            this.colBASTAR.Visible = true;
            this.colBASTAR.VisibleIndex = 10;
            this.colBASTAR.Width = 94;
            // 
            // colBITTAR
            // 
            this.colBITTAR.FieldName = "BITTAR";
            this.colBITTAR.MinWidth = 25;
            this.colBITTAR.Name = "colBITTAR";
            this.colBITTAR.Visible = true;
            this.colBITTAR.VisibleIndex = 11;
            this.colBITTAR.Width = 94;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Width = 94;
            // 
            // colSIRKID
            // 
            this.colSIRKID.FieldName = "SIRKID";
            this.colSIRKID.MinWidth = 25;
            this.colSIRKID.Name = "colSIRKID";
            this.colSIRKID.Width = 94;
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.MinWidth = 25;
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Width = 94;
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.MinWidth = 25;
            this.colSLINDI.Name = "colSLINDI";
            this.colSLINDI.Width = 94;
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.MinWidth = 25;
            this.colEKKULL.Name = "colEKKULL";
            this.colEKKULL.Width = 94;
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.MinWidth = 25;
            this.colETARIH.Name = "colETARIH";
            this.colETARIH.Width = 94;
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.MinWidth = 25;
            this.colDEKULL.Name = "colDEKULL";
            this.colDEKULL.Width = 94;
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.MinWidth = 25;
            this.colDTARIH.Name = "colDTARIH";
            this.colDTARIH.Width = 94;
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.MinWidth = 25;
            this.colKYNKKD.Name = "colKYNKKD";
            this.colKYNKKD.Width = 94;
            // 
            // colCHKCTR
            // 
            this.colCHKCTR.FieldName = "CHKCTR";
            this.colCHKCTR.MinWidth = 25;
            this.colCHKCTR.Name = "colCHKCTR";
            this.colCHKCTR.Width = 94;
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
            this.repositoryItemGridLookUpEdit1View.DetailHeight = 431;
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repcol1KullaniciAdi
            // 
            this.repcol1KullaniciAdi.Caption = "Kullanici Adi";
            this.repcol1KullaniciAdi.FieldName = "KullaniciAdi";
            this.repcol1KullaniciAdi.MinWidth = 23;
            this.repcol1KullaniciAdi.Name = "repcol1KullaniciAdi";
            this.repcol1KullaniciAdi.Visible = true;
            this.repcol1KullaniciAdi.VisibleIndex = 0;
            this.repcol1KullaniciAdi.Width = 87;
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
            this.gridView2.DetailHeight = 431;
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // repcol2KullaniciAdi
            // 
            this.repcol2KullaniciAdi.Caption = "Kullanici Adı";
            this.repcol2KullaniciAdi.FieldName = "KullaniciAdi";
            this.repcol2KullaniciAdi.MinWidth = 23;
            this.repcol2KullaniciAdi.Name = "repcol2KullaniciAdi";
            this.repcol2KullaniciAdi.Visible = true;
            this.repcol2KullaniciAdi.VisibleIndex = 0;
            this.repcol2KullaniciAdi.Width = 87;
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
            // FrmStokFiyat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(1116, 570);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmStokFiyat.IconOptions.Image")));
            this.Name = "FrmStokFiyat";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTKFYTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repStkFytHareketTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaSaatTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegisiklikSaatiTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaadiLkUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegistirenAdiLkUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repYaratmaSaatTimeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repDegisiklikSaatiTimeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repYaratmaadiLkUp;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn repcol1KullaniciAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repDegistirenAdiLkUp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn repcol2KullaniciAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private System.Windows.Forms.BindingSource sTKFYTBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSTFYNO;
        private DevExpress.XtraGrid.Columns.GridColumn colSTHRTP;
        private DevExpress.XtraGrid.Columns.GridColumn colTANIMI;
        private DevExpress.XtraGrid.Columns.GridColumn colDVCNKD;
        private DevExpress.XtraGrid.Columns.GridColumn colKDVFLG;
        private DevExpress.XtraGrid.Columns.GridColumn colGISKNT1;
        private DevExpress.XtraGrid.Columns.GridColumn colGISKNT2;
        private DevExpress.XtraGrid.Columns.GridColumn colGISKNT3;
        private DevExpress.XtraGrid.Columns.GridColumn colSPORKD;
        private DevExpress.XtraGrid.Columns.GridColumn colSPDGKD;
        private DevExpress.XtraGrid.Columns.GridColumn colBASTAR;
        private DevExpress.XtraGrid.Columns.GridColumn colBITTAR;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repStkFytHareketTip;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
    }
}
