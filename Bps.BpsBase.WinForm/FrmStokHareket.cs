using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;

using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Concrete.WM;
using Bps.BpsBase.Entities.Models.IK.Listed;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.ST.Enums;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.Core.Response;
using Bps.Core.Utilities.Helpers;
using Bps.Core.Utilities.WinForm;
using BPS.Windows.Forms.Helper;
using DevExpress.Utils;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Base;
using DevExpress.XtraGrid.Views.Grid;
using Google.Apis.Util;

namespace BPS.Windows.Forms
{
    public partial class FrmStokHareket : BPS.Windows.Base.FrmChildBase
    {
        private readonly IStftipService _stftipService;
        private readonly IGndptnService _gndptnService;
        private readonly IGndpnoService _gndpnoService;
        private readonly IStkartService _stkartService;
        private readonly IStolcuService _stolcuService;
        private readonly IGnthrkService _gnthrkService;
        private readonly IIkpersService _ikpersService;
        private readonly IWmadrtService _wmadrtService;
        private readonly IWmhratService _wmhratService;
        private readonly ICrcariService _crcariService;
        private readonly ISpfbasService _spfbasService;
        private readonly ISpfharService _spfharService;
        private readonly IStdepoService _stdepoService;
        private readonly IXXService _xxService;
        private readonly IUragacService _uragacService;
        private readonly IStbdrnService _stbdrnService;

        private int _satirNo = 0;
        private bool _loading;
        private UnboundColumnCache _kyadrsUnboundCache, _hdadrsUnboundCache;
        private Image imgRequired;
        private List<STKART> _stkarts; 
        private List<STBDRN> _stbdrns;
        private bool formLoaded = false;

        public FrmStokHareket(IStftipService stftipService, IGndptnService gndptnService, IGndpnoService gndpnoService,
            IStkartService stkartService, IStolcuService stolcuService, IGnthrkService gnthrkService,
            IIkpersService ikpersService, IWmadrtService wmadrtService, IWmhratService wmhratService,
            ICrcariService crcariService, ISpfbasService spfbasService, ISpfharService spfharService,
            IXXService xxService, IStdepoService stdepoService, IUragacService uragacService, IStbdrnService stbdrnService)
        {
            _xxService = xxService;
            _stkartService = stkartService;
            _stolcuService = stolcuService;
            _stftipService = stftipService;
            _gndptnService = gndptnService;
            _gndpnoService = gndpnoService;
            _gnthrkService = gnthrkService;
            _ikpersService = ikpersService;
            _wmadrtService = wmadrtService;
            _wmhratService = wmhratService;
            _crcariService = crcariService;
            _spfbasService = spfbasService;
            _spfharService = spfharService;
            _stdepoService = stdepoService;
            _uragacService = uragacService;
            _stbdrnService = stbdrnService;
            InitializeComponent();
        }

        private void FrmStokHareket_Load(object sender, EventArgs e)
        {
            _loading = true;

            foreach (Control control in grpBox2.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "s1")
                {
                    control.Visible = false;
                }
            }

            var teknads = new List<string>() { "OLCUKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            barManager.Bars["Tools"].Visible = false;
            sTHRTPGridLookUpEdit.Properties.DataSource = EnumHelper.GetListItemsFromEnum<HareketTipEnum>();
            //sTFTNOGridLookUpEdit.Properties.DataSource = _stftipService.Cch_GetList_NLog(global, false).Items;
            var depoList = _gndptnService.Cch_GetList_NLog(global, false).Items;
            gRDEPOGridLookUpEdit.Properties.DataSource = depoList;
            cKDEPOGridLookUpEdit.Properties.DataSource = depoList;
            _stkarts = _stkartService.Ncch_GetList_NLog(global, false).Items;
            _stbdrns = _stbdrnService.Cch_GetList_NLog(global, false).Items;
            repLkedStHrktStokKod.DataSource = _stkarts;
            repLkedOlcuBirimi.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();

            var persList = _ikpersService.Ncch_GetListPersonelSicilAdPoz_NLog(global, false).Items;
            List<IkpersSicilAdPozModel> list = new List<IkpersSicilAdPozModel>();
            list.Add(new IkpersSicilAdPozModel());
            list.AddRange(persList);

            repLkedTeslimAlan.DataSource = list;

            _satirNo = 0;
            sTHBASBindingSource.Add(new STHBAS()
            {
                ACTIVE = true,
                SIRKID = global.SirketId.Value,
                SLINDI = false,
                STHRTP = -1,
                STFTNO = -1,
                BELTRH = DateTime.Now
            });
            sTHBASBindingSource.CurrencyManager.Refresh();

            string exeDir = AppDomain.CurrentDomain.BaseDirectory;
            string path = Path.Combine(exeDir, "images\\required.png");
            imgRequired = Image.FromFile(path);

            _loading = false;
            formLoaded = true;
        }

        private void sTHRTPGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (_loading) return;

            ChangingEventArgs ce = e as ChangingEventArgs;
            if (ce.NewValue.ToString() == ce.OldValue.ToString()) return;

            sTFTNOGridLookUpEdit.EditValue = null;
            sTFTNOGridLookUpEdit.Properties.DataSource = null;
            gRDEPOGridLookUpEdit.EditValue = null;
            cKDEPOGridLookUpEdit.EditValue = null;
            gridLkeSASNO.EditValue = null;
            cRKODUGridLookUpEdit.EditValue = null;

            GetGridLayout();

            if (sTHRTPGridLookUpEdit.EditValue == null) return;
            var tipNo = sTHRTPGridLookUpEdit.EditValue.ToInt32();

            switch (tipNo)
            {
                case 0:
                    gRDEPOLabel.Visible = true;
                    gRDEPOGridLookUpEdit.Visible = true;
                    cKDEPOLabel.Visible = false;
                    cKDEPOGridLookUpEdit.Visible = false;
                    break;
                case 1:
                    gRDEPOLabel.Visible = false;
                    gRDEPOGridLookUpEdit.Visible = false;
                    cKDEPOLabel.Visible = true;
                    cKDEPOGridLookUpEdit.Visible = true;
                    break;
                case 2:
                    gRDEPOLabel.Visible = true;
                    gRDEPOGridLookUpEdit.Visible = true;
                    cKDEPOLabel.Visible = true;
                    cKDEPOGridLookUpEdit.Visible = true;
                    break;
            }

            gRDEPOGridLookUpEdit.EditValue = null;
            cKDEPOGridLookUpEdit.EditValue = null;
            _kyadrsUnboundCache = null;
            _hdadrsUnboundCache = null;

            GridHelper.ColumnRepositoryItems(grdViewStHrkt, global);
            sTFTNOGridLookUpEdit.Properties.DataSource =
                _stftipService.Ncch_GetListByHrkTipKod_NLog(tipNo, global, false).Items;

            sTFTNOGridLookUpEdit.EditValue = null;

            _satirNo = 0;
        }

        private void sTFTNOGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (sTFTNOGridLookUpEdit.EditValue == null)
            {
                _kyadrsUnboundCache = null;
                _hdadrsUnboundCache = null;
                return;
            }

            try
            {
                if (sTFTNOGridLookUpEdit.EditValue.ToInt32() != -1)
                {
                    int stfstp = sTFTNOGridLookUpEdit.EditValue.ToInt32();
                    WMHRAT wmhrat = _wmhratService.Cch_GetByFisTip_NLog(stfstp, global, false).Nesne;

                    if (wmhrat != null)
                    {
                        int sthrtp = sTHRTPGridLookUpEdit.EditValue.ToInt32();
                        if (sthrtp == 0) _hdadrsUnboundCache = new UnboundColumnCache("HDADRS");
                        else if (sthrtp == 1) _kyadrsUnboundCache = new UnboundColumnCache("KYADRS");
                        else
                        {
                            _kyadrsUnboundCache = new UnboundColumnCache("KYADRS");
                            _hdadrsUnboundCache = new UnboundColumnCache("HDADRS");
                        }
                    }

                    GetGridLayout(stfstp.ToString());
                    VisibleSasGroup(stfstp == 4 || stfstp == 10 || stfstp == 12);
                    GridHelper.ColumnRepositoryRenkBedenItems(grdViewStHrkt, global);
                }
                else
                {
                    _kyadrsUnboundCache = null;
                    _hdadrsUnboundCache = null;

                    GetGridLayout();
                    GridHelper.ColumnRepositoryRenkBedenItems(grdViewStHrkt, global);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

            foreach (Control control in grpBox2.Controls)
            {
                if (control.Tag != null && control.Tag.ToString() == "s1")
                {
                    control.Visible = visible;
                }
            }
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

        private void btnStHrktKaydet_Click(object sender, EventArgs e)
        {
            //if (dxErrorProvider1.HasErrors || dxErrorProvider2.HasErrors)
            //{
            //   return;
            //}

            if (!ValidateFields()) return;

            var response = new StandardResponse();
            var model = new StokHareketModel();
            model.Baslik = (STHBAS)sTHBASBindingSource.Current;

            model.Baslik.BELTRH = bELTRHDateEdit.DateTime;
            model.Baslik.EVRAKN = eVRAKNTextEdit.Text;
            model.Baslik.STHRTP = sTHRTPGridLookUpEdit.EditValue.ToInt32();
            model.Baslik.STFTNO = sTFTNOGridLookUpEdit.EditValue.ToInt32();

            if (gRDEPOGridLookUpEdit.Visible) model.Baslik.GRDEPO = gRDEPOGridLookUpEdit.EditValue.ToString();
            else model.Baslik.GRDEPO = null;
            if (cKDEPOGridLookUpEdit.Visible) model.Baslik.CKDEPO = cKDEPOGridLookUpEdit.EditValue.ToString();
            else model.Baslik.CKDEPO = null;

            model.KaynakWmAdresList = new List<string>();
            model.HedefWmAdresList = new List<string>();

            WMHRAT wmhrat = _wmhratService.Cch_GetByFisTip_NLog(model.Baslik.STFTNO, global, false).Nesne;

            model.Kalemler = new List<STHRKT>();
            var kalems = sTHRKTBindingSource.List;
            foreach (STHRKT kalem in kalems)
            {
                if (string.IsNullOrEmpty(kalem.STKODU)) continue;
                if (model.Baslik.STFTNO == 1)
                {
                    kalem.GNMKTR = kalem.GRMKTR;
                    kalem.OLCUKD = kalem.GROLBR;
                }
                if (kalem.SLINDI || kalem.GRMKTR.Value == 0)
                {
                    model.HedefWmAdresList.Add("");
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

                if (wmhrat != null && _kyadrsUnboundCache != null)
                {
                    var adres = _kyadrsUnboundCache.GetValue(kalem);
                    if (adres != null) model.KaynakWmAdresList.Add(adres.ToString());
                    else
                    {
                        MessageBox.Show(kalem.STKODU + " - " + kalem.STKNAM + Environment.NewLine + "çıkış depo adresi seçilmedi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                if (wmhrat != null && _hdadrsUnboundCache != null)
                {
                    var adres = _hdadrsUnboundCache.GetValue(kalem);
                    if (adres != null) model.HedefWmAdresList.Add(adres.ToString());
                    else
                    {
                        MessageBox.Show(kalem.STKODU + " - " + kalem.STKNAM + Environment.NewLine + "giriş depo adresi seçilmedi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }

                model.Kalemler.Add(kalem);
            }

            if (model.Kalemler.Count == 0)
            {
                MessageBox.Show("Stok seçmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var fisTip = (STFTIP)sTFTNOGridLookUpEdit.GetSelectedDataRow();

            if ((fisTip.STFTNO == 11 || fisTip.STFTNO == 12) && gridLkeSASNO.EditValue != null && gridLkeSASNO.EditValue.ToString() != "") //Satış Siparişi
            {
                model.SiparisList = _spfharService.Cch_GetListByBelge_NLog(gridLkeSASNO.EditValue.ToString(), global).Items;
            }

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
                case "Ncch_UretimMalGiris_Log":
                    {

                        response = _xxService.Ncch_StokMalGirisCikis_Log(model, global, false);
                        UretimdenGiris(model,response.Message);

                        break;
                    }
            }

            if (response.Status != ResponseStatusEnum.OK)
            {
                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            sTHBASBindingSource.DataSource = new STHBAS()
            {
                ACTIVE = true,
                SIRKID = global.SirketId.Value,
                SLINDI = false,
                STHRTP = -1,
                STFTNO = -1,
                BELTRH = DateTime.Now
            };
            sTHRKTBindingSource.DataSource = new List<STHRKT>();
            VisibleSasGroup(false);
            MessageBox.Show(response.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            int tip = -1;
            if (sTHRTPGridLookUpEdit.EditValue != null) tip = sTHRTPGridLookUpEdit.EditValue.ToInt32();

            if (tip == 0 && gRDEPOGridLookUpEdit.Text == "")
            {
                MessageBox.Show("Giriş deposunu seçmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                gRDEPOGridLookUpEdit.ShowPopup();
                return false;
            }

            if (tip == 1 && cKDEPOGridLookUpEdit.Text == "")
            {
                MessageBox.Show("Çıkış deposunu seçmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                cKDEPOGridLookUpEdit.ShowPopup();
                return false;
            }

            if (tip == 2 && (gRDEPOGridLookUpEdit.Text == "" || cKDEPOGridLookUpEdit.Text == ""))
            {
                MessageBox.Show("Giriş ve Çıkış deposunu seçmediniz!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            return true;
        }
        private void UretimdenGiris(StokHareketModel model,string evrakno)
        {
            var model1 = model.DeepCopy();
            model1.Kalemler.Clear();
            var urunagac = _uragacService.Ncch_GetUrunAgaciList_NLog(global).Items;
            model1.Baslik.CKDEPO = "001";
            model1.Baslik.GRDEPO = null;
            model1.Baslik.STHRTP = 1;
            model1.Baslik.STFTNO = 6;
            model1.Baslik.EVRAKN = evrakno; 
            foreach (var item in model.Kalemler)
            {
                var mltr = _stkarts.Where(a => a.STKODU == item.STKODU).Select(s => s.STMLTR).FirstOrDefault();
                if (mltr == "01")
                {

                    var sonvry = _stbdrns.Where(x => x.STKODU == item.STKODU && x.VRKODU == item.VRKODU).FirstOrDefault();
                    var sonkarakter = item.VRKODU.Last();
                    var varyant = sonvry.STKODU + sonvry.RENKKD + "M";
                    var agacklms = urunagac.Where(x => x.AnaUrunKodu == item.STKODU && x.AnaUrunVaryanti== varyant).ToList();
                    if (agacklms.Count > 0)
                    {
                        foreach (var klm in agacklms)
                        {
                            model1.Kalemler.Add(new STHRKT
                            {
                                STHRTP = 1,
                                STFTNO = 6,
                                STKODU = klm.MalzemeKodu,
                                VRKODU = klm.MalzemeVaryanti,
                                GNMKTR = klm.KümülatifMiktar * item.GRMKTR,
                                GRMKTR = klm.KümülatifMiktar * item.GRMKTR,
                                GROLBR = klm.Birim,
                                STKNAM = _stkarts.Where(a => a.STKODU == klm.MalzemeKodu).Select(s => s.STKNAM).FirstOrDefault()
                            });
                        }

                    }
                    else
                    {
                        MessageBox.Show("Ürün Ağacı Bulunamadı : " + item.STKODU +'-'+item.VRKODU ); 
                    }
                }
            }
            var response = new StandardResponse();
            if (model1.Kalemler.Count > 0)
            {
                response = _xxService.Ncch_StokMalGirisCikis_Log(model1, global, false);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
            ;
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

        private void repLkedStHrktStokKod_Closed(object sender, ClosedEventArgs e)
        {
            var g = gridView1.GetFocusedRowCellValue("STKODU");

            //var newValue = repLkedStHrktStokKod.GetKeyValue(repLkedStHrktStokKod.row)
            //if (newValue != null)
            //{
            //    STKART stkart = (STKART)repLkedStHrktStokKod.GetRowByKeyValue(newValue);
            //    ((STHRKT)sTHRKTBindingSource.Current).STKNAM = stkart.STKNAM;
            //    ((STHRKT)sTHRKTBindingSource.Current).OLCUKD = stkart.OLCUKD;

            //    sTHRKTBindingSource.CurrencyManager.Refresh();
            //}
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

        private void btnProfil_Click(object sender, EventArgs e)
        {
            var form = this.MdiParent.MdiChildren.FirstOrDefault(f => f.Name == "FrmProfilOptimizasyon");

            FrmMain mainForm = this.MdiParent as FrmMain;
            mainForm.barModulAdi.Caption = "";
            mainForm.barMenuTag.Caption = "";
            mainForm.barMenuAdi.Caption = "Profil Optimizasyonu";

            if (form != null) form.Activate();
            else
            {
                FrmProfilOptimizasyon pForm = new FrmProfilOptimizasyon();
                pForm.MdiParent = mainForm;
                pForm.global = global;
                pForm.Show();
            }
        }

        private void repLkedTeslimAlan_Popup(object sender, EventArgs e)
        {
            repLkedTeslimAlan.View.BestFitColumns();
        }

        private void grdViewStHrkt_ValidatingEditor(object sender, BaseContainerValidateEditorEventArgs e)
        {
            ColumnView view = sender as ColumnView;
            GridColumn column = (e as EditFormValidateEditorEventArgs)?.Column ?? view.FocusedColumn;
            if (column.FieldName == "TSTARH")
            {
                e.Value = ((DateTimeOffset)e.Value).DateTime;
                e.Valid = true;
            }
        }

        private void grdViewStHrkt_CustomUnboundColumnData(object sender, CustomColumnDataEventArgs e)
        {
            STHRKT sthrkt = e.Row as STHRKT;

            var sthrtp = sTHRTPGridLookUpEdit.EditValue.ToInt32();

            if (sthrtp == 0)
            {
                if (_hdadrsUnboundCache == null) return;

                if (e.IsSetData)
                {
                    _hdadrsUnboundCache.SetValue(sthrkt, e.Value);
                }

                if (e.IsGetData)
                {
                    e.Value = _hdadrsUnboundCache.GetValue(sthrkt);
                }

            }
            else if (sthrtp == 1)
            {
                if (_kyadrsUnboundCache == null) return;

                if (e.IsSetData)
                {
                    _kyadrsUnboundCache.SetValue(sthrkt, e.Value);
                }

                if (e.IsGetData)
                {
                    e.Value = _kyadrsUnboundCache.GetValue(sthrkt);
                }
            }
            grdViewStHrkt.RefreshData();

        }

        private void cKDEPOGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (_loading || !cKDEPOGridLookUpEdit.Visible) return;

            repLkedWmAdresTanim.DataSource = null;
            _kyadrsUnboundCache = new UnboundColumnCache("KYADRS");

            if (cKDEPOGridLookUpEdit.EditValue != null && cKDEPOGridLookUpEdit.EditValue.ToString() != "")
            {
                var gndptn = cKDEPOGridLookUpEdit.GetSelectedDataRow() as GNDPTN;
                var gndpno = _gndpnoService.Ncch_GetByDepoKodUretimYeri_NLog(gndptn.URYRKD, gndptn.DPKODU, global, false).Nesne;

                if (gndpno != null)
                {
                    repLkedWmAdresTanim.DataSource = _wmadrtService.Cch_GetListByDepoKd_NLog(gndpno.DEPOKD, global, false).Items;
                }
            }
        }

        private void grdViewStHrkt_ShowingEditor(object sender, System.ComponentModel.CancelEventArgs e)
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

        private void grdViewStHrkt_CustomDrawCell(object sender, RowCellCustomDrawEventArgs e)
        {
            if (e.RowHandle < 0) return;

            string c = e.Column.FieldName;

            if ((c == "SATIRN" || c == "STKODU" || c == "STKNAM" || c == "GRMKTR" || c == "GROLBR" || c == "KYADRS" ||
                 c == "HDADRS") &&
                e.Column.Visible && (e.CellValue == null || e.CellValue.ToString() == ""))
            {
                e.DefaultDraw();
                e.Cache.DrawImage(imgRequired, e.Bounds.Location);
                //e.Appearance.BackColor = Color.MistyRose;
            }

            if ((c == "GRMKTR" && e.Column.Visible && e.CellValue != null && Convert.ToSingle(e.CellValue) < 0) ||
                (c == "SATIRN" && e.Column.Visible && e.CellValue != null && Convert.ToInt32(e.CellValue) < 1))
            {
                e.DefaultDraw();
                e.Cache.DrawImage(imgRequired, e.Bounds.Location);
            }

            if (c == "PARTIN" && e.Column.Visible)
            {
                GridView view = sender as GridView;

                var partiControl = view.GetRowCellValue(e.RowHandle, "PARTIT");

                if (partiControl != null && Convert.ToBoolean(partiControl) &&
                    (e.CellValue == null || e.CellValue.ToString() == ""))
                {
                    e.DefaultDraw();
                    e.Cache.DrawImage(imgRequired, e.Bounds.Location);
                    //e.Appearance.BackColor = Color.MistyRose;
                }
            }
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

        private void RefreshKalem(string sasNo = "")
        {
            if (!formLoaded) return;

            if (string.IsNullOrEmpty(sasNo))
            {
                sTHRKTBindingSource.DataSource = new List<STHRKT>();
                sTHRKTBindingSource.CurrencyManager.Refresh();
                return;
            }

            var sasBaslik = _spfbasService.Ncch_GetByBelgeNo_NLog(sasNo, global, false).Nesne;
            STHBAS hrkBaslik = (STHBAS)sTHBASBindingSource.Current;

            hrkBaslik.CRKODU = sasBaslik.CRKODU;
            hrkBaslik.EVRAKN = sasBaslik.EVRAKN;
            hrkBaslik.GRDEPO = sasBaslik.GRDEPO;
            hrkBaslik.CKDEPO = sasBaslik.CKDEPO;
            hrkBaslik.GNACIK = sasBaslik.GNACIK;

            sTHBASBindingSource.CurrencyManager.Refresh();

            List<string> adresList = new List<string>();

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
                model.VRKODU = kalem.VRKODU;
                if (kalem.FLGKPN != null && kalem.FLGKPN.Value) model.SLINDI = true;

                STKART stkart = _stkarts.FirstOrDefault(s => s.STKODU == kalem.STKODU);
                if (stkart == null)
                {
                    MessageBox.Show(kalem.STKODU + " stok kodu bulunamadı!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                model.SADEGK = stkart.SADEGK;
                model.PARTIT = stkart.PARTIT;

                int hareketTipi = sTHRTPGridLookUpEdit.EditValue.ToInt32();
                if (hareketTipi == 0) model.GROLBR = stkart.SAOLKD;
                else model.GROLBR = stkart.OLCUKD;

                bindingSourceHrkSas.Add(model);

                var lst = _stdepoService.Cch_GetByStokKodu_NLog(global, stkart.STKODU, false).Items;
                if (lst.Count > 0)
                {
                    STDEPO stdepo = lst[0];
                    if (stdepo != null && stdepo.DPADRS != null) adresList.Add(stdepo.DPADRS);
                    else adresList.Add("");
                }
                else adresList.Add("");
            }

            sTHRKTBindingSource.DataSource = bindingSourceHrkSas;

            for (int i = 0; i < grdViewStHrkt.RowCount; i++)
            {
                GridColumn column = grdViewStHrkt.Columns["HDADRS"];
                grdViewStHrkt.SetRowCellValue(i, column, adresList[i]);
            }

            sTHRKTBindingSource.CurrencyManager.Refresh();
            grdViewStHrkt.RefreshData();
        }

        private void gridLkeSASNO_EditValueChanged(object sender, EventArgs e)
        {
            _hdadrsUnboundCache = new UnboundColumnCache("HDADRS");
            var ev = e as ChangingEventArgs;
            string sasNo = "";
            if (ev.NewValue != null && ev.NewValue.ToString() != "") sasNo = ev.NewValue.ToString();
            RefreshKalem(sasNo);
        }

        private void barButGrmktrSifirla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            var kalems = sTHRKTBindingSource.List;
            foreach (STHRKT kalem in kalems) kalem.GRMKTR = 0;
            sTHRKTBindingSource.CurrencyManager.Refresh();
            grdViewStHrkt.RefreshData();
        }

        private void grdViewStHrkt_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            if (grdViewStHrkt.RowCount > 0) popMenu.ShowPopup(MousePosition);
        }

        private void gRDEPOGridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (_loading || !gRDEPOGridLookUpEdit.Visible) return;

            repLkedWmAdresTanim.DataSource = null;
            _hdadrsUnboundCache = new UnboundColumnCache("HDADRS");

            if (gRDEPOGridLookUpEdit.EditValue != null && gRDEPOGridLookUpEdit.EditValue.ToString() != "")
            {
                var gndptn = gRDEPOGridLookUpEdit.GetSelectedDataRow() as GNDPTN;
                var gndpno = _gndpnoService.Ncch_GetByDepoKodUretimYeri_NLog(gndptn.URYRKD, gndptn.DPKODU, global, false).Nesne;

                if (gndpno != null)
                {
                    repLkedWmAdresTanim.DataSource = _wmadrtService.Cch_GetListByDepoKd_NLog(gndpno.DEPOKD, global, false).Items;
                }
            }
        }
    }
}
