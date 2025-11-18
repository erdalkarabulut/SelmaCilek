namespace BPS.Windows.Forms
{
	partial class FrmSifreDegistir
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmSifreDegistir));
			this.txtMevcutSifre = new DevExpress.XtraEditors.TextEdit();
			this.txtYeniSifre = new DevExpress.XtraEditors.TextEdit();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtYeniSifreTekrar = new DevExpress.XtraEditors.TextEdit();
			this.btnSKaydet = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.txtMevcutSifre.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// txtMevcutSifre
			// 
			this.txtMevcutSifre.Location = new System.Drawing.Point(117, 22);
			this.txtMevcutSifre.Name = "txtMevcutSifre";
			this.txtMevcutSifre.Properties.PasswordChar = '*';
			this.txtMevcutSifre.Size = new System.Drawing.Size(131, 20);
			this.txtMevcutSifre.TabIndex = 0;
			// 
			// txtYeniSifre
			// 
			this.txtYeniSifre.Location = new System.Drawing.Point(117, 58);
			this.txtYeniSifre.Name = "txtYeniSifre";
			this.txtYeniSifre.Properties.PasswordChar = '*';
			this.txtYeniSifre.Size = new System.Drawing.Size(131, 20);
			this.txtYeniSifre.TabIndex = 1;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(42, 25);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(71, 13);
			this.label1.TabIndex = 2;
			this.label1.Text = "Mevcut Şifre:";
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(57, 61);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 13);
			this.label2.TabIndex = 3;
			this.label2.Text = "Yeni Şifre:";
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(15, 97);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(98, 13);
			this.label3.TabIndex = 5;
			this.label3.Text = "Yeni Şifre (Tekrar):";
			// 
			// txtYeniSifreTekrar
			// 
			this.txtYeniSifreTekrar.Location = new System.Drawing.Point(117, 94);
			this.txtYeniSifreTekrar.Name = "txtYeniSifreTekrar";
			this.txtYeniSifreTekrar.Properties.PasswordChar = '*';
			this.txtYeniSifreTekrar.Size = new System.Drawing.Size(131, 20);
			this.txtYeniSifreTekrar.TabIndex = 4;
			// 
			// btnSKaydet
			// 
			this.btnSKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnSifreDegistir.ImageOptions.Image")));
			this.btnSKaydet.Location = new System.Drawing.Point(160, 137);
			this.btnSKaydet.Name = "btnSKaydet";
			this.btnSKaydet.Size = new System.Drawing.Size(88, 36);
			this.btnSKaydet.TabIndex = 6;
			this.btnSKaydet.Text = "Kaydet";
			this.btnSKaydet.Click += new System.EventHandler(this.btnSKaydet_Click);
			// 
			// FrmSifreDegistir
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(267, 190);
			this.Controls.Add(this.btnSKaydet);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtYeniSifreTekrar);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtYeniSifre);
			this.Controls.Add(this.txtMevcutSifre);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmSifreDegistir";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Şifre Değiştir";
			this.Load += new System.EventHandler(this.FrmSifreDegistir_Load);
			((System.ComponentModel.ISupportInitialize)(this.txtMevcutSifre.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtYeniSifre.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtYeniSifreTekrar.Properties)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraEditors.TextEdit txtMevcutSifre;
		private DevExpress.XtraEditors.TextEdit txtYeniSifre;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private DevExpress.XtraEditors.TextEdit txtYeniSifreTekrar;
		private DevExpress.XtraEditors.SimpleButton btnSKaydet;
	}
}