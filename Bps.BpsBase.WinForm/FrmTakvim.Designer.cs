namespace BPS.Windows.Forms
{
	partial class FrmTakvim
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmTakvim));
			DevExpress.XtraScheduler.TimeRuler timeRuler1 = new DevExpress.XtraScheduler.TimeRuler();
			DevExpress.XtraScheduler.TimeRuler timeRuler2 = new DevExpress.XtraScheduler.TimeRuler();
			DevExpress.XtraScheduler.TimeRuler timeRuler3 = new DevExpress.XtraScheduler.TimeRuler();
			this.ribbon = new DevExpress.XtraBars.Ribbon.RibbonControl();
			this.barButDay = new DevExpress.XtraBars.BarButtonItem();
			this.barButFullWeek = new DevExpress.XtraBars.BarButtonItem();
			this.barButWorkDays = new DevExpress.XtraBars.BarButtonItem();
			this.barButMonth = new DevExpress.XtraBars.BarButtonItem();
			this.barButAgenda = new DevExpress.XtraBars.BarButtonItem();
			this.barButYear = new DevExpress.XtraBars.BarButtonItem();
			this.ribbonPage1 = new DevExpress.XtraBars.Ribbon.RibbonPage();
			this.ribbonPageGroup1 = new DevExpress.XtraBars.Ribbon.RibbonPageGroup();
			this.ribbonStatusBar = new DevExpress.XtraBars.Ribbon.RibbonStatusBar();
			this.schedulerControl1 = new DevExpress.XtraScheduler.SchedulerControl();
			this.schedulerDataStorage1 = new DevExpress.XtraScheduler.SchedulerDataStorage(this.components);
			this.splitContainerControl1 = new DevExpress.XtraEditors.SplitContainerControl();
			this.dateNavigator1 = new DevExpress.XtraScheduler.DateNavigator();
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).BeginInit();
			this.splitContainerControl1.Panel1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).BeginInit();
			this.splitContainerControl1.Panel2.SuspendLayout();
			this.splitContainerControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).BeginInit();
			this.SuspendLayout();
			// 
			// ribbon
			// 
			this.ribbon.ExpandCollapseItem.Id = 0;
			this.ribbon.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.ribbon.ExpandCollapseItem,
            this.ribbon.SearchEditItem,
            this.barButDay,
            this.barButFullWeek,
            this.barButWorkDays,
            this.barButMonth,
            this.barButAgenda,
            this.barButYear});
			this.ribbon.Location = new System.Drawing.Point(0, 0);
			this.ribbon.MaxItemId = 7;
			this.ribbon.Name = "ribbon";
			this.ribbon.Pages.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPage[] {
            this.ribbonPage1});
			this.ribbon.Size = new System.Drawing.Size(1375, 158);
			this.ribbon.StatusBar = this.ribbonStatusBar;
			// 
			// barButDay
			// 
			this.barButDay.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.barButDay.Caption = "Gün";
			this.barButDay.Id = 1;
			this.barButDay.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButDay.ImageOptions.Image")));
			this.barButDay.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButDay.ImageOptions.LargeImage")));
			this.barButDay.Name = "barButDay";
			this.barButDay.Tag = "Day";
			this.barButDay.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButDay_ItemClick);
			// 
			// barButFullWeek
			// 
			this.barButFullWeek.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.barButFullWeek.Caption = "Hafta";
			this.barButFullWeek.Id = 2;
			this.barButFullWeek.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButFullWeek.ImageOptions.Image")));
			this.barButFullWeek.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButFullWeek.ImageOptions.LargeImage")));
			this.barButFullWeek.Name = "barButFullWeek";
			this.barButFullWeek.Tag = "FullWeek";
			this.barButFullWeek.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButDay_ItemClick);
			// 
			// barButWorkDays
			// 
			this.barButWorkDays.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.barButWorkDays.Caption = "Haftaiçi";
			this.barButWorkDays.Id = 3;
			this.barButWorkDays.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButWorkDays.ImageOptions.Image")));
			this.barButWorkDays.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButWorkDays.ImageOptions.LargeImage")));
			this.barButWorkDays.Name = "barButWorkDays";
			this.barButWorkDays.Tag = "WorkDays";
			this.barButWorkDays.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButDay_ItemClick);
			// 
			// barButMonth
			// 
			this.barButMonth.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.barButMonth.Caption = "Ay";
			this.barButMonth.Id = 4;
			this.barButMonth.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButMonth.ImageOptions.Image")));
			this.barButMonth.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButMonth.ImageOptions.LargeImage")));
			this.barButMonth.Name = "barButMonth";
			this.barButMonth.Tag = "Month";
			this.barButMonth.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButDay_ItemClick);
			// 
			// barButAgenda
			// 
			this.barButAgenda.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.barButAgenda.Caption = "Ajanda";
			this.barButAgenda.Id = 5;
			this.barButAgenda.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButAgenda.ImageOptions.Image")));
			this.barButAgenda.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButAgenda.ImageOptions.LargeImage")));
			this.barButAgenda.Name = "barButAgenda";
			this.barButAgenda.Tag = "Agenda";
			this.barButAgenda.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButDay_ItemClick);
			// 
			// barButYear
			// 
			this.barButYear.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.Check;
			this.barButYear.Caption = "Yıl";
			this.barButYear.Id = 6;
			this.barButYear.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barButYear.ImageOptions.Image")));
			this.barButYear.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barButYear.ImageOptions.LargeImage")));
			this.barButYear.Name = "barButYear";
			this.barButYear.Tag = "Year";
			this.barButYear.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButDay_ItemClick);
			// 
			// ribbonPage1
			// 
			this.ribbonPage1.Groups.AddRange(new DevExpress.XtraBars.Ribbon.RibbonPageGroup[] {
            this.ribbonPageGroup1});
			this.ribbonPage1.Name = "ribbonPage1";
			this.ribbonPage1.Text = "Aksiyon Takvimi";
			// 
			// ribbonPageGroup1
			// 
			this.ribbonPageGroup1.ItemLinks.Add(this.barButDay);
			this.ribbonPageGroup1.ItemLinks.Add(this.barButFullWeek);
			this.ribbonPageGroup1.ItemLinks.Add(this.barButWorkDays);
			this.ribbonPageGroup1.ItemLinks.Add(this.barButMonth);
			this.ribbonPageGroup1.ItemLinks.Add(this.barButAgenda);
			this.ribbonPageGroup1.ItemLinks.Add(this.barButYear);
			this.ribbonPageGroup1.Name = "ribbonPageGroup1";
			this.ribbonPageGroup1.Text = "Görünüm";
			// 
			// ribbonStatusBar
			// 
			this.ribbonStatusBar.Location = new System.Drawing.Point(0, 579);
			this.ribbonStatusBar.Name = "ribbonStatusBar";
			this.ribbonStatusBar.Ribbon = this.ribbon;
			this.ribbonStatusBar.Size = new System.Drawing.Size(1375, 24);
			// 
			// schedulerControl1
			// 
			this.schedulerControl1.DataStorage = this.schedulerDataStorage1;
			this.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.schedulerControl1.Location = new System.Drawing.Point(0, 0);
			this.schedulerControl1.MenuManager = this.ribbon;
			this.schedulerControl1.Name = "schedulerControl1";
			this.schedulerControl1.Size = new System.Drawing.Size(1102, 421);
			this.schedulerControl1.Start = new System.DateTime(2024, 12, 23, 0, 0, 0, 0);
			this.schedulerControl1.TabIndex = 2;
			this.schedulerControl1.Text = "schedulerControl1";
			this.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1);
			this.schedulerControl1.Views.FullWeekView.Enabled = true;
			this.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2);
			this.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3);
			this.schedulerControl1.Views.YearView.UseOptimizedScrolling = false;
			this.schedulerControl1.ActiveViewChanged += new System.EventHandler(this.schedulerControl1_ActiveViewChanged);
			this.schedulerControl1.AppointmentsDrop += new System.EventHandler<DevExpress.XtraScheduler.AppointmentsDragEventArgs>(this.schedulerControl1_AppointmentsDrop);
			// 
			// schedulerDataStorage1
			// 
			// 
			// 
			// 
			this.schedulerDataStorage1.AppointmentDependencies.AutoReload = false;
			// 
			// splitContainerControl1
			// 
			this.splitContainerControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.splitContainerControl1.Location = new System.Drawing.Point(0, 158);
			this.splitContainerControl1.Name = "splitContainerControl1";
			// 
			// splitContainerControl1.Panel1
			// 
			this.splitContainerControl1.Panel1.Controls.Add(this.dateNavigator1);
			this.splitContainerControl1.Panel1.Text = "Panel1";
			// 
			// splitContainerControl1.Panel2
			// 
			this.splitContainerControl1.Panel2.Controls.Add(this.schedulerControl1);
			this.splitContainerControl1.Panel2.Text = "Panel2";
			this.splitContainerControl1.Size = new System.Drawing.Size(1375, 421);
			this.splitContainerControl1.SplitterPosition = 263;
			this.splitContainerControl1.TabIndex = 3;
			// 
			// dateNavigator1
			// 
			this.dateNavigator1.CalendarAppearance.DayCellSpecial.FontStyleDelta = System.Drawing.FontStyle.Bold;
			this.dateNavigator1.CalendarAppearance.DayCellSpecial.Options.UseFont = true;
			this.dateNavigator1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateNavigator1.FirstDayOfWeek = System.DayOfWeek.Monday;
			this.dateNavigator1.Location = new System.Drawing.Point(12, 15);
			this.dateNavigator1.Name = "dateNavigator1";
			this.dateNavigator1.SchedulerControl = this.schedulerControl1;
			this.dateNavigator1.Size = new System.Drawing.Size(241, 245);
			this.dateNavigator1.TabIndex = 4;
			this.dateNavigator1.SelectionChanged += new System.EventHandler(this.dateNavigator1_SelectionChanged);
			// 
			// FrmTakvim
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1375, 603);
			this.Controls.Add(this.splitContainerControl1);
			this.Controls.Add(this.ribbonStatusBar);
			this.Controls.Add(this.ribbon);
			this.Name = "FrmTakvim";
			this.Ribbon = this.ribbon;
			this.StatusBar = this.ribbonStatusBar;
			this.Text = "FrmTakvim";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Load += new System.EventHandler(this.FrmTakvim_Load);
			((System.ComponentModel.ISupportInitialize)(this.ribbon)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.schedulerControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.schedulerDataStorage1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel1)).EndInit();
			this.splitContainerControl1.Panel1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1.Panel2)).EndInit();
			this.splitContainerControl1.Panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.splitContainerControl1)).EndInit();
			this.splitContainerControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.dateNavigator1.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateNavigator1)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private DevExpress.XtraBars.Ribbon.RibbonControl ribbon;
		private DevExpress.XtraBars.Ribbon.RibbonPage ribbonPage1;
		private DevExpress.XtraBars.Ribbon.RibbonPageGroup ribbonPageGroup1;
		private DevExpress.XtraBars.Ribbon.RibbonStatusBar ribbonStatusBar;
		private DevExpress.XtraScheduler.SchedulerControl schedulerControl1;
		private DevExpress.XtraScheduler.SchedulerDataStorage schedulerDataStorage1;
		private DevExpress.XtraEditors.SplitContainerControl splitContainerControl1;
		private DevExpress.XtraScheduler.DateNavigator dateNavigator1;
		private DevExpress.XtraBars.BarButtonItem barButDay;
		private DevExpress.XtraBars.BarButtonItem barButFullWeek;
		private DevExpress.XtraBars.BarButtonItem barButWorkDays;
		private DevExpress.XtraBars.BarButtonItem barButMonth;
		private DevExpress.XtraBars.BarButtonItem barButAgenda;
		private DevExpress.XtraBars.BarButtonItem barButYear;
	}
}