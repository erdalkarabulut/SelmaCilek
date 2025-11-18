using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.BpsBase.Entities.Models.Firestore;
using Bps.BpsBase.Entities.Models.SH.Firestore;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Utilities.Helpers;
using BPS.Google.Firestore;


namespace BPS.Windows.Service
{
	public partial class frmService : Form
	{
		[DllImport("user32.dll")]
		public static extern bool LockWorkStation();

		public frmService()
		{
			InitializeComponent();
			Firestore.Initialize();
			if (Param.ADAPTATION == Adaptation.Bala) Firestore.ListenWorkOrder();
			//Firestore.ListenRequest();
			Firestore.ListenRequests(); //EFI
		}

		private async void frmService_Shown(object sender, EventArgs e)
		{
			//LockWorkStation();

			grdKullanici.DataSource = Firestore.users;
		}

		private async void button1_Click_1(object sender, EventArgs e)
		{
			//var j = PassHelper.GeneratePassword("user");

			List<Order> objs = await Firestore.GetDocuments<Order>("orders");
			gridControl1.DataSource = objs[0];
			gridView1.BestFitColumns();

			gridView1.ExportToXlsx(@"D:\fgfgfg.xlsx");
		}

		private async void repButChangePassword_Click(object sender, EventArgs e)
		{
			string id = grdVwKullanici.GetFocusedRowCellValue("DocumentId").ToString();
			await Firestore.ChangeUserPasswordAsync(id);
		}
	}
}
