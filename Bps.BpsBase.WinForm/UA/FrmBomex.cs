using DevExpress.XtraBars;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Windows.Forms;
using Bps.Bomex.Abstract;
using Bps.Bomex.Models;
using Bps.Bomex.Solidworks;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraTreeList.Columns;
using DevExpress.XtraTreeList.Nodes;

namespace BPS.Windows.Forms.UA
{
    public partial class FrmBomex : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public IApp _app;
        int rowHeight = 30;
        int locX = 26;
        int locY = 35;
        private int kullaniciId = -1;
        private string kullaniciAdi = "";
        //frmThumb thumbForm = new frmThumb();
        List<SimpleButton> buttonList = new List<SimpleButton>();
        string server = "";
        public DataTable table = new DataTable();
        private DataTable _uaSumTable;
        public bool srForm = false;
        private Thread thread;
        public delegate void UpdateUIDlg();
        double _totalDelta = 1;
        public delegate void UpdateDataTableDlg(int partCount, int total, int index, DataTable table, string assemblyFile, string partFile, string partName, int miktar, string rota, string partPath);

        public FrmBomex()
        {
            try
            {
                 _app = new SldApp();
                if (!_app.AppIsOpen())
                {
                    MessageBox.Show("Önce programı açın!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                    return;
                }

                InitializeComponent();

                Screen screen = Screen.FromControl(this);
                int x = screen.WorkingArea.X - screen.Bounds.X;
                int y = screen.WorkingArea.Y - screen.Bounds.Y;
                MaximizedBounds = new Rectangle(x, y, screen.WorkingArea.Width, screen.WorkingArea.Height);
                MaximumSize = screen.WorkingArea.Size;
                WindowState = FormWindowState.Maximized;
                barProgress.EditWidth = Width / 4;

                _app.OnSearchResultComplete += _OnSearchResultComplete;
                _app.OnSearchError += _OnSearchError;
                MouseWheel += Form_MouseWheel;

                SetTreeIcons();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FrmBomex_Load(object sender, EventArgs e)
        {
            table.Columns.Add("Sira", typeof(int));
            table.Columns.Add("Thumb", typeof(Image));
            table.Columns.Add("AssemblyFile", typeof(string));
            table.Columns.Add("PartFile", typeof(string));
            table.Columns.Add("PartCode", typeof(string));
            table.Columns.Add("PartName", typeof(string));
            table.Columns.Add("Miktar", typeof(int));
            table.Columns.Add("Rota", typeof(string));
            table.Columns.Add("Path", typeof(string));

            gridParca.DataSource = table;
            //gridViewParca.Columns["Path"].Visible = false;

            //foreach (GridColumn column in gridViewParca.Columns) column.OptionsColumn.AllowEdit = false;

            CheckActiveDocument();
        }

        private void barButBom_ItemClick(object sender, ItemClickEventArgs e)
        {
            BOM();
        }

        private void Form_MouseWheel(object sender, MouseEventArgs e)
        {
            if (ModifierKeys == Keys.Shift)
            {
                _totalDelta = _totalDelta + (double)e.Delta / 1200;
                if (_totalDelta > 1) _totalDelta = 1;
                if (_totalDelta < .1) _totalDelta = .1;
                Opacity = _totalDelta;
            }
        }

        private void _OnSearchResultComplete(object sender, RecursiveEventArgs e)
        {
            int index = gridViewParca.LocateByValue("PartFile", e.SearchResults.PartFile);
            UpdateDataTable(e.SearchResults.PartCount, e.SearchResults.TotalCount, index, table, e.SearchResults.AssemblyFile, 
                e.SearchResults.PartFile, e.SearchResults.PartName, e.SearchResults.Miktar, e.SearchResults.Rota, e.SearchResults.PartPath);
        }

        private void _OnSearchError(object sender, EventArgs e)
        {
            UpdateUI();
        }

        private void SetTreeIcons()
        {
            ImageList iconList = new ImageList();
            iconList.ColorDepth = ColorDepth.Depth32Bit;
            iconList.Images.Add(Properties.Resources.part);
            iconList.Images.Add(Properties.Resources.assembly);
            treeUA.StateImageList = iconList;
        }

        private void CheckActiveDocument()
        {
            DocType docType = _app.GetActiveDocType();
            if (docType == DocType.PartDoc)
            {
            }
            else if (docType == DocType.AssemblyDoc)
            {
                tabMain.SelectedTabPage = pageAssembly;
            }
            else
            {
                barDosyaAdi.Caption = "";
                return;
            }
            barDosyaAdi.Caption = _app.ActiveDocumentPath;
        }

        public void UpdateDataTable(int partCount, int total, int index, DataTable table, string assemblyFile, string partFile, string partName, int miktar, string rota, string partPath)
        {
            if (InvokeRequired)
            {
                UpdateDataTableDlg del = UpdateDataTable;
                Invoke(del, partCount, total, index, table, assemblyFile, partFile, partName, miktar, rota, partPath);
            }
            else
            {
                int sira = table.Rows.Count + 1;
                try
                {
                    if (index < 0)
                    {
                        Image thumb = _app.GetPartThumbnail(partPath);
                        table.Rows.Add(sira, thumb, assemblyFile, partFile, "", partName, 1, rota, partPath);
                    }
                    else table.Rows[index]["Miktar"] = Convert.ToInt16(table.Rows[index]["Miktar"]) + 1;
                }
                catch (Exception ex)
                {
                    partCount = 0;
                    barTamamlanan.Caption = "";
                    MessageBox.Show(ex.Message);

                }

                float yuzde = ((float)partCount / (float)total) * 100;
                barProgress.EditValue = (int)yuzde;
                //barITamamlanan.Caption = partCount.ToString() + "/" + total.ToString();

                if (partCount == total)
                {
                    barTamamlanan.Caption = "Tamamlandı.";
                    foreach (GridColumn gridColumn in gridViewParca.Columns)
                    {
                        if (gridColumn.FieldName == "Thumb") gridColumn.Width = 60;
                        else gridColumn.BestFit();
                    }

                    //ParcaGridView.BestFitColumns();
                    _app.StopRecursiveSearch();

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();

                    _app.UpdateAssembly();

                    ribUrunAgaciGroup.Enabled = true;

                    if (_app.Errors.Count > 0)
                    {
                        List<string> errors = _app.Errors.Distinct().ToList();
                        string errString = "";
                        foreach (var error in errors) errString = errString + error + Environment.NewLine;
                        MessageBox.Show(errString, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                    MessageBox.Show(partCount.ToString() + " parça aktarıldı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    barTamamlanan.Caption = "";
                    barProgress.EditValue = 0;
                    barButBom.Caption = "Parça Listesi Al (BOM)";
                }
            }
        }

        private void UpdateUI()
        {
            if (InvokeRequired)
            {
                UpdateUIDlg delg = UpdateUI;
                Invoke(delg);
            }
            else BOM();
        }

        private void BOM()
        {
            if (InvokeRequired)
            {
                UpdateUIDlg uDlg = BOM;
                uDlg.Invoke();
            }
            else
            {
                if (barButBom.Caption == "Parça Listesi Al (BOM)")
                {
                    _app.FilePaths = new List<string[]>();
                    _app.ThreadCanceled = false;

                    if (_app.GetActiveDocType() != DocType.AssemblyDoc)
                    {
                        MessageBox.Show("Sadece Montaj (*.iam) dosyasıyla işlem yapabilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                    }

                    barButBom.Caption = "İşlemi Durdur";
                    table.Clear();

                    ribUrunAgaciGroup.Enabled = false;

                    _app.UpdateAssembly();
                    _app.StartRecursiveSearch();
                    //loadingForm.close = true;
                }
                else
                {
                    _app.StopRecursiveSearch();
                    Enabled = false;
                    Thread.Sleep(2000);
                    barButBom.Caption = "Parça Listesi Al (BOM)";
                    table.Clear();
                    barProgress.EditValue = 0;
                    barTamamlanan.Caption = "";

                    ribUrunAgaciGroup.Enabled = true;
                    Enabled = true;

                    if (_app.Errors.Count > 0)
                    {
                        List<string> errors = _app.Errors.Distinct().ToList();
                        string errString = "";
                        foreach (var error in errors) errString = errString + error + Environment.NewLine;
                        MessageBox.Show(errString, "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void barButUrunAgac_ItemClick(object sender, ItemClickEventArgs e)
        {
            _app.GetUrunAgaci();
            CreateUrunAgaciTree(_app.UrunAgaciTable);
            tabMain.SelectedTabPage = pageUrunAgaci;
        }

        public void CreateUrunAgaciTree(DataTable uaTable)
        {
            gridParcaSum.DataSource = null;
            gridViewParcaSum.Columns.Clear();
            gridParcaSum.RepositoryItems.Clear();

            treeUA.DataSource = null;
            treeUA.Columns.Clear();
            treeUA.GetStateImage -= TreeUA_GetStateImage;
            treeUA.FocusedNodeChanged -= TreeUA_FocusedNodeChanged;

            if (uaTable.Rows.Count == 0) return;

            treeUA.KeyFieldName = "KeyId";
            treeUA.ParentFieldName = "ParentId";
            treeUA.DataSource = uaTable;
            treeUA.GetStateImage += TreeUA_GetStateImage;
            treeUA.FocusedNodeChanged += TreeUA_FocusedNodeChanged;

            foreach (TreeListColumn col in treeUA.Columns) if (col.FieldName != "Child") col.Visible = false;

            treeUA.Columns["Child"].Caption = "Parça / Montaj";
            treeUA.BestFitColumns();
            treeUA.ExpandAll();

            //CreatePartSumTable(treeUA.Nodes[0]);
        }

        private void TreeUA_GetStateImage(object sender, DevExpress.XtraTreeList.GetStateImageEventArgs e)
        {
            if (Convert.ToBoolean(e.Node.GetValue(treeUA.Columns["Montaj"])))
                e.NodeImageIndex = 1;
            else
                e.NodeImageIndex = 0;
        }

        private void TreeUA_FocusedNodeChanged(object sender, DevExpress.XtraTreeList.FocusedNodeChangedEventArgs e)
        {
            //CreatePartSumTable(e.Node);
        }

        private void CreatePartSumTable(TreeListNode node)
        {
            DataTable parcaTable = new DataTable();
            parcaTable.Columns.Add("Thumb", typeof(Image));
            parcaTable.Columns.Add("Parca", typeof(string));
            parcaTable.Columns.Add("Aciklama", typeof(string));
            parcaTable.Columns.Add("Rota", typeof(string));
            parcaTable.Columns.Add("Miktar", typeof(decimal));
            parcaTable.Columns.Add("Birim", typeof(string));

            GetNodeInfo(node, parcaTable);

            DataTable dt = parcaTable.Clone();
            dt = parcaTable.AsEnumerable()
                .GroupBy(r => new
                {
                    Parca = r.Field<string>("Parca"),
                    Aciklama = r.Field<string>("Aciklama"),
                    Rota = r.Field<string>("Rota"),
                    Birim = r.Field<string>("Birim"),
                })
                .Select(g =>
                {
                    Image thumb = null;

                    DataRow[] foundRows = table.Select("[PartFile] = '" + g.Key.Parca + "'");
                    if (foundRows.Length > 0) thumb = (Image)foundRows[0]["Thumb"];

                    var row = dt.NewRow();

                    row["Thumb"] = thumb;
                    row["Parca"] = g.Key.Parca;
                    row["Aciklama"] = g.Key.Aciklama;
                    row["Rota"] = g.Key.Rota;
                    row["Birim"] = g.Key.Birim;
                    row["Miktar"] = g.Sum(r => (decimal)r["Miktar"]);

                    return row;
                }).CopyToDataTable();

            gridParcaSum.DataSource = null;
            gridViewParcaSum.Columns.Clear();
            gridParcaSum.DataSource = dt;
            gridParcaSum.RepositoryItems.Clear();

            if (gridParcaSum.RepositoryItems.Count == 0)
            {
                RepositoryItemTextEdit textEdit = new RepositoryItemTextEdit();
                textEdit.ContextImageOptions.Image = Properties.Resources.part;
                gridViewParcaSum.Columns["Parca"].ColumnEdit = textEdit;
                gridParcaSum.RepositoryItems.Add(textEdit);
            }

            foreach (GridColumn gridColumn in gridViewParcaSum.Columns)
            {
                if (gridColumn.FieldName == "Thumb") gridColumn.Width = 50;
                else gridColumn.BestFit();
            }

            _uaSumTable = dt;
        }

        private void GetNodeInfo(TreeListNode node, DataTable parcaTable)
        {
            if (node.HasChildren) foreach (TreeListNode n in node.Nodes) GetNodeInfo(n, parcaTable);
            else
            {
                string parca = node.GetDisplayText(treeUA.Columns["Child"]);
                string birim = node.GetDisplayText(treeUA.Columns["Birim"]);

                parcaTable.Rows.Add(null, parca, 1, birim, null, null);
            }
        }

        private void gridViewParca_CellValueChanged(object sender, DevExpress.XtraGrid.Views.Base.CellValueChangedEventArgs e)
        {
            if (e.RowHandle < 0) return;
            string partPath = gridViewParca.GetFocusedRowCellDisplayText("Path");
            string partFile = gridViewParca.GetFocusedRowCellDisplayText("PartFile");
            var found = _app.UrunAgaciTable.Select("[Child] = '" + partFile + "'");

            //if (e.Column.FieldName == "Dummy")
            //{
            //    string dummy = "";
            //    if (e.Value.ToString() == "True") dummy = "DMY";
            //    _app.WriteToCustomProps(partPath, "Dummy", dummy);
            //    foreach (var row in found) row["FisYok"] = e.Value;
            //}
            //else if (e.Column.FieldName == "Siparis")
            //{
            //    string siparis = "";
            //    if (e.Value.ToString() == "True") siparis = "SPR";
            //    _app.WriteToCustomProps(partPath, "Siparis", siparis);
            //    foreach (var row in found) row["Siparis"] = e.Value;
            //}
            //else
            //{
            //    _app.WriteToCustomProps(partPath, e.Column.FieldName, e.Value.ToString());
            //    foreach (var row in found) row[e.Column.FieldName] = e.Value;
            //}

            _app.WriteToCustomProps(partPath, e.Column.FieldName, e.Value.ToString());
            foreach (var row in found) row[e.Column.FieldName] = e.Value;

            gridViewParca.RefreshRow(e.RowHandle);
        }
    }
}