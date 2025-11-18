using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.IS.Listed
{
	public class IsplanUrunParcaModel
	{
		[CsDisplayName("Şirket Id")]
		public int SIRKID { get; set; }

		[CsDisplayName("Üretim Yeri")]
		public string URYRKD { get; set; }

		[CsDisplayName("Plan No")]
		public string ISPKOD { get; set; }

		[CsDisplayName("Plan Sıra No")]
		public int? SIRASI { get; set; }

		[CsDisplayName("Plan Tarihi")]
		public DateTime? GNTARH { get; set; }

		[CsDisplayName("Sipariş No")]
		public string ISMETN { get; set; }

		[CsDisplayName("Cari Kodu")]
		public string CRKODU { get; set; }

		[CsDisplayName("Cari Ünvan")]
		public string CRUNV1 { get; set; }

		[CsDisplayName("Revizyon No")]
		public string GNREZV { get; set; }

		[CsDisplayName("Ürün Ağacı Kodu")]
		public string URAKOD { get; set; }

		[CsDisplayName("Parent Ürün Ağacı Kodu")]
		public string PURKOD { get; set; }

		[CsDisplayName("Sipariş Satır No")]
		public int? SPSRNO { get; set; }

		[CsDisplayName("Sipariş Stok Kodu")]
		public string SPSTKD { get; set; }

		[CsDisplayName("Sipariş Stok Adı")]
		public string SPSTNM { get; set; }

		[CsDisplayName("Sipariş Stok Açıklama")]
		public string SPSTAC { get; set; }

		[CsDisplayName("Üst Stok Kodu")]
		public string MXPRKD { get; set; }

		[CsDisplayName("Üst Stok Adı")]
		public string MXPRNM { get; set; }

		[CsDisplayName("Stok Kodu")]
		public string STKODU { get; set; }

		[CsDisplayName("Stok Adı")]
		public string STKNAM { get; set; }

		[CsDisplayName("Plan Miktar")]
		public decimal? PLMKTR { get; set; }

		[CsDisplayName("Giren Miktar")]
		public decimal? GRMKTR { get; set; }

		[CsDisplayName("Ölçü Birimi")]
		public string GROLBR { get; set; }

		[CsDisplayName("Teknik Resim Yolu")]
		public string TEKPTH { get; set; }

		public IsplanUrunParcaModel ShallowCopy()
		{
			return (IsplanUrunParcaModel)this.MemberwiseClone();
		}
	}
}