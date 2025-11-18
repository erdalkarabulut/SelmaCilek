using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Entities.Concrete.SP;

namespace BPS.Windows.Forms.SP
{
    public partial class FrmFisTipiSec : Form
    {
        public SPFTIP fisTipi = null;

        public FrmFisTipiSec()
        {
            InitializeComponent();
        }

        private void btnTamam_Click(object sender, EventArgs e)
        {

            fisTipi = gridLkeFisTip.GetSelectedDataRow() as SPFTIP;
            Close();
        }
    }
}
