namespace BPS.Windows.Forms
{
	partial class FrmServisKullanici
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServisKullanici));
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			this.SuspendLayout();
			// 
			// gridControl1
			// 
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 24);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.Size = new System.Drawing.Size(957, 439);
			this.gridControl1.TabIndex = 5;
			this.gridControl1.Tag = "201";
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			// 
			// gridView1
			// 
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn10,
            this.gridColumn1,
            this.gridColumn5,
            this.gridColumn4,
            this.gridColumn3,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn9,
            this.gridColumn2,
            this.gridColumn8});
			this.gridView1.DetailHeight = 182;
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.LevelIndent = 0;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.PreviewIndent = 0;
			this.gridView1.CellValueChanging += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanging);
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Admin";
			this.gridColumn10.FieldName = "Admin";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 0;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Cloud Id";
			this.gridColumn1.FieldName = "DocumentId";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.OptionsColumn.AllowEdit = false;
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 1;
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Personel Id";
			this.gridColumn5.FieldName = "PersId";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.OptionsColumn.AllowEdit = false;
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 2;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Ad Soyad";
			this.gridColumn4.FieldName = "NameSurname";
			this.gridColumn4.Name = "gridColumn4";
			this.gridColumn4.OptionsColumn.AllowEdit = false;
			this.gridColumn4.Visible = true;
			this.gridColumn4.VisibleIndex = 3;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "E-mail";
			this.gridColumn3.FieldName = "Email";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.OptionsColumn.AllowEdit = false;
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 4;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Platform";
			this.gridColumn6.FieldName = "Platform";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.OptionsColumn.AllowEdit = false;
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 5;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Profil Fotoğrafı";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.OptionsColumn.AllowEdit = false;
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 6;
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Token";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.OptionsColumn.AllowEdit = false;
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 7;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Diğer İşemirleri Yetki";
			this.gridColumn2.FieldName = "DigerIsemirleriYetki";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 8;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Tamamlananlar Yetki";
			this.gridColumn8.FieldName = "TamamlananlarYetki";
			this.gridColumn8.Name = "gridColumn8";
			this.gridColumn8.Visible = true;
			this.gridColumn8.VisibleIndex = 9;
			// 
			// FrmServisKullanici
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(957, 463);
			this.Controls.Add(this.gridControl1);
			this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmServisKullanici.IconOptions.Image")));
			this.Name = "FrmServisKullanici";
			this.Load += new System.EventHandler(this.FrmServisKullanici_Load);
			this.Controls.SetChildIndex(this.gridControl1, 0);
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraGrid.GridControl gridControl1;
		private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
	}
}
