namespace BPS.Windows.Forms
{
    partial class FrmEvrakTanim
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
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gNEVRKBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTABLNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEKNAD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colISLTUR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNYEAR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNONEK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKARSAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBASDEG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBITDEG = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKALDEG = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNEVRKBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.gNEVRKBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(957, 419);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gNEVRKBindingSource
            // 
            this.gNEVRKBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.GN.GNEVRK);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTABLNM,
            this.colTEKNAD,
            this.colISLTUR,
            this.colGNYEAR,
            this.colGNONEK,
            this.colKARSAY,
            this.colBASDEG,
            this.colBITDEG,
            this.colKALDEG,
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
            // colTABLNM
            // 
            this.colTABLNM.FieldName = "TABLNM";
            this.colTABLNM.Name = "colTABLNM";
            this.colTABLNM.Visible = true;
            this.colTABLNM.VisibleIndex = 0;
            // 
            // colTEKNAD
            // 
            this.colTEKNAD.FieldName = "TEKNAD";
            this.colTEKNAD.Name = "colTEKNAD";
            this.colTEKNAD.Visible = true;
            this.colTEKNAD.VisibleIndex = 1;
            // 
            // colISLTUR
            // 
            this.colISLTUR.FieldName = "ISLTUR";
            this.colISLTUR.Name = "colISLTUR";
            this.colISLTUR.Visible = true;
            this.colISLTUR.VisibleIndex = 2;
            // 
            // colGNYEAR
            // 
            this.colGNYEAR.FieldName = "GNYEAR";
            this.colGNYEAR.Name = "colGNYEAR";
            this.colGNYEAR.Visible = true;
            this.colGNYEAR.VisibleIndex = 3;
            // 
            // colGNONEK
            // 
            this.colGNONEK.FieldName = "GNONEK";
            this.colGNONEK.Name = "colGNONEK";
            this.colGNONEK.Visible = true;
            this.colGNONEK.VisibleIndex = 4;
            // 
            // colKARSAY
            // 
            this.colKARSAY.FieldName = "KARSAY";
            this.colKARSAY.Name = "colKARSAY";
            this.colKARSAY.Visible = true;
            this.colKARSAY.VisibleIndex = 5;
            // 
            // colBASDEG
            // 
            this.colBASDEG.FieldName = "BASDEG";
            this.colBASDEG.Name = "colBASDEG";
            this.colBASDEG.Visible = true;
            this.colBASDEG.VisibleIndex = 6;
            // 
            // colBITDEG
            // 
            this.colBITDEG.FieldName = "BITDEG";
            this.colBITDEG.Name = "colBITDEG";
            this.colBITDEG.Visible = true;
            this.colBITDEG.VisibleIndex = 7;
            // 
            // colKALDEG
            // 
            this.colKALDEG.FieldName = "KALDEG";
            this.colKALDEG.Name = "colKALDEG";
            this.colKALDEG.Visible = true;
            this.colKALDEG.VisibleIndex = 8;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 9;
            // 
            // colSIRKID
            // 
            this.colSIRKID.FieldName = "SIRKID";
            this.colSIRKID.Name = "colSIRKID";
            this.colSIRKID.Visible = true;
            this.colSIRKID.VisibleIndex = 10;
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Visible = true;
            this.colACTIVE.VisibleIndex = 11;
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.Name = "colSLINDI";
            this.colSLINDI.Visible = true;
            this.colSLINDI.VisibleIndex = 12;
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.Name = "colEKKULL";
            this.colEKKULL.Visible = true;
            this.colEKKULL.VisibleIndex = 13;
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.Name = "colETARIH";
            this.colETARIH.Visible = true;
            this.colETARIH.VisibleIndex = 14;
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.Name = "colDEKULL";
            this.colDEKULL.Visible = true;
            this.colDEKULL.VisibleIndex = 15;
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.Name = "colDTARIH";
            this.colDTARIH.Visible = true;
            this.colDTARIH.VisibleIndex = 16;
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.Name = "colKYNKKD";
            this.colKYNKKD.Visible = true;
            this.colKYNKKD.VisibleIndex = 17;
            // 
            // colCHKCTR
            // 
            this.colCHKCTR.FieldName = "CHKCTR";
            this.colCHKCTR.Name = "colCHKCTR";
            this.colCHKCTR.Visible = true;
            this.colCHKCTR.VisibleIndex = 18;
            // 
            // FrmEvrakTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmEvrakTanim";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNEVRKBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource gNEVRKBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTABLNM;
        private DevExpress.XtraGrid.Columns.GridColumn colTEKNAD;
        private DevExpress.XtraGrid.Columns.GridColumn colISLTUR;
        private DevExpress.XtraGrid.Columns.GridColumn colGNYEAR;
        private DevExpress.XtraGrid.Columns.GridColumn colGNONEK;
        private DevExpress.XtraGrid.Columns.GridColumn colKARSAY;
        private DevExpress.XtraGrid.Columns.GridColumn colBASDEG;
        private DevExpress.XtraGrid.Columns.GridColumn colBITDEG;
        private DevExpress.XtraGrid.Columns.GridColumn colKALDEG;
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
    }
}
