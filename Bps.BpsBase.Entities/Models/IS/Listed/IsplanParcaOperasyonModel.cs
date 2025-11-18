using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.IS.Listed
{
	public class IsplanParcaOperasyonModel
	{
		[CsDisplayName("Id")]
		public int Id { get; set; }

		[CsDisplayName("Şirket Id")]
		public int SIRKID { get; set; }

		[CsDisplayName("Üretim Yeri")]
		public string URYRKD { get; set; }

		[CsDisplayName("Plan No")]
		public string ISPKOD { get; set; }

		[CsDisplayName("Plan Sıra No")]
		public int? SIRASI { get; set; }

		[CsDisplayName("Revizyon No")]
		public string GNREZV { get; set; }

		[CsDisplayName("Ürün Ağacı Kodu")]
		public string URAKOD { get; set; }

		[CsDisplayName("Stok Kodu")]
		public string STKODU { get; set; }

		[CsDisplayName("Stok Adı")]
		public string STKNAM { get; set; }

		[CsDisplayName("Giren Miktar")]
		public decimal? GRMKTR { get; set; }

		[CsDisplayName("Ölçü Birimi")]
		public string GROLBR { get; set; }

		[CsDisplayName("İşyeri Kodu")]
		public string ISYKOD { get; set; }

		[CsDisplayName("İşyeri Tanımı")]
		public string ISYTNM { get; set; }

		[CsDisplayName("Operasyon Kodu")]
		public string ISOPKD { get; set; }

		[CsDisplayName("Operasyon Tanımı")]
		public string ISOPTN { get; set; }

		[CsDisplayName("İşlem No")]
		public int? ISLMNO { get; set; }

		[CsDisplayName("Başlama Zamanı")]
		public DateTime? BASTAR { get; set; }

		[CsDisplayName("Hazırlık Süresi")]
		public int? GNHZSR { get; set; }

		[CsDisplayName("Hazırlık Süre Birim")]
		public string GNHZOB { get; set; }

		[CsDisplayName("İşlem Süresi")]
		public int? ISLMSR { get; set; }

		[CsDisplayName("İşlem Süre Birim")]
		public string ISLMSB { get; set; }

		[CsDisplayName("Tamamlandı")]
		public bool FLGKPN { get; set; }

		public IsplanOperasyonModel ShallowCopy()
		{
			return (IsplanOperasyonModel)this.MemberwiseClone();
		}
	}
}