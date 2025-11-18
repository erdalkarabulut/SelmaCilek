
namespace BPS.Windows.Forms
{
    partial class FrmUrunAgaciMalzemeTuruTayin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmUrunAgaciMalzemeTuruTayin));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUAKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repUAKodu = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcolUAKullanimKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colUAKullanimText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMalzemeTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repMalzemeTuru = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit2View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcolMalzemeTuru = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repcolMalzemeTuruText = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUAKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMalzemeTuru)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repUAKodu,
            this.repMalzemeTuru});
            this.gridControl1.Size = new System.Drawing.Size(957, 439);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colUAKodu,
            this.colMalzemeTuru});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            this.gridView1.CellValueChanged += new DevExpress.XtraGrid.Views.Base.CellValueChangedEventHandler(this.gridView1_CellValueChanged);
            this.gridView1.ValidateRow += new DevExpress.XtraGrid.Views.Base.ValidateRowEventHandler(this.gridView1_ValidateRow);
            // 
            // colId
            // 
            this.colId.Caption = "Id";
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colUAKodu
            // 
            this.colUAKodu.Caption = "Ürün Ağacı Kullanım Tipi";
            this.colUAKodu.ColumnEdit = this.repUAKodu;
            this.colUAKodu.FieldName = "UAKLNT";
            this.colUAKodu.Name = "colUAKodu";
            this.colUAKodu.Visible = true;
            this.colUAKodu.VisibleIndex = 1;
            // 
            // repUAKodu
            // 
            this.repUAKodu.AutoHeight = false;
            this.repUAKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repUAKodu.DisplayMember = "TANIMI";
            this.repUAKodu.Name = "repUAKodu";
            this.repUAKodu.NullText = "";
            this.repUAKodu.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repUAKodu.ValueMember = "KLNKOD";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repcolUAKullanimKodu,
            this.colUAKullanimText});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repcolUAKullanimKodu
            // 
            this.repcolUAKullanimKodu.Caption = "Kullanim Kodu";
            this.repcolUAKullanimKodu.FieldName = "KLNKOD";
            this.repcolUAKullanimKodu.Name = "repcolUAKullanimKodu";
            this.repcolUAKullanimKodu.Visible = true;
            this.repcolUAKullanimKodu.VisibleIndex = 0;
            // 
            // colUAKullanimText
            // 
            this.colUAKullanimText.Caption = "Kullanım Tanım";
            this.colUAKullanimText.FieldName = "TANIMI";
            this.colUAKullanimText.Name = "colUAKullanimText";
            this.colUAKullanimText.Visible = true;
            this.colUAKullanimText.VisibleIndex = 1;
            // 
            // colMalzemeTuru
            // 
            this.colMalzemeTuru.Caption = "Malzeme Türü";
            this.colMalzemeTuru.ColumnEdit = this.repMalzemeTuru;
            this.colMalzemeTuru.FieldName = "STMLTR";
            this.colMalzemeTuru.Name = "colMalzemeTuru";
            this.colMalzemeTuru.Visible = true;
            this.colMalzemeTuru.VisibleIndex = 2;
            // 
            // repMalzemeTuru
            // 
            this.repMalzemeTuru.AutoHeight = false;
            this.repMalzemeTuru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repMalzemeTuru.DisplayMember = "STMLNM";
            this.repMalzemeTuru.Name = "repMalzemeTuru";
            this.repMalzemeTuru.NullText = "";
            this.repMalzemeTuru.PopupView = this.repositoryItemGridLookUpEdit2View;
            this.repMalzemeTuru.ValueMember = "STMLTR";
            // 
            // repositoryItemGridLookUpEdit2View
            // 
            this.repositoryItemGridLookUpEdit2View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repcolMalzemeTuru,
            this.repcolMalzemeTuruText});
            this.repositoryItemGridLookUpEdit2View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit2View.Name = "repositoryItemGridLookUpEdit2View";
            this.repositoryItemGridLookUpEdit2View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit2View.OptionsView.ShowGroupPanel = false;
            // 
            // repcolMalzemeTuru
            // 
            this.repcolMalzemeTuru.Caption = "Malzeme Türü";
            this.repcolMalzemeTuru.FieldName = "STMLTR";
            this.repcolMalzemeTuru.Name = "repcolMalzemeTuru";
            this.repcolMalzemeTuru.Visible = true;
            this.repcolMalzemeTuru.VisibleIndex = 0;
            // 
            // repcolMalzemeTuruText
            // 
            this.repcolMalzemeTuruText.Caption = "Tanım";
            this.repcolMalzemeTuruText.FieldName = "STMLNM";
            this.repcolMalzemeTuruText.Name = "repcolMalzemeTuruText";
            this.repcolMalzemeTuruText.Visible = true;
            this.repcolMalzemeTuruText.VisibleIndex = 1;
            // 
            // FrmUrunAgaciMalzemeTuruTayin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmUrunAgaciMalzemeTuruTayin.IconOptions.Image")));
            this.Name = "FrmUrunAgaciMalzemeTuruTayin";
            this.Text = "Ürün Ağacı Malzeme Türü Tayin";
            this.Load += new System.EventHandler(this.FrmUrunAgaciMalzemeTuruTayin_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUAKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repMalzemeTuru)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colUAKodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repUAKodu;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn repcolUAKullanimKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colUAKullanimText;
        private DevExpress.XtraGrid.Columns.GridColumn colMalzemeTuru;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repMalzemeTuru;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit2View;
        private DevExpress.XtraGrid.Columns.GridColumn repcolMalzemeTuru;
        private DevExpress.XtraGrid.Columns.GridColumn repcolMalzemeTuruText;
    }
}
