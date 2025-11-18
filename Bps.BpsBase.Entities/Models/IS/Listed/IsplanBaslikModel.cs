using System;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.IS.Listed
{
	public class IsplanBaslikModel
	{

		[CsDisplayName("ISPKOD")]
		public string ISPKOD { get; set; }

		[CsDisplayName("SIPKOD")]
		public string SIPKOD { get; set; }

		[CsDisplayName("GNTARH")]
		public DateTime GNTARH { get; set; }

		[CsDisplayName("CRKODU")]
		public string CRKODU { get; set; }

		[CsDisplayName("CRNAME")]
		public string CRNAME { get; set; }
	}
}