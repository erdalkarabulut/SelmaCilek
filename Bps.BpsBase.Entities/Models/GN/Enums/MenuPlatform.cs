using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.GN.Enums
{
    public enum MenuPlatform
    {
        [Description("Tümü")]
        All = 0,
        [Description("Sadece Masaüstü")]
        DesktopOnly = 1,
        [Description("Sadece Web")]
        WebOnly = 2,
        [Description("Sadece Mobil")]
        MobileOnly = 3
    }
}