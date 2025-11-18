
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
    public partial class FrmOrtamMenu : DevExpress.XtraEditors.XtraForm
    {
        private Global _global;
        private List<GNYETB> sourceList = new List<GNYETB>();
        private List<GNYETB> targetList = new List<GNYETB>();

        private GNYETB _gnyetb;
        public int _yetkiId;
        private readonly IGnthrkService _gnthrkService;
        private readonly IGnyetbService _gnyetbService;


        public FrmOrtamMenu(Global global)
        {

            _global = global;
            _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
            _gnyetbService = InstanceFactory.GetInstance<IGnyetbService>();


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
            List<GNYETB> MenuList = new List<GNYETB>();
            var ortams = _gnyetbService.Cch_GetListYetkiId_NLog(_yetkiId, _global);

            var teknads = new List<string>() { "MENUKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(_global, teknads, false).Items;

            foreach (var item in teknadsResponse)
            {
                MenuList.Add(new GNYETB { MENUKD = item.TIPKOD, MNUTAG = item.HARKOD.ToInt32(), MNUNAM = item.TANIMI,SIRKID = _global.SirketId.ToInt32() ,YetkId =_yetkiId     });
            }

            var list = MenuList;
            list.ForEach(l => sourceList.Add(l));

            gridControl1.DataSource = sourceList;
            grdViewSource.BestFitColumns();

            //var uastrtList = _uastrtService.Ncch_GetListByUrunAgacInfo_NLog(_uragac, _global, false).Items;

            //foreach (UASTRT uastrt in uastrtList)
            //{
            //    var operasyon = sourceList.First(t => t.HARKOD == uastrt.ISOPKD);
            //    targetList.Add(operasyon.DeepCopy());
            //}
            targetList = ortams.Items; 
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

            List<GNYETB> sourceTable = sourceGrid.GridControl.DataSource as List<GNYETB>;

            int[] sourceHandles = e.GetData<int[]>();

            //Point hitPoint = targetGrid.GridControl.PointToClient(Cursor.Position);
            //GridHitInfo hitInfo = targetGrid.CalcHitInfo(hitPoint);

            int targetRowHandle = args.HitInfo.RowHandle; //hitInfo.RowHandle;
            int targetRowIndex = targetGrid.GetDataSourceRowIndex(targetRowHandle);

            List<GNYETB> draggedRows = new List<GNYETB>();
            foreach (int sourceHandle in sourceHandles)
            {
                int oldRowIndex = sourceGrid.GetDataSourceRowIndex(sourceHandle);
                GNYETB oldRow = sourceTable[oldRowIndex];
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
                        GNYETB oldRow = draggedRows[i];
                        GNYETB newRow = oldRow.DeepCopy();
                        targetList.Remove(oldRow);
                        bool varmi = targetList.Any(x => x.MNUTAG == newRow.MNUTAG);
                        if (!varmi) targetList.Insert(newRowIndex, newRow);
                    }

                    break;
                case InsertType.After:
                    newRowIndex = targetRowIndex < sourceHandles[0] ? targetRowIndex + 1 : targetRowIndex;
                    if (newRowIndex < 0) newRowIndex = targetList.Count;
                    for (int i = 0; i < draggedRows.Count; i++)
                    {
                        GNYETB oldRow = draggedRows[i];
                        GNYETB newRow = oldRow.DeepCopy();
                        targetList.Remove(oldRow);
                        bool varmi = targetList.Any(x => x.MNUTAG == newRow.MNUTAG);
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
            using (TransactionScope ts = new TransactionScope())
            {
                try
                {
                    var ortams = _gnyetbService.Cch_GetListYetkiId_NLog(_yetkiId, _global);
                    var deletes = _gnyetbService.Ncch_MultiDelete_Log(ortams.Items, _global);
                    var result = _gnyetbService.Ncch_MultiAdd_Log(targetList, _global);


                    //var operasyonList = targetList.Select(x => x.HARKOD).ToList();

                    //var result = _uastrtService.Ncch_UrunAgacStokRotaKaydet_Log(_uragac, operasyonList, _global, false);

                    if (result.Status == ResponseStatusEnum.OK)
                    {
                        Close();
                        MessageBox.Show("Kaydedildi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show(result.ErrorMessage, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ts.Complete();
                }
                catch (Exception)
                {
                    MessageBox.Show("Hata Oluştu", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
              
                }
                
            }
        }
    }
}