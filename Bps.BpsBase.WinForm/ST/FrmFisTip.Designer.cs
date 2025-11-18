namespace BPS.Windows.Forms
{
    partial class FrmFisTip
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
            this.sTFTIPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSTFTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTANIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNEVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNACIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNONAY = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.colFUNCNM = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTFTIPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sTFTIPBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(957, 419);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sTFTIPBindingSource
            // 
            this.sTFTIPBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.ST.STFTIP);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSTFTNO,
            this.colTANIMI,
            this.colGNEVID,
            this.colGNACIK,
            this.colGNONAY,
            this.colFUNCNM,
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
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colSTFTNO
            // 
            this.colSTFTNO.FieldName = "STFTNO";
            this.colSTFTNO.MinWidth = 21;
            this.colSTFTNO.Name = "colSTFTNO";
            this.colSTFTNO.Visible = true;
            this.colSTFTNO.VisibleIndex = 0;
            this.colSTFTNO.Width = 86;
            // 
            // colTANIMI
            // 
            this.colTANIMI.FieldName = "TANIMI";
            this.colTANIMI.MinWidth = 21;
            this.colTANIMI.Name = "colTANIMI";
            this.colTANIMI.Visible = true;
            this.colTANIMI.VisibleIndex = 1;
            this.colTANIMI.Width = 58;
            // 
            // colGNEVID
            // 
            this.colGNEVID.FieldName = "GNEVID";
            this.colGNEVID.MinWidth = 21;
            this.colGNEVID.Name = "colGNEVID";
            this.colGNEVID.Visible = true;
            this.colGNEVID.VisibleIndex = 2;
            this.colGNEVID.Width = 58;
            // 
            // colGNACIK
            // 
            this.colGNACIK.FieldName = "GNACIK";
            this.colGNACIK.MinWidth = 21;
            this.colGNACIK.Name = "colGNACIK";
            this.colGNACIK.Visible = true;
            this.colGNACIK.VisibleIndex = 3;
            this.colGNACIK.Width = 58;
            // 
            // colGNONAY
            // 
            this.colGNONAY.FieldName = "GNONAY";
            this.colGNONAY.MinWidth = 21;
            this.colGNONAY.Name = "colGNONAY";
            this.colGNONAY.Visible = true;
            this.colGNONAY.VisibleIndex = 4;
            this.colGNONAY.Width = 58;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 21;
            this.colId.Name = "colId";
            this.colId.Width = 58;
            // 
            // colSIRKID
            // 
            this.colSIRKID.FieldName = "SIRKID";
            this.colSIRKID.MinWidth = 21;
            this.colSIRKID.Name = "colSIRKID";
            this.colSIRKID.Width = 58;
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.MinWidth = 21;
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Visible = true;
            this.colACTIVE.VisibleIndex = 5;
            this.colACTIVE.Width = 58;
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.MinWidth = 21;
            this.colSLINDI.Name = "colSLINDI";
            this.colSLINDI.Width = 58;
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.MinWidth = 21;
            this.colEKKULL.Name = "colEKKULL";
            this.colEKKULL.Width = 58;
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.MinWidth = 21;
            this.colETARIH.Name = "colETARIH";
            this.colETARIH.Width = 58;
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.MinWidth = 21;
            this.colDEKULL.Name = "colDEKULL";
            this.colDEKULL.Width = 58;
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.MinWidth = 21;
            this.colDTARIH.Name = "colDTARIH";
            this.colDTARIH.Width = 58;
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.MinWidth = 21;
            this.colKYNKKD.Name = "colKYNKKD";
            this.colKYNKKD.Width = 58;
            // 
            // colCHKCTR
            // 
            this.colCHKCTR.FieldName = "CHKCTR";
            this.colCHKCTR.MinWidth = 21;
            this.colCHKCTR.Name = "colCHKCTR";
            this.colCHKCTR.Width = 87;
            // 
            // colFUNCNM
            // 
            this.colFUNCNM.FieldName = "FUNCNM";
            this.colFUNCNM.Name = "colFUNCNM";
            this.colFUNCNM.Visible = true;
            this.colFUNCNM.VisibleIndex = 6;
            this.colFUNCNM.Width = 64;
            // 
            // FrmFisTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmFisTip";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTFTIPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource sTFTIPBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSTFTNO;
        private DevExpress.XtraGrid.Columns.GridColumn colTANIMI;
        private DevExpress.XtraGrid.Columns.GridColumn colGNONAY;
        private DevExpress.XtraGrid.Columns.GridColumn colGNEVID;
        private DevExpress.XtraGrid.Columns.GridColumn colGNACIK;
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
        private DevExpress.XtraGrid.Columns.GridColumn colFUNCNM;
    }
}
