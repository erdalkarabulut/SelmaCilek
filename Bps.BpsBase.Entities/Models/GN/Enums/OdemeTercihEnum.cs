using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.GN.Enums
{
    public enum OdemeTercihEnum
    {
        [Description("NAKİT")]
        Nakit = 0,
        [Description("MÜŞTERİ ÇEKİ")]
        MusteriCeki = 1,
        [Description("FİRMA ÇEKİ")]
        FirmaCeki = 2,
        [Description("MÜŞTERİ SENEDİ")]
        MusteriSenedi = 3,
        [Description("FİRMA SENEDİ")]
        FirmaSenedi = 4,
        [Description("HAVALE")]
        Havale = 5,
        [Description("ÖDEME EMRİ")]
        OdemeEmri = 6,
        [Description("DOĞRUDAN HAVALE")]
        DogrudanHavale = 7
    }
}