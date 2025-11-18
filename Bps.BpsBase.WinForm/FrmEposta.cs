using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.CR.Listed;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.Core.Entities;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using Convert = Bps.Core.Utilities.Converters.Convert;


namespace BPS.Windows.Forms
{
    public partial class FrmEposta : Form
    {
        public CariEmailModel emailModel;

        private List<CariEmailModel> _emailList;

        public FrmEposta(List<CariEmailModel> emailList)
        {
            _emailList = emailList;
            InitializeComponent();
        }

        private void FrmEposta_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = _emailList;
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridControl1.PointToClient(Control.MousePosition);

            GridHitInfo info = gridView1.CalcHitInfo(point);
            if (info.InRow || info.InRowCell)
            {
                emailModel = _emailList[info.RowHandle];
                Close();
            }
        }
    }
}
