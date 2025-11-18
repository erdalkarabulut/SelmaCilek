namespace BPS.Windows.Forms
{
    partial class FrmTedarikTuruTanim
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
            this.sTTDTRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colTEDKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colURYRKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTEDTNM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYAPAYK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colFASONK = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.sTTDTRBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sTTDTRBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Location = new System.Drawing.Point(0, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1116, 520);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sTTDTRBindingSource
            // 
            this.sTTDTRBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.ST.STTDTR);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colTEDKOD,
            this.colURYRKD,
            this.colTEDTNM,
            this.colYAPAYK,
            this.colFASONK,
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
            // colTEDKOD
            // 
            this.colTEDKOD.FieldName = "TEDKOD";
            this.colTEDKOD.MinWidth = 25;
            this.colTEDKOD.Name = "colTEDKOD";
            this.colTEDKOD.Visible = true;
            this.colTEDKOD.VisibleIndex = 0;
            this.colTEDKOD.Width = 87;
            // 
            // colURYRKD
            // 
            this.colURYRKD.FieldName = "URYRKD";
            this.colURYRKD.MinWidth = 25;
            this.colURYRKD.Name = "colURYRKD";
            this.colURYRKD.Visible = true;
            this.colURYRKD.VisibleIndex = 1;
            this.colURYRKD.Width = 87;
            // 
            // colTEDTNM
            // 
            this.colTEDTNM.FieldName = "TEDTNM";
            this.colTEDTNM.MinWidth = 25;
            this.colTEDTNM.Name = "colTEDTNM";
            this.colTEDTNM.Visible = true;
            this.colTEDTNM.VisibleIndex = 2;
            this.colTEDTNM.Width = 87;
            // 
            // colYAPAYK
            // 
            this.colYAPAYK.FieldName = "YAPAYK";
            this.colYAPAYK.MinWidth = 25;
            this.colYAPAYK.Name = "colYAPAYK";
            this.colYAPAYK.Visible = true;
            this.colYAPAYK.VisibleIndex = 3;
            this.colYAPAYK.Width = 87;
            // 
            // colFASONK
            // 
            this.colFASONK.FieldName = "FASONK";
            this.colFASONK.MinWidth = 25;
            this.colFASONK.Name = "colFASONK";
            this.colFASONK.Visible = true;
            this.colFASONK.VisibleIndex = 4;
            this.colFASONK.Width = 87;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 25;
            this.colId.Name = "colId";
            this.colId.Width = 87;
            // 
            // colSIRKID
            // 
            this.colSIRKID.FieldName = "SIRKID";
            this.colSIRKID.MinWidth = 25;
            this.colSIRKID.Name = "colSIRKID";
            this.colSIRKID.Width = 87;
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.MinWidth = 25;
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Width = 87;
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.MinWidth = 25;
            this.colSLINDI.Name = "colSLINDI";
            this.colSLINDI.Width = 87;
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.MinWidth = 25;
            this.colEKKULL.Name = "colEKKULL";
            this.colEKKULL.Width = 87;
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.MinWidth = 25;
            this.colETARIH.Name = "colETARIH";
            this.colETARIH.Width = 87;
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.MinWidth = 25;
            this.colDEKULL.Name = "colDEKULL";
            this.colDEKULL.Width = 87;
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.MinWidth = 25;
            this.colDTARIH.Name = "colDTARIH";
            this.colDTARIH.Width = 87;
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.MinWidth = 25;
            this.colKYNKKD.Name = "colKYNKKD";
            this.colKYNKKD.Width = 87;
            // 
            // colCHKCTR
            // 
            this.colCHKCTR.FieldName = "CHKCTR";
            this.colCHKCTR.MinWidth = 25;
            this.colCHKCTR.Name = "colCHKCTR";
            this.colCHKCTR.Width = 87;
            // 
            // FrmTedarikTuruTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(1116, 570);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 5, 3, 5);
            this.Name = "FrmTedarikTuruTanim";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTTDTRBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource sTTDTRBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colTEDKOD;
        private DevExpress.XtraGrid.Columns.GridColumn colURYRKD;
        private DevExpress.XtraGrid.Columns.GridColumn colTEDTNM;
        private DevExpress.XtraGrid.Columns.GridColumn colYAPAYK;
        private DevExpress.XtraGrid.Columns.GridColumn colFASONK;
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
