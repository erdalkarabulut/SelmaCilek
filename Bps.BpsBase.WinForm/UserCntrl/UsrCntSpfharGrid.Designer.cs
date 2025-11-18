
namespace BPS.Windows.Forms
{
    partial class UsrCntSpfharGrid
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sPFHARBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSATIRN = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTKODU = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTKNAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGFIYAT = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNMKTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNTUTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGISKNT = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPFHARBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(812, 502);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "groupControl1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sPFHARBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.TextLocation = DevExpress.XtraEditors.NavigatorButtonsTextLocation.None;
            this.gridControl1.Location = new System.Drawing.Point(2, 2);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(808, 498);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.UseEmbeddedNavigator = true;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // sPFHARBindingSource
            // 
            this.sPFHARBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.SP.SPFHAR);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSATIRN,
            this.colSTKODU,
            this.colSTKNAM,
            this.colGFIYAT,
            this.colGNMKTR,
            this.colGNTUTR,
            this.colGISKNT});
            this.gridView1.FooterPanelHeight = 80;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.GroupSummary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridGroupSummaryItem(DevExpress.Data.SummaryItemType.Sum, "VRGSIZ", null, "")});
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsView.ShowFooter = true;
            // 
            // colSATIRN
            // 
            this.colSATIRN.FieldName = "SATIRN";
            this.colSATIRN.Name = "colSATIRN";
            this.colSATIRN.Visible = true;
            this.colSATIRN.VisibleIndex = 0;
            // 
            // colSTKODU
            // 
            this.colSTKODU.FieldName = "STKODU";
            this.colSTKODU.Name = "colSTKODU";
            this.colSTKODU.Visible = true;
            this.colSTKODU.VisibleIndex = 1;
            // 
            // colSTKNAM
            // 
            this.colSTKNAM.FieldName = "STKNAM";
            this.colSTKNAM.Name = "colSTKNAM";
            this.colSTKNAM.Visible = true;
            this.colSTKNAM.VisibleIndex = 2;
            // 
            // colGFIYAT
            // 
            this.colGFIYAT.FieldName = "GFIYAT";
            this.colGFIYAT.Name = "colGFIYAT";
            this.colGFIYAT.Visible = true;
            this.colGFIYAT.VisibleIndex = 4;
            // 
            // colGNMKTR
            // 
            this.colGNMKTR.FieldName = "GNMKTR";
            this.colGNMKTR.Name = "colGNMKTR";
            this.colGNMKTR.Visible = true;
            this.colGNMKTR.VisibleIndex = 3;
            // 
            // colGNTUTR
            // 
            this.colGNTUTR.FieldName = "GNTUTR";
            this.colGNTUTR.Name = "colGNTUTR";
            this.colGNTUTR.Visible = true;
            this.colGNTUTR.VisibleIndex = 5;
            // 
            // colGISKNT
            // 
            this.colGISKNT.FieldName = "GISKNT";
            this.colGISKNT.Name = "colGISKNT";
            this.colGISKNT.Visible = true;
            this.colGISKNT.VisibleIndex = 6;
            // 
            // UsrCntSpfharGrid
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "UsrCntSpfharGrid";
            this.Size = new System.Drawing.Size(812, 502);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sPFHARBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource sPFHARBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colSATIRN;
        private DevExpress.XtraGrid.Columns.GridColumn colSTKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colSTKNAM;
        private DevExpress.XtraGrid.Columns.GridColumn colGFIYAT;
        private DevExpress.XtraGrid.Columns.GridColumn colGNMKTR;
        private DevExpress.XtraGrid.Columns.GridColumn colGNTUTR;
        private DevExpress.XtraGrid.Columns.GridColumn colGISKNT;
    }
}
