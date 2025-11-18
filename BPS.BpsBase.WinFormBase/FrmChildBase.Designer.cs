
namespace BPS.Windows.Base
{
    partial class FrmChildBase
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmChildBase));
            this.barManager = new DevExpress.XtraBars.BarManager(this.components);
            this.bar1 = new DevExpress.XtraBars.Bar();
            this.barGoruntule = new DevExpress.XtraBars.BarButtonItem();
            this.barEkle = new DevExpress.XtraBars.BarButtonItem();
            this.barDegistir = new DevExpress.XtraBars.BarButtonItem();
            this.barKaydet = new DevExpress.XtraBars.BarButtonItem();
            this.barSil = new DevExpress.XtraBars.BarButtonItem();
            this.barVazgec = new DevExpress.XtraBars.BarButtonItem();
            this.barYenile = new DevExpress.XtraBars.BarButtonItem();
            this.barListe = new DevExpress.XtraBars.BarButtonItem();
            this.barBaskiOnizleme = new DevExpress.XtraBars.BarButtonItem();
            this.barFiltre = new DevExpress.XtraBars.BarButtonItem();
            this.barAktar = new DevExpress.XtraBars.BarButtonItem();
            this.popAktar = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButAktarPdf = new DevExpress.XtraBars.BarButtonItem();
            this.barButAktarHtml = new DevExpress.XtraBars.BarButtonItem();
            this.barButAktarMht = new DevExpress.XtraBars.BarButtonItem();
            this.barButAktarDocs = new DevExpress.XtraBars.BarButtonItem();
            this.barButAktarXls = new DevExpress.XtraBars.BarButtonItem();
            this.barButAktarXlsx = new DevExpress.XtraBars.BarButtonItem();
            this.barButAktarRtf = new DevExpress.XtraBars.BarButtonItem();
            this.barButAktarText = new DevExpress.XtraBars.BarButtonItem();
            this.barOrtam = new DevExpress.XtraBars.BarButtonItem();
            this.popOrtam = new DevExpress.XtraBars.PopupMenu(this.components);
            this.barButBelgeAkisi = new DevExpress.XtraBars.BarButtonItem();
            this.barButTopluAktarim = new DevExpress.XtraBars.BarButtonItem();
            this.barButEkler = new DevExpress.XtraBars.BarButtonItem();
            this.barButOnayaGonder = new DevExpress.XtraBars.BarButtonItem();
            this.barButOrnekDosya = new DevExpress.XtraBars.BarButtonItem();
            this.barButExcelAktar = new DevExpress.XtraBars.BarButtonItem();
            this.barButTedStok = new DevExpress.XtraBars.BarButtonItem();
            this.barButQrKod = new DevExpress.XtraBars.BarButtonItem();
            this.barButShopify = new DevExpress.XtraBars.BarButtonItem();
            this.barGeri = new DevExpress.XtraBars.BarButtonItem();
            this.barKopyala = new DevExpress.XtraBars.BarButtonItem();
            this.barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            this.barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            this.barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            this.barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            this.bar2 = new DevExpress.XtraBars.Bar();
            this.barButShopifySip = new DevExpress.XtraBars.BarButtonItem();
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            this.SuspendLayout();
            // 
            // barManager
            // 
            this.barManager.AllowCustomization = false;
            this.barManager.AllowQuickCustomization = false;
            this.barManager.Bars.AddRange(new DevExpress.XtraBars.Bar[] {
            this.bar1});
            this.barManager.DockControls.Add(this.barDockControlTop);
            this.barManager.DockControls.Add(this.barDockControlBottom);
            this.barManager.DockControls.Add(this.barDockControlLeft);
            this.barManager.DockControls.Add(this.barDockControlRight);
            this.barManager.Form = this;
            this.barManager.Items.AddRange(new DevExpress.XtraBars.BarItem[] {
            this.barEkle,
            this.barDegistir,
            this.barGoruntule,
            this.barKaydet,
            this.barSil,
            this.barVazgec,
            this.barListe,
            this.barBaskiOnizleme,
            this.barFiltre,
            this.barOrtam,
            this.barButBelgeAkisi,
            this.barButTopluAktarim,
            this.barButEkler,
            this.barButOnayaGonder,
            this.barButtonItem1,
            this.barAktar,
            this.barButAktarPdf,
            this.barButAktarHtml,
            this.barButAktarMht,
            this.barButAktarDocs,
            this.barButAktarXls,
            this.barButAktarXlsx,
            this.barButAktarRtf,
            this.barButAktarText,
            this.barButtonItem2,
            this.barGeri,
            this.barYenile,
            this.barKopyala,
            this.barButOrnekDosya,
            this.barButExcelAktar,
            this.barButQrKod,
            this.barButTedStok,
            this.barButShopify,
            this.barButShopifySip});
            this.barManager.MaxItemId = 35;
            // 
            // bar1
            // 
            this.bar1.BarName = "Tools";
            this.bar1.DockCol = 0;
            this.bar1.DockRow = 0;
            this.bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barGoruntule),
            new DevExpress.XtraBars.LinkPersistInfo(this.barEkle),
            new DevExpress.XtraBars.LinkPersistInfo(this.barDegistir),
            new DevExpress.XtraBars.LinkPersistInfo(this.barKaydet),
            new DevExpress.XtraBars.LinkPersistInfo(this.barSil),
            new DevExpress.XtraBars.LinkPersistInfo(this.barVazgec),
            new DevExpress.XtraBars.LinkPersistInfo(this.barYenile),
            new DevExpress.XtraBars.LinkPersistInfo(this.barListe, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barBaskiOnizleme),
            new DevExpress.XtraBars.LinkPersistInfo(this.barFiltre),
            new DevExpress.XtraBars.LinkPersistInfo(this.barAktar, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barOrtam, true),
            new DevExpress.XtraBars.LinkPersistInfo(this.barGeri),
            new DevExpress.XtraBars.LinkPersistInfo(this.barKopyala)});
            this.bar1.OptionsBar.AllowQuickCustomization = false;
            this.bar1.OptionsBar.AutoPopupMode = DevExpress.XtraBars.BarAutoPopupMode.None;
            this.bar1.OptionsBar.DisableCustomization = true;
            this.bar1.OptionsBar.DrawDragBorder = false;
            this.bar1.Text = "Tools";
            // 
            // barGoruntule
            // 
            this.barGoruntule.Caption = "Görüntüle";
            this.barGoruntule.Id = 27;
            this.barGoruntule.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barGoruntule.ImageOptions.Image")));
            this.barGoruntule.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barGoruntule.ImageOptions.LargeImage")));
            this.barGoruntule.Name = "barGoruntule";
            this.barGoruntule.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barGoruntule.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barGoruntule.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barGoruntule_ItemClick);
            // 
            // barEkle
            // 
            this.barEkle.Caption = "Ekle";
            this.barEkle.Id = 0;
            this.barEkle.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barEkle.ImageOptions.Image")));
            this.barEkle.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barEkle.ImageOptions.LargeImage")));
            this.barEkle.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F3);
            this.barEkle.Name = "barEkle";
            this.barEkle.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barEkle.Tag = "1";
            this.barEkle.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barEkle_ItemClick);
            // 
            // barDegistir
            // 
            this.barDegistir.Caption = "Değiştir";
            this.barDegistir.Id = 1;
            this.barDegistir.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barDegistir.ImageOptions.Image")));
            this.barDegistir.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barDegistir.ImageOptions.LargeImage")));
            this.barDegistir.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F4);
            this.barDegistir.Name = "barDegistir";
            this.barDegistir.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barDegistir.Tag = "2";
            this.barDegistir.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barDegistir_ItemClick);
            // 
            // barKaydet
            // 
            this.barKaydet.Caption = "Kaydet";
            this.barKaydet.Id = 2;
            this.barKaydet.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barKaydet.ImageOptions.Image")));
            this.barKaydet.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barKaydet.ImageOptions.LargeImage")));
            this.barKaydet.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F2);
            this.barKaydet.Name = "barKaydet";
            this.barKaydet.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barKaydet.Tag = "3";
            this.barKaydet.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barKaydet_ItemClick);
            // 
            // barSil
            // 
            this.barSil.Caption = "Sil";
            this.barSil.Id = 3;
            this.barSil.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barSil.ImageOptions.Image")));
            this.barSil.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barSil.ImageOptions.LargeImage")));
            this.barSil.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.Delete);
            this.barSil.Name = "barSil";
            this.barSil.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barSil.Tag = "4";
            this.barSil.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barSil_ItemClick);
            // 
            // barVazgec
            // 
            this.barVazgec.Caption = "Vazgeç";
            this.barVazgec.Id = 4;
            this.barVazgec.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barVazgec.ImageOptions.Image")));
            this.barVazgec.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barVazgec.ImageOptions.LargeImage")));
            this.barVazgec.Name = "barVazgec";
            this.barVazgec.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barVazgec.Tag = "5";
            this.barVazgec.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barVazgec_ItemClick);
            // 
            // barYenile
            // 
            this.barYenile.Caption = "Yenile";
            this.barYenile.Id = 26;
            this.barYenile.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barYenile.ImageOptions.Image")));
            this.barYenile.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barYenile.ImageOptions.LargeImage")));
            this.barYenile.ItemShortcut = new DevExpress.XtraBars.BarShortcut(System.Windows.Forms.Keys.F5);
            this.barYenile.Name = "barYenile";
            this.barYenile.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barYenile.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barYenile_ItemClick);
            // 
            // barListe
            // 
            this.barListe.Caption = "Liste";
            this.barListe.Id = 5;
            this.barListe.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barListe.ImageOptions.Image")));
            this.barListe.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barListe.ImageOptions.LargeImage")));
            this.barListe.Name = "barListe";
            this.barListe.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // barBaskiOnizleme
            // 
            this.barBaskiOnizleme.Caption = "Baskı Önizleme";
            this.barBaskiOnizleme.Id = 6;
            this.barBaskiOnizleme.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barBaskiOnizleme.ImageOptions.Image")));
            this.barBaskiOnizleme.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barBaskiOnizleme.ImageOptions.LargeImage")));
            this.barBaskiOnizleme.Name = "barBaskiOnizleme";
            this.barBaskiOnizleme.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barBaskiOnizleme.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barBaskiOnizleme_ItemClick);
            // 
            // barFiltre
            // 
            this.barFiltre.Caption = "Filtre";
            this.barFiltre.Id = 7;
            this.barFiltre.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barFiltre.ImageOptions.Image")));
            this.barFiltre.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barFiltre.ImageOptions.LargeImage")));
            this.barFiltre.Name = "barFiltre";
            this.barFiltre.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barFiltre.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barFiltre_ItemClick);
            // 
            // barAktar
            // 
            this.barAktar.ActAsDropDown = true;
            this.barAktar.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barAktar.Caption = "Aktar";
            this.barAktar.DropDownControl = this.popAktar;
            this.barAktar.Id = 15;
            this.barAktar.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barAktar.ImageOptions.Image")));
            this.barAktar.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barAktar.ImageOptions.LargeImage")));
            this.barAktar.Name = "barAktar";
            this.barAktar.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barAktar.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            // 
            // popAktar
            // 
            this.popAktar.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButAktarPdf),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButAktarHtml),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButAktarMht),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButAktarDocs),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButAktarXls),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButAktarXlsx),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButAktarRtf),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButAktarText)});
            this.popAktar.Manager = this.barManager;
            this.popAktar.Name = "popAktar";
            // 
            // barButAktarPdf
            // 
            this.barButAktarPdf.Caption = "PDF";
            this.barButAktarPdf.Id = 17;
            this.barButAktarPdf.Name = "barButAktarPdf";
            // 
            // barButAktarHtml
            // 
            this.barButAktarHtml.Caption = "HTML";
            this.barButAktarHtml.Id = 18;
            this.barButAktarHtml.Name = "barButAktarHtml";
            // 
            // barButAktarMht
            // 
            this.barButAktarMht.Caption = "MHT";
            this.barButAktarMht.Id = 19;
            this.barButAktarMht.Name = "barButAktarMht";
            // 
            // barButAktarDocs
            // 
            this.barButAktarDocs.Caption = "DOCS";
            this.barButAktarDocs.Id = 20;
            this.barButAktarDocs.Name = "barButAktarDocs";
            // 
            // barButAktarXls
            // 
            this.barButAktarXls.Caption = "XLS";
            this.barButAktarXls.Id = 21;
            this.barButAktarXls.Name = "barButAktarXls";
            // 
            // barButAktarXlsx
            // 
            this.barButAktarXlsx.Caption = "XLSX";
            this.barButAktarXlsx.Id = 22;
            this.barButAktarXlsx.Name = "barButAktarXlsx";
            // 
            // barButAktarRtf
            // 
            this.barButAktarRtf.Caption = "RTF";
            this.barButAktarRtf.Id = 23;
            this.barButAktarRtf.Name = "barButAktarRtf";
            // 
            // barButAktarText
            // 
            this.barButAktarText.Caption = "TEXT";
            this.barButAktarText.Id = 24;
            this.barButAktarText.Name = "barButAktarText";
            // 
            // barOrtam
            // 
            this.barOrtam.ActAsDropDown = true;
            this.barOrtam.ButtonStyle = DevExpress.XtraBars.BarButtonStyle.DropDown;
            this.barOrtam.Caption = "Ortam";
            this.barOrtam.DropDownControl = this.popOrtam;
            this.barOrtam.Id = 8;
            this.barOrtam.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barOrtam.ImageOptions.Image")));
            this.barOrtam.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barOrtam.ImageOptions.LargeImage")));
            this.barOrtam.Name = "barOrtam";
            this.barOrtam.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            // 
            // popOrtam
            // 
            this.popOrtam.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] {
            new DevExpress.XtraBars.LinkPersistInfo(this.barButBelgeAkisi),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButTopluAktarim),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButEkler),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButOnayaGonder),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButOrnekDosya),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButExcelAktar),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButTedStok),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButQrKod),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButShopify),
            new DevExpress.XtraBars.LinkPersistInfo(this.barButShopifySip)});
            this.popOrtam.Manager = this.barManager;
            this.popOrtam.Name = "popOrtam";
            // 
            // barButBelgeAkisi
            // 
            this.barButBelgeAkisi.Caption = "Belge Akışı";
            this.barButBelgeAkisi.Id = 23;
            this.barButBelgeAkisi.Name = "barButBelgeAkisi";
            this.barButBelgeAkisi.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barOrtamBelgeAkisi_ItemClick);
            // 
            // barButTopluAktarim
            // 
            this.barButTopluAktarim.Caption = "Toplu Aktarım";
            this.barButTopluAktarim.Id = 10;
            this.barButTopluAktarim.Name = "barButTopluAktarim";
            // 
            // barButEkler
            // 
            this.barButEkler.Caption = "Ekler";
            this.barButEkler.Id = 11;
            this.barButEkler.Name = "barButEkler";
            this.barButEkler.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barOrtamEk_ItemClick);
            // 
            // barButOnayaGonder
            // 
            this.barButOnayaGonder.Caption = "Onaya Gönder";
            this.barButOnayaGonder.Id = 12;
            this.barButOnayaGonder.Name = "barButOnayaGonder";
            this.barButOnayaGonder.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            // 
            // barButOrnekDosya
            // 
            this.barButOrnekDosya.Caption = "Aktarım Örnek Dosya İndir";
            this.barButOrnekDosya.Id = 29;
            this.barButOrnekDosya.Name = "barButOrnekDosya";
            this.barButOrnekDosya.Tag = "1001";
            this.barButOrnekDosya.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            this.barButOrnekDosya.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButOrnekDosya_ItemClick);
            // 
            // barButExcelAktar
            // 
            this.barButExcelAktar.Caption = "Excelden Aktarım Yap";
            this.barButExcelAktar.Id = 30;
            this.barButExcelAktar.Name = "barButExcelAktar";
            this.barButExcelAktar.Tag = "1002";
            this.barButExcelAktar.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            this.barButExcelAktar.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButExcelAktar_ItemClick);
            // 
            // barButTedStok
            // 
            this.barButTedStok.Caption = "Tedarikçi Stok Tanımlama";
            this.barButTedStok.Id = 32;
            this.barButTedStok.Name = "barButTedStok";
            this.barButTedStok.Tag = "1003";
            this.barButTedStok.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            this.barButTedStok.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButTedStokTnm_ItemClick);
            // 
            // barButQrKod
            // 
            this.barButQrKod.Caption = "QR Kod Oluşturucu";
            this.barButQrKod.Id = 31;
            this.barButQrKod.Name = "barButQrKod";
            this.barButQrKod.Tag = "1004";
            this.barButQrKod.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            this.barButQrKod.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButQrKod_ItemClick);
            // 
            // barButShopify
            // 
            this.barButShopify.Caption = "Shopify Ürün Entegrasyon";
            this.barButShopify.Id = 33;
            this.barButShopify.Name = "barButShopify";
            this.barButShopify.Tag = "1005";
            this.barButShopify.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            this.barButShopify.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButShopify_ItemClick);
            // 
            // barGeri
            // 
            this.barGeri.Caption = "Geri";
            this.barGeri.Id = 25;
            this.barGeri.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barGeri.ImageOptions.Image")));
            this.barGeri.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barGeri.ImageOptions.LargeImage")));
            this.barGeri.Name = "barGeri";
            this.barGeri.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barGeri.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;
            this.barGeri.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barGeri_ItemClick);
            // 
            // barKopyala
            // 
            this.barKopyala.Caption = "Kopyala";
            this.barKopyala.Id = 28;
            this.barKopyala.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("barKopyala.ImageOptions.Image")));
            this.barKopyala.ImageOptions.LargeImage = ((System.Drawing.Image)(resources.GetObject("barKopyala.ImageOptions.LargeImage")));
            this.barKopyala.Name = "barKopyala";
            this.barKopyala.PaintStyle = DevExpress.XtraBars.BarItemPaintStyle.CaptionGlyph;
            this.barKopyala.Tag = "12";
            this.barKopyala.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barKopyala_ItemClick);
            // 
            // barDockControlTop
            // 
            this.barDockControlTop.CausesValidation = false;
            this.barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            this.barDockControlTop.Location = new System.Drawing.Point(0, 0);
            this.barDockControlTop.Manager = this.barManager;
            this.barDockControlTop.Size = new System.Drawing.Size(957, 24);
            // 
            // barDockControlBottom
            // 
            this.barDockControlBottom.CausesValidation = false;
            this.barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.barDockControlBottom.Location = new System.Drawing.Point(0, 463);
            this.barDockControlBottom.Manager = this.barManager;
            this.barDockControlBottom.Size = new System.Drawing.Size(957, 0);
            // 
            // barDockControlLeft
            // 
            this.barDockControlLeft.CausesValidation = false;
            this.barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.barDockControlLeft.Location = new System.Drawing.Point(0, 24);
            this.barDockControlLeft.Manager = this.barManager;
            this.barDockControlLeft.Size = new System.Drawing.Size(0, 439);
            // 
            // barDockControlRight
            // 
            this.barDockControlRight.CausesValidation = false;
            this.barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.barDockControlRight.Location = new System.Drawing.Point(957, 24);
            this.barDockControlRight.Manager = this.barManager;
            this.barDockControlRight.Size = new System.Drawing.Size(0, 439);
            // 
            // barButtonItem1
            // 
            this.barButtonItem1.Caption = "barButtonItem1";
            this.barButtonItem1.Id = 14;
            this.barButtonItem1.Name = "barButtonItem1";
            // 
            // barButtonItem2
            // 
            this.barButtonItem2.Caption = "barButtonItem2";
            this.barButtonItem2.Id = 16;
            this.barButtonItem2.Name = "barButtonItem2";
            // 
            // bar2
            // 
            this.bar2.BarName = "Custom 3";
            this.bar2.DockCol = 0;
            this.bar2.DockRow = 1;
            this.bar2.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            this.bar2.Text = "Custom 3";
            // 
            // barButShopifySip
            // 
            this.barButShopifySip.Caption = "Shopify Siparişler";
            this.barButShopifySip.Id = 34;
            this.barButShopifySip.Name = "barButShopifySip";
            this.barButShopifySip.Tag = "1006";
            this.barButShopifySip.Visibility = DevExpress.XtraBars.BarItemVisibility.OnlyInCustomizing;
            this.barButShopifySip.ItemClick += new DevExpress.XtraBars.ItemClickEventHandler(this.barButShopifySip_ItemClick);
            // 
            // FrmChildBase
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.barDockControlLeft);
            this.Controls.Add(this.barDockControlRight);
            this.Controls.Add(this.barDockControlBottom);
            this.Controls.Add(this.barDockControlTop);
            this.DoubleBuffered = true;
            this.IconOptions.Image = global::BPS.Windows.Base.Properties.Resources.logo;
            this.Name = "FrmChildBase";
            this.Text = "ChildBase";
            this.Activated += new System.EventHandler(this.FrmChildBase_Activated);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmChildBase_FormClosed);
            this.Load += new System.EventHandler(this.FrmChildBase_Load);
            ((System.ComponentModel.ISupportInitialize)(this.barManager)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        protected DevExpress.XtraBars.BarManager barManager;
        protected DevExpress.XtraBars.Bar bar1;
        protected DevExpress.XtraBars.BarDockControl barDockControlTop;
        protected DevExpress.XtraBars.BarDockControl barDockControlBottom;
        protected DevExpress.XtraBars.BarDockControl barDockControlLeft;
        protected DevExpress.XtraBars.BarDockControl barDockControlRight;
        protected DevExpress.XtraBars.BarButtonItem barEkle;
        protected DevExpress.XtraBars.BarButtonItem barDegistir;
        protected DevExpress.XtraBars.BarButtonItem barKaydet;
        protected DevExpress.XtraBars.BarButtonItem barSil;
        protected DevExpress.XtraBars.BarButtonItem barVazgec;
        protected DevExpress.XtraBars.BarButtonItem barListe;
        protected DevExpress.XtraBars.BarButtonItem barBaskiOnizleme;
        protected DevExpress.XtraBars.BarButtonItem barFiltre;
        protected DevExpress.XtraBars.BarButtonItem barOrtam;
        protected DevExpress.XtraBars.BarButtonItem barButBelgeAkisi;
        protected DevExpress.XtraBars.BarButtonItem barButTopluAktarim;
        protected DevExpress.XtraBars.BarButtonItem barButEkler;
        protected DevExpress.XtraBars.BarButtonItem barButOnayaGonder;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem1;
        protected DevExpress.XtraBars.PopupMenu popAktar;
        protected DevExpress.XtraBars.BarButtonItem barButtonItem2;
        protected DevExpress.XtraBars.BarButtonItem barAktar;

        protected DevExpress.XtraBars.BarButtonItem barButAktarPdf;
        protected DevExpress.XtraBars.BarButtonItem barButAktarHtml;
        protected DevExpress.XtraBars.BarButtonItem barButAktarMht;
        protected DevExpress.XtraBars.BarButtonItem barButAktarDocs;
        protected DevExpress.XtraBars.BarButtonItem barButAktarXls;
        protected DevExpress.XtraBars.BarButtonItem barButAktarXlsx;
        protected DevExpress.XtraBars.BarButtonItem barButAktarRtf;
        protected DevExpress.XtraBars.BarButtonItem barButAktarText;
        protected DevExpress.XtraBars.PopupMenu popOrtam;
        private DevExpress.XtraBars.BarButtonItem barGeri;
        private DevExpress.XtraBars.BarButtonItem barYenile;
        private DevExpress.XtraBars.BarButtonItem barGoruntule;
        private DevExpress.XtraBars.Bar bar2;
        private DevExpress.XtraBars.BarButtonItem barKopyala;
        private DevExpress.XtraBars.BarButtonItem barButOrnekDosya;
        private DevExpress.XtraBars.BarButtonItem barButExcelAktar;
        private DevExpress.XtraBars.BarButtonItem barButQrKod;
        private DevExpress.XtraBars.BarButtonItem barButTedStok;
        private DevExpress.XtraBars.BarButtonItem barButShopify;
        private DevExpress.XtraBars.BarButtonItem barButShopifySip;
    }
}