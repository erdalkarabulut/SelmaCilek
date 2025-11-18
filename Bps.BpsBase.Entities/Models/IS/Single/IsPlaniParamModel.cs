using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.IS.Single
{
	public class IsPlaniParamModel
	{
		public bool Tamamlanan { get; set; }
		public string PlanNo { get; set; }
		public DateTime? DtBaslangic { get; set; }
		public DateTime? DtBitis { get; set; }
	}
}
