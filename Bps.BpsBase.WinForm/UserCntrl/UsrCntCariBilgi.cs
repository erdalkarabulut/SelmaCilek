using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.Core.GlobalStaticsVariables;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BPS.Windows.Forms
{
    public partial class UsrCntCariBilgi : UserControl
    {
        private readonly CRCARI _cariModel;
        private readonly CRADRS _adresModel;
        private readonly Global _global;
        public IGnthrkService _gnthrkService;

        public UsrCntCariBilgi()
        {
            InitializeComponent();
        }
        public UsrCntCariBilgi(CRCARI cariModel,CRADRS adresModel,Global global)
        {
            InitializeComponent();
            _cariModel = cariModel;
            _adresModel = adresModel;
            _global = global;

        }

        private void UsrCntCariBilgi_Load(object sender, EventArgs e)
        {
            if (_cariModel != null)
            {
                cRCARIBindingSource.DataSource = _cariModel;
                var teknads = new List<string>() { "CRHRKD", "CRBGKD", "DVCNKD" };
                var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(_global, teknads, false);
                var cariTurList = teknadsResponse.Items.Where(w => w.TEKNAD == "CRHRKD").ToList();
                LkEdCariTur.Properties.DataSource = cariTurList;
            }
                
            if (_adresModel!= null)
            {
                cRADRSBindingSource.DataSource = _adresModel;
            }
            
        }
    }
}
