using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models;
using Bps.BpsBase.Entities.Models.CR.Listed;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.UA;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Mask;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraReports.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace BPS.Windows.Forms
{
    public partial class FrmSiparisler : BPS.Windows.Base.FrmChildBase
    {
        public string blgNo;
        public int fisTipi;

        private ISpfbasService _sinifService;
        private IGnkxmlService _sinifyerlesimService;
        public SPFTIP _spftip;
        private List<SPFTIP> _listSpftip;
        private GNKXML _sinifyerlesim;

        private ProjeMenuListed yetkiModel;
        private IList<SPFBAS> list;
        private string _action;
        private bool formLoaded = false;
        private bool loadingGrid = false;
        private bool _mailSent = false;

        private readonly IGnyetkService _gnyetkService;
        private readonly IGnthrkService _gnthrkService;
        private readonly ISpftipService _spftipService;
        private readonly ICrcariService _crcariService;
        private readonly ICradrsService _cradrsService;
        private readonly IGndptnService _gndptnService;
        private readonly IStkfytService _stkfytService;
        private readonly IStkfiyService _stkfiyService;
        private readonly IStkartService _stkartService;
        private readonly IStolcuService _stolcuService;
        private readonly ISpfharService _spfharService;
        private readonly ISpuropService _spuropService;
        private readonly ISturopService _sturopService;
        private readonly IGnoptpService _gnoptpService;
        private readonly IGnophrService _gnophrService;
        private readonly ICrytklService _crytklService;
        private readonly IDovkurService _dovkurService;
        private readonly IGnkullService _gnkullService;
        private readonly IStdepoService _stdepoService;
        private readonly ISthrktService _sthrktService;
        private readonly ISpodtbService _spodtbService;
        private readonly ISpkoslService _spkoslService;
        private readonly IStnameService _stnameService;
        private readonly IGnlkhrService _gnlkhrService;
        private readonly IUragacService _uragacService;
        private readonly ISirketService _sirketService;
        private readonly ISpfbasDal _spfbasDal;
        private readonly IXXService _xxService;
        private readonly IGnorhrService _gnorhrService;
        private readonly IGnyetbService _gnyetbService;

        private List<Grid> focusedRowHandler = new List<Grid>();
        private List<CRCARI> CariKarts;
        private List<STKFYT> fiyatNoList;
        private List<GNDPTN> depoList;
        private int _satirNo = 0;
        private Image imgRequired;
        private List<Dictionary<int, List<UrunOpsiyonModel>>> opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();
        private List<DOVKUR> dovkurList = new List<DOVKUR>();
        private List<UrunAgaciModulPaket> uaModulPaketList = new List<UrunAgaciModulPaket>();
        private List<GNYETB> ortamModel;

        public FrmSiparisler(ISpfbasService sinifService, IGnthrkService gnthrkService,
            ISpftipService spftipService, ICrcariService crcariService, ICradrsService cradrsService,
            IGndptnService gndptnService, IStkfytService stkfytService,
            IStkfiyService stkfiyService, IStkartService stkartService,
            IStolcuService stolcuService, ISpfharService spfharService, ISirketService sirketService,
            ISpuropService spuropService, IStnameService stnameService, IUragacService uragacService,
            IGnoptpService gnoptpService, IGnophrService gnophrService, IGnlkhrService gnlkhrService,
            ICrytklService crytklService, IXXService xxService, ISturopService sturopService,
            IGnyetkService gnyetkService, IGnkxmlService sinifyerlesimService,
            IDovkurService dovkurService, IGnkullService gnkullService, ISpkoslService spkoslService,
            IStdepoService stdepoService, ISthrktService sthrktService, ISpodtbService spodtbService, ISpfbasDal spfbasDal
            , IGnorhrService gnorhrService, IGnyetbService gnyetbService)
        {
            _gnthrkService = gnthrkService;
            _spftipService = spftipService;
            _crcariService = crcariService;
            _cradrsService = cradrsService;
            _gndptnService = gndptnService;
            _stkfytService = stkfytService;
            _stkfiyService = stkfiyService;
            _stkartService = stkartService;
            _stolcuService = stolcuService;
            _spfharService = spfharService;
            _spuropService = spuropService;
            _sturopService = sturopService;
            _crytklService = crytklService;
            _gnoptpService = gnoptpService;
            _gnophrService = gnophrService;
            _gnkullService = gnkullService;
            _stdepoService = stdepoService;
            _sthrktService = sthrktService;
            _spodtbService = spodtbService;
            _spkoslService = spkoslService;
            _stnameService = stnameService;
            _gnlkhrService = gnlkhrService;
            _uragacService = uragacService;
            _sirketService = sirketService;
            _xxService = xxService;
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _dovkurService = dovkurService;
            _spfbasDal = spfbasDal;
            _gnorhrService = gnorhrService;
            _gnyetbService = gnyetbService;
            InitializeComponent();

            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            dtBaslangic.EditValue = DateTime.Today.AddDays(-15);
            dtBitis.EditValue = DateTime.Today.AddDays(5);
        }



        private void FrmSiparis_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ortamModel = _gnyetbService.Cch_GetListYetkiId_NLog(yetkiModel.Id, global, false).Items;
            FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);
            barManager.Bars["Tools"].Visible = false;
            _listSpftip = _spftipService.Ncch_GetListBySphrtp_NLog(global).Items;
            depoList = _gndptnService.Cch_GetListAktif_NLog(global, false).Items;
            gridLkeFisTipTab1.Properties.DataSource = _listSpftip;
            GridHelper.ColumnRepositoryItems(sTFYNOGridLookUpEditView, global);
          
        }



        #region Standard

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
           
            BaslikLoad(1);


        }

        private void BaslikLoad(int butonTag) 
        {
            SPFBAS _baslik = new SPFBAS();
            if (butonTag == 1)
            {
                sPFBASBindingSource.AddNew();
                _baslik = (SPFBAS)sPFBASBindingSource.Current;
                _baslik.SPFTNO = _spftip.SPFTNO;
                _baslik.SIRKID = (int)global.SirketId;
                _baslik.SPORKD = _spftip.SPORKD;
                _baslik.SPDGKD = _spftip.SPDGKD;
                _baslik.BELTRH = DateTime.Now.Date;
                GetDovizKur(DateTime.Today);
            }
            else if (butonTag == 2)
            {
                _baslik = (SPFBAS)sPFBASBindingSource.Current;
            }
            userControlCariYukle(_baslik);
            userControlGenelVerilerYukle(_baslik);
            xtraTabControl1.SelectedTabPage = xtraTabPage3;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            BaslikLoad(2);
        }
        private void userControlCariYukle(SPFBAS sipbaslik)
        {
            
            var sipcari = _crcariService.Ncch_GetByCariKod_NLog(sipbaslik.CRKODU, global, false).Nesne;
            var sipadres = _cradrsService.Cch_GetListByCariKod_NLog(global, sipbaslik.CRKODU, false).Items.FirstOrDefault(f => f.Id == sipcari.FTADNO);

            var tescari = _crcariService.Ncch_GetByCariKod_NLog(sipbaslik.MALTES, global, false).Nesne;
            var tesadres = _cradrsService.Cch_GetListByCariKod_NLog(global, sipbaslik.MALTES, false).Items.FirstOrDefault(f => f.Id == tescari.FTADNO);
            
            var cntrlsip = new UsrCntCariBilgi(sipcari, sipadres, global);
            cntrlsip._gnthrkService = _gnthrkService;
            xTabPageSiparisVeren.Controls.Clear();
            xTabPageSiparisVeren.AddControl(cntrlsip);
            cntrlsip.Dock = DockStyle.Fill;
            var cntrltes = new UsrCntCariBilgi(tescari, tesadres, global);
            cntrltes._gnthrkService = _gnthrkService;
            xTabPageTeslimAlan.Controls.Clear();
            xTabPageTeslimAlan.AddControl(cntrltes);
            cntrltes.Dock = DockStyle.Fill;
        }
        private void userControlGenelVerilerYukle(SPFBAS sipbaslik)
        {
                       
            var cntrlgenelveriler = new UsrCntGenelVeriler(sipbaslik,CariKarts,_listSpftip,fiyatNoList,depoList,global);
            cntrlgenelveriler._gnthrkService = _gnthrkService;
            xTabPageGenelVeriler.Controls.Clear();
            xTabPageGenelVeriler.AddControl(cntrlgenelveriler);
            cntrlgenelveriler.Dock = DockStyle.Fill;
            
        }
        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Emin misiniz ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                sPFBASBindingSource.EndEdit();
                var data = (SPFBAS)sPFBASBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
        }
        protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                gridView1.OptionsBehavior.Editable = false;

                barManager.Bars["Tools"].Visible = false;
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
            }

            FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);
        }



        #endregion



        private void btnSiparisAra_Click(object sender, EventArgs e)
        {
            var spFistip = (gridLkeFisTipTab1.EditValue == null || gridLkeFisTipTab1.EditValue.ToString() == "") ? (int?)null : Convert.ToInt32(gridLkeFisTipTab1.EditValue);
            var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
            var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
            var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

            if (spFistip == null ) 
            {
                MessageBox.Show("Fiş tip giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtBaslangic == null && string.IsNullOrEmpty(belgeNo))
            {
                MessageBox.Show("Sipariş tarihi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(belgeNo)  && _spftip.KDVFLG == null)
            {
                MessageBox.Show(_spftip.TANIMI + " fiş tipi için KDV bakımı yapınız!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            LoadGrid();
            barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
            barManager.Bars["Tools"].Visible = true;
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        private void LoadGrid(SPFBAS selectedBaslik = null)
        {
            loadingGrid = true;
            var spFistip = (gridLkeFisTipTab1.EditValue == null || gridLkeFisTipTab1.EditValue == "")? (int?)null : Convert.ToInt32(gridLkeFisTipTab1.EditValue);
            var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
            var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
            var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

            var param = new SiparisParamModel()
            {
                SPDGKD = _spftip.SPDGKD,
                BELGEN = belgeNo,
                DtBaslangic = dtBas,
                DtBitis = dtBit,
                SPFTNO = spFistip,
                SPORKD = _spftip.SPORKD
            };

            //sPFHARBindingSource.DataSource = new List<SPFHAR>();

            list = _sinifService.Cch_GetListByParam_NLog(param, global, false).Items;
            sPFBASBindingSource.DataSource = list;
            sPFBASBindingSource.Position = -1;
            gridView1.FocusedRowHandle = GridControl.InvalidRowHandle;

            if (selectedBaslik != null)
            {
                int index = list.IndexOf(list.FirstOrDefault(s => s.BELGEN == selectedBaslik.BELGEN));
                sPFBASBindingSource.Position = index;
            }
            fiyatNoList = _stkfytService.Cch_GetListAktif_NLog(global, false).Items;
            repLkeBaslikFiyatNo.DataSource = fiyatNoList.Where(f => f.STHRTP == _spftip.SPHRTY).ToList();
            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            focusedRowHandler.Clear();
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            CariKarts = _crcariService.Cch_GetList_NLog(global, false).Items;
            repLkeBaslikCari.DataSource = CariKarts;
            GridHelper.ColumnRepositoryItems(gridView1, global);
            loadingGrid = false;

        }


        protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.OptionsView.ShowAutoFilterRow = gridView1.OptionsView.ShowAutoFilterRow == false;
        }
        protected override void barButShopifySip_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void gridView1_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
        }

        private void grdViewSipKalem_ShownEditor(object sender, EventArgs e)
        {

        }



        private void barButStokYenile_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void grdViewSipKalem_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {

        }

        private void grdViewSipKalem_CustomDrawCell(object sender, DevExpress.XtraGrid.Views.Base.RowCellCustomDrawEventArgs e)
        {

        }

        private void barButRezervasyon_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        private void gridLkeFisTipTab1_EditValueChanged(object sender, EventArgs e)
        {
            _spftip = gridLkeFisTipTab1.GetSelectedDataRow() as SPFTIP;
            
        }

       

       

        private void sPFBASBindingSource_CurrentItemChanged(object sender, EventArgs e)
        {
            if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                var _baslik = (SPFBAS)sPFBASBindingSource.Current;
                userControlCariYukle(_baslik);
            }

        }

        private void GetDovizKur(DateTime date)
        {
            bool alis = _spftip.SPHRTY == 1;

            var baslik = (SPFBAS)sPFBASBindingSource.Current;

            List<string> dvcnkdList = new List<string> { "USD", "EUR" };
            dovkurList = new List<DOVKUR>();
            foreach (var dovkod in dvcnkdList)
            {
                var response = _dovkurService.Cch_GetByDate_NLog(dovkod, date);
                if (response.Status == ResponseStatusEnum.OK && response.Nesne != null)
                {
                    var doviz = response.Nesne;
                    double? dovizFiyat = alis ? doviz.DVFYT1 : doviz.DVFYT2;

                    dovkurList.Add(doviz);
                    if (dovkod == "USD") baslik.USDFYT = Convert.ToDecimal(dovizFiyat);
                    else if (dovkod == "EUR") baslik.EURFYT = Convert.ToDecimal(dovizFiyat);
                }
                else
                {
                    if (baslik == null) return;
                    DOVKUR dovkur = new DOVKUR { DVCNKD = dovkod, DOVTRH = date };
                    dovkur = _dovkurService.GetDovizKuru(dovkur);
                    double? dovizFiyat = alis ? dovkur.DVFYT1 : dovkur.DVFYT2;

                    if (dovkur != null && dovizFiyat > 0)
                    {
                        dovkur.DOVTRH = date;
                        _dovkurService.Ncch_AutoAdd_NLog(dovkur, global);
                    }

                    if (dovkod == "USD") baslik.USDFYT = dovkur != null ? Convert.ToDecimal(dovizFiyat) : 0;
                    else if (dovkod == "EUR") baslik.EURFYT = dovkur != null ? Convert.ToDecimal(dovizFiyat) : 0;
                }
            }
        }


    }
}