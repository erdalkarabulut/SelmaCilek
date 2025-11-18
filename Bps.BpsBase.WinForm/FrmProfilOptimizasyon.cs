using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading;
using System.Windows.Forms;

using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using DevExpress.LookAndFeel;
using DevExpress.Utils;
using DevExpress.Utils.Extensions;
using DevExpress.XtraBars;
using DevExpress.XtraCharts;
using DevExpress.XtraCharts.Native;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraPrinting;
using DevExpress.XtraReports.UI;

namespace BPS.Windows.Forms
{
    public partial class FrmProfilOptimizasyon : BPS.Windows.Base.FrmChildBase
    {
        public DataTable kesilecekTable, kalanTable;
        public Optimizasyon gecmisOptimizasyon;
        public string _stokKodu;
        public string _stokAdi;

        private bool _formLoaded;
        private bool _optimizationIsDone;
        private List<Optimizasyon> _optimizasyonList;
        private List<ProfilKesimModel> _kullanilacakPartiler;
        private List<short> _gerceklesenKesimList;
        private DataTable _shTable;
        private DataTable _shAyrintiTable;
        private int _chartHeight = 0;
        private int _chartWidth = 0;

        private readonly IStkartService _stokKartService;
        private readonly ISthrktService _sthrktService;
        private readonly IStoptmService _stoptmService;
        private readonly IXXService _xxService;

        public FrmProfilOptimizasyon()
        {
            InitializeComponent();
            DepoChart.Dock = DockStyle.Fill;
            _chartHeight = DepoChart.Height;
            _chartWidth = DepoChart.Width;

            _stokKartService = InstanceFactory.GetInstance<IStkartService>();
            _sthrktService = InstanceFactory.GetInstance<ISthrktService>();
            _stoptmService = InstanceFactory.GetInstance<IStoptmService>();
            _xxService = InstanceFactory.GetInstance<IXXService>();
        }

        private void FrmProfilOptimizasyon_Load(object sender, EventArgs e)
        {
            kesilecekTable = new DataTable();
            kalanTable = new DataTable();

            lkEdStokKart.Properties.DataSource = _stokKartService.Ncch_GetListWithParti_NLog(global, false).Items;
            lkEdStokKart.Properties.View.BestFitColumns();

            profilKesimModelBindingSource.DataSource = new List<ProfilKesimModel>();
            _formLoaded = true;

            if (gecmisOptimizasyon != null)
            {
                btnTemizle.Enabled = false;
                HesaplaButton.Enabled = false;
                btnStokHareket.Enabled = false;
                lkEdStokKart.Enabled = false;
                IterasyonText.Enabled = false;
                TestereText.Enabled = false;
                chkTumStok.Enabled = false;

                gridView1.OptionsView.NewItemRowPosition = NewItemRowPosition.None;
                gridView1.OptionsBehavior.Editable = false;
                gridView1.OptionsBehavior.ReadOnly = true;

                lkEdStokKart.EditValue = _stokKodu;

                TestereText.Text = gecmisOptimizasyon.TesterePayi.ToString();
                profilKesimModelBindingSource.DataSource = gecmisOptimizasyon.KesimList;

                _optimizasyonList = new List<Optimizasyon>();
                _optimizasyonList.Add(gecmisOptimizasyon);
                PuanList.DataSource = _optimizasyonList;

                xtraTabControl1.SelectedTabPage = KesilecekPage;
            }
        }

        private void GetStok()
        {
            grdStok.DataSource = null;
            _shTable = new DataTable();
            _shAyrintiTable = new DataTable();
            _stokKodu = "";
            _stokAdi = "";

            if (lkEdStokKart.EditValue == null) return;

            string stokKodu = lkEdStokKart.EditValue.ToString();

            if (stokKodu != "")
            {
                //AND kaldırıldı. Kontrol edilecek
                string whereFilter = " STKODU = '" + stokKodu + "'";
                List<SthrktMiktarByPartiModel> stokMiktarList = _sthrktService.GetStokMiktarFromHareketByParti(global, whereFilter, false).Items;
                stokMiktarList = stokMiktarList.OrderBy(s => Convert.ToInt32(s.PARTIN)).ToList();

                if (stokMiktarList != null && stokMiktarList.Count > 0)
                {
                    _stokKodu = stokMiktarList[0].STKODU;
                    _stokAdi = stokMiktarList[0].STKNAM;
                    grdStok.DataSource = stokMiktarList;
                    grdViewStok.BestFitColumns();

                    _shTable = Bps.Core.Utilities.Converters.Convert.ListToDataTable(stokMiktarList);
                    _shAyrintiTable = _shTable.Clone();
                    _shAyrintiTable.Columns.Add("SIRA", typeof(short));

                    int sira = 0;
                    for (int i = 0; i < _shTable.Rows.Count; i++)
                    {
                        DataRow row = _shTable.Rows[i];
                        int miktar = Convert.ToInt32(row["GRMKTR"]);
                        for (int k = 0; k < miktar; k++)
                        {
                            _shAyrintiTable.Rows.Add(row.ItemArray);
                            _shAyrintiTable.Rows[_shAyrintiTable.Rows.Count - 1]["SIRA"] = sira;
                            sira++;
                        }
                    }
                }

                xtraTabControl1.SelectedTabPage = StokPage;
            }
        }

        private void HesaplaButton_Click(object sender, EventArgs e)
        {
            if (lkEdStokKart.EditValue == null || lkEdStokKart.EditValue == "")
            {
                MessageBox.Show("Stok seçmediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                profilKesimModelBindingSource.DataSource = new List<ProfilKesimModel>();
                lkEdStokKart.ShowPopup();
                return;
            }

            if (profilKesimModelBindingSource.Count == 0)
            {
                MessageBox.Show("Kesim listesini girmediniz.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                xtraTabControl1.SelectedTabPage = KesilecekPage;
                return;
            }

            btnTemizle_Click(null, EventArgs.Empty);
            progressBarControl1.Position = 0;
            lblYuzde.Text = "";

            if (_shTable.Rows.Count == 0) return;

            _formLoaded = false;
            _optimizationIsDone = false;
            PuanList.DataSource = null;
            PuanList.Items.Clear();
            //label1.Text = "";

            List<string> keyList = new List<string>();
            keyList.Add("");

            short testerePayi = 0;
            if (!short.TryParse(TestereText.Text, out testerePayi)) TestereText.Text = "0";

            List<short> ihtiyacList = new List<short>();
            foreach (var item in profilKesimModelBindingSource.List as List<ProfilKesimModel>)
            {
                for (int i = 0; i < item.GNMKTR; i++)
                {
                    short toplamBoy = Convert.ToInt16(item.PARTIN);
                    toplamBoy += testerePayi;
                    ihtiyacList.Add(toplamBoy);
                }
            }

            object[] objArr = { keyList, ihtiyacList };

            Thread tuketimThread = new Thread(new ParameterizedThreadStart(TuketimHesaplaTh));
            tuketimThread.IsBackground = true;
            tuketimThread.Start(objArr);
        }

        private void TuketimHesaplaTh(object parameters)
        {
            _optimizasyonList = new List<Optimizasyon>();
            object[] objArr = (object[])parameters;
            List<string> keyList = (List<string>)objArr[0];
            List<short> ihtiyacList = (List<short>)objArr[1];

            int iterasyon = 0;
            if (!int.TryParse(IterasyonText.Text, out iterasyon)) return;

            for (int i = 0; i < iterasyon; i++)
            {
                float yuzde = (float)i / (float)iterasyon * 100f;
                TuketimHesapla(keyList, ihtiyacList.ToList(), (int)yuzde);
            }

            _formLoaded = true;

            lblYuzde.Invoke((MethodInvoker)delegate { lblYuzde.Text = "%100"; });
            progressBarControl1.Invoke((MethodInvoker)delegate { progressBarControl1.Position = 100; });

            _optimizasyonList = _optimizasyonList.OrderBy(d => d.Point).ToList();

            PuanList.Invoke((MethodInvoker)delegate
            {
                PuanList.DataSource = _optimizasyonList;
                PuanList.SelectedIndex = PuanList.Items.Count == 1 ? -1 : PuanList.Items.Count - 1;
            });

            lblYuzde.Invoke((MethodInvoker)delegate { lblYuzde.Text = ""; });
            progressBarControl1.Invoke((MethodInvoker)delegate { progressBarControl1.Position = 0; });

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();

            //_optimizationIsDone = true;
        }

        private void TuketimHesapla(List<string> keyList, List<short> ihtiyacList, int yuzde)
        {
            List<short> sonucList = new List<short>();
            List<short> partiList = new List<short>();
            List<string> pointList = new List<string>();
            foreach (DataRow row in _shAyrintiTable.Rows)
            {
                sonucList.Add(Convert.ToInt16(row["PARTIN"]));
                partiList.Add(Convert.ToInt16(row["PARTIN"]));
                pointList.Add("");
            }

            ihtiyacList = ihtiyacList.OrderBy(a => Guid.NewGuid()).ToList();

            for (int i = ihtiyacList.Count - 1; i > -1; i--)
            {
                short ihtiyacUzunluk = Convert.ToInt16(ihtiyacList[i]);
                for (int k = 0; k < sonucList.Count; k++)
                {
                    short depoUzunluk = Convert.ToInt16(sonucList[k]);
                    if (depoUzunluk >= ihtiyacUzunluk)
                    {
                        sonucList[k] = (short)(depoUzunluk - ihtiyacUzunluk);
                        pointList[k] = (pointList[k] + " " + ihtiyacUzunluk.ToString()).Trim();
                        ihtiyacList.RemoveAt(i);
                        break;
                    }
                }
            }

            int toplamPuan = 0;
            string key = "";

            List<short> orderedList = sonucList.OrderBy(i => i).ToList();
            foreach (short item in orderedList)
            {
                key += item.ToString();
                toplamPuan += SonucuPuanla(item);
            }

            if (!keyList.Contains(key))
            {
                keyList.Add(key);
                Optimizasyon optimizasyon = new Optimizasyon();
                optimizasyon.Point = toplamPuan;
                optimizasyon.ToplamPuan = toplamPuan.ToString();
                optimizasyon.SonucList = sonucList;
                optimizasyon.PointList = pointList;
                optimizasyon.PartiList = partiList;
                _optimizasyonList.Add(optimizasyon);
                //PuanList.Invoke((MethodInvoker)delegate{ PuanList.Items.Add(depoItem); });
            }

            lblYuzde.Invoke((MethodInvoker)delegate { lblYuzde.Text = "%" + yuzde.ToString(); });
            progressBarControl1.Invoke((MethodInvoker)delegate { progressBarControl1.Position = yuzde; });
        }

        private int SonucuPuanla(short boy)
        {
            if (boy <= 9) return 100;

            //quadratic regression. Kalan parça uzunluk puanlaması değişirse grafik denklemi tekrar hesaplanacak.
            const double a = 0.0000270027; //0.1mm --> 1 puan
            const double b = -0.0328522; //2000mm --> 550 puan
            const double c = 0.967148; //6000mm --> 1000 puan

            double sonuc = (a * (boy * boy)) + (b * boy) + c; //ax^2 + bx + c
            return (int)sonuc;

        }

        public void CreateChart(Optimizasyon depoItem)
        {
            try
            {
                DegerCheck.Checked = false;
                DepoChart.Series.Clear();
                DepoChart.DataSource = null;
                _kullanilacakPartiler = new List<ProfilKesimModel>();
                _gerceklesenKesimList = new List<short>();
                List<short> depoKalanList = depoItem.SonucList;
                List<short> partiList = depoItem.PartiList;
                List<string> kesileceklerList = SortPointsList(depoItem.PointList);

                kesilecekTable = new DataTable();
                kesilecekTable.Columns.Add("Satir", typeof(int));
                kesilecekTable.Columns.Add("Sutun", typeof(int));
                kesilecekTable.Columns.Add("Deger", typeof(short));
                kesilecekTable.Columns.Add("Parti", typeof(short));
                kalanTable = kesilecekTable.Clone();

                if (DepoChart.Series["Kalan"] != null) DepoChart.Series.Remove(DepoChart.Series["Kalan"]);
                if (DepoChart.Series["Kesilecek"] != null) DepoChart.Series.Remove(DepoChart.Series["Kesilecek"]);
                DepoChart.Legend.Visibility = DefaultBoolean.False;
                DepoChart.Titles[0].Text = _stokKodu + " - " + _stokAdi;
                DepoChart.CrosshairOptions.ShowValueLabels = true;
                DepoChart.CrosshairOptions.SnapMode = CrosshairSnapMode.NearestArgument;
                DepoChart.AnimationStartMode = ChartAnimationMode.OnLoad;
                DepoChart.SeriesTemplate.View = new StackedBarSeriesView();
                DepoChart.SeriesDataMember = "Sutun";
                DepoChart.SeriesTemplate.ArgumentDataMember = "Satir";
                DepoChart.SeriesTemplate.ValueDataMembers.AddRange("Deger");

                XYDiagram diagram = (XYDiagram)DepoChart.Diagram;
                diagram.AxisX.CustomLabels.Clear();

                KeyColorColorizer colorizer = new KeyColorColorizer { PaletteName = "Default" };
                int satir = 1;

                List<short> kullanilacakStokList = new List<short>();

                //Kesilecek parçaları datatable'a al
                for (int i = 0; i < kesileceklerList.Count; i++)
                {
                    string[] kesilecekArr = kesileceklerList[i].Split();

                    //Hiç dokunulmamış parçaları listeye alma
                    if ((gecmisOptimizasyon != null || !chkTumStok.Checked) && kesilecekArr.Length == 1 && kesilecekArr[0] == "0") continue;

                    short parti = -1;
                    if (gecmisOptimizasyon == null) parti = Convert.ToInt16(_shAyrintiTable.Rows[i]["PARTIN"]);
                    else parti = Convert.ToInt16(partiList[i]);

                    kullanilacakStokList.Add(parti);

                    diagram.AxisX.CustomLabels.Add(new CustomAxisLabel(parti.ToString() + " mm", i));
                    for (int k = 0; k < kesilecekArr.Length; k++)
                    {
                        DataRow row = kesilecekTable.NewRow();
                        row["Satir"] = satir;
                        row["Sutun"] = k + 1; //Sütun no 1'den başlayacak. ToolTip açıklaması için.
                        row["Parti"] = parti;

                        string boyStr = kesilecekArr[k];
                        if (boyStr == "") row["Deger"] = 0;
                        else
                        {
                            short deger = Convert.ToInt16(boyStr);
                            row["Deger"] = deger;
                            if (!colorizer.Keys.Contains(deger)) colorizer.Keys.Add(deger);
                            kesilecekTable.Rows.Add(row);
                            _gerceklesenKesimList.Add(deger);
                        }
                    }

                    DataRow row2 = kalanTable.NewRow();
                    row2["Satir"] = satir;
                    row2["Sutun"] = kesilecekArr.Length;
                    row2["Deger"] = depoKalanList[i];
                    row2["Parti"] = parti;
                    kalanTable.Rows.Add(row2);

                    satir++;
                }

                //Kullanılacak parti sayıları
                var distinctPartiList = kullanilacakStokList.Select(d => d).Distinct().ToList();
                distinctPartiList.ForEach(x =>
                {
                    int count = kullanilacakStokList.Where(s => s == x).Count();
                    _kullanilacakPartiler.Add(new ProfilKesimModel
                    {
                        PARTIN = x.ToString(),
                        GNMKTR = count
                    });
                });

                diagram.Rotated = true;
                diagram.AxisX.Reverse = true;
                diagram.AxisX.WholeRange.Auto = false;
                diagram.AxisX.WholeRange.MinValue = 0d;
                diagram.AxisX.WholeRange.MaxValue = kalanTable.Rows.Count + 1d;
                diagram.AxisX.WholeRange.AutoSideMargins = false;
                diagram.AxisX.WholeRange.SideMarginsValue = 0.1d;
                diagram.AxisX.QualitativeScaleOptions.AutoGrid = false;
                diagram.AxisX.Label.ResolveOverlappingOptions.AllowHide = false;
                diagram.AxisX.LabelVisibilityMode = AxisLabelVisibilityMode.AutoGeneratedAndCustom;
                diagram.AxisX.CustomLabels.Clear();

                diagram.AxisY.WholeRange.Auto = false;
                diagram.AxisY.WholeRange.MinValue = 0;
                diagram.AxisY.WholeRange.MaxValue = 6000;
                diagram.AxisY.WholeRange.AutoSideMargins = false;
                diagram.AxisY.WholeRange.SideMarginsValue = 30d;

                //int rowCount = kesilecekTable.Rows.Count - 1;

                //for (int i = rowCount; i > -1; i--)
                //{
                //    short deger = Convert.ToInt16(kesilecekTable.Rows[i]["Deger"]);
                //    if (deger == 0)
                //    {
                //        int satir = Convert.ToInt32(kesilecekTable.Rows[i]["Satir"]);
                //        kesilecekTable.Rows.RemoveAt(i);

                //        kalanTable.Rows.Cast<DataRow>().Where(
                //            r => Convert.ToInt32(r.ItemArray[0]) == satir).ToList().ForEach(r => r.Delete());
                //    }
                //}

                DepoChart.DataSource = kesilecekTable;

                StackedBarSeriesView seriesView = (StackedBarSeriesView)DepoChart.SeriesTemplate.View;
                seriesView.FillStyle.FillMode = FillMode.Solid;
                seriesView.Border.Color = Color.Gainsboro;
                seriesView.Colorizer = colorizer;
                seriesView.ColorEach = false;
                //DepoChart.SeriesTemplate.ColorDataMember = "Deger";
                DepoChart.SeriesTemplate.CrosshairLabelPattern = "{S} --> {V} mm";

                //Kesilecek parçalar
                //Series seriesKesilecek = new Series("Sutun", ViewType.StackedBar);
                //seriesKesilecek.DataSource = kesilecekTable;

                //seriesKesilecek.ArgumentDataMember = "Satir";
                //seriesKesilecek.ValueDataMembers.AddRange("Deger");
                //seriesKesilecek.CrosshairLabelPattern = "{S} --> {V} mm";
                //seriesKesilecek.ColorDataMember = "Deger";
                //seriesKesilecek.View = new StackedBarSeriesView();

                ////foreach (DataRow row in kesilecekTable.Rows)
                ////{
                ////    int argument = Convert.ToInt32(row["Satir"]);
                ////    short value = Convert.ToInt16(row["Deger"]);

                ////    seriesKesilecek.Points.AddPoint(argument, value);
                ////}

                //StackedBarSeriesView seriesViewKesilecek = (StackedBarSeriesView)seriesKesilecek.View;
                //seriesViewKesilecek.FillStyle.FillMode = FillMode.Solid;
                //seriesViewKesilecek.Border.Color = Color.Gainsboro;
                //seriesViewKesilecek.Colorizer = colorizer;
                //DepoChart.Series.Add(seriesKesilecek);

                //Kalan parçalar
                Series seriesKalan = new Series("Kalan", ViewType.StackedBar);
                seriesKalan.DataSource = kalanTable;
                seriesKalan.ArgumentDataMember = "Satir";
                seriesKalan.ValueDataMembers[0] = "Deger";
                seriesKalan.CrosshairLabelPattern = "Kalan: --> {V} mm";
                seriesKalan.View = new StackedBarSeriesView();

                StackedBarSeriesView seriesViewKalan = (StackedBarSeriesView)seriesKalan.View;
                seriesViewKalan.ColorEach = false;
                seriesViewKalan.FillStyle.FillMode = FillMode.Solid;
                seriesViewKalan.Color = Color.DimGray;
                seriesViewKalan.Border.Color = Color.DimGray;
                DepoChart.Series.Add(seriesKalan);

                DegerCheck.Checked = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("CreateChart - " + ex.ToString());
            }
        }

        private List<string> SortPointsList(List<string> listToSort)
        {
            List<string> sortedList = new List<string>();

            for (int i = 0; i < listToSort.Count; i++)
            {
                string data = listToSort[i];
                var strArr = data.Split(' ');
                int[] intArr = new int[1];

                if (strArr.Length > 1) intArr = Array.ConvertAll(strArr, s => int.Parse(s));
                else if (strArr.Length == 1 && strArr[0] != "") intArr[0] = int.Parse(strArr[0]);

                if (radioButton2.Checked) intArr = intArr.OrderBy(a => a).ToArray();
                if (radioButton1.Checked) intArr = intArr.OrderByDescending(a => a).ToArray();

                strArr = Array.ConvertAll(intArr, s => s.ToString());
                sortedList.Add(string.Join(" ", strArr));
            }

            return sortedList;
        }

        private void DegerCheck_CheckedChanged(object sender, EventArgs e)
        {
            DefaultBoolean dBool = DegerCheck.Checked ? DefaultBoolean.True : DefaultBoolean.False;
            foreach (Series series in DepoChart.Series) series.LabelsVisibility = dBool;
            DepoChart.SeriesTemplate.LabelsVisibility = dBool;
            //DepoChart.ShowRibbonPrintPreview();
        }

        private void lkEdStokKart_EditValueChanged(object sender, EventArgs e)
        {
            DepoChart.DataSource = null;
            DepoChart.Series.Clear();

            GetStok();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gecmisOptimizasyon != null) return;

            Point clientPt = gridControl1.PointToClient(Cursor.Position);
            GridHitInfo hitInfo = gridView1.CalcHitInfo(clientPt);

            if (hitInfo.InRowCell && hitInfo.Column.FieldName == "Sil") return;
            if (!hitInfo.InRowCell) return;

            if (lkEdStokKart.EditValue == null || lkEdStokKart.EditValue == "")
            {
                MessageBox.Show("Stok seçmediniz", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                profilKesimModelBindingSource.DataSource = new List<ProfilKesimModel>();
                lkEdStokKart.ShowPopup();
                return;
            }

            if (gridView1.FocusedRowHandle == GridControl.NewItemRowHandle)
            {
                var data = new ProfilKesimModel();
                data.OLCUKD = "ADT";
                profilKesimModelBindingSource.Add(data);
            }
        }

        private void repositoryItemButtonEdit1_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            if (gecmisOptimizasyon != null) return;

            int rowHandle = gridView1.FocusedRowHandle;
            if (rowHandle > -1) profilKesimModelBindingSource.RemoveCurrent();
        }

        private void PuanList_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_formLoaded)
            {
                List<Optimizasyon> list = PuanList.DataSource as List<Optimizasyon>;

                if (list != null && list.Count > 0 && PuanList.SelectedIndex < 0)
                    PuanList.SelectedIndex = list.Count - 1;
                Optimizasyon optimizasyon = (Optimizasyon)PuanList.SelectedItem;
                if (optimizasyon != null) CreateChart(optimizasyon);
            }
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            PuanList_SelectedIndexChanged(sender, EventArgs.Empty);
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            if (trackBar1.Value == 0)
            {
                DepoChart.Dock = DockStyle.Fill;
                _chartWidth = DepoChart.Width;
                _chartHeight = DepoChart.Height;
            }
            else
            {
                DepoChart.Dock = DockStyle.Top;
                DepoChart.Width = _chartWidth;
                DepoChart.Height = _chartHeight + (50 * trackBar1.Value);
            }
        }

        private void FrmProfilOptimizasyon_Activated(object sender, EventArgs e)
        {
            FrmMain mainForm = this.MdiParent as FrmMain;
            if (mainForm != null)
            {
                mainForm.barModulAdi.Caption = "";
                mainForm.barMenuTag.Caption = "";
                mainForm.barMenuAdi.Caption = "Profil Optimizasyonu";
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            Close();
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            if (sender == null) return;

            DialogResult Mesaj = MessageBox.Show("Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj != DialogResult.Yes) return;

            DepoChart.Series.Clear();
            DepoChart.DataSource = null;
            PuanList.DataSource = null;
            PuanList.Items.Clear();
            profilKesimModelBindingSource.DataSource = null;
            _kullanilacakPartiler = new List<ProfilKesimModel>();

            radioButton1.Checked = true;
            DegerCheck.Checked = false;
            chkTumStok.Checked = false;
        }

        private void btnStokHareket_Click(object sender, EventArgs e)
        {
            if (DepoChart.DataSource == null) return;

            if (kalanTable.Rows.Count == 0)
            {
                MessageBox.Show("Bu optimizasyon için stok hareketleri oluşturuldu.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DialogResult Mesaj = MessageBox.Show("Giriş ve çıkış stok hareketleri oluşturulacak. Emin misiniz?", "Uyarı", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (Mesaj != DialogResult.Yes) return;

            chkTumStok.Checked = false;

            var cikisList = (from dr in kalanTable.AsEnumerable()
                             group dr by new { Parti = dr["Parti"] } into g
                             select new
                             {
                                 Parti = g.Key.Parti,
                                 Miktar = g.Count()
                             }).ToList();

            var girisList = (from dr in kalanTable.AsEnumerable()
                             group dr by new { Parti = dr["Deger"] } into g
                             select new
                             {
                                 Kalan = g.Key.Parti,
                                 Miktar = g.Count()
                             }).ToList();

            //Stok çıkış
            StokHareketModel cikisModel = new StokHareketModel();

            cikisModel.Baslik = new STHBAS()
            {
                ACTIVE = true,
                SIRKID = global.SirketId.Value,
                SLINDI = false,
                STHRTP = 1,
                STFTNO = 6,
                CKDEPO = grdViewStok.GetRowCellDisplayText(0, "DPKODU"),
                BELTRH = DateTime.Now,
                GNACIK = "Kesim optimizasyonu ile stok çıkışı"
            };

            cikisModel.Kalemler = new List<STHRKT>();
            for (int i = 0; i < cikisList.Count; i++)
            {
                STHRKT kalem = new STHRKT
                {
                    ACTIVE = true,
                    SLINDI = false,
                    GRMKTR = cikisList[i].Miktar,
                    GROLBR = grdViewStok.GetRowCellDisplayText(0, "OLCUKD"),
                    PARTIT = true,
                    PARTIN = cikisList[i].Parti.ToString(),
                    SATIRN = i + 1,
                    STKNAM = _stokAdi,
                    STKODU = _stokKodu
                };

                cikisModel.Kalemler.Add(kalem);
            }

            //Optimizasyon kaydı
            Optimizasyon optimizasyon = (Optimizasyon)PuanList.SelectedItem;
            var kesimListesi = profilKesimModelBindingSource.DataSource as List<ProfilKesimModel>;
            optimizasyon.KesimList = kesimListesi;

            short testerePayi = 0;
            short.TryParse(TestereText.Text, out testerePayi);

            optimizasyon.TesterePayi = testerePayi;

            var optimizasyonArr = Bps.Core.Utilities.Converters.Convert.Serialize(optimizasyon);

            cikisModel.Optimizasyon = new STOPTM
            {
                
                ACTIVE = true,
                SLINDI = false,
                OPTMZS = optimizasyonArr,
            };

            // Stok giriş kaydı
            StokHareketModel girisModel = new StokHareketModel();

            girisModel.Baslik = new STHBAS()
            {
                ACTIVE = true,
                SIRKID = global.SirketId.Value,
                SLINDI = false,
                STHRTP = 0,
                STFTNO = 5,
                GRDEPO = grdViewStok.GetRowCellDisplayText(0, "DPKODU"),
                BELTRH = DateTime.Now,
                GNACIK = "Kesim optimizasyonu ile stok girişi"
            };

            girisModel.Kalemler = new List<STHRKT>();
            for (int i = 0; i < girisList.Count; i++)
            {
                if (Convert.ToInt16(girisList[i].Kalan) == 0) continue;

                STHRKT kalem = new STHRKT
                {
                    ACTIVE = true,
                    SLINDI = false,
                    GRMKTR = girisList[i].Miktar,
                    GROLBR = grdViewStok.GetRowCellDisplayText(0, "OLCUKD"),
                    PARTIT = true,
                    PARTIN = girisList[i].Kalan.ToString(),
                    SATIRN = i + 1,
                    STKNAM = _stokAdi,
                    STKODU = _stokKodu
                };

                girisModel.Kalemler.Add(kalem);
            }

            StandardResponse response = _xxService.Ncch_StokGirisCikisByOptimizasyon_Log(cikisModel, girisModel, global, false);

            if (response.Status != ResponseStatusEnum.OK)
            {
                MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            MessageBox.Show(response.Message, "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            kesilecekTable.Clear();
            kalanTable.Clear();

            PuanList.DataSource = null;
            PuanList.Items.Clear();

            GetStok();
        }

        private void btnYazdir_Click(object sender, EventArgs e)
        {
            if (PuanList.SelectedIndex < 0) return;

            Optimizasyon optimizasyon = (Optimizasyon)PuanList.SelectedItem;

            if (gecmisOptimizasyon == null)
            {
                short testerePayi = 0;
                short.TryParse(TestereText.Text, out testerePayi);

                optimizasyon.TesterePayi = testerePayi;
                optimizasyon.KesimList = profilKesimModelBindingSource.DataSource as List<ProfilKesimModel>;
            }

            var kesimList = optimizasyon.KesimList;

            repOptimizasyon repOpt = new repOptimizasyon();

            MemoryStream ms = new MemoryStream();
            DepoChart.SaveToStream(ms);
            ms.Seek(0, SeekOrigin.Begin);
            repOpt.xrOptChart.LoadFromStream(ms);
            (repOpt.xrOptChart as IChartContainer).Chart.Assign((DepoChart as IChartContainer).Chart);
            repOpt.xrOptChart.Titles.Clear();

            repOpt.xrCellStokKodu.Text = _stokKodu;
            repOpt.xrCellStokAdi.Text = _stokAdi;

            int planlananToplam = 0;
            int gerceklesenToplam = 0;

            repOpt.xrTblKesimListesi.BeginInit();
            for (int i = 0; i < kesimList.Count + 1; i++)
            {
                XRTableRow xrRow = new XRTableRow();
                for (int j = 0; j < 3; j++)
                {
                    XRTableCell xRCell = new XRTableCell();

                    if (i < kesimList.Count)
                    {
                        if (j == 0) xRCell.Text = kesimList[i].PARTIN + " mm";
                        if (j == 1)
                        {
                            planlananToplam += kesimList[i].GNMKTR.ToInt32();
                            xRCell.Text = kesimList[i].GNMKTR.ToString("n0") + " Adet";
                        }
                        if (j == 2)
                        {
                            short kesimBoy = Convert.ToInt16(kesimList[i].PARTIN);
                            short testerePayi = 0;
                            short.TryParse(TestereText.Text, out testerePayi);
                            kesimBoy += testerePayi;

                            int gerceklesen = _gerceklesenKesimList.Where(g => g == kesimBoy).Count();
                            gerceklesenToplam += gerceklesen;
                            xRCell.Text = gerceklesen.ToString() + " Adet";
                            if (xRCell.Text != xrRow.Cells[xrRow.Cells.Count - 1].Text) xRCell.ForeColor = Color.Red;
                        }
                    }
                    else
                    {
                        if (j == 0) xRCell.Text = "TOPLAM:";
                        if (j == 1) xRCell.Text = planlananToplam.ToString() + " Adet";
                        if (j == 2) xRCell.Text = gerceklesenToplam.ToString() + " Adet";
                        xRCell.Font = new Font("Tahoma", 12F, FontStyle.Bold);
                    }
                    xrRow.Cells.Add(xRCell);
                }
                repOpt.xrTblKesimListesi.Rows.Add(xrRow);
            }

            repOpt.xrTblKesimListesi.EndInit();

            repOpt.xrTblStokListesi.BeginInit();
            for (int i = 0; i < _kullanilacakPartiler.Count; i++)
            {
                XRTableRow xrRow = new XRTableRow();
                for (int j = 0; j < 2; j++)
                {
                    XRTableCell xRCell = new XRTableCell();
                    if (j == 0) xRCell.Text = _kullanilacakPartiler[i].GNMKTR.ToString("n0") + " Adet";
                    if (j == 1) xRCell.Text = _kullanilacakPartiler[i].PARTIN + " mm";
                    xrRow.Cells.Add(xRCell);
                }
                repOpt.xrTblStokListesi.Rows.Add(xrRow);
            }
            repOpt.xrTblStokListesi.EndInit();

            int yPos = repOpt.xrTblKesimListesi.Location.Y + repOpt.xrTblKesimListesi.Size.Height + 20;
            repOpt.xrTblStokListesi.Location = new Point(repOpt.xrTblStokListesi.Location.X, yPos);

            repOpt.xrOptChart.Location = new Point(repOpt.xrOptChart.Location.X, 127);
            repOpt.xrOptChart.Size = new Size(1250, 910);

            repOpt.ShowRibbonPreviewDialog();

            return;
            PrintingSystem printingSystem1 = new PrintingSystem();
            PrintableComponentLink chartComponent = new PrintableComponentLink();
            chartComponent.Landscape = true;
            chartComponent.Margins = new Margins(5, 5, 5, 5);
            printingSystem1.ShowMarginsWarning = false;
            printingSystem1.Document.AutoFitToPagesWidth = 1;
            printingSystem1.Links.AddRange(new object[] { chartComponent });
            DepoChart.LookAndFeel.UseDefaultLookAndFeel = false;
            chartComponent.Component = DepoChart;
            chartComponent.ShowRibbonPreviewDialog(UserLookAndFeel.Default);
            DepoChart.LookAndFeel.UseDefaultLookAndFeel = true;
        }

        protected override void barYenile_ItemClick(object sender, ItemClickEventArgs e)
        {
            btnTemizle_Click(null, EventArgs.Empty);
            lkEdStokKart.Properties.DataSource = null;
            lkEdStokKart.EditValue = null;
            FrmProfilOptimizasyon_Load(null, EventArgs.Empty);
        }
    }

    [Serializable]
    public class Optimizasyon
    {
        public int Point { get; set; }
        public string ToplamPuan { get; set; }
        public List<short> SonucList { get; set; }
        public short TesterePayi { get; set; }
        public List<string> PointList { get; set; }
        public List<short> PartiList { get; set; }
        public List<ProfilKesimModel> KesimList { get; set; }
        public string BelgeNo { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }

        public override string ToString()
        {
            return ToplamPuan;
        }
    }
}
