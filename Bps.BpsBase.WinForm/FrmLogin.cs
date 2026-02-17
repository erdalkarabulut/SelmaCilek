using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.GN.Params;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using DevExpress.XtraBars.Navigation;
using Microsoft.Win32;
using BPS.Windows.Base;
using System.Configuration;

namespace BPS.Windows.Forms
{
    public partial class FrmLogin : XtraForm
    {
        [DllImport("gdi32", EntryPoint = "AddFontResource")]
        public static extern int AddFontResourceA(string lpFileName);

        private ISirketService _sirketService;
        private IGnkullService _gnkullService;
        private IGnyetkService _gnyetkService;
        private IGnthrkService _gnthrkService;

        RegistryKey register;
        public FrmLogin(ISirketService sirketService, IGnkullService gnkullService,
            IGnyetkService gnyetkService, IGnthrkService gnthrkService)
        {
            _sirketService = sirketService;
            _gnkullService = gnkullService;
            _gnyetkService = gnyetkService;
            _gnthrkService = gnthrkService;

            InstallFonts();

            InitializeComponent();
        }

        private void InstallFonts()
        {
            List<FontFamily> fontsFamilies = new List<FontFamily>(FontFamily.Families);
            if (!fontsFamilies.Exists(f => f.Name.Contains("NoirPro") || f.Name.Contains("Noir Pro")))
            {
                string exeDir = AppDomain.CurrentDomain.BaseDirectory;
                string path = Path.Combine(exeDir, "fonts\\NoirPro-Light.otf");
                AddFontResourceA(path);
                path = Path.Combine(exeDir, "fonts\\NoirPro-Medium.otf");
                AddFontResourceA(path);
                path = Path.Combine(exeDir, "fonts\\NoirPro-Regular.otf");
                AddFontResourceA(path);
                path = Path.Combine(exeDir, "fonts\\NoirPro-SemiBold.otf");
                AddFontResourceA(path);
            }
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            var sirketList = _sirketService.GetResmiSirketList().Items;
            string logoDir = AppDomain.CurrentDomain.BaseDirectory + "Logo\\Logo.png";
            if (File.Exists(logoDir))
            {
                Logo.Visible = true;

                Logo.Image = Image.FromFile(logoDir);
            }
            else
            {
                Logo.Visible = false;
            }
            string LogoPath = AppDomain.CurrentDomain.BaseDirectory;
            lkEdSirket.Properties.DataSource = sirketList;
            lkEdSirket.EditValue = 1;

            register = Registry.CurrentUser.CreateSubKey(@"Software\BPS", RegistryKeyPermissionCheck.ReadWriteSubTree);
            if (register.GetValue("Kullanici") != null)
            {
                txtKullaniciAdi.Text = register.GetValue("Kullanici").ToString();
            }
        }

        private void btnGiris_Click(object sender, EventArgs e)
        {
            //JsonClassGenerator.GenerateClassFromJson("dd.json","Station");

            //int seedValue = (DateTime.Now.Year.ToString() + DateTime.Now.DayOfYear.ToString()).ToInt32();
            //string metin = "bl";
            //foreach (char c in metin) seedValue += c;

            //Random random = new Random(seedValue);
            //string randomNumber = random.Next(1, 10001).ToString("d4");
            //MessageBox.Show(randomNumber.ToString());
            //return;

            //Bps.BpsBase.DataAccess.MySql mysql = new Bps.BpsBase.DataAccess.MySql();
            //var h = mysql.OpenConnection();
            //return;

            labelControl3.Visible = true;
            progressBarControl.Visible = true;

            foreach (Form frm in Application.OpenForms)
            {
                if (frm.Name == "FrmMain")
                {
                    frm.Activate();
                    return;
                }
            }

            var param = new GirisParam();
            param.KULKOD = txtKullaniciAdi.Text;
            param.PASSWD = txtSifre.Text;
            param.DilKod = "tr-TR";
            param.KaynakKod = "3";
            param.SIRKID = (int)lkEdSirket.EditValue;

            var loginResponse = _gnkullService.Ncch_UserLogin_Log(param, "");
            if (loginResponse.Status != ResponseStatusEnum.OK)
            {
                MessageBox.Show(loginResponse.Message);
                return;
            }

            register = Registry.CurrentUser.OpenSubKey(@"Software\BPS", true);
            register.SetValue("Kullanici", txtKullaniciAdi.Text);

            SIRKET sirket = lkEdSirket.GetSelectedDataRow() as SIRKET;
            GNKULL _kullanici = loginResponse.Nesne;

            Global global = new Global();
            global.UserKod = _kullanici.KULKOD;
            global.UserId = _kullanici.Id;
            global.FirstName = _kullanici.GNNAME;
            global.LastName = _kullanici.GNSNAM;
            global.Role = _kullanici.ROLEKD;
            global.KaynakKod = param.KaynakKod;
            global.DilKod = param.DilKod;
            global.Email = _kullanici.GNMAIL;
            global.SirketId = param.SIRKID;
            global.SirketType = true;
            global.SirketGuid = sirket.SRGUID;
            global.RenkBeden = sirket.RNKBDN ?? false;
            global.shopName = ConfigurationManager.AppSettings["shopName"];
            global.apiClientId = ConfigurationManager.AppSettings["apiClientId"];
            global.apiClientSecret = ConfigurationManager.AppSettings["apiClientSecret"];
            ///// silinecek
            //FrmChildBase newForm = null;
            //if (global.UserKod == "admin")
            //{
            //    newForm = CompositionRoot.Resolve<TempForm>() as FrmChildBase;
            //    newForm.global = global;
            //    newForm.Show();
            //}
            //return;
            ///// silinecek


            //FrmMain frmMain = new FrmMain();
            var frmMain = CompositionRoot.Resolve<FrmMain>();
            frmMain.accMenu.Elements.Clear();

            var projects = _gnthrkService.Cch_GetListByTeknad(global, "PROJKD", yetkiKontrol: false).Items;
            foreach (var project in projects)
            {
                bool yetki;
                var sonuc = _gnyetkService.Cch_GetProjeMenuYetkiList_NLog(global, global.UserKod, project.HARKOD);
                yetki = sonuc.Status == ResponseStatusEnum.OK ? true : false;

                var menus = _gnyetkService.Cch_GetProjeMenuYetkiList_NLog(global, project.HARKOD, global.UserKod).Items;
                if (menus.Count == 0) continue;

                var lst = menus.Where(m => m.GRNTLM).ToList();
                if (lst.Count == 0) continue;

                AccordionControlElement aceGroup = new AccordionControlElement
                {
                    Style = ElementStyle.Group,
                    Text = project.TANIMI,
                    Enabled = yetki,
                    Tag = project.HARKOD,
                    //Hint= project.SIRASI.ToString(),
                };
              
                aceGroup.Click += frmMain.MenuElement_Click;

                var parents = menus.Where(w => w.PARENT == 0 && w.GRNTLM).ToList();
                foreach (var parent in parents)
                {
                    var children = menus.Where(w => w.PARENT == parent.MNUTAG).OrderBy(o => o.SIRASI).ToList();

                    AccordionControlElement aceItem = new AccordionControlElement
                    {
                        Style = ElementStyle.Group,
                        Text = parent.MNUNAM,
                        Enabled = parent.GRNTLM,
                        Tag = parent.MNUTAG,
                        //Hint = parent.SIRASI.ToString(),
                        Visible = children.Count > 0
                    };

                    aceItem.Click += frmMain.MenuElement_Click;

                    foreach (var child in children)
                    {
                        if (string.IsNullOrEmpty(child.FORNM) || !child.GRNTLM)
                        {
                            continue;
                        }
                        var newGlobal = global.ShallowCopy();
                        newGlobal.ProjeKod = child.PROKOD;
                        newGlobal.ProjeTanim = project.TANIMI;
                        newGlobal.MenuTag = child.MNUTAG;
                        newGlobal.MenuName = child.MNUNAM;
                        newGlobal.FormName = child.FORNM;
                        newGlobal.Sira = child.SIRASI;
                        AccordionControlElement aceSubItem = new AccordionControlElement
                        {
                            Style = ElementStyle.Item,
                            Enabled = child.GRNTLM,
                            Text = child.MNUNAM,
                            Tag = newGlobal,
                            //Hint = child.SIRASI.ToString(),
                            TagInternal = child
                        };

                        aceSubItem.Click += frmMain.MenuElement_Click;
                        aceItem.Elements.Add(aceSubItem);
                    }

                    if (aceItem.Elements.Count > 0)
                    {
                        aceGroup.Elements.Add(aceItem);
                    }
                }

                if (aceGroup.Elements.Count > 0)
                {
                    frmMain.accMenu.Elements.Add(aceGroup);
                }
            }

            labelControl3.Visible = false;
            progressBarControl.Visible = false;

            this.Hide();
           

            if (global.UserKod == "sac")
            {
                FrmSacHareket frmSacHareket = new FrmSacHareket();
                frmSacHareket.global = global;
                frmSacHareket.Show();
            }
            else
            {
                frmMain.global = global;
                frmMain.frmLogin = this;
                
                frmMain.Show();
            }
        }

        private void picClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void FrmLogin_Shown(object sender, EventArgs e)
        {
            //btnGiris.Focus();
            txtKullaniciAdi.Focus();
        }

        private void txtKullaniciAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                SendKeys.Send("{TAB}");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}