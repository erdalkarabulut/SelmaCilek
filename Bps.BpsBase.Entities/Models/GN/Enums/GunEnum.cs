using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.GN.Enums
{
    public enum GunEnum
    {
        [Description("PAZAR")]
        Pazar = 0,
        [Description("PAZARTESİ")]
        Pazartesi = 1,
        [Description("SALI")]
        Sali = 2,
        [Description("ÇARŞAMBA")]
        Carsamba = 3,
        [Description("PERŞEMBE")]
        Persembe = 4,
        [Description("CUMA")]
        Cuma = 5,
        [Description("CUMARTESİ")]
        Cumartesi = 6
    }
}