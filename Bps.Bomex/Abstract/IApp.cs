using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Threading;
using BOMex.Core;
using Bps.Bomex.Models;

namespace Bps.Bomex.Abstract
{
    public delegate void RecursiveEventHandler(object sender, RecursiveEventArgs e);
    public delegate void SearchErrorEventHandler(object sender, EventArgs e);

    public interface IApp
    {
        //Properties
        string ProductCode { get; set; }

        bool SearchError { get; set; }

        bool ThreadCanceled { get; set; }

        int TotalCount { get; set; }

        int PartCount { get; set; }

        string ActiveDocumentPath { get; set; }

        AppType ApplicationType { get; set; }

        Thread SearchThread { get; set; }

        DataTable UrunAgaciTable { get; set; }

        List<string[]> FilePaths { get; set; }

        List<CustomProp> CustomProps { get; set; }

        List<string> Errors { get; set; }


        //Events
        event RecursiveEventHandler OnSearchResultComplete;

        event SearchErrorEventHandler OnSearchError;


        //Methods
        bool AppIsOpen();

        Image GetPartThumbnail(string partPath);

        DocType GetActiveDocType();

        PartInfo GetPartInfo(object prt = null);

        void GetActiveDocumentPath();

        void OpenPart(string partPath, int miktar = -1);

        List<CustomProp> GetCustomProps();

        void CheckCustomProps(object doc, PartInfo partInfo = null);

        void WriteToCustomProps(string docPath, string field, object value);

        void GetBomPartCount();

        void StartRecursiveSearch();

        void StopRecursiveSearch();

        void RecursiveSearch(object parameters);

        void SearchResultUpdated(SearchResult searchResult);

        void SearchErrorOccured();

        void RefreshAssembly();

        void UpdateAssembly();

        void GetUrunAgaci();

        void UpdatePartMaterial(PartInfo partInfo);
    }
}
