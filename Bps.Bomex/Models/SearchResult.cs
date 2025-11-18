using System.Drawing;

namespace Bps.Bomex.Models
{
    public class SearchResult
    {
        public SearchResult()
        {
            PartName = "";
            Rota = "";
        }

        public int PartCount { get; set; }
        public int TotalCount { get; set; }
        public int Index { get; set; }
        public string AssemblyFile { get; set; }
        public string PartFile { get; set; }
        public string PartName { get; set; }
        public int Miktar { get; set; }
        public string Rota { get; set; }
        public string PartPath { get; set; }
        public Image Thumbnail { get; set; }
    }
}
