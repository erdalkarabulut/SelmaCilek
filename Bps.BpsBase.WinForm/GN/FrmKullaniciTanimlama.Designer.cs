
namespace BPS.Windows.Forms
{
    partial class FrmKullaniciTanimlama
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmKullaniciTanimlama));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gNKULLBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colKULKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPASSWD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNSNAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNMAIL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNTELF = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLANGKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colPERSID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEFPRO = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colLGNDAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSCQUKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSCANSW = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colROLEKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNTHEM = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNKULLBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.gNKULLBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(957, 439);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.Tag = "201";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gNKULLBindingSource
            // 
            this.gNKULLBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.GN.GNKULL);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colKULKOD,
            this.colPASSWD,
            this.colGNNAME,
            this.colGNSNAM,
            this.colGNMAIL,
            this.colGNTELF,
            this.colLANGKD,
            this.colPERSID,
            this.colDEFPRO,
            this.colLGNDAT,
            this.colSCQUKD,
            this.colSCANSW,
            this.colROLEKD,
            this.colGNTHEM,
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
            this.gridView1.DetailHeight = 182;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.LevelIndent = 0;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PreviewIndent = 0;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            // 
            // colKULKOD
            // 
            this.colKULKOD.FieldName = "KULKOD";
            this.colKULKOD.Name = "colKULKOD";
            this.colKULKOD.Visible = true;
            this.colKULKOD.VisibleIndex = 0;
            // 
            // colPASSWD
            // 
            this.colPASSWD.FieldName = "PASSWD";
            this.colPASSWD.Name = "colPASSWD";
            this.colPASSWD.Visible = true;
            this.colPASSWD.VisibleIndex = 1;
            // 
            // colGNNAME
            // 
            this.colGNNAME.FieldName = "GNNAME";
            this.colGNNAME.Name = "colGNNAME";
            this.colGNNAME.Visible = true;
            this.colGNNAME.VisibleIndex = 2;
            // 
            // colGNSNAM
            // 
            this.colGNSNAM.FieldName = "GNSNAM";
            this.colGNSNAM.Name = "colGNSNAM";
            this.colGNSNAM.Visible = true;
            this.colGNSNAM.VisibleIndex = 3;
            // 
            // colGNMAIL
            // 
            this.colGNMAIL.FieldName = "GNMAIL";
            this.colGNMAIL.Name = "colGNMAIL";
            this.colGNMAIL.Visible = true;
            this.colGNMAIL.VisibleIndex = 4;
            // 
            // colGNTELF
            // 
            this.colGNTELF.Caption = "Telefon";
            this.colGNTELF.FieldName = "GNTELF";
            this.colGNTELF.Name = "colGNTELF";
            this.colGNTELF.Visible = true;
            this.colGNTELF.VisibleIndex = 5;
            // 
            // colLANGKD
            // 
            this.colLANGKD.FieldName = "LANGKD";
            this.colLANGKD.Name = "colLANGKD";
            this.colLANGKD.Visible = true;
            this.colLANGKD.VisibleIndex = 6;
            // 
            // colPERSID
            // 
            this.colPERSID.FieldName = "PERSID";
            this.colPERSID.Name = "colPERSID";
            this.colPERSID.Visible = true;
            this.colPERSID.VisibleIndex = 7;
            // 
            // colDEFPRO
            // 
            this.colDEFPRO.FieldName = "DEFPRO";
            this.colDEFPRO.Name = "colDEFPRO";
            this.colDEFPRO.Visible = true;
            this.colDEFPRO.VisibleIndex = 8;
            // 
            // colLGNDAT
            // 
            this.colLGNDAT.FieldName = "LGNDAT";
            this.colLGNDAT.Name = "colLGNDAT";
            this.colLGNDAT.Visible = true;
            this.colLGNDAT.VisibleIndex = 9;
            // 
            // colSCQUKD
            // 
            this.colSCQUKD.FieldName = "SCQUKD";
            this.colSCQUKD.Name = "colSCQUKD";
            this.colSCQUKD.Visible = true;
            this.colSCQUKD.VisibleIndex = 10;
            // 
            // colSCANSW
            // 
            this.colSCANSW.FieldName = "SCANSW";
            this.colSCANSW.Name = "colSCANSW";
            this.colSCANSW.Visible = true;
            this.colSCANSW.VisibleIndex = 11;
            // 
            // colROLEKD
            // 
            this.colROLEKD.FieldName = "ROLEKD";
            this.colROLEKD.Name = "colROLEKD";
            this.colROLEKD.Visible = true;
            this.colROLEKD.VisibleIndex = 12;
            // 
            // colGNTHEM
            // 
            this.colGNTHEM.FieldName = "GNTHEM";
            this.colGNTHEM.Name = "colGNTHEM";
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
            // FrmKullaniciTanimlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmKullaniciTanimlama.IconOptions.Image")));
            this.Name = "FrmKullaniciTanimlama";
            this.Text = "Kullanıcı Tanımlama";
            this.Load += new System.EventHandler(this.FrmKullaniciTanimlama_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNKULLBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource gNKULLBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colKULKOD;
        private DevExpress.XtraGrid.Columns.GridColumn colPASSWD;
        private DevExpress.XtraGrid.Columns.GridColumn colGNNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colGNSNAM;
        private DevExpress.XtraGrid.Columns.GridColumn colGNMAIL;
        private DevExpress.XtraGrid.Columns.GridColumn colLANGKD;
        private DevExpress.XtraGrid.Columns.GridColumn colPERSID;
        private DevExpress.XtraGrid.Columns.GridColumn colDEFPRO;
        private DevExpress.XtraGrid.Columns.GridColumn colLGNDAT;
        private DevExpress.XtraGrid.Columns.GridColumn colSCQUKD;
        private DevExpress.XtraGrid.Columns.GridColumn colSCANSW;
        private DevExpress.XtraGrid.Columns.GridColumn colROLEKD;
        private DevExpress.XtraGrid.Columns.GridColumn colGNTHEM;
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
        private DevExpress.XtraGrid.Columns.GridColumn colGNTELF;
    }
}
