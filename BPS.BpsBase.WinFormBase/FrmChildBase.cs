using System;
using DevExpress.XtraBars;
using System.Windows.Forms;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Web.Model;
using DevExpress.XtraSplashScreen;

namespace BPS.Windows.Base
{
    public partial class FrmChildBase : DevExpress.XtraEditors.XtraForm, IFormActions
    {
        public Func<bool, object, bool> SetStatusBarInfo = (b, o) => true;
        public Global global = new Global();
        public ProjeMenuListed MenuYetki = new ProjeMenuListed();

        protected object toolBarButton;
        protected ItemClickEventArgs toolBarButtonArgs;

        public FrmChildBase()
        {
            InitializeComponent();
        }

        protected virtual void FrmChildBase_Load(object sender, EventArgs e)
        {
            SetStatusBarInfo(false, this.Tag);
            BarButtonItemControl();
        }

        protected virtual void FrmChildBase_Activated(object sender, EventArgs e)
        {
            SetStatusBarInfo(false, this.Tag);
        }

        protected virtual void FrmChildBase_FormClosed(object sender, FormClosedEventArgs e)
        {
            SetStatusBarInfo(true, this.Tag);
        }

        protected virtual void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            toolBarButton = sender;
            toolBarButtonArgs = e;

            SplashScreenManager.ShowForm(this, typeof(WaitForm1), true, true, false);
            try
            {
                Save();
            }
            finally
            {
                SplashScreenManager.CloseForm(false);
            }
        }

        protected virtual void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barOrtamEk_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barOrtamBelgeAkisi_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        public virtual void BarButtonItemControl()
        {
            barButOnayaGonder.Visibility = MenuYetki.GNONAY ? BarItemVisibility.OnlyInRuntime : BarItemVisibility.Never;
            barEkle.Enabled = MenuYetki.EKLEME;
            barDegistir.Enabled = MenuYetki.DEGIST;
            barSil.Enabled = MenuYetki.SILMEK;
            barKaydet.Enabled = MenuYetki.KAYDET;
        }

        protected virtual void barGeri_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        public virtual void Save()
        {

        }

        protected virtual void barGoruntule_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barKopyala_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barButOrnekDosya_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barButExcelAktar_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barButQrKod_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barButTedStokTnm_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barButShopify_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected virtual void barButShopifySip_ItemClick(object sender, ItemClickEventArgs e)
        {

        }
    }
}