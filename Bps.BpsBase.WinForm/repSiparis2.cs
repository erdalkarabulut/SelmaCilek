using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Bps.Core.Utilities.Helpers;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
    public partial class repSiparis2 : DevExpress.XtraReports.UI.XtraReport
    {
        private string _langCode;
        private string _currency;

        public repSiparis2(string langCode = "tr-TR", string currency = "TRY")
        {
            _langCode = langCode;
            _currency = currency;
            InitializeComponent();
            xrPictureBox1.Image = ImageHelper.GetCompanyLogo("logo1");
            SetFieldsLanguage();
        }

        private void SetFieldsLanguage()
        {
            if (_langCode.StartsWith("en-"))
            {
                lblBaslik.Text = "PRICE QUOTATION";
                lblPage.Text = "page:";
                lblTeklif.Text = "QUOTATION";
                lblNumarasi.Text = "No.";
                lblUrunKodu.Text = "PRODUCT CODE";
                lblUrunAdi.Text = "DESCRIPTION OF PRODUCT";
                lblMiktar.Text = "QUANTITY";
                lblBirim.Text = "UNIT";
                lblBrmFiyat.Text = "UNIT PRICE";
                lblToplam.Text = "TOTAL";
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("Türkiye", "Turkey");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("Telefon:", "Phone:");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("E-posta:", "E-mail:");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("ö", "o");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("Ş", "S");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("ü", "u");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("İ", "I");
                lblNumarasi.TextAlignment = TextAlignment.BottomRight;

                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("Banka adı", "Bank name");
                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("SWIFT kodu", "SWIFT code");
                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("Hesap adı", "Acc. name");
                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("Ş", "S");
                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("Banka adresi: Türkiye", "Bank address: Turkey");
            }
        }
    }
}
