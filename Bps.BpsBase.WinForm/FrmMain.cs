using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Entities.Concrete;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Base;
using BPS.Windows.Forms.SP;
using BPS.Windows.Forms.Utilities;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.XtraBars.Navigation;
using DevExpress.XtraReports.UI;
using Application = System.Windows.Forms.Application;

namespace BPS.Windows.Forms
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public Global global;
        public ProjeMenuListed yetki;
        public FrmLogin frmLogin;
        private IDovkurService _dovkurService;

        public FrmMain(IDovkurService dovkurService)
        {
            _dovkurService = dovkurService;
            InitializeComponent();
           
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            barKullaniciId.Caption = global.UserId.ToString();
            barKullaniciAdi.Caption = global.UserKod;
            barRol.Caption = global.Role;
            
            Task.Run(() => SaveDailyCurrency(new List<string> { "USD", "EUR" }));
            Task.Run(() => HelperMethods.RefreshYetki(global));
        }

        public void MenuElement_Click(object sender, EventArgs e)
        {
            AccordionControlElement element = (AccordionControlElement)sender;

            if (element.Level == 0)
            {
                //global.ProjeKod = element.Tag.ToString();
                ////global.MenuTag = 0;
                //yetki = null;
            }
            else if (element.Level == 2)
            {
                global = (Global)element.Tag;
                //global.ProjeKod = element.OwnerElement.OwnerElement.Tag.ToString();
                //global.Sira = Convert.ToInt32( element.Hint);
                yetki = (ProjeMenuListed)element.TagInternal;
                this.HtmlText = element.Hint;

                if (global.FormName == "") MessageBox.Show("Form adı tanımlı değil.");
                else OpenForm(this);
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        public void OpenForm(Form parentForm)
        {
            var form = parentForm.MdiChildren.FirstOrDefault(f => f.Name == global.FormName && f.AccessibleName == global.ProjeKod);

            global.ProjeKod = global.ProjeKod;
            global.MenuTag = global.MenuTag;

            if (form != null) form.Activate();
            else
            {
                try
                {
                    if (global.FormName == "ReportDesignTool")
                    {
                        OpenEtiketDesign();
                        return;
                    }

                    Type type = Type.GetType("BPS.Windows.Forms." + global.FormName);
                    if (type == null)
                    {
                        MessageBox.Show("Form nesnesi bulunamadı");
                        return;
                    }
                    FrmChildBase newForm = null;

                    #region  Form Initialize

                    switch (global.FormName)
                    {
                        case "FrmSiparis":
                            newForm = CompositionRoot.Resolve<FrmSiparis>() as FrmChildBase;
                            break;
                        case "FrmSatinalmaTalep":
                            newForm = CompositionRoot.Resolve<FrmSatinalmaTalep>() as FrmChildBase;
                            break;
                        case "FrmSatisTeklif":
                            newForm = CompositionRoot.Resolve<FrmSatisTeklif>() as FrmChildBase;
                            break;
                        case "FrmTipTanim":
                            newForm = CompositionRoot.Resolve<FrmTipTanim>() as FrmChildBase;
                            break;
                        case "FrmTipHareket":
                            newForm = CompositionRoot.Resolve<FrmTipHareket>() as FrmChildBase;
                            break;
                        case "FrmYetki":
                            newForm = CompositionRoot.Resolve<FrmYetki>() as FrmChildBase;
                            break;
                        case "FrmStokKart":
                            newForm = CompositionRoot.Resolve<FrmStokKart>() as FrmChildBase;
                            break;
                        case "FrmStokHareket":
                            newForm = CompositionRoot.Resolve<FrmStokHareket>() as FrmChildBase;
                            break;
                        case "FrmStokFiyat":
                            newForm = CompositionRoot.Resolve<FrmStokFiyat>() as FrmChildBase;
                            break;
                        case "FrmStokRapor":
                            newForm = CompositionRoot.Resolve<FrmStokRapor>() as FrmChildBase;
                            break;
                        case "FrmCariKart":
                            newForm = CompositionRoot.Resolve<FrmCariKart>() as FrmChildBase;
                            break;
                        case "FrmCariKartAdres":
                            newForm = CompositionRoot.Resolve<FrmCariKartAdres>() as FrmChildBase;
                            break;
                        case "FrmWmAdrt":
                            newForm = CompositionRoot.Resolve<FrmWmAdrt>() as FrmChildBase;
                            break;
                        case "FrmWmHrat":
                            newForm = CompositionRoot.Resolve<FrmWmHrat>() as FrmChildBase;
                            break;
                        case "FrmWmHrkt":
                            newForm = CompositionRoot.Resolve<FrmWmHrkt>() as FrmChildBase;
                            break;
                        case "FrmUrunAgacKalemTanim":
                            newForm = CompositionRoot.Resolve<FrmUrunAgacKalemTanim>() as FrmChildBase;
                            break;
                        case "FrmUrunAgacKullanimTipi":
                            newForm = CompositionRoot.Resolve<FrmUrunAgacKullanimTipi>() as FrmChildBase;
                            break;
                        case "FrmUrunAgaciMalzemeTuruTayin":
                            newForm = CompositionRoot.Resolve<FrmUrunAgaciMalzemeTuruTayin>() as FrmChildBase;
                            break;
                        case "FrmUrunAgaci":
                            newForm = CompositionRoot.Resolve<FrmUrunAgaci>() as FrmChildBase;
                            break;
                        case "FrmFisTip":
                            newForm = CompositionRoot.Resolve<FrmFisTip>() as FrmChildBase;
                            break;
                        case "FrmMalzemeTuruTanim":
                            newForm = CompositionRoot.Resolve<FrmMalzemeTuruTanim>() as FrmChildBase;
                            break;
                        case "FrmSirketTanim":
                            newForm = CompositionRoot.Resolve<FrmSirketTanim>() as FrmChildBase;
                            break;
                        case "FrmTedarikTuruTanim":
                            newForm = CompositionRoot.Resolve<FrmTedarikTuruTanim>() as FrmChildBase;
                            break;
                        case "FrmStkFiy":
                            newForm = CompositionRoot.Resolve<FrmStkFiy>() as FrmChildBase;
                            break;
                        case "FrmSiparisFisTip":
                            newForm = CompositionRoot.Resolve<FrmSiparisFisTip>() as FrmChildBase;
                            break;
                        case "FrmSaDegerAnahtarTanim":
                            newForm = CompositionRoot.Resolve<FrmSaDegerAnahtarTanim>() as FrmChildBase;
                            break;
                        case "FrmDepoNo":
                            newForm = CompositionRoot.Resolve<FrmDepoNo>() as FrmChildBase;
                            break;
                        case "FrmDepoTanimlama":
                            newForm = CompositionRoot.Resolve<FrmDepoTanimlama>() as FrmChildBase;
                            break;
                        case "FrmDepoTip":
                            newForm = CompositionRoot.Resolve<FrmDepoTip>() as FrmChildBase;
                            break;
                        case "FrmDovizKur":
                            newForm = CompositionRoot.Resolve<FrmDovizKur>() as FrmChildBase;
                            break;
                        case "FrmEvrakTanim":
                            newForm = CompositionRoot.Resolve<FrmEvrakTanim>() as FrmChildBase;
                            break;
                        case "FrmKullaniciTanimlama":
                            newForm = CompositionRoot.Resolve<FrmKullaniciTanimlama>() as FrmChildBase;
                            break;
                        case "FrmMesajTanim":
                            newForm = CompositionRoot.Resolve<FrmMesajTanim>() as FrmChildBase;
                            break;
                        case "FrmServisKarti":
                            newForm = CompositionRoot.Resolve<FrmServisKarti>() as FrmChildBase;
                            break;
                        case "FrmPersonel":
                            newForm = CompositionRoot.Resolve<FrmPersonel>() as FrmChildBase;
                            break;
                        case "FrmIsyeriTanim":
                            newForm = CompositionRoot.Resolve<FrmIsyeriTanim>() as FrmChildBase;
                            break;
                        case "FrmRevizyonTanim":
                            newForm = CompositionRoot.Resolve<FrmRevizyonTanim>() as FrmChildBase;
                            break;
                        case "FrmUrunOpsiyonTip":
                            newForm = CompositionRoot.Resolve<FrmUrunOpsiyonTip>() as FrmChildBase;
                            break;
                        case "FrmUrunOpsiyonHareket":
                            newForm = CompositionRoot.Resolve<FrmUrunOpsiyonHareket>() as FrmChildBase;
                            break;
                        case "FrmKosul":
                            newForm = CompositionRoot.Resolve<FrmKosul>() as FrmChildBase;
                            break;
                        case "FrmTeslimatFistip":
                            newForm = CompositionRoot.Resolve<FrmTeslimatFistip>() as FrmChildBase;
                            break;
                        case "FrmTeslimat":
                            newForm = CompositionRoot.Resolve<FrmTeslimat>() as FrmChildBase;
                            break;
                        case "FrmSaRapor":
                            newForm = CompositionRoot.Resolve<FrmSaRapor>() as FrmChildBase;
                            break;
                        case "FrmTeklifRapor":
                            newForm = CompositionRoot.Resolve<FrmTeklifRapor>() as FrmChildBase;
                            break;
                        case "FrmOnayOrganizasyon":
                            newForm = CompositionRoot.Resolve<FrmOnayOrganizasyon>() as FrmChildBase;
                            break;
                        case "FrmEksikPaketRapor":
                            newForm = CompositionRoot.Resolve<FrmEksikPaketRapor>() as FrmChildBase;
                            break;
                        case "FrmIsPlani":
	                        newForm = CompositionRoot.Resolve<FrmIsPlani>() as FrmChildBase;
	                        break;
                        case "FrmServisKullanici":
	                        newForm = CompositionRoot.Resolve<FrmServisKullanici>() as FrmChildBase;
	                        break;
                        case "FrmCrmIsKarti":
	                        newForm = CompositionRoot.Resolve<FrmCrmIsKarti>() as FrmChildBase;
	                        break;
                        case "FrmTedarikciStok":
                            newForm = CompositionRoot.Resolve<FrmTedarikciStok>() as FrmChildBase;
                            break;
                    }

                    #endregion

                    //global.Sira = 0;
                    //if (global.MenuName == "Sipariş") global.Sira = 1;
                    //if (global.MenuName == "Teslimat") global.Sira = 1;
                    //if (global.MenuName == "Satış Teklifi") global.Sira = 45;
                    //if (global.MenuName == "Satın Alma Teklifi") global.Sira = 6;
                    //if (global.FormName == "FrmSatinalmaTalep") global.Sira = 3;
                    

                    newForm.MdiParent = parentForm;
                    newForm.Name = global.FormName;
                    newForm.Text = global.MenuName;
                    newForm.SetStatusBarInfo = SetStatusBarInfo;
                    newForm.Tag = global;
                    newForm.global = global;
                    newForm.MenuYetki = yetki;
                    newForm.AccessibleName = global.ProjeKod;
                    newForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void OpenEtiketDesign()
        {
            repBarkodEtiket rEtiket = new repBarkodEtiket();
            rEtiket.lblStokAdi.Text = "";
            rEtiket.xrBarcode.Text = "";

            ReportDesignTool designTool = new ReportDesignTool(rEtiket);
            designTool.ShowRibbonDesignerDialog(UserLookAndFeel.Default);
        }

        private bool SetStatusBarInfo(bool formClosed, object menuItemInfo)
        {
            barModulAdi.Caption = "";
            barMenuAdi.Caption = "";
            barMenuTag.Caption = "";

            if (formClosed && MdiChildren.Count() == 1) return true;

            global = (Global)menuItemInfo;
            barModulAdi.Caption = global.ProjeTanim;
            barMenuAdi.Caption = global.MenuName;
            barMenuTag.Caption = global.MenuTag.ToString();

            return true;
        }

        private async Task SaveDailyCurrency(List<string> dvcnkdList)
        {
            foreach (var dovkod in dvcnkdList)
            {
                var response = _dovkurService.Cch_GetByDate_NLog(dovkod, DateTime.Now.Date);
                if (response.Status == ResponseStatusEnum.OK && response.Nesne == null)
                {
                    DOVKUR dovkur = new DOVKUR { DVCNKD = dovkod, DOVTRH = DateTime.Now.Date };
                    dovkur = _dovkurService.GetDovizKuru(dovkur);

                    if (dovkur != null && dovkur.DVFYT1 > 0)
                    {
                        dovkur.DOVTRH = DateTime.Now.Date;
                        _dovkurService.Ncch_AutoAdd_NLog(dovkur, global);
                    }
                }
            }
        }

        private void barKullaniciAdi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            popupMenu1.ShowPopup(MousePosition);
        }

        private void barButSifre_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
	        FrmSifreDegistir frmSifreDegistir = new FrmSifreDegistir(global);
	        frmSifreDegistir.ShowDialog();
        }

        private void barButCikis_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
	        DialogResult cikis = MessageBox.Show("Çıkış yapmak istediğinize emin misin?", "Çıkış Yap", MessageBoxButtons.YesNo,
		        MessageBoxIcon.Question);

	        if (cikis == DialogResult.Yes)
	        {
		        frmLogin.Show();
		        Hide();
	        }
        }
    }
}