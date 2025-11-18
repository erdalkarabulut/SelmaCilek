namespace BPS.Windows.Forms
{
    partial class FrmHizliCariGiris
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHizliCariGiris));
			this.txtCariUnvan = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
			this.label2 = new System.Windows.Forms.Label();
			this.txtVergiDairesi = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtVergiNo = new System.Windows.Forms.TextBox();
			this.grpCari = new DevExpress.XtraEditors.GroupControl();
			this.LkEdCariTuru = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.label10 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.txtCariKod = new System.Windows.Forms.TextBox();
			this.grpYetkili = new DevExpress.XtraEditors.GroupControl();
			this.label8 = new System.Windows.Forms.Label();
			this.txtYetkiliEposta = new System.Windows.Forms.TextBox();
			this.txtYetkiliCepTel = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtYetkiliIsTel = new System.Windows.Forms.TextBox();
			this.txtYetkiliSoyadi = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.txtYetkiliAdi = new System.Windows.Forms.TextBox();
			this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
			((System.ComponentModel.ISupportInitialize)(this.grpCari)).BeginInit();
			this.grpCari.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.LkEdCariTuru.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grpYetkili)).BeginInit();
			this.grpYetkili.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
			this.panelControl1.SuspendLayout();
			this.SuspendLayout();
			// 
			// txtCariUnvan
			// 
			this.txtCariUnvan.Location = new System.Drawing.Point(83, 60);
			this.txtCariUnvan.Name = "txtCariUnvan";
			this.txtCariUnvan.Size = new System.Drawing.Size(477, 21);
			this.txtCariUnvan.TabIndex = 1;
			this.txtCariUnvan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(16, 64);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 13);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cari Ünvan:";
			// 
			// btnEkle
			// 
			this.btnEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEkle.ImageOptions.Image")));
			this.btnEkle.Location = new System.Drawing.Point(492, 9);
			this.btnEkle.Name = "btnEkle";
			this.btnEkle.Size = new System.Drawing.Size(68, 23);
			this.btnEkle.TabIndex = 3;
			this.btnEkle.Text = "Kaydet";
			this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(10, 91);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(70, 13);
			this.label2.TabIndex = 4;
			this.label2.Text = "Vergi Dairesi:";
			// 
			// txtVergiDairesi
			// 
			this.txtVergiDairesi.Location = new System.Drawing.Point(83, 87);
			this.txtVergiDairesi.Name = "txtVergiDairesi";
			this.txtVergiDairesi.Size = new System.Drawing.Size(477, 21);
			this.txtVergiDairesi.TabIndex = 2;
			this.txtVergiDairesi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(29, 118);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(51, 13);
			this.label3.TabIndex = 6;
			this.label3.Text = "Vergi No:";
			// 
			// txtVergiNo
			// 
			this.txtVergiNo.Location = new System.Drawing.Point(83, 114);
			this.txtVergiNo.Name = "txtVergiNo";
			this.txtVergiNo.Size = new System.Drawing.Size(477, 21);
			this.txtVergiNo.TabIndex = 3;
			this.txtVergiNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
			// 
			// grpCari
			// 
			this.grpCari.Controls.Add(this.LkEdCariTuru);
			this.grpCari.Controls.Add(this.label10);
			this.grpCari.Controls.Add(this.label9);
			this.grpCari.Controls.Add(this.txtCariKod);
			this.grpCari.Controls.Add(this.label1);
			this.grpCari.Controls.Add(this.txtCariUnvan);
			this.grpCari.Controls.Add(this.label3);
			this.grpCari.Controls.Add(this.txtVergiDairesi);
			this.grpCari.Controls.Add(this.txtVergiNo);
			this.grpCari.Controls.Add(this.label2);
			this.grpCari.Dock = System.Windows.Forms.DockStyle.Top;
			this.grpCari.Location = new System.Drawing.Point(0, 0);
			this.grpCari.Name = "grpCari";
			this.grpCari.Size = new System.Drawing.Size(573, 151);
			this.grpCari.TabIndex = 7;
			this.grpCari.Text = "Cari Bilgileri";
			// 
			// LkEdCariTuru
			// 
			this.LkEdCariTuru.EditValue = "";
			this.LkEdCariTuru.Location = new System.Drawing.Point(394, 33);
			this.LkEdCariTuru.Name = "LkEdCariTuru";
			this.LkEdCariTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.LkEdCariTuru.Properties.DisplayMember = "TANIMI";
			this.LkEdCariTuru.Properties.NullText = "";
			this.LkEdCariTuru.Properties.PopupView = this.gridLookUpEdit1View;
			this.LkEdCariTuru.Properties.ValueMember = "HARKOD";
			this.LkEdCariTuru.Size = new System.Drawing.Size(166, 20);
			this.LkEdCariTuru.TabIndex = 10;
			// 
			// gridLookUpEdit1View
			// 
			this.gridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2});
			this.gridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridLookUpEdit1View.Name = "gridLookUpEdit1View";
			this.gridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridLookUpEdit1View.OptionsView.ShowAutoFilterRow = true;
			this.gridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Cari Türü";
			this.gridColumn1.FieldName = "HARKOD";
			this.gridColumn1.Name = "gridColumn1";
			this.gridColumn1.Visible = true;
			this.gridColumn1.VisibleIndex = 0;
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Tanım";
			this.gridColumn2.FieldName = "TANIMI";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 1;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(333, 36);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(55, 13);
			this.label10.TabIndex = 9;
			this.label10.Text = "Cari Türü:";
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(16, 37);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(57, 13);
			this.label9.TabIndex = 8;
			this.label9.Text = "Cari Kodu:";
			// 
			// txtCariKod
			// 
			this.txtCariKod.Location = new System.Drawing.Point(83, 33);
			this.txtCariKod.Name = "txtCariKod";
			this.txtCariKod.Size = new System.Drawing.Size(190, 21);
			this.txtCariKod.TabIndex = 0;
			// 
			// grpYetkili
			// 
			this.grpYetkili.Controls.Add(this.label8);
			this.grpYetkili.Controls.Add(this.txtYetkiliEposta);
			this.grpYetkili.Controls.Add(this.txtYetkiliCepTel);
			this.grpYetkili.Controls.Add(this.label6);
			this.grpYetkili.Controls.Add(this.label7);
			this.grpYetkili.Controls.Add(this.txtYetkiliIsTel);
			this.grpYetkili.Controls.Add(this.txtYetkiliSoyadi);
			this.grpYetkili.Controls.Add(this.label5);
			this.grpYetkili.Controls.Add(this.label4);
			this.grpYetkili.Controls.Add(this.txtYetkiliAdi);
			this.grpYetkili.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grpYetkili.Location = new System.Drawing.Point(0, 151);
			this.grpYetkili.Name = "grpYetkili";
			this.grpYetkili.Size = new System.Drawing.Size(573, 129);
			this.grpYetkili.TabIndex = 8;
			this.grpYetkili.Text = "Yetkili Bilgileri";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(32, 95);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(48, 13);
			this.label8.TabIndex = 12;
			this.label8.Text = "E-posta:";
			// 
			// txtYetkiliEposta
			// 
			this.txtYetkiliEposta.Location = new System.Drawing.Point(83, 91);
			this.txtYetkiliEposta.Name = "txtYetkiliEposta";
			this.txtYetkiliEposta.Size = new System.Drawing.Size(190, 21);
			this.txtYetkiliEposta.TabIndex = 11;
			this.txtYetkiliEposta.Text = ".@.";
			// 
			// txtYetkiliCepTel
			// 
			this.txtYetkiliCepTel.Location = new System.Drawing.Point(370, 64);
			this.txtYetkiliCepTel.Name = "txtYetkiliCepTel";
			this.txtYetkiliCepTel.Size = new System.Drawing.Size(190, 21);
			this.txtYetkiliCepTel.TabIndex = 10;
			this.txtYetkiliCepTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(320, 68);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(47, 13);
			this.label6.TabIndex = 9;
			this.label6.Text = "Cep Tel:";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(43, 68);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(37, 13);
			this.label7.TabIndex = 8;
			this.label7.Text = "İş Tel:";
			// 
			// txtYetkiliIsTel
			// 
			this.txtYetkiliIsTel.Location = new System.Drawing.Point(83, 64);
			this.txtYetkiliIsTel.Name = "txtYetkiliIsTel";
			this.txtYetkiliIsTel.Size = new System.Drawing.Size(190, 21);
			this.txtYetkiliIsTel.TabIndex = 7;
			this.txtYetkiliIsTel.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
			// 
			// txtYetkiliSoyadi
			// 
			this.txtYetkiliSoyadi.Location = new System.Drawing.Point(370, 37);
			this.txtYetkiliSoyadi.Name = "txtYetkiliSoyadi";
			this.txtYetkiliSoyadi.Size = new System.Drawing.Size(190, 21);
			this.txtYetkiliSoyadi.TabIndex = 6;
			this.txtYetkiliSoyadi.Text = ".";
			this.txtYetkiliSoyadi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(294, 41);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(73, 13);
			this.label5.TabIndex = 5;
			this.label5.Text = "Yetkili Soyadı:";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(24, 41);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 13);
			this.label4.TabIndex = 3;
			this.label4.Text = "Yetkili Adı:";
			// 
			// txtYetkiliAdi
			// 
			this.txtYetkiliAdi.Location = new System.Drawing.Point(83, 37);
			this.txtYetkiliAdi.Name = "txtYetkiliAdi";
			this.txtYetkiliAdi.Size = new System.Drawing.Size(190, 21);
			this.txtYetkiliAdi.TabIndex = 2;
			this.txtYetkiliAdi.Text = ".";
			this.txtYetkiliAdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
			// 
			// panelControl1
			// 
			this.panelControl1.Controls.Add(this.btnEkle);
			this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
			this.panelControl1.Location = new System.Drawing.Point(0, 280);
			this.panelControl1.Name = "panelControl1";
			this.panelControl1.Size = new System.Drawing.Size(573, 42);
			this.panelControl1.TabIndex = 9;
			// 
			// FrmHizliCariGiris
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(573, 322);
			this.Controls.Add(this.grpYetkili);
			this.Controls.Add(this.panelControl1);
			this.Controls.Add(this.grpCari);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmHizliCariGiris";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Hızlı Cari Girişi";
			this.Load += new System.EventHandler(this.FrmHizliCariGiris_Load);
			((System.ComponentModel.ISupportInitialize)(this.grpCari)).EndInit();
			this.grpCari.ResumeLayout(false);
			this.grpCari.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.LkEdCariTuru.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grpYetkili)).EndInit();
			this.grpYetkili.ResumeLayout(false);
			this.grpYetkili.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
			this.panelControl1.ResumeLayout(false);
			this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private DevExpress.XtraEditors.GroupControl grpCari;
        private DevExpress.XtraEditors.GroupControl grpYetkili;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox txtCariKod;
        public System.Windows.Forms.TextBox txtCariUnvan;
        public System.Windows.Forms.TextBox txtVergiDairesi;
        public System.Windows.Forms.TextBox txtVergiNo;
        public System.Windows.Forms.TextBox txtYetkiliSoyadi;
        public System.Windows.Forms.TextBox txtYetkiliAdi;
        public System.Windows.Forms.TextBox txtYetkiliCepTel;
        public System.Windows.Forms.TextBox txtYetkiliIsTel;
        public System.Windows.Forms.TextBox txtYetkiliEposta;
		private DevExpress.XtraGrid.Views.Grid.GridView gridLookUpEdit1View;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
		private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
		private System.Windows.Forms.Label label10;
		public DevExpress.XtraEditors.GridLookUpEdit LkEdCariTuru;
	}
}