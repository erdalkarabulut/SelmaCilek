namespace BPS.Windows.Forms
{
    partial class FrmSaDegerAnahtarTanim
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
            this.sADEGABindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSADEGK = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTESACT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colTESFZT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNIHT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNIHT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNIHT3 = new DevExpress.XtraGrid.Columns.GridColumn();
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
            ((System.ComponentModel.ISupportInitialize)(this.sADEGABindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sADEGABindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Location = new System.Drawing.Point(0, 30);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(4);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(1116, 520);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sADEGABindingSource
            // 
            this.sADEGABindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.SA.SADEGA);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSADEGK,
            this.colTESACT,
            this.colTESFZT,
            this.colGNIHT1,
            this.colGNIHT2,
            this.colGNIHT3,
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
            // colSADEGK
            // 
            this.colSADEGK.FieldName = "SADEGK";
            this.colSADEGK.MinWidth = 25;
            this.colSADEGK.Name = "colSADEGK";
            this.colSADEGK.Visible = true;
            this.colSADEGK.VisibleIndex = 0;
            this.colSADEGK.Width = 94;
            // 
            // colTESACT
            // 
            this.colTESACT.FieldName = "TESACT";
            this.colTESACT.MinWidth = 25;
            this.colTESACT.Name = "colTESACT";
            this.colTESACT.Visible = true;
            this.colTESACT.VisibleIndex = 1;
            this.colTESACT.Width = 94;
            // 
            // colTESFZT
            // 
            this.colTESFZT.FieldName = "TESFZT";
            this.colTESFZT.MinWidth = 25;
            this.colTESFZT.Name = "colTESFZT";
            this.colTESFZT.Visible = true;
            this.colTESFZT.VisibleIndex = 2;
            this.colTESFZT.Width = 94;
            // 
            // colGNIHT1
            // 
            this.colGNIHT1.FieldName = "GNIHT1";
            this.colGNIHT1.MinWidth = 25;
            this.colGNIHT1.Name = "colGNIHT1";
            this.colGNIHT1.Visible = true;
            this.colGNIHT1.VisibleIndex = 3;
            this.colGNIHT1.Width = 94;
            // 
            // colGNIHT2
            // 
            this.colGNIHT2.FieldName = "GNIHT2";
            this.colGNIHT2.MinWidth = 25;
            this.colGNIHT2.Name = "colGNIHT2";
            this.colGNIHT2.Visible = true;
            this.colGNIHT2.VisibleIndex = 4;
            this.colGNIHT2.Width = 94;
            // 
            // colGNIHT3
            // 
            this.colGNIHT3.FieldName = "GNIHT3";
            this.colGNIHT3.MinWidth = 25;
            this.colGNIHT3.Name = "colGNIHT3";
            this.colGNIHT3.Visible = true;
            this.colGNIHT3.VisibleIndex = 5;
            this.colGNIHT3.Width = 94;
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
            // FrmSaDegerAnahtarTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.ClientSize = new System.Drawing.Size(1116, 570);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmSaDegerAnahtarTanim";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sADEGABindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource sADEGABindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSADEGK;
        private DevExpress.XtraGrid.Columns.GridColumn colTESACT;
        private DevExpress.XtraGrid.Columns.GridColumn colTESFZT;
        private DevExpress.XtraGrid.Columns.GridColumn colGNIHT1;
        private DevExpress.XtraGrid.Columns.GridColumn colGNIHT2;
        private DevExpress.XtraGrid.Columns.GridColumn colGNIHT3;
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
