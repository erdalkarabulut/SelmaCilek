namespace BPS.Windows.Forms
{
    partial class FrmTipTanim
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTipTanim));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gNTIPIBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTIPKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTIPADI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEKNAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUTPKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repUstTipKod = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colHRKTBL = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.repHareketTablosu = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNTIPIBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUstTipKod)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repHareketTablosu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.gNTIPIBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repUstTipKod,
            this.repHareketTablosu});
            this.gridControl1.Size = new System.Drawing.Size(957, 439);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gNTIPIBindingSource
            // 
            this.gNTIPIBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.GN.GNTIPI);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTIPKOD,
            this.colTIPADI,
            this.colTEKNAD,
            this.colUTPKOD,
            this.colHRKTBL,
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
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // colTIPKOD
            // 
            this.colTIPKOD.FieldName = "TIPKOD";
            this.colTIPKOD.Name = "colTIPKOD";
            this.colTIPKOD.Visible = true;
            this.colTIPKOD.VisibleIndex = 0;
            // 
            // colTIPADI
            // 
            this.colTIPADI.FieldName = "TIPADI";
            this.colTIPADI.Name = "colTIPADI";
            this.colTIPADI.Visible = true;
            this.colTIPADI.VisibleIndex = 1;
            // 
            // colTEKNAD
            // 
            this.colTEKNAD.FieldName = "TEKNAD";
            this.colTEKNAD.Name = "colTEKNAD";
            this.colTEKNAD.Visible = true;
            this.colTEKNAD.VisibleIndex = 2;
            // 
            // colUTPKOD
            // 
            this.colUTPKOD.ColumnEdit = this.repUstTipKod;
            this.colUTPKOD.FieldName = "UTPKOD";
            this.colUTPKOD.Name = "colUTPKOD";
            this.colUTPKOD.Visible = true;
            this.colUTPKOD.VisibleIndex = 3;
            // 
            // repUstTipKod
            // 
            this.repUstTipKod.AutoHeight = false;
            this.repUstTipKod.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repUstTipKod.DisplayMember = "TIPADI";
            this.repUstTipKod.Name = "repUstTipKod";
            this.repUstTipKod.NullText = "";
            this.repUstTipKod.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repUstTipKod.ValueMember = "TIPKOD";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Tip Kodu";
            this.gridColumn1.FieldName = "TIPKOD";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Tip Adı";
            this.gridColumn2.FieldName = "TIPADI";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // colHRKTBL
            // 
            this.colHRKTBL.Caption = "Hareket Tablosu";
            this.colHRKTBL.ColumnEdit = this.repHareketTablosu;
            this.colHRKTBL.FieldName = "HRKTBL";
            this.colHRKTBL.Name = "colHRKTBL";
            this.colHRKTBL.Visible = true;
            this.colHRKTBL.VisibleIndex = 4;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 5;
            // 
            // colSIRKID
            // 
            this.colSIRKID.FieldName = "SIRKID";
            this.colSIRKID.Name = "colSIRKID";
            this.colSIRKID.Visible = true;
            this.colSIRKID.VisibleIndex = 6;
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Visible = true;
            this.colACTIVE.VisibleIndex = 7;
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.Name = "colSLINDI";
            this.colSLINDI.Visible = true;
            this.colSLINDI.VisibleIndex = 8;
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.Name = "colEKKULL";
            this.colEKKULL.Visible = true;
            this.colEKKULL.VisibleIndex = 9;
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.Name = "colETARIH";
            this.colETARIH.Visible = true;
            this.colETARIH.VisibleIndex = 10;
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.Name = "colDEKULL";
            this.colDEKULL.Visible = true;
            this.colDEKULL.VisibleIndex = 11;
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.Name = "colDTARIH";
            this.colDTARIH.Visible = true;
            this.colDTARIH.VisibleIndex = 12;
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.Name = "colKYNKKD";
            this.colKYNKKD.Visible = true;
            this.colKYNKKD.VisibleIndex = 13;
            // 
            // colCHKCTR
            // 
            this.colCHKCTR.FieldName = "CHKCTR";
            this.colCHKCTR.Name = "colCHKCTR";
            this.colCHKCTR.Visible = true;
            this.colCHKCTR.VisibleIndex = 14;
            // 
            // repHareketTablosu
            // 
            this.repHareketTablosu.AutoHeight = false;
            this.repHareketTablosu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repHareketTablosu.DisplayMember = "TANIMI";
            this.repHareketTablosu.Name = "repHareketTablosu";
            this.repHareketTablosu.PopupView = this.gridView2;
            this.repHareketTablosu.ValueMember = "HARKOD";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn3,
            this.gridColumn4});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowAutoFilterRow = true;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Kod";
            this.gridColumn3.FieldName = "HARKOD";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 0;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Tanım";
            this.gridColumn4.FieldName = "TANIMI";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 1;
            // 
            // FrmTipTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmTipTanim.IconOptions.Image")));
            this.Name = "FrmTipTanim";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNTIPIBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUstTipKod)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repHareketTablosu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource gNTIPIBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPKOD;
        private DevExpress.XtraGrid.Columns.GridColumn colTIPADI;
        private DevExpress.XtraGrid.Columns.GridColumn colTEKNAD;
        private DevExpress.XtraGrid.Columns.GridColumn colUTPKOD;
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
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repUstTipKod;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn colHRKTBL;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repHareketTablosu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
    }
}
