
namespace BPS.Windows.Forms
{
    partial class UsrCntOrgOnay
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
            DevExpress.XtraGrid.GridFormatRule gridFormatRule2 = new DevExpress.XtraGrid.GridFormatRule();
            DevExpress.XtraEditors.FormatConditionRuleValue formatConditionRuleValue2 = new DevExpress.XtraEditors.FormatConditionRuleValue();
            this.colGNONAY = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolOnayla = new System.Windows.Forms.ToolStripMenuItem();
            this.toolOnayKaldir = new System.Windows.Forms.ToolStripMenuItem();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colSIRASI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKULKOD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colGNNAME = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGNSNAM = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit();
            this.colGNONTR = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).BeginInit();
            this.SuspendLayout();
            // 
            // colGNONAY
            // 
            this.colGNONAY.Caption = "Onay";
            this.colGNONAY.FieldName = "GNONAY";
            this.colGNONAY.MinWidth = 30;
            this.colGNONAY.Name = "colGNONAY";
            this.colGNONAY.OptionsColumn.AllowEdit = false;
            this.colGNONAY.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colGNONAY.OptionsColumn.AllowIncrementalSearch = false;
            this.colGNONAY.Visible = true;
            this.colGNONAY.VisibleIndex = 3;
            this.colGNONAY.Width = 110;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.gridControl1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(1115, 684);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Onaylama Kontrol";
            // 
            // gridControl1
            // 
            this.gridControl1.ContextMenuStrip = this.contextMenuStrip1;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 34);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemLookUpEdit1,
            this.repositoryItemLookUpEdit2});
            this.gridControl1.Size = new System.Drawing.Size(1111, 648);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolOnayla,
            this.toolOnayKaldir});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(241, 101);
            this.contextMenuStrip1.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStrip1_ItemClicked);
            // 
            // toolOnayla
            // 
            this.toolOnayla.Name = "toolOnayla";
            this.toolOnayla.Size = new System.Drawing.Size(240, 32);
            this.toolOnayla.Text = "Onayla";
            // 
            // toolOnayKaldir
            // 
            this.toolOnayKaldir.Name = "toolOnayKaldir";
            this.toolOnayKaldir.Size = new System.Drawing.Size(240, 32);
            this.toolOnayKaldir.Text = "Onay Kaldır";
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colSIRASI,
            this.colId,
            this.colKULKOD,
            this.colGNNAME,
            this.colGNSNAM,
            this.colGNONAY,
            this.colGNONTR});
            gridFormatRule2.ApplyToRow = true;
            gridFormatRule2.Column = this.colGNONAY;
            gridFormatRule2.ColumnApplyTo = this.colGNONAY;
            gridFormatRule2.Name = "Format0";
            formatConditionRuleValue2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            formatConditionRuleValue2.Appearance.Options.UseBackColor = true;
            formatConditionRuleValue2.Condition = DevExpress.XtraEditors.FormatCondition.Equal;
            formatConditionRuleValue2.Value1 = true;
            gridFormatRule2.Rule = formatConditionRuleValue2;
            this.gridView1.FormatRules.Add(gridFormatRule2);
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsNavigation.AutoMoveRowFocus = false;
            this.gridView1.OptionsScrollAnnotations.ShowFocusedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsScrollAnnotations.ShowSelectedRows = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.EnableAppearanceFocusedRow = false;
            this.gridView1.OptionsSelection.EnableAppearanceHotTrackedRow = DevExpress.Utils.DefaultBoolean.False;
            this.gridView1.OptionsSelection.UseIndicatorForSelection = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            // 
            // colSIRASI
            // 
            this.colSIRASI.Caption = "Sıra";
            this.colSIRASI.FieldName = "SIRASI";
            this.colSIRASI.MinWidth = 30;
            this.colSIRASI.Name = "colSIRASI";
            this.colSIRASI.OptionsColumn.AllowEdit = false;
            this.colSIRASI.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colSIRASI.OptionsColumn.AllowIncrementalSearch = false;
            this.colSIRASI.Visible = true;
            this.colSIRASI.VisibleIndex = 0;
            this.colSIRASI.Width = 88;
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 30;
            this.colId.Name = "colId";
            this.colId.Width = 112;
            // 
            // colKULKOD
            // 
            this.colKULKOD.Caption = "Kullanici";
            this.colKULKOD.FieldName = "KULKOD";
            this.colKULKOD.MinWidth = 30;
            this.colKULKOD.Name = "colKULKOD";
            this.colKULKOD.Width = 112;
            // 
            // colGNNAME
            // 
            this.colGNNAME.Caption = "Adı";
            this.colGNNAME.ColumnEdit = this.repositoryItemLookUpEdit1;
            this.colGNNAME.FieldName = "KULKOD";
            this.colGNNAME.MinWidth = 30;
            this.colGNNAME.Name = "colGNNAME";
            this.colGNNAME.OptionsColumn.AllowEdit = false;
            this.colGNNAME.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colGNNAME.OptionsColumn.AllowIncrementalSearch = false;
            this.colGNNAME.Visible = true;
            this.colGNNAME.VisibleIndex = 1;
            this.colGNNAME.Width = 358;
            // 
            // repositoryItemLookUpEdit1
            // 
            this.repositoryItemLookUpEdit1.AutoHeight = false;
            this.repositoryItemLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit1.DisplayMember = "GNNAME";
            this.repositoryItemLookUpEdit1.Name = "repositoryItemLookUpEdit1";
            this.repositoryItemLookUpEdit1.NullText = "";
            this.repositoryItemLookUpEdit1.ValueMember = "KULKOD";
            // 
            // colGNSNAM
            // 
            this.colGNSNAM.Caption = "Soyadı";
            this.colGNSNAM.ColumnEdit = this.repositoryItemLookUpEdit2;
            this.colGNSNAM.FieldName = "KULKOD";
            this.colGNSNAM.MinWidth = 30;
            this.colGNSNAM.Name = "colGNSNAM";
            this.colGNSNAM.OptionsColumn.AllowEdit = false;
            this.colGNSNAM.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colGNSNAM.OptionsColumn.AllowIncrementalSearch = false;
            this.colGNSNAM.Visible = true;
            this.colGNSNAM.VisibleIndex = 2;
            this.colGNSNAM.Width = 415;
            // 
            // repositoryItemLookUpEdit2
            // 
            this.repositoryItemLookUpEdit2.AutoHeight = false;
            this.repositoryItemLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemLookUpEdit2.DisplayMember = "GNSNAM";
            this.repositoryItemLookUpEdit2.Name = "repositoryItemLookUpEdit2";
            this.repositoryItemLookUpEdit2.NullText = "";
            this.repositoryItemLookUpEdit2.ValueMember = "KULKOD";
            // 
            // colGNONTR
            // 
            this.colGNONTR.Caption = "Onay Tarihi";
            this.colGNONTR.FieldName = "GNONTR";
            this.colGNONTR.MinWidth = 30;
            this.colGNONTR.Name = "colGNONTR";
            this.colGNONTR.OptionsColumn.AllowEdit = false;
            this.colGNONTR.OptionsColumn.AllowGroup = DevExpress.Utils.DefaultBoolean.False;
            this.colGNONTR.OptionsColumn.AllowIncrementalSearch = false;
            this.colGNONTR.Visible = true;
            this.colGNONTR.VisibleIndex = 4;
            this.colGNONTR.Width = 429;
            // 
            // UsrCntOrgOnay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.groupControl1);
            this.Name = "UsrCntOrgOnay";
            this.Size = new System.Drawing.Size(1115, 684);
            this.Load += new System.EventHandler(this.UsrCntOrgOnay_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemLookUpEdit2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colSIRASI;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colKULKOD;
        private DevExpress.XtraGrid.Columns.GridColumn colGNNAME;
        private DevExpress.XtraGrid.Columns.GridColumn colGNSNAM;
        private DevExpress.XtraGrid.Columns.GridColumn colGNONAY;
        private DevExpress.XtraGrid.Columns.GridColumn colGNONTR;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit1;
        private DevExpress.XtraEditors.Repository.RepositoryItemLookUpEdit repositoryItemLookUpEdit2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        public System.Windows.Forms.ToolStripMenuItem toolOnayla;
        public System.Windows.Forms.ToolStripMenuItem toolOnayKaldir;
    }
}
