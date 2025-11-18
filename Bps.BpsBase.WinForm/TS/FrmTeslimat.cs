using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.TS;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.TS;
using Bps.BpsBase.Entities.Models;
using Bps.Core.Web.Model;
using Bps.Core.Utilities.WinForm;
using BPS.Windows.Forms.Helper;
using System.Linq;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.SP;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Bps.BpsBase.Entities.Models.TS;
using Bps.Core.GlobalStaticsVariables;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using Bps.Core.Response;

namespace BPS.Windows.Forms
{
    public partial class FrmTeslimat : Base.FrmChildBase
    {
        private ITsfbasService _sinifService;
        private IGnkxmlService _sinifyerlesimService;

        private ProjeMenuListed yetkiModel;
        private IList<TSFBAS> list;
        private string _action;
        private bool formLoaded = false;
        private bool loadingGrid = false;

        private GNKXML _sinifyerlesim;

        private readonly ITsfharService _tsfharService;
        private readonly IGnyetkService _gnyetkService;
        private readonly ITsftipService _tsftipService;
        private readonly IGnkullService _gnkullService;
        private readonly IGnthrkService _gnthrkService;
        private readonly ICrcariService _crcariService;
        private readonly IGndptnService _gndptnService;
        private readonly ISpfbasService _spfbasService;
        private readonly ISpfharService _spfharService;
        private readonly ICradrsService _cradrsService;
        private readonly IStdepoService _stdepoService;
        private readonly ISthrktService _sthrktService;
        private readonly IXXService _xxService;

        private List<Grid> focusedRowHandler = new List<Grid>();
        public List<CRCARI> CariKarts = new List<CRCARI>();
        private int _satirNo = 0;
        private List<Dictionary<int, List<UrunOpsiyonModel>>> opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

        public FrmTeslimat(ITsfbasService sinifService, IGnkxmlService sinifyerlesimService,
            IGnyetkService gnyetkService, ITsftipService tsftipService, IGnkullService gnkullService,
            IGnthrkService gnthrkService, ITsfharService tsfharService, ICrcariService crcariService,
            IGndptnService gndptnService, ISpfbasService spfbasService, ICradrsService cradrsService,
            ISpfharService spfharService, IStdepoService stdepoService, ISthrktService sthrktService,
            IXXService xxService)
        {
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _tsftipService = tsftipService;
            _gnkullService = gnkullService;
            _gnthrkService = gnthrkService;
            _tsfharService = tsfharService;
            _crcariService = crcariService;
            _gndptnService = gndptnService;
            _spfbasService = spfbasService;
            _spfharService = spfharService;
            _cradrsService = cradrsService;
            _stdepoService = stdepoService;
            _sthrktService = sthrktService;
            _xxService = xxService;
            InitializeComponent();

            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            dtBaslangic.EditValue = DateTime.Today.AddDays(-5);
            dtBitis.EditValue = DateTime.Today.AddDays(5);
        }

        private void FrmTeslimat_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            FormIslemleri.FormYetki2(barManager, yetkiModel);

            _satirNo = 0;
            barManager.Bars["Tools"].Visible = false;

            GridHelper.ColumnRepositoryItems(gridView1, global);

            //List<STKART> stokList = _stkartService.Cch_GetListAktif_NLog(global, false).Items;

            if (global.Sira == 0) // Satınalma
            {
                var globalCopy = global.ShallowCopy();
                globalCopy.Sira = 3;
                
                var kullaniciList = _gnkullService.Ncch_GetOnlyAdSoyad_NLog(global, false).Items;

                repLkedKul1.DataSource = repLkedKul2.DataSource = kullaniciList;

                colMLKBTR.Caption = "Mal Kabul Tarihi";
                colCKDEPO1.Visible = false;

                foreach (Control control in xtraTabPage1.Controls)
                {
                    if (control.Tag != null && control.Tag.ToString() == "1")
                    {
                        control.Visible = false;
                    }
                }
            }
            else if (global.Sira == 1) // Satış
            {
                //stokList = stokList.Where(s => s.STMLTR == Param.MAMUL_KODU).ToList();
                colGRMKTR.Caption = "Çıkış Miktarı";
                colGROLBR.Caption = "Çıkış Ölçü Birimi";
                colMLKBTR.Caption = "Makine (Ürün) Sevk Tarihi";
                colGRDEPO1.Visible = false;

                foreach (Control control in xtraTabPage1.Controls)
                {
                    if (control.Tag != null && control.Tag.ToString() == "0")
                    {
                        control.Visible = false;
                    }
                }
            }

            var teknads = new List<string>() { "OLCUKD", "SPORKD", "SPDGKD", "DVCNKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false).Items;

            var dagKanalList = teknadsResponse.Where(w => w.TEKNAD == "SPDGKD").ToList();
            var satOrgList = teknadsResponse.Where(w => w.TEKNAD == "SPORKD").ToList();

            sPORKDGridLookUpEdit.Properties.DataSource = satOrgList;
            repLkedSporkd.DataSource = satOrgList;
            sPDGKDGridLookUpEdit.Properties.DataSource = dagKanalList;
            repLkedSpdgkd.DataSource = dagKanalList;
            gridLkeDgtKnl.Properties.DataSource = dagKanalList;
            gridLkeSatisOrg.Properties.DataSource = satOrgList;

            CariKarts = _crcariService.Cch_GetList_NLog(global, false).Items;

            gridLke1Cari1.Properties.DataSource = CariKarts;
            gridLke1Cari2.Properties.DataSource = CariKarts;
            gridLke0Cari1.Properties.DataSource = CariKarts;
            gridLke0Cari2.Properties.DataSource = CariKarts;

            repLkeBaslikCari.DataSource = CariKarts;

            var fisTipList = _tsftipService.Ncch_GetListBySira_NLog(global, false).Items;
            gridLkeFisTipTab1.Properties.DataSource = fisTipList;
            gridLkeFisTip1.Properties.DataSource = fisTipList;
            gridLkeFisTip0.Properties.DataSource = fisTipList;

            if (global.Sira == 0) //Satınalma ise satış org. ve dağıtımın kanalı sütunlarını kaldır
            {
                gridLkeFisTipTab1.Properties.View.Columns.RemoveAt(2);
                gridLkeFisTipTab1.Properties.View.Columns.RemoveAt(2);
            }

            var depoList = _gndptnService.Cch_GetListAktif_NLog(global, false).Items;
            gridLkeGirisDepo.Properties.DataSource = depoList;
            gridLkeCikisDepo.Properties.DataSource = depoList;

            #region Kalem

            GetStokMiktarRapor();
            //repSipKalemStokKod.DataSource = stokList;
            //repSipKalemFiyatNo.DataSource = fiyatNoList;
            repLkedOlcuBirimi.DataSource = teknadsResponse.Where(w => w.TEKNAD == "OLCUKD").ToList();
            repLkeDepo.DataSource = depoList;

            #endregion

            grdViewTesKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grdViewTesKalem.OptionsNavigation.EnterMoveNextColumn = true;
            grdViewTesKalem.OptionsBehavior.Editable = true;
            grdViewTesKalem.OptionsBehavior.ReadOnly = false;

            GridHelper.ColumnRepositoryItems(grdViewTesKalem, global);

            formLoaded = true;
        }

        private void GetStokMiktarRapor()
        {
            var stokMiktarList = _stdepoService.GetStokMiktarRapor(global).Items;

            if (stokMiktarList != null && stokMiktarList.Count > 0)
            {
                var stokMiktarByPartiList = _sthrktService.GetStokMiktarFromHareketByParti(global).Items;

                DataSet dataSet = new DataSet();
                dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarList));
                dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarByPartiList));

                DataColumn keyColumn = dataSet.Tables[0].Columns["STKODU"];
                DataColumn keyColumn2 = dataSet.Tables[0].Columns["DPKODU"];
                DataColumn foreignKeyColumn = dataSet.Tables[1].Columns["STKODU"];
                DataColumn foreignKeyColumn2 = dataSet.Tables[1].Columns["DPKODU"];

                DataRelation dr = new DataRelation("Parti Stok", new[] { keyColumn, keyColumn2 }, new[] { foreignKeyColumn, foreignKeyColumn2 });
                dataSet.Relations.Add(dr);

                repSipKalemStokKod.DataSource = null;
                repSipKalemStokKod.DataSource = dataSet.Tables[0];
                gridView7.BestFitColumns();
            }
        }

        private void btnSipSec_Click(object sender, EventArgs e)
        {
            var sipNo = repLkeSiparis.EditValue == null ? "" : repLkeSiparis.EditValue.ToString();
            if (string.IsNullOrEmpty(sipNo))
            {
                MessageBox.Show("Sipariş seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var siparis = (SPFBAS)repLkeSiparis.GetSelectedDataRow();
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(2), yetkiModel);
            _action = "insert";
            opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

            var fistip = Convert.ToInt32(gridLkeFisTipTab1.EditValue);
            tLBLNOGridLookUpEdit.Enabled = true;
            //gridLkeFisTip0.EditValue = fistip;
            gridLkeFisTip1.EditValue = fistip;

            var rowView = (TSFBAS)tSFBASBindingSource.AddNew();
            if (rowView != null)
            {
                rowView.ACTIVE = true;
                rowView.TSFTNO = fistip;
                rowView.BELTRH = DateTime.Today;

                rowView.CRKODU = siparis.CRKODU;
                rowView.MALTES = siparis.MALTES;
                rowView.SPDGKD = siparis.SPDGKD;
                rowView.SPORKD = siparis.SPORKD;
                rowView.CKDEPO = siparis.CKDEPO;
                rowView.TERTAR = siparis.TERTAR;
                rowView.STFYNO = siparis.STFYNO.ToString();
            }

            //GetDovizKur(DateTime.Today);

            tSFHARBindingSource.DataSource = new List<TSFHAR>();

            var sipKalemList = _spfharService.Cch_GetListByBelge_NLog(siparis.BELGEN, global).Items;

            _satirNo = 0;
            foreach (var spfhar in sipKalemList)
            {
                _satirNo = _satirNo + 100;
                var newTesKalem = new TSFHAR();
                newTesKalem.SATIRN = _satirNo;
                newTesKalem.STKODU = spfhar.STKODU;
                newTesKalem.STKNAM = spfhar.STKNAM;
                newTesKalem.CKDEPO = spfhar.CKDEPO;
                newTesKalem.SPDGKD = spfhar.SPDGKD;
                newTesKalem.SPORKD = spfhar.SPORKD;
                newTesKalem.OLCUKD = spfhar.OLCUKD;
                newTesKalem.GROLBR = spfhar.OLCUKD;
                newTesKalem.GNMKTR = spfhar.GNMKTR;
                newTesKalem.GRMKTR = spfhar.GRMKTR;
                newTesKalem.AGOLKD = spfhar.AGOLKD;
                newTesKalem.BRTAGR = spfhar.BRTAGR;
                newTesKalem.NETAGR = spfhar.NETAGR;

                newTesKalem.REFBEL = spfhar.BELGEN;
                newTesKalem.REFKLM = spfhar.SATIRN;

                tSFHARBindingSource.Add(newTesKalem);
            }

            if (global.Sira == 1)
            {
                TabControlTesEkle(true);
            }

            TabControl();
            
            tSFBASBindingSource.CurrencyManager.Refresh();

            xtraTabControl1.SelectedTabPage = xtraTabPage3;
            xtraTabControl2.SelectedTabPage = global.Sira == 0 ? tabGenelVeriler0 : tabGenelVeriler1;
        }

        private void btnTeslimatAra_Click(object sender, EventArgs e)
        {
            var spFistip = (gridLkeFisTipTab1.EditValue == null || gridLkeFisTipTab1.EditValue.ToString() == "") ? (int?)null : Convert.ToInt32(gridLkeFisTipTab1.EditValue);
            var satisOrg = sPORKDGridLookUpEdit.EditValue == null ? "" : sPORKDGridLookUpEdit.EditValue.ToString();
            var dagitimKnl = sPDGKDGridLookUpEdit.EditValue == null ? "" : sPDGKDGridLookUpEdit.EditValue.ToString();
            var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
            var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
            var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

            if (spFistip == null && string.IsNullOrEmpty(belgeNo))
            {
                MessageBox.Show("Fiş tip giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (dtBaslangic == null && string.IsNullOrEmpty(belgeNo))
            {
                MessageBox.Show("Teslimat tarihi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            var selectedRow = (TSFTIP)gridLkeFisTipTab1.GetSelectedDataRow();


            if (selectedRow.GNONAY == false)
            {
                MessageBox.Show(selectedRow.TANIMI + " fiş tipi onaylanmamış!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            //var fiyatNoList = _stkfytService.Cch_GetListByKdvFlag_NLog(selectedRow.KDVFLG.Value, global, false).Items;
            //var fiyatNoList = _stkfytService.Cch_GetAll_NLog(global, false).Items;
            //var satinAlmaFiyatNoList = fiyatNoList.Where(f => f.STHRTP == 0 && f.ACTIVE && !f.SLINDI).ToList();
            //var satisFiyatNoList = fiyatNoList.Where(f => f.STHRTP == 1 && f.ACTIVE && !f.SLINDI).ToList();

            //gridLkeFiyatNo0.Properties.DataSource = satinAlmaFiyatNoList;
            //gridLkeFiyatNo1.Properties.DataSource = satisFiyatNoList;
            //repLkeBaslikFiyatNo.DataSource = global.Sira == 0 ? satinAlmaFiyatNoList : satisFiyatNoList;
            //repSipKalemFiyatNo.DataSource = global.Sira == 0 ? satinAlmaFiyatNoList : satisFiyatNoList;
            repLkeBaslikFiyatNo.BestFitMode = BestFitMode.BestFitResizePopup;
            //repSipKalemFiyatNo.BestFitMode = BestFitMode.BestFitResizePopup;

            LoadGrid();

            _sinifyerlesim = _sinifyerlesimService.Ncch_GetByVarsayilan_NLog(global.UserKod,
                global.MenuName,
                global.MenuTag.Value, Convert.ToInt32(gridControl1.Tag)).Nesne;
            if (_sinifyerlesim != null)
            {
                byte[] byteArray = Encoding.ASCII.GetBytes(_sinifyerlesim.GRDXML);
                MemoryStream stream = new MemoryStream(byteArray);
                gridView1.RestoreLayoutFromStream(stream);
            }

            GridHelper.ColumnRepositoryItems(gridView1, global);

            //gridView1.Columns["KULKOD"].OptionsColumn.AllowEdit = false;
            //gridView1.SetRowCellValue(1, gridView1.Columns["KULKOD"], kulKod);

            barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
            barManager.Bars["Tools"].Visible = true;
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        private void LoadGrid(TSFBAS selectedBaslik = null)
        {
            loadingGrid = true;
            var spFistip = gridLkeFisTipTab1.EditValue == null ? (int?)null : Convert.ToInt32(gridLkeFisTipTab1.EditValue);
            var satisOrg = sPORKDGridLookUpEdit.EditValue == null ? "" : sPORKDGridLookUpEdit.EditValue.ToString();
            var dagitimKnl = sPDGKDGridLookUpEdit.EditValue == null ? "" : sPDGKDGridLookUpEdit.EditValue.ToString();
            var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
            var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
            var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

            var param = new TeslimatParamModel()
            {
                SPDGKD = dagitimKnl,
                BELGEN = belgeNo,
                DtBaslangic = dtBas,
                DtBitis = dtBit,
                TSFTNO = spFistip,
                SPORKD = satisOrg
            };

            tSFHARBindingSource.DataSource = new List<TSFHAR>();

            list = _sinifService.Cch_GetListByParam_NLog(param, global, false).Items;
            tSFBASBindingSource.DataSource = list;
            tSFBASBindingSource.Position = -1;
            gridView1.FocusedRowHandle = GridControl.InvalidRowHandle;

            if (selectedBaslik != null)
            {
                int index = list.IndexOf(list.FirstOrDefault(s => s.BELGEN == selectedBaslik.BELGEN));
                tSFBASBindingSource.Position = index;
            }

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            focusedRowHandler.Clear();
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            loadingGrid = false;


            //grdViewTesKalem.OptionsBehavior.Editable = true;
            grdViewTesKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            grdViewTesKalem.Columns[0].OptionsColumn.AllowEdit = false;
            grdViewTesKalem.Columns[8].OptionsColumn.AllowEdit = false;
            grdViewTesKalem.Columns[9].OptionsColumn.AllowEdit = false;
        }

        #region Standard

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";
            opsiyonList = new List<Dictionary<int, List<UrunOpsiyonModel>>>();

            var fistip = Convert.ToInt32(gridLkeFisTipTab1.EditValue);
            tLBLNOGridLookUpEdit.Enabled = true;
            //gridLkeFisTip0.EditValue = fistip;
            gridLkeFisTip1.EditValue = fistip;

            gridLke0Cari1.EditValue = null;
            gridLke0Cari2.EditValue = null;
            gridLke1Cari1.EditValue = null;
            gridLke1Cari2.EditValue = null;

            //GetDovizKur(DateTime.Today);

            ClearCari1();
            ClearCari2();
            tSFHARBindingSource.DataSource = new List<TSFHAR>();
            xtraTabControl1.SelectedTabPage = xtraTabPage3;
            xtraTabControl2.SelectedTabPage = global.Sira == 0 ? tabGenelVeriler0 : tabTesSip;

            TabControl(true);

            if (global.Sira == 1)
            {
                TabControlTesEkle(false);
            }

            repLkeSiparis.Properties.DataSource = _spfbasService
                .Ncch_GetListByTesFisTip_NLog(Convert.ToInt32(gridLkeFisTipTab1.EditValue), global, false).Items;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";

            loadingGrid = true;

            tLBLNOGridLookUpEdit.Enabled = false;
            var baslik = (TSFBAS)tSFBASBindingSource.Current;
            tSFHARBindingSource.DataSource = _tsfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;
            
            xtraTabControl1.SelectedTabPage = xtraTabPage3;
            xtraTabControl2.SelectedTabPage = global.Sira == 0 ? tabGenelVeriler0 : tabGenelVeriler1;

            TabControl();

            grdViewTesKalem.BestFitColumns();
            loadingGrid = false;
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();

            try
            {
                var response = new StandardResponse();
                tSFBASBindingSource.EndEdit();

                var model = new TeslimatKayitModel();
                var baslik = (TSFBAS)tSFBASBindingSource.Current;
                var selectedRow = (TSFTIP)gridLkeFisTipTab1.GetSelectedDataRow();
                baslik.TSHRTP = selectedRow.TSHRTP;
                model.Baslik = baslik;

                if (_action == "insert") model.Baslik.Id = 0;
                
                model.Baslik.ACTIVE = true;
                model.Baslik.SLINDI = false;

                var tsfhars = tSFHARBindingSource.List;
                var harekets = new List<TSFHAR>();

                foreach (var bind in tsfhars)
                {
                    var hrk = (TSFHAR)bind;
                    hrk.ACTIVE = true;
                    hrk.SLINDI = false;
                    hrk.EVRAKN = model.Baslik.EVRAKN;
                    hrk.BELGEN = model.Baslik.BELGEN;
                    hrk.BELTRH = model.Baslik.BELTRH;
                    hrk.TSHRTP = model.Baslik.TSHRTP;
                    hrk.SPORKD = model.Baslik.SPORKD;
                    hrk.SPDGKD = model.Baslik.SPDGKD;
                    hrk.TSFTNO = model.Baslik.TSFTNO;

                    harekets.Add(hrk);
                }

                model.Kalems = harekets;
                
                response = _xxService.Ncch_TeslimatKaydet_Log(model, global, false);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                LoadGrid(baslik);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
                MessageBox.Show("Kaydedildi", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                string errorMessage = ex.GetBaseException().Message;
                MessageBox.Show("Kayıt Yapılamadı " + errorMessage);
            }
        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Emin misiniz ?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                tSFBASBindingSource.EndEdit();
                var data = (TSFBAS)tSFBASBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            gridLke0Cari1.EditValue = null;
            gridLke0Cari2.EditValue = null;
            gridLke1Cari1.EditValue = null;
            gridLke1Cari2.EditValue = null;

            tSFBASBindingSource.CancelEdit();
            tSFHARBindingSource.CancelEdit();

            LoadGrid((TSFBAS)tSFBASBindingSource.Current);
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Mesaj = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj == DialogResult.Yes)
            {
                FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
                tSFBASBindingSource.CancelEdit();
                tSFHARBindingSource.CancelEdit();
                LoadGrid();
            }
        }

        protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
        {
            tSFBASBindingSource.CancelEdit();
            tSFHARBindingSource.CancelEdit();
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            if (xtraTabControl1.SelectedTabPage == xtraTabPage2)
            {
                gridView1.OptionsBehavior.Editable = false;

                barManager.Bars["Tools"].Visible = false;
                xtraTabControl1.SelectedTabPage = xtraTabPage1;
            }
            else if (xtraTabControl1.SelectedTabPage == xtraTabPage3)
            {
                LoadGrid((TSFBAS)tSFBASBindingSource.Current);
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
            }
        }

        #endregion

        void TabControl(bool degistir = false)
        {
            if (global.Sira == 0)
            {
                tabGenelVeriler0.PageVisible = true;
                tabGenelVeriler1.PageVisible = false;
                grpMuh1.Text = "Malı Teslim Eden";
                grpMuh2.Text = "Satıcı";
            }
            else
            {
                tabTesSip.PageVisible = !degistir;
                tabGenelVeriler0.PageVisible = false;
                tabGenelVeriler1.PageVisible = true;
                grpMuh1.Text = "Malı Teslim Alan";
                grpMuh2.Text = "Sipariş Veren";
                if (_action == "update")
                {
                    btnPdf.Visible = true;
                    btnOdemeTablosu.Visible = true;
                    btnAnlasmaKosullari.Visible = true;
                }
                else
                {
                    btnPdf.Visible = false;
                    btnOdemeTablosu.Visible = false;
                    btnAnlasmaKosullari.Visible = false;
                }
            }
        }

        public void ClearCari1()
        {

            foreach (Control control in grpMuh1.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "Sil1")
                {
                    control.Text = "";
                }
            }
        }

        public void ClearCari2()
        {
            foreach (Control control in grpMuh2.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "Sil2")
                {
                    control.Text = "";
                }
            }
        }

        private void gridLkeFisTipTab1_EditValueChanged(object sender, EventArgs e)
        {
            var selectedRow = (TSFTIP)gridLkeFisTipTab1.GetSelectedDataRow();
            sPORKDGridLookUpEdit.EditValue = selectedRow.SPORKD;
            sPDGKDGridLookUpEdit.EditValue = selectedRow.SPDGKD;
        }

        private void Cari_EditValueChanged(object sender, EventArgs e)
        {
            if (loadingGrid || xtraTabControl1.SelectedTabPage != xtraTabPage3 || xtraTabControl2.SelectedTabPage == tabTesSip) return;

            GridLookUpEdit lked = sender as GridLookUpEdit;
            if (lked == gridLke0Cari2 || lked == gridLke1Cari2) return;

            TSFBAS spfbas = (TSFBAS)tSFBASBindingSource.Current;
            if (global.Sira == 0)
            {
                if (spfbas.Id != 0 && spfbas.SIRKID != 0) gridLke0Cari1.EditValue = spfbas.CRKODU; //Buraya bakılacak
                gridLke0Cari2.EditValue = gridLke0Cari1.EditValue;

                if (spfbas != null)
                {
                    string cari1 = gridLke0Cari1.EditValue == null ? "" : gridLke0Cari1.EditValue.ToString();
                    string cari2 = gridLke0Cari2.EditValue == null ? "" : gridLke0Cari2.EditValue.ToString();
                    spfbas.CRKODU = cari1 == "" ? null : cari1;
                    spfbas.MALTES = cari2 == "" ? null : cari2;
                }
            }
            if (global.Sira == 1 && spfbas != null)
            {
                if (spfbas.Id != 0 && spfbas.SIRKID != 0) gridLke1Cari1.EditValue = spfbas.CRKODU; //Buraya bakılacak
                gridLke1Cari2.EditValue = gridLke1Cari1.EditValue;

                if (spfbas != null)
                {
                    string cari1 = gridLke1Cari1.EditValue == null ? "" : gridLke1Cari1.EditValue.ToString();
                    string cari2 = gridLke1Cari2.EditValue == null ? "" : gridLke1Cari2.EditValue.ToString();
                    spfbas.CRKODU = cari1 == "" ? null : cari1;
                    spfbas.MALTES = cari2 == "" ? null : cari2;
                }
            }

            tSFBASBindingSource.CurrencyManager.Refresh();
        }

        private void xtraTabControl2_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
            if (e.Page != null && e.Page.Name == "tabMuhatap")
            {
                getmuhatab();
            }
        }

        private void getmuhatab()
        {
            ClearCari1();
            ClearCari2();
            this.Validate();
            if (global.Sira == 0)
            {
                if (gridLke0Cari1.EditValue != null)
                {
                    var cariKod = gridLke0Cari1.EditValue.ToString();

                    var selectedRow = (CRCARI)gridLke0Cari1.GetSelectedDataRow();
                    if (selectedRow == null) return;

                    var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;

                    var faturaAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.FTADNO);

                    txtMhCariKod2.Text = cariKod;
                    txtCari2Unv1.Text = selectedRow.CRUNV1;
                    txtCari2Unv2.Text = selectedRow.CRUNV2;
                    txtCari2Mail.Text = selectedRow.GNMAIL;
                    txtCari2WebAdr.Text = selectedRow.GNWEBA;
                    txtCari2VergiDaire.Text = selectedRow.VERGDA;
                    txtCari2VergiNo.Text = selectedRow.VERGNO;

                    txtCari2Adres.Text = faturaAdres != null ? faturaAdres.ADRESS : "";

                    gridLke0Cari2.EditValue = gridLke0Cari1.EditValue;

                    tSFBASBindingSource.CurrencyManager.Refresh();
                }

                tSFBASBindingSource.EndEdit();

                if (gridLke0Cari2.EditValue != null)
                {
                    var cariKod = gridLke0Cari2.EditValue.ToString();

                    var selectedRow = (CRCARI)gridLke0Cari2.GetSelectedDataRow();

                    if (selectedRow == null) return;

                    var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;

                    var sevkAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.SVADNO);

                    txtMhCariKod1.Text = cariKod;
                    txtCari1Unv1.Text = selectedRow.CRUNV1;
                    txtCari1Unv2.Text = selectedRow.CRUNV2;

                    txtCari1Adres.Text = sevkAdres != null ? sevkAdres.ADRESS : "";
                }

                tSFBASBindingSource.EndEdit();
            }
            if (global.Sira == 1)
            {
                if ((gridLke1Cari1.EditValue != null))
                {
                    var cariKod = gridLke1Cari1.EditValue.ToString();

                    var selectedRow = (CRCARI)gridLke1Cari1.GetSelectedDataRow();
                    if (selectedRow == null) return;

                    var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;

                    var faturaAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.FTADNO);

                    txtMhCariKod2.Text = cariKod;
                    txtCari2Unv1.Text = selectedRow.CRUNV1;
                    txtCari2Unv2.Text = selectedRow.CRUNV2;
                    txtCari2Mail.Text = selectedRow.GNMAIL;
                    txtCari2WebAdr.Text = selectedRow.GNWEBA;
                    txtCari2VergiDaire.Text = selectedRow.VERGDA;
                    txtCari2VergiNo.Text = selectedRow.VERGNO;

                    txtCari2Adres.Text = faturaAdres != null ? faturaAdres.ADRESS : "";

                    gridLke1Cari2.EditValue = gridLke1Cari1.EditValue;

                    tSFBASBindingSource.CurrencyManager.Refresh();
                }

                tSFBASBindingSource.EndEdit();
                if (gridLke1Cari2.EditValue != null)
                {
                    var cariKod = gridLke1Cari2.EditValue.ToString();

                    var selectedRow = (CRCARI)gridLke1Cari2.GetSelectedDataRow();

                    if (selectedRow == null) return;

                    var adresler = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKod, false).Items;

                    var sevkAdres = adresler.FirstOrDefault(f => f.Id == selectedRow.SVADNO);

                    txtMhCariKod1.Text = cariKod;
                    txtCari1Unv1.Text = selectedRow.CRUNV1;
                    txtCari1Unv2.Text = selectedRow.CRUNV2;

                    txtCari1Adres.Text = sevkAdres != null ? sevkAdres.ADRESS : "";
                }

                tSFBASBindingSource.EndEdit();
            }
        }

        void TabControlTesEkle(bool visible)
        {
            tabGenelVeriler0.PageVisible = visible;
            tabGenelVeriler1.PageVisible = visible;
            tabMuhatap.PageVisible = visible;
            groupControl2.Visible = visible;
            tabTesSip.PageVisible = !visible;
        }
    }
}
