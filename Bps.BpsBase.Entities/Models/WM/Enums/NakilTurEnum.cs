using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.WM.Enums
{
    public enum NakilTurEnum
    {
        //[Description("Depodan Çıkış")]
        //DepodanCikis = 'A',
        //[Description("Depolama")]
        //Depolama = 'E',
        //[Description("Nakil Kaydı")]
        //NakilKaydi = 'U',
        //[Description("Depo Gözetimi")]
        //DepoGozetimi = 'X'

        [Description("Depodan Çıkış")]
        DepodanCikis = 0,
        [Description("Depolama")]
        Depolama = 1,
        [Description("Nakil Kaydı")]
        NakilKaydi = 2,
        [Description("Depo Gözetimi")]
        DepoGozetimi = 3
    }
}