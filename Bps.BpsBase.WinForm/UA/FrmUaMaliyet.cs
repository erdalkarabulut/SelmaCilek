using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Models.GN.Enums;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using DevExpress.XtraGrid;

namespace BPS.Windows.Forms.UA
{
    public partial class FrmUaMaliyet : Form
    {
        public Global global;
        public List<DOVKUR> dovizList = new List<DOVKUR>();

        private FrmUrunAgaci _uaForm;

        public FrmUaMaliyet(FrmUrunAgaci uaForm)
        {
            _uaForm = uaForm;
            InitializeComponent();
        }

        private void FrmUaMaliyet_Load(object sender, EventArgs e)
        {
            SetDovizKur(KurHesapEnum.DovizSatis);
        }

        private void SetDovizKur(KurHesapEnum kurHesaplamaYontemi)
        {
            foreach (DOVKUR dovkur in dovizList)
            {
                if (dovkur.DVCNKD == "USD") txtUsd.Text = dovkur.DVFYT2.Value.ToString("N4");
                else if (dovkur.DVCNKD == "EUR") txtEur.Text = dovkur.DVFYT2.Value.ToString("N4");

                if (dovkur.DVCNKD == "USD")
                {
                    if (kurHesaplamaYontemi == KurHesapEnum.DovizAlis) txtUsd.Text = ((decimal)dovkur.DVFYT1).ToString("N4");
                    if (kurHesaplamaYontemi == KurHesapEnum.DovizSatis) txtUsd.Text = ((decimal)dovkur.DVFYT2).ToString("N4");
                    if (kurHesaplamaYontemi == KurHesapEnum.EfektifAlis) txtUsd.Text = ((decimal)dovkur.DVFYT3).ToString("N4");
                    if (kurHesaplamaYontemi == KurHesapEnum.EfektifSatis) txtUsd.Text = ((decimal)dovkur.DVFYT4).ToString("N4");
                }
                else if (dovkur.DVCNKD == "EUR")
                {
                    if (kurHesaplamaYontemi == KurHesapEnum.DovizAlis) txtEur.Text = ((decimal)dovkur.DVFYT1).ToString("N4");
                    if (kurHesaplamaYontemi == KurHesapEnum.DovizSatis) txtEur.Text = ((decimal)dovkur.DVFYT2).ToString("N4");
                    if (kurHesaplamaYontemi == KurHesapEnum.EfektifAlis) txtEur.Text = ((decimal)dovkur.DVFYT3).ToString("N4");
                    if (kurHesaplamaYontemi == KurHesapEnum.EfektifSatis) txtEur.Text = ((decimal)dovkur.DVFYT4).ToString("N4");
                }

                dateEdit1.DateTime = dovkur.DOVTRH;
            }
        }

        private void barButExcel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (gridView1.RowCount == 0) return;
            string filePath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + this.Text + " - Maliyet.xlsx";
            gridView1.ExportToXlsx(filePath);
            Process.Start(filePath);
        }

        private void gridView1_PopupMenuShowing(object sender, DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventArgs e)
        {
            popContext.ShowPopup(MousePosition);
        }

        private void cmbAlisSatis_SelectedIndexChanged(object sender, EventArgs e)
        {
            KurHesapEnum kurHesap = KurHesapEnum.DovizSatis;

            if (cmbAlisSatis.Text == "ALIŞ") kurHesap = KurHesapEnum.DovizAlis;
            if (cmbAlisSatis.Text == "SATIS") kurHesap = KurHesapEnum.DovizSatis;
            if (cmbAlisSatis.Text == "EFEKTİF ALIŞ") kurHesap = KurHesapEnum.EfektifAlis;
            if (cmbAlisSatis.Text == "EFEKTİF SATIŞ") kurHesap = KurHesapEnum.EfektifSatis;

            DataTable urunAgaciTable = _uaForm.UAMaliyetHesapla(kurHesap, out dovizList);

            gridControl1.DataSource = urunAgaciTable;

            //GridColumnSummaryItem item1 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "Tutar", "{0:n2}");
            //GridColumnSummaryItem item2 = new GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TutarTL", "{0:n2}");
            //uForm.gridView1.Columns["Tutar"].Summary.Add(item1);
            //uForm.gridView1.Columns["TutarTL"].Summary.Add(item2);

            gridView1.BestFitColumns();

            SetDovizKur(kurHesap);
        }
    }
}
