using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.ST.Enums
{
    public enum HareketTipEnum
    {
        [Description("GİRİŞ")]
        Giris = 0,
        [Description("ÇIKIŞ")]
        Cikis = 1,
        [Description("GİRİŞ & ÇIKIŞ")]
        GirisCikis = 2
    }
}