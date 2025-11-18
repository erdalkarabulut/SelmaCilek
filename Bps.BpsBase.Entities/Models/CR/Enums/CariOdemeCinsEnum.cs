using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.CR.Enums
{
    public enum CariOdemeCinsEnum
    {

        [Description("SERBEST")]
        Serbest = 0,
        [Description("HAFTALIK")]
        Haftalik = 1,
        [Description("AYLIK")]
        Aylık = 2,
        [Description("15 Günlük")]
        OnBesGunluk = 3
    }
}