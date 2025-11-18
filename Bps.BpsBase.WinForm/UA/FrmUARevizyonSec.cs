using System.Collections.Generic;

namespace BPS.Windows.Forms
{
    public partial class FrmUARevizyonSec : DevExpress.XtraEditors.XtraForm
    {
        List<string[]> revList;
        public string defaultRevNo = "";

        public FrmUARevizyonSec(List<string[]> rList)
        {
            InitializeComponent();
            revList = rList;
        }

        private void repButSec_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            string uaKodu = gridView1.GetFocusedRowCellDisplayText("UrunAgaciKodu");
            string vrykodu = gridView1.GetFocusedRowCellValue("VRKODU") as string ;   
            revList.Add(new string[] { uaKodu, "0", vrykodu });
            this.Close();
        }
    }
}