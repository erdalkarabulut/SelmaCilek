using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;

namespace BPS.Windows.Forms
{
    public partial class FrmParcaSecim : DevExpress.XtraEditors.XtraForm
    {
        public Global global;
        public string parcaKodu = "";
        public string parcaAdi = "";

        private readonly IGnthrkService _gnthrkService;

        public FrmParcaSecim()
        {
            InitializeComponent();
            _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        }

        private void FrmParcaSecim_Load(object sender, EventArgs e)
        {
            var teknads = new List<string>() { "MAPRKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            var parcaTanimList = teknadsResponse.Items;

            gridControl1.DataSource = parcaTanimList;
        }

        protected override bool ProcessDialogKey(Keys keyData)
        {
            if (Form.ModifierKeys == Keys.None && keyData == Keys.Escape)
            {
                parcaKodu = "";
                parcaAdi = "";

                this.Close();
                return true;
            }
            return base.ProcessDialogKey(keyData);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridControl1.PointToClient(Control.MousePosition);
            GridHitInfo info = gridView1.CalcHitInfo(point);

            if (info.InRow || info.InRowCell)
            {
                parcaKodu = gridView1.GetFocusedRowCellDisplayText("HARKOD");
                parcaAdi = gridView1.GetFocusedRowCellDisplayText("TANIMI");
                this.Close();
            }
        }

        private void gridView1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return) gridControl1_DoubleClick(null, null);
        }

        private void FrmParcaSecim_Shown(object sender, EventArgs e)
        {
            gridView1.FocusedRowHandle = GridControl.AutoFilterRowHandle;
            gridView1.FocusedColumn = gridView1.Columns[1];
        }
    }
}