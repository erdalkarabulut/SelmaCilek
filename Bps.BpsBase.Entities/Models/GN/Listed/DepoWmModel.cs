using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.BpsBase.Entities.Models.GN.Listed
{
	public class DepoWmModel
	{
		public int Id { get; set; }
		public int SIRKID { get; set; }
		public string URYRKD { get; set; }
		public string DPKODU { get; set; }
		public string DPTANM { get; set; }
		public bool? MIPGOS { get; set; }
		public bool? WM { get; set; }
    }
}
