using Bps.Core.Entities;

namespace Bps.Core.Web.Model
{
    public class ProjeMenuListed : IEntity
    {
        public int Id { get; set; }
        public string PROKOD { get; set; }
        public string MNUNAM { get; set; }
        public int MNUTAG { get; set; }
        public int PARENT { get; set; }
        public string PARENTNAME { get; set; }
        public int SIRASI { get; set; }
        public string GNICON { get; set; }
        public string CONTNM { get; set; }
        public string FUNCNM { get; set; }
        public string FORNM { get; set; }
        public string GNAREA { get; set; }
        public bool GRNTLM { get; set; }
        public bool EKLEME { get; set; }
        public bool DEGIST { get; set; }
        public bool KAYDET { get; set; }
        public bool SILMEK { get; set; }
        public bool PDFGOS { get; set; }
        public bool EXCGOS { get; set; }
        public bool YAZDIR { get; set; }
        public bool CSVGOS { get; set; }
        public bool XMLGOS { get; set; }
        public bool DOCGOS { get; set; }
        public bool GNONAY { get; set; }
        public bool KOPYAL { get; set; }
        public bool? Selected { get; set; }
        public bool? Expanded { get; set; }
    }
}