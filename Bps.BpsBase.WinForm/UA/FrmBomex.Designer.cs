
namespace BPS.Windows.Forms.UA
{
    partial class FrmBomex
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmBomex));
            this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
            this.barButBom = new DevExpress.XtraBars.BarButtonItem();
            this.barProgress = new DevExpress.XtraBars.BarEditItem();
            this.repositoryItemProgressBar1 = new DevExpress.XtraEditors.Repository.RepositoryItemProgressBar();
            this.barTamamlanan = new DevExpress.XtraBars.BarStaticItem();
            this.barDosyaAdi = new DevExpress.XtraBars.BarStaticItem();
            this.barButUrunAgac = new DevExpress.XtraBars.BarButtonItem();
            this.barButDisaAktar = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButParcaPropReset = new DevExpress.XtraBars.BarButtonItem();
            this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
            this.ribBomGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribUrunAgaciGroup = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
            this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
            this.pageUrunAgaci = new DevExpress.XtraTab.XtraTabPage();
            this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
            this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
            this.gridParcaSum = new DevExpress.XtraGrid.GridControl();
            this.gridViewParcaSum = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.treeUA = new DevExpress.XtraTreeList.TreeList();
            this.pageAssembly = new DevExpress.XtraTab.XtraTabPage();
            this.gridParca = new DevExpress.XtraGrid.GridControl();
            this.gridViewParca = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.tabMain = new DevExpress.XtraTab.XtraTabControl();
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).BeginInit();
            this.pageUrunAgaci.SuspendLayout();
            this.xtraScrollableControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
            this.groupControl2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParcaSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParcaSum)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.treeUA)).BeginInit();
            this.pageAssembly.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridParca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParca)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).BeginInit();
            this.tabMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // ribbon
            // 
            this.ribbon.ExpandCollapseItem.Id = 0;
            this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barButBom,
            this.barProgress,
            this.barTamamlanan,
            this.barDosyaAdi,
            this.barButUrunAgac,
            this.barButDisaAktar,
            this.barButtonItem1,
            this.barButParcaPropReset});
            this.ribbon.Location = new System.Drawing.Point(0, 0);
            this.ribbon.MaxItemId = 9;
            this.ribbon.Name = "ribbon";
            this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
            this.ribbon.QuickToolbarItemLinks.Add(this.barDosyaAdi);
            this.ribbon.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemProgressBar1});
            this.ribbon.ShowApplicationButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowDisplayOptionsMenuButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowExpandCollapseButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowMoreCommandsButton = DevExpress.Utils.DefaultBoolean.False;
            this.ribbon.ShowToolbarCustomizeItem = false;
            this.ribbon.Size = new System.Drawing.Size(1278, 158);
            this.ribbon.StatusBar = this.ribbonStatusBar;
            this.ribbon.Toolbar.ShowCustomizeItem = false;
            // 
            // barButBom
            // 
            this.barButBom.Caption = "Parça Listesi Al (BOM)";
            this.barButBom.Id = 1;
            this.barButBom.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButBom.ImageOptions.Image")));
            this.barButBom.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButBom.ImageOptions.LargeImage")));
            this.barButBom.ItemAppearance.Disabled.Options.UseTextOptions = true;
            this.barButBom.ItemAppearance.Disabled.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.barButBom.ItemAppearance.Hovered.Options.UseTextOptions = true;
            this.barButBom.ItemAppearance.Hovered.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.barButBom.ItemAppearance.Normal.Options.UseTextOptions = true;
            this.barButBom.ItemAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.barButBom.ItemAppearance.Pressed.Options.UseTextOptions = true;
            this.barButBom.ItemAppearance.Pressed.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.barButBom.ItemInMenuAppearance.Normal.Options.UseTextOptions = true;
            this.barButBom.ItemInMenuAppearance.Normal.TextOptions.WordWrap = DevExpress.Utils.WordWrap.NoWrap;
            this.barButBom.Name = "barButBom";
            this.barButBom.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButBom_ItemClick);
            // 
            // barProgress
            // 
            this.barProgress.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barProgress.Edit = this.repositoryItemProgressBar1;
            this.barProgress.Id = 2;
            this.barProgress.Name = "barProgress";
            // 
            // repositoryItemProgressBar1
            // 
            this.repositoryItemProgressBar1.Name = "repositoryItemProgressBar1";
            this.repositoryItemProgressBar1.Step = 1;
            // 
            // barTamamlanan
            // 
            this.barTamamlanan.Alignment = DevExpress.XtraBars.BarItemLinkAlignment.Right;
            this.barTamamlanan.Id = 3;
            this.barTamamlanan.Name = "barTamamlanan";
            // 
            // barDosyaAdi
            // 
            this.barDosyaAdi.Id = 4;
            this.barDosyaAdi.Name = "barDosyaAdi";
            // 
            // barButUrunAgac
            // 
            this.barButUrunAgac.Caption = "Ürün Ağacı Göster";
            this.barButUrunAgac.Id = 5;
            this.barButUrunAgac.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButUrunAgac.ImageOptions.Image")));
            this.barButUrunAgac.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButUrunAgac.ImageOptions.LargeImage")));
            this.barButUrunAgac.Name = "barButUrunAgac";
            this.barButUrunAgac.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButUrunAgac_ItemClick);
            // 
            // barButDisaAktar
            // 
            this.barButDisaAktar.Caption = "Dışa Aktar";
            this.barButDisaAktar.Id = 6;
            this.barButDisaAktar.Name = "barButDisaAktar";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Dışa Aktar";
            this.barButtonItem1.Id = 7;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButParcaPropReset
            // 
            this.barButParcaPropReset.Caption = "Tüm Parça Bilgilerini Temizle";
            this.barButParcaPropReset.Id = 8;
            this.barButParcaPropReset.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButParcaPropReset.ImageOptions.Image")));
            this.barButParcaPropReset.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButParcaPropReset.ImageOptions.LargeImage")));
            this.barButParcaPropReset.Name = "barButParcaPropReset";
            // 
            // ribbonPage1
            // 
            this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribBomGroup,
            this.ribUrunAgaciGroup});
            this.ribbonPage1.Name = "ribbonPage1";
            this.ribbonPage1.Text = "Montaj Dosyası İşlemleri";
            // 
            // ribBomGroup
            // 
            this.ribBomGroup.AllowTextClipping = false;
            this.ribBomGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribBomGroup.ItemLinks.Add(this.barButBom);
            this.ribBomGroup.ItemLinks.Add(this.barButParcaPropReset);
            this.ribBomGroup.Name = "ribBomGroup";
            this.ribBomGroup.Text = "BOM";
            // 
            // ribUrunAgaciGroup
            // 
            this.ribUrunAgaciGroup.AllowTextClipping = false;
            this.ribUrunAgaciGroup.CaptionButtonVisible = DevExpress.Utils.DefaultBoolean.False;
            this.ribUrunAgaciGroup.ItemLinks.Add(this.barButUrunAgac);
            this.ribUrunAgaciGroup.ItemLinks.Add(this.barButtonItem1);
            this.ribUrunAgaciGroup.Name = "ribUrunAgaciGroup";
            this.ribUrunAgaciGroup.Text = "Ürün Ağacı İşlemleri";
            // 
            // ribbonStatusBar
            // 
            this.ribbonStatusBar.ItemLinks.Add(this.barTamamlanan);
            this.ribbonStatusBar.ItemLinks.Add(this.barProgress);
            this.ribbonStatusBar.Location = new System.Drawing.Point(0, 596);
            this.ribbonStatusBar.Name = "ribbonStatusBar";
            this.ribbonStatusBar.Ribbon = this.ribbon;
            this.ribbonStatusBar.Size = new System.Drawing.Size(1278, 24);
            // 
            // pageUrunAgaci
            // 
            this.pageUrunAgaci.Controls.Add(this.xtraScrollableControl1);
            this.pageUrunAgaci.Name = "pageUrunAgaci";
            this.pageUrunAgaci.Size = new System.Drawing.Size(1276, 413);
            this.pageUrunAgaci.Text = "Ürün Ağacı";
            // 
            // xtraScrollableControl1
            // 
            this.xtraScrollableControl1.Controls.Add(this.groupControl2);
            this.xtraScrollableControl1.Controls.Add(this.groupControl1);
            this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
            this.xtraScrollableControl1.Name = "xtraScrollableControl1";
            this.xtraScrollableControl1.Size = new System.Drawing.Size(1276, 413);
            this.xtraScrollableControl1.TabIndex = 0;
            // 
            // groupControl2
            // 
            this.groupControl2.Controls.Add(this.gridParcaSum);
            this.groupControl2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupControl2.Location = new System.Drawing.Point(305, 0);
            this.groupControl2.Name = "groupControl2";
            this.groupControl2.Size = new System.Drawing.Size(971, 413);
            this.groupControl2.TabIndex = 1;
            // 
            // gridParcaSum
            // 
            this.gridParcaSum.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridParcaSum.Location = new System.Drawing.Point(2, 23);
            this.gridParcaSum.MainView = this.gridViewParcaSum;
            this.gridParcaSum.Name = "gridParcaSum";
            this.gridParcaSum.Size = new System.Drawing.Size(967, 388);
            this.gridParcaSum.TabIndex = 8;
            this.gridParcaSum.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewParcaSum,
            this.gridView1});
            // 
            // gridViewParcaSum
            // 
            this.gridViewParcaSum.GridControl = this.gridParcaSum;
            this.gridViewParcaSum.Name = "gridViewParcaSum";
            this.gridViewParcaSum.OptionsBehavior.Editable = false;
            this.gridViewParcaSum.OptionsBehavior.ReadOnly = true;
            this.gridViewParcaSum.OptionsView.ShowAutoFilterRow = true;
            this.gridViewParcaSum.OptionsView.ShowFooter = true;
            this.gridViewParcaSum.OptionsView.ShowGroupPanel = false;
            // 
            // gridView1
            // 
            this.gridView1.GridControl = this.gridParcaSum;
            this.gridView1.Name = "gridView1";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.treeUA);
            this.groupControl1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupControl1.Location = new System.Drawing.Point(0, 0);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.Size = new System.Drawing.Size(305, 413);
            this.groupControl1.TabIndex = 0;
            this.groupControl1.Text = "Ürün Ağacı";
            // 
            // treeUA
            // 
            this.treeUA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeUA.Location = new System.Drawing.Point(2, 23);
            this.treeUA.Name = "treeUA";
            this.treeUA.OptionsBehavior.Editable = false;
            this.treeUA.OptionsBehavior.PopulateServiceColumns = true;
            this.treeUA.OptionsBehavior.ReadOnly = true;
            this.treeUA.OptionsView.EnableAppearanceEvenRow = true;
            this.treeUA.OptionsView.ShowAutoFilterRow = true;
            this.treeUA.Size = new System.Drawing.Size(301, 388);
            this.treeUA.TabIndex = 9;
            // 
            // pageAssembly
            // 
            this.pageAssembly.Controls.Add(this.gridParca);
            this.pageAssembly.Name = "pageAssembly";
            this.pageAssembly.Size = new System.Drawing.Size(1276, 413);
            this.pageAssembly.Text = "Montaj";
            // 
            // gridParca
            // 
            this.gridParca.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridParca.Location = new System.Drawing.Point(0, 0);
            this.gridParca.MainView = this.gridViewParca;
            this.gridParca.MenuManager = this.ribbon;
            this.gridParca.Name = "gridParca";
            this.gridParca.Size = new System.Drawing.Size(1276, 413);
            this.gridParca.TabIndex = 0;
            this.gridParca.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridViewParca,
            this.gridView2});
            // 
            // gridViewParca
            // 
            this.gridViewParca.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3,
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7,
            this.gridColumn8,
            this.gridColumn9});
            this.gridViewParca.GridControl = this.gridParca;
            this.gridViewParca.Name = "gridViewParca";
            this.gridViewParca.OptionsView.ShowGroupPanel = false;
            this.gridViewParca.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridViewParca_CellValueChanged);
            // 
            // gridColumn1
            // 
            this.gridColumn1.Caption = "Sıra No";
            this.gridColumn1.FieldName = "Sira";
            this.gridColumn1.Name = "gridColumn1";
            this.gridColumn1.OptionsColumn.AllowEdit = false;
            this.gridColumn1.OptionsColumn.ReadOnly = true;
            this.gridColumn1.Visible = true;
            this.gridColumn1.VisibleIndex = 0;
            // 
            // gridColumn2
            // 
            this.gridColumn2.Caption = "Resim";
            this.gridColumn2.FieldName = "Thumb";
            this.gridColumn2.Name = "gridColumn2";
            this.gridColumn2.OptionsColumn.AllowEdit = false;
            this.gridColumn2.OptionsColumn.ReadOnly = true;
            this.gridColumn2.Visible = true;
            this.gridColumn2.VisibleIndex = 1;
            // 
            // gridColumn3
            // 
            this.gridColumn3.Caption = "Montaj Dosyası";
            this.gridColumn3.FieldName = "AssemblyFile";
            this.gridColumn3.Name = "gridColumn3";
            this.gridColumn3.OptionsColumn.AllowEdit = false;
            this.gridColumn3.OptionsColumn.ReadOnly = true;
            this.gridColumn3.Visible = true;
            this.gridColumn3.VisibleIndex = 2;
            // 
            // gridColumn4
            // 
            this.gridColumn4.Caption = "Parça Dosyası";
            this.gridColumn4.FieldName = "PartFile";
            this.gridColumn4.Name = "gridColumn4";
            this.gridColumn4.OptionsColumn.AllowEdit = false;
            this.gridColumn4.OptionsColumn.ReadOnly = true;
            this.gridColumn4.Visible = true;
            this.gridColumn4.VisibleIndex = 3;
            // 
            // gridColumn5
            // 
            this.gridColumn5.Caption = "Parça Kodu";
            this.gridColumn5.FieldName = "PartCode";
            this.gridColumn5.Name = "gridColumn5";
            this.gridColumn5.Visible = true;
            this.gridColumn5.VisibleIndex = 4;
            // 
            // gridColumn6
            // 
            this.gridColumn6.Caption = "Parça Adı";
            this.gridColumn6.FieldName = "PartName";
            this.gridColumn6.Name = "gridColumn6";
            this.gridColumn6.Visible = true;
            this.gridColumn6.VisibleIndex = 5;
            // 
            // gridColumn7
            // 
            this.gridColumn7.Caption = "Miktar";
            this.gridColumn7.FieldName = "Miktar";
            this.gridColumn7.Name = "gridColumn7";
            this.gridColumn7.OptionsColumn.AllowEdit = false;
            this.gridColumn7.OptionsColumn.ReadOnly = true;
            this.gridColumn7.Visible = true;
            this.gridColumn7.VisibleIndex = 6;
            // 
            // gridColumn8
            // 
            this.gridColumn8.Caption = "Rota";
            this.gridColumn8.FieldName = "Rota";
            this.gridColumn8.Name = "gridColumn8";
            this.gridColumn8.OptionsColumn.AllowEdit = false;
            this.gridColumn8.OptionsColumn.ReadOnly = true;
            this.gridColumn8.Visible = true;
            this.gridColumn8.VisibleIndex = 7;
            // 
            // gridColumn9
            // 
            this.gridColumn9.Caption = "Path";
            this.gridColumn9.FieldName = "Path";
            this.gridColumn9.Name = "gridColumn9";
            this.gridColumn9.OptionsColumn.AllowEdit = false;
            this.gridColumn9.OptionsColumn.ReadOnly = true;
            // 
            // gridView2
            // 
            this.gridView2.GridControl = this.gridParca;
            this.gridView2.Name = "gridView2";
            // 
            // tabMain
            // 
            this.tabMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabMain.Location = new System.Drawing.Point(0, 158);
            this.tabMain.Name = "tabMain";
            this.tabMain.SelectedTabPage = this.pageAssembly;
            this.tabMain.Size = new System.Drawing.Size(1278, 438);
            this.tabMain.TabIndex = 2;
            this.tabMain.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.pageAssembly,
            this.pageUrunAgaci});
            // 
            // FrmBomex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1278, 620);
            this.Controls.Add(this.tabMain);
            this.Controls.Add(this.ribbonStatusBar);
            this.Controls.Add(this.ribbon);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmBomex.IconOptions.Image")));
            this.Name = "FrmBomex";
            this.Ribbon = this.ribbon;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.StatusBar = this.ribbonStatusBar;
            this.Text = "Solidworks Ürün Ağacı";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmBomex_Load);
            ((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemProgressBar1)).EndInit();
            this.pageUrunAgaci.ResumeLayout(false);
            this.xtraScrollableControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
            this.groupControl2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridParcaSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParcaSum)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.treeUA)).EndInit();
            this.pageAssembly.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridParca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridViewParca)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tabMain)).EndInit();
            this.tabMain.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
        private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribBomGroup;
        private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
        private DevExpress.XtraBars.BarButtonItem barButBom;
        private DevExpress.XtraBars.BarEditItem barProgress;
        private DevExpress.XtraEditors.Repository.RepositoryItemProgressBar repositoryItemProgressBar1;
        private DevExpress.XtraBars.BarStaticItem barTamamlanan;
        private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribUrunAgaciGroup;
        private DevExpress.XtraBars.BarStaticItem barDosyaAdi;
        private DevExpress.XtraBars.BarButtonItem barButUrunAgac;
        private DevExpress.XtraBars.BarButtonItem barButDisaAktar;
        private DevExpress.XtraTab.XtraTabPage pageUrunAgaci;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraGrid.GridControl gridParcaSum;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewParcaSum;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraTreeList.TreeList treeUA;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraTab.XtraTabPage pageAssembly;
        private DevExpress.XtraGrid.GridControl gridParca;
        private DevExpress.XtraGrid.Views.Grid.GridView gridViewParca;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraTab.XtraTabControl tabMain;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButParcaPropReset;
    }
}