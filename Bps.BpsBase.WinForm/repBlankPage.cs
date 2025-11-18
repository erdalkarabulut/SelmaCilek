using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Bps.Core.Utilities.Helpers;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
    public partial class repBlankPage : DevExpress.XtraReports.UI.XtraReport
    {
        public repBlankPage()
        {
            InitializeComponent();
            xrPictureBox1.Image = ImageHelper.GetCompanyLogo("logo1");
        }

    }
}
