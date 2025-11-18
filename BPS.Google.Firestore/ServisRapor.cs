using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace BPS.Google.Firestore
{
    public partial class ServisRapor : DevExpress.XtraReports.UI.XtraReport
    {
        private string _langCode;
        private string _currency;

        public ServisRapor(string langCode = "tr-TR", string currency = "TRY")
        {
            _langCode = langCode;
            _currency = currency;
            InitializeComponent();
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
                lblAdres.Text = lblAdres.Text.Replace("Türkiye", "Turkey");
                lblAdres.Text = lblAdres.Text.Replace("Telefon:", "Phone:");
                lblAdres.Text = lblAdres.Text.Replace("E-posta:", "E-mail:");
                lblAdres.Text = lblAdres.Text.Replace("ö", "o");
                lblAdres.Text = lblAdres.Text.Replace("Ş", "S");
                lblAdres.Text = lblAdres.Text.Replace("ü", "u");
                lblAdres.Text = lblAdres.Text.Replace("İ", "I");
                lblNumarasi.TextAlignment = TextAlignment.BottomRight;
            }
        }
    }
}
