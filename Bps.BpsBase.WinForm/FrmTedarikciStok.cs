using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.MH;
using Bps.BpsBase.Business.Abstract.SA;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.Entities.Models;
using Bps.BpsBase.Entities.Models.CR.Enums;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.Entities.Models.ST.Enums;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.BpsBase.Entities.Models.UA;
using Bps.Core.Entities;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.Helpers;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms.Helper;
using DevExpress.LookAndFeel;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;
using DevExpress.XtraReports.UserDesigner;
using DevExpress.XtraTab;
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
using System.Xml;
using CommandVisibility = DevExpress.XtraReports.UserDesigner.CommandVisibility;

namespace BPS.Windows.Forms
{
    public partial class FrmTedarikciStok : Base.FrmChildBase
    {
        private IStkartService _stokKartService;

        private IXXService _stokService;

        //private IStokKartSinifService _stokKartSinifService;
        private BindingList<STKART> _stokKartBindingList;
        private BindingList<STNAME> _stokTanimBindingList;
        private ProjeMenuListed yetkiModel;
        private readonly IGnyetkService _gnyetkService;
        private readonly IStmaltService _stmaltService;

        private readonly IUragacService _uragacService;
        private readonly IGnthrkService _gnthrkService;
        private readonly IGndptnService _gndptnService;

        private readonly ISttdtrService _sttdtrService;
        private readonly IStdepoService _stdepoService;

        private readonly IStnameService _stnameService;

        private readonly IStbdrnService _stbdrnService;
        private readonly IStcrkdService _stcrkdService;
        private List<GNYETB> ortamModel;
        private readonly IGnyetbService _gnyetbService;

        private readonly ICrcariService _crcariService;

        private BindingList<STOLCU> oldBindingList;

        private List<List<IEntity>> entitiesFromExcel;
        private int? deletedId { get; set; }

        private STKART _stokKart;
        int maxAltId = 0;

        private List<Grid> focusedRowHandler = new List<Grid>();
        private string _action;
        private short _etiketSayisi;
        private string imageFolder = "";
        private string saveFolder = "";

        private List<Dictionary<int, List<UrunOpsiyonModel>>> opsiyonList =
            new List<Dictionary<int, List<UrunOpsiyonModel>>>();

        private List<TipHareketListModel> malGrubuTanimList = new List<TipHareketListModel>();
        private List<TipHareketListModel> stokAnaGrupList = new List<TipHareketListModel>();
        private List<TipHareketListModel> stokAltGrupList = new List<TipHareketListModel>();
        private List<TipHareketListModel> stokGrup1List = new List<TipHareketListModel>();
        private List<TipHareketListModel> stokGrup2List = new List<TipHareketListModel>();
        private List<TipHareketListModel> stokGrup3List = new List<TipHareketListModel>();
        private List<UrunAgaciModulPaket> uaModulPaketList = new List<UrunAgaciModulPaket>();

        Dictionary<string, RepositoryItemGridLookUpEdit> repositoryList =
            new Dictionary<string, RepositoryItemGridLookUpEdit>();

        public FrmTedarikciStok(IStkartService stokKartService, IXXService stokService, IGnyetkService gnyetkService,
            IStmaltService stmaltService,
            IGnthrkService gnthrkService, IGndptnService gndptnService, ISttdtrService sttdtrService,
            IStdepoService stdepoService,
            IStnameService stnameService,
            IGnyetbService gnyetbService
            , IStbdrnService stbdrnService, ICrcariService crcariService, IStcrkdService stcrkdService)
        {
            _stokKartService = stokKartService;
            _gnyetkService = gnyetkService;
            _stmaltService = stmaltService;


            _gnthrkService = gnthrkService;
            _gndptnService = gndptnService;
            _sttdtrService = sttdtrService;
            _stokService = stokService;
            _stdepoService = stdepoService;

            _stnameService = stnameService;


            _gnyetbService = gnyetbService;
            _stbdrnService = stbdrnService;
            _crcariService = crcariService;
            _stcrkdService = stcrkdService;
            InitializeComponent();
            xtraTabControl1.ShowTabHeader = DevExpress.Utils.DefaultBoolean.False;
            _etiketSayisi = 1;
        }

        private void FrmStokKart_Load(object sender, EventArgs e)
        {
            //barManager.Items["barGoruntule"].Visibility = BarItemVisibility.Always;
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ortamModel = _gnyetbService.Cch_GetListYetkiId_NLog(yetkiModel.Id, global, false).Items;
            FormIslemleri.FormYetki2(barManager, yetkiModel, ortamModel);

            var teknads = new List<string>() { "MALGKD", "URYRKD", "LANGKD", "STANKD", "STALKD", "SPORKD", "RENKKD", "BEDNKD", "DROPKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            var tedarikTurList = _sttdtrService.Cch_GetList_NLog(global, false).Items;
            var depoTanims = _gndptnService.Cch_GetList_NLog(global, false).Items;
            rENKKDTextEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "RENKKD").ToList();
            bEDNKDTextEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "BEDNKD").ToList();
            dROPKDTextEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "DROPKD").ToList();
            uRYRKDTextEdit.Properties.DataSource = teknadsResponse.Items.Where(w => w.TEKNAD == "URYRKD").ToList();

            var malzemeTuruTanimList = _stmaltService.Cch_GetList_NLog(global, false).Items;
            LkEdMalzTuru.Properties.DataSource = malzemeTuruTanimList.OrderBy(m => m.STMLTR).ToList();
            repositoryCRKODULookUpEdit.DataSource = _crcariService.Cch_GetList_NLog(global).Items;

            GridHelper.ColumnRepositoryItems(gridView1, global);
            GridHelper.ColumnRepositoryItems(gridView2, global);
            GridHelper.ColumnRepositoryItems(gridViewStCRKD, global);


        }

        protected override void barGoruntule_ItemClick(object sender, ItemClickEventArgs e)
        {
            //FormIslemleri.SetControlsReadonlyProperty(groupControl3);
            //FormIslemleri.SetControlsReadonlyProperty(groupControl4);
            //FormIslemleri.SetControlsReadonlyProperty(groupControl5);
            //FormIslemleri.SetControlsReadonlyProperty(groupControl6);
            //FormIslemleri.SetControlsReadonlyProperty(groupControl10);
            //FormIslemleri.SetControlsReadonlyProperty(grpSablonTasarim);
        }

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            deletedId = null;
            //TxtStokKodu.Enabled = true;
            //TxtMalzemeTuru.Enabled = false;
            //btnKodOlustur.Enabled = true;

            var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;

            if (tur != null)
            {

                _action = "insert";
                GetSelectGridViewRow(gridView1, gridView2, tur);
                if (tur.STBDEN == true || tur.STRENK == true || tur.STDROP == true)
                {
                    if (gridView2.FocusedRowHandle > -1)
                    {

                    }
                    else
                    {
                        MessageBox.Show("Seçim işlemi yapmadınız");
                        return;
                    }
                }

                FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                //Validation hatası yüzünden kaldırıldı. Tekrar bakılacak

                //sTCRKDBindingSource.DataSource = new STCRKD();
                data_load();
                //sTCRKDBindingSource.RemoveCurrent();
                bindingNavigatorAddNewItem2.Enabled = true;
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
                xtraTabControl2.SelectedTabPage = xtraTabPage10;
                xtraTabPage10.PageVisible = true;
            }
        }
        private void data_load()
        {
            sTCRKDBindingSource.DataSource = _stcrkdService.Cch_GetListByStokKodu_NLog(GetSafeString(sTKODUTextEdit.EditValue), GetSafeString(vRKODUTextEdit.EditValue), global).Items;
        }


        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            deletedId = null;

            focusedRowHandler.Clear();
            var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
            {
                if (tur == null) return;

                if (tur != null && gridView1.FocusedRowHandle > -1) FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);

                string bakimDurum = tur.STBKDR;
                _action = "update";

                STKART sKart = sTKARTBindingSource.Current as STKART;

                GetSelectGridViewRow(gridView1, gridView2, tur);
                bindingNavigatorAddNewItem2.Enabled = false;
                data_load();
                xtraTabControl1.SelectedTabPage = xtraTabPage2;
                xtraTabControl2.SelectedTabPage = xtraTabPage10;
                xtraTabPage10.PageVisible = true;
            }
        }

        private string GetSafeString(object input)
        {
            return input?.ToString();
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {


            if (Validate())
            {
                if (xtraTabControl1.SelectedTabPage == xtraTabPage1) return;
                var stcrkdBindingList = sTCRKDBindingSource.List;
                var Stcrkds = new List<STCRKD>();
                foreach (var bind in stcrkdBindingList)
                {
                    Stcrkds.Add((STCRKD)bind);
                }
                if (Stcrkds != null)
                {
                    var inserted = Stcrkds.Where(w => w.Id == 0).ToList();
                    foreach (var data in inserted)
                    {
                        data.STKODU = GetSafeString(sTKODUTextEdit.EditValue);
                        data.URYRKD = GetSafeString(uRYRKDTextEdit.EditValue);
                        data.VRKODU = GetSafeString(vRKODUTextEdit.EditValue);
                        data.RENKKD = GetSafeString(rENKKDTextEdit.EditValue);
                        data.BEDNKD = GetSafeString(bEDNKDTextEdit.EditValue);
                        data.DROPKD = GetSafeString(dROPKDTextEdit.EditValue);
                        data.SIRKID = global.SirketId.Value;
                        data.KYNKKD = global.KaynakKod;
                        data.ACTIVE = true;
                        data.SLINDI = false;
                        data.EKKULL = global.UserKod;
                        data.ETARIH = DateTime.Now;
                       var response = _stcrkdService.Ncch_Add_NLog(data, global);
                        if (response.Status != ResponseStatusEnum.OK)
                        {
                            MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    foreach (var grid in focusedRowHandler)
                    {
                        STCRKD data = null;
                        if (grid.Tipi == "delete")
                        {
                            data = _stcrkdService.Ncch_GetById_NLog(grid.Id, global).Nesne;
                        }
                        else if (grid.Tipi == "update")
                        {
                            data = Stcrkds.FirstOrDefault(f => f.Id == grid.Id);
                        }


                        if (grid.Tipi == "update")
                        {
                           
                            data.SIRKID = global.SirketId.Value;
                            data.KYNKKD = global.KaynakKod;
                            data.ACTIVE = true;
                            data.SLINDI = false;
                            data.DEKULL = global.UserKod;
                            data.DTARIH = DateTime.Now;
                           var response = _stcrkdService.Ncch_Update_Log(data, data, global);
                            if (response.Status != ResponseStatusEnum.OK)
                            {
                                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                        else if (grid.Tipi == "delete")
                        {
                            data.ACTIVE = false;
                            data.SLINDI = true;
                            data.DEKULL = global.UserKod;
                            data.DTARIH = DateTime.Now;
                            var response =_stcrkdService.Ncch_Update_Log(data, data, global);
                            if (response.Status != ResponseStatusEnum.OK)
                            {
                                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }

                    if (_action == "delete")
                    {
                        foreach (var data in Stcrkds)
                        {
                            data.ACTIVE = false;
                            data.SLINDI = true;
                            data.DEKULL = global.UserKod;
                            data.DTARIH = DateTime.Now;
                            var response =_stcrkdService.Ncch_Update_Log(data, data, global);
                            if (response.Status != ResponseStatusEnum.OK)
                            {
                                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                        }
                    }
                }

                

            }
















            data_load();
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);




        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            MessageBox.Show("Bu formda silme işlemi Griddeki sil butonu ile silinip kaydet ile yapılmaktadır");
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {

        }

        protected override void barBaskiOnizleme_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (!gridControl1.IsPrintingAvailable)
            {
                MessageBox.Show("Baskı Önizleme mümkün değil. ", "Hata");
                return;
            }

            gridView1.ShowPrintPreview();
        }

        protected override void barFiltre_ItemClick(object sender, ItemClickEventArgs e)
        {
            gridView1.OptionsView.ShowAutoFilterRow = gridView1.OptionsView.ShowAutoFilterRow == false;
        }

        private void LkEdMalzTuru_EditValueChanged(object sender, EventArgs e)
        {
            if (LkEdMalzTuru.EditValue != null)
            {
                var tur = LkEdMalzTuru.GetSelectedDataRow() as STMALT;
                string malzemeTuru = LkEdMalzTuru.EditValue.ToString();
                List<STKART> stkarts = _stokKartService.Cch_GetListByMalTur_NLog(global, malzemeTuru, false).Items;
                sTKARTBindingSource.DataSource = stkarts;
                gridView1.BestFitColumns();

                SetRepositoryLookups();

            }
        }

        private void SetRepositoryLookups()
        {
            List<STKART> stkarts = new List<STKART>();
            for (int i = 0; i < gridView1.RowCount; i++)
            {
                STKART cust = gridView1.GetRow(i) as STKART;
                stkarts.Add(cust);
            }

            List<TipHareketListModel> filteredList = new List<TipHareketListModel>();

            var parentHarkods = stkarts.Select(s => s.STANKD).Distinct().ToList();
            foreach (string harkod in parentHarkods)
            {
                TipHareketListModel anaGrup = stokAnaGrupList.FirstOrDefault(s => s.HARKOD == harkod);
                filteredList.AddRange(stokAltGrupList.Where(s => s.PARENT == anaGrup.Id).ToList());
            }

            repLkedStokAltGrup.DataSource = filteredList;
        }



        private void gridView_CellValueChanged(object sender,
            DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            GridView view = sender as GridView;
            if (view == null) return;

            var cellValue = (int)view.GetRowCellValue(e.RowHandle, view.Columns["Id"]);
            if (cellValue > 0)
            {
                var a = focusedRowHandler.FirstOrDefault(x => x.Id == cellValue);

                if (a == null)
                {
                    focusedRowHandler.Add(new Grid(cellValue, "update", view.Tag.ToString()));
                }
            }



        }

        private void gridViewStDepo_InitNewRow(object sender, InitNewRowEventArgs e)
        {
           
        }

        private void bindingNavigatorDeleteItem_Click(object sender, EventArgs e)
        {
            if (deletedId != null)
            {
                ToolStripButton toolStripButton = sender as ToolStripButton;
                if (toolStripButton == null) return;
                var tag = toolStripButton.Tag.ToString();
                //var a = focusedRowHandler.FirstOrDefault(f => f.View == tag);
                //if (a != null)
                //{
                //    focusedRowHandler.Remove(a);
                //}

                focusedRowHandler.Add(new Grid(deletedId.Value, "delete", tag));
                deletedId = null;
            }
        }

        private void bindingNavigatorDeleteItem_MouseDown(object sender, MouseEventArgs e)
        {
            ToolStripButton toolStripButton = sender as ToolStripButton;
            if (toolStripButton == null) return;
            var tag = toolStripButton.Tag.ToString();

            deletedId = null;

            if (tag == "STCRKD")
            {
                var current = (STCRKD)sTCRKDBindingSource.Current;
                if (current != null && current.Id > 0)
                {
                    deletedId = current.Id;
                }
            }


        }

        private void gridControl1_DoubleClick(object sender, EventArgs e)
        {
            //Point point = gridView1.GridControl.PointToClient(MousePosition);
            //DevExpress.XtraGrid.Views.Grid.ViewInfo.GridHitInfo info = gridView1.CalcHitInfo(point);
            //if (info.InRow || info.InRowCell)
            //{
            //    if (info.Column.FieldName == "STEKOD" && gridView1.OptionsBehavior.Editable)
            //    {
            //        info.Column.OptionsColumn.AllowEdit = true;
            //        info.Column.OptionsColumn.ReadOnly = false;
            //    }
            //    else
            //    {
            //        var link = barDegistir.GetVisibleLinks()[0];
            //        ItemClickEventArgs arg = new ItemClickEventArgs(barDegistir, link);
            //        barDegistir_ItemClick(barDegistir, arg);
            //    }
            //}
        }

        protected override void barOrtamEk_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (gridView1.GetFocusedRowCellValue("Id") == null)
            {
                MessageBox.Show("Lütfen kayıt seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            FrmFileManager form = new FrmFileManager(global, "STKART", id);
            form.ShowDialog();
        }

        private RepositoryItemGridLookUpEdit CreateRepositoryItem(List<TipHareketListModel> dataSource)
        {
            RepositoryItemGridLookUpEdit repItem = new RepositoryItemGridLookUpEdit();

            repItem.AutoHeight = false;
            repItem.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[]
            {
                new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)
            });
            repItem.DisplayMember = "TANIMI";
            repItem.NullText = "";
            repItem.PopupView = this.repositoryItemGridLookUpEdit25View;
            repItem.ValueMember = "HARKOD";
            repItem.DataSource = dataSource;

            return repItem;
        }

        private void GetSelectGridViewRow(GridView gridView_1, GridView gridView_2, STMALT _stmalt, int _form = 0)
        {
            STKART _stokKart = gridView_1.GetFocusedRow() as STKART;
            STBDRN _stcrkd = gridView_2.GetFocusedRow() as STBDRN;
            if (_stcrkd == null)
            {
                return;
            }
            sTKODUTextEdit.Text = _stokKart.STKODU;
            sTKADITextEdit.Text = _stokKart.STKNAM;
            _stmalt.STBDEN = _stmalt.STBDEN ?? false;
            _stmalt.STRENK = _stmalt.STRENK ?? false;
            _stmalt.STDROP = _stmalt.STDROP ?? false;

            if (_stmalt.STBDEN == true || _stmalt.STRENK == true || _stmalt.STDROP == true)
            {

                rENKKDTextEdit.Text = _stcrkd.RENKKD ;
                bEDNKDTextEdit.Text = _stcrkd.BEDNKD;
                dROPKDTextEdit.Text = _stcrkd.DROPKD;
                uRYRKDTextEdit.Text = _stcrkd.URYRKD;
                vRKODUTextEdit.Text = _stcrkd.VRKODU;


            }
            if (_stmalt.STBDEN == false)
            {
                bEDNKDTextEdit.Visible = false;
                bEDNKDLabel.Visible = false;
            }
            if (_stmalt.STRENK == false)
            {
                rENKKDTextEdit.Visible = false;
                rENKKDLabel.Visible = false;
            }
            if (_stmalt.STDROP == false)
            {
                dROPKDTextEdit.Visible = false;
                dROPKDLabel.Visible = false;
            }


        }

        public class DesignerCommandHandler : DevExpress.XtraReports.UserDesigner.ICommandHandler
        {
            XRDesignMdiController mdiController;
            STKART stkart;
            string saveFolder;
            private Action callbackAction;

            public DesignerCommandHandler(XRDesignMdiController mdiController, STKART stkart, string saveFolder,
                Action callBackAction)
            {
                this.mdiController = mdiController;
                this.stkart = stkart;
                this.saveFolder = saveFolder;
                this.callbackAction = callBackAction;
            }

            public void HandleCommand(ReportCommand command, object[] args)
            {
                if (command == ReportCommand.SaveFile || command == ReportCommand.SaveFileAs ||
                    command == ReportCommand.SaveAll)
                {
                    Directory.CreateDirectory(saveFolder);

                    SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                    saveFileDialog1.InitialDirectory = saveFolder;
                    saveFileDialog1.Title = "Şablonu Kaydet";
                    saveFileDialog1.CheckFileExists = false;
                    saveFileDialog1.CheckPathExists = false;
                    saveFileDialog1.DefaultExt = "xml";
                    saveFileDialog1.Filter = "Şablon Dosyası (*.xml)|*.xml";
                    saveFileDialog1.FilterIndex = 1;
                    saveFileDialog1.RestoreDirectory = true;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        string fileNameOnly = Path.GetFileName(saveFileDialog1.FileName);
                        EditXml("DisplayName", fileNameOnly, saveFileDialog1.FileName);
                        mdiController.ActiveDesignPanel.Report.DisplayName = fileNameOnly;
                        mdiController.ActiveDesignPanel.ReportState = ReportState.Saved;

                        callbackAction.Invoke();
                    }
                }
                else if (command == ReportCommand.OpenFile)
                {
                    Directory.CreateDirectory(saveFolder);

                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.InitialDirectory = saveFolder;
                    openFileDialog.Title = "Şablon Dosyası Aç";
                    openFileDialog.DefaultExt = "xml";
                    openFileDialog.Filter = "Şablon Dosyası (*.xml)|*.xml";
                    openFileDialog.FilterIndex = 1;
                    openFileDialog.RestoreDirectory = true;
                    if (openFileDialog.ShowDialog() == DialogResult.OK)
                    {
                        if (mdiController.ActiveDesignPanel != null)
                        {
                            MemoryStream stream = new MemoryStream();
                            using (FileStream fs = File.OpenRead(openFileDialog.FileName))
                            {
                                fs.CopyTo(stream);
                            }

                            EditXml("DisplayName", openFileDialog.SafeFileName, openFileDialog.FileName, stream);
                            mdiController.ActiveDesignPanel.OpenReport(openFileDialog.FileName);
                            mdiController.ActiveDesignPanel.Report.DisplayName = openFileDialog.SafeFileName;
                        }
                    }
                }
            }

            public void EditXml(string attribute, string value, string filePath, MemoryStream stream = null)
            {
                if (stream == null)
                {
                    stream = new MemoryStream();
                    stream.Seek(0, SeekOrigin.Begin);
                    mdiController.ActiveDesignPanel.Report.SaveLayoutToXml(stream);
                }

                stream.Seek(0, SeekOrigin.Begin);

                XmlDocument doc = new XmlDocument();
                doc.Load(stream);

                var attributes = doc.ChildNodes[1].Attributes;
                if (attributes != null) attributes[attribute].InnerText = value;

                stream = new MemoryStream();
                stream.Seek(0, SeekOrigin.Begin);
                doc.Save(stream);
                stream.Seek(0, SeekOrigin.Begin);

                using (FileStream file = new FileStream(filePath, FileMode.Create, FileAccess.Write))
                {
                    stream.WriteTo(file);
                }
            }

            public bool CanHandleCommand(ReportCommand command,
                ref bool useNextHandler)
            {
                useNextHandler = !(command == ReportCommand.SaveFile ||
                                   command == ReportCommand.OpenFile);
                return !useNextHandler;
            }

        }


        private void gridView1_ColumnFilterChanged(object sender, EventArgs e)
        {
            SetRepositoryLookups();
        }







        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle > -1)
            {
                sTBDRNBindingSource.DataSource =
                     _stbdrnService.Cch_GetListByStokKodu_NLog(
                         gridView1.GetFocusedRowCellValue("STKODU").ToString(), global, false).Items;
                gridView2.FocusedRowHandle = -1;
            }

        }

        private void gridViewStCRKD_InitNewRow(object sender, InitNewRowEventArgs e)
        {
            gridViewStCRKD.SetRowCellValue(e.RowHandle, gridViewStCRKD.Columns["STKODU"], sTKODUTextEdit.EditValue);
            gridViewStCRKD.SetRowCellValue(e.RowHandle, gridViewStCRKD.Columns["URYRKD"], uRYRKDTextEdit.EditValue);
            gridViewStCRKD.SetRowCellValue(e.RowHandle, gridViewStCRKD.Columns["VRKODU"], vRKODUTextEdit.EditValue);
            gridViewStCRKD.SetRowCellValue(e.RowHandle, gridViewStCRKD.Columns["RENKKD"], rENKKDTextEdit.EditValue);
            gridViewStCRKD.SetRowCellValue(e.RowHandle, gridViewStCRKD.Columns["BEDNKD"], bEDNKDTextEdit.EditValue);
            gridViewStCRKD.SetRowCellValue(e.RowHandle, gridViewStCRKD.Columns["DROPKD"], dROPKDTextEdit.EditValue);


            gridViewStCRKD.SetRowCellValue(e.RowHandle, gridViewStCRKD.Columns["ACTIVE"], true);

        }

        private void sTCRKDBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
            
        }
    }
}