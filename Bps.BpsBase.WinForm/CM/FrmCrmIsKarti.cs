using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CM;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
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
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.CM;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.CM.Single;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.Response;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors.Repository;

namespace BPS.Windows.Forms
{
    public partial class FrmCrmIsKarti : Base.FrmChildBase
    {
        private ICmkartService _sinifService;
        private IGnkxmlService _sinifyerlesimService;

        private GNKXML _sinifyerlesim;

        private ProjeMenuListed yetkiModel;
        private static IList<CMKART> list;
        private static CMKART oldData;
        private string _action;

        private readonly ICrcariService _crcariService;
        private readonly IGnyetkService _gnyetkService;
        private readonly IGnthrkService _gnthrkService;
        private readonly IStkartService _stkartService;
        private readonly ICmaksnService _cmaksnService;
        private readonly IGnkullService _gnkullService;
        private readonly IXXService _xxService;

        private List<Grid> focusedRowHandler = new List<Grid>();
        private int _satirNo = 0;

        private List<TipHareketListModel> stokAnaGrupList = new List<TipHareketListModel>();
        private List<TipHareketListModel> stokAltGrupList = new List<TipHareketListModel>();

        public FrmCrmIsKarti(ICmkartService sinifService, IGnthrkService gnthrkService, IStkartService stkartService, 
	        ICmaksnService cmaksnService, IGnyetkService gnyetkService, ICrcariService crcariService,
        IXXService xxService, IGnkxmlService sinifyerlesimService, IGnkullService gnkullService)
        {
	        _crcariService = crcariService;
            _gnthrkService = gnthrkService;
            _stkartService = stkartService;
            _cmaksnService = cmaksnService;
            _xxService = xxService;
            _sinifService = sinifService;
            _sinifyerlesimService = sinifyerlesimService;
            _gnyetkService = gnyetkService;
            _gnkullService = gnkullService;
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

            cRKODUGridLookUpEdit.Properties.DataSource = _crcariService.Ncch_GetAllActive_NLog(global, false).Items;

            var teknads = new List<string>() { "OLCUKD", "MALGKD", "STANKD", "STALKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            var kullaniciList = _gnkullService.Ncch_GetOnlyAdSoyad_NLog(global, false).Items;

            repLkedKul1.DataSource = repLkedKul2.DataSource = kullaniciList;

            repLkedMalGrubu.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
            stokAnaGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").ToList();
            stokAltGrupList = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();

            repLkedStokAnaGrup.DataSource = stokAnaGrupList;
            repSipKalemStokKod.BestFitMode = BestFitMode.BestFitResizePopup;

            grdViewAksiyon.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
            grdViewAksiyon.OptionsNavigation.EnterMoveNextColumn = true;
            grdViewAksiyon.OptionsBehavior.Editable = true;
            grdViewAksiyon.OptionsBehavior.ReadOnly = false;

            GridHelper.ColumnRepositoryItems(grdViewAksiyon, global);
            gridView1.Columns["DEKULL"].Visible = true;
            gridView1.Columns["EKKULL"].Visible = true;
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

            var rowView = (CMKART)cMKARTBindingSource.AddNew();
            if (rowView != null)
            {
                rowView.ACTIVE = true;
                rowView.BELTRH = DateTime.Today;
            }

            dateEdit3.Enabled = true;
            dateEdit3.DateTime = DateTime.Now;
            memoEdit2.Enabled = true;
            grdViewAksiyon.OptionsBehavior.Editable = true;
            grdViewAksiyon.OptionsBehavior.ReadOnly = false;
            bndNvgHareket.Visible = true;
            barKaydet.Enabled = true;
            grdViewAksiyon.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            cMAKSNBindingSource.DataSource = new List<CMAKSN>();
            xtraTabControl1.SelectedTabPage = xtraTabPage3;
            xtraTabControl2.SelectedTabPage = tabGenelVeriler;
            cMKARTBindingSource.CurrencyManager.Refresh();
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";

            var baslik = (SPFBAS)cMKARTBindingSource.Current;
            cMAKSNBindingSource.DataSource = _cmaksnService.Ncch_GetListByBelge_NLog(baslik.BELGEN, global).Items;

            dateEdit3.Enabled = true;
            memoEdit2.Enabled = true;
            grdViewAksiyon.OptionsBehavior.Editable = true;
            grdViewAksiyon.OptionsBehavior.ReadOnly = false;
            bndNvgHareket.Visible = true;
            barKaydet.Enabled = true;
            grdViewAksiyon.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;

            if (baslik.FLGKPN != null && baslik.FLGKPN.Value)
            {
                dateEdit3.Enabled = false;
                memoEdit2.Enabled = false;
                grdViewAksiyon.OptionsBehavior.Editable = false;
                grdViewAksiyon.OptionsBehavior.ReadOnly = true;
                bndNvgHareket.Visible = false;
                barKaydet.Enabled = false;
                grdViewAksiyon.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            }

            xtraTabControl1.SelectedTabPage = xtraTabPage3;
            xtraTabControl2.SelectedTabPage = tabGenelVeriler;
            grdViewAksiyon.BestFitColumns();
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            try
            {
                var response = new StandardResponse();
                cMKARTBindingSource.EndEdit();

                var cmkart = (CMKART)cMKARTBindingSource.Current;

                if (_action == "insert")
                {
	                cmkart.Id = 0;
	                cmkart.CMDRKD = "01"; // Yeni Kayıt
                }

                cmkart.ACTIVE = true;
                cmkart.SLINDI = true;

                var cmaksnList = cMAKSNBindingSource.List;
                var aksiyonList = new List<CMAKSN>();

                foreach (var bind in cmaksnList)
                {
                    var hrk = (CMAKSN)bind;
                    hrk.ACTIVE = true;
                    hrk.SLINDI = false;
                    hrk.BELGEN = cmkart.BELGEN;
                    hrk.BELTRH = cmkart.BELTRH;

                    aksiyonList.Add(hrk);
                }

                response = _xxService.Ncch_CrmKartKaydet_Log(cmkart, aksiyonList, global, false);
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
                cMKARTBindingSource.EndEdit();
                var data = (CMKART)cMKARTBindingSource.Current;
                _sinifService.Ncch_Delete_Log(data, global);
                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                LoadGrid();
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            cMKARTBindingSource.CancelEdit();
            cMAKSNBindingSource.CancelEdit();
            LoadGrid();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            DialogResult Mesaj = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj == DialogResult.Yes)
            {
                FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
                cMKARTBindingSource.CancelEdit();
                cMAKSNBindingSource.CancelEdit();
                LoadGrid();
            }
        }
        protected override void barGeri_ItemClick(object sender, ItemClickEventArgs e)
        {
	        cMKARTBindingSource.CancelEdit();
	        cMAKSNBindingSource.CancelEdit();
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
            var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
            var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
            var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

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
            var belgeNo = bELGENTextEdit.EditValue == null ? "" : bELGENTextEdit.EditValue.ToString();
            var dtBas = dtBaslangic.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBaslangic.EditValue);
            var dtBit = dtBitis.EditValue == null ? (DateTime?)null : Convert.ToDateTime(dtBitis.EditValue);

            var param = new CrmKartParamModel()
            {
                BELGEN = belgeNo,
                DtBaslangic = dtBas,
                DtBitis = dtBit,
            };

            list = _sinifService.Ncch_GetListByParam_NLog(param, global, false).Items;
            cMKARTBindingSource.DataSource = list;

            gridView1.OptionsBehavior.Editable = false;
            gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            focusedRowHandler.Clear();
            FormIslemleri.ButonKontrol2(barManager, 5, yetkiModel);
        }

        private void grdViewSipKalem_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            
        }

        private void grdViewSipKalem_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            //if (grdViewSipKalem.FocusedRowHandle == GridControl.NewItemRowHandle)
            //{
            //    var cmaksnList = cMAKSNBindingSource.List;
            //    var kalems = new List<CMAKSN>();

            //    foreach (var bind in cmaksnList)
            //    {
            //        kalems.Add((CMAKSN)bind);
            //    }

            //    _satirNo = 0;
            //    if (kalems.Count > 0)
            //    {
            //        var intPtr = kalems.OrderByDescending(o => o.AKSNNO).FirstOrDefault();
            //        if (intPtr != null)
            //            _satirNo = intPtr.AKSNNO ?? 0;
            //    }
            //    var data = new SPFHAR();
            //    _satirNo = _satirNo + 100;
            //    data.SATIRN = _satirNo;

            //    var baslik = ((SPFBAS)cMKARTBindingSource.Current);
            //    if (baslik.GRDEPO != null) data.GRDEPO = baslik.GRDEPO;
            //    if (baslik.TERTAR != null) data.MLKBTR = baslik.TERTAR;

            //    cMAKSNBindingSource.Add(data);
            //}
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
            SPFHAR current = cMAKSNBindingSource.Current as SPFHAR;
            if (current == null) return;

            current.STKNAM = stkart.STKNAM;
            current.SADEGK = stkart.SADEGK;

            cMAKSNBindingSource.CurrencyManager.Refresh();
        }

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