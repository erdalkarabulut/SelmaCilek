using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.IS.Listed
{
	public class IsplanOperasyonDurumModel
	{
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

		[CsDisplayName("Üst Stok Kodu")]
		public string MXPRKD { get; set; }

		[CsDisplayName("Stok Kodu")]
		public string STKODU { get; set; }

		[CsDisplayName("Giren Miktar")]
		public decimal? GRMKTR { get; set; }

		[CsDisplayName("Ölçü Birimi")]
		public string GROLBR { get; set; }

		[CsDisplayName("Operasyon Kodu")]
		public string ISOPKD { get; set; }

		[CsDisplayName("İşlem No")]
		public int? ISLMNO { get; set; }

		[CsDisplayName("Tamamlandı")]
		public bool FLGKPN { get; set; }

		public IsplanOperasyonDurumModel ShallowCopy()
		{
			return (IsplanOperasyonDurumModel)this.MemberwiseClone();
		}
	}
}