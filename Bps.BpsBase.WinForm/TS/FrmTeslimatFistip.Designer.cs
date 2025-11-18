namespace BPS.Windows.Forms
{
    partial class FrmTeslimatFistip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTeslimatFistip));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.tSFTIPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTSFTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTANIMI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTSHRTP = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPORKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSPDGKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNONAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNEVID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNACIK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFUNCNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDIZAYN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFTFTNO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSFTIPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.tSFTIPBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1116, 540);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.Load += new System.EventHandler(this.TemplateForm_Load);
            // 
            // tSFTIPBindingSource
            // 
            this.tSFTIPBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.TS.TSFTIP);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTSFTNO,
            this.colTANIMI,
            this.colTSHRTP,
            this.colSPORKD,
            this.colSPDGKD,
            this.colGNONAY,
            this.colGNEVID,
            this.colGNACIK,
            this.colFUNCNM,
            this.colDIZAYN,
            this.colFTFTNO,
            this.colId});
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
            // colTSFTNO
            // 
            this.colTSFTNO.FieldName = "TSFTNO";
            this.colTSFTNO.MinWidth = 25;
            this.colTSFTNO.Name = "colTSFTNO";
            this.colTSFTNO.Visible = true;
            this.colTSFTNO.VisibleIndex = 0;
            this.colTSFTNO.Width = 94;
            // 
            // colTANIMI
            // 
            this.colTANIMI.FieldName = "TANIMI";
            this.colTANIMI.MinWidth = 25;
            this.colTANIMI.Name = "colTANIMI";
            this.colTANIMI.Visible = true;
            this.colTANIMI.VisibleIndex = 1;
            this.colTANIMI.Width = 94;
            // 
            // colTSHRTP
            // 
            this.colTSHRTP.FieldName = "TSHRTP";
            this.colTSHRTP.MinWidth = 25;
            this.colTSHRTP.Name = "colTSHRTP";
            this.colTSHRTP.Visible = true;
            this.colTSHRTP.VisibleIndex = 2;
            this.colTSHRTP.Width = 94;
            // 
            // colSPORKD
            // 
            this.colSPORKD.FieldName = "SPORKD";
            this.colSPORKD.MinWidth = 25;
            this.colSPORKD.Name = "colSPORKD";
            this.colSPORKD.Visible = true;
            this.colSPORKD.VisibleIndex = 3;
            this.colSPORKD.Width = 94;
            // 
            // colSPDGKD
            // 
            this.colSPDGKD.FieldName = "SPDGKD";
            this.colSPDGKD.MinWidth = 25;
            this.colSPDGKD.Name = "colSPDGKD";
            this.colSPDGKD.Visible = true;
            this.colSPDGKD.VisibleIndex = 4;
            this.colSPDGKD.Width = 94;
            // 
            // colGNONAY
            // 
            this.colGNONAY.FieldName = "GNONAY";
            this.colGNONAY.MinWidth = 25;
            this.colGNONAY.Name = "colGNONAY";
            this.colGNONAY.Visible = true;
            this.colGNONAY.VisibleIndex = 5;
            this.colGNONAY.Width = 94;
            // 
            // colGNEVID
            // 
            this.colGNEVID.FieldName = "GNEVID";
            this.colGNEVID.MinWidth = 25;
            this.colGNEVID.Name = "colGNEVID";
            this.colGNEVID.Visible = true;
            this.colGNEVID.VisibleIndex = 6;
            this.colGNEVID.Width = 94;
            // 
            // colGNACIK
            // 
            this.colGNACIK.FieldName = "GNACIK";
            this.colGNACIK.MinWidth = 25;
            this.colGNACIK.Name = "colGNACIK";
            this.colGNACIK.Visible = true;
            this.colGNACIK.VisibleIndex = 7;
            this.colGNACIK.Width = 94;
            // 
            // colFUNCNM
            // 
            this.colFUNCNM.FieldName = "FUNCNM";
            this.colFUNCNM.MinWidth = 25;
            this.colFUNCNM.Name = "colFUNCNM";
            this.colFUNCNM.Visible = true;
            this.colFUNCNM.VisibleIndex = 8;
            this.colFUNCNM.Width = 94;
            // 
            // colDIZAYN
            // 
            this.colDIZAYN.FieldName = "DIZAYN";
            this.colDIZAYN.MinWidth = 25;
            this.colDIZAYN.Name = "colDIZAYN";
            this.colDIZAYN.Width = 94;
            // 
            // colFTFTNO
            // 
            this.colFTFTNO.FieldName = "FTFTNO";
            this.colFTFTNO.MinWidth = 25;
            this.colFTFTNO.Name = "colFTFTNO";
            this.colFTFTNO.Visible = true;
            this.colFTFTNO.VisibleIndex = 9;
            this.colFTFTNO.Width = 94;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Width = 94;
            // 
            // FrmTeslimatFistip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(1116, 570);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmTeslimatFistip.IconOptions.Image")));
            this.Name = "FrmTeslimatFistip";
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tSFTIPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource tSFTIPBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTSFTNO;
        private DevExpress.XtraGrid.Columns.GridColumn colTANIMI;
        private DevExpress.XtraGrid.Columns.GridColumn colTSHRTP;
        private DevExpress.XtraGrid.Columns.GridColumn colSPORKD;
        private DevExpress.XtraGrid.Columns.GridColumn colSPDGKD;
        private DevExpress.XtraGrid.Columns.GridColumn colGNONAY;
        private DevExpress.XtraGrid.Columns.GridColumn colGNEVID;
        private DevExpress.XtraGrid.Columns.GridColumn colGNACIK;
        private DevExpress.XtraGrid.Columns.GridColumn colFUNCNM;
        private DevExpress.XtraGrid.Columns.GridColumn colDIZAYN;
        private DevExpress.XtraGrid.Columns.GridColumn colFTFTNO;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
    }
}
