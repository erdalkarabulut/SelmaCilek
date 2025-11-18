using System;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Entities.Concrete.IS;
using Bps.BpsBase.Entities.Concrete.UR;
using Bps.BpsBase.Entities.Models.IS.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Newtonsoft.Json;

namespace Bps.BpsBase.WebAPI.Controllers
{
	[Route("api/Uretim/{action}", Name = "UretimApi")]
	public class UretimController : ApiController
	{
		protected IUrsureService _ursureService;
		protected IIsplanService _isplanService;

		public UretimController(IUrsureService ursureService, IIsplanService isplanService)
		{
			_ursureService = ursureService;
			_isplanService = isplanService;
		}

		public UretimController()
		{
		}

		[HttpPost]
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public ListResponse<URSURE> GetUretimSureListByIsplanId(List<dynamic> data)
		{
			Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
			var isplanIdDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(data[1].ToString());
			int isplanId = Convert.ToInt32(isplanIdDic["ISPLID"]);

			var response = _ursureService.Ncch_GetUretimSureListByIsplanId_NLog(global, isplanId, false);

			if (response.Status == ResponseStatusEnum.OK)
			{
				response.Message = "";
				response.ErrorCode = "";
				response.ErrorMessage = "";
				response.RequestMessage = "";
			}

			return response;
		}

		[HttpPost]
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public ListResponse<URSURE> GetUretimAcikSureList(List<dynamic> data)
		{
			Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());

			var response = _ursureService.Ncch_GetUretimAcikSureList_NLog(global, false);

			if (response.Status == ResponseStatusEnum.OK)
			{
				response.Message = "";
				response.ErrorCode = "";
				response.ErrorMessage = "";
				response.RequestMessage = "";
			}

			return response;
		}

		[HttpPost]
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public ListResponse<URSURE> GetUretimSureListByStokKodu(List<dynamic> data)
		{
			Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
			var dataDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(data[1].ToString());
			string ispkod = dataDic["ISPKOD"].ToString();
			string stkodu = dataDic["STKODU"].ToString();
			string gnrevz = dataDic["GNREZV"].ToString();
			string urakod = dataDic["URAKOD"].ToString();
			string uryrkd = dataDic["URYRKD"].ToString();

			var response = _ursureService.Ncch_GetUretimSureListByStokKodu_NLog(global, ispkod, stkodu, gnrevz, urakod, uryrkd, false);

			if (response.Status == ResponseStatusEnum.OK)
			{
				response.Message = "";
				response.ErrorCode = "";
				response.ErrorMessage = "";
				response.RequestMessage = "";
			}

			return response;
		}

		[HttpPost]
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public StandardResponse<URSURE> UretimSureKaydet(List<dynamic> data)
		{
			Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
			URSURE ursure = JsonConvert.DeserializeObject<URSURE>(data[1].ToString());

			ISPLAN isplan = _isplanService.Ncch_GetById_NLog(ursure.ISPLID.Value, global, false).Nesne;

			if (ursure.Id == 0)
			{
				ursure.ACTIVE = true;
				ursure.SLINDI = false;
				ursure.CHKCTR = false;
				ursure.EKKULL = global.UserKod;
				ursure.ETARIH = DateTime.Now;
				ursure.ISBASL = DateTime.Now;
				ursure.KYNKKD = "3";

				isplan.BASTAR = ursure.ISBASL;
				_isplanService.Ncch_UpdatePlan_Log(isplan, global);
			}
			else
			{
				string durusKodu = ursure.URDRKD;
				decimal? miktar = ursure.GRMKTR;
				ursure = _ursureService.Ncch_GetById_NLog(ursure.Id, global, false).Nesne;
				ursure.URDRKD = durusKodu;
				ursure.GRMKTR = miktar;
				ursure.ISBITS = DateTime.Now;
				ursure.DEKULL = global.UserKod;
				ursure.DTARIH = DateTime.Now;

				if (isplan.GRMKTR == null) isplan.GRMKTR = 0;
				isplan.GRMKTR += ursure.GRMKTR;

				if (durusKodu == "00" && ursure.ISLTUR == "İŞLEM") isplan.FLGKPN = true;
			}

			_isplanService.Ncch_UpdatePlan_Log(isplan, global);

			var response = _ursureService.Ncch_UretimSureKaydet_NLog(ursure, global, false);

			if (response.Status == ResponseStatusEnum.OK)
			{
				response.Message = "";
				response.ErrorCode = "";
				response.ErrorMessage = "";
				response.RequestMessage = "";
			}

			return response;
		}
	}
}