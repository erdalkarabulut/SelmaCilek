using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.Entities.Constants;
using Bps.BpsBase.Entities.Models.GN.Enums;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.BpsBase.Entities.Models.UA;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using BPS.Windows.Forms.UA;
using DevExpress.Utils;
using DevExpress.Utils.DragDrop;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using PopupMenuShowingEventArgs = DevExpress.XtraTreeList.PopupMenuShowingEventArgs;

namespace BPS.Windows.Forms
{
    public partial class FrmUrunAgaci : BPS.Windows.Base.FrmChildBase
    {
        private IStkartService _stokKartService;
        private IUragacService _urunAgaciService;
        private IUastbgService _urunAgacStokBaglantiService;
        private IUakltnService _urunAgacKalemTanimService;
        private IUamltyService _urunAgaciMalzemeTuruTayinService;
        private IGnevrkService _gnevrkService;
        private IGnthrkService _gnthrkService;
        private IGnyetkService _gnyetkService;
        private IStmaltService _stmaltService;
        private IUakltpService _uakltpService;
        private IIsrevzService _isrevzService;
        private ISpfharService _spfharService;
        private IDovkurService _dovkurService;
        private IStbdrnService _stbdrnService;

        private ProjeMenuListed yetkiModel;
        private DataSet dataSet = new DataSet();
        private DataTable dt1 = new DataTable();
        private DataTable dt2 = new DataTable();
        private static List<UrunAgaciTreeList> list1 = new List<UrunAgaciTreeList>();
        private static List<UrunAgaciTreeList> list2 = new List<UrunAgaciTreeList>();
        private static IList<UrunAgaciRevizyonList> listRvList;
        private static IList<STKART> list;

        private URAGAC _urunAgaci;
        private string _action;
        int maxAltId = 0;
        string modulAdi = "";
        string takimAdi = "";
        string modulKodu = "";
        string takimKodu = "";
        int uretimAdet = 1;
        STKART stokTakim;
        STKART stokModul;
        STKART stokPaket;
        STKART stokParca;
        STMALT tur;
        private List<STKART> stokList;
        private Dictionary<int, List<URAGVR>> variantList = new Dictionary<int, List<URAGVR>>();

        public FrmUrunAgaci(IStkartService stokKartService, IUragacService urunAgaciService,
            IUastbgService urunAgacStokBaglantiService, IUakltnService urunAgacKalemTanimService,
            IUamltyService urunAgaciMalzemeTuruTayinService, IGnevrkService gnevrkService,
            IGnthrkService gnthrkService, IGnyetkService gnyetkService, IDovkurService dovkurService,
            IStmaltService stmaltService, IUakltpService uakltpService,
            IIsrevzService isrevzService, ISpfharService spfharService,
            IStbdrnService stbdrnService)
        {
            InitializeComponent();
            _stokKartService = stokKartService;
            _urunAgaciService = urunAgaciService;
            _urunAgacStokBaglantiService = urunAgacStokBaglantiService;
            _urunAgacKalemTanimService = urunAgacKalemTanimService;
            _urunAgaciMalzemeTuruTayinService = urunAgaciMalzemeTuruTayinService;
            _stmaltService = stmaltService;
            _gnevrkService = gnevrkService;
            _gnthrkService = gnthrkService;
            _gnyetkService = gnyetkService;
            _uakltpService = uakltpService;
            _isrevzService = isrevzService;
            _spfharService = spfharService;
            _dovkurService = dovkurService;
            _stbdrnService = stbdrnService;

            InitProjectsData();
            DragDropManager.Default.DragOver += OnDragOver;
            DragDropManager.Default.DragDrop += OnDragDrop;

            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
        }

        private void FrmUrunAgac_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;

            FormIslemleri.FormYetki2(barManager, yetkiModel);

            var teknads = new List<string>() { "URYRKD", "OLCUKD", "RENKKD", "BEDNKD", "DROPKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            var malzemeTuruTanimList = _stmaltService.Cch_GetList_NLog(global, false).Items;
            var uretimYeriList = teknadsResponse.Items.Where(w => w.TEKNAD == "URYRKD").ToList();
            var urunAgacKullanimTipi = _uakltpService.Cch_GetList_NLog(global, false).Items;
            var malzemeTuruTanimListP2 = _stmaltService.Cch_GetList_NLog(global, false).Items;
            stokList = _stokKartService.Cch_GetList_NLog(global, false).Items;
            var renkKdlist = teknadsResponse.Items.Where(w => w.TEKNAD == "RENKKD").ToList();
            var bedenKdlist = teknadsResponse.Items.Where(w => w.TEKNAD == "BEDNKD").ToList();
            var dropKdlist = teknadsResponse.Items.Where(w => w.TEKNAD == "DROPKD").ToList();

            repStokAdi.DataSource = stokList;
            repKalemTipi.DataSource = _urunAgacKalemTanimService.Cch_GetList_NLog(global, false).Items;
            repOlcuBirimi.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();
            repUretimYeri.DataSource = uretimYeriList;

            LkEdMlzTuruP2.Properties.DataSource = malzemeTuruTanimListP2;
            LkEdMalzTuru.Properties.DataSource = malzemeTuruTanimList;
            LkEdUretimYeriKodu.Properties.DataSource = uretimYeriList;
            LkEdUAKullanimKodu.Properties.DataSource = urunAgacKullanimTipi;
            LkEdUretimYeriKoduP2.Properties.DataSource = uretimYeriList;
            LkEdUAKullanimKoduP2.Properties.DataSource = urunAgacKullanimTipi;
            LkEdRenkKdP2.Properties.DataSource = LkEdRenkKd.Properties.DataSource = renkKdlist;
            LkEdBedenKdP2.Properties.DataSource = LkEdBedenKd.Properties.DataSource = bedenKdlist;
            LkEdDropKdP2.Properties.DataSource = LkEdDropKd.Properties.DataSource = dropKdlist;
            GridHelper.ColumnRepositoryItems(repLookUpVryKodView, global);
            GridHelper.ColumnRepositoryItems(repLookUpRENKKDView, global);
            GridHelper.ColumnRepositoryItems(gridViewLkEdVrKodu, global);
            GridHelper.ColumnRepositoryItems(gridViewLkEdVrKoduP2, global);
            if (global.RenkBeden == false || global.RenkBeden == null)
            {
                treeVryKodu.Visible = false;
                treeRenkKd.Visible = false;
                treeBednKd.Visible = false;
               
            }    
            else
            {
                treeVaryant.Visible = false;
            }
            //treeList.MouseDown += TreeList_MouseDown;
            //treeList.MouseMove += TreeList_MouseMove;
            //btnTrash.DragEnter += BtnTrash_DragEnter;
            //btnTrash.DragDrop += BtnTrash_DragDrop;
            //InitValidationRules();
            //dxValidationProvider.ValidationMode = ValidationMode.Auto;
        }

        TreeListNode draggedNode = null;

        //private void TreeList_MouseDown(object sender, MouseEventArgs e)
        //{
        //    TreeListHitInfo hitInfo = treeList.CalcHitInfo(e.Location);
        //    if (hitInfo.Node != null)
        //    {
        //        draggedNode = hitInfo.Node;
        //    }
        //}

        //private void TreeList_MouseMove(object sender, MouseEventArgs e)
        //{
        //    if (draggedNode != null && e.Button == MouseButtons.Left)
        //    {
        //        treeList.DoDragDrop(draggedNode, DragDropEffects.Move);
        //    }
        //}
        //private void BtnTrash_DragEnter(object sender, DragEventArgs e)
        //{
        //    e.Effect = DragDropEffects.Move;
        //    btnTrash.Image = Properties.Resources.trash_closed; // Açık çöp kutusu ikonu
        //}
        //private void BtnTrash_DragDrop(object sender, DragEventArgs e)
        //{
        //    if (draggedNode != null)
        //    {
        //        treeList.DoDragDrop(draggedNode, DragDropEffects.Move);
        //        treeList.Nodes.Remove(draggedNode);
        //        draggedNode = null;

             
        //        btnTrash.Image = Properties.Resources.trash_open; // Kapalı çöp kutusu ikonu
        //    }
        //}


        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TxtStokKodu.Text == "")
            {
                MessageBox.Show("Ürün seçmeden ürün ağacı oluşturamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (LkEdUretimYeriKodu.Text == "" || LkEdUAKullanimKodu.Text == "")
            {
                MessageBox.Show("Üretim Yeri ve Kullanım alanları boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var uAMalzTuruTayin = _urunAgaciMalzemeTuruTayinService.Cch_GetListByUaKodAndMaltr_NLog(global, LkEdUAKullanimKodu.Text,
                LkEdMalzTuru.EditValue.ToString(), false);
            if (uAMalzTuruTayin == null)
            {
                MessageBox.Show(LkEdMalzTuru.Text + " için " + LblUAKullanimText.Text +
                                " ürün ağacı oluşturamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((LbRenkKd.Visible) || (LbBedenKd.Visible) || (LbDropKd.Visible))
            {
                if (LkEdVrKodu.Text == "")
                {
                    MessageBox.Show("Varyant seçmeden ürün ağacı oluşturamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
            variantList = new Dictionary<int, List<URAGVR>>();

            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";

            bool urunAgaciVar = RefreshTreeList();
            if (!urunAgaciVar) return;

            var revizyontanimlistP2 = _isrevzService.Cch_GetListByUAModel_NLog(global, false).Items;
            LkEdRevizyonNoP2.Properties.DataSource = revizyontanimlistP2;
            LkEdRevizyonNo.EditValue = null;
            LkEdRevizyonNoP2.EditValue = null;
            TxtUrunAgacKodu.Text = "";
            TxtUrunAgacKoduP2.Text = "";
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TxtStokKodu.Text == "")
            {
                MessageBox.Show("Ürün seçmeden ürün ağacı düzenleyemezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (LkEdUretimYeriKodu.Text == "" || LkEdUAKullanimKodu.Text == "" || LkEdRevizyonNo.Text == "")
            {
                MessageBox.Show("Üretim Yeri, Kullanım ve Revizyon No alanları boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            if ((LbRenkKd.Visible) || (LbBedenKd.Visible) || (LbDropKd.Visible))
            {
                if (LkEdVrKodu.Text == "")
                {
                    MessageBox.Show("Varyant seçmeden ürün ağacı oluşturamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }

            if (TxtUrunAgacKodu.Text == "") return;

            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;

            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";
            if ((bool)global.RenkBeden )
            {
                var urunAgaci = _urunAgaciService.Ncch_GetMaxRevizyonNo_NLog(TxtStokKodu.EditValue.ToString(), LkEdUAKullanimKoduP2.EditValue.ToString(), global, LkEdVrKoduP2.EditValue.ToString()).Items;
                LkEdRevizyonNoP2.Properties.DataSource = urunAgaci;
            }
            else
            {
                var urunAgaci = _urunAgaciService.Ncch_GetMaxRevizyonNo_NLog(TxtStokKodu.EditValue.ToString(), LkEdUAKullanimKoduP2.EditValue.ToString(), global).Items;
                LkEdRevizyonNoP2.Properties.DataSource = urunAgaci;
            }
            //LkEdRevizyonNoP2.Properties.DataSource = urunAgaci;
            LkEdRevizyonNoP2.Text = LkEdRevizyonNo.Text;
            LkEdRevizyonNoP2.Enabled = false;
            LkEdUretimYeriKoduP2.Enabled = false;
            LkEdUAKullanimKoduP2.Enabled = false;
            TxtUrunAgacKoduP2.Text = TxtUrunAgacKodu.Text;

            bool urunAgaciVar = RefreshTreeList();
            if (!urunAgaciVar) return;

            treeList.DataSource = dataSet.Tables[0];
            treeList.ExpandAll();
            treeList.BestFitColumns();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();
            if (LkEdUretimYeriKoduP2.Text == "" || LkEdUAKullanimKoduP2.Text == "" || LkEdRevizyonNoP2.Text == "")
            {
                MessageBox.Show("Lütfen gerekli tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                return;
            }

            string error = "";
            string _Numara = "";
            int _parent = 0;
            List<TreeListNode> _nodes = treeList.GetNodeList();

            //using (TransactionScope ts = new TransactionScope())
            //{
                try
                {
                    if (_action == "insert")
                    {
                        var evrakmodel = new EvrakNoUretParamModel();
                        evrakmodel.TabloAdi = "URAGAC";
                        evrakmodel.TeknikAd = "URAKOD";
                        evrakmodel.IslemTur = 0;
                        var evrakResponse = _gnevrkService.Ncch_EvrakNoUret_NLog(global, evrakmodel);
                        //_numaraUrunAgaci = evrakResponse.GetById(1);

                        if (evrakResponse.Status != ResponseStatusEnum.OK)
                        {
                            MessageBox.Show("İşlem yapılamadı " + evrakResponse.Message);
                            return;
                        }

                        _Numara = evrakResponse.Nesne;

                        //_numaraUrunAgaciService.Update(new NumaraUrunAgaci { Numara = _Numara.ToString(), Id = 1 });
                        UASTBG uastbg = new UASTBG()
                        {
                            STKODU = TxtStokKoduP2.Text,
                            URYRKD = LkEdUretimYeriKoduP2.EditValue.ToString(),
                            KLNKOD = LkEdUAKullanimKoduP2.EditValue.ToString(),
                            VRKODU = LkEdVrKoduP2.EditValue == null ? null : LkEdVrKoduP2.EditValue.ToString(),
                            URAKOD = _Numara,
                            ALTERN = 1,
                            GNREZV = LkEdRevizyonNoP2.Text,
                            ACTIVE = true,

                        };

                        _urunAgacStokBaglantiService.Ncch_Add_NLog(uastbg, global);
                    }
                    else
                    {
                        _Numara = TxtUrunAgacKoduP2.Text;
                        _urunAgaciService.Ncch_DeleteList_Log(TxtUrunAgacKoduP2.Text, global);
                    }

                    foreach (TreeListNode node in _nodes)
                    {
                        DataRowView rowView = treeList.GetRow(node.Id) as DataRowView;
                        if (rowView["MalzemeTuru"].ToString() == "") continue;

                        //MessageBox.Show(rowView["Miktar"].ToString());

                        string stokKodu = rowView["StokKodu"].ToString();
                        decimal miktar = 0;
                        decimal.TryParse(rowView["Miktar"].ToString(), out miktar);

                        if (miktar == 0)
                        {
                            string stokAdi = stokList.FirstOrDefault(s => s.STKODU == stokKodu).STKNAM;
                            error = stokKodu + " - " + stokAdi + " için miktar girmediniz!";
                            throw new Exception(error);
                        }

                        if (node.Level != 0)
                        {
                            _parent = node.ParentNode.Id;
                        }
                        else
                        {
                            _parent = node.Id;
                        }

                        URAGAC urAgac = new URAGAC()
                        {
                            STKODU = stokKodu,
                            VRKODU = rowView["VryKodu"] == null || rowView["VryKodu"].ToString() =="" ? null : rowView["VryKodu"].ToString(),
                            CHILDD = node.Id,
                            PARENT = _parent,
                            GNREZV = LkEdRevizyonNoP2.Text,
                            SEVIYE = node.Level,
                            URAKOD = _Numara,
                            SLINDI = Convert.ToBoolean(rowView["Silme"].ToString()),
                            URYRKD = rowView["UretimYeriKodu"].ToString(),
                            URKLTP = rowView["KalemTipi"].ToString(),
                            SIRALM = rowView["Siralama"].ToString() == "" ? null : rowView["Siralama"].ToString(),
                            OLCUKD = rowView["OlcuBirimiKodu"].ToString(),
                            GNMKTR = (decimal)rowView["Miktar"],
                            SBTMIK = Convert.ToDecimal(rowView["SabitMiktar"].ToString()),
                            STKKLM = true,
                            MTNKLM = false,
                            FTNKLM = Convert.ToBoolean(rowView["FantomKalemi"].ToString()),
                            STMLTR = rowView["MalzemeTuru"].ToString(),
                            AURKOD = rowView["AltUrunAgaciKodu"].ToString() != ""
                                ? rowView["AltUrunAgaciKodu"].ToString()
                                : _Numara,
                            ACTIVE = true
                        };

                        var ua = _urunAgaciService.Ncch_Add_NLog(urAgac, global).Nesne;

                    }
                    //ts.Complete();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.GetBaseException().Message, "Kayıt Yapılamadı", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    //ts.Dispose();

                    if (error == "")
                    {
                        TxtUrunAgacKoduP2.Text = _Numara.ToString();

                        treeList.ClearNodes();
                        treeList.DataSource = null;
                        LkEdMlzTuruP2.EditValue = null;
                        listBoxControl.DataSource = null;
                        TxtUrunAgacKodu.Text = "";
                        TxtUrunAgacKoduP2.Text = "";
                        LkEdRevizyonNoP2.Properties.DataSource = null;
                        LblRevizyonText.Text = "";
                        LblRevizyonTextP2.Text = "";
                        LkEdRevizyonNoP2.Enabled = true;
                        LkEdUretimYeriKoduP2.Enabled = true;
                        LkEdUAKullanimKoduP2.Enabled = true;
                        LoadRevizyonLkEd(TxtStokKoduP2.Text);

                        FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                        xtraTabControl1.SelectedTabPage = xtraTabPage1;
                    }
                //}
            }
        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            treeList.ClearNodes();
            treeList.DataSource = null;
            LkEdMlzTuruP2.EditValue = null;
            listBoxControl.DataSource = null;
            TxtUrunAgacKodu.Text = "";
            TxtUrunAgacKoduP2.Text = "";
            LkEdRevizyonNoP2.Properties.DataSource = null;
            LblRevizyonTextP2.Text = "";
            LblRevizyonText.Text = "";
            LkEdRevizyonNoP2.Enabled = true;
            LkEdUretimYeriKoduP2.Enabled = true;
            LkEdUAKullanimKoduP2.Enabled = true;
            LoadRevizyonLkEd(TxtStokKoduP2.Text);

            xtraTabControl1.SelectedTabPage = xtraTabPage1;
        }

        protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                return;
            }

            // Open the Preview window.
            gridView12.ShowPrintPreview();
        }

        protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.OptionsView.ShowAutoFilterRow == false)
            {
                gridView1.OptionsView.ShowAutoFilterRow = true;
            }
            else
            {
                gridView1.OptionsView.ShowAutoFilterRow = false;
            }
        }

        private void LkEdMalzTuru_EditValueChanged(object sender, EventArgs e)
        {
            gridControl2.DataSource = null;
            gridView12.Columns.Clear();
            tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
            tur_kontrol(tur);
            TxtStokKodu.Text = TxtStokKoduP2.Text = "";
            LblStokAdi.Text = LblStokAdiP2.Text = "";
            string malzemeTuru = LkEdMalzTuru.EditValue.ToString();
            gridControl1.DataSource = null;
            //gridView1.Columns.Clear();
            gridControl1.DataSource = _stokKartService.Cch_GetListByMalTur_NLog(global, malzemeTuru, false).Items;
            gridView1.BestFitColumns();
        }
        private void tur_kontrol(STMALT _tur)
        {
            var vrkoduList = _stbdrnService.Cch_GetListByStokKodu_NLog(TxtStokKodu.Text, global, false).Items;
            LbRenkKdP2.Visible = LbRenkKd.Visible = tur.STRENK ?? false;
            LbBedenKdP2.Visible = LbBedenKd.Visible = tur.STBDEN ?? false;
            LbDropKdP2.Visible = LbDropKd.Visible = tur.STDROP ?? false;
            LkEdRenkKdP2.Visible = LkEdRenkKd.Visible = tur.STRENK ?? false;
            LkEdBedenKdP2.Visible = LkEdBedenKd.Visible = tur.STBDEN ?? false;
            LkEdDropKdP2.Visible = LkEdDropKd.Visible = tur.STDROP ?? false;
            LkEdRenkKdP2.EditValue = LkEdRenkKd.EditValue = null;
            LkEdBedenKdP2.EditValue = LkEdBedenKd.EditValue = null;
            LkEdDropKdP2.EditValue = LkEdDropKd.EditValue = null;
            LkEdVrKoduP2.EditValue = LkEdVrKodu.EditValue = null;
            if ((LbRenkKd.Visible) || (LbBedenKd.Visible) || (LbDropKd.Visible))
            {
                LkEdVrKoduP2.Properties.DataSource = LkEdVrKodu.Properties.DataSource = vrkoduList;
                LbVrKoduP2.Visible = LbVrKodu.Visible = true;
                LkEdVrKoduP2.Visible = LkEdVrKodu.Visible = true;
            }
            else
            {
                LbVrKoduP2.Visible = LbVrKodu.Visible = false;
                LkEdVrKoduP2.Visible = LkEdVrKodu.Visible = false;
            }
        }

        private void gridView1_Click(object sender, EventArgs e)
        {

            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle ||
                gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;
            gridControl2.DataSource = null;
            gridView12.Columns.Clear();
            if (gridView1.SelectedRowsCount > 0)
            {
                TxtStokKoduP2.Text = TxtStokKodu.Text = gridView1.GetFocusedRowCellValue("STKODU").ToString();
                LblStokAdiP2.Text = LblStokAdi.Text = gridView1.GetFocusedRowCellValue("STKNAM").ToString();
                tur_kontrol(tur);
              
            }
        }

        private void LkEdUretimYeriKodu_EditValueChanged(object sender, EventArgs e)
        {
            if (LkEdUretimYeriKodu.EditValue == null) return;
            LkEdUretimYeriKoduP2.Text = LkEdUretimYeriKodu.Text;
            LkEdUretimYeriKoduP2.EditValue = LkEdUretimYeriKodu.EditValue;
            LblUretimYeriText.Text = LblUretimYeriTextP2.Text = LkEdUretimYeriKodu.Properties.View.GetFocusedRowCellValue("TANIMI").ToString();
        }

        private void LkEdUAKullanimKodu_EditValueChanged(object sender, EventArgs e)
        {
            LoadRevizyonLkEd(TxtStokKodu.Text);
        }

        private void LkEdRevizyonNo_EditValueChanged(object sender, EventArgs e)
        {
            TxtUrunAgacKodu.Text = TxtUrunAgacKoduP2.Text = "";
            LkEdRevizyonNoP2.Text = LkEdRevizyonNo.Text;
            if ((bool)global.RenkBeden)
            {
                listRvList = _urunAgaciService.Ncch_GetUrunAgaciRevizyonList_Log(LkEdRevizyonNo.Text, TxtStokKodu.EditValue.ToString()
                                               , global,LkEdVrKoduP2.EditValue == null ? "" : LkEdVrKoduP2.EditValue.ToString()).Items;
            }
            else
            {
                listRvList = _urunAgaciService.Ncch_GetUrunAgaciRevizyonList_Log(LkEdRevizyonNo.Text, TxtStokKodu.EditValue.ToString(), global).Items;
            }
                
            foreach (var itemList in listRvList)
            {
                LblRevizyonText.Text = itemList.RevizyonText;
                TxtUrunAgacKodu.Text = itemList.UrunAgaciKodu;
            }
        }

        private void LkEdMlzTuruP2_EditValueChanged(object sender, EventArgs e)
        {
            list1.Clear();
            dt1.Clear();
            if (dataSet.Tables.Count > 1) dataSet.Tables.Remove("ListBox");

            string malzemeTuru = LkEdMlzTuruP2.EditValue == null ? "" : LkEdMlzTuruP2.EditValue.ToString();
            if (malzemeTuru != "")
            {
                list = _stokKartService.Cch_GetListByMalTur_NLog(global, malzemeTuru, false).Items;

                foreach (var item in list)
                {
                    list1.Add(new UrunAgaciTreeList
                    {
                        StokKodu = item.STKODU,
                        StokAdi = item.STKNAM,
                        OlcuBirimiKodu = item.OLCUKD,
                        KalemTipi = "L",
                        UretimYeriKodu = LkEdUretimYeriKoduP2.EditValue.ToString(),
                        //StokResim = item.StokResim,
                        MalzemeTuru = item.STMLTR
                    });
                }

                dt1 = ListToDataTable<UrunAgaciTreeList>(list1);
                dataSet.Tables.Add(dt1);
                dataSet.Tables[1].TableName = "ListBox";

                listBoxControl.DataSource = dataSet.Tables[1].DefaultView;
                treeList.DataSource = dataSet.Tables[0];
                treeList.ExpandAll();
                treeList.BestFitColumns();
            }
        }

        void OnDragDrop(object sender, DragDropEventArgs e)
        {

            treeList.AllowDrop = true;
            
                var view = sender as GridView;
            if (view != null) return; //Rota ekleme formunda yapılan drag drop'u ilginç bir şekilde burada da yakalıyor. Source gridview ise üst formdan geliyordur. return et.

            if (e.Source == e.Target)
            {
                if (e.Source == treeList)
                {
                    var destNode = GetDestNode(e.Location);
                    TreeList sTree = e.Source as TreeList;
                    string sMalzTuru = sTree.FocusedNode.GetValue("MalzemeTuru").ToString();
                    string tMalzTuru = destNode.GetDisplayText("MalzemeTuru");
                    if (sMalzTuru == "" || tMalzTuru == "")
                    {
                        e.Action = DragDropActions.None;
                        return;
                    }
                }
                OnTreeListDragDrop(e);
                return;
                // e.Action = DragDropActions.None;
            }

            e.Handled = true;
            if (e.Action == DragDropActions.None || e.InsertType == InsertType.None)
                return;
            if (e.Target == treeList)
            {
                OnTreeListDrop(e);
                e.Action = DragDropActions.None;
            }
            if (e.Target == listBoxControl)
            {
                //OnListBoxDrop(e);
                e.Action = DragDropActions.None;
            }
            Cursor.Current = Cursors.Default;
        }

        void OnListBoxDrop(DragDropEventArgs e)
        {
            DataView dataView = listBoxControl.DataSource as DataView;
            if (dataView == null)
                return;
            var nodes = e.GetData<IList<TreeListNode>>();
            if (nodes == null)
                return;
            int index = CalcDestItemIndex(e);
            treeList.BeginUpdate();
            listBoxControl.BeginUpdate();
            listBoxControl.UnSelectAll();
            List<int> selectIndices = new List<int>();
            DropNode(nodes, dataView, selectIndices, ref index, e.Action == DragDropActions.Copy);
            for (int i = 0; i < selectIndices.Count; i++)
                listBoxControl.SetSelected(selectIndices[i], true);
            listBoxControl.EndUpdate();
            treeList.EndUpdate();
        }

        void DropNode(IEnumerable<TreeListNode> nodes, DataView dataView, List<int> selectIndices, ref int index, bool isCopy)
        {
            List<TreeListNode> _nodes = new List<TreeListNode>(nodes);
            foreach (TreeListNode node in _nodes)
            {
                if (node.HasChildren)
                    DropNode(node.Nodes, dataView, selectIndices, ref index, isCopy);
                DataRowView rowView = treeList.GetRow(node.Id) as DataRowView;
                if (rowView == null)
                    return;
                var newRow = dataView.Table.NewRow();
                for (int i = 0; i < dataView.Table.Columns.Count; i++)
                {
                    var rowColumn = rowView.Row.Table.Columns[i];
                    var newRowColumn = newRow.Table.Columns[i];
                    newRow[newRowColumn] = rowView.Row[rowColumn];
                }
                dataView.Table.Rows.InsertAt(newRow, index);
                if (!isCopy)
                    treeList.Nodes.Remove(node);
                selectIndices.Add(index++);
            }
        }

        int CalcDestItemIndex(DragDropEventArgs e)
        {
            Point hitPoint = listBoxControl.PointToClient(e.Location);
            int index = listBoxControl.IndexFromPoint(hitPoint);
            if (e.InsertType == InsertType.After)
                index += 1;
            if (index == -1 && listBoxControl.ItemCount == 0)
                return 0;
            return index;
        }

        private void CreateGridSecButton(Form form)
        {
            FrmUARevizyonSec frmUARevSec = form as FrmUARevizyonSec;
            GridColumn column = frmUARevSec.gridView1.Columns.AddVisible("Sec", "Sec");
            column.ColumnEdit = frmUARevSec.repButSec;
            frmUARevSec.gridView1.Columns.Add(column);

        }
       

        private List<string[]> GetUARevizyonList()
        {
            List<string[]> revList = new List<string[]>();

            foreach (DataRowView item in listBoxControl.SelectedItems)
            {
                string stokKodu = item.Row["StokKodu"].ToString();
                string vryKodu = item.Row["VryKodu"].ToString();
                string stokAdi = item.Row["StokAdi"].ToString();
                string uaKodu = "";
                DataSet dSetUA = new DataSet("UADataSet");
                DataTable tblUARevizyonlar = ListToDataTable(_urunAgacStokBaglantiService.Ncch_GetByStokKoduUaKullanim_NLog(stokKodu, LkEdUAKullanimKodu.EditValue.ToString(), global,false,null).Items);
                if (tblUARevizyonlar.Rows.Count == 0)
                {
                    revList.Add(new string[] { TxtUrunAgacKoduP2.Text, "0" });
                    continue;
                }
               

                DataTable tblUrunAgaci = ListToDataTable(new List<UrunAgaciKalemMalzemeJoin>()).Clone();

                foreach (DataRow row in tblUARevizyonlar.Rows)
                {
                    if ((bool)global.RenkBeden)
                    {
                        row["RENKKD"] = _stbdrnService.Cch_GetListByStokKodu_NLog(row["StokKodu"].ToString(), global, false).Items
                            .Where(x => x.VRKODU == row["VRKODU"].ToString()).Select(x => x.RENKKD).FirstOrDefault();
                        row["BEDNKD"] = _stbdrnService.Cch_GetListByStokKodu_NLog(row["StokKodu"].ToString(), global, false).Items
                           .Where(x => x.VRKODU == row["VRKODU"].ToString()).Select(x => x.BEDNKD).FirstOrDefault();
                        row["DROPKD"] = _stbdrnService.Cch_GetListByStokKodu_NLog(row["StokKodu"].ToString(), global, false).Items
                           .Where(x => x.VRKODU == row["VRKODU"].ToString()).Select(x => x.DROPKD).FirstOrDefault();
                    }
                   
                    uaKodu = row["UrunAgaciKodu"].ToString();
                    tblUrunAgaci.Merge(ListToDataTable(_urunAgaciService.Ncch_GetUAKalemMalzemeJoin_NLog(uaKodu, global).Items));
                }

                dSetUA.Tables.AddRange(new DataTable[] { tblUARevizyonlar, tblUrunAgaci });

                DataColumn parent = dSetUA.Tables[0].Columns["UrunAgaciKodu"];
                DataColumn child = dSetUA.Tables[1].Columns["UrunAgaciKodu"];
                dSetUA.Relations.Add(parent, child);

                var frm = new FrmUARevizyonSec(revList);
                frm.defaultRevNo = TxtUrunAgacKoduP2.Text;
                frm.groupControl1.Text = stokKodu + " - " + stokAdi;
                frm.gridControl1.DataSource = dSetUA.Tables[0];
                frm.gridView1.Columns["StokKodu"].Visible = false;
                if (!(bool)global.RenkBeden)
                {
                    frm.gridView1.Columns["VRKODU"].Visible = false;
                    frm.gridView1.Columns["RENKKD"].Visible = false;
                    frm.gridView1.Columns["BEDNKD"].Visible = false;
                    frm.gridView1.Columns["DROPKD"].Visible = false;
                }
                    frm.gridView1.Columns["RevizyonNo"].AppearanceCell.FontStyleDelta = FontStyle.Bold;
                GridHelper.ColumnRepositoryItems(frm.gridView1, global);
                foreach (GridColumn col in frm.gridView1.Columns) if (col.FieldName != "Sec") col.OptionsColumn.AllowEdit = false;
                CreateGridSecButton(frm);
                frm.gridView1.BestFitColumns();
                frm.ShowDialog();
               
            }
            return revList;
        }

        void OnTreeListDrop(DragDropEventArgs e)
        {
            if (LkEdUretimYeriKoduP2.Text == "" || LkEdUAKullanimKoduP2.Text == "" ||
            LkEdRevizyonNoP2.Text == "")
            {
                MessageBox.Show("Üretim Yeri, Kullanım ve Revizyon No alanları boş bırakılamaz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataView dataView = listBoxControl.DataSource as DataView;
            if (e.Source != e.Target)
            {
                if (dataView == null)
                    return;
            }
            var items = e.GetData<IEnumerable<object>>();
            if (items == null)
                return;

            var destNode = GetDestNode(e.Location);
            int index = CalcDestNodeIndex(e, destNode);

            if (destNode != null && destNode.GetDisplayText("MalzemeTuru") == "") return;

            List<string[]> revList = GetUARevizyonList();
            if (revList.Count == 0) return;

            int revIndex = 0;
            // listBoxControl.BeginUpdate();

            List<object> _items = new List<object>(items);
            foreach (object item in _items)
            {
                treeList.BeginUpdate();
                treeList.Selection.UnselectAll();
                DataRowView rowView = item as DataRowView;
                if (index < 0) rowView.Row[4] = destNode == null ? 0 : destNode.Level + 1;
                else rowView.Row[4] = destNode == null ? 0 : destNode.Level;

                //rowView.Row["ParentStokKodu"] = destNode.GetValue("StokKodu");
                string altUrunAgaciKodu = (revList[revIndex])[0];
                byte fntm = Convert.ToByte((revList[revIndex])[1]);
                string vrkodu = null;
                if (revList[0].Length > 2)
                {
                    vrkodu = (revList[revIndex])[2] as string;
                }
                else
                {
                    vrkodu = null;
                }
               
                bool fantom = fntm == 1;
                revIndex++;

                rowView.Row["AltUrunAgaciKodu"] = altUrunAgaciKodu;
                rowView.Row["FantomKalemi"] = fantom;
                rowView.Row["VryKodu"] = vrkodu;

                //SetMiktar(rowView);

                TreeListNode node = treeList.AppendNode(rowView.Row.ItemArray, index == -1000 ? destNode : null);
                TreeListNode pNode = node;

                //if (!fantom)
                //{
                //    DataTable dt3 = ListToDataTable(_urunAgaciService.GetUrunAgaci(altUrunAgaciKodu));

                //    if (dt3.Rows.Count > 0)
                //    {
                //        maxAltId = 0;
                //        //DataTable dt4 = dt3.Clone();
                //        DataTable dtSubLevels = dt3.Clone();
                //        maxAltId = Convert.ToInt32(dt3.Select("AltId = MAX(AltId)")[0]["AltId"]);

                //        foreach (DataRow row in dt3.Rows)
                //        {
                //            string stokKodu = row["StokKodu"].ToString();
                //            string revizyonNo = row["RevizyonNo"].ToString();
                //            string uaKodu = _urunAgacStokBaglantiService.GetUrunAgaciKodu(stokKodu, revizyonNo, LkEdUAKullanimKoduP2.EditValue.ToString());
                //            if (uaKodu == "")
                //            {
                //                //dt4.Rows.Add(row.ItemArray);
                //                continue;
                //            }

                //            row["MalzemeTuru"] = "";
                //            int parentId = Convert.ToInt32(row["AltId"]);
                //            int seviye = node.Level + 1;

                //            //dt4.Rows.Add(row.ItemArray);
                //            //parentId = Convert.ToInt32(dt4.Rows[dt4.Rows.Count - 1]["AltId"]);

                //            GetUrunAgaciSubLevel(dtSubLevels, stokKodu, revizyonNo, parentId, seviye + 1);
                //            if (dtSubLevels.Rows.Count > 0) maxAltId = Convert.ToInt32(dtSubLevels.Select("AltId = MAX(AltId)")[0]["AltId"]);
                //            //dt4.Merge(dtSubLevels);
                //        }
                //        dt3.Merge(dtSubLevels);
                //        foreach (DataRow row in dt3.Rows)
                //        {
                //            TreeListNode altNode = treeList.AppendNode(row.ItemArray, pNode);
                //        }
                //    }
                //}

                if (index > -1)
                {
                    treeList.MoveNode(node, destNode.ParentNode, true, index++);
                }
                if (e.Action != DragDropActions.Copy)
                    //dataView.Table.Rows.Remove(rowView.Row);
                    treeList.SelectNode(node);
                if (node.ParentNode != null)
                    node.ParentNode.Expand();

                variantList.Add(node.Id, new List<URAGVR>());

                treeList.EndUpdate();

            }
            //listBoxControl.EndUpdate();
        }

        private void SetMiktar(DataRowView rowView)
        {
            // SAVVARİN
            string stokKodu = rowView.Row["StokKodu"].ToString();
            string malzemeOlcuBirimi = rowView.Row["OlcuBirimiKodu"].ToString();
            if (stokKodu.StartsWith("25.009") && malzemeOlcuBirimi == "M2") //Plaka ise
            {
                STKART stkart = _stokKartService.Ncch_GetByStKod_NLog(TxtStokKodu.Text, global, false).Nesne;

                decimal genislik = stkart.GENSLK ?? 0;
                decimal uzunluk = stkart.UZUNLK ?? 0;
                decimal yuzeyAlani = genislik * uzunluk;
                decimal fireCarpan = 1.07M;
                decimal bolen = 1000000; //MM için

                if (stkart.UGYBKD == "CM") bolen = 10000;
                else if (stkart.UGYBKD == "MT") bolen = 1;

                rowView.Row["Miktar"] = yuzeyAlani / bolen * fireCarpan;
            }
        }

        void OnTreeListDragDrop(DragDropEventArgs e)
        {
            int _deger = 0;
            var destNode = GetDestNode(e.Location);
            int index = CalcDestNodeIndex(e, destNode);
            if (e.Action == DragDropActions.None || e.InsertType == InsertType.None)
                return;
            if (index < 0) { _deger = destNode == null ? 0 : destNode.Level + 1; }
            else
            {
                _deger = destNode == null ? 0 : destNode.Level;
                //if (treeList.FocusedNode.Level == destNode.Level) return;
            }

            if (treeList.FocusedNode.Level == _deger) return;
            treeList.FocusedNode.SetValue("Seviye", _deger);
            _deger++;
            foreach (TreeListNode _node in treeList.FocusedNode.Nodes)
            {
                _node.SetValue("Seviye", _deger);
                SetNodeLevels(_node, _deger);
            }
        }

        private void SetNodeLevels(TreeListNode _nodelist, int deg)
        {
            //string parentN = _nodelist.ParentNode.GetDisplayText("StokKodu");
            //int rootLevel = _nodelist.ParentNode.RootNode.Level;
            //int parentLevel = _nodelist.ParentNode.Level;
            //int deg1 = parentLevel;
            //if (parentLevel > rootLevel) deg1 = deg1 - parentLevel;

            int deg1 = deg;
            foreach (TreeListNode _node in _nodelist.Nodes)
            {
                string ff = _node.GetDisplayText("StokKodu");
                _nodelist.SetValue("Seviye", deg1);
                if (_nodelist.HasChildren)
                {
                    deg1 = deg1 + 1;
                    for (int i = 0; i < _nodelist.Nodes.Count; i++)
                    //foreach (TreeListNode _subnode in _nodelist.Nodes)
                    {
                        TreeListNode _subnode = _nodelist.Nodes[i];
                        string fff = _subnode.GetDisplayText("StokKodu");
                        _subnode.SetValue("Seviye", deg1);
                        SetNodeLevels(_subnode, deg);
                        if (i == _nodelist.Nodes.Count - 1) break;
                    }
                }

                SetNodeLevels(_node, deg1);
            }
        }

        TreeListNode GetDestNode(Point hitPoint)
        {
            Point pt = treeList.PointToClient(hitPoint);
            DevExpress.XtraTreeList.TreeListHitInfo ht = treeList.CalcHitInfo(pt);
            TreeListNode destNode = ht.Node;
            if (destNode is TreeListAutoFilterNode)
                return null;
            return destNode;
        }

        int CalcDestNodeIndex(DragDropEventArgs e, TreeListNode destNode)
        {
            if (destNode == null)
                return -1;
            if (e.InsertType == InsertType.AsChild)
                return -1000;
            var nodes = destNode.ParentNode == null ? treeList.Nodes : destNode.ParentNode.Nodes;
            int index = nodes.IndexOf(destNode);
            if (e.InsertType == InsertType.After)
                return ++index;
            return index;
        }

        void OnDragOver(object sender, DragOverEventArgs e)
        {
            treeList.AllowDrop = false;
            if (e.Source == e.Target) return;

            e.Default();
            if (e.InsertType == InsertType.None)
                return;
            e.Action = IsCopy(e.KeyState) ? DragDropActions.Copy : DragDropActions.Move;
            Cursor current = Cursors.No;
            if (e.Action != DragDropActions.None)
                current = Cursors.Default;
            Cursor.Current = current;
        }

        bool IsCopy(DragDropKeyState key)
        {
            return (key & DragDropKeyState.Control) != 0;
        }

        void InitProjectsData()
        {
            dt2 = ListToDataTable<UrunAgaciTreeList>(list2);

            dataSet.Tables.Add(dt2);
            dataSet.Tables[0].TableName = "TreeList";
        }

        public static DataTable ListToDataTable<T>(List<T> list)
        {
            if (list == null) return null;
            DataTable dt = new DataTable();

            foreach (PropertyInfo info in typeof(T).GetProperties())
            {
                dt.Columns.Add(new DataColumn(info.Name, info.PropertyType));
            }
            foreach (T t in list)
            {
                DataRow row = dt.NewRow();
                foreach (PropertyInfo info in typeof(T).GetProperties())
                {
                    row[info.Name] = info.GetValue(t, null);
                }
                dt.Rows.Add(row);
            }
            return dt;
        }

        private void LoadRevizyonLkEd(string stokKodu)
        {
            LkEdUAKullanimKoduP2.Text = LkEdUAKullanimKodu.Text;
            LkEdUAKullanimKoduP2.EditValue = LkEdUAKullanimKodu.EditValue;
            if (LkEdUAKullanimKodu.EditValue.ToString() != "") LblUAKullanimText.Text = LblUAKullanimTextP2.Text = LkEdUAKullanimKodu.Properties.View.GetFocusedRowCellValue("TANIMI").ToString();
            string _Vrkodu = null;
            if (LkEdVrKoduP2.EditValue != null) _Vrkodu = LkEdVrKoduP2.EditValue.ToString();
            if ((LbRenkKd.Visible) || (LbBedenKd.Visible) || (LbDropKd.Visible))
            {
                var urunAgaci = _urunAgaciService.Ncch_GetMaxRevizyonNo_NLog(stokKodu, LkEdUAKullanimKodu.EditValue.ToString(), global, _Vrkodu).Items;
                LkEdRevizyonNo.Properties.DataSource = urunAgaci;
            }
            else
            {
                var urunAgaci = _urunAgaciService.Ncch_GetMaxRevizyonNo_NLog(stokKodu, LkEdUAKullanimKodu.EditValue.ToString(), global).Items;
                LkEdRevizyonNo.Properties.DataSource = urunAgaci;
            }


            LkEdRevizyonNo.EditValue = null;
        }

        private bool RefreshTreeList()
        {
            if (dataSet.Tables.Contains("ListBox")) dataSet.Tables.Remove("ListBox");
            if (dataSet.Tables.Contains("TreeList")) dataSet.Tables.Remove("TreeList");
            maxAltId = 0;

            if (dt2 != null) dt2.Clear();
            if (_action == "insert") dt2 = ListToDataTable<UrunAgaciTreeList>(list2);
            if (_action == "update")
            {
                dt2 = ListToDataTable(_urunAgaciService.Ncch_GetUrunAgaci_NLog(TxtUrunAgacKoduP2.Text, global).Items);
                if (dt2 == null)
                {
                    MessageBox.Show("Ürün ağacı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
                DataTable dtSubLevels = dt2.Clone();
                maxAltId = Convert.ToInt32(dt2.Select("AltId = MAX(AltId)")[0]["AltId"]);

                foreach (DataRow row in dt2.Rows)
                {
                    string stokKodu = row["StokKodu"].ToString();
                    string revizyonNo = row["RevizyonNo"].ToString();
                    string vrkodu = row["VryKodu"] == null || row["VryKodu"].ToString() == "" ? null : row["VryKodu"].ToString();
                    int parentId = Convert.ToInt32(row["AltId"]);
                    int seviye = Convert.ToInt32(row["Seviye"]);
                    bool fantom = Convert.ToBoolean(row["FantomKalemi"]);

                    if (!fantom) GetUrunAgaciSubLevel(dtSubLevels, stokKodu, revizyonNo, parentId, seviye + 1,vrkodu);
                    if (dtSubLevels.Rows.Count > 0) maxAltId = Convert.ToInt32(dtSubLevels.Select("AltId = MAX(AltId)")[0]["AltId"]);
                }
                dt2.Merge(dtSubLevels);
            }
            dataSet.Tables.Add(dt2);
            dataSet.Tables[0].TableName = "TreeList";
            return true;
        }

        private void GetUrunAgaciSubLevel(DataTable dtSubLevels, string stokKodu, string revizyonNo, int parentId, int seviye,string vrkodu=null)
        {
            string uaKodu = _urunAgacStokBaglantiService.Ncch_GetUrunAgaciKodu_NLog(stokKodu, revizyonNo, LkEdUAKullanimKodu.EditValue.ToString()
                , global,vrkodu).Nesne;
            if (uaKodu == null) return;

            DataTable dt = ListToDataTable(_urunAgaciService.Ncch_GetUrunAgaci_NLog(uaKodu, global).Items);
            //int _kayitsayisi = dt.Rows.Count;
            //if (_kayitsayisi > 1)
            //{
            foreach (DataRow row in dt.Rows)
            {
                maxAltId++;
                row["ParentId"] = parentId;
                row["AltId"] = maxAltId;
                row["Seviye"] = seviye;
                row["MalzemeTuru"] = "";
                stokKodu = row["StokKodu"].ToString();
                revizyonNo = row["RevizyonNo"].ToString();
                dtSubLevels.Rows.Add(row.ItemArray);
                vrkodu = row["VryKodu"] == null ? null : row["VryKodu"].ToString();
                GetUrunAgaciSubLevel(dtSubLevels, stokKodu, revizyonNo, maxAltId, seviye + 1,vrkodu);
            }
            //}
        }

        private void ClearControls()
        {
            LkEdRevizyonNo.Properties.DataSource = null;
            LkEdRevizyonNoP2.Properties.DataSource = null;
            TxtUrunAgacKodu.Text = "";
            TxtUrunAgacKoduP2.Text = "";
            LblRevizyonText.Text = "";
            LblRevizyonTextP2.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearControls();
            LoadRevizyonLkEd(gridView1.GetFocusedRowCellDisplayText("STKODU"));
        }

        private void LkEdRevizyonNoP2_EditValueChanged(object sender, EventArgs e)
        {
            List<UrunAgaciRevizyonList> uARevList = new List<UrunAgaciRevizyonList>();
            if (LkEdRevizyonNoP2.EditValue == null) return;
            string _Vrkodu = null;
            if (LkEdVrKoduP2.EditValue != null) _Vrkodu = LkEdVrKoduP2.EditValue.ToString();
            
            if ((bool)global.RenkBeden )
            {
                uARevList = _urunAgaciService.Ncch_GetUrunAgaciRevizyonList_Log(LkEdRevizyonNoP2.Text, TxtStokKoduP2.Text, global,_Vrkodu).Items;
            }
            else
            {
                uARevList = _urunAgaciService.Ncch_GetUrunAgaciRevizyonList_Log(LkEdRevizyonNoP2.Text, TxtStokKoduP2.Text, global).Items;
            }
                
            if (uARevList.Count > 0)
            {
                MessageBox.Show(LkEdRevizyonNoP2.Text + " numaralı revizyon bu stok kodu için daha önce tanımlanmış. " +
                                "Devam etmek için farklı bir revizyon numarası seçin.", "Uyarı",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
                LkEdRevizyonNoP2.EditValue = null;
                return;
            }
        }

        private void searchControl1_QueryIsSearchColumn(object sender, DevExpress.XtraEditors.QueryIsSearchColumnEventArgs args)
        {
            MessageBox.Show(sender.ToString());
            if (sender.ToString() != "Ship Country") args.IsSearchColumn = false;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0) listBoxControl.DisplayMember = "StokKodu";
            else listBoxControl.DisplayMember = "StokAdi";
        }

        private void treeList_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e)
        {
            EventHandler customItemClick = null;
            DXMenuItem customItem = new DXMenuItem("Excel Şablonu Oluştur"); customItemClick = (sender1, ea) =>
            {
                customItem.Click -= customItemClick;

                //FormIslemleri.CreateExcelTemplate("", new [] {"UrunAgaci", "UrunAgacStokBaglanti"});
            };

            customItem.Click += customItemClick;
            e.Menu.Items.Add(customItem);
        }

        private void treeList_CustomDrawRow(object sender, CustomDrawRowEventArgs e)
        {
            e.DefaultDraw();
            if (e.RowInfo.Node.Focused)
            {
                Pen pen = new Pen(Color.Gainsboro, 1);
                e.Cache.DrawRectangle(pen, e.Bounds);
            }
            e.Handled = true;
        }

        private void treeList_ShowingEditor(object sender, CancelEventArgs e)
        {
           //if (treeList.FocusedNode.GetDisplayText("MalzemeTuru") == "") e.Cancel = true;
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            if (LkEdMalzTuru.EditValue == null) return;
            string malzTuru = LkEdMalzTuru.EditValue.ToString();

            if (malzTuru == "100") btnTakimUA.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            else btnTakimUA.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            if (malzTuru == "100" || malzTuru == "101") btnMalzUA.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            else btnMalzUA.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            popupMenu1.ShowPopup(MousePosition);
        }

        private void GetUAAllSubLevels(DataTable table, string uaKodu, string uaKoduField, string uaKullanim, bool onlyParts = true)
        {
            DataTable tbl = _urunAgaciService.GetAltUrunAgaci(StaticParams.DefaultConnstr, uaKodu, uaKoduField, uaKullanim, global, onlyParts);
            table.Merge(tbl);

            foreach (DataRow row in tbl.Rows)
            {
                string malzemeTuru = row["MalzemeTuru"].ToString();
                string altUAKodu = row["AltUrunAgaciKodu"].ToString();
                if (malzemeTuru != "100" && malzemeTuru != "101") uaKullanim = "2";
                if (uaKullanim == "2") onlyParts = false;
                else onlyParts = true;
                if (altUAKodu != uaKodu) GetUAAllSubLevels(table, row["AltUrunAgaciKodu"].ToString(), uaKoduField, uaKullanim, onlyParts);
            }

        }

        private string CheckDecimalPlaces(decimal val)
        {
            if (val.ToString() != "")
            {
                if (val == -1) return "";
                if (val % 1 == 0) return Convert.ToInt32(val).ToString();
                else return val.ToString("f2");
            }
            else return "";
        }

        private void GetModulTakim(string stokKodu, string revizyonNo, string ustMalzemeTuru)
        {
            DataTable tbl = _urunAgaciService.GetUrunAgaciUpperLevels(StaticParams.DefaultConnstr, stokKodu, revizyonNo, ustMalzemeTuru, global);
            stokKodu = tbl.Rows[0]["StokKodu"].ToString();
            revizyonNo = tbl.Rows[0]["RevizyonNo"].ToString();
            ustMalzemeTuru = tbl.Rows[0]["UstMalzemeTuru"].ToString();

            if (ustMalzemeTuru == "101")
            {
                STKART stok = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
                takimAdi = stok.STKNAM;
                takimKodu = stok.STKODU;
                GetModulTakim(stokKodu, revizyonNo, ustMalzemeTuru);
            }
            else if (ustMalzemeTuru == "100")
            {
                STKART stok = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
                takimAdi = stok.STKNAM;
                takimKodu = stok.STKODU;
            }
            else GetModulTakim(stokKodu, revizyonNo, ustMalzemeTuru);
        }

        private void GetPaketParca(string stokKodu, string revizyonNo, string malzemeTuru)
        {
            DataTable tbl = _urunAgaciService.GetUrunAgaciUpperLevels(StaticParams.DefaultConnstr, stokKodu, revizyonNo, malzemeTuru, global);
            stokKodu = tbl.Rows[0]["StokKodu"].ToString();
            revizyonNo = tbl.Rows[0]["RevizyonNo"].ToString();
            malzemeTuru = tbl.Rows[0]["MalzemeTuru"].ToString();

            if (malzemeTuru == "102")
            {
                stokPaket = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;
                GetPaketParca(stokKodu, revizyonNo, malzemeTuru);
            }
            else if (malzemeTuru == "103")
            {
                STKART stok = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
                stokParca = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
            }
            else GetPaketParca(stokKodu, revizyonNo, malzemeTuru);
        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            Point point = gridView1.GridControl.PointToClient(MousePosition);
            RowDoubleClick(gridView1, point);
        }

        private void RowDoubleClick(DevExpress.XtraGrid.Views.Grid.GridView gridView, Point point)
        {
            GridHitInfo info = gridView.CalcHitInfo(point);
            if (info.InRow || info.InRowCell)
            {
                Clipboard.SetText(gridView.GetFocusedRowCellDisplayText("STKNAM"));
            }
        }

        private void treeList_CustomRowFilter(object sender, CustomRowFilterEventArgs e)
        {
            TreeList treeList = sender as TreeList;
            try
            {
                bool silme = Convert.ToBoolean(treeList.GetRowCellValue(e.Node, treeList.Columns["Silme"]));
                if (silme == true)
                {
                    e.Visible = false;
                    e.Handled = true;
                }
            }

            catch { }
        }

        private void GetUAAllSubLevelsForReport(DataTable table, string uaKodu, string uaKoduField, string uaKullanim, bool onlyParts = true, bool paketParca = false)
        {
            DataTable tbl = _urunAgaciService.GetAltUrunAgaci(StaticParams.DefaultConnstr, uaKodu, uaKoduField, uaKullanim, global, onlyParts, "vwUARapor");
            int startIndex = table.Rows.Count;

            table.Merge(tbl);
            if (table.Columns.Count == 12)
            {
                table.Columns.Add("ToplamMiktar", typeof(decimal));
                table.Columns.Add("TakimKodu", typeof(string));
                table.Columns.Add("TakimAdi", typeof(string));
                table.Columns.Add("ModulKodu", typeof(string));
                table.Columns.Add("ModulAdi", typeof(string));
                table.Columns.Add("PaketKodu", typeof(string));
                table.Columns.Add("PaketAdi", typeof(string));
                table.Columns.Add("ParcaKodu", typeof(string));
                table.Columns.Add("ParcaAdi", typeof(string));
            }

            int count = -1;
            foreach (DataRow row in tbl.Rows)
            {
                count++;

                string stkKodu = row["AltStokKodu"].ToString();
                string malzemeTuru = row["MalzemeTuru"].ToString();
                string altUAKodu = row["AltUrunAgaciKodu"].ToString();
                string ustMalzemeTuru = row["UstMalzemeTuru"].ToString();
                decimal birimMiktar = Convert.ToDecimal(row["BirimMiktar"]);

                if (paketParca)
                {
                    if (ustMalzemeTuru == "102" && stokPaket == null)
                    {
                        stokPaket = _stokKartService.Ncch_GetByStKod_NLog(stkKodu, global, false).Nesne;
                    }
                    //string ustStkKodu = row["StokKodu"].ToString();
                    //GetPaketParca(ustStkKodu, row["RevizyonNo"].ToString(), ustMalzemeTuru);
                }

                if (malzemeTuru == "103" && (stokParca == null || stkKodu != stokParca.STKODU))
                {
                    stokParca = _stokKartService.Ncch_GetByStKod_NLog(stkKodu, global, false).Nesne;
                }

                table.Rows[startIndex + count]["ToplamMiktar"] = birimMiktar * uretimAdet;
                table.Rows[startIndex + count]["TakimKodu"] = stokTakim != null ? stokTakim.STKODU : "";
                table.Rows[startIndex + count]["TakimAdi"] = stokTakim != null ? stokTakim.STKNAM : "";
                table.Rows[startIndex + count]["ModulKodu"] = stokModul != null ? stokModul.STKODU : "";
                table.Rows[startIndex + count]["ModulAdi"] = stokModul != null ? stokModul.STKNAM : "";
                table.Rows[startIndex + count]["PaketKodu"] = stokPaket != null ? stokPaket.STKODU : "";
                table.Rows[startIndex + count]["PaketAdi"] = stokPaket != null ? stokPaket.STKNAM : "";
                if (ustMalzemeTuru == "103")
                {
                    table.Rows[startIndex + count]["ParcaKodu"] = stokParca != null ? stokParca.STKODU : "";
                    table.Rows[startIndex + count]["ParcaAdi"] = stokParca != null ? stokParca.STKNAM : "";
                }

                if (malzemeTuru != "100" && malzemeTuru != "101") uaKullanim = "2";
                if (uaKullanim == "2") onlyParts = false;
                else onlyParts = true;
                if (altUAKodu != uaKodu) GetUAAllSubLevelsForReport(table, row["AltUrunAgaciKodu"].ToString(), uaKoduField, uaKullanim, onlyParts);
            }

        }

        private void GetUARapor(string reportType, int uretimAdet)
        {
            try
            {
                stokTakim = null;
                stokModul = null;
                stokPaket = null;
                stokParca = null;
                barEditItem1.EditValue = null;

                string stokKodu = gridView1.GetFocusedRowCellDisplayText("StokKodu");
                string stokAdi = gridView1.GetFocusedRowCellDisplayText("StokAdı");
                string malzTuru = LkEdMalzTuru.EditValue.ToString();

                string uaKullanim = "1";
                if (malzTuru != "100" && malzTuru != "101") uaKullanim = "2";
                string revizyonNo = "";
                if ((LbRenkKd.Visible) || (LbBedenKd.Visible) || (LbDropKd.Visible))
                {
                    revizyonNo = _urunAgaciService.Ncch_GetMaxRevizyonNo_NLog(stokKodu, uaKullanim, global, LkEdVrKoduP2.EditValue.ToString()).Items[0].RevizyonNo;
                }
                else
                {
                    revizyonNo = _urunAgaciService.Ncch_GetMaxRevizyonNo_NLog(stokKodu, uaKullanim, global).Items[0].RevizyonNo;
                }


                string uaKodu = _urunAgacStokBaglantiService.Ncch_GetUrunAgaciKodu_NLog(stokKodu, revizyonNo, uaKullanim, global).Nesne;
                DataTable table = new DataTable();
                DataTable table2 = new DataTable();

                if (uaKullanim == "1")
                {
                    GetUAAllSubLevelsForReport(table, uaKodu, "UrunAgaciKodu", uaKullanim);
                    table2 = table.Clone();

                    foreach (DataRow row in table.Rows)
                    {
                        string malzemeTuru = row["MalzemeTuru"].ToString();
                        string ustMalzemeTuru = row["UstMalzemeTuru"].ToString();
                        string stkKodu = row["StokKodu"].ToString();

                        if (stokTakim == null)
                        {
                            if (ustMalzemeTuru == "100") stokTakim = _stokKartService.Ncch_GetByStKod_NLog(stkKodu, global, false).Nesne;
                            else
                            {
                                GetModulTakim(stokKodu, revizyonNo, ustMalzemeTuru);
                                stokTakim = _stokKartService.Ncch_GetByStKod_NLog(takimKodu, global, false).Nesne;
                            }
                        }

                        if (ustMalzemeTuru == "101" && (stokModul == null || stkKodu != stokModul.STKODU))
                        {
                            stokModul = _stokKartService.Ncch_GetByStKod_NLog(stkKodu, global, false).Nesne;
                        }

                        string maxUAKodu = _urunAgaciService.GetMaxUrunAgaciKodu(row["AltStokKodu"].ToString(), "2", global).Nesne;
                        if (maxUAKodu == "HATA") return;
                        if (maxUAKodu != "")
                        {
                            stkKodu = row["AltStokKodu"].ToString();
                            if (malzemeTuru == "102" && (stokPaket == null || stkKodu != stokPaket.STKODU))
                            {
                                stokPaket = _stokKartService.Ncch_GetByStKod_NLog(stkKodu, global, false).Nesne;
                            }
                            GetUAAllSubLevelsForReport(table2, maxUAKodu, "UrunAgaciKodu", "2", false);
                        }
                    }
                }
                else if (uaKullanim == "2")
                {
                    table2 = _urunAgaciService.GetAltUrunAgaci(StaticParams.DefaultConnstr, uaKodu, "AltUrunAgaciKodu", uaKullanim, global, false, "vwUARapor");
                    GetUAAllSubLevelsForReport(table2, uaKodu, "UrunAgaciKodu", "2", false, true);
                }

                table2.Columns.Remove("Id");
                table2.Columns.Remove("StokKodu");
                table2.Columns.Remove("UstMalzemeTuru");
                table2.Columns.Remove("UAKullanimKodu");
                table2.Columns.Remove("UrunAgaciKodu");
                table2.Columns.Remove("AltUrunAgaciKodu");
                table2.Columns.Remove("RevizyonNo");
                table2.Columns["AltStokKodu"].ColumnName = "StokKodu";
                table2.Columns["OlcuBirimiKodu"].ColumnName = "Birim";

                gridControl2.DataSource = null;
                gridView12.Columns.Clear();

                if (reportType == "malzeme")
                {
                    string grupKodu = "TakimKodu";
                    string grupAdi = "TakimAdi";

                    DataView dv = new DataView(table2);
                    dv.RowFilter = "NOT MalzemeTuru = '100' AND NOT MalzemeTuru = '101' AND NOT MalzemeTuru = '102' AND NOT MalzemeTuru = '103'";
                    DataTable tbl = dv.ToTable();
                    tbl.Columns.Remove("MalzemeTuru");
                    if (LkEdMalzTuru.EditValue.ToString() != "101")
                    {
                        tbl.Columns.Remove("ModulKodu");
                        tbl.Columns.Remove("ModulAdi");
                    }
                    else
                    {
                        tbl.Columns.Remove("TakimKodu");
                        tbl.Columns.Remove("TakimAdi");
                        grupKodu = "ModulKodu";
                        grupAdi = "ModulAdi";
                    }
                    tbl.Columns.Remove("PaketKodu");
                    tbl.Columns.Remove("PaketAdi");
                    tbl.Columns.Remove("ParcaKodu");
                    tbl.Columns.Remove("ParcaAdi");

                    //DataTable newTable = tbl.AsEnumerable()
                    //.GroupBy(r => new { Col1 = r["StokKodu"], Col2 = r["StokAdi"], Col3 = r["Birim"], Col4 = r[grupKodu], Col5 = r[grupAdi] })
                    //.Select(g =>
                    //{
                    //    var row = tbl.NewRow();

                    //    row["StokKodu"] = g.Key.Col1;
                    //    row["StokAdi"] = g.Key.Col2;
                    //    row["BirimMiktar"] = g.Sum(r => r.Field<decimal>("BirimMiktar"));
                    //    row["ToplamMiktar"] = g.Sum(r => r.Field<decimal>("ToplamMiktar"));
                    //    row["Birim"] = g.Key.Col3;
                    //    row[grupKodu] = g.Key.Col4;
                    //    row[grupAdi] = g.Key.Col5;

                    //    return row;

                    //})
                    //.CopyToDataTable();

                    //gridControl2.DataSource = newTable;
                }
                else if (reportType == "takim")
                {
                    table2.Columns.Remove("ToplamMiktar");
                    DataView dv = new DataView(table2);
                    dv.RowFilter = "MalzemeTuru = '100' OR MalzemeTuru = '101' OR MalzemeTuru = '102' OR MalzemeTuru = '103'";
                    DataTable tbl = dv.ToTable();
                    tbl.Columns.Remove("MalzemeTuru");
                    tbl.Columns.Remove("ParcaKodu");
                    tbl.Columns.Remove("ParcaAdi");
                    gridControl2.DataSource = tbl;
                }

                gridView12.BestFitColumns();
                uretimAdet = 1;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnMalzUA_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            uretimAdet = 1;
            try
            {
                uretimAdet = Convert.ToInt32(barEditItem1.EditValue);
            }
            catch
            {
                uretimAdet = 1;
                MessageBox.Show("Geçerli bir adet girin.");
                return;
            }
            if (uretimAdet == 0) uretimAdet = 1;

            BarButtonItem btn = (BarButtonItem)e.Item;
            string reportType = "malzeme";
            if (btn == btnTakimUA) reportType = "takim";
            GetUARapor(reportType, uretimAdet);
        }

        private void btnSolidworks_Click(object sender, EventArgs e)
        {
            FrmBomex frmBom = new FrmBomex();
            frmBom.ShowDialog();
        }

        private void searchControl1_QuerySearchParameters(object sender, SearchControlQueryParamsEventArgs e)
        {

        }

        private void buttonMaliyet_Click(object sender, EventArgs e)
        {
            List<DOVKUR> dovizList = new List<DOVKUR>();
            DataTable urunAgaciTable = UAMaliyetHesapla(KurHesapEnum.DovizSatis, out dovizList);

            if (urunAgaciTable == null) return;

            FrmUaMaliyet uForm = new FrmUaMaliyet(this);
            uForm.cmbAlisSatis.Text = "SATIŞ";
            uForm.global = global;
            uForm.dovizList = dovizList;
            uForm.repLkedStokAdi.DataSource = stokList;
            uForm.Text = TxtStokKodu.Text + " - " + LblStokAdi.Text;
            uForm.gridControl1.DataSource = urunAgaciTable;

            GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tutar", "{0:n2}");
            GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TutarTL", "{0:n2}");
            uForm.gridView1.Columns["Tutar"].Summary.Add(item1);
            uForm.gridView1.Columns["TutarTL"].Summary.Add(item2);

            uForm.gridView1.BestFitColumns();

            uForm.Show();
        }

        public DataTable UAMaliyetHesapla(KurHesapEnum kurHesaplamaYontemi, out List<DOVKUR> dovizList)
        {
            dovizList = GetDailyCurrency(new List<string> { "USD", "EUR" });

            if (TxtUrunAgacKodu.Text == "") return null;

            maxAltId = 0;

            if (dt2 != null) dt2.Clear();

            DataTable urunAgaciTable = dt2.Clone();
            urunAgaciTable = ListToDataTable(_urunAgaciService.Ncch_GetUrunAgaci_NLog(TxtUrunAgacKodu.Text, global).Items);

            urunAgaciTable.Columns.Add("PartiBirimFiyat", typeof(decimal));
            urunAgaciTable.Columns.Add("BirimFiyat", typeof(decimal));
            urunAgaciTable.Columns.Add("Tutar", typeof(decimal));
            urunAgaciTable.Columns.Add("TutarTL", typeof(decimal));
            urunAgaciTable.Columns.Add("DovizCinsi", typeof(string));
            urunAgaciTable.Columns.Add("SaOlcuBirimi", typeof(string));

            if (urunAgaciTable == null || urunAgaciTable.Rows.Count == 0)
            {
                MessageBox.Show("Ürün ağacı bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return null;
            }

            decimal usdKur = 0;
            decimal eurKur = 0;

            foreach (DOVKUR dovkur in dovizList)
            {
                if (dovkur.DVCNKD == "USD")
                {
                    if (kurHesaplamaYontemi == KurHesapEnum.DovizAlis) usdKur = (decimal)dovkur.DVFYT1;
                    if (kurHesaplamaYontemi == KurHesapEnum.DovizSatis) usdKur = (decimal)dovkur.DVFYT2;
                    if (kurHesaplamaYontemi == KurHesapEnum.EfektifAlis) usdKur = (decimal)dovkur.DVFYT3;
                    if (kurHesaplamaYontemi == KurHesapEnum.EfektifSatis) usdKur = (decimal)dovkur.DVFYT4;
                }
                else if (dovkur.DVCNKD == "EUR")
                {
                    if (kurHesaplamaYontemi == KurHesapEnum.DovizAlis) eurKur = (decimal)dovkur.DVFYT1;
                    if (kurHesaplamaYontemi == KurHesapEnum.DovizSatis) eurKur = (decimal)dovkur.DVFYT2;
                    if (kurHesaplamaYontemi == KurHesapEnum.EfektifAlis) eurKur = (decimal)dovkur.DVFYT3;
                    if (kurHesaplamaYontemi == KurHesapEnum.EfektifSatis) eurKur = (decimal)dovkur.DVFYT4;
                }
            }

            var saKalemFiyat = _spfharService.Ncch_GetSatinalmaSonFiyat_NLog(global, false).Items;

            DataTable dtSubLevels = dt2.Clone();
            maxAltId = Convert.ToInt32(urunAgaciTable.Select("AltId = MAX(AltId)")[0]["AltId"]);

            foreach (DataRow row in urunAgaciTable.Rows)
            {
                decimal miktar = Convert.ToDecimal(row["Miktar"]);
                string stokKodu = row["StokKodu"].ToString();
                string revizyonNo = row["RevizyonNo"].ToString();
                int parentId = Convert.ToInt32(row["AltId"]);
                int seviye = Convert.ToInt32(row["Seviye"]);
                bool fantom = Convert.ToBoolean(row["FantomKalemi"]);
                decimal kur = 1;

                SaKalemFiyat kalemFiyat = saKalemFiyat.FirstOrDefault(f => f.STKODU == stokKodu);
                if (kalemFiyat != null)
                {
                    if (kalemFiyat.DVCNKD == "USD") kur = usdKur;
                    if (kalemFiyat.DVCNKD == "EUR") kur = eurKur;

                    if (kalemFiyat.PRBRFY.HasValue)
                    {
                        row["PartiBirimFiyat"] = kalemFiyat.PRBRFY.Value;
                        row["Tutar"] = miktar * kalemFiyat.PRBRFY.Value;
                        row["TutarTL"] = (miktar * kalemFiyat.PRBRFY.Value * kur);
                    }
                    else
                    {
                        row["Tutar"] = miktar * kalemFiyat.GFIYAT;
                        row["TutarTL"] = miktar * kalemFiyat.GFIYAT * kur;
                    }

                    row["StokAdi"] = kalemFiyat.STKNAM;
                    row["BirimFiyat"] = kalemFiyat.GFIYAT;
                    row["DovizCinsi"] = kalemFiyat.DVCNKD;
                    row["SaOlcuBirimi"] = kalemFiyat.SAOLKD;
                }

                DataTable subLevels = dt2.Clone();

                if (!fantom)
                {
                    GetUrunAgaciSubLevel(subLevels, stokKodu, revizyonNo, parentId, seviye + 1);
                    subLevels.Columns.Add("PartiBirimFiyat", typeof(decimal));
                    subLevels.Columns.Add("BirimFiyat", typeof(decimal));
                    subLevels.Columns.Add("Tutar", typeof(decimal));
                    subLevels.Columns.Add("DovizCinsi", typeof(string));
                    subLevels.Columns.Add("TutarTL", typeof(decimal));
                    subLevels.Columns.Add("SaOlcuBirimi", typeof(string));

                    foreach (DataRow sRow in subLevels.Rows)
                    {
                        kur = 1;
                        decimal sMiktar = Convert.ToDecimal(sRow["Miktar"]) * miktar;
                        sRow["Miktar"] = sMiktar;

                        kalemFiyat = saKalemFiyat.FirstOrDefault(f => f.STKODU == sRow["StokKodu"].ToString());
                        if (kalemFiyat != null)
                        {
                            if (kalemFiyat.DVCNKD == "USD") kur = usdKur;
                            if (kalemFiyat.DVCNKD == "EUR") kur = eurKur;

                            if (kalemFiyat.PRBRFY.HasValue)
                            {
                                sRow["PartiBirimFiyat"] = kalemFiyat.PRBRFY.Value;
                                sRow["Tutar"] = sMiktar * kalemFiyat.PRBRFY.Value;
                                sRow["TutarTL"] = sMiktar * kalemFiyat.PRBRFY.Value * kur;
                            }
                            else sRow["Tutar"] = sMiktar * kalemFiyat.GFIYAT * kur;

                            sRow["StokAdi"] = kalemFiyat.STKNAM;
                            sRow["BirimFiyat"] = kalemFiyat.GFIYAT;
                            sRow["DovizCinsi"] = kalemFiyat.DVCNKD;
                            sRow["SaOlcuBirimi"] = kalemFiyat.SAOLKD;
                        }
                    }
                    dtSubLevels.Merge(subLevels);
                }

                if (dtSubLevels.Rows.Count > 0) maxAltId = Convert.ToInt32(dtSubLevels.Select("AltId = MAX(AltId)")[0]["AltId"]);
            }

            urunAgaciTable.Merge(dtSubLevels);

            urunAgaciTable.Columns.Remove("Silme");
            urunAgaciTable.Columns.Remove("UretimYeriKodu");
            urunAgaciTable.Columns.Remove("KalemTipi");
            urunAgaciTable.Columns.Remove("FantomKalemi");
            urunAgaciTable.Columns.Remove("Siralama");
            urunAgaciTable.Columns.Remove("SabitMiktar");
            urunAgaciTable.Columns.Remove("StokResim");
            urunAgaciTable.Columns.Remove("MasterStokKodu");
            urunAgaciTable.Columns.Remove("ParentStokKodu");
            urunAgaciTable.Columns.Remove("AltUrunAgaciKodu");
            urunAgaciTable.Columns["SaOlcuBirimi"].SetOrdinal(7);

            return urunAgaciTable;
        }

        private List<DOVKUR> GetDailyCurrency(List<string> dvcnkdList)
        {
            List<DOVKUR> dovizList = new List<DOVKUR>();

            foreach (var dovkod in dvcnkdList)
            {
                DOVKUR dovkur = _dovkurService.Cch_GetByDate_NLog(dovkod, DateTime.Now.Date).Nesne;

                if (dovkur == null)
                {
                    dovkur = new DOVKUR { DVCNKD = dovkod, DOVTRH = DateTime.Now.Date };
                    dovkur = _dovkurService.GetDovizKuru(dovkur);
                }

                if (dovkur != null && dovkur.DVFYT2 > 0)
                {
                    dovkur.DOVTRH = DateTime.Now.Date;
                    dovizList.Add(dovkur);
                }
            }

            if (dovizList.Count == 0) dovizList = _dovkurService.GetRecentCurrencies(global).Items;

            return dovizList;
        }

       
       

        private void repButVaryant_Click(object sender, EventArgs e)
        {
            string stokKodu = treeList.GetFocusedRowCellValue(treeList.Columns["StokKodu"]).ToString();
            string stmltr = treeList.GetFocusedRowCellValue(treeList.Columns["MalzemeTuru"]).ToString();

            FrmStokSecim sForm = new FrmStokSecim(global, stokKodu, stmltr);
            sForm.ShowDialog();

            if (sForm.stkart != null)
            {
                DataRow row = treeList.GetFocusedDataRow();

                URAGVR uragvr = new URAGVR
                {
                    SIRKID = global.SirketId.Value,
                    ACTIVE = true,
                    SLINDI = false,
                    CHKCTR = false,
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now,
                    KYNKKD = "3",
                    //STKODU = sForm.stkart.STKODU,
                    //GNMKTR = Convert.ToDecimal(row["Miktar"]),
                    //OLCUKD = sForm.stkart.OLCUKD,
                    //STMLTR = sForm.stkart.STMLTR,
                };

                variantList[treeList.FocusedNode.Id].Add(uragvr);
            }
        }

        private void repButRota_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            var data = treeList.GetFocusedRow() as DataRowView;

            int uragid = Convert.ToInt32(data["Id"]);
            URAGAC uragac = _urunAgaciService.Ncch_GetById_NLog(uragid, global, false).Nesne;
            string stokKodu = data["StokKodu"].ToString();
            string stokAdi = stokList.FirstOrDefault(s => s.STKODU == stokKodu).STKNAM;

            FrmParcaUretimRota pForm = new FrmParcaUretimRota(uragac, global);
            pForm.Text = $"{stokKodu} - {stokAdi}";

            pForm.ShowDialog();
        }

        private void treeList_DragEnter(object sender, DragEventArgs e)
        {
            // Check if the dragged data is a file
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0 && IsImageFile(files[0]))
                {
                    e.Effect = DragDropEffects.Copy;
                }
                else
                {
                    e.Effect = DragDropEffects.None;
                }
            }
        }

        private bool IsImageFile(string filePath)
        {
            string extension = Path.GetExtension(filePath).ToLower();
            return extension == ".jpg" || extension == ".jpeg" || extension == ".png" || extension == ".pdf";
        }

        private void treeList_DragDrop(object sender, DragEventArgs e)
        {
            try
            {
                Point pt1 = treeList.PointToClient(new Point(e.X, e.Y));
              
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                if (files != null && files.Length > 0)
                {
                    string filePath = files[0];
                    string extension = Path.GetExtension(filePath).ToLower();

                    Point pt = treeList.PointToClient(new Point(e.X, e.Y));
                    TreeListHitInfo hitInfo = treeList.CalcHitInfo(pt);

                    if (hitInfo.Node != null)
                    {
                        TreeListNode node = hitInfo.Node;
                        string stokKodu = node.GetValue(1).ToString();
                        
                        List<UrunAgaciUst> uaUstList = new List<UrunAgaciUst>();
                        GetUrunAgaciUpperLevels(stokKodu, uaUstList);
                        string masterStokKodu = uaUstList.Last().USKODU;

                        string newFileFolder = AppDomain.CurrentDomain.BaseDirectory + $@"\servis\teknik\{masterStokKodu}\{stokKodu}\";
                        if (!Directory.Exists(newFileFolder)) Directory.CreateDirectory(newFileFolder);

                        if (extension == ".pdf")
                        {
                            string newFilePath = newFileFolder + Path.GetFileNameWithoutExtension(filePath);

                            List<Image> images = Bps.Core.Utilities.Converters.Convert.ConvertPdfToImage(filePath);
                            for (int i = 0; i < images.Count; i++)
                            {
                                Image image = images[i];
                                string fileName = newFilePath + "-" + (i + 1).ToString() + ".png";
                                image.Save(fileName);
                            }
                        }
                        else
                        {
                            string newFilePath = newFileFolder + Path.GetFileName(filePath);
                            File.Copy(filePath, newFilePath);
                        }
                        // node.SetValue(0, Path.GetFileName(filePath));
                    }
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void GetUrunAgaciUpperLevels(string stokKodu, List<UrunAgaciUst> uaUstList)
        {
            List<UrunAgaciUst> list = _urunAgaciService.Ncch_GetUrunAgaciUst_NLog(global, stokKodu).Items;
            if (list != null && list.Count > 0)
            {
                uaUstList.AddRange(list);
                GetUrunAgaciUpperLevels(list[0].USKODU, uaUstList);
            }
        }

        private void btnExcel_Click(object sender, EventArgs e)
        {

            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + TxtStokKodu.Text + ".xlsx";
            treeList.ExportToXlsx(filePath);
            Process.Start(filePath);
        }

        private void LkEdVrKodu_EditValueChanged(object sender, EventArgs e)
        {
            var vrkodent = LkEdVrKodu.GetSelectedDataRow() as STBDRN;
            if (vrkodent == null)
            {
                LkEdRenkKd.EditValue = null;
                LkEdBedenKd.EditValue = null;
                LkEdDropKd.EditValue = null;
            }
            else
            {
                LkEdRenkKd.EditValue = vrkodent.RENKKD;
                LkEdBedenKd.EditValue = vrkodent.BEDNKD;
                LkEdDropKd.EditValue = vrkodent.DROPKD;
                LkEdRenkKdP2.EditValue = vrkodent.RENKKD;
                LkEdBedenKdP2.EditValue = vrkodent.BEDNKD;
                LkEdDropKdP2.EditValue = vrkodent.DROPKD;
                LkEdVrKoduP2.EditValue = LkEdVrKodu.EditValue;
                LoadRevizyonLkEd(TxtStokKodu.Text);

            }
        }

        Dictionary<string, List<StbdrnListModel>> lookupCache = new Dictionary<string, List<StbdrnListModel>>();
        private void treeList_ShownEditor(object sender, EventArgs e)
        {
            TreeList tree = sender as TreeList;
            string _stkkodu = Convert.ToString(tree.GetFocusedRowCellValue(treeStokKodu));

            if (tree.FocusedColumn ==treeVryKodu || tree.FocusedColumn == treeRenkKd || tree.FocusedColumn == treeBednKd)
            {
                if (!string.IsNullOrEmpty(_stkkodu))
                {
                    GridLookUpEdit editor = (GridLookUpEdit)tree.ActiveEditor;
                    string cacheKey = $"{_stkkodu}";
                    
                    if (lookupCache.TryGetValue(cacheKey, out List<StbdrnListModel> repoItem))
                    {

                        editor.Properties.DataSource = repoItem;
                    }
                    else
                    {
                        var _vrydata = _stbdrnService.Cch_GetListModelByStok_NLog(_stkkodu, global, false).Items;
                        editor.Properties.DataSource = _vrydata;
                        lookupCache[cacheKey] = _vrydata;
                    }
                       
                    
                }
            }
        }

        Dictionary<string,List<StbdrnListModel>> lookupCacheModel = new Dictionary<string, List<StbdrnListModel>>();
        private void treeList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            if (e.Column == treeVryKodu && e.Column.Visible == true  ) 
            {
                string _stkkodu = e.Node.GetValue(treeStokKodu).ToString();
                string _vrykodu = e.Node.GetValue(treeVryKodu).ToString();
                if (!string.IsNullOrEmpty(_stkkodu) && !string.IsNullOrEmpty(_vrykodu))
                {
                    string cacheKey = $"{_stkkodu}_{_vrykodu}";
                    if (lookupCacheModel.TryGetValue(cacheKey, out List<StbdrnListModel> repoItem))
                    {
                        repLookUpVryKod.DataSource = repoItem;
                        repLookUpRENKKD.DataSource = repoItem;
                        repLookUpBEDNKD.DataSource = repoItem;
                    }
                    else
                    {
                        var _vrydata = _stbdrnService.Cch_GetListModelByStok_NLog(_stkkodu, global, false, _vrykodu).Items;
                        repLookUpVryKod.DataSource = _vrydata;
                        repLookUpRENKKD.DataSource = _vrydata;
                        repLookUpBEDNKD.DataSource = _vrydata;
                        lookupCacheModel[cacheKey] = _vrydata; 
                       
                    }
                }             
            }
        }
    }
}
