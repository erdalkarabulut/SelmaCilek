namespace BPS.Windows.Forms
{
    partial class FrmFileManager
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmFileManager));
            this.barManager1 = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bar3 = new DevExpress.XtraBars.Bar();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            this.gridControl = new DevExpress.XtraGrid.GridControl();
            this.winExplorerView = new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView();
            this.columnName = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnPath = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnCheck = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnGroup = new DevExpress.XtraGrid.Columns.GridColumn();
            this.columnImage = new DevExpress.XtraGrid.Columns.GridColumn();
            this.itemPopupMenu = new DevExpress.XtraBars.PopupMenu(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPopupMenu)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager1
            // 
            this.barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1,
            this.bar3});
            this.barManager1.DockControls.Add(this.barDockControlTop);
            this.barManager1.DockControls.Add(this.barDockControlBottom);
            this.barManager1.DockControls.Add(this.barDockControlLeft);
            this.barManager1.DockControls.Add(this.barDockControlRight);
            this.barManager1.Form = this;
            this.barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barButtonItem1,
            this.barButtonItem2,
            this.barButtonItem3});
            this.barManager1.MaxItemId = 3;
            this.barManager1.StatusBar = this.bar3;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem1),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButtonItem2)});
            this.bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "Ekle";
            this.barButtonItem1.Id = 0;
            this.barButtonItem1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.Image")));
            this.barButtonItem1.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem1.ImageOptions.LargeImage")));
            this.barButtonItem1.Name = "barButtonItem1";
            this.barButtonItem1.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem1_ItemClick);
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "Sil";
            this.barButtonItem2.Id = 1;
            this.barButtonItem2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.Image")));
            this.barButtonItem2.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButtonItem2.ImageOptions.LargeImage")));
            this.barButtonItem2.Name = "barButtonItem2";
            this.barButtonItem2.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButtonItem2_ItemClick);
            // 
            // bar3
            // 
            this.bar3.BarName = "Status bar";
            this.bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            this.bar3.DockCol = 0;
            this.bar3.DockRow = 0;
            this.bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            this.bar3.OptionsBar.AllowQuickCustomization = false;
            this.bar3.OptionsBar.DrawDragBorder = false;
            this.bar3.OptionsBar.UseWholeRow = true;
            this.bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager1;
            this.barDockControlTop.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlTop.Size = new System.Drawing.Size(1017, 30);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 635);
            this.barDockControlBottom.Manager = this.barManager1;
            this.barDockControlBottom.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlBottom.Size = new System.Drawing.Size(1017, 20);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 30);
            this.barDockControlLeft.Manager = this.barManager1;
            this.barDockControlLeft.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 605);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(1017, 30);
            this.barDockControlRight.Manager = this.barManager1;
            this.barDockControlRight.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.barDockControlRight.Size = new System.Drawing.Size(0, 605);
            // 
            // barButtonItem3
            // 
            this.barButtonItem3.Caption = "Kaydet";
            this.barButtonItem3.Id = 2;
            this.barButtonItem3.Name = "barButtonItem3";
            // 
            // gridControl
            // 
            this.gridControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl.EmbeddedNavigator.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Location = new System.Drawing.Point(0, 30);
            this.gridControl.MainView = this.winExplorerView;
            this.gridControl.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gridControl.Name = "gridControl";
            this.gridControl.Size = new System.Drawing.Size(1017, 605);
            this.gridControl.TabIndex = 4;
            this.gridControl.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.winExplorerView});
            // 
            // winExplorerView
            // 
            this.winExplorerView.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            this.winExplorerView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.columnName,
            this.columnPath,
            this.columnCheck,
            this.columnGroup,
            this.columnImage});
            this.winExplorerView.ColumnSet.CheckBoxColumn = this.columnCheck;
            this.winExplorerView.ColumnSet.DescriptionColumn = this.columnPath;
            this.winExplorerView.ColumnSet.ExtraLargeImageColumn = this.columnImage;
            this.winExplorerView.ColumnSet.GroupColumn = this.columnGroup;
            this.winExplorerView.ColumnSet.LargeImageColumn = this.columnImage;
            this.winExplorerView.ColumnSet.MediumImageColumn = this.columnImage;
            this.winExplorerView.ColumnSet.SmallImageColumn = this.columnImage;
            this.winExplorerView.ColumnSet.TextColumn = this.columnName;
            this.winExplorerView.GridControl = this.gridControl;
            this.winExplorerView.GroupCount = 1;
            this.winExplorerView.Name = "winExplorerView";
            this.winExplorerView.OptionsBehavior.Editable = false;
            this.winExplorerView.OptionsSelection.AllowMarqueeSelection = true;
            this.winExplorerView.OptionsSelection.ItemSelectionMode = DevExpress.XtraGrid.Views.WinExplorer.IconItemSelectionMode.Click;
            this.winExplorerView.OptionsSelection.MultiSelect = true;
            this.winExplorerView.OptionsView.ImageLayoutMode = DevExpress.Utils.Drawing.ImageLayoutMode.Stretch;
            this.winExplorerView.OptionsView.ShowViewCaption = true;
            this.winExplorerView.SortInfo.AddRange(new DevExpress.XtraGrid.Columns.GridColumnSortInfo[] {
            new DevExpress.XtraGrid.Columns.GridColumnSortInfo(this.columnGroup, DevExpress.Data.ColumnSortOrder.Ascending)});
            this.winExplorerView.ItemClick += new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewItemClickEventHandler(this.OnWinExplorerViewItemClick);
            this.winExplorerView.ItemDoubleClick += new DevExpress.XtraGrid.Views.WinExplorer.WinExplorerViewItemDoubleClickEventHandler(this.OnWinExplorerViewItemDoubleClick);
            this.winExplorerView.KeyDown += new System.Windows.Forms.KeyEventHandler(this.OnWinExplorerViewKeyDown);
            // 
            // columnName
            // 
            this.columnName.Caption = "columnName";
            this.columnName.FieldName = "Name";
            this.columnName.MinWidth = 23;
            this.columnName.Name = "columnName";
            this.columnName.Visible = true;
            this.columnName.VisibleIndex = 0;
            this.columnName.Width = 87;
            // 
            // columnPath
            // 
            this.columnPath.Caption = "columnPath";
            this.columnPath.FieldName = "Path";
            this.columnPath.MinWidth = 23;
            this.columnPath.Name = "columnPath";
            this.columnPath.Visible = true;
            this.columnPath.VisibleIndex = 0;
            this.columnPath.Width = 87;
            // 
            // columnCheck
            // 
            this.columnCheck.Caption = "columnCheck";
            this.columnCheck.FieldName = "IsCheck";
            this.columnCheck.MinWidth = 23;
            this.columnCheck.Name = "columnCheck";
            this.columnCheck.Visible = true;
            this.columnCheck.VisibleIndex = 0;
            this.columnCheck.Width = 87;
            // 
            // columnGroup
            // 
            this.columnGroup.Caption = "columnGroup";
            this.columnGroup.FieldName = "Group";
            this.columnGroup.MinWidth = 23;
            this.columnGroup.Name = "columnGroup";
            this.columnGroup.Visible = true;
            this.columnGroup.VisibleIndex = 0;
            this.columnGroup.Width = 87;
            // 
            // columnImage
            // 
            this.columnImage.Caption = "columnImage";
            this.columnImage.FieldName = "Image";
            this.columnImage.MinWidth = 23;
            this.columnImage.Name = "columnImage";
            this.columnImage.Visible = true;
            this.columnImage.VisibleIndex = 0;
            this.columnImage.Width = 87;
            // 
            // itemPopupMenu
            // 
            this.itemPopupMenu.Name = "itemPopupMenu";
            // 
            // FrmFileManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1017, 655);
            this.Controls.Add(this.gridControl);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmFileManager";
            this.Text = "Dosya Yönetimi";
            ((System.ComponentModel.ISupportInitialize)(this.barManager1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.winExplorerView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPopupMenu)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraGrid.GridControl gridControl;
        private DevExpress.XtraGrid.Views.WinExplorer.WinExplorerView winExplorerView;
        private DevExpress.XtraGrid.Columns.GridColumn columnName;
        private DevExpress.XtraGrid.Columns.GridColumn columnPath;
        private DevExpress.XtraGrid.Columns.GridColumn columnCheck;
        private DevExpress.XtraGrid.Columns.GridColumn columnGroup;
        private DevExpress.XtraGrid.Columns.GridColumn columnImage;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
        private DevExpress.XtraBars.PopupMenu itemPopupMenu;
        private DevExpress.XtraBars.Bar bar1;
    }
}