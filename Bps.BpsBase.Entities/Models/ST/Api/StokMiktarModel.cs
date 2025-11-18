using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.Entities.Models.ST.Api
{
	public class StokMiktarModel
	{
		public STKART Stkart { get; set; }

		public double Miktar { get; set; }

		public string Parti { get; set; }
	}
}