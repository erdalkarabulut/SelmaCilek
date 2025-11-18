using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using Bps.Core.Utilities.Helpers;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
    public partial class repSiparis2LastPage : DevExpress.XtraReports.UI.XtraReport
    {
        private string _langCode;
        private string _currency;
        Color _backColor = Color.Transparent;

        public repSiparis2LastPage(string langCode = "tr-TR", string currency = "TRY")
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
                lblGenelToplam1.Text = "SUM TOTAL:";
                lblIskonto1.Text = "TOTAL DISCOUNT:";
                lblAraToplam1.Text = "SUB TOTAL:";
                lblKdv1.Text = null;
                lblNavlunUcretleri1.Text = "FREIGHT CHARGES:";
                lblDigerUcretler1.Text = "OTHER CHARGES:";
                lblNetTutar1.Text = "TOTAL AMOUNT:";
                lblOdenecekTutar1.Text = "AMOUNT TO BE PAID:";
                lblOdemeTablosu.Text = "PAYMENT SCHEDULE";
                lblAnlasmaKosullari.Text = "TERMS OF AGREEMENT";
                lblOdemeSekli.Text = "PAYMENT METHOD";
                lblOdemeTarihi.Text = "PAYMENT DATE";
                lblTutar.Text = "AMOUNT";
                lblDovizCinsi.Text = "CURRENCY";
                lblSignature1.Text = "Signature";
                lblSignature2.Text = "Signature";
                lblTeklifVeren.Text = "Quoted by";
                lblMusteriOnay.Text = "Customer";
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("Türkiye", "Turkey");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("Telefon:", "Phone:");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("E-posta:", "E-mail:");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("ö", "o");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("Ş", "S");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("ü", "u");
                lblCompanyInfo.Text = lblCompanyInfo.Text.Replace("İ", "I");

                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("Banka adı", "Bank name");
                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("SWIFT kodu", "SWIFT code");
                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("Hesap adı", "Acc. name");
                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("Ş", "S");
                lblHesapBanka.Text = lblHesapBanka1.Text = lblHesapBanka2.Text = lblHesapBanka.Text.Replace("Banka adresi: Türkiye", "Bank address: Turkey");
            }
        }

        private void repSiparis2LastPage_BeforePrint(object sender, System.Drawing.Printing.PrintEventArgs e)
        {
            decimal iskonto = 0;
            decimal.TryParse(lblIskonto.Text, out iskonto);

            decimal kdv = 0;
            decimal.TryParse(lblKdv.Text, out kdv);

            decimal navlun = 0;
            decimal.TryParse(lblNavlunUcretleri.Text, out navlun);

            decimal diger = 0;
            decimal.TryParse(lblDigerUcretler.Text, out diger);

            if (iskonto == 0)
            {
                lblIskonto.Text = null;
                lblIskonto1.Text = null;
                lblIskonto2.Text = null;
            }
            else lblIskonto.Text = iskonto.ToString("n2");

            if (kdv == 0)
            {
                lblKdv.Text = null;
                lblKdv1.Text = null;
                lblKdv2.Text = null;
            }
            else lblKdv.Text = kdv.ToString("n2");

            if (navlun == 0)
            {
                lblNavlunUcretleri.Text = null;
                lblNavlunUcretleri1.Text = null;
                lblNavlunUcretleri2.Text = null;
            }
            else lblNavlunUcretleri.Text = navlun.ToString("n2");

            if (diger == 0)
            {
                lblDigerUcretler.Text = null;
                lblDigerUcretler1.Text = null;
                lblDigerUcretler2.Text = null;
            }
            else lblDigerUcretler.Text = diger.ToString("n2");

            if (_langCode.StartsWith("en-"))
            {
                lblKdv.Text = null;
                lblKdv1.Text = null;
                lblKdv2.Text = null;

                decimal odenecekTutar = Convert.ToDecimal(lblNetTutar.Text) - kdv;
                lblNetTutar.Text = odenecekTutar.ToString("n2");
            }
            else if (_langCode == "tr-TR")
            {
                lblNavlunUcretleri.Text = null;
                lblNavlunUcretleri1.Text = null;
                lblNavlunUcretleri2.Text = null;
                lblDigerUcretler.Text = null;
                lblDigerUcretler1.Text = null;
                lblDigerUcretler2.Text = null;
            }

            SetColor("lblGenelToplam");
            SetColor("lblIskonto");
            SetColor("lblAraToplam");
            SetColor("lblKdv");
            SetColor("lblTevkifat");
            SetColor("lblNavlunUcretleri");
            SetColor("lblDigerUcretler");
            SetColor("lblNetTutar");
            SetColor("lblOdenecekTutar");
            SetColor("lblOdenecekTutarTL");
        }

        private void SetColor(string controlName)
        {
            if (!string.IsNullOrEmpty(PageHeader.Controls[controlName].Text))
            {
                if (_backColor == Color.Gainsboro) _backColor = Color.Transparent;
                else _backColor = Color.Gainsboro;

                PageHeader.Controls[controlName].BackColor = _backColor;
                PageHeader.Controls[controlName + "1"].BackColor = _backColor;
                PageHeader.Controls[controlName + "2"].BackColor = _backColor;
            }
        }
    }
}
