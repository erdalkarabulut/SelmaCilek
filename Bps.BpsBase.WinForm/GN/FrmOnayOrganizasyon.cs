using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.Entities.Constants;
using Bps.BpsBase.Entities.Models.GN;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.BpsBase.Entities.Models.UA;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;
using Bps.Core.Web.Model;
using BPS.Windows.Forms;
using DevExpress.Utils;
using DevExpress.Utils.DragDrop;
using DevExpress.Utils.Menu;
using DevExpress.XtraBars;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using DevExpress.XtraTreeList;
using DevExpress.XtraTreeList.Nodes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Transactions;
using System.Windows.Forms;

namespace BPS.Windows.Forms
{
    public partial class FrmOnayOrganizasyon : BPS.Windows.Base.FrmChildBase
    {

        private IGnthrkService _gnthrkService;
        private IGnyetkService _gnyetkService;
        private ProjeMenuListed yetkiModel;
        private DataSet dataSet = new DataSet();
        private DataTable dt1 = new DataTable();
        private DataTable dt2 = new DataTable();
        private string _action;
        int maxAltId = 0;
        private IGnkullService _gnkullService;
        private IGnorgaService _gnorgaService;

        private static List<OnayOrganizasyonTreeList> list1 = new List<OnayOrganizasyonTreeList>();
        private static List<OnayOrganizasyonTreeList> list2 = new List<OnayOrganizasyonTreeList>();
        ////private static IList<UrunAgaciRevizyonList> listRvList;
        private static IList<GNKULL> list;

        private GNORGA _Gnorga;

        string modulAdi = "";
        string takimAdi = "";
        string modulKodu = "";
        string takimKodu = "";
        int uretimAdet = 1;
        STKART stokTakim;
        STKART stokModul;
        STKART stokPaket;
        STKART stokParca;
        private List<STKART> stokList;
        private Dictionary<int, List<URAGVR>> variantList = new Dictionary<int, List<URAGVR>>();





        public FrmOnayOrganizasyon(
            IGnthrkService gnthrkService, IGnyetkService gnyetkService,
            IGnkullService gnkullService, IGnorgaService gnorgaService)
        {
            InitializeComponent();

            _gnthrkService = gnthrkService;
            _gnyetkService = gnyetkService;
            _gnkullService = gnkullService;
            _gnorgaService = gnorgaService;

            InitProjectsData();
            DragDropManager.Default.DragOver += OnDragOver;
            DragDropManager.Default.DragDrop += OnDragDrop;

            xtraTabControl1.ShowTabHeader = DefaultBoolean.False;
        }

        private void FrmUrunAgac_Load(object sender, EventArgs e)
        {
            yetkiModel = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;

            FormIslemleri.FormYetki2(barManager, yetkiModel);

            var teknads = new List<string>() { "ORGTKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            var organizasyonTanim = teknadsResponse.Items.Where(w => w.TEKNAD == "ORGTKD").ToList();
            gridControl1.DataSource = organizasyonTanim;

        }

        protected override void barEkle_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TxtOrgtkd.Text == "")
            {
                MessageBox.Show("Seçim yapmadan oluşturamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var sonuc = _gnorgaService.Ncch_GetOnayOrganizasyon_NLog(TxtOrgtkd.Text, global).Items;
            if (sonuc.Count > 0)
            {
                MessageBox.Show(LblTanimi.Text + " Daha önce tanımlanmış Değiştir ile girebilirsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            ////variantList = new Dictionary<int, List<URAGVR>>();

            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "insert";
            ListGetir();
            bool organizasyonVar = RefreshTreeList();
            if (!organizasyonVar) return;

            ////var revizyontanimlistP2 = _isrevzService.Cch_GetListByUAModel_NLog(global, false).Items;

            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barDegistir_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TxtOrgtkd.Text == "")
            {
                MessageBox.Show("Seçim yapmadan düzenleyemezsiniz.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }



            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle) return;

            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            _action = "update";


            ListGetir();
            bool organizasyonVar = RefreshTreeList();
            if (!organizasyonVar) return;

            treeList.DataSource = dataSet.Tables[0];
            treeList.ExpandAll();
            treeList.BestFitColumns();
            xtraTabControl1.SelectedTabPage = xtraTabPage2;
        }

        protected override void barKaydet_ItemClick(object sender, ItemClickEventArgs e)
        {
            this.Validate();


            string _Numara = "";
            int _parent = 0;
            List<TreeListNode> _nodes = treeList.GetNodeList();

            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    if (_action == "update")
                    {
                        var sonuc = _gnorgaService.Ncch_DeleteOrganizasyon_NLog(TxtOrgtkd.Text, global);
                        if (sonuc.Status != ResponseStatusEnum.OK)
                        {
                            throw new ArgumentException("Kayıt sırasında hata"); ;
                        }
                    }


                    foreach (TreeListNode node in _nodes)
                    {
                        DataRowView rowView = treeList.GetRow(node.Id) as DataRowView;
                        if (rowView["Orgtkd"].ToString() == "") continue;

                        //MessageBox.Show(rowView["Miktar"].ToString());
                        if (rowView == null)
                            return;
                        if (node.Level != 0)
                        {
                            _parent = node.ParentNode.Id;
                        }
                        else
                        {
                            _parent = node.Id;
                        }

                        StandardResponse<GNORGA> _gnorga = _gnorgaService.Ncch_Add_NLog(new GNORGA()
                        {
                            ORGTKD = rowView["Orgtkd"].ToString(),
                            CHILDD = node.Id,
                            PARENT = _parent,
                            TANIMI = rowView["Tanimi"].ToString(),
                            SEVIYE = Convert.ToInt32(rowView["Seviye"].ToString()),
                            SIRASI = node.Id,
                            KULKOD = rowView["Kulkod"].ToString(),
                            GNNAME = rowView["Gnname"].ToString(),
                            GNSNAM = rowView["Gnsnam"].ToString(),
                            ONYSVY = Convert.ToInt32(rowView["Onysvy"].ToString()),
                            GNONAY = false,
                            GNLONY = Convert.ToBoolean(rowView["Gnlony"]),
                            GNDFON = false,
                            ACTIVE = true
                        }, global);
                    }
                    ts.Complete();
                    MessageBox.Show("Kayıt Tamamlandı ");
                }
                catch (Exception exception)
                {
                    MessageBox.Show("Kayıt Yapılamadı " + exception.GetBaseException().Message);
                }
                finally
                {
                    ts.Dispose();
                    treeList.ClearNodes();
                    treeList.DataSource = null;
                    listBoxControl.DataSource = null;
                    FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                    xtraTabControl1.SelectedTabPage = xtraTabPage1;
                }
            }
        }

        protected override void barSil_ItemClick(object sender, ItemClickEventArgs e)
        {
            if (TxtOrgtkd.Text == "")
            {
                MessageBox.Show("Seçim yapmadan Silme işlemi yapamazsınız.", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            DialogResult Secim;
            Secim = MessageBox.Show("Silmek istediğinizden Eminmisiniz?", "Silme İşlemi", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (Secim == DialogResult.Yes)
            {
                using (TransactionScope ts = new TransactionScope())
                {
                    try
                    {
                        var sonuc = _gnorgaService.Ncch_DeleteOrganizasyon_NLog(TxtOrgtkd.Text, global);
                        if (sonuc.Status != ResponseStatusEnum.OK)
                        {
                            throw new ArgumentException("Kayıt sırasında hata"); ;
                        }

                        ts.Complete();
                        MessageBox.Show("Silme işlemi tamamlandı ");
                    }
                    catch (Exception exception)
                    {
                        MessageBox.Show("Silme işlemi Yapılamadı " + exception.GetBaseException().Message);
                    }
                    finally
                    {
                        ts.Dispose();
                        treeList.ClearNodes();
                        treeList.DataSource = null;
                        listBoxControl.DataSource = null;
                        FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
                        xtraTabControl1.SelectedTabPage = xtraTabPage1;
                    }

                }
            }
        }

        protected override void barVazgec_ItemClick(object sender, ItemClickEventArgs e)
        {
            FormIslemleri.ButonKontrol2(barManager, Convert.ToInt32(e.Item.Tag), yetkiModel);
            treeList.ClearNodes();
            treeList.DataSource = null;
            ////LkEdMlzTuruP2.EditValue = null;
            listBoxControl.DataSource = null;
            bool organizasyonVar = RefreshTreeList();
            if (!organizasyonVar) return;
            //TxtUrunAgacKodu.Text = "";
            //TxtUrunAgacKoduP2.Text = "";
            //LkEdRevizyonNoP2.Properties.DataSource = null;
            //LblRevizyonTextP2.Text = "";
            //LblRevizyonText.Text = "";
            //LkEdRevizyonNoP2.Enabled = true;
            //LkEdUretimYeriKoduP2.Enabled = true;
            //LkEdUAKullanimKoduP2.Enabled = true;
            ////LoadRevizyonLkEd(TxtStokKoduP2.Text);

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



        private void gridView1_Click(object sender, EventArgs e)
        {
            if (gridView1.FocusedRowHandle == GridControl.InvalidRowHandle ||
                gridView1.FocusedRowHandle == GridControl.AutoFilterRowHandle) return;
            gridControl2.DataSource = null;
            gridView12.Columns.Clear();
            if (gridView1.SelectedRowsCount > 0)
            {
                TxtOrgtkdP2.Text = TxtOrgtkd.Text = gridView1.GetFocusedRowCellValue("HARKOD").ToString();
                LblTanimiP2.Text = LblTanimi.Text = gridView1.GetFocusedRowCellValue("TANIMI").ToString();
            }
        }



        private void LkEdUAKullanimKodu_EditValueChanged(object sender, EventArgs e)
        {
            ////LoadRevizyonLkEd(TxtStokKodu.Text);
        }



        private void ListGetir()
        {
            list1.Clear();
            dt1.Clear();
            if (dataSet.Tables.Count > 1) dataSet.Tables.Remove("ListBox");

            ////string malzemeTuru = LkEdMlzTuruP2.EditValue == null ? "" : LkEdMlzTuruP2.EditValue.ToString();
            ////if (malzemeTuru != "")
            ////{
            list = _gnkullService.Cch_GetList_NLog(global, false).Items;

            foreach (var item in list)
            {
                list1.Add(new OnayOrganizasyonTreeList
                {
                    Orgtkd = TxtOrgtkd.Text,
                    Tanimi = LblTanimi.Text,
                    Kulkod = item.KULKOD,
                    Gnname = item.GNNAME,
                    Gnsnam = item.GNSNAM,
                    Onysvy = 1,
                    Gnonay = true,
                    Gnlony = false,
                    Gndfon = false

                });
            }

            dt1 = ListToDataTable<OnayOrganizasyonTreeList>(list1);
            if (dataSet.Tables.Count > 1)
            {
                dataSet.Tables[1].Clear();
            }
            dataSet.Tables.Add(dt1);
            dataSet.Tables[1].TableName = "ListBox";

            listBoxControl.DataSource = dataSet.Tables[1].DefaultView;
            treeList.DataSource = dataSet.Tables[0];
            treeList.ExpandAll();
            treeList.BestFitColumns();
            ////}
        }

        void OnDragDrop(object sender, DragDropEventArgs e)
        {

            if (e.Source == e.Target)
            {
                if (e.Source == treeList)
                {
                    var destNode = GetDestNode(e.Location);
                    TreeList sTree = e.Source as TreeList;

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





        void OnTreeListDrop(DragDropEventArgs e)
        {

            DataTable dataViewtree = treeList.DataSource as DataTable;

            DataView dataView = listBoxControl.DataSource as DataView;
            if (e.Source != e.Target)
            {
                if (dataView == null)
                    return;
            }
            var items = e.GetData<IEnumerable<object>>();
            if (items == null)
                return;
            List<object> _items = new List<object>(items);
            Cursor current = Cursors.No;



            foreach (object item in _items)
            {
                DataRowView rowView = item as DataRowView;
                foreach (DataRow treeitem in dataViewtree.Rows)
                {
                    if (rowView.Row[5].ToString() == treeitem["Kulkod"].ToString())
                    {
                        current = Cursors.No;
                        return;
                    }
                }


            }
            //}

            var destNode = GetDestNode(e.Location);
            int index = CalcDestNodeIndex(e, destNode);


            List<string[]> revList = new List<string[]>();
            ////= GetUARevizyonList();
            ////if (revList.Count == 0) return;

            int revIndex = 0;
            // listBoxControl.BeginUpdate();
            current = Cursors.Hand;

            foreach (object item in _items)
            {
                treeList.BeginUpdate();
                treeList.Selection.UnselectAll();
                DataRowView rowView = item as DataRowView;
                if (index < 0) rowView.Row[4] = destNode == null ? 0 : destNode.Level + 1;
                else rowView.Row[4] = destNode == null ? 0 : destNode.Level;

                //rowView.Row["ParentStokKodu"] = destNode.GetValue("StokKodu");
                ////string altUrunAgaciKodu = (revList[revIndex])[0];
                ////byte fntm = Convert.ToByte((revList[revIndex])[1]);
                ////bool fantom = fntm == 1;
                revIndex++;

                ////rowView.Row["AltUrunAgaciKodu"] = altUrunAgaciKodu;
                ////rowView.Row["FantomKalemi"] = fantom;

                //SetMiktar(rowView);

                TreeListNode node = treeList.AppendNode(rowView.Row.ItemArray, index == -1000 ? destNode : null);
                TreeListNode pNode = node;



                if (index > -1)
                {
                    treeList.MoveNode(node, destNode.ParentNode, true, index++);
                }
                if (e.Action != DragDropActions.Copy)
                    //dataView.Table.Rows.Remove(rowView.Row);
                    treeList.SelectNode(node);
                if (node.ParentNode != null)
                    node.ParentNode.Expand();

                ////variantList.Add(node.Id, new List<URAGVR>());

                treeList.EndUpdate();

            }
            //listBoxControl.EndUpdate();
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
                ////string ff = _node.GetDisplayText("StokKodu");
                _nodelist.SetValue("Seviye", deg1);
                if (_nodelist.HasChildren)
                {
                    deg1 = deg1 + 1;
                    for (int i = 0; i < _nodelist.Nodes.Count; i++)
                    //foreach (TreeListNode _subnode in _nodelist.Nodes)
                    {
                        TreeListNode _subnode = _nodelist.Nodes[i];
                        //string fff = _subnode.GetDisplayText("StokKodu");
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
            if (e.Source == e.Target)

                return;
            e.Default();
            if (e.InsertType == InsertType.None)
                return;
            e.Action = IsCopy(e.KeyState) ? DragDropActions.Copy : DragDropActions.Move;
            Cursor current = Cursors.Hand;
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
            dt2 = ListToDataTable<OnayOrganizasyonTreeList>(list2);

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



        private bool RefreshTreeList()
        {
            if (dataSet.Tables.Contains("ListBox")) dataSet.Tables.Remove("ListBox");
            if (dataSet.Tables.Contains("TreeList")) dataSet.Tables.Remove("TreeList");
            maxAltId = 0;

            if (dt2 != null) dt2.Clear();
            if (_action == "insert") dt2 = ListToDataTable<OnayOrganizasyonTreeList>(list2);
            if (_action == "update")
            {
                dt2 = ListToDataTable(_gnorgaService.Ncch_GetOnayOrganizasyon_NLog(TxtOrgtkd.Text, global).Items);
                if (dt2 == null)
                {
                    MessageBox.Show("Kayıt bulunamadı.", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }


                ////foreach (DataRow row in dt2.Rows)
                ////{
                ////    string stokKodu = row["StokKodu"].ToString();
                ////    string revizyonNo = row["RevizyonNo"].ToString();
                ////    int parentId = Convert.ToInt32(row["AltId"]);
                ////    int seviye = Convert.ToInt32(row["Seviye"]);
                ////    bool fantom = Convert.ToBoolean(row["FantomKalemi"]);

                ////    //if (!fantom) GetUrunAgaciSubLevel(dtSubLevels, stokKodu, revizyonNo, parentId, seviye + 1);
                ////    if (dtSubLevels.Rows.Count > 0) maxAltId = Convert.ToInt32(dtSubLevels.Select("AltId = MAX(AltId)")[0]["AltId"]);
                ////}
                ////dt2.Merge(dtSubLevels);
            }
            dataSet.Tables.Add(dt2);
            dataSet.Tables[0].TableName = "TreeList";
            return true;
        }

        private void GetUrunAgaciSubLevel(DataTable dtSubLevels, string stokKodu, string revizyonNo, int parentId, int seviye)
        {
            ////string uaKodu = _urunAgacStokBaglantiService.Ncch_GetUrunAgaciKodu_NLog(stokKodu, revizyonNo, LkEdUAKullanimKodu.EditValue.ToString(), global).Nesne;
            ////if (uaKodu == null) return;

            DataTable dt = new DataTable();
            ////ListToDataTable(_urunAgaciService.Ncch_GetUrunAgaci_NLog(uaKodu, global).Items);

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
                GetUrunAgaciSubLevel(dtSubLevels, stokKodu, revizyonNo, maxAltId, seviye + 1);
            }
        }

        private void ClearControls()
        {
            ////LkEdRevizyonNo.Properties.DataSource = null;
            ////LkEdRevizyonNoP2.Properties.DataSource = null;
            ////TxtUrunAgacKodu.Text = "";
            ////TxtUrunAgacKoduP2.Text = "";
            ////LblRevizyonText.Text = "";
            ////LblRevizyonTextP2.Text = "";
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            ClearControls();
            ////LoadRevizyonLkEd(gridView1.GetFocusedRowCellDisplayText("STKODU"));
        }



        private void searchControl1_QueryIsSearchColumn(object sender, DevExpress.XtraEditors.QueryIsSearchColumnEventArgs args)
        {
            MessageBox.Show(sender.ToString());
            if (sender.ToString() != "Ship Country") args.IsSearchColumn = false;
        }

        private void radioGroup1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (radioGroup1.SelectedIndex == 0) listBoxControl.DisplayMember = "Gnname";
            else listBoxControl.DisplayMember = "Gnsnam";
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
            if (treeList.FocusedNode.GetDisplayText("Orgtkd") == "") e.Cancel = true;
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            ////if (LkEdMalzTuru.EditValue == null) return;
            ////string malzTuru = LkEdMalzTuru.EditValue.ToString();

            ////if (malzTuru == "100") btnTakimUA.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            ////else btnTakimUA.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            ////if (malzTuru == "100" || malzTuru == "101") btnMalzUA.Visibility = DevExpress.XtraBars.BarItemVisibility.Always;
            ////else btnMalzUA.Visibility = DevExpress.XtraBars.BarItemVisibility.Never;

            popupMenu1.ShowPopup(MousePosition);
        }

        ////private void GetUAAllSubLevels(DataTable table, string uaKodu, string uaKoduField, string uaKullanim, bool onlyParts = true)
        ////{
        ////    DataTable tbl = _urunAgaciService.GetAltUrunAgaci(StaticParams.DefaultConnstr, uaKodu, uaKoduField, uaKullanim, global, onlyParts);
        ////    table.Merge(tbl);

        ////    foreach (DataRow row in tbl.Rows)
        ////    {
        ////        string malzemeTuru = row["MalzemeTuru"].ToString();
        ////        string altUAKodu = row["AltUrunAgaciKodu"].ToString();
        ////        if (malzemeTuru != "100" && malzemeTuru != "101") uaKullanim = "2";
        ////        if (uaKullanim == "2") onlyParts = false;
        ////        else onlyParts = true;
        ////        if (altUAKodu != uaKodu) GetUAAllSubLevels(table, row["AltUrunAgaciKodu"].ToString(), uaKoduField, uaKullanim, onlyParts);
        ////    }

        ////}

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

        ////private void GetModulTakim(string stokKodu, string revizyonNo, string ustMalzemeTuru)
        ////{
        ////    DataTable tbl = _urunAgaciService.GetUrunAgaciUpperLevels(StaticParams.DefaultConnstr, stokKodu, revizyonNo, ustMalzemeTuru, global);
        ////    stokKodu = tbl.Rows[0]["StokKodu"].ToString();
        ////    revizyonNo = tbl.Rows[0]["RevizyonNo"].ToString();
        ////    ustMalzemeTuru = tbl.Rows[0]["UstMalzemeTuru"].ToString();

        ////    if (ustMalzemeTuru == "101")
        ////    {
        ////        STKART stok = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
        ////        takimAdi = stok.STKNAM;
        ////        takimKodu = stok.STKODU;
        ////        GetModulTakim(stokKodu, revizyonNo, ustMalzemeTuru);
        ////    }
        ////    else if (ustMalzemeTuru == "100")
        ////    {
        ////        STKART stok = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
        ////        takimAdi = stok.STKNAM;
        ////        takimKodu = stok.STKODU;
        ////    }
        ////    else GetModulTakim(stokKodu, revizyonNo, ustMalzemeTuru);
        ////}

        ////private void GetPaketParca(string stokKodu, string revizyonNo, string malzemeTuru)
        ////{
        ////    DataTable tbl = _urunAgaciService.GetUrunAgaciUpperLevels(StaticParams.DefaultConnstr, stokKodu, revizyonNo, malzemeTuru, global);
        ////    stokKodu = tbl.Rows[0]["StokKodu"].ToString();
        ////    revizyonNo = tbl.Rows[0]["RevizyonNo"].ToString();
        ////    malzemeTuru = tbl.Rows[0]["MalzemeTuru"].ToString();

        ////    if (malzemeTuru == "102")
        ////    {
        ////        stokPaket = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global).Nesne;
        ////        GetPaketParca(stokKodu, revizyonNo, malzemeTuru);
        ////    }
        ////    else if (malzemeTuru == "103")
        ////    {
        ////        STKART stok = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
        ////        stokParca = _stokKartService.Ncch_GetByStKod_NLog(stokKodu, global, false).Nesne;
        ////    }
        ////    else GetPaketParca(stokKodu, revizyonNo, malzemeTuru);
        ////}

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

        ////private void GetUAAllSubLevelsForReport(DataTable table, string uaKodu, string uaKoduField, string uaKullanim, bool onlyParts = true, bool paketParca = false)
        //// {
        ////     DataTable tbl = _urunAgaciService.GetAltUrunAgaci(StaticParams.DefaultConnstr, uaKodu, uaKoduField, uaKullanim, global, onlyParts, "vwUARapor");
        ////     int startIndex = table.Rows.Count;

        ////     table.Merge(tbl);
        ////     if (table.Columns.Count == 12)
        ////     {
        ////         table.Columns.Add("ToplamMiktar", typeof(decimal));
        ////         table.Columns.Add("TakimKodu", typeof(string));
        ////         table.Columns.Add("TakimAdi", typeof(string));
        ////         table.Columns.Add("ModulKodu", typeof(string));
        ////         table.Columns.Add("ModulAdi", typeof(string));
        ////         table.Columns.Add("PaketKodu", typeof(string));
        ////         table.Columns.Add("PaketAdi", typeof(string));
        ////         table.Columns.Add("ParcaKodu", typeof(string));
        ////         table.Columns.Add("ParcaAdi", typeof(string));
        ////     }

        ////     int count = -1;
        ////     foreach (DataRow row in tbl.Rows)
        ////     {
        ////         count++;

        ////         string stkKodu = row["AltStokKodu"].ToString();
        ////         string malzemeTuru = row["MalzemeTuru"].ToString();
        ////         string altUAKodu = row["AltUrunAgaciKodu"].ToString();
        ////         string ustMalzemeTuru = row["UstMalzemeTuru"].ToString();
        ////         decimal birimMiktar = Convert.ToDecimal(row["BirimMiktar"]);

        ////         if (paketParca)
        ////         {
        ////             if (ustMalzemeTuru == "102" && stokPaket == null)
        ////             {
        ////                 stokPaket = _stokKartService.Ncch_GetByStKod_NLog(stkKodu, global, false).Nesne;
        ////             }
        ////             //string ustStkKodu = row["StokKodu"].ToString();
        ////             //GetPaketParca(ustStkKodu, row["RevizyonNo"].ToString(), ustMalzemeTuru);
        ////         }

        ////         if (malzemeTuru == "103" && (stokParca == null || stkKodu != stokParca.STKODU))
        ////         {
        ////             stokParca = _stokKartService.Ncch_GetByStKod_NLog(stkKodu, global, false).Nesne;
        ////         }

        ////         table.Rows[startIndex + count]["ToplamMiktar"] = birimMiktar * uretimAdet;
        ////         table.Rows[startIndex + count]["TakimKodu"] = stokTakim != null ? stokTakim.STKODU : "";
        ////         table.Rows[startIndex + count]["TakimAdi"] = stokTakim != null ? stokTakim.STKNAM : "";
        ////         table.Rows[startIndex + count]["ModulKodu"] = stokModul != null ? stokModul.STKODU : "";
        ////         table.Rows[startIndex + count]["ModulAdi"] = stokModul != null ? stokModul.STKNAM : "";
        ////         table.Rows[startIndex + count]["PaketKodu"] = stokPaket != null ? stokPaket.STKODU : "";
        ////         table.Rows[startIndex + count]["PaketAdi"] = stokPaket != null ? stokPaket.STKNAM : "";
        ////         if (ustMalzemeTuru == "103")
        ////         {
        ////             table.Rows[startIndex + count]["ParcaKodu"] = stokParca != null ? stokParca.STKODU : "";
        ////             table.Rows[startIndex + count]["ParcaAdi"] = stokParca != null ? stokParca.STKNAM : "";
        ////         }

        ////         if (malzemeTuru != "100" && malzemeTuru != "101") uaKullanim = "2";
        ////         if (uaKullanim == "2") onlyParts = false;
        ////         else onlyParts = true;
        ////         if (altUAKodu != uaKodu) GetUAAllSubLevelsForReport(table, row["AltUrunAgaciKodu"].ToString(), uaKoduField, uaKullanim, onlyParts);
        ////     }

        //// }







        private void searchControl1_QuerySearchParameters(object sender, SearchControlQueryParamsEventArgs e)
        {

        }



        private void treeList_CustomNodeCellEdit(object sender, GetCustomNodeCellEditEventArgs e)
        {
            //if (e.Column.FieldName == "Varyant")
            //{
            //    var rowView = treeList.GetRow(e.Node.Id) as DataRowView;
            //    var k = rowView.Row.ItemArray[6].ToString() + " - " + rowView.Row.ItemArray[7].ToString();
            //    Console.WriteLine(k);
            //    RepositoryItemButtonEdit repBut = e.RepositoryItem as RepositoryItemButtonEdit;
            //    repBut.Buttons[0].Caption = "ff";
            //    var h = e.Node.Id;
            //    var y = 4;
            //}
        }


    }
}
