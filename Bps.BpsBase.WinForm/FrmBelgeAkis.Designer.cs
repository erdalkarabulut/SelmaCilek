namespace BPS.Windows.Forms
{
    partial class FrmBelgeAkis
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
            this.belgeAkisModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colNew = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colOld = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUserKod = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDate = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNSNAM = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.belgeAkisModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.belgeAkisModelBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(939, 505);
            this.gridControl1.TabIndex = 6;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // belgeAkisModelBindingSource
            // 
            this.belgeAkisModelBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Models.GN.Listed.BelgeAkisModel);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colNew,
            this.colOld,
            this.colUserKod,
            this.colDate,
            this.colGNNAME,
            this.colGNSNAM});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colNew
            // 
            this.colNew.FieldName = "New";
            this.colNew.MinWidth = 19;
            this.colNew.Name = "colNew";
            this.colNew.Visible = true;
            this.colNew.VisibleIndex = 5;
            this.colNew.Width = 204;
            // 
            // colOld
            // 
            this.colOld.FieldName = "Old";
            this.colOld.MinWidth = 19;
            this.colOld.Name = "colOld";
            this.colOld.Visible = true;
            this.colOld.VisibleIndex = 4;
            this.colOld.Width = 198;
            // 
            // colUserKod
            // 
            this.colUserKod.FieldName = "UserKod";
            this.colUserKod.MinWidth = 19;
            this.colUserKod.Name = "colUserKod";
            this.colUserKod.Visible = true;
            this.colUserKod.VisibleIndex = 0;
            this.colUserKod.Width = 80;
            // 
            // colDate
            // 
            this.colDate.FieldName = "Date";
            this.colDate.MinWidth = 19;
            this.colDate.Name = "colDate";
            this.colDate.Visible = true;
            this.colDate.VisibleIndex = 3;
            this.colDate.Width = 100;
            // 
            // colGNNAME
            // 
            this.colGNNAME.FieldName = "GNNAME";
            this.colGNNAME.MinWidth = 19;
            this.colGNNAME.Name = "colGNNAME";
            this.colGNNAME.Visible = true;
            this.colGNNAME.VisibleIndex = 1;
            this.colGNNAME.Width = 166;
            // 
            // colGNSNAM
            // 
            this.colGNSNAM.FieldName = "GNSNAM";
            this.colGNSNAM.MinWidth = 19;
            this.colGNSNAM.Name = "colGNSNAM";
            this.colGNSNAM.Visible = true;
            this.colGNSNAM.VisibleIndex = 2;
            this.colGNSNAM.Width = 166;
            // 
            // FrmBelgeAkis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(939, 505);
            this.Controls.Add(this.gridControl1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FrmBelgeAkis";
            this.Text = "FrmBelgeAkis";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.belgeAkisModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource belgeAkisModelBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colNew;
        private DevExpress.XtraGrid.Columns.GridColumn colOld;
        private DevExpress.XtraGrid.Columns.GridColumn colUserKod;
        private DevExpress.XtraGrid.Columns.GridColumn colDate;
        private DevExpress.XtraGrid.Columns.GridColumn colGNNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colGNSNAM;
    }
}