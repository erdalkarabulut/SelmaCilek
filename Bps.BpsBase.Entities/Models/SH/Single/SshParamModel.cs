using System;

namespace Bps.BpsBase.Entities.Models.SP.Single
{
    public class SshParamModel
    {
        public bool All { get; set; }
        public bool Tamamlanan { get; set; }
        public string BELGEN { get; set; }
        public DateTime? DtBaslangic { get; set; }
        public DateTime? DtBitis { get; set; }
    }
}