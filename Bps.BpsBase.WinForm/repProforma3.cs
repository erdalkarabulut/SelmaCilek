using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Linq;
using Bps.Core.Utilities.Helpers;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
    public partial class repProforma3 : DevExpress.XtraReports.UI.XtraReport
    {
        public repProforma3()
        {
            InitializeComponent();
            xrPictureBox1.Image = ImageHelper.GetCompanyLogo("logo1");
        }

        private void xrTable9_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            System.Collections.Generic.IEnumerable<XRRichText> richTextCollection = (sender as XRTable).AllControls<XRRichText>().ToList();
            foreach (XRRichText item in richTextCollection)
            {
                item.LocationF = new PointF(0, 0);
                item.SizeF = (item.Parent as XRTableCell).SizeF;
            }
        }
    }
}
