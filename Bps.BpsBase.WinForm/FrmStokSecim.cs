using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.Core.GlobalStaticsVariables;
using DevExpress.Utils.Extensions;

namespace BPS.Windows.Forms
{
    public partial class FrmStokSecim : Form
    {
        public STKART stkart = null;

        private Global _global;
        private string _stmalt;
        private string _stkodu;
        private IStmaltService _stmaltService;
        private IStkartService _stokKartService;
        private IGnthrkService _gnthrkService;

        public FrmStokSecim(Global global, string stkodu, string stmalt)
        {
            _global = global;
            _stmalt = stmalt;
            _stkodu = stkodu;
            _stmaltService = InstanceFactory.GetInstance<IStmaltService>();
            _stokKartService = InstanceFactory.GetInstance<IStkartService>();
            _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();

            InitializeComponent();
        }

        private void FrmStokSecim_Load(object sender, EventArgs e)
        {
            var teknads = new List<string>() { "MALGKD", "STANKD", "STALKD"};
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(_global, teknads, false);

            var malzemeTuruTanimList = _stmaltService.Cch_GetList_NLog(_global, false).Items;
            var malGrubuTanimList = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
            var anaGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").ToList();
            var altGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();

            LkEdMalzTuru.Properties.DataSource = malzemeTuruTanimList.OrderBy(m => m.STMLTR).ToList();
            LkEdMalzTuru.Properties.View.Columns["STBKDR"].Visible = false;
            LkEdMalzTuru.EditValue = _stmalt;
            
            repLkedMalGrubu.DataSource = malGrubuTanimList;
            repLkedStokAnaGrup.DataSource = anaGrupList;
            repLkedStokAltGrup.DataSource = altGrupList;
        }

        private void LkEdMalzTuru_EditValueChanged(object sender, EventArgs e)
        {
            if (LkEdMalzTuru.EditValue != null)
            {
                string malzemeTuru = LkEdMalzTuru.EditValue.ToString();
                
                var stokList = _stokKartService.Cch_GetListByMalTur_NLog(_global, malzemeTuru, false).Items;
                stokList.Remove(s => s.STKODU == _stkodu);

                sTKARTBindingSource.DataSource = stokList;
                gridView1.BestFitColumns();
            }
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridView1.GridControl.PointToClient(MousePosition);
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = gridView1.CalcHitInfo(point);
            if (info.InRow || info.InRowCell)
            {
                stkart = sTKARTBindingSource.Current as STKART;
                Close();
            }
        }
    }
}
