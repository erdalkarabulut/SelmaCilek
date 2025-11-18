
namespace BPS.Windows.Forms
{
    partial class FrmRevizyonTanim
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colRevizyonNo = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colRevizyonText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colBaslangicTarih = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repositoryItemDateEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemDateEdit();
            this.colEtkin = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUretimOnay = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSilme = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYaratmaTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colYaratanKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repYaratmaadiLkUp = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcol1KullaniciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDegisiklikTarihi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDegistirenKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repDegistirenAdiLkUp = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcol2KullaniciAdi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repYaratmaSaatTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            this.repDegisiklikSaatiTimeEdit = new DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaadiLkUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegistirenAdiLkUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaSaatTimeEdit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegisiklikSaatiTimeEdit)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repYaratmaSaatTimeEdit,
            this.repDegisiklikSaatiTimeEdit,
            this.repYaratmaadiLkUp,
            this.repDegistirenAdiLkUp,
            this.repositoryItemDateEdit1});
            this.gridControl1.Size = new System.Drawing.Size(957, 419);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colRevizyonNo,
            this.colRevizyonText,
            this.colBaslangicTarih,
            this.colEtkin,
            this.colUretimOnay,
            this.colSilme,
            this.colYaratmaTarihi,
            this.colYaratanKodu,
            this.colDegisiklikTarihi,
            this.colDegistirenKodu});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.InitNewRow += new DevExpress.XtraGrid.Views.Grid.InitNewRowEventHandler(this.gridView1_InitNewRow);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // colRevizyonNo
            // 
            this.colRevizyonNo.Caption = "Revizyon No";
            this.colRevizyonNo.FieldName = "GNREZV";
            this.colRevizyonNo.Name = "colRevizyonNo";
            this.colRevizyonNo.OptionsColumn.AllowEdit = false;
            this.colRevizyonNo.OptionsColumn.AllowFocus = false;
            this.colRevizyonNo.Visible = true;
            this.colRevizyonNo.VisibleIndex = 0;
            this.colRevizyonNo.Width = 81;
            // 
            // colRevizyonText
            // 
            this.colRevizyonText.Caption = "Revizyon Tanımı";
            this.colRevizyonText.FieldName = "TANIMI";
            this.colRevizyonText.Name = "colRevizyonText";
            this.colRevizyonText.Visible = true;
            this.colRevizyonText.VisibleIndex = 1;
            this.colRevizyonText.Width = 91;
            // 
            // colBaslangicTarih
            // 
            this.colBaslangicTarih.Caption = "Başlangıç Tarihi";
            this.colBaslangicTarih.ColumnEdit = this.repositoryItemDateEdit1;
            this.colBaslangicTarih.FieldName = "BASTAR";
            this.colBaslangicTarih.Name = "colBaslangicTarih";
            this.colBaslangicTarih.Visible = true;
            this.colBaslangicTarih.VisibleIndex = 2;
            this.colBaslangicTarih.Width = 129;
            // 
            // repositoryItemDateEdit1
            // 
            this.repositoryItemDateEdit1.AutoHeight = false;
            this.repositoryItemDateEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repositoryItemDateEdit1.Name = "repositoryItemDateEdit1";
            this.repositoryItemDateEdit1.TodayDate = new System.DateTime(2019, 3, 15, 20, 29, 8, 0);
            // 
            // colEtkin
            // 
            this.colEtkin.Caption = "Etkin";
            this.colEtkin.FieldName = "ACTIVE";
            this.colEtkin.Name = "colEtkin";
            this.colEtkin.Visible = true;
            this.colEtkin.VisibleIndex = 3;
            this.colEtkin.Width = 52;
            // 
            // colUretimOnay
            // 
            this.colUretimOnay.Caption = "Üretim Onay";
            this.colUretimOnay.FieldName = "URTONY";
            this.colUretimOnay.Name = "colUretimOnay";
            this.colUretimOnay.Visible = true;
            this.colUretimOnay.VisibleIndex = 4;
            this.colUretimOnay.Width = 72;
            // 
            // colSilme
            // 
            this.colSilme.Caption = "Silindi";
            this.colSilme.FieldName = "SLINDI";
            this.colSilme.Name = "colSilme";
            this.colSilme.Visible = true;
            this.colSilme.VisibleIndex = 5;
            this.colSilme.Width = 49;
            // 
            // colYaratmaTarihi
            // 
            this.colYaratmaTarihi.Caption = "Oluşturma Tarihi";
            this.colYaratmaTarihi.FieldName = "ETARIH";
            this.colYaratmaTarihi.Name = "colYaratmaTarihi";
            this.colYaratmaTarihi.OptionsColumn.AllowEdit = false;
            this.colYaratmaTarihi.OptionsColumn.AllowFocus = false;
            this.colYaratmaTarihi.Visible = true;
            this.colYaratmaTarihi.VisibleIndex = 6;
            this.colYaratmaTarihi.Width = 49;
            // 
            // colYaratanKodu
            // 
            this.colYaratanKodu.Caption = "Oluşturan";
            this.colYaratanKodu.ColumnEdit = this.repYaratmaadiLkUp;
            this.colYaratanKodu.FieldName = "EKKULL";
            this.colYaratanKodu.Name = "colYaratanKodu";
            this.colYaratanKodu.OptionsColumn.AllowEdit = false;
            this.colYaratanKodu.OptionsColumn.AllowFocus = false;
            this.colYaratanKodu.Visible = true;
            this.colYaratanKodu.VisibleIndex = 7;
            this.colYaratanKodu.Width = 49;
            // 
            // repYaratmaadiLkUp
            // 
            this.repYaratmaadiLkUp.AutoHeight = false;
            this.repYaratmaadiLkUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repYaratmaadiLkUp.DisplayMember = "KullaniciAdi";
            this.repYaratmaadiLkUp.Name = "repYaratmaadiLkUp";
            this.repYaratmaadiLkUp.NullText = "";
            this.repYaratmaadiLkUp.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repYaratmaadiLkUp.ValueMember = "Id";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repcol1KullaniciAdi});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repcol1KullaniciAdi
            // 
            this.repcol1KullaniciAdi.Caption = "Kullanici Adi";
            this.repcol1KullaniciAdi.FieldName = "KullaniciAdi";
            this.repcol1KullaniciAdi.Name = "repcol1KullaniciAdi";
            this.repcol1KullaniciAdi.Visible = true;
            this.repcol1KullaniciAdi.VisibleIndex = 0;
            // 
            // colDegisiklikTarihi
            // 
            this.colDegisiklikTarihi.Caption = "Değişiklik Tarihi";
            this.colDegisiklikTarihi.FieldName = "DTARIH";
            this.colDegisiklikTarihi.Name = "colDegisiklikTarihi";
            this.colDegisiklikTarihi.OptionsColumn.AllowEdit = false;
            this.colDegisiklikTarihi.OptionsColumn.AllowFocus = false;
            this.colDegisiklikTarihi.Visible = true;
            this.colDegisiklikTarihi.VisibleIndex = 8;
            this.colDegisiklikTarihi.Width = 49;
            // 
            // colDegistirenKodu
            // 
            this.colDegistirenKodu.Caption = "Değiştiren";
            this.colDegistirenKodu.ColumnEdit = this.repDegistirenAdiLkUp;
            this.colDegistirenKodu.FieldName = "DEKULL";
            this.colDegistirenKodu.Name = "colDegistirenKodu";
            this.colDegistirenKodu.OptionsColumn.AllowEdit = false;
            this.colDegistirenKodu.OptionsColumn.AllowFocus = false;
            this.colDegistirenKodu.Visible = true;
            this.colDegistirenKodu.VisibleIndex = 9;
            this.colDegistirenKodu.Width = 73;
            // 
            // repDegistirenAdiLkUp
            // 
            this.repDegistirenAdiLkUp.AutoHeight = false;
            this.repDegistirenAdiLkUp.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDegistirenAdiLkUp.DisplayMember = "KullaniciAdi";
            this.repDegistirenAdiLkUp.Name = "repDegistirenAdiLkUp";
            this.repDegistirenAdiLkUp.NullText = "";
            this.repDegistirenAdiLkUp.PopupView = this.gridView2;
            this.repDegistirenAdiLkUp.ValueMember = "Id";
            // 
            // gridView2
            // 
            this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repcol2KullaniciAdi});
            this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView2.Name = "gridView2";
            this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView2.OptionsView.ShowGroupPanel = false;
            // 
            // repcol2KullaniciAdi
            // 
            this.repcol2KullaniciAdi.Caption = "Kullanici Adı";
            this.repcol2KullaniciAdi.FieldName = "KullaniciAdi";
            this.repcol2KullaniciAdi.Name = "repcol2KullaniciAdi";
            this.repcol2KullaniciAdi.Visible = true;
            this.repcol2KullaniciAdi.VisibleIndex = 0;
            // 
            // repYaratmaSaatTimeEdit
            // 
            this.repYaratmaSaatTimeEdit.AutoHeight = false;
            this.repYaratmaSaatTimeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repYaratmaSaatTimeEdit.Name = "repYaratmaSaatTimeEdit";
            // 
            // repDegisiklikSaatiTimeEdit
            // 
            this.repDegisiklikSaatiTimeEdit.AutoHeight = false;
            this.repDegisiklikSaatiTimeEdit.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repDegisiklikSaatiTimeEdit.Name = "repDegisiklikSaatiTimeEdit";
            // 
            // FrmRevizyonTanim
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.Name = "FrmRevizyonTanim";
            this.Text = "Revizyon Tanımı";
            this.Load += new System.EventHandler(this.FrmRevizyonTanim_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemDateEdit1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaadiLkUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegistirenAdiLkUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repYaratmaSaatTimeEdit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repDegisiklikSaatiTimeEdit)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colRevizyonNo;
        private DevExpress.XtraGrid.Columns.GridColumn colRevizyonText;
        private DevExpress.XtraGrid.Columns.GridColumn colBaslangicTarih;
        private DevExpress.XtraEditors.Repository.RepositoryItemDateEdit repositoryItemDateEdit1;
        private DevExpress.XtraGrid.Columns.GridColumn colEtkin;
        private DevExpress.XtraGrid.Columns.GridColumn colUretimOnay;
        private DevExpress.XtraGrid.Columns.GridColumn colSilme;
        private DevExpress.XtraGrid.Columns.GridColumn colYaratmaTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colYaratanKodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repYaratmaadiLkUp;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn repcol1KullaniciAdi;
        private DevExpress.XtraGrid.Columns.GridColumn colDegisiklikTarihi;
        private DevExpress.XtraGrid.Columns.GridColumn colDegistirenKodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repDegistirenAdiLkUp;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn repcol2KullaniciAdi;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repYaratmaSaatTimeEdit;
        private DevExpress.XtraEditors.Repository.RepositoryItemTimeEdit repDegisiklikSaatiTimeEdit;
    }
}
