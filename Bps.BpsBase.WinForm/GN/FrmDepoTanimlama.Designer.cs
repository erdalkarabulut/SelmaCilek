namespace BPS.Windows.Forms
{
    partial class FrmDepoTanimlama
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDepoTanimlama));
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gNDPTNBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colUretimYeriKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repUretimYeriKodu = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
            this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.repcolUretimYeri = new DevExpress.XtraGrid.Columns.GridColumn();
            this.repcolUretimYeriText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepoKodu = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDepoText = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMipGostergesi = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colCHKCTR = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEKULL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEKKULL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colETARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKYNKKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSIRKID = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSLINDI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMOBILE = new DevExpress.XtraGrid.Columns.GridColumn();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNDPTNBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUretimYeriKodu)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
            this.SuspendLayout();
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.gNDPTNBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 24);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repUretimYeriKodu});
            this.gridControl1.Size = new System.Drawing.Size(957, 439);
            this.gridControl1.TabIndex = 4;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // gNDPTNBindingSource
            // 
            this.gNDPTNBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.GN.GNDPTN);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colUretimYeriKodu,
            this.colDepoKodu,
            this.colDepoText,
            this.colMipGostergesi,
            this.colMOBILE,
            this.colACTIVE,
            this.colCHKCTR,
            this.colDEKULL,
            this.colDTARIH,
            this.colEKKULL,
            this.colETARIH,
            this.colId,
            this.colKYNKKD,
            this.colSIRKID,
            this.colSLINDI});
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
            // colUretimYeriKodu
            // 
            this.colUretimYeriKodu.ColumnEdit = this.repUretimYeriKodu;
            this.colUretimYeriKodu.FieldName = "URYRKD";
            this.colUretimYeriKodu.MinWidth = 23;
            this.colUretimYeriKodu.Name = "colUretimYeriKodu";
            this.colUretimYeriKodu.Visible = true;
            this.colUretimYeriKodu.VisibleIndex = 0;
            this.colUretimYeriKodu.Width = 86;
            // 
            // repUretimYeriKodu
            // 
            this.repUretimYeriKodu.AutoHeight = false;
            this.repUretimYeriKodu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.repUretimYeriKodu.DisplayMember = "TANIMI";
            this.repUretimYeriKodu.Name = "repUretimYeriKodu";
            this.repUretimYeriKodu.NullText = "";
            this.repUretimYeriKodu.PopupView = this.repositoryItemGridLookUpEdit1View;
            this.repUretimYeriKodu.ValueMember = "HARKOD";
            // 
            // repositoryItemGridLookUpEdit1View
            // 
            this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.repcolUretimYeri,
            this.repcolUretimYeriText});
            this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
            this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
            // 
            // repcolUretimYeri
            // 
            this.repcolUretimYeri.Caption = "Üretim Yeri";
            this.repcolUretimYeri.FieldName = "UretimYeriKodu";
            this.repcolUretimYeri.MinWidth = 23;
            this.repcolUretimYeri.Name = "repcolUretimYeri";
            this.repcolUretimYeri.Visible = true;
            this.repcolUretimYeri.VisibleIndex = 0;
            this.repcolUretimYeri.Width = 86;
            // 
            // repcolUretimYeriText
            // 
            this.repcolUretimYeriText.Caption = "Tanım";
            this.repcolUretimYeriText.FieldName = "UretimYeriText";
            this.repcolUretimYeriText.MinWidth = 23;
            this.repcolUretimYeriText.Name = "repcolUretimYeriText";
            this.repcolUretimYeriText.Visible = true;
            this.repcolUretimYeriText.VisibleIndex = 1;
            this.repcolUretimYeriText.Width = 86;
            // 
            // colDepoKodu
            // 
            this.colDepoKodu.Caption = "Depo Kodu";
            this.colDepoKodu.FieldName = "DPKODU";
            this.colDepoKodu.MinWidth = 23;
            this.colDepoKodu.Name = "colDepoKodu";
            this.colDepoKodu.Visible = true;
            this.colDepoKodu.VisibleIndex = 1;
            this.colDepoKodu.Width = 86;
            // 
            // colDepoText
            // 
            this.colDepoText.Caption = "Depo Tanımı";
            this.colDepoText.FieldName = "DPTANM";
            this.colDepoText.MinWidth = 23;
            this.colDepoText.Name = "colDepoText";
            this.colDepoText.Visible = true;
            this.colDepoText.VisibleIndex = 2;
            this.colDepoText.Width = 86;
            // 
            // colMipGostergesi
            // 
            this.colMipGostergesi.Caption = "Mip Gostergesi";
            this.colMipGostergesi.FieldName = "MIPGOS";
            this.colMipGostergesi.MinWidth = 23;
            this.colMipGostergesi.Name = "colMipGostergesi";
            this.colMipGostergesi.Visible = true;
            this.colMipGostergesi.VisibleIndex = 3;
            this.colMipGostergesi.Width = 86;
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.MinWidth = 21;
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Visible = true;
            this.colACTIVE.VisibleIndex = 5;
            this.colACTIVE.Width = 81;
            // 
            // colCHKCTR
            // 
            this.colCHKCTR.FieldName = "CHKCTR";
            this.colCHKCTR.MinWidth = 21;
            this.colCHKCTR.Name = "colCHKCTR";
            this.colCHKCTR.Visible = true;
            this.colCHKCTR.VisibleIndex = 6;
            this.colCHKCTR.Width = 81;
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.MinWidth = 21;
            this.colDEKULL.Name = "colDEKULL";
            this.colDEKULL.Visible = true;
            this.colDEKULL.VisibleIndex = 7;
            this.colDEKULL.Width = 81;
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.MinWidth = 21;
            this.colDTARIH.Name = "colDTARIH";
            this.colDTARIH.Visible = true;
            this.colDTARIH.VisibleIndex = 8;
            this.colDTARIH.Width = 81;
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.MinWidth = 21;
            this.colEKKULL.Name = "colEKKULL";
            this.colEKKULL.Visible = true;
            this.colEKKULL.VisibleIndex = 9;
            this.colEKKULL.Width = 81;
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.MinWidth = 21;
            this.colETARIH.Name = "colETARIH";
            this.colETARIH.Visible = true;
            this.colETARIH.VisibleIndex = 10;
            this.colETARIH.Width = 81;
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.MinWidth = 21;
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 11;
            this.colId.Width = 81;
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.MinWidth = 21;
            this.colKYNKKD.Name = "colKYNKKD";
            this.colKYNKKD.Visible = true;
            this.colKYNKKD.VisibleIndex = 12;
            this.colKYNKKD.Width = 81;
            // 
            // colSIRKID
            // 
            this.colSIRKID.FieldName = "SIRKID";
            this.colSIRKID.MinWidth = 21;
            this.colSIRKID.Name = "colSIRKID";
            this.colSIRKID.Visible = true;
            this.colSIRKID.VisibleIndex = 13;
            this.colSIRKID.Width = 81;
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.MinWidth = 21;
            this.colSLINDI.Name = "colSLINDI";
            this.colSLINDI.Visible = true;
            this.colSLINDI.VisibleIndex = 14;
            this.colSLINDI.Width = 81;
            // 
            // colMOBILE
            // 
            this.colMOBILE.FieldName = "MOBILE";
            this.colMOBILE.Name = "colMOBILE";
            this.colMOBILE.Visible = true;
            this.colMOBILE.VisibleIndex = 4;
            this.colMOBILE.Width = 64;
            // 
            // FrmDepoTanimlama
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.gridControl1);
            this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmDepoTanimlama.IconOptions.Image")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FrmDepoTanimlama";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.gridControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gNDPTNBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repUretimYeriKodu)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private DevExpress.XtraGrid.Columns.GridColumn colUretimYeriKodu;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repUretimYeriKodu;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn repcolUretimYeri;
        private DevExpress.XtraGrid.Columns.GridColumn repcolUretimYeriText;
        private DevExpress.XtraGrid.Columns.GridColumn colDepoKodu;
        private DevExpress.XtraGrid.Columns.GridColumn colDepoText;
        private DevExpress.XtraGrid.Columns.GridColumn colMipGostergesi;
        private System.Windows.Forms.BindingSource gNDPTNBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colACTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colCHKCTR;
        private DevExpress.XtraGrid.Columns.GridColumn colDEKULL;
        private DevExpress.XtraGrid.Columns.GridColumn colDTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colEKKULL;
        private DevExpress.XtraGrid.Columns.GridColumn colETARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colKYNKKD;
        private DevExpress.XtraGrid.Columns.GridColumn colSIRKID;
        private DevExpress.XtraGrid.Columns.GridColumn colSLINDI;
        private DevExpress.XtraGrid.Columns.GridColumn colMOBILE;
    }
}
