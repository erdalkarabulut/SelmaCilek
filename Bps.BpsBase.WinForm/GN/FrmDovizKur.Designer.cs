namespace BPS.Windows.Forms
{
    partial class FrmDovizKur
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
            System.Windows.Forms.Label dVCNKDLabel;
            System.Windows.Forms.Label dOVTRHLabel;
            System.Windows.Forms.Label dVFYT1Label;
            System.Windows.Forms.Label dVFYT2Label;
            System.Windows.Forms.Label dVFYT3Label;
            System.Windows.Forms.Label dVFYT4Label;
            System.Windows.Forms.Label aCTIVELabel;
            this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
            this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.dOVKURBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVCNKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDOVTRH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVFYT1 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVFYT2 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVFYT3 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDVFYT4 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colMANUEL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colEKKULL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colETARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDEKULL = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colDTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colKYNKKD = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
            this.colSLINDI = new DevExpress.XtraGrid.Columns.GridColumn();
            this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
            this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
            this.dateEdit1 = new DevExpress.XtraEditors.DateEdit();
            this.btnMerkezBankasi = new DevExpress.XtraEditors.SimpleButton();
            this.aCTIVECheckBox = new System.Windows.Forms.CheckBox();
            this.dVFYT4TextBox = new System.Windows.Forms.TextBox();
            this.dVFYT3TextBox = new System.Windows.Forms.TextBox();
            this.dVFYT2TextBox = new System.Windows.Forms.TextBox();
            this.dVFYT1TextBox = new System.Windows.Forms.TextBox();
            this.LkEdDovizKod = new DevExpress.XtraEditors.GridLookUpEdit();
            this.gridView16 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
            this.dxErrorProvider1 = new DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider(this.components);
            dVCNKDLabel = new System.Windows.Forms.Label();
            dOVTRHLabel = new System.Windows.Forms.Label();
            dVFYT1Label = new System.Windows.Forms.Label();
            dVFYT2Label = new System.Windows.Forms.Label();
            dVFYT3Label = new System.Windows.Forms.Label();
            dVFYT4Label = new System.Windows.Forms.Label();
            aCTIVELabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
            this.xtraTabControl1.SuspendLayout();
            this.xtraTabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOVKURBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.xtraTabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
            this.groupControl1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.LkEdDovizKod.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).BeginInit();
            this.SuspendLayout();
            // 
            // dVCNKDLabel
            // 
            dVCNKDLabel.AutoSize = true;
            dVCNKDLabel.Location = new System.Drawing.Point(15, 33);
            dVCNKDLabel.Name = "dVCNKDLabel";
            dVCNKDLabel.Size = new System.Drawing.Size(64, 13);
            dVCNKDLabel.TabIndex = 0;
            dVCNKDLabel.Text = "Döviz Kodu:";
            // 
            // dOVTRHLabel
            // 
            dOVTRHLabel.AutoSize = true;
            dOVTRHLabel.Location = new System.Drawing.Point(15, 65);
            dOVTRHLabel.Name = "dOVTRHLabel";
            dOVTRHLabel.Size = new System.Drawing.Size(66, 13);
            dOVTRHLabel.TabIndex = 13;
            dOVTRHLabel.Text = "Döviz Tarihi:";
            // 
            // dVFYT1Label
            // 
            dVFYT1Label.AutoSize = true;
            dVFYT1Label.Location = new System.Drawing.Point(15, 95);
            dVFYT1Label.Name = "dVFYT1Label";
            dVFYT1Label.Size = new System.Drawing.Size(70, 13);
            dVFYT1Label.TabIndex = 14;
            dVFYT1Label.Text = "Döviz Fiyat1:";
            // 
            // dVFYT2Label
            // 
            dVFYT2Label.AutoSize = true;
            dVFYT2Label.Location = new System.Drawing.Point(15, 131);
            dVFYT2Label.Name = "dVFYT2Label";
            dVFYT2Label.Size = new System.Drawing.Size(70, 13);
            dVFYT2Label.TabIndex = 15;
            dVFYT2Label.Text = "Döviz Fiyat2:";
            // 
            // dVFYT3Label
            // 
            dVFYT3Label.AutoSize = true;
            dVFYT3Label.Location = new System.Drawing.Point(15, 167);
            dVFYT3Label.Name = "dVFYT3Label";
            dVFYT3Label.Size = new System.Drawing.Size(70, 13);
            dVFYT3Label.TabIndex = 16;
            dVFYT3Label.Text = "Döviz Fiyat3:";
            // 
            // dVFYT4Label
            // 
            dVFYT4Label.AutoSize = true;
            dVFYT4Label.Location = new System.Drawing.Point(15, 200);
            dVFYT4Label.Name = "dVFYT4Label";
            dVFYT4Label.Size = new System.Drawing.Size(70, 13);
            dVFYT4Label.TabIndex = 17;
            dVFYT4Label.Text = "Döviz Fiyat4:";
            // 
            // aCTIVELabel
            // 
            aCTIVELabel.AutoSize = true;
            aCTIVELabel.Location = new System.Drawing.Point(15, 234);
            aCTIVELabel.Name = "aCTIVELabel";
            aCTIVELabel.Size = new System.Drawing.Size(33, 13);
            aCTIVELabel.TabIndex = 18;
            aCTIVELabel.Text = "Aktif:";
            // 
            // xtraTabControl1
            // 
            this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.xtraTabControl1.Location = new System.Drawing.Point(0, 24);
            this.xtraTabControl1.Name = "xtraTabControl1";
            this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
            this.xtraTabControl1.Size = new System.Drawing.Size(957, 419);
            this.xtraTabControl1.TabIndex = 4;
            this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2});
            // 
            // xtraTabPage1
            // 
            this.xtraTabPage1.Controls.Add(this.gridControl1);
            this.xtraTabPage1.Name = "xtraTabPage1";
            this.xtraTabPage1.Size = new System.Drawing.Size(955, 394);
            this.xtraTabPage1.Text = "xtraTabPage1";
            // 
            // gridControl1
            // 
            this.gridControl1.DataSource = this.dOVKURBindingSource;
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(955, 394);
            this.gridControl1.TabIndex = 5;
            this.gridControl1.Tag = "1";
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
            // 
            // dOVKURBindingSource
            // 
            this.dOVKURBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.DOVKUR);
            this.dOVKURBindingSource.AddingNew += new System.ComponentModel.AddingNewEventHandler(this.dOVKURBindingSource_AddingNew);
            // 
            // gridView1
            // 
            this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colDVCNKD,
            this.colDOVTRH,
            this.colDVFYT1,
            this.colDVFYT2,
            this.colDVFYT3,
            this.colDVFYT4,
            this.colMANUEL,
            this.colEKKULL,
            this.colETARIH,
            this.colDEKULL,
            this.colDTARIH,
            this.colKYNKKD,
            this.colACTIVE,
            this.colSLINDI});
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.ReadOnly = true;
            this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.PopupMenuShowing += new DevExpress.XtraGrid.Views.Grid.PopupMenuShowingEventHandler(this.gridView1_PopupMenuShowing);
            // 
            // colId
            // 
            this.colId.FieldName = "Id";
            this.colId.Name = "colId";
            this.colId.Visible = true;
            this.colId.VisibleIndex = 0;
            // 
            // colDVCNKD
            // 
            this.colDVCNKD.FieldName = "DVCNKD";
            this.colDVCNKD.Name = "colDVCNKD";
            this.colDVCNKD.Visible = true;
            this.colDVCNKD.VisibleIndex = 1;
            // 
            // colDOVTRH
            // 
            this.colDOVTRH.FieldName = "DOVTRH";
            this.colDOVTRH.Name = "colDOVTRH";
            this.colDOVTRH.Visible = true;
            this.colDOVTRH.VisibleIndex = 2;
            // 
            // colDVFYT1
            // 
            this.colDVFYT1.DisplayFormat.FormatString = "c4";
            this.colDVFYT1.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDVFYT1.FieldName = "DVFYT1";
            this.colDVFYT1.Name = "colDVFYT1";
            this.colDVFYT1.Visible = true;
            this.colDVFYT1.VisibleIndex = 3;
            // 
            // colDVFYT2
            // 
            this.colDVFYT2.DisplayFormat.FormatString = "c4";
            this.colDVFYT2.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDVFYT2.FieldName = "DVFYT2";
            this.colDVFYT2.Name = "colDVFYT2";
            this.colDVFYT2.Visible = true;
            this.colDVFYT2.VisibleIndex = 4;
            // 
            // colDVFYT3
            // 
            this.colDVFYT3.DisplayFormat.FormatString = "c4";
            this.colDVFYT3.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDVFYT3.FieldName = "DVFYT3";
            this.colDVFYT3.Name = "colDVFYT3";
            this.colDVFYT3.Visible = true;
            this.colDVFYT3.VisibleIndex = 5;
            // 
            // colDVFYT4
            // 
            this.colDVFYT4.DisplayFormat.FormatString = "c4";
            this.colDVFYT4.DisplayFormat.FormatType = DevExpress.Utils.FormatType.Numeric;
            this.colDVFYT4.FieldName = "DVFYT4";
            this.colDVFYT4.Name = "colDVFYT4";
            this.colDVFYT4.Visible = true;
            this.colDVFYT4.VisibleIndex = 6;
            // 
            // colMANUEL
            // 
            this.colMANUEL.FieldName = "MANUEL";
            this.colMANUEL.Name = "colMANUEL";
            this.colMANUEL.Visible = true;
            this.colMANUEL.VisibleIndex = 7;
            // 
            // colEKKULL
            // 
            this.colEKKULL.FieldName = "EKKULL";
            this.colEKKULL.Name = "colEKKULL";
            this.colEKKULL.Visible = true;
            this.colEKKULL.VisibleIndex = 8;
            // 
            // colETARIH
            // 
            this.colETARIH.FieldName = "ETARIH";
            this.colETARIH.Name = "colETARIH";
            this.colETARIH.Visible = true;
            this.colETARIH.VisibleIndex = 9;
            // 
            // colDEKULL
            // 
            this.colDEKULL.FieldName = "DEKULL";
            this.colDEKULL.Name = "colDEKULL";
            this.colDEKULL.Visible = true;
            this.colDEKULL.VisibleIndex = 10;
            // 
            // colDTARIH
            // 
            this.colDTARIH.FieldName = "DTARIH";
            this.colDTARIH.Name = "colDTARIH";
            this.colDTARIH.Visible = true;
            this.colDTARIH.VisibleIndex = 11;
            // 
            // colKYNKKD
            // 
            this.colKYNKKD.FieldName = "KYNKKD";
            this.colKYNKKD.Name = "colKYNKKD";
            this.colKYNKKD.Visible = true;
            this.colKYNKKD.VisibleIndex = 12;
            // 
            // colACTIVE
            // 
            this.colACTIVE.FieldName = "ACTIVE";
            this.colACTIVE.Name = "colACTIVE";
            this.colACTIVE.Visible = true;
            this.colACTIVE.VisibleIndex = 13;
            // 
            // colSLINDI
            // 
            this.colSLINDI.FieldName = "SLINDI";
            this.colSLINDI.Name = "colSLINDI";
            this.colSLINDI.Visible = true;
            this.colSLINDI.VisibleIndex = 14;
            // 
            // xtraTabPage2
            // 
            this.xtraTabPage2.Controls.Add(this.groupControl1);
            this.xtraTabPage2.Name = "xtraTabPage2";
            this.xtraTabPage2.Size = new System.Drawing.Size(955, 394);
            this.xtraTabPage2.Text = "xtraTabPage2";
            // 
            // groupControl1
            // 
            this.groupControl1.Controls.Add(this.dateEdit1);
            this.groupControl1.Controls.Add(this.btnMerkezBankasi);
            this.groupControl1.Controls.Add(aCTIVELabel);
            this.groupControl1.Controls.Add(this.aCTIVECheckBox);
            this.groupControl1.Controls.Add(dVFYT4Label);
            this.groupControl1.Controls.Add(this.dVFYT4TextBox);
            this.groupControl1.Controls.Add(dVFYT3Label);
            this.groupControl1.Controls.Add(this.dVFYT3TextBox);
            this.groupControl1.Controls.Add(dVFYT2Label);
            this.groupControl1.Controls.Add(this.dVFYT2TextBox);
            this.groupControl1.Controls.Add(dVFYT1Label);
            this.groupControl1.Controls.Add(this.dVFYT1TextBox);
            this.groupControl1.Controls.Add(dOVTRHLabel);
            this.groupControl1.Controls.Add(this.LkEdDovizKod);
            this.groupControl1.Controls.Add(dVCNKDLabel);
            this.groupControl1.Location = new System.Drawing.Point(11, 19);
            this.groupControl1.Name = "groupControl1";
            this.groupControl1.ShowCaption = false;
            this.groupControl1.Size = new System.Drawing.Size(748, 337);
            this.groupControl1.TabIndex = 0;
            // 
            // dateEdit1
            // 
            this.dateEdit1.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOVKURBindingSource, "DOVTRH", true));
            this.dateEdit1.EditValue = null;
            this.dateEdit1.Location = new System.Drawing.Point(111, 62);
            this.dateEdit1.MenuManager = this.barManager;
            this.dateEdit1.Name = "dateEdit1";
            this.dateEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.dateEdit1.Size = new System.Drawing.Size(179, 20);
            this.dateEdit1.TabIndex = 21;
            // 
            // btnMerkezBankasi
            // 
            this.btnMerkezBankasi.Location = new System.Drawing.Point(306, 28);
            this.btnMerkezBankasi.Name = "btnMerkezBankasi";
            this.btnMerkezBankasi.Size = new System.Drawing.Size(125, 23);
            this.btnMerkezBankasi.TabIndex = 20;
            this.btnMerkezBankasi.Text = "Merkez Bankası\'ndan al";
            this.btnMerkezBankasi.Click += new System.EventHandler(this.btnMerkezBankasi_Click);
            // 
            // aCTIVECheckBox
            // 
            this.aCTIVECheckBox.Checked = true;
            this.aCTIVECheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.aCTIVECheckBox.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.dOVKURBindingSource, "ACTIVE", true));
            this.aCTIVECheckBox.Location = new System.Drawing.Point(111, 229);
            this.aCTIVECheckBox.Name = "aCTIVECheckBox";
            this.aCTIVECheckBox.Size = new System.Drawing.Size(104, 24);
            this.aCTIVECheckBox.TabIndex = 19;
            this.aCTIVECheckBox.UseVisualStyleBackColor = true;
            // 
            // dVFYT4TextBox
            // 
            this.dVFYT4TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dOVKURBindingSource, "DVFYT4", true));
            this.dVFYT4TextBox.Location = new System.Drawing.Point(111, 197);
            this.dVFYT4TextBox.Name = "dVFYT4TextBox";
            this.dVFYT4TextBox.Size = new System.Drawing.Size(100, 21);
            this.dVFYT4TextBox.TabIndex = 18;
            // 
            // dVFYT3TextBox
            // 
            this.dVFYT3TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dOVKURBindingSource, "DVFYT3", true));
            this.dVFYT3TextBox.Location = new System.Drawing.Point(111, 165);
            this.dVFYT3TextBox.Name = "dVFYT3TextBox";
            this.dVFYT3TextBox.Size = new System.Drawing.Size(100, 21);
            this.dVFYT3TextBox.TabIndex = 17;
            // 
            // dVFYT2TextBox
            // 
            this.dVFYT2TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dOVKURBindingSource, "DVFYT2", true));
            this.dVFYT2TextBox.Location = new System.Drawing.Point(111, 129);
            this.dVFYT2TextBox.Name = "dVFYT2TextBox";
            this.dVFYT2TextBox.Size = new System.Drawing.Size(100, 21);
            this.dVFYT2TextBox.TabIndex = 16;
            // 
            // dVFYT1TextBox
            // 
            this.dVFYT1TextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.dOVKURBindingSource, "DVFYT1", true));
            this.dVFYT1TextBox.Location = new System.Drawing.Point(111, 93);
            this.dVFYT1TextBox.Name = "dVFYT1TextBox";
            this.dVFYT1TextBox.Size = new System.Drawing.Size(100, 21);
            this.dVFYT1TextBox.TabIndex = 15;
            // 
            // LkEdDovizKod
            // 
            this.LkEdDovizKod.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.dOVKURBindingSource, "DVCNKD", true));
            this.LkEdDovizKod.EditValue = "";
            this.LkEdDovizKod.Location = new System.Drawing.Point(111, 31);
            this.LkEdDovizKod.Name = "LkEdDovizKod";
            this.LkEdDovizKod.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
            this.LkEdDovizKod.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.LkEdDovizKod.Properties.DisplayMember = "TANIMI";
            this.LkEdDovizKod.Properties.LookAndFeel.UseDefaultLookAndFeel = false;
            this.LkEdDovizKod.Properties.NullText = "";
            this.LkEdDovizKod.Properties.PopupView = this.gridView16;
            this.LkEdDovizKod.Properties.ValueMember = "HARKOD";
            this.LkEdDovizKod.Size = new System.Drawing.Size(179, 20);
            this.LkEdDovizKod.TabIndex = 13;
            // 
            // gridView16
            // 
            this.gridView16.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn27,
            this.gridColumn28});
            this.gridView16.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
            this.gridView16.Name = "gridView16";
            this.gridView16.OptionsSelection.EnableAppearanceFocusedCell = false;
            this.gridView16.OptionsView.ShowAutoFilterRow = true;
            this.gridView16.OptionsView.ShowGroupPanel = false;
            // 
            // gridColumn27
            // 
            this.gridColumn27.Caption = "Kod";
            this.gridColumn27.FieldName = "HARKOD";
            this.gridColumn27.Name = "gridColumn27";
            this.gridColumn27.Visible = true;
            this.gridColumn27.VisibleIndex = 0;
            // 
            // gridColumn28
            // 
            this.gridColumn28.Caption = "Tanımı";
            this.gridColumn28.FieldName = "TANIMI";
            this.gridColumn28.Name = "gridColumn28";
            this.gridColumn28.Visible = true;
            this.gridColumn28.VisibleIndex = 1;
            // 
            // dxErrorProvider1
            // 
            this.dxErrorProvider1.ContainerControl = this;
            this.dxErrorProvider1.DataSource = this.dOVKURBindingSource;
            // 
            // FrmDovizKur
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.ClientSize = new System.Drawing.Size(957, 463);
            this.Controls.Add(this.xtraTabControl1);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "FrmDovizKur";
            this.Load += new System.EventHandler(this.TemplateForm_Load);
            this.Controls.SetChildIndex(this.xtraTabControl1, 0);
            ((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
            this.xtraTabControl1.ResumeLayout(false);
            this.xtraTabPage1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dOVKURBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.xtraTabPage2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
            this.groupControl1.ResumeLayout(false);
            this.groupControl1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties.CalendarTimeProperties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dateEdit1.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.LkEdDovizKod.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView16)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dxErrorProvider1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource dOVKURBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colACTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colSLINDI;
        private DevExpress.XtraGrid.Columns.GridColumn colEKKULL;
        private DevExpress.XtraGrid.Columns.GridColumn colETARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colDEKULL;
        private DevExpress.XtraGrid.Columns.GridColumn colDTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colKYNKKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDVCNKD;
        private DevExpress.XtraGrid.Columns.GridColumn colDOVTRH;
        private DevExpress.XtraGrid.Columns.GridColumn colDVFYT1;
        private DevExpress.XtraGrid.Columns.GridColumn colDVFYT2;
        private DevExpress.XtraGrid.Columns.GridColumn colDVFYT3;
        private DevExpress.XtraGrid.Columns.GridColumn colDVFYT4;
        private DevExpress.XtraGrid.Columns.GridColumn colMANUEL;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GridLookUpEdit LkEdDovizKod;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private System.Windows.Forms.CheckBox aCTIVECheckBox;
        private System.Windows.Forms.TextBox dVFYT4TextBox;
        private System.Windows.Forms.TextBox dVFYT3TextBox;
        private System.Windows.Forms.TextBox dVFYT2TextBox;
        private System.Windows.Forms.TextBox dVFYT1TextBox;
        private DevExpress.XtraEditors.SimpleButton btnMerkezBankasi;
        private DevExpress.XtraEditors.DateEdit dateEdit1;
        private DevExpress.XtraEditors.DXErrorProvider.DXErrorProvider dxErrorProvider1;
    }
}
