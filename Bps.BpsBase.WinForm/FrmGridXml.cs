using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Transactions;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Utilities.WinForm;
using Exception = System.Exception;

namespace BPS.Windows.Forms
{
    public partial class FrmGridXml : Form
    {
        public Global global;
        private IGnkxmlService _sinifService;
        private GNKXML _sinif;
        private static IList<dynamic> list;
        private BindingList<dynamic> bindingList;
        List<Grid> focusedRowHandler = new List<Grid>();
        public string _kullaniciId;
        public string _moduladi;
        public string _menutag;
        public string _gridtag;
        public string _xml;
        public string _secilenXml;

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        protected override void WndProc(ref Message m)
        {
            const UInt32 WM_NCHITTEST = 0x0084;
            const UInt32 WM_MOUSEMOVE = 0x0200;

            const UInt32 HTLEFT = 10;
            const UInt32 HTRIGHT = 11;
            const UInt32 HTBOTTOMRIGHT = 17;
            const UInt32 HTBOTTOM = 15;
            const UInt32 HTBOTTOMLEFT = 16;
            const UInt32 HTTOP = 12;
            const UInt32 HTTOPLEFT = 13;
            const UInt32 HTTOPRIGHT = 14;

            const int RESIZE_HANDLE_SIZE = 10;
            bool handled = false;
            if (m.Msg == WM_NCHITTEST || m.Msg == WM_MOUSEMOVE)
            {
                Size formSize = this.Size;
                Point screenPoint = new Point(m.LParam.ToInt32());
                Point clientPoint = this.PointToClient(screenPoint);

                Dictionary<UInt32, Rectangle> boxes = new Dictionary<UInt32, Rectangle>() {
        {HTBOTTOMLEFT, new Rectangle(0, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
        {HTBOTTOM, new Rectangle(RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
        {HTBOTTOMRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, formSize.Height - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE)},
        {HTRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE)},
        {HTTOPRIGHT, new Rectangle(formSize.Width - RESIZE_HANDLE_SIZE, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
        {HTTOP, new Rectangle(RESIZE_HANDLE_SIZE, 0, formSize.Width - 2*RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
        {HTTOPLEFT, new Rectangle(0, 0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE) },
        {HTLEFT, new Rectangle(0, RESIZE_HANDLE_SIZE, RESIZE_HANDLE_SIZE, formSize.Height - 2*RESIZE_HANDLE_SIZE) }
            };

                foreach (KeyValuePair<UInt32, Rectangle> hitBox in boxes)
                {
                    if (this.WindowState != FormWindowState.Maximized
                        && hitBox.Value.Contains(clientPoint))
                    {
                        m.Result = (IntPtr)hitBox.Key;
                        handled = true;
                        break;
                    }
                }
            }

            if (!handled)
                base.WndProc(ref m);
        }

        public FrmGridXml(Global _global)
        {
            InitializeComponent();
            _sinifService = InstanceFactory.GetInstance<IGnkxmlService>();
            global = _global;
        }

        private void TemplateForm_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            list = _sinifService.Ncch_GetSpecificColumnsWhere_NLog(global.UserKod, _moduladi, global.MenuTag.Value, Convert.ToInt32(_gridtag), global).Items;
            bindingList = new BindingList<dynamic>(list);
            gridControl1.DataSource = bindingList;
        }

        #region Visual Elements

        bool _mouseLButtonHold = false;
        private void MovePane_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Dock == DockStyle.Fill) return;
            if (e.Button == MouseButtons.Left)
            {
                _mouseLButtonHold = true;
                this.Dock = DockStyle.None;
            }
        }

        private void MovePane_MouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseLButtonHold)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void MovePane_MouseUp(object sender, MouseEventArgs e)
        {
            _mouseLButtonHold = false;
            this.MdiParent.Refresh();
        }

        private void CloseNavBut_ElementClick(object sender, DevExpress.XtraBars.Navigation.NavElementEventArgs e)
        {
            this.Close();
        }

        #endregion

        public string tip;

        private void gridView1_DoubleClick(object sender, EventArgs e)
        {
            _sinif = _sinifService.Ncch_GetBy_NLog(global.UserKod, _moduladi, global.MenuTag.Value,
                Convert.ToInt32(_gridtag), gridView1.GetFocusedRowCellValue("Tanim").ToString(), global).Nesne;
            this.Tag = _sinif.GRDXML;
            this.Close();
        }

        private void gridView1_Click(object sender, EventArgs e)
        {
            txtTanim.Text = gridView1.GetFocusedRowCellValue("Tanim").ToString();
            if (gridView1.GetFocusedRowCellValue("Aktif") != null)
                chkVarsayilan.Checked = Convert.ToBoolean(gridView1.GetFocusedRowCellValue("Aktif").ToString());
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            if (txtTanim.Text == "") return;
            _sinif = _sinifService.Ncch_GetBy_NLog(global.UserKod, _moduladi, global.MenuTag.Value, Convert.ToInt32(_gridtag), txtTanim.Text, global).Nesne;

            if (_sinif == null)
            {
                tip = "Insert";
            }
            else
            {
                tip = "Update";
            }

            if (chkVarsayilan.Checked)
            {
                _sinif.VARSAY = true;
            }
            else if (tip == "Update")
            {
                _sinifService.Ncch_Update_Log(_sinif, _sinif, global);
            }

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    if (tip == "Insert")
                    {
                        _sinifService.Ncch_Add_NLog(new GNKXML()
                        {

                            KULKOD = global.UserKod,
                            MNUNAM = _moduladi,
                            MNUTAG = Convert.ToInt32(_menutag),
                            GRDTAG = Convert.ToInt32(_gridtag),
                            GRDTXT = txtTanim.Text,
                            VARSAY = chkVarsayilan.Checked,
                            GRDXML = _xml,
                            ACTIVE = true
                        }, global);
                    }

                    if (tip == "Update")
                    {
                        _sinifService.Ncch_Update_Log(new GNKXML
                        {
                            Id = _sinif.Id,
                            KULKOD = global.UserKod,
                            MNUNAM = _moduladi,
                            MNUTAG = Convert.ToInt32(_menutag),
                            GRDTAG = Convert.ToInt32(_gridtag),
                            GRDTXT = txtTanim.Text,
                            VARSAY = chkVarsayilan.Checked,
                            GRDXML = _xml,
                            ACTIVE = true,
                        }, new GNKXML
                        {
                            Id = _sinif.Id,
                            KULKOD = global.UserKod,
                            MNUNAM = _moduladi,
                            MNUTAG = Convert.ToInt32(_menutag),
                            GRDTAG = Convert.ToInt32(_gridtag),
                            GRDTXT = txtTanim.Text,
                            VARSAY = chkVarsayilan.Checked,
                            GRDXML = _xml,
                            ACTIVE = true
                        },global);
                    }

                    ts.Complete();
                    gridView1.RefreshData();
                    MessageBox.Show("Yerleşim Kaydedildi");

                }
                catch (Exception exception)
                {
                    MessageBox.Show("Kayıt Yapılamadı " + exception.Message);

                }
                finally
                {
                    ts.Dispose();
                    LoadData();
                }
            }
        }

        private void btnVazgec_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}