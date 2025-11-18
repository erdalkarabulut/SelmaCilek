namespace BPS.Windows.Service
{
    partial class frmService
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
			DevExpress.XtraEditors.Controls.EditorButtonImageOptions editorButtonImageOptions1 = new DevExpress.XtraEditors.Controls.EditorButtonImageOptions();
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmService));
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject1 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject2 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject3 = new DevExpress.Utils.SerializableAppearanceObject();
			DevExpress.Utils.SerializableAppearanceObject serializableAppearanceObject4 = new DevExpress.Utils.SerializableAppearanceObject();
			this.button1 = new System.Windows.Forms.Button();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.pageUsers = new DevExpress.XtraTab.XtraTabPage();
			this.grdKullanici = new DevExpress.XtraGrid.GridControl();
			this.grdVwKullanici = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repButChangePassword = new DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.pageUsers.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdKullanici)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdVwKullanici)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repButChangePassword)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(389, 43);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(75, 23);
			this.button1.TabIndex = 0;
			this.button1.Text = "button1";
			this.button1.UseVisualStyleBackColor = true;
			this.button1.Visible = false;
			this.button1.Click += new System.EventHandler(this.button1_Click_1);
			// 
			// gridView1
			// 
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.Name = "gridView1";
			// 
			// gridControl1
			// 
			this.gridControl1.Location = new System.Drawing.Point(389, 72);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(137, 66);
			this.gridControl1.TabIndex = 1;
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			this.gridControl1.Visible = false;
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.pageUsers;
			this.xtraTabControl1.Size = new System.Drawing.Size(904, 481);
			this.xtraTabControl1.TabIndex = 2;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageUsers,
            this.xtraTabPage2});
			this.xtraTabControl1.Visible = false;
			// 
			// pageUsers
			// 
			this.pageUsers.Controls.Add(this.grdKullanici);
			this.pageUsers.Name = "pageUsers";
			this.pageUsers.Size = new System.Drawing.Size(902, 456);
			this.pageUsers.Text = "Kullanıcılar";
			// 
			// grdKullanici
			// 
			this.grdKullanici.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdKullanici.Location = new System.Drawing.Point(0, 0);
			this.grdKullanici.MainView = this.grdVwKullanici;
			this.grdKullanici.Name = "grdKullanici";
			this.grdKullanici.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repButChangePassword});
			this.grdKullanici.Size = new System.Drawing.Size(902, 456);
			this.grdKullanici.TabIndex = 2;
			this.grdKullanici.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdVwKullanici});
			// 
			// grdVwKullanici
			// 
			this.grdVwKullanici.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
			this.grdVwKullanici.GridControl = this.grdKullanici;
			this.grdVwKullanici.Name = "grdVwKullanici";
			this.grdVwKullanici.OptionsView.EnableAppearanceEvenRow = true;
			this.grdVwKullanici.OptionsView.ShowFooter = true;
			this.grdVwKullanici.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "DocumentId";
			this.gridColumn1.FieldName = "DocumentId";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Email";
			this.gridColumn2.FieldName = "Email";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.OptionsColumn.AllowEdit = false;
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "NameSurname";
			this.gridColumn3.FieldName = "NameSurname";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 2;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "PersId";
			this.gridColumn4.FieldName = "PersId";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Platform";
			this.gridColumn5.FieldName = "Platform";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 4;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Token";
			this.gridColumn6.FieldName = "Token";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Change Password";
			this.gridColumn7.ColumnEdit = this.repButChangePassword;
			this.gridColumn7.FieldName = "ChangePassword";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 6;
			// 
			// repButChangePassword
			// 
			this.repButChangePassword.AutoHeight = false;
			editorButtonImageOptions1.Image = ((System.Drawing.Image)(resources.GetObject("editorButtonImageOptions1.Image")));
			this.repButChangePassword.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Glyph, "", -1, true, true, false, editorButtonImageOptions1, new DevExpress.Utils.KeyShortcut(System.Windows.Forms.Keys.None), serializableAppearanceObject1, serializableAppearanceObject2, serializableAppearanceObject3, serializableAppearanceObject4, "", null, null, DevExpress.Utils.ToolTipAnchor.Default)});
			this.repButChangePassword.Name = "repButChangePassword";
			this.repButChangePassword.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.HideTextEditor;
			this.repButChangePassword.Click += new System.EventHandler(this.repButChangePassword_Click);
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.button1);
			this.xtraTabPage2.Controls.Add(this.gridControl1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(902, 456);
			this.xtraTabPage2.Text = "xtraTabPage2";
			// 
			// frmService
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(904, 481);
			this.Controls.Add(this.xtraTabControl1);
			this.Margin = new System.Windows.Forms.Padding(2);
			this.Name = "frmService";
			this.Text = "WinService";
			this.Shown += new System.EventHandler(this.frmService_Shown);
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.pageUsers.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdKullanici)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdVwKullanici)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repButChangePassword)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
		private DevExpress.XtraTab.XtraTabPage pageUsers;
		private DevExpress.XtraGrid.GridControl grdKullanici;
		private DevExpress.XtraGrid.Views.Grid.GridView grdVwKullanici;
		private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraEditors.Repository.RepositoryItemButtonEdit repButChangePassword;
	}
}

