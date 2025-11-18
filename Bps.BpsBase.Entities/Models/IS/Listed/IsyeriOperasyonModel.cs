using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.IS.Listed
{
	public class IsyeriOperasyonModel
	{
		[CsDisplayName("Id")] 
		public int Id { get; set; }

		[CsDisplayName("Şirket Id")] 
		public int SIRKID { get; set; }

		[CsDisplayName("Üretim Yeri")] 
		public string URYRKD { get; set; }

		[CsDisplayName("İşyeri Bölüm")] 
		public string ISBLKD { get; set; }

		[CsDisplayName("İşyeri Kodu")]
		public string ISYKOD { get; set; }

		[CsDisplayName("İşyeri Tanım")] 
		public string ISYTNM { get; set; }

		[CsDisplayName("Operasyon Kodu")] 
		public string ISOPKD { get; set; }

		[CsDisplayName("Operasyon Tanımı")] 
		public string ISOPTN { get; set; }

	}
}