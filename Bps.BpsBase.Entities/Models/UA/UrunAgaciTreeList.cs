namespace Bps.BpsBase.Entities.Models.UA
{
    public class UrunAgaciTreeList
    {
        public int Id { get; set; }
        public int ParentId { get; set; }
        public int AltId { get; set; }
        public string RevizyonNo { get; set; }
        public string UrunAgaciKodu { get; set; }
        public string ParentUrunAgaciKodu { get; set; }
        public int Seviye { get; set; }
        public bool Silme { get; set; }
        public string StokKodu { get; set; }
        public string StokAdi { get; set; }
        public string UretimYeriKodu { get; set; }
        public string KalemTipi { get; set; }
        public string Siralama { get; set; }
        public string OlcuBirimiKodu { get; set; }
        public decimal Miktar { get; set; }
        public decimal SabitMiktar { get; set; }
        public byte[] StokResim { get; set; }
        public string MasterStokKodu { get; set; }
        public string ParentStokKodu { get; set; }
        public string MalzemeTuru { get; set; }
        public string AltUrunAgaciKodu { get; set; }
        public bool FantomKalemi { get; set; }
        public string VryKodu { get; set; }

        public UrunAgaciTreeList ShallowCopy()
        {
	        return (UrunAgaciTreeList)this.MemberwiseClone();
        }
    }
}