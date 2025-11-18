namespace BPS.Windows.Forms
{
    partial class FrmStokSecim
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
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.sTKARTBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn94 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkedMalGrubu = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView49 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn97 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn98 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn95 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkedStokAnaGrup = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit24View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn99 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn100 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn96 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repLkedStokAltGrup = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit25View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn107 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn108 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSTMLTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.LkEdMalzTuru = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTKARTBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedMalGrubu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView49)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedStokAnaGrup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit24View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedStokAltGrup)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit25View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LkEdMalzTuru.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridControl1);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 71);
            this.groupControl2.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(843, 534);
            this.groupControl2.TabIndex = 5;
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.sTKARTBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(2, 23);
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repLkedMalGrubu,
            this.repLkedStokAnaGrup,
            this.repLkedStokAltGrup});
            this.gridControl1.Size = new System.Drawing.Size(839, 509);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // sTKARTBindingSource
            // 
            this.sTKARTBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.ST.STKART);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn19,
            this.gridColumn26,
            this.gridColumn94,
            this.gridColumn95,
            this.gridColumn96,
            this.colSTMLTR,
            this.colId6});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowAutoFilterRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.Tag = "STKART";
            // 
            // gridColumn19
            // 
            this.gridColumn19.Caption = "Stok Kodu";
            this.gridColumn19.FieldName = "STKODU";
            this.gridColumn19.Name = "gridColumn19";
            this.gridColumn19.Visible = true;
            this.gridColumn19.VisibleIndex = 0;
            // 
            // gridColumn26
            // 
            this.gridColumn26.Caption = "Stok Adı";
            this.gridColumn26.FieldName = "STKNAM";
            this.gridColumn26.Name = "gridColumn26";
            this.gridColumn26.Visible = true;
            this.gridColumn26.VisibleIndex = 1;
            // 
            // gridColumn94
            // 
            this.gridColumn94.Caption = "Mal Grubu";
            this.gridColumn94.ColumnEdit = this.repLkedMalGrubu;
            this.gridColumn94.FieldName = "MALGKD";
            this.gridColumn94.Name = "gridColumn94";
            this.gridColumn94.Visible = true;
            this.gridColumn94.VisibleIndex = 2;
            // 
            // repLkedMalGrubu
            // 
            this.repLkedMalGrubu.AutoHeight = false;
            this.repLkedMalGrubu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkedMalGrubu.DisplayMember = "TANIMI";
            this.repLkedMalGrubu.Name = "repLkedMalGrubu";
            this.repLkedMalGrubu.NullText = "";
            this.repLkedMalGrubu.PopupView = this.gridView49;
            this.repLkedMalGrubu.ValueMember = "HARKOD";
            // 
            // gridView49
            // 
            this.gridView49.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn97,
            this.gridColumn98});
            this.gridView49.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView49.Name = "gridView49";
            this.gridView49.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView49.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn97
            // 
            this.gridColumn97.Caption = "Kod";
            this.gridColumn97.FieldName = "HARKOD";
            this.gridColumn97.Name = "gridColumn97";
            this.gridColumn97.Visible = true;
            this.gridColumn97.VisibleIndex = 0;
            // 
            // gridColumn98
            // 
            this.gridColumn98.Caption = "Tanım";
            this.gridColumn98.FieldName = "TANIMI";
            this.gridColumn98.Name = "gridColumn98";
            this.gridColumn98.Visible = true;
            this.gridColumn98.VisibleIndex = 1;
            // 
            // gridColumn95
            // 
            this.gridColumn95.Caption = "Stok Ana Grup";
            this.gridColumn95.ColumnEdit = this.repLkedStokAnaGrup;
            this.gridColumn95.FieldName = "STANKD";
            this.gridColumn95.Name = "gridColumn95";
            this.gridColumn95.Visible = true;
            this.gridColumn95.VisibleIndex = 3;
            // 
            // repLkedStokAnaGrup
            // 
            this.repLkedStokAnaGrup.AutoHeight = false;
            this.repLkedStokAnaGrup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkedStokAnaGrup.DisplayMember = "TANIMI";
            this.repLkedStokAnaGrup.Name = "repLkedStokAnaGrup";
            this.repLkedStokAnaGrup.NullText = "";
            this.repLkedStokAnaGrup.PopupView = this.repositoryItemGridLookUpEdit24View;
            this.repLkedStokAnaGrup.ValueMember = "HARKOD";
            // 
            // repositoryItemGridLookUpEdit24View
            // 
            this.repositoryItemGridLookUpEdit24View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn99,
            this.gridColumn100});
            this.repositoryItemGridLookUpEdit24View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit24View.Name = "repositoryItemGridLookUpEdit24View";
            this.repositoryItemGridLookUpEdit24View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit24View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn99
            // 
            this.gridColumn99.Caption = "Kod";
            this.gridColumn99.FieldName = "HARKOD";
            this.gridColumn99.Name = "gridColumn99";
            this.gridColumn99.Visible = true;
            this.gridColumn99.VisibleIndex = 0;
            // 
            // gridColumn100
            // 
            this.gridColumn100.Caption = "Tanım";
            this.gridColumn100.FieldName = "TANIMI";
            this.gridColumn100.Name = "gridColumn100";
            this.gridColumn100.Visible = true;
            this.gridColumn100.VisibleIndex = 1;
            // 
            // gridColumn96
            // 
            this.gridColumn96.Caption = "Stok Alt Grup";
            this.gridColumn96.ColumnEdit = this.repLkedStokAltGrup;
            this.gridColumn96.FieldName = "STALKD";
            this.gridColumn96.Name = "gridColumn96";
            this.gridColumn96.Visible = true;
            this.gridColumn96.VisibleIndex = 4;
            // 
            // repLkedStokAltGrup
            // 
            this.repLkedStokAltGrup.AutoHeight = false;
            this.repLkedStokAltGrup.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repLkedStokAltGrup.DisplayMember = "TANIMI";
            this.repLkedStokAltGrup.Name = "repLkedStokAltGrup";
            this.repLkedStokAltGrup.NullText = "";
            this.repLkedStokAltGrup.PopupView = this.repositoryItemGridLookUpEdit25View;
            this.repLkedStokAltGrup.ValueMember = "HARKOD";
            // 
            // repositoryItemGridLookUpEdit25View
            // 
            this.repositoryItemGridLookUpEdit25View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn107,
            this.gridColumn108});
            this.repositoryItemGridLookUpEdit25View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit25View.Name = "repositoryItemGridLookUpEdit25View";
            this.repositoryItemGridLookUpEdit25View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit25View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn107
            // 
            this.gridColumn107.Caption = "Kod";
            this.gridColumn107.FieldName = "HARKOD";
            this.gridColumn107.Name = "gridColumn107";
            this.gridColumn107.Visible = true;
            this.gridColumn107.VisibleIndex = 0;
            // 
            // gridColumn108
            // 
            this.gridColumn108.Caption = "Tanım";
            this.gridColumn108.FieldName = "TANIMI";
            this.gridColumn108.Name = "gridColumn108";
            this.gridColumn108.Visible = true;
            this.gridColumn108.VisibleIndex = 1;
            // 
            // colSTMLTR
            // 
            this.colSTMLTR.FieldName = "STMLTR";
            this.colSTMLTR.Name = "colSTMLTR";
            // 
            // colId6
            // 
            this.colId6.FieldName = "Id";
            this.colId6.MinWidth = 21;
            this.colId6.Name = "colId6";
            this.colId6.Width = 81;
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.LkEdMalzTuru);
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(843, 71);
            this.groupControl1.TabIndex = 4;
            // 
            // LkEdMalzTuru
            // 
            this.LkEdMalzTuru.EditValue = "";
            this.LkEdMalzTuru.Location = new System.Drawing.Point(120, 33);
            this.LkEdMalzTuru.Name = "LkEdMalzTuru";
            this.LkEdMalzTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LkEdMalzTuru.Properties.DisplayMember = "STMLNM";
            this.LkEdMalzTuru.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LkEdMalzTuru.Properties.NullText = "";
            this.LkEdMalzTuru.Properties.PopupView = this.gridLookUpEdit1View;
            this.LkEdMalzTuru.Properties.ValueMember = "STMLTR";
            this.LkEdMalzTuru.Size = new System.Drawing.Size(166, 20);
            this.LkEdMalzTuru.TabIndex = 2;
            this.LkEdMalzTuru.EditValueChanged += new System.EventHandler(this.LkEdMalzTuru_EditValueChanged);
            // 
            // gridLookUpEdit1View
            // 
            this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
            this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
            this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
            this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Malzeme Türü";
            this.gridColumn1.FieldName = "STMLTR";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Malzeme Türü Tanım";
            this.gridColumn2.FieldName = "STMLNM";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Bakım Durum";
            this.gridColumn3.FieldName = "STBKDR";
            this.gridColumn3.Name = "gridColumn3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Malzeme Türü:";
            // 
            // FrmStokSecim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 605);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmStokSecim";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Stok Seçimi";
            this.Load += new System.EventHandler(this.FrmStokSecim_Load);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.sTKARTBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedMalGrubu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView49)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedStokAnaGrup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit24View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repLkedStokAltGrup)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit25View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.LkEdMalzTuru.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn94;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkedMalGrubu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView49;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn97;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn98;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn95;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkedStokAnaGrup;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit24View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn99;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn100;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn96;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repLkedStokAltGrup;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit25View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn107;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn108;
        private DevExpress.XtraGrid.Columns.GridColumn colSTMLTR;
        private DevExpress.XtraGrid.Columns.GridColumn colId6;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GridLookUpEdit LkEdMalzTuru;
        private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource sTKARTBindingSource;
    }
}