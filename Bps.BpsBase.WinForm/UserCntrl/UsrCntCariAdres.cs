using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Utilities.Helpers;
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
    public partial class UsrCntCariAdres : UserControl
    {
        private  CRADRS _adresModel;
        private readonly CRADRS _oldadresModel;
        private readonly Global _global;
        public IGnthrkService _gnthrkService;
        public IGnlkhrService _gnlkhrService;
        public IGntipiService _gntipiService;
        private string _ulkeTipKod, _sehirTipKod, _ilceTipKod, _semtTipKod, _mahalleTipKod;

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            var changes = CloneHelper.FindDifferences(_oldadresModel, _adresModel);
            CloneHelper.RevertChanges(_adresModel, changes);
            cRADRSBindingSource.DataSource = _adresModel;
            cRADRSBindingSource.ResetBindings(false);

            this.Dispose();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        public UsrCntCariAdres()
        {
            InitializeComponent();
        }
        public UsrCntCariAdres(CRADRS adresModel, Global global)
        {
            InitializeComponent();
            _adresModel = adresModel;
            _oldadresModel= adresModel.ShallowCopy();
             _global = global;
        }

        private void UsrCntCariAdres_Load(object sender, EventArgs e)
        {
            if (_adresModel != null)
            {
                cRADRSBindingSource.DataSource = _adresModel;
                
            }
            _ulkeTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(_global, "ULKEKD", false).Nesne.TIPKOD;
            _sehirTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(_global, "SEHRKD", false).Nesne.TIPKOD;
            _ilceTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(_global, "ILCEKD", false).Nesne.TIPKOD;
            _semtTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(_global, "SEMTKD", false).Nesne.TIPKOD;
            _mahalleTipKod = _gntipiService.Ncch_GetByTeknikAd_NLog(_global, "MAHAKD", false).Nesne.TIPKOD;

            var ulkeList = _gnlkhrService.Cch_GetListByTipKod(_global, _ulkeTipKod, false).Items;
            LkEdUlke.Properties.DataSource = ulkeList;
        }

        private void LkEdUlke_EditValueChanged(object sender, EventArgs e)
        {
            LkEdSehir.EditValue = null;
            LkEdSehir.Properties.DataSource = null;
           
            var tip = LkEdUlke.GetSelectedDataRow() as GNLKHR;
            if (tip == null) return;

            if (LkEdUlke.EditValue != null)
            {
                var data = (CRADRS)cRADRSBindingSource.Current;

                var sehirList = _gnlkhrService.Cch_GetListByTipKodAndParent(_global, _sehirTipKod, tip.Id, false).Items;
                LkEdSehir.Properties.DataSource = sehirList;
                LkEdSehir.EditValue = data.SEHRKD;
            }
        }
    }
}
