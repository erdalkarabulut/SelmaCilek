
namespace BPS.Windows.Forms
{
    partial class FrmServisKarti
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
			System.Windows.Forms.Label cRKODULabel;
			System.Windows.Forms.Label label1;
			System.Windows.Forms.Label label2;
			System.Windows.Forms.Label label3;
			System.Windows.Forms.Label label5;
			System.Windows.Forms.Label label4;
			System.Windows.Forms.Label label6;
			System.Windows.Forms.Label label7;
			System.Windows.Forms.Label label8;
			System.Windows.Forms.Label label9;
			System.Windows.Forms.Label label10;
			System.Windows.Forms.Label label14;
			System.Windows.Forms.Label label15;
			System.Windows.Forms.Label label11;
			System.Windows.Forms.Label label12;
			System.Windows.Forms.Label label17;
			System.Windows.Forms.Label label16;
			System.Windows.Forms.Label label18;
			System.Windows.Forms.Label label19;
			System.Windows.Forms.Label label13;
			System.Windows.Forms.Label label20;
			System.Windows.Forms.Label bELGENLabel;
			System.Windows.Forms.Label eTARIHLabel;
			System.Windows.Forms.Label sTFYNOLabel;
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmServisKarti));
			this.xtraTabControl1 = new DevExpress.XtraTab.XtraTabControl();
			this.xtraTabPage1 = new DevExpress.XtraTab.XtraTabPage();
			this.chkTamamlanan = new System.Windows.Forms.CheckBox();
			this.btnServisAra = new DevExpress.XtraEditors.SimpleButton();
			this.bELGENTextEdit = new DevExpress.XtraEditors.TextEdit();
			this.dtBitis = new DevExpress.XtraEditors.DateEdit();
			this.dtBaslangic = new DevExpress.XtraEditors.DateEdit();
			this.xtraTabPage2 = new DevExpress.XtraTab.XtraTabPage();
			this.gridControl1 = new DevExpress.XtraGrid.GridControl();
			this.sHSRVSBindingSource = new System.Windows.Forms.BindingSource(this.components);
			this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.colId = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSRTLTR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBELGEN = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colBELTRH = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCRKODU = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repGrdLkedCari = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.repositoryItemGridLookUpEdit1View = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn23 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn24 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colTLPACN = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colURKTGR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repGrdLkedKategori = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView8 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn25 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn32 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colURMODL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repGrdLkedUrunModel = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView7 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn20 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn21 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSRVTUR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repGrdLkedServisTuru = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView11 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn33 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn34 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSRVDRM = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repGrdLkedServisDurumu = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView12 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn35 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn36 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colGRNDRM = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMKNDRM = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colMKKRTR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSRPRID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repGrdLkedPersonel = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView13 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn37 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn38 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colURSERI = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colURSASI = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPRBTNM = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colPRBTSP = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colAKSYON = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colONYLYN = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSRBSTR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSRBTTR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSIRKID = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colACTIVE = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colSLINDI = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colEKKULL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colETARIH = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDEKULL = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colDTARIH = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colKYNKKD = new DevExpress.XtraGrid.Columns.GridColumn();
			this.colCHKCTR = new DevExpress.XtraGrid.Columns.GridColumn();
			this.xtraTabPage3 = new DevExpress.XtraTab.XtraTabPage();
			this.xtraScrollableControl1 = new DevExpress.XtraEditors.XtraScrollableControl();
			this.groupControl5 = new DevExpress.XtraEditors.GroupControl();
			this.grdIslemSure = new DevExpress.XtraGrid.GridControl();
			this.grdVwIslemSure = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn22 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn39 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn40 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn41 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit1 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView16 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn43 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn44 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit2 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView15 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn47 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn48 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit4 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView18 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn53 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn54 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit5 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView19 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn56 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn57 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit6 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView20 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn62 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn63 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.repositoryItemGridLookUpEdit3 = new DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit();
			this.gridView17 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn50 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn51 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl4 = new DevExpress.XtraEditors.GroupControl();
			this.btnWord = new DevExpress.XtraEditors.SimpleButton();
			this.pdfBut = new DevExpress.XtraEditors.SimpleButton();
			this.btnPdf = new DevExpress.XtraEditors.SimpleButton();
			this.memoAksiyon = new DevExpress.XtraEditors.MemoEdit();
			this.memoProblemTespit = new DevExpress.XtraEditors.MemoEdit();
			this.memoProblemTanim = new DevExpress.XtraEditors.MemoEdit();
			this.groupControl3 = new DevExpress.XtraEditors.GroupControl();
			this.txtSasiNo = new DevExpress.XtraEditors.TextEdit();
			this.txtSeriNo = new DevExpress.XtraEditors.TextEdit();
			this.grdLkedModel = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView9 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn26 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn27 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn28 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grdLkedKategori = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView10 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn29 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn30 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn31 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.groupControl2 = new DevExpress.XtraEditors.GroupControl();
			this.timeEdit1 = new DevExpress.XtraEditors.TimeEdit();
			this.dateServisTalep = new DevExpress.XtraEditors.DateEdit();
			this.dateKurulum = new DevExpress.XtraEditors.DateEdit();
			this.grdLkedMakineDurumu = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView6 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn17 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn18 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn19 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grdLkedGarantiDurumu = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView5 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn14 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn15 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn16 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grdLkedServisDurumu = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView4 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn11 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn12 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn13 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grdLkedServisTuru = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView3 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn8 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn9 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn10 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.grdLkedServisPersonel = new DevExpress.XtraEditors.GridLookUpEdit();
			this.gridView2 = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn4 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn5 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn6 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn7 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.cmbTalebiAcan = new System.Windows.Forms.ComboBox();
			this.groupControl1 = new DevExpress.XtraEditors.GroupControl();
			this.txtGpsBoylam = new DevExpress.XtraEditors.TextEdit();
			this.txtGpsEnlem = new DevExpress.XtraEditors.TextEdit();
			this.btnAdayCariEkle = new DevExpress.XtraEditors.SimpleButton();
			this.cmbAdres = new System.Windows.Forms.ComboBox();
			this.cmbTelefon = new System.Windows.Forms.ComboBox();
			this.cmbYetkili = new System.Windows.Forms.ComboBox();
			this.cRKODUGridLookUpEdit = new DevExpress.XtraEditors.GridLookUpEdit();
			this.cRKODUGridLookUpEditView = new DevExpress.XtraGrid.Views.Grid.GridView();
			this.gridColumn1 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn2 = new DevExpress.XtraGrid.Columns.GridColumn();
			this.gridColumn3 = new DevExpress.XtraGrid.Columns.GridColumn();
			cRKODULabel = new System.Windows.Forms.Label();
			label1 = new System.Windows.Forms.Label();
			label2 = new System.Windows.Forms.Label();
			label3 = new System.Windows.Forms.Label();
			label5 = new System.Windows.Forms.Label();
			label4 = new System.Windows.Forms.Label();
			label6 = new System.Windows.Forms.Label();
			label7 = new System.Windows.Forms.Label();
			label8 = new System.Windows.Forms.Label();
			label9 = new System.Windows.Forms.Label();
			label10 = new System.Windows.Forms.Label();
			label14 = new System.Windows.Forms.Label();
			label15 = new System.Windows.Forms.Label();
			label11 = new System.Windows.Forms.Label();
			label12 = new System.Windows.Forms.Label();
			label17 = new System.Windows.Forms.Label();
			label16 = new System.Windows.Forms.Label();
			label18 = new System.Windows.Forms.Label();
			label19 = new System.Windows.Forms.Label();
			label13 = new System.Windows.Forms.Label();
			label20 = new System.Windows.Forms.Label();
			bELGENLabel = new System.Windows.Forms.Label();
			eTARIHLabel = new System.Windows.Forms.Label();
			sTFYNOLabel = new System.Windows.Forms.Label();
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).BeginInit();
			this.xtraTabControl1.SuspendLayout();
			this.xtraTabPage1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.bELGENTextEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties)).BeginInit();
			this.xtraTabPage2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.sHSRVSBindingSource)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedCari)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedKategori)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedUrunModel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedServisTuru)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView11)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedServisDurumu)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView12)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedPersonel)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView13)).BeginInit();
			this.xtraTabPage3.SuspendLayout();
			this.xtraScrollableControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.groupControl5)).BeginInit();
			this.groupControl5.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.grdIslemSure)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdVwIslemSure)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView16)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView15)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView18)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView19)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView20)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView17)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).BeginInit();
			this.groupControl4.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoAksiyon.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoProblemTespit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.memoProblemTanim.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).BeginInit();
			this.groupControl3.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSasiNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSeriNo.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedModel.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView9)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedKategori.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView10)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).BeginInit();
			this.groupControl2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateServisTalep.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateServisTalep.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateKurulum.Properties.CalendarTimeProperties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dateKurulum.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedMakineDurumu.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedGarantiDurumu.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedServisDurumu.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedServisTuru.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedServisPersonel.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).BeginInit();
			this.groupControl1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtGpsBoylam.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.txtGpsEnlem.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cRKODUGridLookUpEdit.Properties)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.cRKODUGridLookUpEditView)).BeginInit();
			this.SuspendLayout();
			// 
			// cRKODULabel
			// 
			cRKODULabel.AutoSize = true;
			cRKODULabel.Location = new System.Drawing.Point(54, 39);
			cRKODULabel.Name = "cRKODULabel";
			cRKODULabel.Size = new System.Drawing.Size(46, 13);
			cRKODULabel.TabIndex = 0;
			cRKODULabel.Text = "Müşteri:";
			// 
			// label1
			// 
			label1.AutoSize = true;
			label1.Location = new System.Drawing.Point(61, 65);
			label1.Name = "label1";
			label1.Size = new System.Drawing.Size(39, 13);
			label1.TabIndex = 3;
			label1.Text = "Adres:";
			// 
			// label2
			// 
			label2.AutoSize = true;
			label2.Location = new System.Drawing.Point(44, 94);
			label2.Name = "label2";
			label2.Size = new System.Drawing.Size(56, 13);
			label2.TabIndex = 5;
			label2.Text = "Yetkili Kişi:";
			// 
			// label3
			// 
			label3.AutoSize = true;
			label3.Location = new System.Drawing.Point(405, 92);
			label3.Name = "label3";
			label3.Size = new System.Drawing.Size(47, 13);
			label3.TabIndex = 7;
			label3.Text = "Telefon:";
			// 
			// label5
			// 
			label5.AutoSize = true;
			label5.Location = new System.Drawing.Point(34, 39);
			label5.Name = "label5";
			label5.Size = new System.Drawing.Size(66, 13);
			label5.TabIndex = 5;
			label5.Text = "Talebi Açan:";
			// 
			// label4
			// 
			label4.AutoSize = true;
			label4.Location = new System.Drawing.Point(369, 66);
			label4.Name = "label4";
			label4.Size = new System.Drawing.Size(86, 13);
			label4.TabIndex = 6;
			label4.Text = "Servis Personeli:";
			// 
			// label6
			// 
			label6.AutoSize = true;
			label6.Location = new System.Drawing.Point(35, 66);
			label6.Name = "label6";
			label6.Size = new System.Drawing.Size(65, 13);
			label6.TabIndex = 8;
			label6.Text = "Servis Türü:";
			// 
			// label7
			// 
			label7.AutoSize = true;
			label7.Location = new System.Drawing.Point(16, 92);
			label7.Name = "label7";
			label7.Size = new System.Drawing.Size(80, 13);
			label7.TabIndex = 10;
			label7.Text = "Servis Durumu:";
			// 
			// label8
			// 
			label8.AutoSize = true;
			label8.Location = new System.Drawing.Point(10, 118);
			label8.Name = "label8";
			label8.Size = new System.Drawing.Size(86, 13);
			label8.TabIndex = 12;
			label8.Text = "Garanti Durumu:";
			// 
			// label9
			// 
			label9.AutoSize = true;
			label9.Location = new System.Drawing.Point(365, 93);
			label9.Name = "label9";
			label9.Size = new System.Drawing.Size(84, 13);
			label9.TabIndex = 14;
			label9.Text = "Makine Durumu:";
			// 
			// label10
			// 
			label10.AutoSize = true;
			label10.Location = new System.Drawing.Point(373, 119);
			label10.Name = "label10";
			label10.Size = new System.Drawing.Size(78, 13);
			label10.TabIndex = 17;
			label10.Text = "Kurulum Tarihi:";
			// 
			// label14
			// 
			label14.AutoSize = true;
			label14.Location = new System.Drawing.Point(415, 40);
			label14.Name = "label14";
			label14.Size = new System.Drawing.Size(39, 13);
			label14.TabIndex = 10;
			label14.Text = "Model:";
			// 
			// label15
			// 
			label15.AutoSize = true;
			label15.Location = new System.Drawing.Point(49, 40);
			label15.Name = "label15";
			label15.Size = new System.Drawing.Size(51, 13);
			label15.TabIndex = 8;
			label15.Text = "Kategori:";
			// 
			// label11
			// 
			label11.AutoSize = true;
			label11.Location = new System.Drawing.Point(54, 66);
			label11.Name = "label11";
			label11.Size = new System.Drawing.Size(45, 13);
			label11.TabIndex = 14;
			label11.Text = "Seri No:";
			// 
			// label12
			// 
			label12.AutoSize = true;
			label12.Location = new System.Drawing.Point(409, 66);
			label12.Name = "label12";
			label12.Size = new System.Drawing.Size(46, 13);
			label12.TabIndex = 15;
			label12.Text = "Şasi No:";
			// 
			// label17
			// 
			label17.AutoSize = true;
			label17.Location = new System.Drawing.Point(13, 39);
			label17.Name = "label17";
			label17.Size = new System.Drawing.Size(82, 13);
			label17.TabIndex = 14;
			label17.Text = "Problem Tanımı:";
			// 
			// label16
			// 
			label16.AutoSize = true;
			label16.Location = new System.Drawing.Point(14, 98);
			label16.Name = "label16";
			label16.Size = new System.Drawing.Size(83, 13);
			label16.TabIndex = 16;
			label16.Text = "Problem Tespiti:";
			// 
			// label18
			// 
			label18.AutoSize = true;
			label18.Location = new System.Drawing.Point(51, 157);
			label18.Name = "label18";
			label18.Size = new System.Drawing.Size(48, 13);
			label18.TabIndex = 18;
			label18.Text = "Aksiyon:";
			// 
			// label19
			// 
			label19.AutoSize = true;
			label19.Location = new System.Drawing.Point(357, 40);
			label19.Name = "label19";
			label19.Size = new System.Drawing.Size(98, 13);
			label19.TabIndex = 20;
			label19.Text = "Servis Talep Tarihi:";
			// 
			// label13
			// 
			label13.AutoSize = true;
			label13.Location = new System.Drawing.Point(39, 119);
			label13.Name = "label13";
			label13.Size = new System.Drawing.Size(61, 13);
			label13.TabIndex = 48;
			label13.Text = "GPS Enlem:";
			// 
			// label20
			// 
			label20.AutoSize = true;
			label20.Location = new System.Drawing.Point(385, 119);
			label20.Name = "label20";
			label20.Size = new System.Drawing.Size(67, 13);
			label20.TabIndex = 50;
			label20.Text = "GPS Boylam:";
			// 
			// bELGENLabel
			// 
			bELGENLabel.AutoSize = true;
			bELGENLabel.Location = new System.Drawing.Point(25, 71);
			bELGENLabel.Name = "bELGENLabel";
			bELGENLabel.Size = new System.Drawing.Size(53, 13);
			bELGENLabel.TabIndex = 18;
			bELGENLabel.Text = "Belge No:";
			// 
			// eTARIHLabel
			// 
			eTARIHLabel.AutoSize = true;
			eTARIHLabel.Location = new System.Drawing.Point(25, 44);
			eTARIHLabel.Name = "eTARIHLabel";
			eTARIHLabel.Size = new System.Drawing.Size(66, 13);
			eTARIHLabel.TabIndex = 15;
			eTARIHLabel.Text = "Talep Tarihi:";
			// 
			// sTFYNOLabel
			// 
			sTFYNOLabel.AutoSize = true;
			sTFYNOLabel.Location = new System.Drawing.Point(25, 17);
			sTFYNOLabel.Name = "sTFYNOLabel";
			sTFYNOLabel.Size = new System.Drawing.Size(83, 13);
			sTFYNOLabel.TabIndex = 13;
			sTFYNOLabel.Text = "Tamamlananlar:";
			// 
			// xtraTabControl1
			// 
			this.xtraTabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraTabControl1.Location = new System.Drawing.Point(0, 24);
			this.xtraTabControl1.Name = "xtraTabControl1";
			this.xtraTabControl1.SelectedTabPage = this.xtraTabPage1;
			this.xtraTabControl1.Size = new System.Drawing.Size(1077, 736);
			this.xtraTabControl1.TabIndex = 4;
			this.xtraTabControl1.TabPages.AddRange(new DevExpress.XtraTab.XtraTabPage[] {
            this.xtraTabPage1,
            this.xtraTabPage2,
            this.xtraTabPage3});
			this.xtraTabControl1.SelectedPageChanged += new DevExpress.XtraTab.TabPageChangedEventHandler(this.xtraTabControl1_SelectedPageChanged);
			// 
			// xtraTabPage1
			// 
			this.xtraTabPage1.Controls.Add(this.chkTamamlanan);
			this.xtraTabPage1.Controls.Add(this.btnServisAra);
			this.xtraTabPage1.Controls.Add(bELGENLabel);
			this.xtraTabPage1.Controls.Add(this.bELGENTextEdit);
			this.xtraTabPage1.Controls.Add(this.dtBitis);
			this.xtraTabPage1.Controls.Add(this.dtBaslangic);
			this.xtraTabPage1.Controls.Add(eTARIHLabel);
			this.xtraTabPage1.Controls.Add(sTFYNOLabel);
			this.xtraTabPage1.Name = "xtraTabPage1";
			this.xtraTabPage1.Size = new System.Drawing.Size(1075, 711);
			this.xtraTabPage1.Text = "xtraTabPage1";
			// 
			// chkTamamlanan
			// 
			this.chkTamamlanan.AutoSize = true;
			this.chkTamamlanan.Location = new System.Drawing.Point(139, 18);
			this.chkTamamlanan.Name = "chkTamamlanan";
			this.chkTamamlanan.Size = new System.Drawing.Size(15, 14);
			this.chkTamamlanan.TabIndex = 21;
			this.chkTamamlanan.UseVisualStyleBackColor = true;
			// 
			// btnServisAra
			// 
			this.btnServisAra.Location = new System.Drawing.Point(139, 103);
			this.btnServisAra.Name = "btnServisAra";
			this.btnServisAra.Size = new System.Drawing.Size(75, 24);
			this.btnServisAra.TabIndex = 20;
			this.btnServisAra.Text = "ARA";
			this.btnServisAra.Click += new System.EventHandler(this.btnServisAra_Click);
			// 
			// bELGENTextEdit
			// 
			this.bELGENTextEdit.Location = new System.Drawing.Point(139, 68);
			this.bELGENTextEdit.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.bELGENTextEdit.MenuManager = this.barManager;
			this.bELGENTextEdit.Name = "bELGENTextEdit";
			this.bELGENTextEdit.Size = new System.Drawing.Size(131, 20);
			this.bELGENTextEdit.TabIndex = 19;
			// 
			// dtBitis
			// 
			this.dtBitis.EditValue = null;
			this.dtBitis.Location = new System.Drawing.Point(273, 41);
			this.dtBitis.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.dtBitis.MenuManager = this.barManager;
			this.dtBitis.Name = "dtBitis";
			this.dtBitis.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBitis.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBitis.Size = new System.Drawing.Size(125, 20);
			this.dtBitis.TabIndex = 17;
			// 
			// dtBaslangic
			// 
			this.dtBaslangic.EditValue = null;
			this.dtBaslangic.Location = new System.Drawing.Point(139, 41);
			this.dtBaslangic.Margin = new System.Windows.Forms.Padding(3, 1, 3, 1);
			this.dtBaslangic.MenuManager = this.barManager;
			this.dtBaslangic.Name = "dtBaslangic";
			this.dtBaslangic.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBaslangic.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dtBaslangic.Size = new System.Drawing.Size(131, 20);
			this.dtBaslangic.TabIndex = 16;
			// 
			// xtraTabPage2
			// 
			this.xtraTabPage2.Controls.Add(this.gridControl1);
			this.xtraTabPage2.Name = "xtraTabPage2";
			this.xtraTabPage2.Size = new System.Drawing.Size(1075, 711);
			this.xtraTabPage2.Text = "xtraTabPage2";
			// 
			// gridControl1
			// 
			this.gridControl1.DataSource = this.sHSRVSBindingSource;
			this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.gridControl1.Location = new System.Drawing.Point(0, 0);
			this.gridControl1.MainView = this.gridView1;
			this.gridControl1.Name = "gridControl1";
			this.gridControl1.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repGrdLkedCari,
            this.repGrdLkedKategori,
            this.repGrdLkedServisTuru,
            this.repGrdLkedServisDurumu,
            this.repGrdLkedPersonel,
            this.repGrdLkedUrunModel});
			this.gridControl1.Size = new System.Drawing.Size(1075, 711);
			this.gridControl1.TabIndex = 6;
			this.gridControl1.Tag = "201";
			this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
			this.gridControl1.DoubleClick += new System.EventHandler(this.gridControl1_DoubleClick);
			// 
			// sHSRVSBindingSource
			// 
			this.sHSRVSBindingSource.DataSource = typeof(Bps.BpsBase.Entities.Concrete.SH.SHSRVS);
			// 
			// gridView1
			// 
			this.gridView1.AppearancePrint.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
			this.gridView1.AppearancePrint.EvenRow.Options.UseBackColor = true;
			this.gridView1.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.colId,
            this.colSRTLTR,
            this.colBELGEN,
            this.colBELTRH,
            this.colCRKODU,
            this.colTLPACN,
            this.colURKTGR,
            this.colURMODL,
            this.colSRVTUR,
            this.colSRVDRM,
            this.colGRNDRM,
            this.colMKNDRM,
            this.colMKKRTR,
            this.colSRPRID,
            this.colURSERI,
            this.colURSASI,
            this.colPRBTNM,
            this.colPRBTSP,
            this.colAKSYON,
            this.colONYLYN,
            this.colSRBSTR,
            this.colSRBTTR,
            this.colSIRKID,
            this.colACTIVE,
            this.colSLINDI,
            this.colEKKULL,
            this.colETARIH,
            this.colDEKULL,
            this.colDTARIH,
            this.colKYNKKD,
            this.colCHKCTR});
			this.gridView1.DetailHeight = 182;
			this.gridView1.GridControl = this.gridControl1;
			this.gridView1.LevelIndent = 0;
			this.gridView1.Name = "gridView1";
			this.gridView1.OptionsBehavior.Editable = false;
			this.gridView1.OptionsPrint.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView1.OptionsView.ShowGroupPanel = false;
			this.gridView1.PreviewIndent = 0;
			// 
			// colId
			// 
			this.colId.FieldName = "Id";
			this.colId.Name = "colId";
			// 
			// colSRTLTR
			// 
			this.colSRTLTR.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
			this.colSRTLTR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colSRTLTR.FieldName = "SRTLTR";
			this.colSRTLTR.Name = "colSRTLTR";
			this.colSRTLTR.Visible = true;
			this.colSRTLTR.VisibleIndex = 0;
			this.colSRTLTR.Width = 96;
			// 
			// colBELGEN
			// 
			this.colBELGEN.FieldName = "BELGEN";
			this.colBELGEN.Name = "colBELGEN";
			this.colBELGEN.Visible = true;
			this.colBELGEN.VisibleIndex = 1;
			this.colBELGEN.Width = 86;
			// 
			// colBELTRH
			// 
			this.colBELTRH.FieldName = "BELTRH";
			this.colBELTRH.Name = "colBELTRH";
			this.colBELTRH.Visible = true;
			this.colBELTRH.VisibleIndex = 2;
			this.colBELTRH.Width = 86;
			// 
			// colCRKODU
			// 
			this.colCRKODU.Caption = "Müşteri";
			this.colCRKODU.ColumnEdit = this.repGrdLkedCari;
			this.colCRKODU.FieldName = "CRKODU";
			this.colCRKODU.Name = "colCRKODU";
			this.colCRKODU.Visible = true;
			this.colCRKODU.VisibleIndex = 3;
			this.colCRKODU.Width = 86;
			// 
			// repGrdLkedCari
			// 
			this.repGrdLkedCari.AutoHeight = false;
			this.repGrdLkedCari.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repGrdLkedCari.DisplayMember = "CRUNV1";
			this.repGrdLkedCari.Name = "repGrdLkedCari";
			this.repGrdLkedCari.NullText = "";
			this.repGrdLkedCari.PopupView = this.repositoryItemGridLookUpEdit1View;
			this.repGrdLkedCari.ValueMember = "CRKODU";
			// 
			// repositoryItemGridLookUpEdit1View
			// 
			this.repositoryItemGridLookUpEdit1View.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn23,
            this.gridColumn24});
			this.repositoryItemGridLookUpEdit1View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.repositoryItemGridLookUpEdit1View.Name = "repositoryItemGridLookUpEdit1View";
			this.repositoryItemGridLookUpEdit1View.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.repositoryItemGridLookUpEdit1View.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn23
			// 
			this.gridColumn23.Caption = "CariKodu";
			this.gridColumn23.FieldName = "CRKODU";
			this.gridColumn23.Name = "gridColumn23";
			this.gridColumn23.Visible = true;
			this.gridColumn23.VisibleIndex = 0;
			// 
			// gridColumn24
			// 
			this.gridColumn24.Caption = "Cari Adı";
			this.gridColumn24.FieldName = "CRUNV1";
			this.gridColumn24.Name = "gridColumn24";
			this.gridColumn24.Visible = true;
			this.gridColumn24.VisibleIndex = 1;
			// 
			// colTLPACN
			// 
			this.colTLPACN.FieldName = "TLPACN";
			this.colTLPACN.Name = "colTLPACN";
			this.colTLPACN.Visible = true;
			this.colTLPACN.VisibleIndex = 4;
			this.colTLPACN.Width = 86;
			// 
			// colURKTGR
			// 
			this.colURKTGR.ColumnEdit = this.repGrdLkedKategori;
			this.colURKTGR.FieldName = "URKTGR";
			this.colURKTGR.Name = "colURKTGR";
			this.colURKTGR.Visible = true;
			this.colURKTGR.VisibleIndex = 5;
			this.colURKTGR.Width = 86;
			// 
			// repGrdLkedKategori
			// 
			this.repGrdLkedKategori.AutoHeight = false;
			this.repGrdLkedKategori.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repGrdLkedKategori.DisplayMember = "TIPADI";
			this.repGrdLkedKategori.Name = "repGrdLkedKategori";
			this.repGrdLkedKategori.NullText = "";
			this.repGrdLkedKategori.PopupView = this.gridView8;
			this.repGrdLkedKategori.ValueMember = "TIPKOD";
			// 
			// gridView8
			// 
			this.gridView8.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn25,
            this.gridColumn32});
			this.gridView8.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView8.Name = "gridView8";
			this.gridView8.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView8.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn25
			// 
			this.gridColumn25.Caption = "Kod";
			this.gridColumn25.FieldName = "TIPKOD";
			this.gridColumn25.Name = "gridColumn25";
			this.gridColumn25.Visible = true;
			this.gridColumn25.VisibleIndex = 0;
			// 
			// gridColumn32
			// 
			this.gridColumn32.Caption = "Tanım";
			this.gridColumn32.FieldName = "TIPADI";
			this.gridColumn32.Name = "gridColumn32";
			this.gridColumn32.Visible = true;
			this.gridColumn32.VisibleIndex = 1;
			// 
			// colURMODL
			// 
			this.colURMODL.ColumnEdit = this.repGrdLkedUrunModel;
			this.colURMODL.FieldName = "URMODL";
			this.colURMODL.Name = "colURMODL";
			this.colURMODL.OptionsColumn.AllowEdit = false;
			this.colURMODL.OptionsColumn.ReadOnly = true;
			this.colURMODL.Visible = true;
			this.colURMODL.VisibleIndex = 6;
			this.colURMODL.Width = 86;
			// 
			// repGrdLkedUrunModel
			// 
			this.repGrdLkedUrunModel.AutoHeight = false;
			this.repGrdLkedUrunModel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repGrdLkedUrunModel.DisplayMember = "TANIMI";
			this.repGrdLkedUrunModel.Name = "repGrdLkedUrunModel";
			this.repGrdLkedUrunModel.NullText = "";
			this.repGrdLkedUrunModel.PopupView = this.gridView7;
			this.repGrdLkedUrunModel.ValueMember = "HARKOD";
			// 
			// gridView7
			// 
			this.gridView7.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn20,
            this.gridColumn21});
			this.gridView7.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView7.Name = "gridView7";
			this.gridView7.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView7.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn20
			// 
			this.gridColumn20.Caption = "Kod";
			this.gridColumn20.FieldName = "HARKOD";
			this.gridColumn20.Name = "gridColumn20";
			this.gridColumn20.Visible = true;
			this.gridColumn20.VisibleIndex = 0;
			// 
			// gridColumn21
			// 
			this.gridColumn21.Caption = "Tanım";
			this.gridColumn21.FieldName = "TANIMI";
			this.gridColumn21.Name = "gridColumn21";
			this.gridColumn21.Visible = true;
			this.gridColumn21.VisibleIndex = 1;
			// 
			// colSRVTUR
			// 
			this.colSRVTUR.ColumnEdit = this.repGrdLkedServisTuru;
			this.colSRVTUR.FieldName = "SRVTUR";
			this.colSRVTUR.Name = "colSRVTUR";
			this.colSRVTUR.Visible = true;
			this.colSRVTUR.VisibleIndex = 7;
			this.colSRVTUR.Width = 86;
			// 
			// repGrdLkedServisTuru
			// 
			this.repGrdLkedServisTuru.AutoHeight = false;
			this.repGrdLkedServisTuru.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repGrdLkedServisTuru.DisplayMember = "TANIMI";
			this.repGrdLkedServisTuru.Name = "repGrdLkedServisTuru";
			this.repGrdLkedServisTuru.NullText = "";
			this.repGrdLkedServisTuru.PopupView = this.gridView11;
			this.repGrdLkedServisTuru.ValueMember = "HARKOD";
			// 
			// gridView11
			// 
			this.gridView11.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn33,
            this.gridColumn34});
			this.gridView11.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView11.Name = "gridView11";
			this.gridView11.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView11.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn33
			// 
			this.gridColumn33.Caption = "Kod";
			this.gridColumn33.FieldName = "HARKOD";
			this.gridColumn33.Name = "gridColumn33";
			this.gridColumn33.Visible = true;
			this.gridColumn33.VisibleIndex = 0;
			// 
			// gridColumn34
			// 
			this.gridColumn34.Caption = "Tanım";
			this.gridColumn34.FieldName = "TANIMI";
			this.gridColumn34.Name = "gridColumn34";
			this.gridColumn34.Visible = true;
			this.gridColumn34.VisibleIndex = 1;
			// 
			// colSRVDRM
			// 
			this.colSRVDRM.ColumnEdit = this.repGrdLkedServisDurumu;
			this.colSRVDRM.FieldName = "SRVDRM";
			this.colSRVDRM.Name = "colSRVDRM";
			this.colSRVDRM.Visible = true;
			this.colSRVDRM.VisibleIndex = 8;
			this.colSRVDRM.Width = 86;
			// 
			// repGrdLkedServisDurumu
			// 
			this.repGrdLkedServisDurumu.AutoHeight = false;
			this.repGrdLkedServisDurumu.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repGrdLkedServisDurumu.DisplayMember = "TANIMI";
			this.repGrdLkedServisDurumu.Name = "repGrdLkedServisDurumu";
			this.repGrdLkedServisDurumu.NullText = "";
			this.repGrdLkedServisDurumu.PopupView = this.gridView12;
			this.repGrdLkedServisDurumu.ValueMember = "HARKOD";
			// 
			// gridView12
			// 
			this.gridView12.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn35,
            this.gridColumn36});
			this.gridView12.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView12.Name = "gridView12";
			this.gridView12.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView12.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn35
			// 
			this.gridColumn35.Caption = "Kod";
			this.gridColumn35.FieldName = "HARKOD";
			this.gridColumn35.Name = "gridColumn35";
			this.gridColumn35.Visible = true;
			this.gridColumn35.VisibleIndex = 0;
			// 
			// gridColumn36
			// 
			this.gridColumn36.Caption = "Tanım";
			this.gridColumn36.FieldName = "TANIMI";
			this.gridColumn36.Name = "gridColumn36";
			this.gridColumn36.Visible = true;
			this.gridColumn36.VisibleIndex = 1;
			// 
			// colGRNDRM
			// 
			this.colGRNDRM.FieldName = "GRNDRM";
			this.colGRNDRM.Name = "colGRNDRM";
			// 
			// colMKNDRM
			// 
			this.colMKNDRM.FieldName = "MKNDRM";
			this.colMKNDRM.Name = "colMKNDRM";
			// 
			// colMKKRTR
			// 
			this.colMKKRTR.FieldName = "MKKRTR";
			this.colMKKRTR.Name = "colMKKRTR";
			// 
			// colSRPRID
			// 
			this.colSRPRID.ColumnEdit = this.repGrdLkedPersonel;
			this.colSRPRID.FieldName = "SRPRID";
			this.colSRPRID.Name = "colSRPRID";
			this.colSRPRID.Visible = true;
			this.colSRPRID.VisibleIndex = 9;
			this.colSRPRID.Width = 86;
			// 
			// repGrdLkedPersonel
			// 
			this.repGrdLkedPersonel.AutoHeight = false;
			this.repGrdLkedPersonel.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repGrdLkedPersonel.DisplayMember = "GNNAME";
			this.repGrdLkedPersonel.Name = "repGrdLkedPersonel";
			this.repGrdLkedPersonel.NullText = "";
			this.repGrdLkedPersonel.PopupView = this.gridView13;
			this.repGrdLkedPersonel.ValueMember = "Id";
			// 
			// gridView13
			// 
			this.gridView13.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn37,
            this.gridColumn38});
			this.gridView13.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView13.Name = "gridView13";
			this.gridView13.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView13.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn37
			// 
			this.gridColumn37.Caption = "Id";
			this.gridColumn37.FieldName = "Id";
			this.gridColumn37.Name = "gridColumn37";
			this.gridColumn37.Visible = true;
			this.gridColumn37.VisibleIndex = 0;
			// 
			// gridColumn38
			// 
			this.gridColumn38.Caption = "Ad Soyad";
			this.gridColumn38.FieldName = "GNNAME";
			this.gridColumn38.Name = "gridColumn38";
			this.gridColumn38.Visible = true;
			this.gridColumn38.VisibleIndex = 1;
			// 
			// colURSERI
			// 
			this.colURSERI.FieldName = "URSERI";
			this.colURSERI.Name = "colURSERI";
			// 
			// colURSASI
			// 
			this.colURSASI.FieldName = "URSASI";
			this.colURSASI.Name = "colURSASI";
			// 
			// colPRBTNM
			// 
			this.colPRBTNM.FieldName = "PRBTNM";
			this.colPRBTNM.Name = "colPRBTNM";
			// 
			// colPRBTSP
			// 
			this.colPRBTSP.FieldName = "PRBTSP";
			this.colPRBTSP.Name = "colPRBTSP";
			// 
			// colAKSYON
			// 
			this.colAKSYON.FieldName = "AKSYON";
			this.colAKSYON.Name = "colAKSYON";
			// 
			// colONYLYN
			// 
			this.colONYLYN.FieldName = "ONYLYN";
			this.colONYLYN.Name = "colONYLYN";
			// 
			// colSRBSTR
			// 
			this.colSRBSTR.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
			this.colSRBSTR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colSRBSTR.FieldName = "SRBSTR";
			this.colSRBSTR.Name = "colSRBSTR";
			this.colSRBSTR.Visible = true;
			this.colSRBSTR.VisibleIndex = 10;
			this.colSRBSTR.Width = 86;
			// 
			// colSRBTTR
			// 
			this.colSRBTTR.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm";
			this.colSRBTTR.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.colSRBTTR.FieldName = "SRBTTR";
			this.colSRBTTR.Name = "colSRBTTR";
			this.colSRBTTR.Visible = true;
			this.colSRBTTR.VisibleIndex = 11;
			this.colSRBTTR.Width = 94;
			// 
			// colSIRKID
			// 
			this.colSIRKID.FieldName = "SIRKID";
			this.colSIRKID.Name = "colSIRKID";
			// 
			// colACTIVE
			// 
			this.colACTIVE.FieldName = "ACTIVE";
			this.colACTIVE.Name = "colACTIVE";
			// 
			// colSLINDI
			// 
			this.colSLINDI.FieldName = "SLINDI";
			this.colSLINDI.Name = "colSLINDI";
			// 
			// colEKKULL
			// 
			this.colEKKULL.FieldName = "EKKULL";
			this.colEKKULL.Name = "colEKKULL";
			// 
			// colETARIH
			// 
			this.colETARIH.FieldName = "ETARIH";
			this.colETARIH.Name = "colETARIH";
			// 
			// colDEKULL
			// 
			this.colDEKULL.FieldName = "DEKULL";
			this.colDEKULL.Name = "colDEKULL";
			// 
			// colDTARIH
			// 
			this.colDTARIH.FieldName = "DTARIH";
			this.colDTARIH.Name = "colDTARIH";
			// 
			// colKYNKKD
			// 
			this.colKYNKKD.FieldName = "KYNKKD";
			this.colKYNKKD.Name = "colKYNKKD";
			// 
			// colCHKCTR
			// 
			this.colCHKCTR.FieldName = "CHKCTR";
			this.colCHKCTR.Name = "colCHKCTR";
			// 
			// xtraTabPage3
			// 
			this.xtraTabPage3.Controls.Add(this.xtraScrollableControl1);
			this.xtraTabPage3.Name = "xtraTabPage3";
			this.xtraTabPage3.Size = new System.Drawing.Size(1075, 711);
			this.xtraTabPage3.Text = "xtraTabPage3";
			// 
			// xtraScrollableControl1
			// 
			this.xtraScrollableControl1.Controls.Add(this.groupControl5);
			this.xtraScrollableControl1.Controls.Add(this.groupControl4);
			this.xtraScrollableControl1.Controls.Add(this.groupControl3);
			this.xtraScrollableControl1.Controls.Add(this.groupControl2);
			this.xtraScrollableControl1.Controls.Add(this.groupControl1);
			this.xtraScrollableControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.xtraScrollableControl1.Location = new System.Drawing.Point(0, 0);
			this.xtraScrollableControl1.Name = "xtraScrollableControl1";
			this.xtraScrollableControl1.Size = new System.Drawing.Size(1075, 711);
			this.xtraScrollableControl1.TabIndex = 1;
			// 
			// groupControl5
			// 
			this.groupControl5.Controls.Add(this.grdIslemSure);
			this.groupControl5.Location = new System.Drawing.Point(728, 16);
			this.groupControl5.Name = "groupControl5";
			this.groupControl5.Size = new System.Drawing.Size(325, 684);
			this.groupControl5.TabIndex = 4;
			this.groupControl5.Text = "Süre Ayrıntıları";
			// 
			// grdIslemSure
			// 
			this.grdIslemSure.Dock = System.Windows.Forms.DockStyle.Fill;
			this.grdIslemSure.Location = new System.Drawing.Point(2, 23);
			this.grdIslemSure.MainView = this.grdVwIslemSure;
			this.grdIslemSure.Name = "grdIslemSure";
			this.grdIslemSure.RepositoryItems.AddRange(new DevExpress.XtraEditors.Repository.RepositoryItem[] {
            this.repositoryItemGridLookUpEdit1,
            this.repositoryItemGridLookUpEdit2,
            this.repositoryItemGridLookUpEdit4,
            this.repositoryItemGridLookUpEdit5,
            this.repositoryItemGridLookUpEdit6,
            this.repositoryItemGridLookUpEdit3});
			this.grdIslemSure.Size = new System.Drawing.Size(321, 659);
			this.grdIslemSure.TabIndex = 7;
			this.grdIslemSure.Tag = "201";
			this.grdIslemSure.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.grdVwIslemSure});
			// 
			// grdVwIslemSure
			// 
			this.grdVwIslemSure.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn22,
            this.gridColumn39,
            this.gridColumn40,
            this.gridColumn41});
			this.grdVwIslemSure.DetailHeight = 182;
			this.grdVwIslemSure.GridControl = this.grdIslemSure;
			this.grdVwIslemSure.LevelIndent = 0;
			this.grdVwIslemSure.Name = "grdVwIslemSure";
			this.grdVwIslemSure.OptionsBehavior.Editable = false;
			this.grdVwIslemSure.OptionsCustomization.AllowSort = false;
			this.grdVwIslemSure.OptionsView.EnableAppearanceEvenRow = true;
			this.grdVwIslemSure.OptionsView.ShowFooter = true;
			this.grdVwIslemSure.OptionsView.ShowGroupPanel = false;
			this.grdVwIslemSure.PreviewIndent = 0;
			// 
			// gridColumn22
			// 
			this.gridColumn22.Caption = "Kod";
			this.gridColumn22.FieldName = "ACCODE";
			this.gridColumn22.Name = "gridColumn22";
			// 
			// gridColumn39
			// 
			this.gridColumn39.Caption = "İşlem";
			this.gridColumn39.FieldName = "ACTION";
			this.gridColumn39.Name = "gridColumn39";
			this.gridColumn39.Visible = true;
			this.gridColumn39.VisibleIndex = 0;
			// 
			// gridColumn40
			// 
			this.gridColumn40.Caption = "Tarih-Saat";
			this.gridColumn40.DisplayFormat.FormatString = "dd.MM.yyyy HH:mm:ss";
			this.gridColumn40.DisplayFormat.FormatType = DevExpress.Utils.FormatType.DateTime;
			this.gridColumn40.FieldName = "TMSTMP";
			this.gridColumn40.Name = "gridColumn40";
			this.gridColumn40.Visible = true;
			this.gridColumn40.VisibleIndex = 1;
			// 
			// gridColumn41
			// 
			this.gridColumn41.Caption = "Toplam Dakika";
			this.gridColumn41.FieldName = "TOPDAK";
			this.gridColumn41.Name = "gridColumn41";
			this.gridColumn41.Summary.AddRange(new DevExpress.XtraGrid.GridSummaryItem[] {
            new DevExpress.XtraGrid.GridColumnSummaryItem(DevExpress.Data.SummaryItemType.Sum, "TOPDAK", "{0:0.##}")});
			this.gridColumn41.Visible = true;
			this.gridColumn41.VisibleIndex = 2;
			// 
			// repositoryItemGridLookUpEdit1
			// 
			this.repositoryItemGridLookUpEdit1.AutoHeight = false;
			this.repositoryItemGridLookUpEdit1.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit1.DisplayMember = "CRUNV1";
			this.repositoryItemGridLookUpEdit1.Name = "repositoryItemGridLookUpEdit1";
			this.repositoryItemGridLookUpEdit1.NullText = "";
			this.repositoryItemGridLookUpEdit1.PopupView = this.gridView16;
			this.repositoryItemGridLookUpEdit1.ValueMember = "CRKODU";
			// 
			// gridView16
			// 
			this.gridView16.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn43,
            this.gridColumn44});
			this.gridView16.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView16.Name = "gridView16";
			this.gridView16.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView16.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn43
			// 
			this.gridColumn43.Caption = "CariKodu";
			this.gridColumn43.FieldName = "CRKODU";
			this.gridColumn43.Name = "gridColumn43";
			this.gridColumn43.Visible = true;
			this.gridColumn43.VisibleIndex = 0;
			// 
			// gridColumn44
			// 
			this.gridColumn44.Caption = "Cari Adı";
			this.gridColumn44.FieldName = "CRUNV1";
			this.gridColumn44.Name = "gridColumn44";
			this.gridColumn44.Visible = true;
			this.gridColumn44.VisibleIndex = 1;
			// 
			// repositoryItemGridLookUpEdit2
			// 
			this.repositoryItemGridLookUpEdit2.AutoHeight = false;
			this.repositoryItemGridLookUpEdit2.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit2.DisplayMember = "TIPADI";
			this.repositoryItemGridLookUpEdit2.Name = "repositoryItemGridLookUpEdit2";
			this.repositoryItemGridLookUpEdit2.NullText = "";
			this.repositoryItemGridLookUpEdit2.PopupView = this.gridView15;
			this.repositoryItemGridLookUpEdit2.ValueMember = "TIPKOD";
			// 
			// gridView15
			// 
			this.gridView15.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn47,
            this.gridColumn48});
			this.gridView15.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView15.Name = "gridView15";
			this.gridView15.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView15.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn47
			// 
			this.gridColumn47.Caption = "Kod";
			this.gridColumn47.FieldName = "TIPKOD";
			this.gridColumn47.Name = "gridColumn47";
			this.gridColumn47.Visible = true;
			this.gridColumn47.VisibleIndex = 0;
			// 
			// gridColumn48
			// 
			this.gridColumn48.Caption = "Tanım";
			this.gridColumn48.FieldName = "TIPADI";
			this.gridColumn48.Name = "gridColumn48";
			this.gridColumn48.Visible = true;
			this.gridColumn48.VisibleIndex = 1;
			// 
			// repositoryItemGridLookUpEdit4
			// 
			this.repositoryItemGridLookUpEdit4.AutoHeight = false;
			this.repositoryItemGridLookUpEdit4.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit4.DisplayMember = "TANIMI";
			this.repositoryItemGridLookUpEdit4.Name = "repositoryItemGridLookUpEdit4";
			this.repositoryItemGridLookUpEdit4.NullText = "";
			this.repositoryItemGridLookUpEdit4.PopupView = this.gridView18;
			this.repositoryItemGridLookUpEdit4.ValueMember = "HARKOD";
			// 
			// gridView18
			// 
			this.gridView18.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn53,
            this.gridColumn54});
			this.gridView18.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView18.Name = "gridView18";
			this.gridView18.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView18.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn53
			// 
			this.gridColumn53.Caption = "Kod";
			this.gridColumn53.FieldName = "HARKOD";
			this.gridColumn53.Name = "gridColumn53";
			this.gridColumn53.Visible = true;
			this.gridColumn53.VisibleIndex = 0;
			// 
			// gridColumn54
			// 
			this.gridColumn54.Caption = "Tanım";
			this.gridColumn54.FieldName = "TANIMI";
			this.gridColumn54.Name = "gridColumn54";
			this.gridColumn54.Visible = true;
			this.gridColumn54.VisibleIndex = 1;
			// 
			// repositoryItemGridLookUpEdit5
			// 
			this.repositoryItemGridLookUpEdit5.AutoHeight = false;
			this.repositoryItemGridLookUpEdit5.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit5.DisplayMember = "TANIMI";
			this.repositoryItemGridLookUpEdit5.Name = "repositoryItemGridLookUpEdit5";
			this.repositoryItemGridLookUpEdit5.NullText = "";
			this.repositoryItemGridLookUpEdit5.PopupView = this.gridView19;
			this.repositoryItemGridLookUpEdit5.ValueMember = "HARKOD";
			// 
			// gridView19
			// 
			this.gridView19.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn56,
            this.gridColumn57});
			this.gridView19.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView19.Name = "gridView19";
			this.gridView19.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView19.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn56
			// 
			this.gridColumn56.Caption = "Kod";
			this.gridColumn56.FieldName = "HARKOD";
			this.gridColumn56.Name = "gridColumn56";
			this.gridColumn56.Visible = true;
			this.gridColumn56.VisibleIndex = 0;
			// 
			// gridColumn57
			// 
			this.gridColumn57.Caption = "Tanım";
			this.gridColumn57.FieldName = "TANIMI";
			this.gridColumn57.Name = "gridColumn57";
			this.gridColumn57.Visible = true;
			this.gridColumn57.VisibleIndex = 1;
			// 
			// repositoryItemGridLookUpEdit6
			// 
			this.repositoryItemGridLookUpEdit6.AutoHeight = false;
			this.repositoryItemGridLookUpEdit6.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit6.DisplayMember = "GNNAME";
			this.repositoryItemGridLookUpEdit6.Name = "repositoryItemGridLookUpEdit6";
			this.repositoryItemGridLookUpEdit6.NullText = "";
			this.repositoryItemGridLookUpEdit6.PopupView = this.gridView20;
			this.repositoryItemGridLookUpEdit6.ValueMember = "Id";
			// 
			// gridView20
			// 
			this.gridView20.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn62,
            this.gridColumn63});
			this.gridView20.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView20.Name = "gridView20";
			this.gridView20.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView20.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn62
			// 
			this.gridColumn62.Caption = "Id";
			this.gridColumn62.FieldName = "Id";
			this.gridColumn62.Name = "gridColumn62";
			this.gridColumn62.Visible = true;
			this.gridColumn62.VisibleIndex = 0;
			// 
			// gridColumn63
			// 
			this.gridColumn63.Caption = "Ad Soyad";
			this.gridColumn63.FieldName = "GNNAME";
			this.gridColumn63.Name = "gridColumn63";
			this.gridColumn63.Visible = true;
			this.gridColumn63.VisibleIndex = 1;
			// 
			// repositoryItemGridLookUpEdit3
			// 
			this.repositoryItemGridLookUpEdit3.AutoHeight = false;
			this.repositoryItemGridLookUpEdit3.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.repositoryItemGridLookUpEdit3.DisplayMember = "TANIMI";
			this.repositoryItemGridLookUpEdit3.Name = "repositoryItemGridLookUpEdit3";
			this.repositoryItemGridLookUpEdit3.NullText = "";
			this.repositoryItemGridLookUpEdit3.PopupView = this.gridView17;
			this.repositoryItemGridLookUpEdit3.ValueMember = "HARKOD";
			// 
			// gridView17
			// 
			this.gridView17.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn50,
            this.gridColumn51});
			this.gridView17.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView17.Name = "gridView17";
			this.gridView17.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView17.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn50
			// 
			this.gridColumn50.Caption = "Kod";
			this.gridColumn50.FieldName = "HARKOD";
			this.gridColumn50.Name = "gridColumn50";
			this.gridColumn50.Visible = true;
			this.gridColumn50.VisibleIndex = 0;
			// 
			// gridColumn51
			// 
			this.gridColumn51.Caption = "Tanım";
			this.gridColumn51.FieldName = "TANIMI";
			this.gridColumn51.Name = "gridColumn51";
			this.gridColumn51.Visible = true;
			this.gridColumn51.VisibleIndex = 1;
			// 
			// groupControl4
			// 
			this.groupControl4.Controls.Add(this.btnWord);
			this.groupControl4.Controls.Add(this.pdfBut);
			this.groupControl4.Controls.Add(this.btnPdf);
			this.groupControl4.Controls.Add(label18);
			this.groupControl4.Controls.Add(this.memoAksiyon);
			this.groupControl4.Controls.Add(label16);
			this.groupControl4.Controls.Add(this.memoProblemTespit);
			this.groupControl4.Controls.Add(label17);
			this.groupControl4.Controls.Add(this.memoProblemTanim);
			this.groupControl4.Location = new System.Drawing.Point(11, 433);
			this.groupControl4.Name = "groupControl4";
			this.groupControl4.Size = new System.Drawing.Size(703, 267);
			this.groupControl4.TabIndex = 3;
			this.groupControl4.Text = "Detaylar";
			// 
			// btnWord
			// 
			this.btnWord.Location = new System.Drawing.Point(566, 239);
			this.btnWord.Name = "btnWord";
			this.btnWord.Size = new System.Drawing.Size(59, 23);
			this.btnWord.TabIndex = 21;
			this.btnWord.Text = "WORD";
			this.btnWord.Visible = false;
			this.btnWord.Click += new System.EventHandler(this.btnWord_Click);
			// 
			// pdfBut
			// 
			this.pdfBut.Location = new System.Drawing.Point(106, 239);
			this.pdfBut.Name = "pdfBut";
			this.pdfBut.Size = new System.Drawing.Size(59, 23);
			this.pdfBut.TabIndex = 20;
			this.pdfBut.Text = "PDF";
			this.pdfBut.Click += new System.EventHandler(this.pdfBut_Click);
			// 
			// btnPdf
			// 
			this.btnPdf.Location = new System.Drawing.Point(631, 239);
			this.btnPdf.Name = "btnPdf";
			this.btnPdf.Size = new System.Drawing.Size(59, 23);
			this.btnPdf.TabIndex = 19;
			this.btnPdf.Text = "PDF";
			this.btnPdf.Visible = false;
			this.btnPdf.Click += new System.EventHandler(this.btnPdf_Click);
			// 
			// memoAksiyon
			// 
			this.memoAksiyon.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "AKSYON", true));
			this.memoAksiyon.Location = new System.Drawing.Point(106, 155);
			this.memoAksiyon.MenuManager = this.barManager;
			this.memoAksiyon.Name = "memoAksiyon";
			this.memoAksiyon.Size = new System.Drawing.Size(584, 75);
			this.memoAksiyon.TabIndex = 17;
			// 
			// memoProblemTespit
			// 
			this.memoProblemTespit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "PRBTSP", true));
			this.memoProblemTespit.Location = new System.Drawing.Point(106, 96);
			this.memoProblemTespit.MenuManager = this.barManager;
			this.memoProblemTespit.Name = "memoProblemTespit";
			this.memoProblemTespit.Size = new System.Drawing.Size(584, 53);
			this.memoProblemTespit.TabIndex = 15;
			// 
			// memoProblemTanim
			// 
			this.memoProblemTanim.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "PRBTNM", true));
			this.memoProblemTanim.Location = new System.Drawing.Point(106, 37);
			this.memoProblemTanim.MenuManager = this.barManager;
			this.memoProblemTanim.Name = "memoProblemTanim";
			this.memoProblemTanim.Size = new System.Drawing.Size(584, 53);
			this.memoProblemTanim.TabIndex = 12;
			// 
			// groupControl3
			// 
			this.groupControl3.Controls.Add(label12);
			this.groupControl3.Controls.Add(label11);
			this.groupControl3.Controls.Add(this.txtSasiNo);
			this.groupControl3.Controls.Add(this.txtSeriNo);
			this.groupControl3.Controls.Add(label14);
			this.groupControl3.Controls.Add(this.grdLkedModel);
			this.groupControl3.Controls.Add(label15);
			this.groupControl3.Controls.Add(this.grdLkedKategori);
			this.groupControl3.Location = new System.Drawing.Point(11, 169);
			this.groupControl3.Name = "groupControl3";
			this.groupControl3.Size = new System.Drawing.Size(703, 99);
			this.groupControl3.TabIndex = 1;
			this.groupControl3.Text = "Ürün Bilgileri";
			// 
			// txtSasiNo
			// 
			this.txtSasiNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "URSASI", true));
			this.txtSasiNo.Location = new System.Drawing.Point(461, 63);
			this.txtSasiNo.MenuManager = this.barManager;
			this.txtSasiNo.Name = "txtSasiNo";
			this.txtSasiNo.Size = new System.Drawing.Size(229, 20);
			this.txtSasiNo.TabIndex = 13;
			// 
			// txtSeriNo
			// 
			this.txtSeriNo.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "URSERI", true));
			this.txtSeriNo.Location = new System.Drawing.Point(108, 63);
			this.txtSeriNo.MenuManager = this.barManager;
			this.txtSeriNo.Name = "txtSeriNo";
			this.txtSeriNo.Size = new System.Drawing.Size(230, 20);
			this.txtSeriNo.TabIndex = 12;
			// 
			// grdLkedModel
			// 
			this.grdLkedModel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "URMODL", true));
			this.grdLkedModel.Location = new System.Drawing.Point(461, 37);
			this.grdLkedModel.MenuManager = this.barManager;
			this.grdLkedModel.Name = "grdLkedModel";
			this.grdLkedModel.Properties.AllowMouseWheel = false;
			this.grdLkedModel.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
			this.grdLkedModel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.grdLkedModel.Properties.DisplayMember = "TANIMI";
			this.grdLkedModel.Properties.NullText = "";
			this.grdLkedModel.Properties.PopupView = this.gridView9;
			this.grdLkedModel.Properties.ValueMember = "HARKOD";
			this.grdLkedModel.Size = new System.Drawing.Size(229, 20);
			this.grdLkedModel.TabIndex = 11;
			// 
			// gridView9
			// 
			this.gridView9.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn26,
            this.gridColumn27,
            this.gridColumn28});
			this.gridView9.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView9.Name = "gridView9";
			this.gridView9.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView9.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView9.OptionsView.ShowAutoFilterRow = true;
			this.gridView9.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn26
			// 
			this.gridColumn26.Caption = "Id";
			this.gridColumn26.FieldName = "Id";
			this.gridColumn26.Name = "gridColumn26";
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
			this.gridColumn28.Caption = "Tanım";
			this.gridColumn28.FieldName = "TANIMI";
			this.gridColumn28.Name = "gridColumn28";
			this.gridColumn28.Visible = true;
			this.gridColumn28.VisibleIndex = 1;
			// 
			// grdLkedKategori
			// 
			this.grdLkedKategori.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "URKTGR", true));
			this.grdLkedKategori.Location = new System.Drawing.Point(108, 37);
			this.grdLkedKategori.MenuManager = this.barManager;
			this.grdLkedKategori.Name = "grdLkedKategori";
			this.grdLkedKategori.Properties.AllowMouseWheel = false;
			this.grdLkedKategori.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
			this.grdLkedKategori.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.grdLkedKategori.Properties.DisplayMember = "TIPADI";
			this.grdLkedKategori.Properties.NullText = "";
			this.grdLkedKategori.Properties.PopupView = this.gridView10;
			this.grdLkedKategori.Properties.ValueMember = "TIPKOD";
			this.grdLkedKategori.Size = new System.Drawing.Size(230, 20);
			this.grdLkedKategori.TabIndex = 9;
			this.grdLkedKategori.EditValueChanged += new System.EventHandler(this.grdLkedKategori_EditValueChanged);
			// 
			// gridView10
			// 
			this.gridView10.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn29,
            this.gridColumn30,
            this.gridColumn31});
			this.gridView10.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView10.Name = "gridView10";
			this.gridView10.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView10.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView10.OptionsView.ShowAutoFilterRow = true;
			this.gridView10.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn29
			// 
			this.gridColumn29.Caption = "Id";
			this.gridColumn29.FieldName = "Id";
			this.gridColumn29.Name = "gridColumn29";
			// 
			// gridColumn30
			// 
			this.gridColumn30.Caption = "Kod";
			this.gridColumn30.FieldName = "TIPKOD";
			this.gridColumn30.Name = "gridColumn30";
			this.gridColumn30.Visible = true;
			this.gridColumn30.VisibleIndex = 0;
			// 
			// gridColumn31
			// 
			this.gridColumn31.Caption = "Tanım";
			this.gridColumn31.FieldName = "TIPADI";
			this.gridColumn31.Name = "gridColumn31";
			this.gridColumn31.Visible = true;
			this.gridColumn31.VisibleIndex = 1;
			// 
			// groupControl2
			// 
			this.groupControl2.Controls.Add(this.timeEdit1);
			this.groupControl2.Controls.Add(label19);
			this.groupControl2.Controls.Add(this.dateServisTalep);
			this.groupControl2.Controls.Add(label10);
			this.groupControl2.Controls.Add(this.dateKurulum);
			this.groupControl2.Controls.Add(label9);
			this.groupControl2.Controls.Add(this.grdLkedMakineDurumu);
			this.groupControl2.Controls.Add(label8);
			this.groupControl2.Controls.Add(this.grdLkedGarantiDurumu);
			this.groupControl2.Controls.Add(label7);
			this.groupControl2.Controls.Add(this.grdLkedServisDurumu);
			this.groupControl2.Controls.Add(label6);
			this.groupControl2.Controls.Add(this.grdLkedServisTuru);
			this.groupControl2.Controls.Add(label4);
			this.groupControl2.Controls.Add(this.grdLkedServisPersonel);
			this.groupControl2.Controls.Add(this.cmbTalebiAcan);
			this.groupControl2.Controls.Add(label5);
			this.groupControl2.Location = new System.Drawing.Point(11, 279);
			this.groupControl2.Name = "groupControl2";
			this.groupControl2.Size = new System.Drawing.Size(703, 147);
			this.groupControl2.TabIndex = 2;
			this.groupControl2.Text = "Servis Bilgileri";
			// 
			// timeEdit1
			// 
			this.timeEdit1.EditValue = new System.DateTime(2024, 1, 12, 0, 0, 0, 0);
			this.timeEdit1.Location = new System.Drawing.Point(605, 37);
			this.timeEdit1.MenuManager = this.barManager;
			this.timeEdit1.Name = "timeEdit1";
			this.timeEdit1.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.timeEdit1.Size = new System.Drawing.Size(85, 20);
			this.timeEdit1.TabIndex = 21;
			// 
			// dateServisTalep
			// 
			this.dateServisTalep.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "SRTLTR", true));
			this.dateServisTalep.EditValue = null;
			this.dateServisTalep.Location = new System.Drawing.Point(461, 37);
			this.dateServisTalep.MenuManager = this.barManager;
			this.dateServisTalep.Name = "dateServisTalep";
			this.dateServisTalep.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateServisTalep.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateServisTalep.Size = new System.Drawing.Size(138, 20);
			this.dateServisTalep.TabIndex = 0;
			// 
			// dateKurulum
			// 
			this.dateKurulum.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "MKKRTR", true));
			this.dateKurulum.EditValue = null;
			this.dateKurulum.Location = new System.Drawing.Point(461, 116);
			this.dateKurulum.MenuManager = this.barManager;
			this.dateKurulum.Name = "dateKurulum";
			this.dateKurulum.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateKurulum.Properties.CalendarTimeProperties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.dateKurulum.Size = new System.Drawing.Size(138, 20);
			this.dateKurulum.TabIndex = 8;
			// 
			// grdLkedMakineDurumu
			// 
			this.grdLkedMakineDurumu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "MKNDRM", true));
			this.grdLkedMakineDurumu.Location = new System.Drawing.Point(461, 90);
			this.grdLkedMakineDurumu.MenuManager = this.barManager;
			this.grdLkedMakineDurumu.Name = "grdLkedMakineDurumu";
			this.grdLkedMakineDurumu.Properties.AllowMouseWheel = false;
			this.grdLkedMakineDurumu.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
			this.grdLkedMakineDurumu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.grdLkedMakineDurumu.Properties.DisplayMember = "TANIMI";
			this.grdLkedMakineDurumu.Properties.NullText = "";
			this.grdLkedMakineDurumu.Properties.PopupView = this.gridView6;
			this.grdLkedMakineDurumu.Properties.ValueMember = "HARKOD";
			this.grdLkedMakineDurumu.Size = new System.Drawing.Size(229, 20);
			this.grdLkedMakineDurumu.TabIndex = 6;
			// 
			// gridView6
			// 
			this.gridView6.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn17,
            this.gridColumn18,
            this.gridColumn19});
			this.gridView6.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView6.Name = "gridView6";
			this.gridView6.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView6.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView6.OptionsView.ShowAutoFilterRow = true;
			this.gridView6.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn17
			// 
			this.gridColumn17.Caption = "Id";
			this.gridColumn17.FieldName = "Id";
			this.gridColumn17.Name = "gridColumn17";
			// 
			// gridColumn18
			// 
			this.gridColumn18.Caption = "Kod";
			this.gridColumn18.FieldName = "HARKOD";
			this.gridColumn18.Name = "gridColumn18";
			this.gridColumn18.Visible = true;
			this.gridColumn18.VisibleIndex = 0;
			// 
			// gridColumn19
			// 
			this.gridColumn19.Caption = "Tanım";
			this.gridColumn19.FieldName = "TANIMI";
			this.gridColumn19.Name = "gridColumn19";
			this.gridColumn19.Visible = true;
			this.gridColumn19.VisibleIndex = 1;
			// 
			// grdLkedGarantiDurumu
			// 
			this.grdLkedGarantiDurumu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "GRNDRM", true));
			this.grdLkedGarantiDurumu.Location = new System.Drawing.Point(108, 115);
			this.grdLkedGarantiDurumu.MenuManager = this.barManager;
			this.grdLkedGarantiDurumu.Name = "grdLkedGarantiDurumu";
			this.grdLkedGarantiDurumu.Properties.AllowMouseWheel = false;
			this.grdLkedGarantiDurumu.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
			this.grdLkedGarantiDurumu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.grdLkedGarantiDurumu.Properties.DisplayMember = "TANIMI";
			this.grdLkedGarantiDurumu.Properties.NullText = "";
			this.grdLkedGarantiDurumu.Properties.PopupView = this.gridView5;
			this.grdLkedGarantiDurumu.Properties.ValueMember = "HARKOD";
			this.grdLkedGarantiDurumu.Size = new System.Drawing.Size(230, 20);
			this.grdLkedGarantiDurumu.TabIndex = 7;
			// 
			// gridView5
			// 
			this.gridView5.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn14,
            this.gridColumn15,
            this.gridColumn16});
			this.gridView5.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView5.Name = "gridView5";
			this.gridView5.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView5.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView5.OptionsView.ShowAutoFilterRow = true;
			this.gridView5.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn14
			// 
			this.gridColumn14.Caption = "Id";
			this.gridColumn14.FieldName = "Id";
			this.gridColumn14.Name = "gridColumn14";
			// 
			// gridColumn15
			// 
			this.gridColumn15.Caption = "Kod";
			this.gridColumn15.FieldName = "HARKOD";
			this.gridColumn15.Name = "gridColumn15";
			this.gridColumn15.Visible = true;
			this.gridColumn15.VisibleIndex = 0;
			// 
			// gridColumn16
			// 
			this.gridColumn16.Caption = "Tanım";
			this.gridColumn16.FieldName = "TANIMI";
			this.gridColumn16.Name = "gridColumn16";
			this.gridColumn16.Visible = true;
			this.gridColumn16.VisibleIndex = 1;
			// 
			// grdLkedServisDurumu
			// 
			this.grdLkedServisDurumu.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "SRVDRM", true));
			this.grdLkedServisDurumu.Enabled = false;
			this.grdLkedServisDurumu.Location = new System.Drawing.Point(108, 89);
			this.grdLkedServisDurumu.MenuManager = this.barManager;
			this.grdLkedServisDurumu.Name = "grdLkedServisDurumu";
			this.grdLkedServisDurumu.Properties.AllowMouseWheel = false;
			this.grdLkedServisDurumu.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
			this.grdLkedServisDurumu.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.grdLkedServisDurumu.Properties.DisplayMember = "TANIMI";
			this.grdLkedServisDurumu.Properties.NullText = "";
			this.grdLkedServisDurumu.Properties.PopupView = this.gridView4;
			this.grdLkedServisDurumu.Properties.ValueMember = "HARKOD";
			this.grdLkedServisDurumu.Size = new System.Drawing.Size(230, 20);
			this.grdLkedServisDurumu.TabIndex = 5;
			// 
			// gridView4
			// 
			this.gridView4.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn11,
            this.gridColumn12,
            this.gridColumn13});
			this.gridView4.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView4.Name = "gridView4";
			this.gridView4.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView4.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView4.OptionsView.ShowAutoFilterRow = true;
			this.gridView4.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn11
			// 
			this.gridColumn11.Caption = "Id";
			this.gridColumn11.FieldName = "Id";
			this.gridColumn11.Name = "gridColumn11";
			// 
			// gridColumn12
			// 
			this.gridColumn12.Caption = "Kod";
			this.gridColumn12.FieldName = "HARKOD";
			this.gridColumn12.Name = "gridColumn12";
			this.gridColumn12.Visible = true;
			this.gridColumn12.VisibleIndex = 0;
			// 
			// gridColumn13
			// 
			this.gridColumn13.Caption = "Tanım";
			this.gridColumn13.FieldName = "TANIMI";
			this.gridColumn13.Name = "gridColumn13";
			this.gridColumn13.Visible = true;
			this.gridColumn13.VisibleIndex = 1;
			// 
			// grdLkedServisTuru
			// 
			this.grdLkedServisTuru.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "SRVTUR", true));
			this.grdLkedServisTuru.Location = new System.Drawing.Point(108, 63);
			this.grdLkedServisTuru.MenuManager = this.barManager;
			this.grdLkedServisTuru.Name = "grdLkedServisTuru";
			this.grdLkedServisTuru.Properties.AllowMouseWheel = false;
			this.grdLkedServisTuru.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFit;
			this.grdLkedServisTuru.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.grdLkedServisTuru.Properties.DisplayMember = "TANIMI";
			this.grdLkedServisTuru.Properties.NullText = "";
			this.grdLkedServisTuru.Properties.PopupView = this.gridView3;
			this.grdLkedServisTuru.Properties.ValueMember = "HARKOD";
			this.grdLkedServisTuru.Size = new System.Drawing.Size(230, 20);
			this.grdLkedServisTuru.TabIndex = 3;
			// 
			// gridView3
			// 
			this.gridView3.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn8,
            this.gridColumn9,
            this.gridColumn10});
			this.gridView3.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView3.Name = "gridView3";
			this.gridView3.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView3.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView3.OptionsView.ShowAutoFilterRow = true;
			this.gridView3.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn8
			// 
			this.gridColumn8.Caption = "Id";
			this.gridColumn8.FieldName = "Id";
			this.gridColumn8.Name = "gridColumn8";
			// 
			// gridColumn9
			// 
			this.gridColumn9.Caption = "Kod";
			this.gridColumn9.FieldName = "HARKOD";
			this.gridColumn9.Name = "gridColumn9";
			this.gridColumn9.Visible = true;
			this.gridColumn9.VisibleIndex = 0;
			// 
			// gridColumn10
			// 
			this.gridColumn10.Caption = "Tanım";
			this.gridColumn10.FieldName = "TANIMI";
			this.gridColumn10.Name = "gridColumn10";
			this.gridColumn10.Visible = true;
			this.gridColumn10.VisibleIndex = 1;
			// 
			// grdLkedServisPersonel
			// 
			this.grdLkedServisPersonel.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "SRPRID", true));
			this.grdLkedServisPersonel.Location = new System.Drawing.Point(461, 63);
			this.grdLkedServisPersonel.MenuManager = this.barManager;
			this.grdLkedServisPersonel.Name = "grdLkedServisPersonel";
			this.grdLkedServisPersonel.Properties.AllowMouseWheel = false;
			this.grdLkedServisPersonel.Properties.BestFitMode = DevExpress.XtraEditors.Controls.BestFitMode.BestFitResizePopup;
			this.grdLkedServisPersonel.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.grdLkedServisPersonel.Properties.DisplayMember = "GNNAME";
			this.grdLkedServisPersonel.Properties.NullText = "";
			this.grdLkedServisPersonel.Properties.PopupView = this.gridView2;
			this.grdLkedServisPersonel.Properties.ValueMember = "Id";
			this.grdLkedServisPersonel.Size = new System.Drawing.Size(229, 20);
			this.grdLkedServisPersonel.TabIndex = 2;
			// 
			// gridView2
			// 
			this.gridView2.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn4,
            this.gridColumn5,
            this.gridColumn6,
            this.gridColumn7});
			this.gridView2.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.gridView2.Name = "gridView2";
			this.gridView2.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.gridView2.OptionsView.EnableAppearanceEvenRow = true;
			this.gridView2.OptionsView.ShowAutoFilterRow = true;
			this.gridView2.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn4
			// 
			this.gridColumn4.Caption = "Id";
			this.gridColumn4.FieldName = "Id";
			this.gridColumn4.Name = "gridColumn4";
			// 
			// gridColumn5
			// 
			this.gridColumn5.Caption = "Sicil No";
			this.gridColumn5.FieldName = "SICILN";
			this.gridColumn5.Name = "gridColumn5";
			this.gridColumn5.Visible = true;
			this.gridColumn5.VisibleIndex = 0;
			// 
			// gridColumn6
			// 
			this.gridColumn6.Caption = "Ad Soyad";
			this.gridColumn6.FieldName = "GNNAME";
			this.gridColumn6.Name = "gridColumn6";
			this.gridColumn6.Visible = true;
			this.gridColumn6.VisibleIndex = 1;
			// 
			// gridColumn7
			// 
			this.gridColumn7.Caption = "Pozisyon";
			this.gridColumn7.FieldName = "POZSYN";
			this.gridColumn7.Name = "gridColumn7";
			this.gridColumn7.Visible = true;
			this.gridColumn7.VisibleIndex = 2;
			// 
			// cmbTalebiAcan
			// 
			this.cmbTalebiAcan.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbTalebiAcan.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbTalebiAcan.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sHSRVSBindingSource, "TLPACN", true));
			this.cmbTalebiAcan.Enabled = false;
			this.cmbTalebiAcan.FormattingEnabled = true;
			this.cmbTalebiAcan.Location = new System.Drawing.Point(108, 36);
			this.cmbTalebiAcan.Name = "cmbTalebiAcan";
			this.cmbTalebiAcan.Size = new System.Drawing.Size(230, 21);
			this.cmbTalebiAcan.TabIndex = 1;
			// 
			// groupControl1
			// 
			this.groupControl1.Controls.Add(label20);
			this.groupControl1.Controls.Add(this.txtGpsBoylam);
			this.groupControl1.Controls.Add(label13);
			this.groupControl1.Controls.Add(this.txtGpsEnlem);
			this.groupControl1.Controls.Add(this.btnAdayCariEkle);
			this.groupControl1.Controls.Add(this.cmbAdres);
			this.groupControl1.Controls.Add(this.cmbTelefon);
			this.groupControl1.Controls.Add(this.cmbYetkili);
			this.groupControl1.Controls.Add(label3);
			this.groupControl1.Controls.Add(label2);
			this.groupControl1.Controls.Add(label1);
			this.groupControl1.Controls.Add(cRKODULabel);
			this.groupControl1.Controls.Add(this.cRKODUGridLookUpEdit);
			this.groupControl1.Location = new System.Drawing.Point(11, 16);
			this.groupControl1.Name = "groupControl1";
			this.groupControl1.Size = new System.Drawing.Size(703, 147);
			this.groupControl1.TabIndex = 0;
			this.groupControl1.Text = "Müşteri Bilgileri";
			// 
			// txtGpsBoylam
			// 
			this.txtGpsBoylam.Location = new System.Drawing.Point(458, 116);
			this.txtGpsBoylam.MenuManager = this.barManager;
			this.txtGpsBoylam.Name = "txtGpsBoylam";
			this.txtGpsBoylam.Size = new System.Drawing.Size(232, 20);
			this.txtGpsBoylam.TabIndex = 49;
			// 
			// txtGpsEnlem
			// 
			this.txtGpsEnlem.Location = new System.Drawing.Point(106, 116);
			this.txtGpsEnlem.MenuManager = this.barManager;
			this.txtGpsEnlem.Name = "txtGpsEnlem";
			this.txtGpsEnlem.Size = new System.Drawing.Size(232, 20);
			this.txtGpsEnlem.TabIndex = 47;
			// 
			// btnAdayCariEkle
			// 
			this.btnAdayCariEkle.Location = new System.Drawing.Point(668, 36);
			this.btnAdayCariEkle.Name = "btnAdayCariEkle";
			this.btnAdayCariEkle.Size = new System.Drawing.Size(22, 20);
			this.btnAdayCariEkle.TabIndex = 46;
			this.btnAdayCariEkle.Click += new System.EventHandler(this.btnAdayCariEkle_Click);
			// 
			// cmbAdres
			// 
			this.cmbAdres.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbAdres.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbAdres.FormattingEnabled = true;
			this.cmbAdres.Location = new System.Drawing.Point(106, 62);
			this.cmbAdres.Name = "cmbAdres";
			this.cmbAdres.Size = new System.Drawing.Size(584, 21);
			this.cmbAdres.TabIndex = 1;
			// 
			// cmbTelefon
			// 
			this.cmbTelefon.FormattingEnabled = true;
			this.cmbTelefon.Location = new System.Drawing.Point(458, 89);
			this.cmbTelefon.Name = "cmbTelefon";
			this.cmbTelefon.Size = new System.Drawing.Size(232, 21);
			this.cmbTelefon.TabIndex = 3;
			// 
			// cmbYetkili
			// 
			this.cmbYetkili.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
			this.cmbYetkili.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
			this.cmbYetkili.DisplayMember = "AdSoyad";
			this.cmbYetkili.FormattingEnabled = true;
			this.cmbYetkili.Location = new System.Drawing.Point(106, 89);
			this.cmbYetkili.Name = "cmbYetkili";
			this.cmbYetkili.Size = new System.Drawing.Size(232, 21);
			this.cmbYetkili.TabIndex = 2;
			this.cmbYetkili.ValueMember = "Id";
			this.cmbYetkili.SelectedIndexChanged += new System.EventHandler(this.cmbYetkili_SelectedIndexChanged);
			this.cmbYetkili.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cmbYetkili_KeyUp);
			// 
			// cRKODUGridLookUpEdit
			// 
			this.cRKODUGridLookUpEdit.DataBindings.Add(new System.Windows.Forms.Binding("EditValue", this.sHSRVSBindingSource, "CRKODU", true));
			this.cRKODUGridLookUpEdit.Location = new System.Drawing.Point(106, 36);
			this.cRKODUGridLookUpEdit.MenuManager = this.barManager;
			this.cRKODUGridLookUpEdit.Name = "cRKODUGridLookUpEdit";
			this.cRKODUGridLookUpEdit.Properties.AllowMouseWheel = false;
			this.cRKODUGridLookUpEdit.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
			this.cRKODUGridLookUpEdit.Properties.DisplayMember = "CRUNV1";
			this.cRKODUGridLookUpEdit.Properties.NullText = "";
			this.cRKODUGridLookUpEdit.Properties.PopupView = this.cRKODUGridLookUpEditView;
			this.cRKODUGridLookUpEdit.Properties.ValueMember = "CRKODU";
			this.cRKODUGridLookUpEdit.Size = new System.Drawing.Size(555, 20);
			this.cRKODUGridLookUpEdit.TabIndex = 0;
			this.cRKODUGridLookUpEdit.EditValueChanged += new System.EventHandler(this.cRKODUGridLookUpEdit_EditValueChanged);
			// 
			// cRKODUGridLookUpEditView
			// 
			this.cRKODUGridLookUpEditView.Columns.AddRange(new DevExpress.XtraGrid.Columns.GridColumn[] {
            this.gridColumn1,
            this.gridColumn2,
            this.gridColumn3});
			this.cRKODUGridLookUpEditView.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
			this.cRKODUGridLookUpEditView.Name = "cRKODUGridLookUpEditView";
			this.cRKODUGridLookUpEditView.OptionsSelection.EnableAppearanceFocusedCell = false;
			this.cRKODUGridLookUpEditView.OptionsView.EnableAppearanceEvenRow = true;
			this.cRKODUGridLookUpEditView.OptionsView.ShowAutoFilterRow = true;
			this.cRKODUGridLookUpEditView.OptionsView.ShowGroupPanel = false;
			// 
			// gridColumn1
			// 
			this.gridColumn1.Caption = "Id";
			this.gridColumn1.FieldName = "Id";
			this.gridColumn1.Name = "gridColumn1";
			// 
			// gridColumn2
			// 
			this.gridColumn2.Caption = "Cari Kodu";
			this.gridColumn2.FieldName = "CRKODU";
			this.gridColumn2.Name = "gridColumn2";
			this.gridColumn2.Visible = true;
			this.gridColumn2.VisibleIndex = 0;
			// 
			// gridColumn3
			// 
			this.gridColumn3.Caption = "Cari Ünvan";
			this.gridColumn3.FieldName = "CRUNV1";
			this.gridColumn3.Name = "gridColumn3";
			this.gridColumn3.Visible = true;
			this.gridColumn3.VisibleIndex = 1;
			// 
			// FrmServisKarti
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.ClientSize = new System.Drawing.Size(1077, 760);
			this.Controls.Add(this.xtraTabControl1);
			this.IconOptions.Image = ((System.Drawing.Image)(resources.GetObject("FrmServisKarti.IconOptions.Image")));
			this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
			this.Name = "FrmServisKarti";
			this.Load += new System.EventHandler(this.FrmServisKarti_Load);
			this.Controls.SetChildIndex(this.xtraTabControl1, 0);
			((System.ComponentModel.ISupportInitialize)(this.popAktar)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.popOrtam)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.xtraTabControl1)).EndInit();
			this.xtraTabControl1.ResumeLayout(false);
			this.xtraTabPage1.ResumeLayout(false);
			this.xtraTabPage1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.bELGENTextEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBitis.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dtBaslangic.Properties)).EndInit();
			this.xtraTabPage2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.sHSRVSBindingSource)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedCari)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1View)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedKategori)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView8)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedUrunModel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView7)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedServisTuru)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView11)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedServisDurumu)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView12)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repGrdLkedPersonel)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView13)).EndInit();
			this.xtraTabPage3.ResumeLayout(false);
			this.xtraScrollableControl1.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.groupControl5)).EndInit();
			this.groupControl5.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.grdIslemSure)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdVwIslemSure)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit1)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView16)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView15)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView18)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView19)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView20)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.repositoryItemGridLookUpEdit3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView17)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl4)).EndInit();
			this.groupControl4.ResumeLayout(false);
			this.groupControl4.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.memoAksiyon.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoProblemTespit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.memoProblemTanim.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl3)).EndInit();
			this.groupControl3.ResumeLayout(false);
			this.groupControl3.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtSasiNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtSeriNo.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedModel.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView9)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedKategori.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView10)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl2)).EndInit();
			this.groupControl2.ResumeLayout(false);
			this.groupControl2.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.timeEdit1.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateServisTalep.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateServisTalep.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateKurulum.Properties.CalendarTimeProperties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dateKurulum.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedMakineDurumu.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView6)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedGarantiDurumu.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView5)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedServisDurumu.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView4)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedServisTuru.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView3)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.grdLkedServisPersonel.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.gridView2)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.groupControl1)).EndInit();
			this.groupControl1.ResumeLayout(false);
			this.groupControl1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.txtGpsBoylam.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.txtGpsEnlem.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cRKODUGridLookUpEdit.Properties)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.cRKODUGridLookUpEditView)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraTab.XtraTabControl xtraTabControl1;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage2;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage3;
        private DevExpress.XtraGrid.GridControl gridControl1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.BindingSource sHSRVSBindingSource;
        private DevExpress.XtraGrid.Columns.GridColumn colId;
        private DevExpress.XtraGrid.Columns.GridColumn colSRTLTR;
        private DevExpress.XtraGrid.Columns.GridColumn colBELGEN;
        private DevExpress.XtraGrid.Columns.GridColumn colBELTRH;
        private DevExpress.XtraGrid.Columns.GridColumn colCRKODU;
        private DevExpress.XtraGrid.Columns.GridColumn colURKTGR;
        private DevExpress.XtraGrid.Columns.GridColumn colURMODL;
        private DevExpress.XtraGrid.Columns.GridColumn colSRVTUR;
        private DevExpress.XtraGrid.Columns.GridColumn colSRVDRM;
        private DevExpress.XtraGrid.Columns.GridColumn colGRNDRM;
        private DevExpress.XtraGrid.Columns.GridColumn colMKNDRM;
        private DevExpress.XtraGrid.Columns.GridColumn colMKKRTR;
        private DevExpress.XtraGrid.Columns.GridColumn colURSERI;
        private DevExpress.XtraGrid.Columns.GridColumn colURSASI;
        private DevExpress.XtraGrid.Columns.GridColumn colPRBTNM;
        private DevExpress.XtraGrid.Columns.GridColumn colPRBTSP;
        private DevExpress.XtraGrid.Columns.GridColumn colAKSYON;
        private DevExpress.XtraGrid.Columns.GridColumn colONYLYN;
        private DevExpress.XtraGrid.Columns.GridColumn colSIRKID;
        private DevExpress.XtraGrid.Columns.GridColumn colACTIVE;
        private DevExpress.XtraGrid.Columns.GridColumn colSLINDI;
        private DevExpress.XtraGrid.Columns.GridColumn colEKKULL;
        private DevExpress.XtraGrid.Columns.GridColumn colETARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colDEKULL;
        private DevExpress.XtraGrid.Columns.GridColumn colDTARIH;
        private DevExpress.XtraGrid.Columns.GridColumn colKYNKKD;
        private DevExpress.XtraGrid.Columns.GridColumn colCHKCTR;
        private DevExpress.XtraEditors.GroupControl groupControl1;
        private DevExpress.XtraEditors.GridLookUpEdit cRKODUGridLookUpEdit;
        private DevExpress.XtraGrid.Views.Grid.GridView cRKODUGridLookUpEditView;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn1;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn3;
        private System.Windows.Forms.ComboBox cmbYetkili;
        private System.Windows.Forms.ComboBox cmbTelefon;
        private System.Windows.Forms.ComboBox cmbAdres;
        private DevExpress.XtraEditors.XtraScrollableControl xtraScrollableControl1;
        private DevExpress.XtraEditors.GroupControl groupControl2;
        private DevExpress.XtraEditors.GridLookUpEdit grdLkedServisPersonel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView2;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn6;
        private System.Windows.Forms.ComboBox cmbTalebiAcan;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn7;
        private DevExpress.XtraEditors.GridLookUpEdit grdLkedServisTuru;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView3;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn10;
        private DevExpress.XtraEditors.GridLookUpEdit grdLkedServisDurumu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView4;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn13;
        private DevExpress.XtraEditors.GridLookUpEdit grdLkedMakineDurumu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView6;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn19;
        private DevExpress.XtraEditors.GridLookUpEdit grdLkedGarantiDurumu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView5;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn14;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn16;
        private DevExpress.XtraEditors.DateEdit dateKurulum;
        private DevExpress.XtraEditors.GroupControl groupControl3;
        private DevExpress.XtraEditors.GridLookUpEdit grdLkedModel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView9;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn26;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn27;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn28;
        private DevExpress.XtraEditors.GridLookUpEdit grdLkedKategori;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView10;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn29;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn30;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn31;
        private DevExpress.XtraEditors.TextEdit txtSasiNo;
        private DevExpress.XtraEditors.TextEdit txtSeriNo;
        private DevExpress.XtraEditors.GroupControl groupControl4;
        private DevExpress.XtraEditors.MemoEdit memoAksiyon;
        private DevExpress.XtraEditors.MemoEdit memoProblemTespit;
        private DevExpress.XtraEditors.MemoEdit memoProblemTanim;
        private DevExpress.XtraEditors.DateEdit dateServisTalep;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repGrdLkedCari;
        private DevExpress.XtraGrid.Views.Grid.GridView repositoryItemGridLookUpEdit1View;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn23;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn24;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repGrdLkedKategori;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView8;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn25;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn32;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repGrdLkedServisTuru;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView11;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn33;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn34;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repGrdLkedServisDurumu;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView12;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn35;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn36;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repGrdLkedPersonel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView13;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn37;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn38;
        private DevExpress.XtraGrid.Columns.GridColumn colTLPACN;
        private DevExpress.XtraGrid.Columns.GridColumn colSRPRID;
        private DevExpress.XtraGrid.Columns.GridColumn colSRBSTR;
        private DevExpress.XtraGrid.Columns.GridColumn colSRBTTR;
        private DevExpress.XtraEditors.SimpleButton btnAdayCariEkle;
        private DevExpress.XtraEditors.SimpleButton btnPdf;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repGrdLkedUrunModel;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView7;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn21;
        private DevExpress.XtraEditors.GroupControl groupControl5;
        private DevExpress.XtraGrid.GridControl grdIslemSure;
        private DevExpress.XtraGrid.Views.Grid.GridView grdVwIslemSure;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn22;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn39;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn40;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit1;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView16;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn43;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn44;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit2;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView15;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn47;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn48;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit4;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView18;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn53;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn54;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit5;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView19;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn56;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn57;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit6;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView20;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn62;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn63;
        private DevExpress.XtraEditors.Repository.RepositoryItemGridLookUpEdit repositoryItemGridLookUpEdit3;
        private DevExpress.XtraGrid.Views.Grid.GridView gridView17;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn50;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn51;
        private DevExpress.XtraGrid.Columns.GridColumn gridColumn41;
        private DevExpress.XtraEditors.TextEdit txtGpsBoylam;
        private DevExpress.XtraEditors.TextEdit txtGpsEnlem;
        private DevExpress.XtraTab.XtraTabPage xtraTabPage1;
        private DevExpress.XtraEditors.SimpleButton btnServisAra;
        private DevExpress.XtraEditors.TextEdit bELGENTextEdit;
        private DevExpress.XtraEditors.DateEdit dtBitis;
        private DevExpress.XtraEditors.DateEdit dtBaslangic;
        private System.Windows.Forms.CheckBox chkTamamlanan;
        private DevExpress.XtraEditors.SimpleButton pdfBut;
        private DevExpress.XtraEditors.SimpleButton btnWord;
        private DevExpress.XtraEditors.TimeEdit timeEdit1;
    }
}
