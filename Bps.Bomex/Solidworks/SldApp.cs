using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading;
using System.Windows.Forms;
using BOMex.Core;
using BOMex.Solidworks;
using Bps.Bomex.Abstract;
using Bps.Bomex.Models;
using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;

namespace Bps.Bomex.Solidworks
{
    public class SldApp : IApp
    {
        #region Interface Properties & Events

        public string ProductCode { get; set; }
        public bool SearchError { get; set; }
        public bool ThreadCanceled { get; set; }
        public int TotalCount { get; set; }
        public int PartCount { get; set; }
        public string ActiveDocumentPath { get; set; }
        public AppType ApplicationType { get; set; }
        public Thread SearchThread { get; set; }
        public DataTable UrunAgaciTable { get; set; }
        public List<string> Errors { get; set; }

        public event RecursiveEventHandler OnSearchResultComplete;
        public event SearchErrorEventHandler OnSearchError;

        #endregion

        #region Application Properties & Fields

        public ModelDoc2 ActivePart { get; set; }
        public AssemblyDoc ActiveAssembly { get; set; }
        public DrawingDoc ActiveDrawing { get; set; }
        public List<string[]> FilePaths { get; set; }
        public List<CustomProp> CustomProps { get; set; }

        private SldWorks _sldApp;
        public List<ModelDoc2> parts;
        public List<SheetMetal> sheetMetals;
        private string mainAssemblyName;

        #endregion

        #region Constructor

        public SldApp()
        {
            ApplicationType = AppType.AutodeskInventor;
            ActiveDocumentPath = "";
            ActivePart = null;
            ActiveAssembly = null;
            TotalCount = PartCount = 0;
            ThreadCanceled = false;
            SearchError = false;
            FilePaths = new List<string[]>();
            CustomProps = GetCustomProps();
            sheetMetals = new List<SheetMetal>();
            Errors = new List<string>();
        }

        #endregion

        #region Interface Methods

        public bool AppIsOpen()
        {
            try
            {
                _sldApp = (SldWorks)Marshal.GetActiveObject("SldWorks.Application");
                _sldApp.Visible = true;
                return true;

            }
            catch (Exception ex)
            {
                return false;
            }
        }


        public Image GetPartThumbnail(string partPath)
        {
            try
            {
                //object com = _sldApp.GetPreviewBitmap(partPath, "Default");
                //part.SaveBMP("D:\\hhhh.png", 400, 400);
                //Image img = AxHostConverter.PictureDispToImage(g);
                return null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return GetPartThumbnail(partPath);
            }
        }

        public DocType GetActiveDocType()
        {
            ActiveDocumentPath = "";
            if (_sldApp == null || _sldApp.ActiveDoc == null)
            {
                ActivePart = null;
                ActiveAssembly = null;
                return DocType.InvalidDoc;
            }

            GetActiveDocumentPath();

            swDocumentTypes_e docType = (swDocumentTypes_e)_sldApp.IActiveDoc2.GetType();

            if (docType == swDocumentTypes_e.swDocPART)
            {
                ActivePart = _sldApp.IActiveDoc2;
                return DocType.PartDoc;
            }

            if (docType == swDocumentTypes_e.swDocASSEMBLY)
            {
                ActiveAssembly = (AssemblyDoc)_sldApp.ActiveDoc;
                return DocType.AssemblyDoc;
            }

            ActiveDocumentPath = "";
            return DocType.InvalidDoc;
        }

        public PartInfo GetPartInfo(object prt = null)
        {
            ModelDoc2 part = null;
            if (prt != null) part = (ModelDoc2)prt;
            else part = ActivePart;

            CheckCustomProps(part);

            var customPropManager = part.Extension.get_CustomPropertyManager("");

            List<CustomProp> propList = new List<CustomProp>();
            object[] fields = (object[])customPropManager.GetNames();
            foreach (var fieldObj in fields)
            {
                string field = fieldObj.ToString();
                string value = "";
                string resValue = "";
                customPropManager.Get4(field, false, out value, out resValue);

                propList.Add(new CustomProp { PropName = field, Val = (dynamic)resValue });
            }

            string miktar = propList.Find(p => p.PropName == "Miktar").Val;

            PartInfo partInfo = new PartInfo();
            partInfo.PartName = propList.Find(p => p.PropName == "PartName").Val;
            partInfo.Rota = propList.Find(p => p.PropName == "Rota").Val;
            partInfo.Miktar = miktar == "" ? 0 : Convert.ToInt32(miktar);
            partInfo.Thumbnail = GetPartThumbnail(part.GetPathName());
            return partInfo;
        }

        public void GetActiveDocumentPath()
        {
            ActiveDocumentPath = _sldApp.IActiveDoc2.GetPathName();
        }

        public void OpenPart(string partPath, int miktar = -1)
        {
            ModelDoc2 part = (ModelDoc2)_sldApp.ActivateDoc(partPath);

            if (miktar > -1)
            {
                var customPropManager = part.Extension.get_CustomPropertyManager("");

                try
                {
                    customPropManager.Set2("Miktar", miktar.ToString());
                }
                catch
                {
                    customPropManager.Add3("Miktar", (int)swCustomInfoType_e.swCustomInfoText, miktar.ToString(), (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);
                }

                part.SaveSilent();
            }
        }

        public List<CustomProp> GetCustomProps()
        {
            List<CustomProp> customProps = new List<CustomProp>();
            customProps.Add(new CustomProp { PropName = "PartName", PropType = "Text", DefaultVal = "" });
            customProps.Add(new CustomProp { PropName = "Miktar", PropType = "Number", DefaultVal = 0 });
            customProps.Add(new CustomProp { PropName = "Rota", PropType = "Text", DefaultVal = "" });
            return customProps;
        }

        public void CheckCustomProps(object doc, PartInfo partInfo = null)
        {
            ModelDoc2 part = (ModelDoc2)doc;

            var customPropManager = part.Extension.get_CustomPropertyManager("");

            List<CustomProp> propList = new List<CustomProp>();
            object[] fields = (object[])customPropManager.GetNames();

            if (fields != null)
            {
                foreach (var fieldObj in fields)
                {
                    string field = fieldObj.ToString();
                    string value = "";
                    string resValue = "";
                    customPropManager.Get4(field, false, out value, out resValue);
                    string type = ((swCustomInfoType_e)customPropManager.GetType2(field)).ToString();
                    type = type.Substring(12); // "swCustomInfo" kısmını alma

                    propList.Add(new CustomProp { PropName = field, PropType = type, Val = (dynamic)resValue });
                }
            }

            for (int i = 0; i < CustomProps.Count; i++)
            {
                string prop = CustomProps[i].PropName;
                dynamic defVal = CustomProps[i].DefaultVal;

                try
                {
                    CustomProp customProp = propList.Find(p => p.PropName == prop);
                    if (customProp != null && (customProp.Val == null || customProp.Val.ToString() == ""))
                    {
                        customPropManager.Delete2(prop);
                        customPropManager.Add3(prop, (int)swCustomInfoType_e.swCustomInfoText, defVal, (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);
                    }
                    else
                    {
                        customPropManager.Add3(prop, (int)swCustomInfoType_e.swCustomInfoText, defVal, (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);
                    }
                }
                catch (Exception ex)
                {
                    customPropManager.Add3(prop, (int)swCustomInfoType_e.swCustomInfoText, defVal, (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);
                }
            }

            if (partInfo != null)
            {
                customPropManager.Set2("PartName", partInfo.PartName ?? "");
                customPropManager.Set2("Rota", partInfo.Rota ?? "");
                customPropManager.Set2("Miktar", partInfo.Miktar == null ? "0" : partInfo.Miktar.ToString());

                part.SaveSilent();
                if (Control.ModifierKeys == Keys.Shift) _sldApp.CloseDoc(part.GetPathName());
                return;
            }

            part.SaveSilent();
        }

        public void WriteToCustomProps(string partPath, string field, object value)
        {
            List<string> propList = new List<string>();
            propList.Add("PartCode");
            propList.Add("PartName");
            propList.Add("Rota");
            propList.Add("Miktar");

            var docs = (object[])ActiveAssembly.GetComponents(false);
            foreach (var doc in docs)
            {
                Component2 comp = (Component2)doc;
                if (comp.GetPathName() == partPath)
                {
                    ModelDoc2 part = (ModelDoc2)comp.GetModelDoc2();
                    var customPropManager = part.Extension.get_CustomPropertyManager("");
                    string[] fields = (string[])customPropManager.GetNames();

                    for (int i = 0; i < fields.Length; i++) propList.Remove(fields[0]);
                    for (int i = 0; i < propList.Count; i++)
                    {
                        string name = propList[i];
                        string defVal = CustomProps.Find(p => p.PropName == name).DefaultVal.ToString();
                        customPropManager.Add3(name, (int)swCustomInfoType_e.swCustomInfoText, defVal, (int)swCustomPropertyAddOption_e.swCustomPropertyOnlyIfNew);
                    }

                    customPropManager.Set2(field, value.ToString());
                    part.SaveSilent();
                    return;
                }
            }
        }

        List<Component2> comps = new List<Component2>();
        public void GetBomPartCount()
        {
            comps = new List<Component2>();
            var docs = (object[])ActiveAssembly.GetComponents(false);

            foreach (var doc in docs)
            {
                var comp = (Component2)doc;
                string path = comp.GetPathName();
                string ext = path.Substring(path.Length - 7);
                if (ext == ".sldprt" || ext == ".SLDPRT")
                {
                    comps.Add(comp);
                }
            }

            TotalCount = comps.Count;
        }

        private void ResetTables()
        {
            UrunAgaciTable = new DataTable();
            UrunAgaciTable.Columns.Add("KeyId", typeof(int));
            UrunAgaciTable.Columns.Add("Child", typeof(string));
            UrunAgaciTable.Columns.Add("ParentId", typeof(int));
            UrunAgaciTable.Columns.Add("Parent", typeof(string));
            UrunAgaciTable.Columns.Add("Miktar", typeof(decimal));
            UrunAgaciTable.Columns.Add("Birim", typeof(string));
            UrunAgaciTable.Columns.Add("Montaj", typeof(bool));

            MontajTable = UrunAgaciTable.Clone();
            //ParcaTable = UrunAgaciTable.Clone();
            montajCount = 0;
            //parcaCount = 0;
        }

        private DataTable MontajTable;
        private DataTable ParcaTable;
        private int montajCount;
        private int parcaCount;

        public void StartRecursiveSearch()
        {
            ProductCode = "";

            ResetTables();

            Errors = new List<string>();
            TotalCount = 0;
            PartCount = 0;
            SearchError = false;
            GetBomPartCount();

            object[] objArr = new object[1];
            objArr[0] = ActiveAssembly;

            sheetMetals = new List<SheetMetal>();
            parts = new List<ModelDoc2>();
            SearchThread = new Thread(new ParameterizedThreadStart(RecursiveSearch));
            SearchThread.IsBackground = true;
            SearchThread.Start(objArr);
        }

        public void StopRecursiveSearch()
        {
            ThreadCanceled = true;
            if (SearchThread != null) SearchThread.Abort();
            PartCount = 0;
            TotalCount = 0;
            Errors = new List<string>();

            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
        }

        public void GetUrunAgaci()
        {
            ResetTables();

            _sldApp.CommandInProgress = true;
            var modDoc = ActiveAssembly as ModelDoc2;
            mainAssemblyName = modDoc.GetTitle();

            montajCount++;
            UrunAgaciTable.Rows.Add(montajCount, mainAssemblyName, -1, "", 1, "ADT", true);

            Action<Component2> action = LogComponentName;
            var swFeature = modDoc.FirstFeature() as Feature;
            while (swFeature != null)
            {
                TraverseFeatureForComponents(swFeature, action);
                swFeature = swFeature.GetNextFeature() as Feature;
            }
            _sldApp.CommandInProgress = false;
            mainAssemblyName = "";

            DataTable dt = UrunAgaciTable.Clone();
            UrunAgaciTable = UrunAgaciTable.AsEnumerable()
                .GroupBy(row => new
                {
                    KeyId = row.Field<int>("KeyId"),
                    Child = row.Field<string>("Child"),
                    ParentId = row.Field<int>("ParentId"),
                    Parent = row.Field<string>("Parent"),
                    Birim = row.Field<string>("Birim"),
                    Montaj = row.Field<bool>("Montaj"),
                })
                .Select(group => 
                {
                    var row = dt.NewRow();

                    row["KeyId"] = group.Key.KeyId;
                    row["Child"] = group.Key.Child;
                    row["ParentId"] = group.Key.ParentId;
                    row["Parent"] = group.Key.Parent;
                    row["Miktar"] = group.Sum(r => (decimal)r["Miktar"]);
                    row["Birim"] = group.Key.Birim;
                    row["Montaj"] = group.Key.Montaj;

                    return row;

                }).CopyToDataTable();

            var h = 9;
        }

        void LogComponentName(Component2 swComponent)
        {
            // this code is not performant  
            int parentCount = 0;
            Component2 swParentComponent;
            swParentComponent = swComponent.GetParent();

            int parentId = 1;
            var parent = mainAssemblyName;
            var montaj = false;
            if (swParentComponent != null)
            {
                parent = Path.GetFileName(swParentComponent.GetPathName());
                DataView dv = new DataView(UrunAgaciTable);
                dv.RowFilter = "[Child] = '" + parent + "'";
                DataTable filteredTable = dv.ToTable();
                parentId = Convert.ToInt32(filteredTable.Rows[0]["KeyId"]);
            }

            string fName = Path.GetFileName(swComponent.GetPathName());
            ModelDoc2 md = swComponent.GetModelDoc2();

            montajCount++;

            Enum.TryParse(md.GetType().ToString(), out swDocumentTypes_e value);

            int id = montajCount;
            if (value == swDocumentTypes_e.swDocASSEMBLY)
            {
                id = montajCount;
                montaj = true;
            }

            UrunAgaciTable.Rows.Add(id, fName, parentId, parent, 1, "ADT", montaj);

            Console.WriteLine($"{parent} {fName}");

            return;
            while (swParentComponent != null)
            {
                parentCount++;
                swParentComponent = swParentComponent.GetParent();
            }
            string indentation = string.Join(string.Empty, Enumerable.Repeat(" ", parentCount));
            string fileNameOnly = System.IO.Path.GetFileName(swComponent.GetPathName());
            Console.WriteLine($"{indentation}{fileNameOnly}");
        }

        void TraverseFeatureForComponents(Feature swFeature, Action<Component2> performAction)
        {
            var swSubFeature = default(Feature);

            var swComponent = swFeature.GetSpecificFeature2() as Component2;
            if (swComponent != null)
            {
                performAction(swComponent);

                swSubFeature = swComponent.FirstFeature();
                while (swSubFeature != null)
                {
                    TraverseFeatureForComponents(swSubFeature, performAction);
                    swSubFeature = swSubFeature.GetNextFeature() as Feature;
                }
            }
        }

        public void RecursiveSearch(object parameters)
        {
            object[] objArr = (object[])parameters;
            AssemblyDoc oAsmDoc = (AssemblyDoc)objArr[0];

            _sldApp.CommandInProgress = true;

            string fileName = "";

            foreach (var comp in comps)
            {
                int count = 0;
                fileName = comp.GetPathName();
                string ext = fileName.Substring(fileName.Length - 7);
                //Console.WriteLine(comp.GetParent().Name);
                int miktar = 0;
                PartCount++;

                ModelDoc2 compOccur = comp.IGetModelDoc();
                if (compOccur == null)
                {
                    using (StreamWriter w = File.AppendText("D:\\error_log.txt"))
                    {
                        w.WriteLine(fileName);
                    }

                    count++;
                    continue;
                }

                //swDocumentTypes_e compOccurType = (swDocumentTypes_e)compOccur.GetType();

                fileName = compOccur.GetPathName();
                string foundPath = null;

                try
                {
                    if (FilePaths.Count > 0)
                    {
                        foundPath = FilePaths.FirstOrDefault(p => p[1] == fileName)[1];
                    }
                }
                catch (Exception ex) { }

                if (foundPath == null)
                {
                    CheckCustomProps(compOccur);
                    FilePaths.Add(new[] { compOccur.GetTitle(), fileName });
                }

                SearchResult searchResult = new SearchResult();

                try
                {
                    if (!parts.Contains(compOccur))
                    {
                        parts.Add(compOccur);
                        miktar = 0;
                        compOccur.set_CustomInfo("Miktar", miktar.ToString());
                    }

                    //miktar += takim;
                    int val = miktar + Convert.ToInt32(compOccur.get_CustomInfo("Miktar"));
                    compOccur.set_CustomInfo("Miktar", val.ToString());

                    PartDoc prtDoc = (PartDoc)compOccur;
                    var bodies = prtDoc.GetBodies2((int)swBodyType_e.swSolidBody, false);
                    if (bodies != null)
                    {
                        foreach (Body2 body in bodies)
                        {
                            if (body.IsSheetMetal()) //parça sheet metal ise
                            {
                                int index = sheetMetals.FindIndex(o => o.SheetBody == compOccur);
                                if (index == -1)
                                    sheetMetals.Add(new SheetMetal(compOccur, false, -1, -1, miktar, -1));
                                else sheetMetals[index].Adet += miktar;
                                break;
                            }
                        }
                    }

                    var customPropManager = compOccur.Extension.get_CustomPropertyManager("");
                    List<CustomProp> propList = new List<CustomProp>();
                    object[] fields = (object[])customPropManager.GetNames();
                    foreach (var fieldObj in fields)
                    {
                        string field = fieldObj.ToString();
                        string value = "";
                        string resValue = "";
                        customPropManager.Get4(field, false, out value, out resValue);
                        string type = ((swCustomInfoType_e)customPropManager.GetType2(field)).ToString();
                        type = type.Substring(12); // "swCustomInfo" parçasını alma

                        propList.Add(new CustomProp { PropName = field, PropType = type, Val = (dynamic)resValue });
                    }
                    searchResult.PartPath = compOccur.GetPathName();
                    searchResult.PartFile = compOccur.GetTitle();
                    searchResult.PartCount = PartCount;
                    searchResult.TotalCount = TotalCount;
                    searchResult.Index = -1;
                    searchResult.Miktar = 1;
                    searchResult.AssemblyFile = ((ModelDoc2)oAsmDoc).GetTitle();
                    searchResult.Miktar = Convert.ToInt32(propList.Find(p => p.PropName == "Miktar").Val);
                    searchResult.PartName = propList.Find(p => p.PropName == "PartName").Val;
                    searchResult.Rota = propList.Find(p => p.PropName == "Rota").Val;

                    //var thumb = _sldApp.GetPreviewBitmap(compOccur.GetPathName(), "Default");
                    //Image image = AxHostConverter.PictureDispToImage(thumb);

                    //string thumbPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.MyDocuments) + "\\prtthumb.bmp";
                    //compOccur.SaveBMP(thumbPath, 400, 400);
                    //Image thumb = Image.FromFile(thumbPath);

                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                    GC.Collect();
                    GC.WaitForPendingFinalizers();
                }
                catch (Exception ex)
                {
                    SearchError = true;
                    ThreadCanceled = true;
                    Errors.Add("RecursiveSearch - " + fileName);
                    //MessageBox.Show("count= " + count.ToString() + " " + ex.ToString());
                    //MessageBox.Show("Hata! - " + prt.FullFileName);
                    //return;
                }

                if (ThreadCanceled)
                {
                    if (SearchError) SearchErrorOccured();

                    if (SearchThread != null) SearchThread.Abort();
                    SearchThread = null;
                }

                SearchResultUpdated(searchResult);

                count++;
            }


            _sldApp.CommandInProgress = false;
        }

        public void SearchResultUpdated(SearchResult searchResult)
        {
            if (OnSearchResultComplete == null) return;

            RecursiveEventArgs args = new RecursiveEventArgs(searchResult);
            OnSearchResultComplete(this, args);
        }

        public void SearchErrorOccured()
        {
            if (OnSearchError == null) return;

            EventArgs args = new EventArgs();
            OnSearchError(this, args);
        }

        public void RefreshAssembly()
        {
            ModelDoc2 asmb = (ModelDoc2)ActiveAssembly;
            asmb.SaveSilent();
        }

        public void UpdateAssembly()
        {
            ActiveAssembly.EditRebuild();
            _sldApp.IActiveDoc2.SaveSilent();
        }

        public void UpdatePartMaterial(PartInfo partInfo)
        {
            //Material kısmına bakılacak!!!
            //ActivePart.ComponentDefinition.Material = ActivePart.Materials[partInfo.Material];
            //ActivePart

            CheckCustomProps(ActivePart, partInfo);
        }

        #endregion

    }
}
