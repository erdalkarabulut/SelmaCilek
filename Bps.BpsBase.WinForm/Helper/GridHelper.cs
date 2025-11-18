using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.ST.Listed;
using Bps.Core.AttributeHelpers;
using Bps.Core.GlobalStaticsVariables;
using DevExpress.Utils.Menu;
using DevExpress.XtraEditors;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Card;
using DevExpress.XtraGrid.Views.Grid;
using Excel = Microsoft.Office.Interop.Excel;

namespace BPS.Windows.Forms.Helper
{
    public class GridHelper
    {
        private static IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        private static IStbdrnService _stbdrnService = InstanceFactory.GetInstance<IStbdrnService>();

        private static RepositoryItemGridLookUpEdit lk_Repo;
        private static RepositoryItemGridLookUpEdit lk_RepoVry;
        private static RepositoryItemGridLookUpEdit lk_RepoRenk;
        private static RepositoryItemGridLookUpEdit lk_RepoBeden;
        private static RepositoryItemGridLookUpEdit lk_RepoDrop;
        private static GridView lk_Repo_View;

        private static GridColumn clmHarkod;
        private static GridColumn clmTanim;

        private static GridColumn clmVRKODU;
        private static GridColumn clmRENKTN;
        private static GridColumn clmBEDNTN;
        private static GridColumn clmDROPTN;


        public static void ColumnRepositoryItems(GridView view, Global global)
        {
            foreach (GridColumn column in view.Columns)
            {
                if (column.FieldName == "EKKULL" || column.FieldName == "ETARIH" || column.FieldName == "DEKULL" || column.FieldName == "DTARIH")
                {
                    column.OptionsColumn.AllowEdit = false;
                    column.Visible = false;
                }

                if (column.ColumnEdit != null && column.ColumnEdit.EditorTypeName == "GridLookUpEdit")
                {
                    column.ColumnEdit.NullText = null;
                }

                if (column.FieldName.Contains("KD"))
                {
                    var fieldName = column.FieldName;
                    var kd = fieldName.Substring(fieldName.Length - 2);

                    if (kd == "KD")
                    {
                        lk_Repo = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmHarkod = new GridColumn();
                        clmTanim = new GridColumn();

                        clmHarkod.Caption = "Kod";
                        clmHarkod.FieldName = "HARKOD";
                        clmHarkod.Name = "clmHarkod";
                        clmHarkod.Visible = true;
                        clmHarkod.VisibleIndex = 0;

                        clmTanim.Caption = "Tanım";
                        clmTanim.FieldName = "TANIMI";
                        clmTanim.Name = "clmTanim";
                        clmTanim.Visible = true;
                        clmTanim.VisibleIndex = 1;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmHarkod,
                            clmTanim});

                        lk_Repo.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_Repo.AutoHeight = false;
                        lk_Repo.DisplayMember = "TANIMI";
                        lk_Repo.Name = "lk_Repo";
                        lk_Repo.PopupView = lk_Repo_View;
                        lk_Repo.ValidateOnEnterKey = true;
                        lk_Repo.ValueMember = "HARKOD";
                        lk_Repo.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;

                        lk_Repo.Name = "lk_Repo" + fieldName;
                        if (fieldName == "MESJKD")
                        {
                            fieldName = "PROJKD";
                        }
                        var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_Repo;
                    }
                }

                view.BestFitColumns();
            }

            if (view.Columns["Id"] != null)
            {
                view.Columns["Id"].Visible = false;
            }
            if (view.Columns["SIRKID"] != null)
            {
                view.Columns["SIRKID"].Visible = false;
            }
            if (view.Columns["CHKCTR"] != null)
            {
                view.Columns["CHKCTR"].Visible = false;
            }
            if (view.Columns["KYNKKD"] != null)
            {
                view.Columns["KYNKKD"].Visible = false;
            }
            if (view.Columns["SLINDI"] != null)
            {
                view.Columns["SLINDI"].Visible = false;
            }
        }


        public static void ColumnRepositoryItems(GridView view, Global global, List<string> teknads)
        {
            foreach (GridColumn column in view.Columns)
            {
                if (column.FieldName == "EKKULL" || column.FieldName == "ETARIH" || column.FieldName == "DEKULL" || column.FieldName == "DTARIH")
                {
                    column.OptionsColumn.AllowEdit = false;
                    column.Visible = false;
                }

                if (column.ColumnEdit != null && column.ColumnEdit.EditorTypeName == "GridLookUpEdit")
                {
                    column.ColumnEdit.NullText = null;
                }

                if (column.FieldName.Contains("KD") && !teknads.Contains(column.FieldName))
                {
                    var fieldName = column.FieldName;
                    var kd = fieldName.Substring(fieldName.Length - 2);

                    if (kd == "KD")
                    {
                        lk_Repo = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmHarkod = new GridColumn();
                        clmTanim = new GridColumn();

                        clmHarkod.Caption = "Kod";
                        clmHarkod.FieldName = "HARKOD";
                        clmHarkod.Name = "clmHarkod";
                        clmHarkod.Visible = true;
                        clmHarkod.VisibleIndex = 0;

                        clmTanim.Caption = "Tanım";
                        clmTanim.FieldName = "TANIMI";
                        clmTanim.Name = "clmTanim";
                        clmTanim.Visible = true;
                        clmTanim.VisibleIndex = 1;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmHarkod,
                            clmTanim});

                        lk_Repo.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_Repo.AutoHeight = false;
                        lk_Repo.DisplayMember = "TANIMI";
                        lk_Repo.Name = "lk_Repo";
                        lk_Repo.PopupView = lk_Repo_View;
                        lk_Repo.ValidateOnEnterKey = true;
                        lk_Repo.ValueMember = "HARKOD";
                        lk_Repo.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;

                        lk_Repo.Name = "lk_Repo" + fieldName;
                        if (fieldName == "MESJKD")
                        {
                            fieldName = "PROJKD";
                        }
                        var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_Repo;
                    }
                }
            }

            if (view.Columns["Id"] != null)
            {
                view.Columns["Id"].Visible = false;
            }
            if (view.Columns["SIRKID"] != null)
            {
                view.Columns["SIRKID"].Visible = false;
            }
            if (view.Columns["CHKCTR"] != null)
            {
                view.Columns["CHKCTR"].Visible = false;
            }
            if (view.Columns["KYNKKD"] != null)
            {
                view.Columns["KYNKKD"].Visible = false;
            }
            if (view.Columns["SLINDI"] != null)
            {
                view.Columns["SLINDI"].Visible = false;
            }

            view.BestFitColumns();
        }

        public static void ColumnRepositoryItems(CardView view, Global global)
        {
            foreach (GridColumn column in view.Columns)
            {
                if (column.FieldName == "EKKULL" || column.FieldName == "ETARIH" || column.FieldName == "DEKULL" || column.FieldName == "DTARIH")
                {
                    column.OptionsColumn.AllowEdit = false;
                }

                if (column.FieldName.Contains("KD"))
                {
                    var fieldName = column.FieldName;
                    var kd = fieldName.Substring(fieldName.Length - 2);

                    if (kd == "KD")
                    {
                        lk_Repo = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmHarkod = new GridColumn();
                        clmTanim = new GridColumn();

                        clmHarkod.Caption = "Kod";
                        clmHarkod.FieldName = "HARKOD";
                        clmHarkod.Name = "clmHarkod";
                        clmHarkod.Visible = true;
                        clmHarkod.VisibleIndex = 0;

                        clmTanim.Caption = "Tanım";
                        clmTanim.FieldName = "TANIMI";
                        clmTanim.Name = "clmTanim";
                        clmTanim.Visible = true;
                        clmTanim.VisibleIndex = 1;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmHarkod,
                            clmTanim});

                        lk_Repo.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_Repo.AutoHeight = false;
                        lk_Repo.DisplayMember = "TANIMI";
                        lk_Repo.Name = "lk_Repo";
                        lk_Repo.PopupView = lk_Repo_View;
                        lk_Repo.ValidateOnEnterKey = true;
                        lk_Repo.ValueMember = "HARKOD";
                        lk_Repo.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;

                        lk_Repo.Name = "lk_Repo" + fieldName;
                        if (fieldName == "MESJKD")
                        {
                            fieldName = "PROJKD";
                        }
                        var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_Repo;
                    }
                }
            }

            if (view.Columns["Id"] != null)
            {
                view.Columns["Id"].Visible = false;
            }
            if (view.Columns["SIRKID"] != null)
            {
                view.Columns["SIRKID"].Visible = false;
            }
            if (view.Columns["CHKCTR"] != null)
            {
                view.Columns["CHKCTR"].Visible = false;
            }
            if (view.Columns["KYNKKD"] != null)
            {
                view.Columns["KYNKKD"].Visible = false;
            }
            if (view.Columns["SLINDI"] != null)
            {
                view.Columns["SLINDI"].Visible = false;
            }
        }

        public static void gridView_PopupMenuShowing(object sender, PopupMenuShowingEventArgs e, Form _form,
            string _tag, GridView _gridView, string optional = "", string[] classNames = null)
        {

            // Add a custom item to the column header menu
            if (e.Menu != null)
            {
                EventHandler customItemClick = null;
                DXMenuItem customItem = new DXMenuItem("Yerleşim Planı");
                customItemClick = (sender1, ea) =>
                {
                    customItem.Click -= customItemClick;
                    //your code here
                    _form.ShowDialog();
                    if (_form.Tag != null)
                    {
                        byte[] byteArray = Encoding.ASCII.GetBytes(_form.Tag.ToString());
                        MemoryStream stream = new MemoryStream(byteArray);
                        _gridView.RestoreLayoutFromStream(stream);

                    }
                };
                customItem.Click += customItemClick;
                e.Menu.Items.Add(customItem);

                EventHandler customItem1Click = null;
                DXMenuItem customItem1 = new DXMenuItem("Excel Şablonu Oluştur");
                customItem1Click = (sender1, ea) =>
                {
                    customItem1.Click -= customItem1Click;
                    //optional parametresi bakım durum stringini içeriyor.
                    CreateExcelTemplate(optional, classNames);
                };

                customItem1.Click += customItem1Click;
                e.Menu.Items.Add(customItem1);

                //EventHandler customItemClick1 = null;
                //DXMenuItem customItem1 = new DXMenuItem("Yerleşim Kaydet");
                //customItemClick1 = (sender1, ea) =>
                //{
                //    customItem1.Click -= customItemClick1;
                //    //your code here

                //    _form.Show();
                //};
                //customItem1.Click += customItemClick1;
                //e.Menu.Items.Add(customItem1);
            }
        }

        public static void CreateExcelTemplate(string bakimDurum, string[] classNames = null)
        {
            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook xlWorkBook = xlApp.Workbooks.Add();
            Excel.Worksheet xlActiveSheet = null;
            xlApp.DisplayAlerts = false;
            string filePath = "";
            string className = "";

            try
            {
                for (int i = xlWorkBook.Worksheets.Count; i > 1; i--) xlWorkBook.Worksheets[i].Delete();

                if (classNames == null)
                {
                    for (int i = 1; i <= bakimDurum.Length; i++)
                    {
                        if (i > 1) xlActiveSheet = xlWorkBook.Worksheets.Add();
                        else xlActiveSheet = xlWorkBook.Worksheets[1];

                        if (i > 1) xlActiveSheet.Move(Type.Missing, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count]);
                        Microsoft.Office.Interop.Excel.Range activeCell = xlActiveSheet.Cells[1, 1];

                        string[] fieldNames =
                            GetClassFieldsForExcelTemplate(bakimDurum.ElementAt(i - 1), out className);
                        xlActiveSheet.Name = className;

                        foreach (var field in fieldNames)
                        {
                            activeCell.Value2 = field;
                            activeCell = activeCell.Offset[0, 1];
                        }

                        xlActiveSheet.Range[xlActiveSheet.Cells[1, 1], activeCell].Columns.ColumnWidth = 15;
                    }
                }
                else
                {
                    for (int i = 1; i <= classNames.Length; i++)
                    {
                        if (i > 1) xlActiveSheet = xlWorkBook.Worksheets.Add();
                        else xlActiveSheet = xlWorkBook.Worksheets[1];

                        if (i > 1) xlActiveSheet.Move(Type.Missing, xlWorkBook.Worksheets[xlWorkBook.Worksheets.Count]);
                        Microsoft.Office.Interop.Excel.Range activeCell = xlActiveSheet.Cells[1, 1];

                        string[] fieldNames =
                            GetClassFieldsForExcelTemplate('?', out className, classNames[i - 1]);
                        xlActiveSheet.Name = className;

                        foreach (var field in fieldNames)
                        {
                            activeCell.Value2 = field;
                            activeCell = activeCell.Offset[0, 1];
                        }

                        xlActiveSheet.Range[xlActiveSheet.Cells[1, 1], activeCell].Columns.ColumnWidth = 15;
                    }
                }

                xlActiveSheet = xlWorkBook.Worksheets[1];
                xlActiveSheet.Activate();

                SaveFileDialog saveFileDialog1 = new SaveFileDialog();
                saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
                saveFileDialog1.Title = "Excel Şablonu Kaydet";
                //saveFileDialog1.CheckFileExists = true;
                saveFileDialog1.CheckPathExists = true;
                saveFileDialog1.DefaultExt = "xlsx";
                saveFileDialog1.Filter = "Excel Dosyaları|*.xls;*.xlsx";
                saveFileDialog1.RestoreDirectory = true;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog1.FileName;
                    xlWorkBook.SaveAs(filePath);
                    xlWorkBook.Close(true);
                }
                else xlWorkBook.Close();

                if (filePath != "") Process.Start(filePath);
            }
            catch (Exception ex)
            {
                filePath = "";
                MessageBox.Show(ex.GetBaseException().Message);
            }

            if (filePath == "")
            {
                xlApp.Quit();
                if (xlActiveSheet != null) Marshal.FinalReleaseComObject(xlActiveSheet);
                Marshal.FinalReleaseComObject(xlWorkBook);
                Marshal.FinalReleaseComObject(xlApp);

                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            }
        }

        private static string[] GetClassFieldsForExcelTemplate(char bakimDurum, out string className, string _class = "")
        {
            switch (bakimDurum)
            {
                case 'A':
                    className = "StokKart";
                    return typeof(STKART).GetProperties().Select(f => f.Name).ToArray();
                case 'J':
                    className = "StokTanim";
                    return typeof(STNAME).GetProperties().Select(f => f.Name).ToArray();
                default:
                    className = _class;
                    return typeof(STKART).Assembly.GetType("Bps.BpsBase.Entities.Concrete." + _class).GetProperties().Select(f => f.Name).ToArray();
            }
        }
        public static void ExcelTemplateforModel(dynamic _model)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            string filePath = "";

            Excel.Workbook workbook = excelApp.Workbooks.Add();


            foreach (var property in _model.GetType().GetProperties())
            {


                Type propertyType = property.PropertyType;


                Excel.Worksheet worksheet = workbook.Sheets.Add();
                worksheet.Cells.Locked = false;
                worksheet.Name = property.Name;
                Type tip = propertyType.GetElementType();
                Type[] entityType1 = propertyType.GetGenericArguments();

                if (propertyType.IsGenericType && propertyType.GetGenericTypeDefinition() == typeof(List<>))
                {
                    Type entityType = propertyType.GetGenericArguments()[0];
                    var entityProperties = entityType.GetProperties();


                    int i = 0;
                    foreach (var _property in entityProperties)
                    {
                        worksheet.Cells[1, i + 1] = _property.Name;
                        var displayNameAttribute = _property.GetCustomAttribute<DisplayNameAttribute>();
                        worksheet.Cells[2, i + 1] = displayNameAttribute.DisplayName;

                        i++;
                    }


                    //var list = propertyValue as IEnumerable<object>;
                    //int rowIndex = 2;
                    //foreach (var item in list)
                    //{
                    //    for (int i = 0; i < entityProperties.Length; i++)
                    //    {
                    //        var value = entityProperties[i].GetValue(item)?.ToString() ?? string.Empty;
                    //        worksheet.Cells[rowIndex, i + 1] = value;
                    //    }
                    //    rowIndex++;
                    //}
                }
                else
                {

                    Type entityType = propertyType;
                    var entityProperties = entityType.GetProperties();


                    int i = 0;
                    foreach (var _property in entityProperties)
                    {
                        worksheet.Cells[1, i + 1] = _property.Name;
                        var displayNameAttribute = _property.GetCustomAttribute<DisplayNameAttribute>();
                        worksheet.Cells[2, i + 1] = displayNameAttribute.DisplayName;

                        i++;
                    }

                    //for (int i = 0; i < entityProperties.Length; i++)
                    //{
                    //    worksheet.Cells[1, i + 1] = entityProperties[i].Name;
                    //    //var displayNameAttribute = entityProperties[i].GetCustomAttributes(true);
                    //    //worksheet.Cells[2, i + 1] = displayNameAttribute[1].ToString();
                    //} "

                    //// Veriyi yaz (_order)
                    //int rowIndex = 2;
                    //for (int i = 0; i < entityProperties.Length; i++)
                    //{
                    //    var value = entityProperties[i].GetValue(propertyValue)?.ToString() ?? string.Empty;
                    //    worksheet.Cells[rowIndex, i + 1] = value;
                    //}
                }
                worksheet.Columns.AutoFit();
                worksheet.Rows.AutoFit();
                worksheet.Range["A1:Z1"].Locked = true;
                worksheet.Range["A2:Z2"].Locked = true;
                worksheet.Protect(Password: "password", DrawingObjects: true, Contents: true, Scenarios: true);
            }
            Excel.Worksheet sheet1 = workbook.Sheets["Sayfa1"];


            excelApp.DisplayAlerts = false;


            sheet1.Delete();


            excelApp.DisplayAlerts = true;


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            saveFileDialog1.Title = "Excel Şablonu Kaydet";
            //saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel Dosyaları|*.xls;*.xlsx";
            saveFileDialog1.RestoreDirectory = true;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = saveFileDialog1.FileName;
                workbook.SaveAs(filePath);
                workbook.Close(true);



            }
            excelApp.Quit();

        }


        public static void ExcelTemplateforEntity(dynamic _model, string _filepath = null)
        {
            var excelApp = new Excel.Application();
            excelApp.Visible = true;
            string filePath = "";
            int sutunsayisi = 0;
            Excel.Workbook workbook = excelApp.Workbooks.Add();

            dynamic _entityType = _model.GetType();
            Excel.Worksheet worksheet = workbook.Sheets.Add();
            worksheet.Cells.Locked = false;
            worksheet.Name = _entityType.Name;




            var entityProperties = _entityType.GetProperties();


            int i = 0;

            foreach (PropertyInfo _property in entityProperties)
            {
                worksheet.Cells[1, i + 1] = _property.Name;
                var displayNameAttribute = _property.GetCustomAttribute<DisplayNameAttribute>();
                var required = _property.GetCustomAttribute<RequiredAttribute>();
                worksheet.Cells[2, i + 1] = displayNameAttribute.DisplayName;
                worksheet.Cells[1, i + 1].Locked = true;
                worksheet.Cells[2, i + 1].Locked = true;
                if (required == null)
                {
                    worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                    worksheet.Cells[2, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.LightGray);
                }
                else
                {
                    worksheet.Cells[1, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);
                    worksheet.Cells[2, i + 1].Interior.Color = System.Drawing.ColorTranslator.ToOle(System.Drawing.Color.OrangeRed);
                }


                i++;
                sutunsayisi = i;
            }


            //for (int i = 0; i < entityProperties.Length; i++)
            //{
            //    worksheet.Cells[1, i + 1] = entityProperties[i].Name;
            //    //var displayNameAttribute = entityProperties[i].GetCustomAttributes(true);
            //    //worksheet.Cells[2, i + 1] = displayNameAttribute[1].ToString();
            //} "

            //// Veriyi yaz (_order)
            //int rowIndex = 2;
            //for (int i = 0; i < entityProperties.Length; i++)
            //{
            //    var value = entityProperties[i].GetValue(propertyValue)?.ToString() ?? string.Empty;
            //    worksheet.Cells[rowIndex, i + 1] = value;
            //}

            worksheet.Columns.AutoFit();
            worksheet.Rows.AutoFit();
            int VisibleColumnCount = sutunsayisi - 10;
            for (int y = 0; y <= sutunsayisi; y++)
            {
                if (y > VisibleColumnCount) worksheet.Columns[y].EntireColumn.Hidden = true;
            }
            //worksheet.Range[1,sutunsayisi].Locked = true;
            //worksheet.Range["A2:Z2"].Locked = true;
            worksheet.Protect(Password: "password", DrawingObjects: true, Contents: true, Scenarios: true);

            Excel.Worksheet sheet1 = workbook.Sheets["Sayfa1"];


            excelApp.DisplayAlerts = false;


            sheet1.Delete();


            excelApp.DisplayAlerts = true;


            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            saveFileDialog1.Title = "Excel Şablonu Kaydet";
            //saveFileDialog1.CheckFileExists = true;
            saveFileDialog1.CheckPathExists = true;
            saveFileDialog1.DefaultExt = "xlsx";
            saveFileDialog1.Filter = "Excel Dosyaları|*.xls;*.xlsx";
            saveFileDialog1.RestoreDirectory = true;

            if (_filepath == null)
            {
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    filePath = saveFileDialog1.FileName;
                }


            }
            else
            {
                filePath = _filepath;
            }




            workbook.SaveAs(filePath);
            workbook?.Close(false);
            excelApp.Quit();
            System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
            System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);






        }
        public static List<T> LoadExcelToListEntity<T>() where T : new()
        {
            string filePath = "";
            var entities = new List<T>();
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filePath = openFileDialog1.FileName;




            }


            var excelApp = new Excel.Application();
            Excel.Workbook workbook = null;
            Excel.Worksheet worksheet = null;

            try
            {
                workbook = excelApp.Workbooks.Open(filePath);
                worksheet = workbook.Sheets[1];
                Excel.Range range = worksheet.UsedRange;

                int rowCount = range.Rows.Count;
                int colCount = range.Columns.Count;


                var headers = new List<string>();
                for (int col = 1; col <= colCount; col++)
                {
                    headers.Add((range.Cells[1, col] as Excel.Range).Value?.ToString());
                }


                for (int row = 3; row <= rowCount; row++)
                {
                    var entity = new T();
                    for (int col = 1; col <= colCount; col++)
                    {
                        string propertyName = headers[col - 1];
                        var cellValue = (range.Cells[row, col] as Excel.Range).Value;

                        PropertyInfo property = typeof(T).GetProperty(propertyName);
                        if (property != null && cellValue != null)
                        {
                            object convertedValue;
                            Type targetType = Nullable.GetUnderlyingType(property.PropertyType) ?? property.PropertyType;
                            if (targetType.Name == "Decimal")
                            {
                                convertedValue = (Decimal)cellValue;
                            }
                            else
                            {
                                convertedValue = Convert.ChangeType(cellValue, property.PropertyType);
                            }

                            property.SetValue(entity, convertedValue);
                        }
                    }
                    entities.Add(entity);
                }
            }
            finally
            {

                workbook?.Close(false);
                excelApp.Quit();
                System.Runtime.InteropServices.Marshal.ReleaseComObject(workbook);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(worksheet);
                System.Runtime.InteropServices.Marshal.ReleaseComObject(excelApp);
            }

            return entities;
        }
        public static void ColumnRepositoryRenkBedenItems(GridView view, Global global)
        {
            if (!(bool)global.RenkBeden)
            {
                foreach (GridColumn column in view.Columns)
                {
                    if (column.Name.Contains("colrnkbdnVRKODU")) column.Visible = false;
                    if (column.Name.Contains("colrnkbdnRENKTN")) column.Visible = false;
                    if (column.Name.Contains("colrnkbdnBEDNTN")) column.Visible = false;
                    if (column.Name.Contains("colrnkbdnDROPTN")) column.Visible = false;
                }

            }
            else
            {
                foreach (GridColumn column in view.Columns)
                {

                    
                    if (column.Name.Contains("colrnkbdnRENKTN"))
                    { column.Visible = true; column.VisibleIndex = 4; }
                    if (column.Name.Contains("colrnkbdnBEDNTN"))
                    { column.Visible = true; column.VisibleIndex = 5; }
                    if (column.Name.Contains("colrnkbdnDROPTN"))
                    { column.Visible = true; column.VisibleIndex = 6; }

                    if (column.Name.Contains("colrnkbdnVRKODU"))
                    {
                        column.Visible = true; column.VisibleIndex = 3;
                        lk_RepoVry = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmVRKODU = new GridColumn();
                        clmRENKTN = new GridColumn();
                        clmBEDNTN = new GridColumn();
                        clmDROPTN = new GridColumn();

                        clmVRKODU.Caption = "Varyant Kodu";
                        clmVRKODU.FieldName = "VRKODU";
                        clmVRKODU.Name = "clmVRKODU";
                        clmVRKODU.Visible = true;
                        clmVRKODU.VisibleIndex = 0;

                        clmRENKTN.Caption = "Renk";
                        clmRENKTN.FieldName = "RENKTN";
                        clmRENKTN.Name = "clmRENKTN";
                        clmRENKTN.Visible = true;
                        clmRENKTN.VisibleIndex = 1;

                        clmBEDNTN.Caption = "Beden";
                        clmBEDNTN.FieldName = "BEDNTN";
                        clmBEDNTN.Name = "clmBEDNTN";
                        clmBEDNTN.Visible = true;
                        clmBEDNTN.VisibleIndex = 2;

                        clmDROPTN.Caption = "Drop";
                        clmDROPTN.FieldName = "DROPTN";
                        clmDROPTN.Name = "clmDROPTN";
                        clmDROPTN.Visible = true;
                        clmDROPTN.VisibleIndex = 3;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmVRKODU,
                            clmRENKTN,
                            clmBEDNTN,
                            clmDROPTN
                    });

                        lk_RepoVry.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_RepoVry.AutoHeight = false;
                        lk_RepoVry.DisplayMember = "VRKODU";
                        lk_RepoVry.Name = "lk_RepoVry";
                        lk_RepoVry.PopupView = lk_Repo_View;
                        lk_RepoVry.ValidateOnEnterKey = true;
                        lk_RepoVry.ValueMember = "VRKODU";
                        lk_RepoVry.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;


                        //var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        //lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_RepoVry;

                    }

                    if (column.Name.Contains("colrnkbdnRENKTN"))
                    {

                        lk_RepoRenk = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmVRKODU = new GridColumn();
                        clmRENKTN = new GridColumn();
                        clmBEDNTN = new GridColumn();
                        clmDROPTN = new GridColumn();

                        clmVRKODU.Caption = "Varyant Kodu";
                        clmVRKODU.FieldName = "VRKODU";
                        clmVRKODU.Name = "clmVRKODU";
                        clmVRKODU.Visible = true;
                        clmVRKODU.VisibleIndex = 0;

                        clmRENKTN.Caption = "Renk";
                        clmRENKTN.FieldName = "RENKTN";
                        clmRENKTN.Name = "clmRENKTN";
                        clmRENKTN.Visible = true;
                        clmRENKTN.VisibleIndex = 1;

                        clmBEDNTN.Caption = "Beden";
                        clmBEDNTN.FieldName = "BEDNTN";
                        clmBEDNTN.Name = "clmBEDNTN";
                        clmBEDNTN.Visible = true;
                        clmBEDNTN.VisibleIndex = 2;

                        clmDROPTN.Caption = "Drop";
                        clmDROPTN.FieldName = "DROPTN";
                        clmDROPTN.Name = "clmDROPTN";
                        clmDROPTN.Visible = true;
                        clmDROPTN.VisibleIndex = 3;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmVRKODU,
                            clmRENKTN,
                            clmBEDNTN,
                            clmDROPTN
                    });

                        lk_RepoRenk.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_RepoRenk.AutoHeight = false;
                        lk_RepoRenk.DisplayMember = "RENKTN";
                        lk_RepoRenk.Name = "lk_RepoRenk";
                        lk_RepoRenk.PopupView = lk_Repo_View;
                        lk_RepoRenk.ValidateOnEnterKey = true;
                        lk_RepoRenk.ValueMember = "VRKODU";
                        lk_RepoRenk.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;


                        //var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        //lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_RepoRenk;

                    }

                    if (column.Name.Contains("colrnkbdnBEDNTN"))
                    {

                        lk_RepoBeden = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmVRKODU = new GridColumn();
                        clmRENKTN = new GridColumn();
                        clmBEDNTN = new GridColumn();
                        clmDROPTN = new GridColumn();

                        clmVRKODU.Caption = "Varyant Kodu";
                        clmVRKODU.FieldName = "VRKODU";
                        clmVRKODU.Name = "clmVRKODU";
                        clmVRKODU.Visible = true;
                        clmVRKODU.VisibleIndex = 0;

                        clmRENKTN.Caption = "Renk";
                        clmRENKTN.FieldName = "RENKTN";
                        clmRENKTN.Name = "clmRENKTN";
                        clmRENKTN.Visible = true;
                        clmRENKTN.VisibleIndex = 1;

                        clmBEDNTN.Caption = "Beden";
                        clmBEDNTN.FieldName = "BEDNTN";
                        clmBEDNTN.Name = "clmBEDNTN";
                        clmBEDNTN.Visible = true;
                        clmBEDNTN.VisibleIndex = 2;

                        clmDROPTN.Caption = "Drop";
                        clmDROPTN.FieldName = "DROPTN";
                        clmDROPTN.Name = "clmDROPTN";
                        clmDROPTN.Visible = true;
                        clmDROPTN.VisibleIndex = 3;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmVRKODU,
                            clmRENKTN,
                            clmBEDNTN,
                            clmDROPTN
                    });

                        lk_RepoBeden.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_RepoBeden.AutoHeight = false;
                        lk_RepoBeden.DisplayMember = "BEDNTN";
                        lk_RepoBeden.Name = "lk_RepoBeden";
                        lk_RepoBeden.PopupView = lk_Repo_View;
                        lk_RepoBeden.ValidateOnEnterKey = true;
                        lk_RepoBeden.ValueMember = "VRKODU";
                        lk_RepoBeden.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;


                        //var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        //lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_RepoBeden;

                    }

                    if (column.Name.Contains("colrnkbdnDROPTN"))
                    {

                        lk_RepoDrop = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmVRKODU = new GridColumn();
                        clmRENKTN = new GridColumn();
                        clmBEDNTN = new GridColumn();
                        clmDROPTN = new GridColumn();

                        clmVRKODU.Caption = "Varyant Kodu";
                        clmVRKODU.FieldName = "VRKODU";
                        clmVRKODU.Name = "clmVRKODU";
                        clmVRKODU.Visible = true;
                        clmVRKODU.VisibleIndex = 0;

                        clmRENKTN.Caption = "Renk";
                        clmRENKTN.FieldName = "RENKTN";
                        clmRENKTN.Name = "clmRENKTN";
                        clmRENKTN.Visible = true;
                        clmRENKTN.VisibleIndex = 1;

                        clmBEDNTN.Caption = "Beden";
                        clmBEDNTN.FieldName = "BEDNTN";
                        clmBEDNTN.Name = "clmBEDNTN";
                        clmBEDNTN.Visible = true;
                        clmBEDNTN.VisibleIndex = 2;

                        clmDROPTN.Caption = "Drop";
                        clmDROPTN.FieldName = "DROPTN";
                        clmDROPTN.Name = "clmDROPTN";
                        clmDROPTN.Visible = true;
                        clmDROPTN.VisibleIndex = 3;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmVRKODU,
                            clmRENKTN,
                            clmBEDNTN,
                            clmDROPTN
                    });

                        lk_RepoDrop.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_RepoDrop.AutoHeight = false;
                        lk_RepoDrop.DisplayMember = "DROPTN";
                        lk_RepoDrop.Name = "lk_RepoDrop";
                        lk_RepoDrop.PopupView = lk_Repo_View;
                        lk_RepoDrop.ValidateOnEnterKey = true;
                        lk_RepoDrop.ValueMember = "VRKODU";
                        lk_RepoDrop.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;


                        //var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        //lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_RepoDrop;

                    }
                    view.BestFitColumns();
                }


                view.ShownEditor += (sender, e) => GridView_ShownEditor(sender, e, global);
                view.CustomRowCellEdit += (sender, e) => GridView_CustomRowCellEdit(sender, e, global);
            }


        }
        static Dictionary<string, List<StbdrnListModel>> lookupCache = new Dictionary<string, List<StbdrnListModel>>();


        private  static void GridView_ShownEditor(object sender, EventArgs e, Global global)
        {
            GridView tree = sender as GridView;
            string _stkkodu = Convert.ToString(tree.GetFocusedRowCellValue("STKODU"));

            if (tree.FocusedColumn.Name.Contains("colrnkbdnVRKODU"))
            {
                if (!string.IsNullOrEmpty(_stkkodu))
                {
                    GridLookUpEdit editor = (GridLookUpEdit)tree.ActiveEditor;
                    string cacheKey = $"{_stkkodu}";

                    if (lookupCache.TryGetValue(cacheKey, out List<StbdrnListModel> repoItem))
                    {

                        editor.Properties.DataSource = repoItem;
                    }
                    else
                    {
                        var _vrydata = _stbdrnService.Cch_GetListModelByStok_NLog(_stkkodu, global, false).Items;
                        editor.Properties.DataSource = _vrydata;
                        lookupCache[cacheKey] = _vrydata;
                    }


                }
            }
        }
        static Dictionary<string, List<StbdrnListModel>> lookupCacheModel = new Dictionary<string, List<StbdrnListModel>>();
        private static void GridView_CustomRowCellEdit(object sender, CustomRowCellEditEventArgs e, Global global)
        {
            GridView view = sender as GridView;
            if (view == null) return;
            if (e.Column.FieldName == "VRKODU" && e.Column.Visible == true)
            {
                string _stkkodu = view.GetRowCellValue(e.RowHandle, "STKODU") as string;
                string _vrykodu = view.GetRowCellValue(e.RowHandle, "VRKODU") as string;
                if (!string.IsNullOrEmpty(_stkkodu) && !string.IsNullOrEmpty(_vrykodu))
                {
                    string cacheKey = $"{_stkkodu}_{_vrykodu}";
                    if (lookupCacheModel.TryGetValue(cacheKey, out List<StbdrnListModel> repoItem))
                    {
                        lk_RepoVry.DataSource = repoItem;
                        lk_RepoRenk.DataSource = repoItem;
                        lk_RepoBeden.DataSource = repoItem;
                        lk_RepoDrop.DataSource = repoItem;
                    }
                    else
                    {
                        var _vrydata = _stbdrnService.Cch_GetListModelByStok_NLog(_stkkodu, global, false, _vrykodu).Items;
                        lk_RepoVry.DataSource = _vrydata;
                        lk_RepoRenk.DataSource = _vrydata;
                        lk_RepoBeden.DataSource = _vrydata;
                        lk_RepoDrop.DataSource = _vrydata;
                        lookupCacheModel[cacheKey] = _vrydata;

                    }
                }
            }
        }

        public  void ColumnRepositoryRenkBedenItems1(GridView view, Global global)
        {
            if (!(bool)global.RenkBeden)
            {
                foreach (GridColumn column in view.Columns)
                {
                    if (column.Name.Contains("colrnkbdnVRKODU")) column.Visible = false;
                    if (column.Name.Contains("colrnkbdnRENKTN")) column.Visible = false;
                    if (column.Name.Contains("colrnkbdnBEDNTN")) column.Visible = false;
                    if (column.Name.Contains("colrnkbdnDROPTN")) column.Visible = false;
                }

            }
            else
            {
                foreach (GridColumn column in view.Columns)
                {


                    if (column.Name.Contains("colrnkbdnRENKTN"))
                    { column.Visible = true; column.VisibleIndex = 4; }
                    if (column.Name.Contains("colrnkbdnBEDNTN"))
                    { column.Visible = true; column.VisibleIndex = 5; }
                    if (column.Name.Contains("colrnkbdnDROPTN"))
                    { column.Visible = true; column.VisibleIndex = 6; }

                    if (column.Name.Contains("colrnkbdnVRKODU"))
                    {
                        column.Visible = true; column.VisibleIndex = 3;
                        lk_RepoVry = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmVRKODU = new GridColumn();
                        clmRENKTN = new GridColumn();
                        clmBEDNTN = new GridColumn();
                        clmDROPTN = new GridColumn();

                        clmVRKODU.Caption = "Varyant Kodu";
                        clmVRKODU.FieldName = "VRKODU";
                        clmVRKODU.Name = "clmVRKODU";
                        clmVRKODU.Visible = true;
                        clmVRKODU.VisibleIndex = 0;

                        clmRENKTN.Caption = "Renk";
                        clmRENKTN.FieldName = "RENKTN";
                        clmRENKTN.Name = "clmRENKTN";
                        clmRENKTN.Visible = true;
                        clmRENKTN.VisibleIndex = 1;

                        clmBEDNTN.Caption = "Beden";
                        clmBEDNTN.FieldName = "BEDNTN";
                        clmBEDNTN.Name = "clmBEDNTN";
                        clmBEDNTN.Visible = true;
                        clmBEDNTN.VisibleIndex = 2;

                        clmDROPTN.Caption = "Drop";
                        clmDROPTN.FieldName = "DROPTN";
                        clmDROPTN.Name = "clmDROPTN";
                        clmDROPTN.Visible = true;
                        clmDROPTN.VisibleIndex = 3;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmVRKODU,
                            clmRENKTN,
                            clmBEDNTN,
                            clmDROPTN
                    });

                        lk_RepoVry.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_RepoVry.AutoHeight = false;
                        lk_RepoVry.DisplayMember = "VRKODU";
                        lk_RepoVry.Name = "lk_RepoVry";
                        lk_RepoVry.PopupView = lk_Repo_View;
                        lk_RepoVry.ValidateOnEnterKey = true;
                        lk_RepoVry.ValueMember = "VRKODU";
                        lk_RepoVry.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;


                        //var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        //lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_RepoVry;

                    }

                    if (column.Name.Contains("colrnkbdnRENKTN"))
                    {

                        lk_RepoRenk = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmVRKODU = new GridColumn();
                        clmRENKTN = new GridColumn();
                        clmBEDNTN = new GridColumn();
                        clmDROPTN = new GridColumn();

                        clmVRKODU.Caption = "Varyant Kodu";
                        clmVRKODU.FieldName = "VRKODU";
                        clmVRKODU.Name = "clmVRKODU";
                        clmVRKODU.Visible = true;
                        clmVRKODU.VisibleIndex = 0;

                        clmRENKTN.Caption = "Renk";
                        clmRENKTN.FieldName = "RENKTN";
                        clmRENKTN.Name = "clmRENKTN";
                        clmRENKTN.Visible = true;
                        clmRENKTN.VisibleIndex = 1;

                        clmBEDNTN.Caption = "Beden";
                        clmBEDNTN.FieldName = "BEDNTN";
                        clmBEDNTN.Name = "clmBEDNTN";
                        clmBEDNTN.Visible = true;
                        clmBEDNTN.VisibleIndex = 2;

                        clmDROPTN.Caption = "Drop";
                        clmDROPTN.FieldName = "DROPTN";
                        clmDROPTN.Name = "clmDROPTN";
                        clmDROPTN.Visible = true;
                        clmDROPTN.VisibleIndex = 3;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmVRKODU,
                            clmRENKTN,
                            clmBEDNTN,
                            clmDROPTN
                    });

                        lk_RepoRenk.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_RepoRenk.AutoHeight = false;
                        lk_RepoRenk.DisplayMember = "RENKTN";
                        lk_RepoRenk.Name = "lk_RepoRenk";
                        lk_RepoRenk.PopupView = lk_Repo_View;
                        lk_RepoRenk.ValidateOnEnterKey = true;
                        lk_RepoRenk.ValueMember = "VRKODU";
                        lk_RepoRenk.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;


                        //var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        //lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_RepoRenk;

                    }

                    if (column.Name.Contains("colrnkbdnBEDNTN"))
                    {

                        lk_RepoBeden = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmVRKODU = new GridColumn();
                        clmRENKTN = new GridColumn();
                        clmBEDNTN = new GridColumn();
                        clmDROPTN = new GridColumn();

                        clmVRKODU.Caption = "Varyant Kodu";
                        clmVRKODU.FieldName = "VRKODU";
                        clmVRKODU.Name = "clmVRKODU";
                        clmVRKODU.Visible = true;
                        clmVRKODU.VisibleIndex = 0;

                        clmRENKTN.Caption = "Renk";
                        clmRENKTN.FieldName = "RENKTN";
                        clmRENKTN.Name = "clmRENKTN";
                        clmRENKTN.Visible = true;
                        clmRENKTN.VisibleIndex = 1;

                        clmBEDNTN.Caption = "Beden";
                        clmBEDNTN.FieldName = "BEDNTN";
                        clmBEDNTN.Name = "clmBEDNTN";
                        clmBEDNTN.Visible = true;
                        clmBEDNTN.VisibleIndex = 2;

                        clmDROPTN.Caption = "Drop";
                        clmDROPTN.FieldName = "DROPTN";
                        clmDROPTN.Name = "clmDROPTN";
                        clmDROPTN.Visible = true;
                        clmDROPTN.VisibleIndex = 3;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmVRKODU,
                            clmRENKTN,
                            clmBEDNTN,
                            clmDROPTN
                    });

                        lk_RepoBeden.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_RepoBeden.AutoHeight = false;
                        lk_RepoBeden.DisplayMember = "BEDNTN";
                        lk_RepoBeden.Name = "lk_RepoBeden";
                        lk_RepoBeden.PopupView = lk_Repo_View;
                        lk_RepoBeden.ValidateOnEnterKey = true;
                        lk_RepoBeden.ValueMember = "VRKODU";
                        lk_RepoBeden.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;


                        //var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        //lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_RepoBeden;

                    }

                    if (column.Name.Contains("colrnkbdnDROPTN"))
                    {

                        lk_RepoDrop = new RepositoryItemGridLookUpEdit();
                        lk_Repo_View = new GridView();
                        clmVRKODU = new GridColumn();
                        clmRENKTN = new GridColumn();
                        clmBEDNTN = new GridColumn();
                        clmDROPTN = new GridColumn();

                        clmVRKODU.Caption = "Varyant Kodu";
                        clmVRKODU.FieldName = "VRKODU";
                        clmVRKODU.Name = "clmVRKODU";
                        clmVRKODU.Visible = true;
                        clmVRKODU.VisibleIndex = 0;

                        clmRENKTN.Caption = "Renk";
                        clmRENKTN.FieldName = "RENKTN";
                        clmRENKTN.Name = "clmRENKTN";
                        clmRENKTN.Visible = true;
                        clmRENKTN.VisibleIndex = 1;

                        clmBEDNTN.Caption = "Beden";
                        clmBEDNTN.FieldName = "BEDNTN";
                        clmBEDNTN.Name = "clmBEDNTN";
                        clmBEDNTN.Visible = true;
                        clmBEDNTN.VisibleIndex = 2;

                        clmDROPTN.Caption = "Drop";
                        clmDROPTN.FieldName = "DROPTN";
                        clmDROPTN.Name = "clmDROPTN";
                        clmDROPTN.Visible = true;
                        clmDROPTN.VisibleIndex = 3;

                        lk_Repo_View.FocusRectStyle = DevExpress.XtraGrid.Views.Grid.DrawFocusRectStyle.RowFocus;
                        lk_Repo_View.Name = "repositoryItemGridLookUpEdit1View";
                        lk_Repo_View.OptionsSelection.EnableAppearanceFocusedCell = false;
                        lk_Repo_View.OptionsView.ShowGroupPanel = false;
                        lk_Repo_View.Columns.AddRange(new[] {
                            clmVRKODU,
                            clmRENKTN,
                            clmBEDNTN,
                            clmDROPTN
                    });

                        lk_RepoDrop.AcceptEditorTextAsNewValue = DevExpress.Utils.DefaultBoolean.True;
                        lk_RepoDrop.AutoHeight = false;
                        lk_RepoDrop.DisplayMember = "DROPTN";
                        lk_RepoDrop.Name = "lk_RepoDrop";
                        lk_RepoDrop.PopupView = lk_Repo_View;
                        lk_RepoDrop.ValidateOnEnterKey = true;
                        lk_RepoDrop.ValueMember = "VRKODU";
                        lk_RepoDrop.NullText = "";
                        //lk_Repo.TextEditStyle = TextEditStyles.DisableTextEditor;


                        //var sonuc = _gnthrkService.Cch_GetListByTeknad(global, fieldName, yetkiKontrol: false);
                        //lk_Repo.DataSource = sonuc.Items;
                        column.ColumnEdit = lk_RepoDrop;

                    }
                    view.BestFitColumns();
                }


                view.ShownEditor += (sender, e) => GridView_ShownEditor(sender, e, global);
                view.CustomRowCellEdit += (sender, e) => GridView_CustomRowCellEdit(sender, e, global);
            }


        }
    }
}