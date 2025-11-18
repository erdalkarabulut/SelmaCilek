namespace BPS.Windows.Forms
{
    partial class FrmGridXml
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmGridXml));
            this.MainPanel = new DevExpress.XtraEditors.PanelControl();
            this.InnerPanel = new DevExpress.XtraEditors.PanelControl();
            this.btnVazgec = new DevExpress.XtraEditors.SimpleButton();
            this.btnKaydet = new DevExpress.XtraEditors.SimpleButton();
            this.chkVarsayilan = new DevExpress.XtraEditors.CheckEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.txtTanim = new DevExpress.XtraEditors.TextEdit();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.MenuPanel = new DevExpress.XtraEditors.PanelControl();
            this.MovePane = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.TopPane = new DevExpress.XtraBars.Navigation.TileNavPane();
            this.CloseNavBut = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton1 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton2 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton3 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton4 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton5 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton6 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton7 = new DevExpress.XtraBars.Navigation.NavButton();
            this.navButton8 = new DevExpress.XtraBars.Navigation.NavButton();
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).BeginInit();
            this.MainPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.InnerPanel)).BeginInit();
            this.InnerPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVarsayilan.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTanim.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPanel)).BeginInit();
            this.MenuPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.MovePane)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopPane)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.MainPanel.Appearance.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.MainPanel.Appearance.BorderColor = System.Drawing.Color.Goldenrod;
            this.MainPanel.Appearance.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            this.MainPanel.Appearance.Options.UseBackColor = true;
            this.MainPanel.Appearance.Options.UseBorderColor = true;
            this.MainPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MainPanel.Controls.Add(this.InnerPanel);
            this.MainPanel.Controls.Add(this.MenuPanel);
            this.MainPanel.Location = new System.Drawing.Point(3, 2);
            this.MainPanel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.MainPanel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Size = new System.Drawing.Size(701, 445);
            this.MainPanel.TabIndex = 8;
            // 
            // InnerPanel
            // 
            this.InnerPanel.Appearance.BackColor = System.Drawing.Color.Transparent;
            this.InnerPanel.Appearance.Options.UseBackColor = true;
            this.InnerPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.Simple;
            this.InnerPanel.Controls.Add(this.btnVazgec);
            this.InnerPanel.Controls.Add(this.btnKaydet);
            this.InnerPanel.Controls.Add(this.chkVarsayilan);
            this.InnerPanel.Controls.Add(this.labelControl1);
            this.InnerPanel.Controls.Add(this.txtTanim);
            this.InnerPanel.Controls.Add(this.gridControl1);
            this.InnerPanel.Cursor = System.Windows.Forms.Cursors.Default;
            this.InnerPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.InnerPanel.Location = new System.Drawing.Point(0, 34);
            this.InnerPanel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.InnerPanel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.InnerPanel.Name = "InnerPanel";
            this.InnerPanel.Size = new System.Drawing.Size(701, 411);
            this.InnerPanel.TabIndex = 10;
            // 
            // btnVazgec
            // 
            this.btnVazgec.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnVazgec.Appearance.Options.UseFont = true;
            this.btnVazgec.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnVazgec.ImageOptions.Image")));
            this.btnVazgec.Location = new System.Drawing.Point(553, 365);
            this.btnVazgec.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnVazgec.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnVazgec.Name = "btnVazgec";
            this.btnVazgec.Size = new System.Drawing.Size(113, 41);
            this.btnVazgec.TabIndex = 5;
            this.btnVazgec.Text = "VAZGEÇ";
            this.btnVazgec.Click += new System.EventHandler(this.btnVazgec_Click);
            // 
            // btnKaydet
            // 
            this.btnKaydet.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.btnKaydet.Appearance.Options.UseFont = true;
            this.btnKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("btnKaydet.ImageOptions.Image")));
            this.btnKaydet.Location = new System.Drawing.Point(432, 365);
            this.btnKaydet.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.btnKaydet.LookAndFeel.UseDefaultLookAndFeel = false;
            this.btnKaydet.Name = "btnKaydet";
            this.btnKaydet.Size = new System.Drawing.Size(113, 41);
            this.btnKaydet.TabIndex = 4;
            this.btnKaydet.Text = "KAYDET";
            this.btnKaydet.Click += new System.EventHandler(this.btnKaydet_Click);
            // 
            // chkVarsayilan
            // 
            this.chkVarsayilan.Location = new System.Drawing.Point(69, 362);
            this.chkVarsayilan.Name = "chkVarsayilan";
            this.chkVarsayilan.Properties.Caption = "Varsayılan";
            this.chkVarsayilan.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.chkVarsayilan.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.chkVarsayilan.Size = new System.Drawing.Size(75, 19);
            this.chkVarsayilan.TabIndex = 3;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(33, 330);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(32, 13);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Tanım:";
            // 
            // txtTanim
            // 
            this.txtTanim.Location = new System.Drawing.Point(69, 324);
            this.txtTanim.Name = "txtTanim";
            this.txtTanim.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F);
            this.txtTanim.Properties.Appearance.Options.UseFont = true;
            this.txtTanim.Properties.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.txtTanim.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.txtTanim.Size = new System.Drawing.Size(597, 26);
            this.txtTanim.TabIndex = 1;
            // 
            // gridControl1
            // 
            this.gridControl1.Location = new System.Drawing.Point(31, 29);
            this.gridControl1.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.gridControl1.LookAndFeel.UseDefaultLookAndFeel = false;
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(635, 276);
            this.gridControl1.TabIndex = 0;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.DimGray;
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.Click += new System.EventHandler(this.gridView1_Click);
            this.gridView1.DoubleClick += new System.EventHandler(this.gridView1_DoubleClick);
            // 
            // MenuPanel
            // 
            this.MenuPanel.Appearance.BackColor = System.Drawing.Color.Gray;
            this.MenuPanel.Appearance.Options.UseBackColor = true;
            this.MenuPanel.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.MenuPanel.Controls.Add(this.MovePane);
            this.MenuPanel.Controls.Add(this.TopPane);
            this.MenuPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.MenuPanel.Location = new System.Drawing.Point(0, 0);
            this.MenuPanel.LookAndFeel.SkinName = "Office 2016 Colorful";
            this.MenuPanel.LookAndFeel.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Flat;
            this.MenuPanel.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MenuPanel.Name = "MenuPanel";
            this.MenuPanel.Padding = new System.Windows.Forms.Padding(2);
            this.MenuPanel.Size = new System.Drawing.Size(701, 34);
            this.MenuPanel.TabIndex = 9;
            // 
            // MovePane
            // 
            this.MovePane.BackColor = System.Drawing.Color.Transparent;
            // 
            // tileNavCategory3
            // 
            this.MovePane.DefaultCategory.Name = "tileNavCategory3";
            this.MovePane.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.MovePane.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.MovePane.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MovePane.Location = new System.Drawing.Point(2, 2);
            this.MovePane.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.MovePane.LookAndFeel.UseDefaultLookAndFeel = false;
            this.MovePane.Name = "MovePane";
            this.MovePane.Size = new System.Drawing.Size(575, 30);
            this.MovePane.TabIndex = 15;
            this.MovePane.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MovePane_MouseDown);
            this.MovePane.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MovePane_MouseMove);
            this.MovePane.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MovePane_MouseUp);
            // 
            // TopPane
            // 
            this.TopPane.BackColor = System.Drawing.Color.Transparent;
            this.TopPane.Buttons.Add(this.CloseNavBut);
            // 
            // tileNavCategory2
            // 
            this.TopPane.DefaultCategory.Name = "tileNavCategory2";
            this.TopPane.DefaultCategory.OwnerCollection = null;
            // 
            // 
            // 
            this.TopPane.DefaultCategory.Tile.DropDownOptions.BeakColor = System.Drawing.Color.Empty;
            this.TopPane.Dock = System.Windows.Forms.DockStyle.Right;
            this.TopPane.Location = new System.Drawing.Point(577, 2);
            this.TopPane.LookAndFeel.SkinName = "DevExpress Dark Style";
            this.TopPane.LookAndFeel.UseDefaultLookAndFeel = false;
            this.TopPane.Name = "TopPane";
            this.TopPane.Size = new System.Drawing.Size(122, 30);
            this.TopPane.TabIndex = 14;
            // 
            // CloseNavBut
            // 
            this.CloseNavBut.Alignment = DevExpress.XtraBars.Navigation.NavButtonAlignment.Right;
            this.CloseNavBut.Caption = null;
            this.CloseNavBut.Name = "CloseNavBut";
            this.CloseNavBut.ElementClick += new DevExpress.XtraBars.Navigation.NavElementClickEventHandler(this.CloseNavBut_ElementClick);
            // 
            // navButton1
            // 
            this.navButton1.Caption = "     ";
            this.navButton1.Enabled = false;
            this.navButton1.Name = "navButton1";
            // 
            // navButton2
            // 
            this.navButton2.Caption = "Ekle";
            this.navButton2.Glyph = ((System.Drawing.Image)(resources.GetObject("navButton2.Glyph")));
            this.navButton2.Name = "navButton2";
            // 
            // navButton3
            // 
            this.navButton3.Caption = "Değiştir";
            this.navButton3.Glyph = ((System.Drawing.Image)(resources.GetObject("navButton3.Glyph")));
            this.navButton3.Name = "navButton3";
            // 
            // navButton4
            // 
            this.navButton4.Caption = "Kaydet";
            this.navButton4.Glyph = ((System.Drawing.Image)(resources.GetObject("navButton4.Glyph")));
            this.navButton4.Name = "navButton4";
            // 
            // navButton5
            // 
            this.navButton5.Caption = "Sil";
            this.navButton5.Glyph = ((System.Drawing.Image)(resources.GetObject("navButton5.Glyph")));
            this.navButton5.Name = "navButton5";
            // 
            // navButton6
            // 
            this.navButton6.Caption = "Vazgeç";
            this.navButton6.Glyph = ((System.Drawing.Image)(resources.GetObject("navButton6.Glyph")));
            this.navButton6.Name = "navButton6";
            // 
            // navButton7
            // 
            this.navButton7.Caption = "Liste";
            this.navButton7.Glyph = ((System.Drawing.Image)(resources.GetObject("navButton7.Glyph")));
            this.navButton7.Name = "navButton7";
            // 
            // navButton8
            // 
            this.navButton8.Caption = "Baskı Önizleme";
            this.navButton8.Glyph = ((System.Drawing.Image)(resources.GetObject("navButton8.Glyph")));
            this.navButton8.Name = "navButton8";
            // 
            // FrmGridXml
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.RoyalBlue;
            this.ClientSize = new System.Drawing.Size(707, 450);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MinimumSize = new System.Drawing.Size(500, 170);
            this.Name = "FrmGridXml";
            this.Text = "FrmGridXml";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.MainPanel)).EndInit();
            this.MainPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.InnerPanel)).EndInit();
            this.InnerPanel.ResumeLayout(false);
            this.InnerPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chkVarsayilan.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtTanim.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.MenuPanel)).EndInit();
            this.MenuPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.MovePane)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TopPane)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private DevExpress.XtraEditors.PanelControl MainPanel;
        private DevExpress.XtraEditors.PanelControl InnerPanel;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraEditors.PanelControl MenuPanel;
        private DevExpress.XtraBars.Navigation.NavButton navButton1;
        private DevExpress.XtraBars.Navigation.NavButton navButton2;
        private DevExpress.XtraBars.Navigation.NavButton navButton3;
        private DevExpress.XtraBars.Navigation.NavButton navButton4;
        private DevExpress.XtraBars.Navigation.NavButton navButton5;
        private DevExpress.XtraBars.Navigation.NavButton navButton6;
        private DevExpress.XtraBars.Navigation.NavButton navButton7;
        private DevExpress.XtraBars.Navigation.NavButton navButton8;
        private DevExpress.XtraBars.Navigation.TileNavPane TopPane;
        private DevExpress.XtraBars.Navigation.NavButton CloseNavBut;
        private DevExpress.XtraBars.Navigation.TileNavPane MovePane;
        private DevExpress.XtraEditors.SimpleButton btnVazgec;
        private DevExpress.XtraEditors.SimpleButton btnKaydet;
        private DevExpress.XtraEditors.CheckEdit chkVarsayilan;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit txtTanim;
    }
}