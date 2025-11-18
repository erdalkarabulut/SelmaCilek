using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
    public partial class repPaketEtiket : DevExpress.XtraReports.UI.XtraReport
    {
        public repPaketEtiket()
        {
            InitializeComponent();
        }

        public repPaketEtiket ShallowCopy()
        {
            return (repPaketEtiket)this.MemberwiseClone();
        }
    }
}
