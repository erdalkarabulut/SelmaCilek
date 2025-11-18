using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
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
    
    public partial class UsrCntGenelVeriler : UserControl
    {
        private readonly SPFBAS _spfbasModel;
        private readonly List<CRCARI> _cariModelList;
        private readonly List<SPFTIP> _spftipModelList;
        private readonly List<STKFYT> _fiyatnoModelList;
        private readonly List<GNDPTN> _depoModelList;
        private readonly Global _global;
        private SPFTIP _spftip;
        public IGnthrkService _gnthrkService;
        public UsrCntGenelVeriler()
        {
            InitializeComponent();
        }
        public UsrCntGenelVeriler(SPFBAS spfbasModel, List<CRCARI> cariModelList, List<SPFTIP> spftipModelList,
            List<STKFYT> fiyatnoModelList, List<GNDPTN> depoModelList, Global global)
        {
            _spfbasModel = spfbasModel;
            _cariModelList = cariModelList;
            _spftipModelList = spftipModelList;
            _fiyatnoModelList = fiyatnoModelList;
            _depoModelList = depoModelList;
            _global = global;
            InitializeComponent();
        }

        private void UsrCntGenelVeriler_Load(object sender, EventArgs e)
        {
            sPFBASBindingSource.DataSource = _spfbasModel;
            gridLke1Cari1.Properties.DataSource = _cariModelList;
            gridLke1Cari2.Properties.DataSource = _cariModelList;
            gridLkeFisTip1.Properties.DataSource = _spftipModelList;
            var teknads = new List<string>() { "OLCUKD", "SPORKD", "SPDGKD", "DVCNKD", "LANGKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(_global, teknads, false).Items;

            var dagKanalList = teknadsResponse.Where(w => w.TEKNAD == "SPDGKD").ToList();
            var satOrgList = teknadsResponse.Where(w => w.TEKNAD == "SPORKD").ToList();
            var languageList = teknadsResponse.Where(w => w.TEKNAD == "LANGKD").ToList();
            var dovizList = teknadsResponse.Where(w => w.TEKNAD == "DVCNKD").ToList();
            _spftip = gridLkeFisTip1.GetSelectedDataRow() as SPFTIP;
            gridLkeSatisOrg.Properties.DataSource = satOrgList;
            gridLkeDgtKnl.Properties.DataSource = dagKanalList;
            dVCNKDGridLookUpEdit.Properties.DataSource = dovizList;
            gridLkeFiyatNo1.Properties.DataSource= _fiyatnoModelList.Where(f => f.STHRTP == _spftip.SPHRTY).ToList();
            DepoBindingChange();






        }

        private void DepoBindingChange()
        {
            if (_spftip.SPHRTY == 0)
            {
                gridLkeCikisDepo.DataBindings.Clear();
                gridLkeCikisDepo.DataBindings.Add("EditValue", sPFBASBindingSource, "GRDEPO", true, DataSourceUpdateMode.OnPropertyChanged);
                cKDEPOLabel.Text = "Giriş Depo:";
            }
            if (_spftip.SPHRTY == 1)
            {
                gridLkeCikisDepo.DataBindings.Clear();
                gridLkeCikisDepo.DataBindings.Add("EditValue", sPFBASBindingSource, "CKDEPO", true, DataSourceUpdateMode.OnPropertyChanged);
                cKDEPOLabel.Text = "Çıkış Depo:";
            }
            gridLkeCikisDepo.Properties.DataSource = _depoModelList;

        }

        private void gridLkeFiyatNo1_EditValueChanged(object sender, EventArgs e)
        {
            var _fiyatno = gridLkeFiyatNo1.GetSelectedDataRow() as STKFYT;
            if (_fiyatno!=null)
            {
                if (_spfbasModel.DOVTRH == null)
                {
                    _spfbasModel.DOVTRH = DateTime.Now.Date;
                }
                _spfbasModel.DVCNKD = _fiyatno.DVCNKD;
            }
            
        }

        private void gridLke1Cari1_EditValueChanged(object sender, EventArgs e)
        {
            var _Spcari = gridLke1Cari1.GetSelectedDataRow() as CRCARI;
            if (_Spcari != null)
            {
                _spfbasModel.CRHRKD = _Spcari.CRHRKD;
            }
        }
    }
}
