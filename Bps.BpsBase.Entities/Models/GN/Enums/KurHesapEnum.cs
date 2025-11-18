using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.GN.Enums
{
    public enum KurHesapEnum
    {
        [Description("DÖVİZ ALIŞ")]
        DovizAlis = 1,
        [Description("DÖVİZ SATIŞ")]
        DovizSatis = 2,
        [Description("EFEKTİF ALIŞ")]
        EfektifAlis = 3,
        [Description("EFEKTİF SATIŞ")]
        EfektifSatis = 4
    }
}