using System;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Bps.BpsBase.Entities.Models;
using DevExpress.XtraBars;
using DevExpress.XtraScheduler;
using DevExpress.XtraScheduler.Native;

namespace BPS.Windows.Forms
{
	public partial class FrmTakvim : DevExpress.XtraBars.Ribbon.RibbonForm
	{
		public BindingList<LocationData> Locations { get; private set; }
		public BindingList<Calendar> Calendars { get; private set; }
		public BindingList<EventData> Events { get; private set; }

		private bool refreshData;

		public FrmTakvim()
		{
			InitializeComponent();

			refreshData = true;
			Locations = new BindingList<LocationData>();
			Calendars = new BindingList<Calendar>();
			Events = new BindingList<EventData>();

			//schedulerControl1.DayView.TopRowTime = TimeSpan.FromHours(8);

			TimeSpan startTime = new TimeSpan(8, 0, 0);  // 8:00 AM
			TimeSpan endTime = new TimeSpan(20, 0, 0);  // 6:00 PM

			schedulerControl1.DayView.VisibleTime = new TimeOfDayInterval(startTime, endTime);
			schedulerControl1.FullWeekView.VisibleTime = new TimeOfDayInterval(startTime, endTime);
			schedulerControl1.WorkWeekView.VisibleTime = new TimeOfDayInterval(startTime, endTime);
		}

		private void FrmTakvim_Load(object sender, EventArgs e)
		{
			SetView("WorkDays");
			barButWorkDays.Down = true;

			//// Sample DataTable for appointments
			//DataTable appointments = new DataTable();
			//appointments.Columns.Add("Id", typeof(int));
			//appointments.Columns.Add("StartTime", typeof(DateTime));
			//appointments.Columns.Add("EndTime", typeof(DateTime));
			//appointments.Columns.Add("Subject", typeof(string));

			//// Add sample data
			//appointments.Rows.Add(1, DateTime.Now, DateTime.Now.AddHours(1), "Meeting");
			//appointments.Rows.Add(2, DateTime.Now.AddHours(2), DateTime.Now.AddHours(3), "Lunch");

			//// Bind to SchedulerStorage
			//schedulerDataStorage1.Appointments.DataSource = appointments;
			//schedulerDataStorage1.Appointments.Mappings.Start = "StartTime";
			//schedulerDataStorage1.Appointments.Mappings.End = "EndTime";
			//schedulerDataStorage1.Appointments.Mappings.Subject = "Subject";

			//// Assign the storage to the SchedulerControl
			//schedulerControl1.DataStorage = schedulerDataStorage1;
		}

		private void schedulerControl1_AppointmentsDrop(object sender, AppointmentsDragEventArgs e)
		{

		}

		void SetView(string view)
		{
			ResetViews();
			UpdateRulers(true);
			TimeRegionHelper.Attach(schedulerControl1);

			switch (view)
			{
				case "Year":
					refreshData = true;

					AttachToYearScheduler();
					schedulerControl1.YearView.Enabled = true;
					schedulerControl1.ActiveViewType = SchedulerViewType.Year;
					barButYear.Down = true;
					break;
				default:
					AttachToScheduler(view);
					break;
			}

			//ResetOptions();
		}

		void ResetViews()
		{
			schedulerControl1.DayView.Enabled = false;
			schedulerControl1.WorkWeekView.Enabled = false;
			schedulerControl1.WeekView.Enabled = false;
			schedulerControl1.MonthView.Enabled = false;
			schedulerControl1.TimelineView.Enabled = false;
			schedulerControl1.AgendaView.Enabled = false;
			schedulerControl1.YearView.Enabled = false;

			ResetButtons();
		}

		void UpdateRulers(bool shouldShowRightRuler)
		{
			int timeRulersCount = this.schedulerControl1.DayView.TimeRulers.Count;
			for (int i = 0; i < timeRulersCount; i++)
			{
				TimeRuler timeRuler = this.schedulerControl1.DayView.TimeRulers[i];
				if (timeRuler.HorizontalAlignment == TimeRulerHorizontalAlignment.Far)
					timeRuler.Visible = shouldShowRightRuler;
			}
		}

		void AttachToScheduler(string view)
		{
			schedulerControl1.Tag = this;

			switch (view)
			{
				case "Day":
					schedulerControl1.DayView.Enabled = true;
					schedulerControl1.ActiveViewType = SchedulerViewType.Day;
					barButDay.Down = true;
					break;
				case "FullWeek":
					schedulerControl1.FullWeekView.Enabled = true;
					schedulerControl1.ActiveViewType = SchedulerViewType.FullWeek;
					barButFullWeek.Down = true;
					break;
				case "WorkDays":
					schedulerControl1.WorkWeekView.Enabled = true;
					schedulerControl1.ActiveViewType = SchedulerViewType.WorkWeek;
					barButWorkDays.Down = true;
					break;
				case "Month":
					schedulerControl1.MonthView.Enabled = true;
					schedulerControl1.ActiveViewType = SchedulerViewType.Month;
					barButMonth.Down = true;
					break;
				case "Agenda":
					schedulerControl1.AgendaView.Enabled = true;
					schedulerControl1.ActiveViewType = SchedulerViewType.Agenda;
					schedulerControl1.AgendaView.DayCount = 10;
					barButAgenda.Down = true;
					break;
			}

			SchedulerDataStorage storage = (SchedulerDataStorage)schedulerControl1.DataStorage;
			schedulerControl1.BeginUpdate();
			try
			{
				storage.Appointments.ResourceSharing = true;
				storage.DateTimeSavingMode = DateTimeSavingMode.Storage;

				storage.Appointments.Labels.Clear();
				storage.Appointments.Labels.Add(SchedulerColorId.NoneLabel, "None", "None");
				storage.Appointments.Labels.Add(SchedulerColorId.PersonalLabel, "Green Category", "Green Category");
				storage.Appointments.Labels.Add(SchedulerColorId.BusinessLabel, "Blue Category", "Blue Category");
				storage.Appointments.Labels.Add(SchedulerColorId.MustAttendLabel, "Orange Category", "Orange Category");
				storage.Appointments.Labels.Add(SchedulerColorId.BirthdayLabel, "Purple Category", "Purple Category");
				storage.Appointments.Labels.Add(SchedulerColorId.ImportantLabel, "Red Category", "Red Category");
				storage.Appointments.Labels.Add(SchedulerColorId.PhoneCallLabel, "Yellow Category", "Yellow Category");
				GenerateLocations();
				GenerateResources();
				GenerateEvents();

				PrepareResourceStorage(storage, true);
				PrepareAppointmentStorage(storage);
				schedulerControl1.InitNewAppointment += (o, e) => { if (((SchedulerControl)o).GroupType == SchedulerGroupType.None) e.Appointment.ResourceId = 1; };

				schedulerControl1.Start = DateTime.Today;

			}
			finally
			{
				schedulerControl1.EndUpdate();
			}
		}

		void AttachToYearScheduler()
		{
			schedulerControl1.Start = new DateTime(DateTime.Now.Year, 1, 1);
			schedulerControl1.Tag = this;

			SchedulerDataStorage storage = (SchedulerDataStorage)schedulerControl1.DataStorage;
			schedulerControl1.BeginUpdate();
			try
			{
				storage.DateTimeSavingMode = DateTimeSavingMode.Storage;

				storage.Appointments.Labels.Clear();
				storage.Appointments.Labels.Add(SchedulerColorId.PersonalLabel, "Vacation Leave", "Vacation Leave");
				storage.Appointments.Labels.Add(SchedulerColorId.MustAttendLabel, "Sick Leave", "Sick Leave");
				storage.Appointments.Labels.Add(SchedulerColorId.BusinessLabel, "FMLA", "FMLA");
				storage.Appointments.Labels.Add(SchedulerColorId.ImportantLabel, "Parental Leave", "Parental Leave");

				Locations.Add(new LocationData() { Id = 0, Caption = "Home" });

				GenerateForYearView();

				PrepareAppointmentStorage(storage);
			}
			finally
			{
				schedulerControl1.EndUpdate();
			}
		}

		void GenerateLocations()
		{
			if (Locations.Count == 0)
			{
				int id = 0;
				Locations.Add(new LocationData() { Id = id, Caption = "My Office" }); ++id;
				Locations.Add(new LocationData() { Id = id, Caption = "Conference Room A" }); ++id;
				Locations.Add(new LocationData() { Id = id, Caption = "Lunch at Caroline's Steakhouse" }); ++id;
				Locations.Add(new LocationData() { Id = id, Caption = "Conference Room B" }); ++id;
				Locations.Add(new LocationData() { Id = id, Caption = "MacArthur Country Club" }); ++id;
				Locations.Add(new LocationData() { Id = id, Caption = "R&R Health Spa" }); ++id;
			}

		}

		void GenerateResources()
		{
			if (Calendars.Count == 0)
			{
				Calendars.Add(new Calendar() { Id = 0, Caption = "Work", ParentId = 0 });
				Calendars.Add(new Calendar() { Id = 1, Caption = "Indoor meetings", ParentId = 0 });
				Calendars.Add(new Calendar() { Id = 2, Caption = "Outdoor meetings", ParentId = 0 });
				Calendars.Add(new Calendar() { Id = 3, Caption = "Partnership", ParentId = 3 });
				Calendars.Add(new Calendar() { Id = 4, Caption = "Personal", ParentId = 4 });
				Calendars.Add(new Calendar() { Id = 5, Caption = "Golfing", ParentId = 4 });
				Calendars.Add(new Calendar() { Id = 6, Caption = "Other", ParentId = 0 });
				Calendars.Add(new Calendar() { Id = 7, Caption = "Other Activities", ParentId = 4 });
				Calendars.Add(new Calendar() { Id = 8, Caption = "Baseball", ParentId = 4 });
				Calendars.Add(new Calendar() { Id = 9, Caption = "Family", ParentId = 4 });
			}
		}

		void GenerateEvents()
		{
			if (!refreshData) return;

			Events = new BindingList<EventData>();
			DateTime baseDate = DateTimeHelper.GetStartOfWeek(DateTime.Today);
			AddEvent(baseDate + TimeSpan.FromTicks(-13518000000000), baseDate + TimeSpan.FromTicks(-13482000000000), "Weekly management meeting", "Review sales and revenue figures for the week, plan for next week's sales push. Discuss strategies to improve factory output and reduce overall costs. \r\n\r\nReports Needed: Weekly sales figures and factory output.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "My Office", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-13473000000000), baseDate + TimeSpan.FromTicks(-13437000000000), "Board of Directors meeting", "Demonstrate need for outside capital to help fuel sales growth and describe risks to business from weakness in supply chain.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room A", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-13428000000000), baseDate + TimeSpan.FromTicks(-13392000000000), "John Gomez - LED Supplier", "Discuss John's new LED technology and determine whether working with his company will offer us better options for the next 1-2 years.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-13383000000000), baseDate + TimeSpan.FromTicks(-13338000000000), "Employee of the month Luncheon", "Make certain that everyone appreciates the hard work required to become employee of the month and why we must work harder than ever before to reach our business objectives.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Lunch at Caroline's Steakhouse", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-13302000000000), baseDate + TimeSpan.FromTicks(-13248000000000), "Product development meeting with R&D team", "Review schematics for new projectors and discuss options for 8K and Dolby Atmos. Determine if we should create our own A/V receiver.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room B", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-12636000000000), baseDate + TimeSpan.FromTicks(-12492000000000), "Golfing with Trent, Barry and Bob", "Goal: Shoot a 88\r\n\r\nRemember, keep eye on the ball throughout the entire swing.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"5\" />\r\n</ResourceIds>", 0, "MacArthur Country Club", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-12096000000000), baseDate + TimeSpan.FromTicks(-11232000000000), "Rest, relax and get ready for next week", "6750 Main Street\r\nLos Angeles, CA 90001", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "R&R Health Spa", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-10944000000000), baseDate + TimeSpan.FromTicks(-10872000000000), "Breakfast with COO to discuss network security", "Determine whether all precautions are being taken and penetration testing has been complete. Make certain customer information is safe andd secure from external threats.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Sam's Breakfast Nook", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-10836000000000), baseDate + TimeSpan.FromTicks(-10782000000000), "Discuss health insurance policy with broker", "Analyze available options for group healthcare and determine if costs can be reduced in both the short term and long term.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-9900000000000), baseDate + TimeSpan.FromTicks(-9864000000000), "Lunch with Ziggy to discuss my golf game", "Did not shoot a 88 last round. Need to figure out why.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"5\" />\r\n</ResourceIds>", 0, "The Beer Garden Lunchroom", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(-10692000000000), baseDate + TimeSpan.FromTicks(-10620000000000), "Root canal and tooth cleaning appointment", "2 hour appointment - must ask him about problem with my molar.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Dr Drake Dental Center", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-10062000000000), baseDate + TimeSpan.FromTicks(-9990000000000), "Presentation on new BluRay player with team", "Product is ready to go to manufacturing. Must determine if pricing model is justified by features and build quality. \r\n\r\nThis is a critical product and we cannot make any mistakes.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-9972000000000), baseDate + TimeSpan.FromTicks(-9900000000000), "Team training session on new automation engine", "Discuss new home automation API and see if we are close to integrating our products with Amazon Alexa. \r\n\r\nNeed to figure out if we'll ever release our own controller as well.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-9864000000000), baseDate + TimeSpan.FromTicks(-9828000000000), "Late lunch and cocktails with new recruits", "Get to know new team members and gauge competence levels. Must determine if these are the right people to help lead us into the uncharted waters of home automation.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Harry's Steakhouse", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-9756000000000), baseDate + TimeSpan.FromTicks(-9702000000000), "Workout", "Trainer is available for first half of training session. Discuss ways to strengthen golf swing.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"5\" />\r\n</ResourceIds>", 0, "The Crossfit Center", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-9180000000000), baseDate + TimeSpan.FromTicks(-9144000000000), "Customer Service Training", "All customer service reps will be in attendance. Review our customer service goals, our satisfaction index and discuss ways in which we must improve team performance.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-9126000000000), baseDate + TimeSpan.FromTicks(-9054000000000), "Sales Force Training", "All sales reps will be in attendance. Review sales techniques to determine how to best improve closing rates. Make certain to answer all product related questions during meeting.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-9045000000000), baseDate + TimeSpan.FromTicks(-9000000000000), "Lunch with High School buddies", "Ask Darren if he remembers our he remembers the name of our English teacher.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "4 Corners Family Restaurant", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(-8973000000000), baseDate + TimeSpan.FromTicks(-8892000000000), "Review product literature and marketing brochures", "Detailed review of all product literature and discuss layout of new marketing brochures. \r\n\r\nMust address customer complaints that our specifications are not 100% accurate.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-8640000000000), baseDate + TimeSpan.FromTicks(-7776000000000), "Minor surgery", "Jane's surgery is today. Will not be at office so I can assist her after her operation.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Community Hospital", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-7488000000000), baseDate + TimeSpan.FromTicks(-7470000000000), "Breakfast with Management Team", "Discuss the upcoming product release cycle and finalize tradeshow plans. Need to nail down the presentations that will be made at the event.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Tiffany's Breakfast Lounge", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-7416000000000), baseDate + TimeSpan.FromTicks(-7362000000000), "Review financials with outside accounting firm", "Determine if all accounting rules are followed and make certain that last year's errors are addressed and will no longer be an issue going forward.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "Conference Room B", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-6444000000000), baseDate + TimeSpan.FromTicks(-6408000000000), "Lunch with sales team", "Motivate sales team to be more aggressive and to be more self-driven. We need to increase sales which requires a commitment from everyone to work longer and to try harder.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Bob's Burgers", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(-6912000000000), baseDate + TimeSpan.FromTicks(-6048000000000), "Little League Championship", "Go Tigers - let's win our first Little League championship.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"8\" />\r\n</ResourceIds>", 0, "Baseball Sadium", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-5760000000000), baseDate + TimeSpan.FromTicks(-5580000000000), "Move office from 1st to 2nd floor", "I expect this to take all day. Will be moving my office from the 1st floor to the second floor. \r\n\r\nAdmin assistant must also relocate to the 2nd floor.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Headquarters", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-4860000000000), baseDate + TimeSpan.FromTicks(-4806000000000), "Conference Call with LED suppliers", "Need to understand why pricing is on the rise and quality is falling. Frustration amongst engineering staff has never been higher.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-4788000000000), baseDate + TimeSpan.FromTicks(-4716000000000), "Company meeting", "Review rules that govern workplace behavior. Discuss impact of changes to the law and how it will impact DevAV in the upcoming 12 months.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-4680000000000), baseDate + TimeSpan.FromTicks(-4644000000000), "Lunch and cocktails", "Late lunch and early cocktails to help relax and get ready for the debriefing from marketing team later in the day.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Bob's Burgers", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-4608000000000), baseDate + TimeSpan.FromTicks(-4554000000000), "Marketing meeting", "Sales are flat, sales people do not have enough leads. We need to increase our marketing efforts. Our television ad buys are a huge money pit and are not offering the benefits promised.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room A", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-4032000000000), baseDate + TimeSpan.FromTicks(-3960000000000), "Meeting with outside HR team", "Johnson & Co is promising to reduce our HR costs and improve the quality of hires. Need to verify that their proposal is factual and not smoke and mirrors.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Conference Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-3933000000000), baseDate + TimeSpan.FromTicks(-3897000000000), "Engineering staff meeting", "Engineering continues to fall behind on new product deliveries. We need to correct the issue once and for all or this will be the worst quarter in our history.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "My Office", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-3888000000000), baseDate + TimeSpan.FromTicks(-3852000000000), "Database overhaul meeting", "Meet to discuss changes required to our database to deal with new products and to address on-going complaints from staff members about performance.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-3816000000000), baseDate + TimeSpan.FromTicks(-3780000000000), "Late lunch", "Quick lunch in my office and then 30 minutes of yoga to relax and unwind. A strong mind equals big results.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-3762000000000), baseDate + TimeSpan.FromTicks(-3744000000000), "Review tax filings", "Need to prepare early this quarter so we can file on time and make certain to avoid any penalties.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "My Office", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-3456000000000), baseDate + TimeSpan.FromTicks(-2592000000000), "CEO Roundtable", "Monthly CEO Roundtable meeting. Make sure to get with Zane Jones to determine how he deals with falling productivity and how he increases employee morale.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Hilton Hotel", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-2304000000000), baseDate + TimeSpan.FromTicks(-2232000000000), "Review the basic principles of Game Theory", "Discuss game theory with entire team and see if we have the tools necessary to improve internal decision making.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room A", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-2214000000000), baseDate + TimeSpan.FromTicks(-2142000000000), "Marketing brochure and cut-sheet review", "The marketing team has prepared final drafts of all upcoming brochures. Must verify that specifications are accurate and make certain that engineering is satisfied with the work.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-2124000000000), baseDate + TimeSpan.FromTicks(-2088000000000), "Late lunch with Doris", "Need to ask Doris if she expects our Little League to do better next year. We have to bring in a ringer who can help us win a championship. Enough losing - it's time to star winning", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"8\" />\r\n</ResourceIds>", 0, "The Lunch Counter", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(-2070000000000), baseDate + TimeSpan.FromTicks(-2034000000000), "Review technical documentation", "Our product manuals need to be simplified so we can reduce customer support calls and increase overall customer satisfaction. \r\n\r\nEither we can do this ourselves our we need to obtain outside assistance.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-1440000000000), baseDate + TimeSpan.FromTicks(-1386000000000), "Weekly management meeting", "Review sales and revenue figures for the week, plan for next week's sales push. Discuss strategies to improve factory output and reduce overall costs.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "My Office", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-1377000000000), baseDate + TimeSpan.FromTicks(-1314000000000), "Meet with analysts and media", "Share our upcoming product releases, discuss stengths of existing product line and provide demos of our new 8K panels.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-1314000000000), baseDate + TimeSpan.FromTicks(-1260000000000), "Meeting to discuss progress on new website", "The website is taking far too long to develop and we need to get everyone on board with management's plan to release the site this month.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room B", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(-864000000000), baseDate + TimeSpan.FromTicks(0), "Vegas Baby", "Monthly trip to Vegas to win some and to lose some.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Las Vegas", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(0), baseDate + TimeSpan.FromTicks(864000000000), "Vegas Baby", "Monthly trip to Vegas to win some and to lose some.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Las Vegas", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(1170000000000), baseDate + TimeSpan.FromTicks(1206000000000), "Extend distribution channel", "Review all options to help us extend our distribution channel and help us get products into more stores. We need to expand internationally and across the Eastern seabord.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(1224000000000), baseDate + TimeSpan.FromTicks(1296000000000), "East-coast distributors meeting", "Host major distributors in the conference room and show them why they need to start carrying our products today.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "Conference Room A", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(1332000000000), baseDate + TimeSpan.FromTicks(1368000000000), "Lunch and review of morning meetings", "Get feedback from management on our morning meetings and see if there's anything we may have missed during our briefing with East-coast distributors.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Sal's Delicatessen", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(1386000000000), baseDate + TimeSpan.FromTicks(1458000000000), "International distributors meeting", "The biggest distributors meeting in the history of our company. Need to get our products into non-US markets.\r\n\r\nRemember to get feedback on our competition overseas.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "Training Room A", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(2061000000000), baseDate + TimeSpan.FromTicks(2106000000000), "Analyze market potential in the UK", "Determine if we have any chance of penetrating the UK A/V market and if so, what is the best chance to achieve our goals and aspirations.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(2124000000000), baseDate + TimeSpan.FromTicks(2196000000000), "Meeting with EU regulators", "Meet with EU regulators to determine battery disposal regulations and how we can avoid fines going forward. Need to verify if our current procedures are sufficient.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "Conference Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(2250000000000), baseDate + TimeSpan.FromTicks(2340000000000), "Discuss EU regulations with engineering", "Review input from EU regulators with engineering team and figure out how we can meet requirements at minimal cost. \r\n\r\nWe must avoid any unnecessary expenditures as are profit margins are being squeezed.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "Training Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(2592000000000), baseDate + TimeSpan.FromTicks(3456000000000), "Meet with architect and soil engineers", "Review the new house plans and make certain to discuss soil conditions with engineer to guarantee that erosion will not be a problem on this plot of land.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Hilltop Development", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(3789000000000), baseDate + TimeSpan.FromTicks(3825000000000), "Customer retention review", "Discuss ways in which we can improve our relationship with customers and prove to them that we are the long term source for all their A/V needs.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(3843000000000), baseDate + TimeSpan.FromTicks(3888000000000), "Determine operational deficiencies", "Weaknesses remain throughout operations and we need to determine the weakest link and eliminate any bottlenecks in production.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(3924000000000), baseDate + TimeSpan.FromTicks(3960000000000), "Lunch with Arthur Doyle", "Has some information on our main competitor. Need to discuss a position within our company as he would be a great asset going forward.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Suzy's Steakhouse", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(3978000000000), baseDate + TimeSpan.FromTicks(4014000000000), "Accountant review", "Prepare for accountants. Review P&L for last few months. Balance sheet must also be reviewed and questions for acccountants formulated. We cannot make any mistakes.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(4608000000000), baseDate + TimeSpan.FromTicks(4716000000000), "Database and website review", "It's time to launch our new website. Management can no longer tolerate delays nor accept excuses. We've been waiting long enough for the overhaul.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room A", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(4824000000000), baseDate + TimeSpan.FromTicks(4860000000000), "French lesson", "If we are to have any chance in France, salespeople must learn french. Practice makes perfect and without constant repetition, learning a new language is impossible.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "Training Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(5544000000000), baseDate + TimeSpan.FromTicks(5652000000000), "18 rounds with Jeff", "It's time I showed everyone how much my game has improved. Hoping to shoot under par.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"5\" />\r\n</ResourceIds>", 0, "Westside Country Club", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(5760000000000), baseDate + TimeSpan.FromTicks(5868000000000), "Drinks and early dinner", "Let's hope I win my match against Jeff. Loser pays for drinks and dinner.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "The 19th Hole Pub", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(6048000000000), baseDate + TimeSpan.FromTicks(6912000000000), "All day with the kids at Disneyland", "It better be the happiest place on earth - I could sure use a nice day with the kids.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"9\" />\r\n</ResourceIds>", 0, "Disneyland", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(7200000000000), baseDate + TimeSpan.FromTicks(7236000000000), "Weekly management meeting", "Review sales and revenue figures for the week, plan for next week's sales push. Discuss strategies to improve factory output and reduce overall costs.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "My Office", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(7254000000000), baseDate + TimeSpan.FromTicks(7344000000000), "Supply-chain review", "Discuss the changes we need to make to our supply-chain to reduce production delays and reduce the amount of inventory on-hand.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(7470000000000), baseDate + TimeSpan.FromTicks(7524000000000), "Monthly customer service training", "All customer service employees must attend. Our focus is total customer satisfaction and any shortcomings need to be addressed. \r\n\r\nReview the status of customer complain reports with staff.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(8064000000000), baseDate + TimeSpan.FromTicks(8136000000000), "Workout", "Meet with new trainer to figure out how to streamline workouts and maintain optimal health.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Great American Gym", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(8280000000000), baseDate + TimeSpan.FromTicks(8388000000000), "Worldwide Executives Forum", "I will be unavailable throughout the day. Do not call my cell phone or text. Reach out to the COO should any operational issues arise.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Sheraton Hotel", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(8946000000000), baseDate + TimeSpan.FromTicks(9018000000000), "Review schematics", "Discuss new board design and determine if power consumption can be reduced. Schematics are ready but need final approval from engineering.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "My Office", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(9072000000000), baseDate + TimeSpan.FromTicks(9126000000000), "Lunch with Larry", "Golf swing requires work. Need to figure out what I must work on so I can start beating some of my opponents.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"5\" />\r\n</ResourceIds>", 0, "Zeke's BBQ", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(9162000000000), baseDate + TimeSpan.FromTicks(9243000000000), "Management meeting", "Satisfaction index remains low and work must be done to increase customer satisfaction across all areas of the business. \r\n\r\nWe cannot accept any excuses going forward.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(9801000000000), baseDate + TimeSpan.FromTicks(9846000000000), "Talk with Felton", "Felton is experiencing some difficulties and we need to figure out how to resolve his personal issues before we would consider his application for employment.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "My Office", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(9873000000000), baseDate + TimeSpan.FromTicks(9936000000000), "Train staff on new remote controls", "Our newest remote controls are ready for production. Everyone needs to understand how our new universal remote works and our long term plans for better automation.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(10008000000000), baseDate + TimeSpan.FromTicks(10062000000000), "Remote control training part 2", "Answer any questions employees have on the new remotes and gather input before remote controls go into full production.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(10080000000000), baseDate + TimeSpan.FromTicks(10152000000000), "Two hour workout", "Let's get ready for golf. Need to keep working on my strength. Ultimate goal is to drive the ball 300 yards. No more excuses.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"5\" />\r\n</ResourceIds>", 0, "Great American Gym", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(10692000000000), baseDate + TimeSpan.FromTicks(10836000000000), "Search for new office location", "Visit multiple sites for new headquarters. Agent promises to show me some interesting options so we can centralize operations and lower costs.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Los Angeles", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(11232000000000), baseDate + TimeSpan.FromTicks(12096000000000), "R&R", "Nothing to do but relax and enjoy the day with family. Need to take my foot off the gas pedal and enjoy the day.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"9\" />\r\n</ResourceIds>", 0, "Home", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(12096000000000), baseDate + TimeSpan.FromTicks(12960000000000), "R&R", "Nothing to do but relax and enjoy the day with family. Need to take my foot off the gas pedal and enjoy the day.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"9\" />\r\n</ResourceIds>", 0, "Home", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(13284000000000), baseDate + TimeSpan.FromTicks(13356000000000), "Sales review and analysis", "Analyze our sales results and discuss the state of expansion into the EU. Everyone needs to understand that without EU expansion, revenues will stagnate.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"3\" />\r\n</ResourceIds>", 0, "My Office", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(13383000000000), baseDate + TimeSpan.FromTicks(13428000000000), "French lesson", "Another french lesson. Once again, without mastering French, our success on the Continent will be less likely. Everyone needs to learn French.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(13482000000000), baseDate + TimeSpan.FromTicks(13536000000000), "Meeting with risk analysts", "Economists are suggesting that we are about to enter a global recession. Some analysts dispute this reality and we need to figure out who is right.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room B", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(14094000000000), baseDate + TimeSpan.FromTicks(14166000000000), "Breakfast with leadership team", "Not happy with the work being done by middle management. Leadership needs to suggest ways in which to improve morale and employee output.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Sara's Breakfast Nook", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(14184000000000), baseDate + TimeSpan.FromTicks(14256000000000), "Company-wide meeting", "Everyone must be ready to ask questions and inform leadership team why they are not performing as expected and what we need to do as a team to improve morale.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(14292000000000), baseDate + TimeSpan.FromTicks(14346000000000), "Lunch with Paul", "Need to figureo out if Paul has fully recovered from his surgery and if he needs any help with finances. Worried about his welfare.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Breckenridge Seafood", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(14364000000000), baseDate + TimeSpan.FromTicks(14436000000000), "German lesson", "We're learning French but we also need to become fluent in German. The German market for A/V products is huge. We need to be able to communicate in German if we are to have any luck in Germany.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(15012000000000), baseDate + TimeSpan.FromTicks(15084000000000), "Opportunities assessment meeting", "Leadership team must communicate all available opportunities and help define a roadmap we can rely upon as we move into new markets.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Conference Room B", 1, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(15156000000000), baseDate + TimeSpan.FromTicks(15192000000000), "Working lunch with staff", "Gather additional feedback on opportunities available to our company and see if anything more can be done to drive sales forward.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"2\" />\r\n</ResourceIds>", 0, "Hungry Heff's Burgers", 0, 3);
			AddEvent(baseDate + TimeSpan.FromTicks(15282000000000), baseDate + TimeSpan.FromTicks(15327000000000), "Workout", "Continue working on upper body strength and begin lower body training. Talk to trainer about increasing amount of time I spend at gym in the next few weeks.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Great American Gym", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(15552000000000), baseDate + TimeSpan.FromTicks(16416000000000), "Emily's surgery", "Will be unavailable entire day. Have requested that all my calls be forwarded to COO.", true, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"4\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"6\" />\r\n</ResourceIds>", 0, "Surgical Outpatient Center", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(16704000000000), baseDate + TimeSpan.FromTicks(16812000000000), "Customer service training part 1", "Jack Howell from Worldwide Consulting will pay us a visit to give us pointers on how to improve our customer service processes.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room A", 0, 0);
			AddEvent(baseDate + TimeSpan.FromTicks(16920000000000), baseDate + TimeSpan.FromTicks(16992000000000), "Customer service training part 2", "Part 2 - Jack promises that he will share some cutting edge techniques and case studies on how his system revolutionizes customer service processes.", false, "<ResourceIds>\r\n<ResourceId Type=\"System.Int32\" Value=\"0\" />\r\n<ResourceId Type=\"System.Int32\" Value=\"1\" />\r\n</ResourceIds>", 0, "Training Room B", 0, 0);
			
			refreshData = false;
		}

		string[] Names = new string[] {
			"Diego Roel",
			"Martine Rancé",
			"Maria Larsson",
			"Peter Franken",
			"Carine Schmitt",
			"Paolo Accorti",
			"Lino Rodriguez",
			"Eduardo Saavedra",
			"José Pedro Freyre",
			"André Fonseca",
			"Howard Snyder",
			"Manuel Pereira",
			"Mario Pontes",
			"Carlos Hernández",
			"Yoshi Latimer",
			"Philip Cramer"
		};

		void AddEvent(DateTime startDate, DateTime endDate, string subject, string description, bool allDay, string resourceIds, int eventType, string location, int labelId, int statusId)
		{
			EventData result = new EventData();
			result.StartDate = startDate;
			result.EndDate = endDate;
			result.Subject = subject;
			result.Description = description;
			result.AllDay = allDay;
			result.CalendarIds = resourceIds;
			result.EventType = eventType;
			result.Location = location;
			result.LabelId = labelId;
			result.StatusId = statusId;
			Events.Add(result);
		}

		void PrepareResourceStorage(ISchedulerStorage storage, bool hideParentResource)
		{
			ResourceMappingInfo mappings = storage.Resources.Mappings;
			mappings.Id = "Id";
			mappings.Caption = "Caption";
			mappings.ParentId = "ParentId";
			storage.Resources.DataSource = Calendars;
			if (hideParentResource)
			{
				foreach (Resource resource in storage.Resources.Items)
				{
					if (resource.ParentId.Equals(resource.Id))
						continue;
					storage.Resources.GetResourceById(resource.ParentId).Visible = false;
				}
			}
		}

		void PrepareAppointmentStorage(ISchedulerStorage storage)
		{
			AppointmentMappingInfo mappings = storage.Appointments.Mappings;
			mappings.AppointmentId = "Id";
			mappings.Start = "StartDate";
			mappings.End = "EndDate";
			mappings.AllDay = "AllDay";
			mappings.Subject = "Subject";
			mappings.Description = "Description";
			mappings.Location = "Location";
			mappings.ReminderInfo = "ReminderInfo";
			mappings.RecurrenceInfo = "RecurrenceInfo";
			mappings.Type = "EventType";
			mappings.ResourceId = "CalendarIds";
			mappings.Label = "LabelId";
			mappings.Status = "StatusId";

			storage.Appointments.CustomFieldMappings.Clear();
			storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("Priority", "Priority", FieldValueType.Integer));
			storage.Appointments.CustomFieldMappings.Add(new AppointmentCustomFieldMapping("IsPrivate", "IsPrivate", FieldValueType.Boolean));
			storage.Appointments.DataSource = Events;
		}

		void GenerateForYearView()
		{
			int year = DateTime.Now.Year;
			int idx = 0;
			AddEvent(new DateTime(year, 1, 7), new DateTime(year, 1, 13), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 0, 2);
			AddEvent(new DateTime(year, 1, 25), new DateTime(year, 1, 30), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 2, 2);
			AddEvent(new DateTime(year, 2, 19), new DateTime(year, 2, 25), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 3, 2);
			AddEvent(new DateTime(year, 3, 7), new DateTime(year, 3, 13), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 1, 2);
			AddEvent(new DateTime(year, 4, 12), new DateTime(year, 4, 18), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 2, 2);
			AddEvent(new DateTime(year, 5, 17), new DateTime(year, 5, 27), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 3, 2);
			AddEvent(new DateTime(year, 6, 2), new DateTime(year, 6, 8), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 0, 2);
			AddEvent(new DateTime(year, 7, 9), new DateTime(year, 7, 19), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 3, 2);
			AddEvent(new DateTime(year, 7, 26), new DateTime(year, 8, 1), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 2, 2);
			AddEvent(new DateTime(year, 9, 17), new DateTime(year, 9, 26), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 0, 2);
			AddEvent(new DateTime(year, 10, 3), new DateTime(year, 10, 10), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 3, 2);
			AddEvent(new DateTime(year, 11, 25), new DateTime(year, 12, 4), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 1, 2);
			AddEvent(new DateTime(year, 12, 14), new DateTime(year, 12, 21), GetNextVacationSubject(ref idx), String.Empty, true, null, 0, String.Empty, 2, 2);
		}

		string GetNextVacationSubject(ref int idx)
		{
			string subject = Names[idx] + "'s vacation";
			idx = (idx + 1) % Names.Length;
			return subject;
		}

		private void barButDay_ItemClick(object sender, ItemClickEventArgs e)
		{
			var button = e.Item as BarButtonItem;
			if (!button.Down) return;

			SetView(button.Tag.ToString());
		}

		void ResetButtons()
		{
			foreach (BarButtonItemLink link in ribbonPageGroup1.ItemLinks)
			{
				link.Item.Down = false;
			}
		}

		private void schedulerControl1_ActiveViewChanged(object sender, EventArgs e)
		{
			string view = schedulerControl1.ActiveView.Id.ToString();
			//MessageBox.Show(view);
		}

		private void dateNavigator1_SelectionChanged(object sender, EventArgs e)
		{
			//// Prevent the DateNavigator from automatically changing the Scheduler's date
			//// You can apply custom logic here if needed
			//DateNavigator dateNavigator = sender as DateNavigator;

			//if (dateNavigator != null)
			//{
			//	// Prevent default behavior by reapplying the current scheduler's date
			//	schedulerControl1.ActiveView.SetSelection(DateTime.Today);
			//}

			//MessageBox.Show("DateNavigator selection changed, but Scheduler's view remains unchanged!");
		}

		//public override void ResetOptions()
		//{
		//	base.ResetOptions();
		//	Scheduler.BeginUpdate();
		//	try
		//	{
		//		this.chkShowRightTimeRuler.Checked = true;
		//		this.chkShowWorkTimeOnly.Checked = true;
		//		this.chkShowAllDayArea.Checked = true;
		//		this.chkShowDayHeaders.Checked = true;
		//		this.chkShowOverAppointment.Checked = false;
		//		this.chkStatusOrientation.Checked = true;
		//		this.chkAllowHtmlText.Checked = true;
		//		this.spinDaysCount.EditValue = 3;
		//		this.chkColorizeResources.Checked = true;

		//		this.cbAllDayStatus.EditValue = AppointmentStatusDisplayType.Bounds;
		//		this.cbStatus.EditValue = AppointmentStatusDisplayType.Bounds;
		//		this.cbSnapToCellsMode.EditValue = AppointmentSnapToCellsMode.Auto;
		//		this.cbTimeIndicatorVisibility.EditValue = TimeIndicatorVisibility.TodayView;
		//		this.cbTimeMarkerVisibility.EditValue = TimeMarkerVisibility.Always;
		//	}
		//	finally
		//	{
		//		Scheduler.EndUpdate();
		//	}
		//}
	}

	public enum VType
	{
		DayView,
		WorkWeekView,
		WeekView,
		MonthView,
		TimelineView,
		AgendaView,
		YearView
	}

	public class LocationData
	{
		public int Id { get; set; }
		public string Caption { get; set; }
	}

	public class Calendar
	{
		public int Id { get; set; }
		public string Caption { get; set; }
		public int ParentId { get; set; }
	}

	public static class TimeRegionHelper
	{
		static DateTime BaseDate { get; set; }
		static TimeSpan Start { get; set; }
		static TimeSpan End { get; set; }

		static TimeRegionHelper()
		{
			BaseDate = DateTimeHelper.GetStartOfWeek(DateTime.Today).AddDays(-15);
			Start = TimeSpan.FromHours(13);
			End = TimeSpan.FromHours(14);
		}

		public static void Attach(SchedulerControl scheduler)
		{
			TimeRegion timeRegion1 = new TimeRegion();
			timeRegion1.Start = BaseDate + Start;
			timeRegion1.End = BaseDate + End;
			timeRegion1.Editable = false;
			timeRegion1.Recurrence = new RecurrenceInfo();
			timeRegion1.Recurrence.Start = timeRegion1.Start;
			timeRegion1.Recurrence.Type = RecurrenceType.Weekly;
			timeRegion1.Recurrence.WeekDays = WeekDays.WorkDays;
			scheduler.TimeRegions.Add(timeRegion1);

			TimeRegion timeRegion2 = new TimeRegion();
			timeRegion2.Start = BaseDate;
			timeRegion2.End = BaseDate.AddDays(1);
			timeRegion2.Editable = false;
			timeRegion2.Recurrence = new RecurrenceInfo();
			timeRegion2.Recurrence.Start = timeRegion2.Start;
			timeRegion2.Recurrence.Type = RecurrenceType.Weekly;
			timeRegion2.Recurrence.WeekDays = WeekDays.WeekendDays;
			scheduler.TimeRegions.Add(timeRegion2);

			scheduler.TimeRegionCustomize += (s, e) =>
			{
				if (e.Appointment == null)
					return;
				if (e.Appointment.StatusKey.Equals(3))
					e.Editable = true;
			};
			//SvgImage svgImage = DemoUtils.GetResourceSvgImage("Images.Dinner.svg");
			//scheduler.CustomDrawTimeRegion += (s, e) => {
			//	if (e.TimeRegion == timeRegion2)
			//		return;
			//	e.DrawDefault();
			//	Rectangle bounds = new Rectangle(e.Bounds.X, e.Bounds.Y, e.Bounds.Width, e.Bounds.Height);
			//	double scaleFactor = (double)bounds.Height / svgImage.Height;
			//	Image img = svgImage.Render(null, Math.Min(scaleFactor, 1));
			//	int x = e.Bounds.Location.X + (e.Bounds.Width / 2 - img.Width / 2);
			//	int y = e.Bounds.Location.Y + (e.Bounds.Height / 2 - img.Height / 2);
			//	e.Cache.DrawImage(img, new Point(x, y));
			//	e.Handled = true;
			//};

			scheduler.PopupMenuShowing += (s, e) =>
			{
				if (scheduler.SelectedAppointments.Any(x => IsIntersectWithRegion(x.Start, x.End)))
					e.Menu.RemoveMenuItem(SchedulerMenuItemId.StatusSubMenu);
			};
		}

		public static bool IsIntersectWithRegion(DateTime start, DateTime end)
		{
			if (IsWeekEnd(start) || IsWeekEnd(end))
				return true;
			TimeInterval interval = new TimeInterval(start, end);
			TimeInterval regionInterval = new TimeInterval(BaseDate, DateTime.MaxValue);
			if (!regionInterval.IntersectsWith(interval))
				return false;
			TimeOfDayInterval dayInterval = new TimeOfDayInterval(start.TimeOfDay, start.TimeOfDay + interval.Duration);
			TimeOfDayInterval dayRegionInterval = new TimeOfDayInterval(Start, End);
			return dayInterval.IntersectsWithExcludingBounds(dayRegionInterval);
		}

		static bool IsWeekEnd(DateTime dateTime)
		{
			return dateTime.DayOfWeek == DayOfWeek.Sunday || dateTime.DayOfWeek == DayOfWeek.Saturday;
		}
	}
}