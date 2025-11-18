using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraBars;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.Core.Response;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
    public partial class FrmSatinalmaTalep : BPS.Windows.Base.FrmChildBase
    {
        private ISpfbasService _sinifService;
        private IGnkxmlService _sinifyerlesimService;

        private GNKXML _sinifyerlesim;

        private ProjeMenuListed yetkiModel;
        private static IList<SPFBAS> list;
        private static SPFBAS oldData;
        private string _action;

        private readonly IGnyetkService _gnyetkService;
        private readonly IGnthrkService _gnthrkService;
        private readonly ISpftipService _spftipService;
        private readonly IGndptnService _gndptnService;
        private readonly IStkartService _stkartService;
        private readonly IStdepoService _stdepoService;
        private readonly IStolcuService _stolcuService;
        private readonly ISpfharService _spfharService;
        private readonly IGnkullService _gnkullService;
        private readonly ISthrktService _sthrktService;
        private readonly IXXService _xxService;

        private List<Grid> focusedRowHandler = new List<Grid>();
        private int _satirNo = 0;

        private List<TipHareketListModel> stokAnaGrupList = new List<TipHareketListModel>();
        private List<TipHareketListModel> stokAltGrupList = new List<TipHareketListModel>();

        public FrmSatinalmaTalep(ISpfbasService sinifService, IGnthrkService gnthrkService,
            ISpftipService spftipService, IGndptnService gndptnService, IStkartService stkartService, IStdepoService stdepoService,
            IStolcuService stolcuService, ISpfharService spfharService, IGnyetkService gnyetkService,
            IXXService xxService, IGnkxmlService sinifyerlesimService, IGnkullService gnkullService, ISthrktService sthrktService)
        {
            _gnthrkService = gnthrkService;
            _spftipService = spftipService;
            _gndptnService = gndptnService;
            _stkartService = stkartService;
            _stdepoService = stdepoService;
            _stolcuService = stolcuService;
            _spfharService = spfharService;
            _xxService = xxService;
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _gnkullService = gnkullService;
            _sthrktService = sthrktService;
            InitializeComponent();

            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            dtBaslangic.EditValue = DateTime.Today.AddDays(-5);
            dtBitis.EditValue = DateTime.Today.AddDays(5);
        }

        private void FrmSiparis_Load(object sender, EventArgs e)
        {
            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            FormIslemleri.FormYetki2(barManager, yetkiModel);

            _satirNo = 0;
            barManager.Bars["Tools"].Visible = false;

            GridHelper.ColumnRepositoryItems(gridView1, global);
            gridView1.Columns["DEKULL"].Visible = true;
            gridView1.Columns["EKKULL"].Visible = true;

            //List<STKART> stokList = _stkartService.Cch_GetListAktif_NLog(global, false).Items;
            //List<StdepoStokMiktarModel> stokList = _stdepoService.GetStokListWithAnaAltGrup(global, yetkiKontrol: false).Items;

            var teknads = new List<string>() { "OLCUKD", "MALGKD", "STANKD", "STALKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            var kullaniciList = _gnkullService.Ncch_GetOnlyAdSoyad_NLog(global, false).Items;

            repLkedKul1.DataSource = repLkedKul2.DataSource = kullaniciList;

            repLkedMalGrubu.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
            stokAnaGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").ToList();
            stokAltGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();

            repLkedStokAnaGrup.DataSource = stokAnaGrupList;
            repSipKalemStokKod.BestFitMode = BestFitMode.BestFitResizePopup;

            var fisTipList = _spftipService.Ncch_GetListBySphrtp_NLog(global, yetkiKontrol: false).Items;
            fisTipList = fisTipList.Where(f => f.TANIMI == "Satın Alma Talebi").ToList();

            gridLkeFisTipTab1.Properties.DataSource = fisTipList;
            gridLkeFisTipTab3.Properties.DataSource = fisTipList;
            gridLkeFisTipTab1.EditValue = gridLkeFisTipTab3.EditValue = fisTipList[0].SPFTNO;

            var depoList = _gndptnService.Cch_GetListAktif_NLog(global, false).Items;
            gridLkeGirisDepo.Properties.DataSource = depoList;

            #region Kalem

            GetStokMiktarRapor();
            //repSipKalemStokKod.DataSource = stokList;
            repLkedOlcuBirimi.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();
            repLkeDepo.DataSource = depoList;

            #endregion

            grdViewSipKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grdViewSipKalem.OptionsNavigation.EnterMoveNextColumn = true;
            grdViewSipKalem.OptionsBehavior.Editable = true;
            grdViewSipKalem.OptionsBehavior.ReadOnly = false;

            GridHelper.ColumnRepositoryItems(grdViewSipKalem, global);
            gridView1.Columns["DEKULL"].Visible = true;
            gridView1.Columns["EKKULL"].Visible = true;
            GridHelper.ColumnRepositoryRenkBedenItems(grdViewSipKalem, global);
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

                foreach (DataRow dataRow in dataSet.Tables[0].Rows)
                {
                    string anaGrup = dataRow["STANKD"].ToString();
                    int parentId = stokAnaGrupList.First(a => a.HARKOD == anaGrup).Id;
                    TipHareketListModel altGrup = stokAltGrupList.FirstOrDefault(a => a.PARENT == parentId);
                    if (altGrup != null) dataRow["STALKD"] = altGrup.TANIMI;
                }

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

        private RepositoryItemGridLookUpEdit CreateRepositoryItem(List<TipHareketListModel> dataSource)
        {
            RepositoryItemGridLookUpEdit repItem = new RepositoryItemGridLookUpEdit();

            repItem.AutoHeight = false;
            repItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            repItem.DisplayMember = "TANIMI";
            repItem.NullText = "";
            repItem.PopupView = this.gridView7;
            repItem.ValueMember = "HARKOD";
            repItem.DataSource = dataSource;

            return repItem;
        }

        #region Standard

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";

            var fistip = Convert.ToInt32(gridLkeFisTipTab1.EditValue);

            var rowView = (SPFBAS)sPFBASBindingSource.AddNew();
            if (rowView != null)
            {
                rowView.ACTIVE = true;
                rowView.SPFTNO = fistip;
                rowView.BELTRH = DateTime.Today;
            }

            dateEdit3.Enabled = true;
            gridLkeGirisDepo.Enabled = true;
            tERTARDateEdit.Enabled = true;
            memoEdit2.Enabled = true;
            grdViewSipKalem.OptionsBehavior.Editable = true;
            grdViewSipKalem.OptionsBehavior.ReadOnly = false;
            bndNvgHareket.Visible = true;
            barKaydet.Enabled = true;
            grdViewSipKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            sPFHARBindingSource.DataSource = new List<SPFHAR>();
            xtraTabControl1.SelectedTabPage = xtraTabPage3;
            xtraTabControl2.SelectedTabPage = tabGenelVeriler;
            sPFBASBindingSource.CurrencyManager.Refresh();
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";

            var baslik = (SPFBAS)sPFBASBindingSource.Current;
            sPFHARBindingSource.DataSource = _spfharService.Cch_GetListByBelge_NLog(baslik.BELGEN, global).Items;

            dateEdit3.Enabled = true;
            gridLkeGirisDepo.Enabled = true;
            tERTARDateEdit.Enabled = true;
            memoEdit2.Enabled = true;
            grdViewSipKalem.OptionsBehavior.Editable = true;
            grdViewSipKalem.OptionsBehavior.ReadOnly = false;
            bndNvgHareket.Visible = true;
            barKaydet.Enabled = true;
            grdViewSipKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            if (baslik.FLGKPN != null && baslik.FLGKPN.Value)
            {
                dateEdit3.Enabled = false;
                gridLkeGirisDepo.Enabled = false;
                tERTARDateEdit.Enabled = false;
                memoEdit2.Enabled = false;
                grdViewSipKalem.OptionsBehavior.Editable = false;
                grdViewSipKalem.OptionsBehavior.ReadOnly = true;
                bndNvgHareket.Visible = false;
                barKaydet.Enabled = false;
                grdViewSipKalem.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }

            xtraTabControl1.SelectedTabPage = xtraTabPage3;
            xtraTabControl2.SelectedTabPage = tabGenelVeriler;
            grdViewSipKalem.BestFitColumns();
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            try
            {
                var response = new StandardResponse();
                sPFBASBindingSource.EndEdit();

                var model = new SiparisKayitModel();
                var baslik = (SPFBAS)sPFBASBindingSource.Current;
                model.Baslik = baslik;

                if (_action == "insert") model.Baslik.Id = 0;

                model.Baslik.ACTIVE = true;
                model.Baslik.SLINDI = true;
                model.Baslik.DVCNKD = "TLP";
                model.Baslik.SPHRTP = 3;
                model.Baslik.SIPVER = false;

                var spfhars = sPFHARBindingSource.List;
                var harekets = new List<SPFHAR>();

                foreach (var bind in spfhars)
                {
                    var hrk = (SPFHAR)bind;
                    hrk.ACTIVE = true;
                    hrk.SLINDI = false;
                    hrk.BELGEN = model.Baslik.BELGEN;
                    hrk.BELTRH = model.Baslik.BELTRH;
                    hrk.SPHRTP = model.Baslik.SPHRTP;
                    hrk.SPFTNO = model.Baslik.SPFTNO;
                    hrk.DVCNKD = model.Baslik.DVCNKD;

                    harekets.Add(hrk);
                }

                model.Kalems = harekets;

                response = _xxService.Ncch_SiparisKaydet_Log(model, global, false);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                LoadGrid();
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
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
                sPFBASBindingSource.EndEdit();
                var data = (SPFBAS)sPFBASBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            sPFBASBindingSource.CancelEdit();
            sPFHARBindingSource.CancelEdit();
            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Mesaj = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj == DialogResult.Yes)
            {
                FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
                sPFBASBindingSource.CancelEdit();
                sPFHARBindingSource.CancelEdit();
                LoadGrid();
            }
        }
        protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
        {
	        sPFBASBindingSource.CancelEdit();
	        sPFHARBindingSource.CancelEdit();
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

	        FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }

        #endregion

        private void btnSiparisAra_Click(object sender, EventArgs e)
        {
            var spFistip = (gridLkeFisTipTab1.EditValue == null || gridLkeFisTipTab1.EditValue.ToString() == "") ? (int?)null : Convert.ToInt32(gridLkeFisTipTab1.EditValue);
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
                MessageBox.Show("Talep tarihi giriniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

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
            gridView1.Columns["DEKULL"].Visible = true;
            gridView1.Columns["EKKULL"].Visible = true;
            
            //gridView1.Columns["KULKOD"].OptionsColumn.AllowEdit = false;
            //gridView1.SetRowCellValue(1, gridView1.Columns["KULKOD"], kulKod);

            barManager.Items["barGeri"].Visibility = BarItemVisibility.Always;
            barManager.Bars["Tools"].Visible = true;
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        private void LoadGrid()
        {
            var spFistip = gridLkeFisTipTab1.EditValue == null ? (int?)null : Convert.ToInt32(gridLkeFisTipTab1.EditValue);
            var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
            var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
            var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

            var param = new SiparisParamModel()
            {
                BELGEN = belgeNo,
                DtBaslangic = dtBas,
                DtBitis = dtBit,
                SPFTNO = spFistip,
            };

            list = _sinifService.Cch_GetListByParam_NLog(param, global, false).Items;
            sPFBASBindingSource.DataSource = list;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            focusedRowHandler.Clear();
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }

        private void grdViewSipKalem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "STKODU" || e.Column.FieldName == "GROLBR")
            {
                SPFHAR spfhar = (SPFHAR)sPFHARBindingSource.Current;

                var a = repLkedOlcuBirimi.DataSource;
                string olcuBirimi = spfhar.GROLBR;
                string stokKodu = spfhar.STKODU;
                List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(stokKodu, global, false).Items;

                if (e.Column.FieldName == "STKODU")
                {
                    STKART stkart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
                    if (stkart != null)
                    {

                        spfhar.PARTIT = stkart.PARTIT;
                        if (stkart.PARTIT.HasValue && stkart.PARTIT.Value)
                        {
                            spfhar.GROLBR = "ADT";
                            return;
                        }
                    }
                }

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == olcuBirimi);
                    if (olcu != null) return;
                }

                ((SPFHAR)sPFHARBindingSource.Current).GROLBR = null;
                MessageBox.Show(olcuBirimi + " için ölçü çevrimi bulunamadı!", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            if (e.Column.FieldName == "GRMKTR")
            {
                SPFHAR spfhar = (SPFHAR)sPFHARBindingSource.Current;
                spfhar.GNMKTR = spfhar.GNMKTR ?? 0;
            }
        }

        private void grdViewSipKalem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (grdViewSipKalem.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                var spfhars = sPFHARBindingSource.List;
                var kalems = new List<SPFHAR>();

                foreach (var bind in spfhars)
                {
                    kalems.Add((SPFHAR)bind);
                }

                _satirNo = 0;
                if (kalems.Count > 0)
                {
                    var intPtr = kalems.OrderByDescending(o => o.SATIRN).FirstOrDefault();
                    if (intPtr != null)
                        _satirNo = intPtr.SATIRN ?? 0;
                }
                var data = new SPFHAR();
                _satirNo = _satirNo + 100;
                data.SATIRN = _satirNo;

                var baslik = ((SPFBAS)sPFBASBindingSource.Current);
                if (baslik.GRDEPO != null) data.GRDEPO = baslik.GRDEPO;
                if (baslik.TERTAR != null) data.MLKBTR = baslik.TERTAR;

                sPFHARBindingSource.Add(data);
            }
        }

        private void grdViewSipKalem_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedColumn.FieldName == "PARTIN")
            {
                object parti = view.GetRowCellValue(view.FocusedRowHandle, "PARTIT");
                if (parti == null || !Convert.ToBoolean(parti))
                    e.Cancel = true;
            }
        }

        private void repSipKalemStokKod_EditValueChanged(object sender, EventArgs e)
        {
            var newValue = ((ChangingEventArgs)e).NewValue;
            if (newValue == null) return;

            //StdepoStokMiktarModel stkart = (StdepoStokMiktarModel)repSipKalemStokKod.GetRowByKeyValue(newValue);
            STKART stkart = _stkartService.Ncch_GetByStKod_NLog(newValue.ToString(), global, false).Nesne;
            SPFHAR current = sPFHARBindingSource.Current as SPFHAR;
            if (current == null) return;

            current.STKNAM = stkart.STKNAM;
            current.SADEGK = stkart.SADEGK;

            var selectedRow = (SPFTIP)gridLkeFisTipTab1.GetSelectedDataRow();

            var hareketTipi = selectedRow.SPHRTP;
            current.GROLBR = hareketTipi == 0 ? stkart.SAOLKD : stkart.OLCUKD;
            current.OLCUKD = stkart.OLCUKD;
            sPFHARBindingSource.CurrencyManager.Refresh();
        }


        //private void btnPdf_Click(object sender, EventArgs e)
        //{
        //    List<SPFHAR> urunList = sPFHARBindingSource.DataSource as List<SPFHAR>;
        //    List<SiparisUrunModel> sipUrModels = new List<SiparisUrunModel>();

        //    List<SPFBAS> spfbasList = sPFBASBindingSource.DataSource as List<SPFBAS>;

        //    repSiparis rSiparis = new repSiparis();
        //    rSiparis.cellBelgeNo.Text = spfbasList[0].BELGEN;
        //    rSiparis.labelDate.Text = DateTime.Now.ToShortDateString();
        //    rSiparis.cellMusteriAdi.Text = selectedRow.CRUNV1;
        //    rSiparis.cellAdres.Text = faturaAdres != null ? faturaAdres.ADRESS : "";
        //    rSiparis.cellEposta.Text = crytkl != null ? crytkl.GNMAIL : selectedRow.GNMAIL;
        //    rSiparis.cellYetkiliKisi.Text = crytkl != null ? crytkl.YETADI + " " + crytkl.YETSOY : "";
        //    rSiparis.cellSiparisTarihi.Text = spfbasList[0].BELTRH.ToShortDateString();
        //    rSiparis.CellTerminTarihi.Text = spfbasList[0].TERTAR?.ToShortDateString();
        //    rSiparis.lblAciklama.Text = spfbasList[0].GNACIK;

        //    rSiparis.bindingSource1.DataSource = sipUrModels;
        //    rSiparis.ShowPreviewDialog();
        //}

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridView1.GridControl.PointToClient(MousePosition);
            DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = gridView1.CalcHitInfo(point);
            if (info.InRow || info.InRowCell)
            {
                var link = barDegistir.GetVisibleLinks()[0];
                ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
                barDegistir_ItemClick(barDegistir, arg);
            }
        }
    }
}