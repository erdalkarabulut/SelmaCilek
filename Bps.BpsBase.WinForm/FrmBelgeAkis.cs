using System;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete;
using Bps.Core.GlobalStaticsVariables;
using BPS.Windows.Forms.Helper;

namespace BPS.Windows.Forms
{
    public partial class FrmBelgeAkis : Form
    {
        public Global global;
        public string tableName;
        public int tableId;

        private ILogsService _sinifService;
        private Logs _sinif;
        public FrmBelgeAkis(Global _global, string _tableName, int? _tableId)
        {
            InitializeComponent();
            _sinifService = InstanceFactory.GetInstance<ILogsService>();
            global = _global;
            tableName = _tableName;
            tableId = _tableId ?? 0;
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            var result = _sinifService.Ncch_GetLogsByType_NLog(tableId, tableName, global, yetkiKontrol: false);
            belgeAkisModelBindingSource.DataSource = result.Items;
            GridHelper.ColumnRepositoryItems(gridView1, global);
        }
    }
}
