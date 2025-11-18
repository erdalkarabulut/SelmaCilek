using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Bps.BpsBase.Entities.Concrete.CR;
using DevExpress.XtraBars;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BPS.Windows.Forms
{
    public partial class FrmYetkiliSec : Form
    {
        public List<CRYTKL> yetkililer;
        public int id = 0;

        public FrmYetkiliSec()
        {
            InitializeComponent();
        }

        private void FrmYetkiliSec_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = yetkililer;
            gridView1.BestFitColumns();
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridView1.GridControl.PointToClient(MousePosition);

            GridHitInfo info = gridView1.CalcHitInfo(point);
            if (info.InRow || info.InRowCell)
            {
                id = gridView1.GetRowCellValue(info.RowHandle, "Id").ToInt32();
                Close();
            }
        }
    }
}
