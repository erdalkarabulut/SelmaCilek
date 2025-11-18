using System;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Models.SH.Firestore;
using BPS.Google.Firestore;

namespace BPS.Windows.Forms
{
	public partial class FrmServisKullanici : BPS.Windows.Base.FrmChildBase
	{
		public FrmServisKullanici()
		{
			InitializeComponent();
		}

		private async void FrmServisKullanici_Load(object sender, EventArgs e)
		{
			Firestore.Initialize();
			List<User> users = await Firestore.GetDocuments<User>("users");

			gridControl1.DataSource = users;
		}

		private void gridView1_CellValueChanging(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
		{
			Dictionary<string, object> data = new Dictionary<string, object>();

			string id = gridView1.GetFocusedRowCellDisplayText("DocumentId");
			string field = "";

			if (e.Column.FieldName == "Admin") field = "admin";
			else if (e.Column.FieldName == "DigerIsemirleriYetki") field = "digerIsemirleriYetki";
			else if (e.Column.FieldName == "TamamlananlarYetki") field = "tamamlananlarYetki";
			
			data.Add(field, e.Value);

			Firestore.SetField("users", id, data);
		}
	}
}
