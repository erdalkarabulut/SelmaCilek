using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.GN;
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
    public partial class UsrCntOrgOnay : UserControl
    {
        private readonly List<GNORHR> _model;
        public IGnkullService _gnkullService;
        public IXXService _xxService;
        private readonly Global _global;
        public UsrCntOrgOnay()
        {
            InitializeComponent();
            
        }
        public UsrCntOrgOnay(List<GNORHR> model, Global global)
        {
            
            
            InitializeComponent();
            _model = model;
            _global = global;
            

        }

        private void UsrCntOrgOnay_Load(object sender, EventArgs e)
        {
            gridControl1.DataSource = null;
           var kullist = _gnkullService.Cch_GetAll_NLog(_global).Items;
            repositoryItemLookUpEdit1.DataSource = kullist;
            repositoryItemLookUpEdit2.DataSource = kullist;
            gridControl1.DataSource = _model;
             
        }

        private void contextMenuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            if (e.ClickedItem.Text == "Onayla")
            {
                var firstUser = _model   
                   .OrderByDescending(o => o.SIRASI).FirstOrDefault();
                if (firstUser == null) return;

                var sonuc = _xxService.Ncch_OrganizasyonHareketOnay_Log(firstUser.ORGKOD, firstUser.TABLNM, firstUser.TABLID, _global, true, true);
                if (sonuc.Status == Bps.Core.Response.ResponseStatusEnum.OK)
                {
                    firstUser.GNONAY = true;
                    firstUser.GNONTR = DateTime.Now;
                    e.ClickedItem.Enabled = false;
                    
                    toolOnayKaldir.Enabled = true;
                }
                gridControl1.RefreshDataSource();
                MessageBox.Show(sonuc.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            if (e.ClickedItem.Text == "Onay Kaldır")
            {
                var firstUser = _model
                   .OrderByDescending(o => o.SIRASI).FirstOrDefault();
                if (firstUser == null) return;
                var sonuc = _xxService.Ncch_OrganizasyonHareketOnay_Log(firstUser.ORGKOD, firstUser.TABLNM, firstUser.TABLID, _global, true, false);
                if (sonuc.Status == Bps.Core.Response.ResponseStatusEnum.OK)
                {
                    firstUser.GNONAY = false;
                    firstUser.GNONTR = null;
                    e.ClickedItem.Enabled = false;
                    toolOnayla.Enabled = true;
                }
                gridControl1.RefreshDataSource();
                MessageBox.Show(sonuc.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
