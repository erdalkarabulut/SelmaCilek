namespace BPS.Windows.Forms
{
	partial class FrmQrCodeGenerator
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmQrCodeGenerator));
			this.memoQr = new DevExpress.XtraEditors.MemoEdit();
			this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
			this.btnQrOlustur = new DevExpress.XtraEditors.SimpleButton();
			((System.ComponentModel.ISupportInitialize)(this.memoQr.Properties)).BeginInit();
			this.SuspendLayout();
			// 
			// memoQr
			// 
			this.memoQr.Location = new System.Drawing.Point(12, 12);
			this.memoQr.Name = "memoQr";
			this.memoQr.Size = new System.Drawing.Size(415, 102);
			this.memoQr.TabIndex = 0;
			// 
			// btnKaydet
			// 
			this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
			this.btnKaydet.Location = new System.Drawing.Point(12, 123);
			this.btnKaydet.Name = "btnKaydet";
			this.btnKaydet.Size = new System.Drawing.Size(69, 32);
			this.btnKaydet.TabIndex = 1;
			this.btnKaydet.Text = "Kaydet";
			this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
			// 
			// btnQrOlustur
			// 
			this.btnQrOlustur.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnQrOlustur.ImageOptions.Image")));
			this.btnQrOlustur.Location = new System.Drawing.Point(347, 123);
			this.btnQrOlustur.Name = "btnQrOlustur";
			this.btnQrOlustur.Size = new System.Drawing.Size(80, 32);
			this.btnQrOlustur.TabIndex = 2;
			this.btnQrOlustur.Text = "QR Oluştur";
			this.btnQrOlustur.Click += new System.EventHandler(this.btnQrOlustur_Click);
			// 
			// FrmQrCodeGenerator
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(439, 167);
			this.Controls.Add(this.btnQrOlustur);
			this.Controls.Add(this.btnKaydet);
			this.Controls.Add(this.memoQr);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "FrmQrCodeGenerator";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "QR Kod Oluşturucu";
			this.Load += new System.EventHandler(this.FrmQrCodeGenerator_Load);
			((System.ComponentModel.ISupportInitialize)(this.memoQr.Properties)).EndInit();
			this.ResumeLayout(false);

		}

		#endregion

		private DevExpress.XtraEditors.MemoEdit memoQr;
		private DevExpress.XtraEditors.SimpleButton btnKaydet;
		private DevExpress.XtraEditors.SimpleButton btnQrOlustur;
	}
}