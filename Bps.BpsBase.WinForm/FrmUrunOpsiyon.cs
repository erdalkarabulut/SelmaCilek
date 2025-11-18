using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models;
using Bps.Core.GlobalStaticsVariables;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace BPS.Windows.Forms
{
    public partial class FrmUrunOpsiyon : Form
    {
        public int satirNo;
        public Global global;
        public List<UrunOpsiyonModel> opsiyonList = new List<UrunOpsiyonModel>();
        public Dictionary<int, List<UrunOpsiyonModel>> opsiyonDict = new Dictionary<int, List<UrunOpsiyonModel>>();
        public bool standartOpsiyon = false;

        private readonly IStkartService _stokKartService;
        private readonly IGnoptpService _gnoptpService;
        private readonly IGnophrService _gnophrService;
        private readonly IGnthrkService _gnthrkService;

        private STKART _stokKart;
        private Point _labelPoint = new Point(30, 10);
        private Point _lkedPoint = new Point(350, 6);
        private Point _buttonPoint = new Point(615, 6);
        private Point _fiyatTextPoint = new Point(650, 6);
        private Point _dovizComboPoint = new Point(735, 6);
        private List<GNTHRK> _dovizList = new List<GNTHRK>();
        private bool settingCommonCurrency = false;

        public FrmUrunOpsiyon()
        {
            InitializeComponent();
            _stokKartService = InstanceFactory.GetInstance<IStkartService>();
            _gnophrService = InstanceFactory.GetInstance<IGnophrService>();
            _gnoptpService = InstanceFactory.GetInstance<IGnoptpService>();
            _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        }

        private void FrmUrunOpsiyon_Load(object sender, EventArgs e)
        {
            if (standartOpsiyon)
            {
                labelControl4.Visible = false;
                labelControl5.Visible = false;
                labelControl6.Visible = false;
                memoAciklama.Visible = false;
                Width -= 270;
                btnKaydet.Location = new Point(btnKaydet.Location.X - 270, btnKaydet.Location.Y);
            }

            _stokKart = _stokKartService.Ncch_GetByStKod_NLog(lblStokKodu.Text, global).Nesne;

            _dovizList = _gnthrkService.Cch_GetListByTeknad(global, "DVCNKD", false).Items;

            var gnoptpList = _gnoptpService.Ncch_GetListByUstTipKod_NLog(global, _stokKart.UROPTB).Items.OrderBy(u => u.TIPKOD).ToList();

            if (gnoptpList != null)
            {
                int count = 1;
                foreach (var gnoptp in gnoptpList)
                {
                    List<GNOPHR> tipHareketList = _gnophrService.Ncch_GetListByTipKod(global, gnoptp.TIPKOD).Items;
                    CreateControls(count, gnoptp, tipHareketList);
                    count++;
                }
            }

            UrunOpsiyonModel urOpModel = opsiyonList.FirstOrDefault(o => o.TIPKOD == "000" && o.HARKOD == "00");
            if (urOpModel != null) memoAciklama.Text = urOpModel.GNACIK;
        }

        private void CreateControls(int count, GNOPTP gnoptp, List<GNOPHR> tipHareketList)
        {
            GridLookUpEdit gridLookUpEdit = new GridLookUpEdit();
            GridView gridLookUpEditView = new GridView();
            LabelControl labelControl = new LabelControl();
            SimpleButton addButton = new SimpleButton();
            TextEdit fiyatText = new TextEdit();
            ComboBoxEdit dovizCombo = new ComboBoxEdit();
            GridColumn col1 = new GridColumn();
            GridColumn col2 = new GridColumn();

            labelControl.Name = "label" + count.ToString();
            labelControl.Location = _labelPoint;
            labelControl.Size = new Size(75, 16);
            labelControl.TabIndex = 1;
            labelControl.Text = gnoptp.TIPADI + ":";

            col1.Caption = "Kod";
            col1.FieldName = "HARKOD";
            col1.MaxWidth = 40;
            col1.Visible = true;
            col1.VisibleIndex = 0;

            col2.Caption = "Tanım";
            col2.FieldName = "TANIMI";
            col2.Visible = true;
            col2.VisibleIndex = 1;

            WindowsFormsSettings.SmartMouseWheelProcessing = false;

            gridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
                col1,
                col2});
            gridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            gridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
            gridLookUpEditView.OptionsView.ShowGroupPanel = false;

            gridLookUpEdit.Name = "lked" + count.ToString();
            gridLookUpEdit.AccessibleName = count.ToString();
            gridLookUpEdit.Location = _lkedPoint;
            gridLookUpEdit.Properties.AllowMouseWheel = false;
            gridLookUpEdit.Properties.DisplayMember = "TANIMI";
            gridLookUpEdit.Properties.NullText = "";
            gridLookUpEdit.Properties.PopupView = gridLookUpEditView;
            gridLookUpEdit.Properties.ValueMember = "HARKOD";
            gridLookUpEdit.Properties.DataSource = tipHareketList;
            gridLookUpEdit.Size = new Size(263, 22);
            gridLookUpEdit.Tag = gnoptp.TIPKOD;
            gridLookUpEdit.EditValueChanged += GridLookUpEdit_EditValueChanged;
            //gridLookUpEdit.EditValue = tipHareketList[0].HARKOD;

            addButton.Name = "button" + count.ToString();
            addButton.ImageOptions.Image = DevExpress.Images.ImageResourceCache.Default.GetImage("images/actions/add_16x16.png");
            addButton.Location = _buttonPoint;
            addButton.Size = new Size(22, 20);
            addButton.Click += AddButton_Click;

            xtraScrollableControl1.Controls.Add(labelControl);
            xtraScrollableControl1.Controls.Add(gridLookUpEdit);
            xtraScrollableControl1.Controls.Add(addButton);

            if (!standartOpsiyon)
            {
                fiyatText.Name = "fiyatText" + count.ToString();
                fiyatText.Location = _fiyatTextPoint;
                fiyatText.Size = new Size(75, 20);
                //fiyatText.Text = "420,3";

                foreach (var doviz in _dovizList) dovizCombo.Properties.Items.Add(doviz.HARKOD);
                dovizCombo.Name = "dovizCombo" + count.ToString();
                dovizCombo.Location = _dovizComboPoint;
                dovizCombo.Properties.TextEditStyle = DevExpress.XtraEditors.Controls.TextEditStyles.DisableTextEditor;
                dovizCombo.Size = new Size(75, 20);
                dovizCombo.SelectedIndexChanged += DovizCombo_SelectedIndexChanged;
                //dovizCombo.Text = "TRY";

                xtraScrollableControl1.Controls.Add(fiyatText);
                xtraScrollableControl1.Controls.Add(dovizCombo);
            }

            if (opsiyonList.Count > 0)
            {
                UrunOpsiyonModel urOpModel = opsiyonList.FirstOrDefault(o => o.TIPKOD == gnoptp.TIPKOD);
                if (urOpModel != null)
                {
                    gridLookUpEdit.EditValue = urOpModel.HARKOD;
                    if (!standartOpsiyon)
                    {
                        fiyatText.Text = urOpModel.GFIYAT.HasValue ? urOpModel.GFIYAT.Value.ToString() : "0";
                        dovizCombo.Text = urOpModel.DVCNKD;
                    }

                }
            }

            _labelPoint.Y += 30;
            _lkedPoint.Y += 30;
            _buttonPoint.Y += 30;
            _fiyatTextPoint.Y += 30;
            _dovizComboPoint.Y += 30;
        }

        private void DovizCombo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (settingCommonCurrency) return;
            if (ModifierKeys.ToString() == "Shift")
            {
                Control combo = sender as Control;

                settingCommonCurrency = true;
                foreach (Control control in xtraScrollableControl1.Controls)
                {
                    if (control is ComboBoxEdit && control != combo)
                    {
                        control.Text = combo.Text;
                    }
                }
                settingCommonCurrency = false;
            }
        }

        private void GridLookUpEdit_EditValueChanged(object sender, EventArgs e)
        {
            if (standartOpsiyon) return;
            GridLookUpEdit lked = sender as GridLookUpEdit;
            string count = lked.AccessibleName;
            if (lked.EditValue == null || lked.EditValue.ToString() == "")
            {
                xtraScrollableControl1.Controls["fiyatText" + count].Text = "0";
                xtraScrollableControl1.Controls["dovizCombo" + count].Text = "";
            }
            else
            {
                var gnophr = lked.GetSelectedDataRow() as GNOPHR;
                xtraScrollableControl1.Controls["fiyatText" + count].Text = gnophr.GFIYAT.HasValue ? gnophr.GFIYAT.ToString() : "";
                xtraScrollableControl1.Controls["dovizCombo" + count].Text = gnophr.DVCNKD;
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            SimpleButton button = (SimpleButton)sender;
            string order = button.Name.Substring(6);

            var lked = (GridLookUpEdit)xtraScrollableControl1.Controls["lked" + order];
            List<GNOPHR> gnophrList = lked.Properties.DataSource as List<GNOPHR>;
            string harkod = gnophrList.Max(g => g.HARKOD);
            GNOPHR lastGnophr = gnophrList.FirstOrDefault(g => g.HARKOD == harkod);

            FrmYeniOpsiyon yForm = new FrmYeniOpsiyon(global, lastGnophr);
            yForm.Text = ((LabelControl)xtraScrollableControl1.Controls["label" + order]).Text;
            yForm.ShowDialog();

            if (yForm.addedGnophr != null)
            {
                gnophrList.Add(yForm.addedGnophr);
                lked.Properties.DataSource = gnophrList;
            }
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            opsiyonList = new List<UrunOpsiyonModel>();

            int count = xtraScrollableControl1.Controls.Count / 5;
            if (standartOpsiyon) count = xtraScrollableControl1.Controls.Count / 3;
            for (int i = 1; i <= count; i++)
            {
                UrunOpsiyonModel urOpModel = new UrunOpsiyonModel
                {
                    SATIRN = satirNo,
                    STKODU = lblStokKodu.Text,
                    STKNAM = lblStokAdi.Text,
                };

                var lked = (GridLookUpEdit)xtraScrollableControl1.Controls["lked" + i.ToString()];
                if (lked.EditValue == null)
                {
                    opsiyonList = new List<UrunOpsiyonModel>();
                    MessageBox.Show("Lütfen tüm alanları doldurun.", "Uyarı", MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                    return;
                }

                urOpModel.TIPKOD = lked.Tag.ToString();
                urOpModel.HARKOD = lked.EditValue == null ? "" : lked.EditValue.ToString();

                if (!standartOpsiyon)
                {
                    decimal fiyat = 0;
                    var textEdit = (TextEdit)xtraScrollableControl1.Controls["fiyatText" + i.ToString()];
                    decimal.TryParse(textEdit.Text, out fiyat);
                    urOpModel.GFIYAT = fiyat;

                    var combo = (ComboBoxEdit)xtraScrollableControl1.Controls["dovizCombo" + i.ToString()];
                    urOpModel.DVCNKD = combo.Text;
                }

                opsiyonList.Add(urOpModel);
            }

            if (!standartOpsiyon)
            {
                UrunOpsiyonModel urOpAciklama = new UrunOpsiyonModel
                {
                    SATIRN = satirNo,
                    STKODU = lblStokKodu.Text,
                    STKNAM = lblStokAdi.Text,
                    TIPKOD = "000",
                    HARKOD = "00",
                    GNACIK = memoAciklama.Text,
                };
                opsiyonList.Add(urOpAciklama);
            }

            opsiyonDict = new Dictionary<int, List<UrunOpsiyonModel>>();
            opsiyonDict.Add(satirNo, opsiyonList);

            Close();
        }
    }
}
