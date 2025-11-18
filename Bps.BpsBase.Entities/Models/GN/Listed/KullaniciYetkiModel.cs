using System;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
    [Serializable]
    public class KullaniciYetkiModel
    {
        public int Id { get; set; }

        public int SIRKID { get; set; }

        public string KULKOD { get; set; }

        public string PROKOD { get; set; }

        public string TANIMI { get; set; }

        public string MNUNAM { get; set; }

        public int MNUTAG { get; set; }

        public int PARENT { get; set; }

        public bool EKLEME { get; set; }

        public bool DEGIST { get; set; }

        public bool KAYDET { get; set; }

        public bool SILMEK { get; set; }

        public bool GRNTLM { get; set; }

        public bool PDFGOS { get; set; }

        public bool EXCGOS { get; set; }

        public bool YAZDIR { get; set; }

        public bool CSVGOS { get; set; }

        public bool XMLGOS { get; set; }

        public bool DOCGOS { get; set; }

        public bool GNONAY { get; set; }
    }
}
