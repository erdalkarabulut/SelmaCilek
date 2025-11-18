namespace BPS.Windows.Forms
{
    partial class FrmDepoTip
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepoTip));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gNDPTPBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colURYRKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEPOKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPTIPI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDPTIPT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDGSTKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDGSTON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDGSTEK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDGSTKR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDGSTBL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDGSTBR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDCSTKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDCSTON = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDCSTTM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDCSTBL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDCSTAY = new DevExpress.XtraGrid.Columns.GridColumn();
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
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNDPTPBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.gNDPTPBindingSource;
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
            // gNDPTPBindingSource
            // 
            this.gNDPTPBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.GN.GNDPTP);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colURYRKD,
            this.colDEPOKD,
            this.colDPTIPI,
            this.colDPTIPT,
            this.colDGSTKD,
            this.colDGSTON,
            this.colDGSTEK,
            this.colDGSTKR,
            this.colDGSTBL,
            this.colDGSTBR,
            this.colDCSTKD,
            this.colDCSTON,
            this.colDCSTTM,
            this.colDCSTBL,
            this.colDCSTAY,
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
            // colURYRKD
            // 
            this.colURYRKD.FieldName = "URYRKD";
            this.colURYRKD.Name = "colURYRKD";
            this.colURYRKD.Visible = true;
            this.colURYRKD.VisibleIndex = 0;
            // 
            // colDEPOKD
            // 
            this.colDEPOKD.FieldName = "DEPOKD";
            this.colDEPOKD.Name = "colDEPOKD";
            this.colDEPOKD.Visible = true;
            this.colDEPOKD.VisibleIndex = 1;
            // 
            // colDPTIPI
            // 
            this.colDPTIPI.FieldName = "DPTIPI";
            this.colDPTIPI.Name = "colDPTIPI";
            this.colDPTIPI.Visible = true;
            this.colDPTIPI.VisibleIndex = 2;
            // 
            // colDPTIPT
            // 
            this.colDPTIPT.FieldName = "DPTIPT";
            this.colDPTIPT.Name = "colDPTIPT";
            this.colDPTIPT.Visible = true;
            this.colDPTIPT.VisibleIndex = 3;
            // 
            // colDGSTKD
            // 
            this.colDGSTKD.FieldName = "DGSTKD";
            this.colDGSTKD.Name = "colDGSTKD";
            this.colDGSTKD.Visible = true;
            this.colDGSTKD.VisibleIndex = 4;
            // 
            // colDGSTON
            // 
            this.colDGSTON.FieldName = "DGSTON";
            this.colDGSTON.Name = "colDGSTON";
            this.colDGSTON.Visible = true;
            this.colDGSTON.VisibleIndex = 5;
            // 
            // colDGSTEK
            // 
            this.colDGSTEK.FieldName = "DGSTEK";
            this.colDGSTEK.Name = "colDGSTEK";
            this.colDGSTEK.Visible = true;
            this.colDGSTEK.VisibleIndex = 6;
            // 
            // colDGSTKR
            // 
            this.colDGSTKR.FieldName = "DGSTKR";
            this.colDGSTKR.Name = "colDGSTKR";
            this.colDGSTKR.Visible = true;
            this.colDGSTKR.VisibleIndex = 7;
            // 
            // colDGSTBL
            // 
            this.colDGSTBL.FieldName = "DGSTBL";
            this.colDGSTBL.Name = "colDGSTBL";
            this.colDGSTBL.Visible = true;
            this.colDGSTBL.VisibleIndex = 8;
            // 
            // colDGSTBR
            // 
            this.colDGSTBR.FieldName = "DGSTBR";
            this.colDGSTBR.Name = "colDGSTBR";
            this.colDGSTBR.Visible = true;
            this.colDGSTBR.VisibleIndex = 9;
            // 
            // colDCSTKD
            // 
            this.colDCSTKD.FieldName = "DCSTKD";
            this.colDCSTKD.Name = "colDCSTKD";
            this.colDCSTKD.Visible = true;
            this.colDCSTKD.VisibleIndex = 10;
            // 
            // colDCSTON
            // 
            this.colDCSTON.FieldName = "DCSTON";
            this.colDCSTON.Name = "colDCSTON";
            this.colDCSTON.Visible = true;
            this.colDCSTON.VisibleIndex = 11;
            // 
            // colDCSTTM
            // 
            this.colDCSTTM.FieldName = "DCSTTM";
            this.colDCSTTM.Name = "colDCSTTM";
            this.colDCSTTM.Visible = true;
            this.colDCSTTM.VisibleIndex = 12;
            // 
            // colDCSTBL
            // 
            this.colDCSTBL.FieldName = "DCSTBL";
            this.colDCSTBL.Name = "colDCSTBL";
            this.colDCSTBL.Visible = true;
            this.colDCSTBL.VisibleIndex = 13;
            // 
            // colDCSTAY
            // 
            this.colDCSTAY.FieldName = "DCSTAY";
            this.colDCSTAY.Name = "colDCSTAY";
            this.colDCSTAY.Visible = true;
            this.colDCSTAY.VisibleIndex = 14;
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
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "barButtonItem3";
            this.barButtonItem3.Id = 27;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // FrmDepoTip
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmDepoTip.IconOptions.Image")));
            this.Name = "FrmDepoTip";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNDPTPBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource gNDPTPBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colURYRKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDEPOKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDPTIPI;
        private DevExpress.XtraGrid.Columns.GridColumn colDPTIPT;
        private DevExpress.XtraGrid.Columns.GridColumn colDGSTKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDGSTON;
        private DevExpress.XtraGrid.Columns.GridColumn colDGSTEK;
        private DevExpress.XtraGrid.Columns.GridColumn colDGSTKR;
        private DevExpress.XtraGrid.Columns.GridColumn colDGSTBL;
        private DevExpress.XtraGrid.Columns.GridColumn colDGSTBR;
        private DevExpress.XtraGrid.Columns.GridColumn colDCSTKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDCSTON;
        private DevExpress.XtraGrid.Columns.GridColumn colDCSTTM;
        private DevExpress.XtraGrid.Columns.GridColumn colDCSTBL;
        private DevExpress.XtraGrid.Columns.GridColumn colDCSTAY;
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
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}
