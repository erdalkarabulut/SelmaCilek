namespace Bps.BpsBase.Entities.Models.GN.Params
{
    public class GirisParam
    {
        public int? SIRKID { get; set; }

        public string KULKOD { get; set; }

        public string PASSWD { get; set; }

        public bool RememberMe { get; set; }

        public string DilKod { get; set; }
        public string ReturnUrl { get; set; }
        public string KaynakKod { get; set; }
    }
}