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
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;

namespace BPS.Windows.Forms
{
    public partial class FrmYeniOpsiyon : Form
    {
        private Global _global;
        private GNOPHR _lastGnophr;
        public GNOPHR addedGnophr;

        private readonly IGnophrService _gnophrService;
        
        public FrmYeniOpsiyon(Global global, GNOPHR lastGnophr)
        {
            _global = global;
            _lastGnophr = lastGnophr;
            _gnophrService = InstanceFactory.GetInstance<IGnophrService>();
            InitializeComponent();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (txtOpsiyon.Text == "") return;

            int harkodInt = Convert.ToInt32(_lastGnophr.HARKOD) + 1;
            string harkod = String.Format("{0:00}", harkodInt);

            GNOPHR gnophr = new GNOPHR();

            gnophr.ACTIVE = true;
            gnophr.SLINDI = false;
            gnophr.TIPKOD = _lastGnophr.TIPKOD;
            gnophr.HARKOD = harkod;
            gnophr.TANIMI = txtOpsiyon.Text;
            gnophr.PARENT = 0;
            gnophr.SIRASI = _lastGnophr.SIRASI + 1;

            StandardResponse<GNOPHR> response = _gnophrService.Ncch_Add_NLog(gnophr, _global);
            if (response.Status == ResponseStatusEnum.OK) 
            {
               addedGnophr = response.Nesne;
               Close();
            }
        }
    }
}
