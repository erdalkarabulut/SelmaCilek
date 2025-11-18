using System.ComponentModel;

namespace Bps.BpsBase.Entities.Models.UA
{
    public class UrunAgaciKalemMalzemeJoin
    {
        [DisplayName("Ürün Ağacı Kodu")]
        public string UrunAgaciKodu { get; set; }
        [DisplayName("Stok Kodu")]
        public string StokKodu { get; set; }
        [DisplayName("Stok Adı")]
        public string StokAdi { get; set; }
        [DisplayName("Kalem Tanım")]
        public string KalemText { get; set; }
        [DisplayName("Ölçü Birimi")]
        public string OlcuBirimiKodu { get; set; }
        public decimal Miktar { get; set; }
        [DisplayName("Sabit Miktar")]
        public decimal SabitMiktar { get; set; }
        [DisplayName("Malzeme Türü")]
        public string MalzemeTuruText { get; set; }
    }
}