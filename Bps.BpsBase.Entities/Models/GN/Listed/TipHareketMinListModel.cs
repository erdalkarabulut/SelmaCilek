using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using Bps.Core.AttributeHelpers;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
	[Serializable]
	public class TipHareketMinListModel
	{
		[DisplayName("ID")]
		public int Id { get; set; }

		[DisplayName("Şirket ID")]
		public int SIRKID { get; set; }

		[DisplayName("Tip Kod")]
		public string TIPKOD { get; set; }

		[DisplayName("Hareket Kodu")]
		public string HARKOD { get; set; }

		[DisplayName("Tanımı")]
		public string TANIMI { get; set; }

		[DisplayName("Parent")]
		public int PARENT { get; set; }

		[DisplayName("Sırası")]
		public int SIRASI { get; set; }
	}
}