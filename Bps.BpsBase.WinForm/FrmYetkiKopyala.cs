using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.UA;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.Helpers;
using DevExpress.Utils.DragDrop;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraGrid.Views.Grid.ViewInfo;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Transactions;
using System.Windows.Forms;

namespace BPS.Windows.Forms
{
    public partial class FrmYetkiKopyala : DevExpress.XtraEditors.XtraForm
    {
        private Global _global;
        private List<GNTHRK> sourceList = new List<GNTHRK>();
        private List<GNTHRK> targetList = new List<GNTHRK>();


        private GNYETB _gnyetb;
        public int _yetkiId;
        private readonly IGnthrkService _gnthrkService;
        private readonly IGnyetbService _gnyetbService;
        private readonly IGnkullService _gnkullService;
        private readonly IGnyetkService _gnyetkService;


        public FrmYetkiKopyala(Global global)
        {

            _global = global;
            _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
            _gnyetbService = InstanceFactory.GetInstance<IGnyetbService>();
            _gnkullService = InstanceFactory.GetInstance<IGnkullService>();
            _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();


            InitializeComponent();

            DragDropBehavior gridControlBehavior = behaviorManager1.GetBehavior<DragDropBehavior>(grdViewSource);
            gridControlBehavior.DragOver += grdViewSource_Behavior_DragOver;
            gridControlBehavior.DragDrop += grdViewSource_Behavior_DragDrop;

            DragDropBehavior gridControlBehavior2 = behaviorManager1.GetBehavior<DragDropBehavior>(grdViewTarget);
            gridControlBehavior2.DragDrop += grdViewTarget_Behavior_DragDrop;
            gridControlBehavior2.DragOver += grdViewTarget_Behavior_DragOver;
        }

        private void FrmOrtamMenu_Load(object sender, EventArgs e)
        {

            List<GNTHRK> ortams = new List<GNTHRK>();
            var kullResponse = _gnkullService.Ncch_GetOnlyActiveUsers_NLog(_global, false);
            var teknads = new List<string>() { "PROJKD" };
            List<GNTHRK> MenuList = _gnthrkService.Cch_GetListByTeknad(_global, "PROJKD", false).Items;
            LkEdSKullanici.Properties.DataSource = kullResponse.Items;
            LkEdTKullanici.Properties.DataSource = kullResponse.Items;

            var list = MenuList;
            list.ForEach(l => sourceList.Add(l));

            gridControl1.DataSource = sourceList;
            grdViewSource.BestFitColumns();

            targetList = ortams;
            gridControl2.DataSource = targetList;
            grdViewTarget.BestFitColumns();
        }

        private void grdViewSource_Behavior_DragDrop(object sender, DragDropEventArgs e)
        {
            e.Handled = true;
        }

        private void grdViewSource_Behavior_DragOver(object sender, DragOverEventArgs e)
        {
            DragOverGridEventArgs args = DragOverGridEventArgs.GetDragOverGridEventArgs(e);

            e.Action = DragDropActions.Copy;
            e.InsertType = args.InsertType;
            e.InsertIndicatorLocation = args.InsertIndicatorLocation;
            Cursor.Current = args.Cursor;

            args.Handled = true;
        }

        private void grdViewTarget_Behavior_DragOver(object sender, DragOverEventArgs e)
        {
            DragOverGridEventArgs args = DragOverGridEventArgs.GetDragOverGridEventArgs(e);
            if (args.Source as GridView == grdViewSource) e.Action = DragDropActions.Copy;
            else e.Action = DragDropActions.Move;

            e.InsertType = args.InsertType;
            e.InsertIndicatorLocation = args.InsertIndicatorLocation;
            Cursor.Current = args.Cursor;
            args.Handled = true;
        }

        private void grdViewTarget_Behavior_DragDrop(object sender, DragDropEventArgs e)
        {
            var args = DragDropGridEventArgs.GetDragDropGridEventArgs(e);
            GridView targetGrid = e.Target as GridView;
            GridView sourceGrid = e.Source as GridView;

            List<GNTHRK> sourceTable = sourceGrid.GridControl.DataSource as List<GNTHRK>;

            int[] sourceHandles = e.GetData<int[]>();

            //Point hitPoint = targetGrid.GridControl.PointToClient(Cursor.Position);
            //GridHitInfo hitInfo = targetGrid.CalcHitInfo(hitPoint);

            int targetRowHandle = args.HitInfo.RowHandle; //hitInfo.RowHandle;
            int targetRowIndex = targetGrid.GetDataSourceRowIndex(targetRowHandle);

            List<GNTHRK> draggedRows = new List<GNTHRK>();
            foreach (int sourceHandle in sourceHandles)
            {
                int oldRowIndex = sourceGrid.GetDataSourceRowIndex(sourceHandle);
                GNTHRK oldRow = sourceTable[oldRowIndex];
                draggedRows.Add(oldRow);
            }

            int newRowIndex = 0;

            if (e.InsertType == InsertType.None) e.InsertType = InsertType.After;

            switch (e.InsertType)
            {
                case InsertType.Before:
                    newRowIndex = targetRowIndex > sourceHandles[sourceHandles.Length - 1]
                        ? targetRowIndex - 1
                        : targetRowIndex;
                    if (newRowIndex < 0) newRowIndex = targetList.Count;
                    for (int i = draggedRows.Count - 1; i >= 0; i--)
                    {
                        GNTHRK oldRow = draggedRows[i];
                        GNTHRK newRow = oldRow.DeepCopy();
                        targetList.Remove(oldRow);
                        bool varmi = targetList.Any(x => x.HARKOD == newRow.HARKOD);
                        if (!varmi) targetList.Insert(newRowIndex, newRow);
                    }

                    break;
                case InsertType.After:
                    newRowIndex = targetRowIndex < sourceHandles[0] ? targetRowIndex + 1 : targetRowIndex;
                    if (newRowIndex < 0) newRowIndex = targetList.Count;
                    for (int i = 0; i < draggedRows.Count; i++)
                    {
                        GNTHRK oldRow = draggedRows[i];
                        GNTHRK newRow = oldRow.DeepCopy();
                        targetList.Remove(oldRow);
                        bool varmi = targetList.Any(x => x.HARKOD == newRow.HARKOD);
                        if (!varmi) targetList.Insert(newRowIndex, newRow);
                    }

                    break;
                default:
                    newRowIndex = -1;
                    break;
            }

            int insertedIndex = targetGrid.GetRowHandle(newRowIndex);
            targetGrid.FocusedRowHandle = insertedIndex;
            targetGrid.SelectRow(targetGrid.FocusedRowHandle);
            grdViewTarget.BestFitColumns();

            args.Handled = true;
        }

        private void repButSil_ButtonClick(object sender, DevExpress.XtraEditors.Controls.ButtonPressedEventArgs e)
        {
            targetList.RemoveAt(grdViewTarget.FocusedRowHandle);
            grdViewTarget.RefreshData();
            grdViewTarget.BestFitColumns();
        }

        private void butKaydet_Click(object sender, EventArgs e)
        {
            if (LkEdSKullanici.EditValue == null || LkEdSKullanici.EditValue == "")
            {
                MessageBox.Show("Kopyalanacak Kullanıcı seçmelisiniz");
                return;
            }  
            List<GNYETK> sourceYetki = new List<GNYETK>();
            List<GNYETK> targetYetki = new List<GNYETK>();

            var skullanici = LkEdSKullanici.GetSelectedDataRow() as GNKULL;
            var tkullanici = LkEdTKullanici.GetSelectedDataRow() as GNKULL;
            foreach (var t_item in targetList)
            {



                sourceYetki = _gnyetkService.Ncch_GetListByFilter_NLog(_global, skullanici.KULKOD, t_item.HARKOD).Items;
                targetYetki = _gnyetkService.Ncch_GetListByFilter_NLog(_global, tkullanici.KULKOD, t_item.HARKOD).Items;
                foreach (var item in sourceYetki)
                {
                    item.KULKOD = tkullanici.KULKOD;
                }
                var deletes = _gnyetkService.Ncch_MultiDelete_Log(targetYetki, _global);
                var result = _gnyetkService.Ncch_MultiAdd_Log(sourceYetki, _global);




                //if (result.Status == ResponseStatusEnum.OK)
                //{
                //    Close();
                //    MessageBox.Show("Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //}
                //else
                //{
                //    MessageBox.Show(result.ErrorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //}





            }
            Close();
            MessageBox.Show("Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}