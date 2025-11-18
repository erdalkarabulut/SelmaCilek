namespace BPS.Windows.Forms
{
    partial class FrmAdayCari
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmAdayCari));
            this.txtCariUnvan = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEkle = new DevExpress.XtraEditors.SimpleButton();
            this.label2 = new System.Windows.Forms.Label();
            this.txtVergiDairesi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtVergiNo = new System.Windows.Forms.TextBox();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
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
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtCariUnvan
            // 
            this.txtCariUnvan.Location = new System.Drawing.Point(83, 32);
            this.txtCariUnvan.Name = "txtCariUnvan";
            this.txtCariUnvan.Size = new System.Drawing.Size(477, 21);
            this.txtCariUnvan.TabIndex = 0;
            this.txtCariUnvan.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cari Ünvan:";
            // 
            // btnEkle
            // 
            this.btnEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnEkle.ImageOptions.Image")));
            this.btnEkle.Location = new System.Drawing.Point(505, 10);
            this.btnEkle.Name = "btnEkle";
            this.btnEkle.Size = new System.Drawing.Size(55, 23);
            this.btnEkle.TabIndex = 3;
            this.btnEkle.Text = "Ekle";
            this.btnEkle.Click += new System.EventHandler(this.btnEkle_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(70, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Vergi Dairesi:";
            // 
            // txtVergiDairesi
            // 
            this.txtVergiDairesi.Location = new System.Drawing.Point(83, 59);
            this.txtVergiDairesi.Name = "txtVergiDairesi";
            this.txtVergiDairesi.Size = new System.Drawing.Size(477, 21);
            this.txtVergiDairesi.TabIndex = 1;
            this.txtVergiDairesi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(30, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Vergi No:";
            // 
            // txtVergiNo
            // 
            this.txtVergiNo.Location = new System.Drawing.Point(84, 86);
            this.txtVergiNo.Name = "txtVergiNo";
            this.txtVergiNo.Size = new System.Drawing.Size(477, 21);
            this.txtVergiNo.TabIndex = 2;
            this.txtVergiNo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.label1);
            this.groupControl1.Controls.Add(this.txtCariUnvan);
            this.groupControl1.Controls.Add(this.label3);
            this.groupControl1.Controls.Add(this.txtVergiDairesi);
            this.groupControl1.Controls.Add(this.txtVergiNo);
            this.groupControl1.Controls.Add(this.label2);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(573, 120);
            this.groupControl1.TabIndex = 7;
            this.groupControl1.Text = "Cari Bilgileri";
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.label8);
            this.groupControl2.Controls.Add(this.txtYetkiliEposta);
            this.groupControl2.Controls.Add(this.txtYetkiliCepTel);
            this.groupControl2.Controls.Add(this.label6);
            this.groupControl2.Controls.Add(this.label7);
            this.groupControl2.Controls.Add(this.txtYetkiliIsTel);
            this.groupControl2.Controls.Add(this.txtYetkiliSoyadi);
            this.groupControl2.Controls.Add(this.label5);
            this.groupControl2.Controls.Add(this.label4);
            this.groupControl2.Controls.Add(this.txtYetkiliAdi);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(0, 120);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(573, 126);
            this.groupControl2.TabIndex = 8;
            this.groupControl2.Text = "Yetkili Bilgileri";
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
            this.txtYetkiliAdi.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCariUnvan_KeyPress);
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.btnEkle);
            this.panelControl1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelControl1.Location = new System.Drawing.Point(0, 246);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(573, 43);
            this.panelControl1.TabIndex = 9;
            // 
            // FrmAdayCari
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 289);
            this.Controls.Add(this.groupControl2);
            this.Controls.Add(this.panelControl1);
            this.Controls.Add(this.groupControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FrmAdayCari";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Aday Cari Ekle";
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            this.groupControl2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtCariUnvan;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.SimpleButton btnEkle;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtVergiDairesi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtVergiNo;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private System.Windows.Forms.TextBox txtYetkiliSoyadi;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtYetkiliAdi;
        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox txtYetkiliCepTel;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtYetkiliIsTel;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtYetkiliEposta;
    }
}