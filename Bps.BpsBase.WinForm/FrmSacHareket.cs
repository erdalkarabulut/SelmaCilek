using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.ST.Enums;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Utilities.Helpers;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using System.IO;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.WM;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.ST.Single;
using DevExpress.XtraGrid;
using Bps.Core.Response;
using Google.Apis.Util;
using Application = System.Windows.Forms.Application;


namespace BPS.Windows.Forms
{
    public partial class FrmSacHareket : DevExpress.XtraEditors.XtraForm
    {
        public Global global;
        private readonly IStkartService _stkartService;
        private readonly IStftipService _stftipService;
        private readonly ISpfbasService _spfbasService;
        private readonly ISpfharService _spfharService;
        private readonly ICrcariService _crcariService;
        private readonly IStdepoService _stdepoService;
        private readonly IGnthrkService _gnthrkService;
        private readonly IStolcuService _stolcuService;
        private readonly IXXService _xxService;

        private int _satirNo;
        private bool _loading;
        private List<STKART> _stkarts;

        private STHBAS hrkBaslik;

        public FrmSacHareket()
        {
            InitializeComponent();
            _stkartService = InstanceFactory.GetInstance<IStkartService>();
            _stftipService = InstanceFactory.GetInstance<IStftipService>();
            _spfbasService = InstanceFactory.GetInstance<ISpfbasService>();
            _spfharService = InstanceFactory.GetInstance<ISpfharService>();
            _crcariService = InstanceFactory.GetInstance<ICrcariService>();
            _stdepoService = InstanceFactory.GetInstance<IStdepoService>();
            _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
            _stolcuService = InstanceFactory.GetInstance<IStolcuService>();
            _xxService = InstanceFactory.GetInstance<IXXService>();
        }

        private void FrmSacHareket_Load(object sender, EventArgs e)
        {
            _loading = true;
            _satirNo = 0;

            var list = EnumHelper.GetListItemsFromEnum<HareketTipEnum>();
            list.RemoveAt(list.Count - 1);
            sTHRTPGridLookUpEdit.Properties.DataSource = list;

            _stkarts = _stkartService.Ncch_GetList_NLog(global, false).Items;
            _stkarts = _stkarts.Where(s => s.STKODU.StartsWith("10")).ToList();

            var teknads = new List<string>() { "OLCUKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            repLkedStHrktStokKod.DataSource = _stkarts;
            repLkedOlcuBirimi.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();

            //lkedStokKart.Properties.DataSource = stkarts;
            //lkedStokKart.Properties.BestFitMode = BestFitMode.BestFitResizePopup;

            _loading = false;
        }

        private void FrmSacHareket_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void sTHRTPGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            ChangingEventArgs ce = e as ChangingEventArgs;
            if (ce.NewValue == null || ce.NewValue.ToString() == ce.OldValue.ToString()) return;

            VisibleSasGroup(false);
            GetGridLayout();

            sTFTNOGridLookUpEdit.EditValue = null;
            sTFTNOGridLookUpEdit.Properties.DataSource = null;
            gridLkeSASNO.EditValue = null;
            cRKODUGridLookUpEdit.EditValue = null;

            if (sTHRTPGridLookUpEdit.EditValue == null) return;
            var tipNo = sTHRTPGridLookUpEdit.EditValue.ToInt32();

            GridHelper.ColumnRepositoryItems(grdViewStHrkt, global);
            sTFTNOGridLookUpEdit.Properties.DataSource =
                _stftipService.Ncch_GetListByHrkTipKod_NLog(tipNo, global, false).Items;

            sTFTNOGridLookUpEdit.EditValue = null;
        }

        private void cRKODUGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            int stftno = -1;
            if (sTFTNOGridLookUpEdit.EditValue != null && sTFTNOGridLookUpEdit.EditValue.ToString() != "") stftno = sTFTNOGridLookUpEdit.EditValue.ToInt32();

            gridLkeSASNO.Properties.DataSource = new List<SPFHAR>();
            sTHRKTBindingSource.DataSource = new List<STHRKT>();
            sTHRKTBindingSource.CurrencyManager.Refresh();
            gridLkeSASNO.EditValue = null;

            if (cRKODUGridLookUpEdit.EditValue == null) return;
            var cariKod = cRKODUGridLookUpEdit.EditValue.ToString();

            if (stftno > -1)
            {
                var stftip = sTFTNOGridLookUpEdit.GetSelectedDataRow() as STFTIP;

                gridLkeSASNO.Properties.DataSource =
                    _spfbasService.Ncch_GetListByCariByFlag_NLog(cariKod, stftip.STHRTP, false, global).Items;
            }
        }

        void VisibleSasGroup(bool visible)
        {
            cRKODUGridLookUpEdit.EditValue = null;
            cRKODUGridLookUpEdit.Properties.DataSource = null;

            gridLkeSASNO.EditValue = null;
            gridLkeSASNO.Properties.DataSource = new List<SPFBAS>();

            bindingNavigatorAddNewItem2.Visible = !visible;

            if (visible)
            {
                int sthrtp = sTHRTPGridLookUpEdit.EditValue.ToInt32();
                List<SpBaslikAcikModel> acikSiparisler = _spfbasService.Ncch_GetAcikSiparisList_NLog(global, sthrtp, false).Items;

                cRKODUGridLookUpEdit.Properties.DataSource = acikSiparisler
                    .GroupBy(m => new { m.CRKODU, m.CRUNV1 })
                    .Select(group => group.First())
                    .OrderBy(o => o.CRUNV1)
                    .ToList();

                bndNvgHareket.Visible = false;
                grdViewStHrkt.OptionsBehavior.AllowAddRows = DefaultBoolean.False;
                grdViewStHrkt.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                colSATIRN.OptionsColumn.ReadOnly = true;
                colSTKODU.OptionsColumn.ReadOnly = true;
                colSTKNAM.OptionsColumn.ReadOnly = true;
                colGROLBR.OptionsColumn.ReadOnly = true;
                colOLCUKD.OptionsColumn.ReadOnly = true;
            }
            else
            {
                bndNvgHareket.Visible = true;
                grdViewStHrkt.OptionsBehavior.AllowAddRows = DefaultBoolean.True;
                grdViewStHrkt.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                colSATIRN.OptionsColumn.ReadOnly = false;
                colSTKODU.OptionsColumn.ReadOnly = false;
                colSTKNAM.OptionsColumn.ReadOnly = false;
                colGROLBR.OptionsColumn.ReadOnly = false;
                colOLCUKD.OptionsColumn.ReadOnly = false;
            }

            sTHRKTBindingSource.DataSource = new List<STHRKT>();
            sTHRKTBindingSource.CurrencyManager.Refresh();

            grpBox2.Visible = visible;
            foreach (Control control in grpBox2.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "s1")
                {
                    control.Visible = visible;
                }
            }
        }

        private bool ValidateFields()
        {
            if (sTHRTPGridLookUpEdit.Text == "")
            {
                MessageBox.Show("Stok hareket tipini seçmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sTHRTPGridLookUpEdit.ShowPopup();
                return false;
            }

            if (sTFTNOGridLookUpEdit.Text == "")
            {
                MessageBox.Show("Stok hareket fiş tipini seçmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                sTFTNOGridLookUpEdit.ShowPopup();
                return false;
            }

            return true;
        }

        private void sTFTNOGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (sTFTNOGridLookUpEdit.EditValue == null) return;

            try
            {
                if (sTFTNOGridLookUpEdit.EditValue.ToInt32() != -1)
                {
                    int stfstp = sTFTNOGridLookUpEdit.EditValue.ToInt32();
                    GetGridLayout(stfstp.ToString());
                    VisibleSasGroup(stfstp == 4 || stfstp == 12);
                }
                else GetGridLayout();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void gridLkeSASNO_EditValueChanged(object sender, EventArgs e)
        {
            var ev = e as ChangingEventArgs;
            string sasNo = "";
            if (ev.NewValue != null && ev.NewValue.ToString() != "") sasNo = ev.NewValue.ToString();
            RefreshKalem(sasNo);
        }

        private void RefreshKalem(string sasNo = "")
        {
            if (_loading) return;

            hrkBaslik = new STHBAS()
            {
                ACTIVE = true,
                SIRKID = global.SirketId.Value,
                SLINDI = false,
                STHRTP = -1,
                STFTNO = -1,
                BELTRH = DateTime.Now
            };

            if (string.IsNullOrEmpty(sasNo))
            {
                sTHRKTBindingSource.DataSource = new List<STHRKT>();
                sTHRKTBindingSource.CurrencyManager.Refresh();
                return;
            }

            var sasBaslik = _spfbasService.Ncch_GetByBelgeNo_NLog(sasNo, global, false).Nesne;

            hrkBaslik.CRKODU = sasBaslik.CRKODU;
            hrkBaslik.EVRAKN = sasBaslik.EVRAKN;
            hrkBaslik.GRDEPO = sasBaslik.GRDEPO;
            hrkBaslik.GNACIK = sasBaslik.GNACIK;

            var kalems = _spfharService.Cch_GetListByBelge_NLog(sasNo, global).Items;
            var bindingSourceHrkSas = new List<STHRKT>();
            sTHRKTBindingSource.DataSource = new List<STHRKT>();
            _satirNo = 0;
            foreach (var kalem in kalems)
            {
                _satirNo++;
                var model = new STHRKT();
                model.SATIRN = _satirNo;
                model.STKODU = kalem.STKODU;
                model.STKNAM = kalem.STKNAM;
                model.STHRTP = hrkBaslik.STHRTP;
                model.GNMKTR = kalem.GNMKTR;
                model.GRMKTR = kalem.KLNMKTR;
                model.OLCUKD = kalem.OLCUKD;
                model.GROLBR = kalem.GROLBR;
                model.GRDEPO = kalem.GRDEPO;
                model.GNTUTR = kalem.GNTUTR;
                model.VRGORN = kalem.VRGORN;
                model.VRGTUT = kalem.VRGTUT;
                model.VRGSIZ = kalem.VRGSIZ;
                model.OTVORN = kalem.OTVORN;
                model.OTVTUT = kalem.OTVTUT;
                model.MLKBTR = kalem.MLKBTR;
                model.USTBLG = kalem.BELGEN;
                model.USTKLM = kalem.SATIRN;
                model.SADEGK = kalem.SADEGK;

                if (kalem.FLGKPN != null && kalem.FLGKPN.Value) model.SLINDI = true;

                STKART stkart = _stkarts.FirstOrDefault(s => s.STKODU == kalem.STKODU);
                if (stkart == null)
                {
                    //MessageBox.Show(kalem.STKODU + " stok kodu bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //return;
                    continue;
                }

                model.SADEGK = stkart.SADEGK;
                model.PARTIT = stkart.PARTIT;

                int hareketTipi = sTHRTPGridLookUpEdit.EditValue.ToInt32();
                if (hareketTipi == 0) model.GROLBR = stkart.SAOLKD;
                else model.GROLBR = stkart.OLCUKD;

                bindingSourceHrkSas.Add(model);
            }

            sTHRKTBindingSource.DataSource = bindingSourceHrkSas;
            sTHRKTBindingSource.CurrencyManager.Refresh();
            grdViewStHrkt.RefreshData();
        }

        private void GetGridLayout(string tip = "Default")
        {
            if (_loading) return;

            _satirNo = 0;
            GridView view = (GridView)grdControlStHrkt.MainView;
            view.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
            sTHRKTBindingSource.Clear();

            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string file = tip == "Default" ? "Default.xml" : "SHLayout" + tip + ".xml";
            string path = Path.Combine(exeDir, "Layouts\\" + file);

            grdViewStHrkt.RestoreLayoutFromXml(path);

            view.Columns["PARTIN"].Visible = false;
            view.Columns["TSTARH"].Visible = false;
            view.Columns["TSALAN"].Visible = false;

            grdViewStHrkt.LayoutChanged();

            if (tip != "Default")
            {
                view.OptionsView.NewItemRowPosition = NewItemRowPosition.Bottom;
                view.OptionsNavigation.EnterMoveNextColumn = true;
                view.OptionsBehavior.Editable = true;
                view.OptionsBehavior.ReadOnly = false;
            }
        }

        private void grdViewStHrkt_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (_loading) return;

            if (grdViewStHrkt.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                var data = new STHRKT();
                _satirNo++;
                data.SATIRN = _satirNo;
                sTHRKTBindingSource.Add(data);
            }
        }

        private void grdViewStHrkt_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.Column.FieldName == "STKODU" || e.Column.FieldName == "GROLBR")
            {
                string olcuBirimi = ((STHRKT)sTHRKTBindingSource.Current).GROLBR;
                string stokKodu = ((STHRKT)sTHRKTBindingSource.Current).STKODU;
                List<STOLCU> olcuList = _stolcuService.Ncch_GetByStKod_NLog(stokKodu, global, false).Items;

                if (e.Column.FieldName == "STKODU")
                {
                    STKART stkart = _stkartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
                    if (stkart != null)
                    {
                        STHRKT sthrkt = (STHRKT)sTHRKTBindingSource.Current;
                        sthrkt.PARTIT = stkart.PARTIT;
                        if (stkart.PARTIT.HasValue && stkart.PARTIT.Value)
                        {
                            //sthrkt.GROLBR = "ADT";
                            return;
                        }

                        string adres = "";
                        var lst = _stdepoService.Cch_GetByStokKodu_NLog(global, stkart.STKODU, false).Items;
                        if (lst.Count > 0)
                        {
                            STDEPO stdepo = lst[0];
                            if (stdepo != null && stdepo.DPADRS != null)
                            {
                                grdViewStHrkt.SetRowCellValue(e.RowHandle, "HDADRS", stdepo.DPADRS);
                            }
                        }

                        sTHRKTBindingSource.CurrencyManager.Refresh();
                        grdViewStHrkt.RefreshData();
                    }
                }

                if (olcuList != null && olcuList.Count > 0)
                {
                    STOLCU olcu = olcuList.FirstOrDefault(o => o.OLCHDF == olcuBirimi);
                    if (olcu != null) return;
                }

                MessageBox.Show(olcuBirimi + " için ölçü çevrimi bulunamadı!", "Bilgi", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void grdViewStHrkt_ShowingEditor(object sender, CancelEventArgs e)
        {
            GridView view = sender as GridView;

            if (view.FocusedColumn.FieldName == "PARTIN")
            {
                object parti = view.GetRowCellValue(view.FocusedRowHandle, "PARTIT");
                if (parti == null || !Convert.ToBoolean(parti))
                    e.Cancel = true;

                object tamamlandi = view.GetRowCellValue(view.FocusedRowHandle, "SLINDI");
                if (tamamlandi != null && Convert.ToBoolean(tamamlandi))
                    e.Cancel = true;
            }
            else if (view.FocusedColumn.FieldName == "GRMKTR" || view.FocusedColumn.FieldName == "HDADRS")
            {
                object tamamlandi = view.GetRowCellValue(view.FocusedRowHandle, "SLINDI");
                if (tamamlandi != null && Convert.ToBoolean(tamamlandi))
                    e.Cancel = true;
            }
        }

        private void repLkedStHrktStokKod_EditValueChanged(object sender, EventArgs e)
        {
            var newValue = ((ChangingEventArgs)e).NewValue;
            if (newValue != null)
            {
                int hareketTipi = sTHRTPGridLookUpEdit.EditValue.ToInt32();

                STKART stkart = (STKART)repLkedStHrktStokKod.GetRowByKeyValue(newValue);
                ((STHRKT)sTHRKTBindingSource.Current).STKNAM = stkart.STKNAM;
                ((STHRKT)sTHRKTBindingSource.Current).SADEGK = stkart.SADEGK;

                if (hareketTipi == 0) ((STHRKT)sTHRKTBindingSource.Current).GROLBR = stkart.SAOLKD;
                else ((STHRKT)sTHRKTBindingSource.Current).GROLBR = stkart.OLCUKD;

                sTHRKTBindingSource.CurrencyManager.Refresh();
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            //if (dxErrorProvider1.HasErrors || dxErrorProvider2.HasErrors)
            //{
            //   return;
            //}

            if (!ValidateFields()) return;

            var response = new StandardResponse();
            var model = new StokHareketModel();
            model.Baslik = hrkBaslik;

            model.Baslik.BELTRH = DateTime.Now;
            model.Baslik.EVRAKN = eVRAKNTextEdit.Text;
            model.Baslik.STHRTP = sTHRTPGridLookUpEdit.EditValue.ToInt32();
            model.Baslik.STFTNO = sTFTNOGridLookUpEdit.EditValue.ToInt32();

            model.HedefWmAdresList = new List<string>();
            model.KaynakWmAdresList = new List<string>();

            if (sTHRTPGridLookUpEdit.EditValue == null) return;
            var tipNo = sTHRTPGridLookUpEdit.EditValue.ToInt32();

            int tip = -1;
            if (sTHRTPGridLookUpEdit.EditValue != null) tip = sTHRTPGridLookUpEdit.EditValue.ToInt32();

            if (tip == 0) model.Baslik.GRDEPO = "004";
            else model.Baslik.GRDEPO = null;
            if (tip == 1) model.Baslik.CKDEPO = "004";
            else model.Baslik.CKDEPO = null;

            model.Kalemler = new List<STHRKT>();
            var kalems = sTHRKTBindingSource.List;
            foreach (STHRKT kalem in kalems)
            {
                if (string.IsNullOrEmpty(kalem.STKODU)) continue;
                if (kalem.SLINDI || kalem.GRMKTR.Value == 0)
                {
                    model.Kalemler.Add(kalem);
                    continue;
                }

                if (kalem.GRMKTR == null)
                {
                    MessageBox.Show(kalem.STKODU + " - " + kalem.STKNAM + Environment.NewLine + "için miktar girmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                if (kalem.PARTIT.HasValue && kalem.PARTIT.Value && string.IsNullOrEmpty(kalem.PARTIN))
                {
                    MessageBox.Show(kalem.STKODU + " - " + kalem.STKNAM + Environment.NewLine + "için parti girmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                model.Kalemler.Add(kalem);
            }

            if (model.Kalemler.Count == 0)
            {
                MessageBox.Show("Stok seçmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fisTip = (STFTIP)sTFTNOGridLookUpEdit.GetSelectedDataRow();

            switch (fisTip.FUNCNM)
            {
                case "Ncch_StokSayim_Log":
                    response = _xxService.Ncch_StokSayim_Log(model, global, false);
                    break;
                case "Ncch_StokMalGirisCikis_Log":
                    response = _xxService.Ncch_StokMalGirisCikis_Log(model, global, false);
                    break;
                case "Ncch_StokDepoTransfer_Log":
                    response = _xxService.Ncch_StokDepoTransfer_Log(model, global, false);
                    break;
                case "Ncch_SasGiris_Log":
                    response = _xxService.Ncch_SasGiris_Log(model, global, false);
                    break;
            }

            if (response.Status != ResponseStatusEnum.OK)
            {
                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            hrkBaslik = new STHBAS()
            {
                ACTIVE = true,
                SIRKID = global.SirketId.Value,
                SLINDI = false,
                STHRTP = -1,
                STFTNO = -1,
                BELTRH = DateTime.Now
            };
            sTHRKTBindingSource.DataSource = new List<STHRKT>();

            sTFTNOGridLookUpEdit.EditValue = null;
            sTHRTPGridLookUpEdit.EditValue = null;

            VisibleSasGroup(false);

            MessageBox.Show(response.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void GetStokMiktarRapor()
        {
	        var stokMiktarList = _stdepoService.GetStokMiktarRapor(global, depoKodu: "004", yetkiKontrol: false).Items;

	        if (stokMiktarList != null && stokMiktarList.Count > 0)
	        {
		        int topRow = gridView1.TopRowIndex;
		        int focusedRow = gridView1.FocusedRowHandle;

		        DataSet dataSet = new DataSet();
		        dataSet.Tables.Add(Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarList));


		        gridControl1.DataSource = null;
		        gridControl1.DataSource = stokMiktarList;
		        gridControl1.ForceInitialize();
		        gridView1.BestFitColumns();

		        gridView1.TopRowIndex = topRow;
		        gridView1.FocusedRowHandle = focusedRow;
	        }

	        //SetRepositoryLookups();
        }

        private void xtraTabControl1_SelectedPageChanged(object sender, DevExpress.XtraTab.TabPageChangedEventArgs e)
        {
	        if (xtraTabControl1.SelectedTabPage == pageDepo) GetStokMiktarRapor();
        }
    }
}