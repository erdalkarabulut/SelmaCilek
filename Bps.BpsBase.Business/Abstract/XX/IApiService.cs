using System.Collections.Generic;
using System.Threading.Tasks;
using Bps.BpsBase.Entities.Concrete.SH;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.BpsBase.Entities.Models.TS;
using Bps.BpsBase.Entities.Models.WM.Api;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.WinForm;

namespace Bps.BpsBase.Business.Abstract.XX
{
	public interface IApiService
	{
		List<string> GetCariTamAdres(Global global, string crkodu, out List<string> adresSeparate);

		string Ncch_GetStokRapor_NLog(Global global, bool withPrice = false, bool yetkiKontrol = false);

		string Ncch_GetSiparisFisTipList_NLog(Global global, bool yetkiKontrol = false);

		string Ncch_GetServisParametreInfo_NLog(Global global, bool yetkiKontrol = false);

		string Ncch_GetServisKartList_NLog(Global global, SshParamModel param, bool yetkiKontrol = false);

		string Ncch_GetSpfbasList_NLog(Global global, SiparisParamModel param, bool yetkiKontrol = false);

		Task<string> Ncch_SaveServisKart_NLog(Global global, Dictionary<string, object> shsrvsDictionary,
			bool yetkiKontrol = false);

		string Ncch_SaveCariYetkili_NLog(Global global, Dictionary<string, object> yetkiliDictionary,
			bool yetkiKontrol = false);
	}
}