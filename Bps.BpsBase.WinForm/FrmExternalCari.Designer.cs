namespace BPS.Windows.Forms
{
    partial class FrmExternalCari
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
			this.cariExternalSourceModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colCRKODU = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCRUNV1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCRUNV2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colVERGDA = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colVERGNO = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.btnTumCarileriAl = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cariExternalSourceModelBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			this.SuspendLayout();
			// 
			// gridControl1
			// 
			this.gridControl1.DataSource = this.cariExternalSourceModelBindingSource;
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(2, 23);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(1264, 638);
			this.gridControl1.TabIndex = 1;
			this.gridControl1.Tag = "1";
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
			// 
			// cariExternalSourceModelBindingSource
			// 
			this.cariExternalSourceModelBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Models.CR.Listed.CariExternalSourceModel);
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colCRKODU,
            this.colCRUNV1,
            this.colCRUNV2,
            this.colVERGDA,
            this.colVERGNO});
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsBehavior.ReadOnly = true;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.ShowAutoFilterRow = true;
			this.gridView1.OptionsView.ShowFooter = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.RowStyle += new DevExpress.XtraGrid.Views.Grid.RowStyleEventHandler(this.gridView1_RowStyle);
			// 
			// colCRKODU
			// 
			this.colCRKODU.Caption = "Cari Kodu";
			this.colCRKODU.FieldName = "CRKODU";
			this.colCRKODU.Name = "colCRKODU";
			this.colCRKODU.Visible = true;
			this.colCRKODU.VisibleIndex = 0;
			// 
			// colCRUNV1
			// 
			this.colCRUNV1.Caption = "Cari Ünvan 1";
			this.colCRUNV1.FieldName = "CRUNV1";
			this.colCRUNV1.Name = "colCRUNV1";
			this.colCRUNV1.Visible = true;
			this.colCRUNV1.VisibleIndex = 1;
			// 
			// colCRUNV2
			// 
			this.colCRUNV2.Caption = "Cari Ünvan 2";
			this.colCRUNV2.FieldName = "CRUNV2";
			this.colCRUNV2.Name = "colCRUNV2";
			this.colCRUNV2.Visible = true;
			this.colCRUNV2.VisibleIndex = 2;
			// 
			// colVERGDA
			// 
			this.colVERGDA.Caption = "Vergi Dairesi";
			this.colVERGDA.FieldName = "VERGDA";
			this.colVERGDA.Name = "colVERGDA";
			this.colVERGDA.Visible = true;
			this.colVERGDA.VisibleIndex = 3;
			// 
			// colVERGNO
			// 
			this.colVERGNO.Caption = "Vergi No";
			this.colVERGNO.FieldName = "VERGNO";
			this.colVERGNO.Name = "colVERGNO";
			this.colVERGNO.Visible = true;
			this.colVERGNO.VisibleIndex = 4;
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(this.gridControl1);
			this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.groupControl1.Location = new System.Drawing.Point(0, 75);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(1268, 663);
			this.groupControl1.TabIndex = 2;
			this.groupControl1.Text = "Muhasebe Programı Cari Listesi";
			// 
			// groupControl2
			// 
			this.groupControl2.Controls.Add(this.btnTumCarileriAl);
			this.groupControl2.Dock = System.Windows.Forms.DockStyle.Top;
			this.groupControl2.Location = new System.Drawing.Point(0, 0);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(1268, 75);
			this.groupControl2.TabIndex = 3;
			// 
			// btnTumCarileriAl
			// 
			this.btnTumCarileriAl.Location = new System.Drawing.Point(12, 26);
			this.btnTumCarileriAl.Name = "btnTumCarileriAl";
			this.btnTumCarileriAl.Size = new System.Drawing.Size(126, 43);
			this.btnTumCarileriAl.TabIndex = 0;
			this.btnTumCarileriAl.Text = "Tüm Carileri Al";
			this.btnTumCarileriAl.Click += new System.EventHandler(this.btnTumCarileriAl_Click);
			// 
			// FrmExternalCari
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1268, 738);
			this.Controls.Add(this.groupControl1);
			this.Controls.Add(this.groupControl2);
			this.Name = "FrmExternalCari";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Cari Seçin";
			this.Load += new System.EventHandler(this.FrmExternalCari_Load);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cariExternalSourceModelBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource cariExternalSourceModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colCRKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colCRUNV1;
        private DevExpress.XtraGrid.Columns.GridColumn colCRUNV2;
        private DevExpress.XtraGrid.Columns.GridColumn colVERGDA;
        private DevExpress.XtraGrid.Columns.GridColumn colVERGNO;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.SimpleButton btnTumCarileriAl;
    }
}