using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.IS.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Newtonsoft.Json;

namespace Bps.BpsBase.WebAPI.Controllers
{
	[Route("api/Plan/{action}", Name = "PlanApi")]
	public class PlanController : ApiController
	{
		protected IIsplanService _isplanService;
		protected IGnklopService _gnklopService;

		public PlanController(IIsplanService isplanService, IGnklopService gnklopService)
		{
			_isplanService = isplanService;
			_gnklopService = gnklopService;
		}

		public PlanController()
		{
		}

		[HttpPost]
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public ListResponse<IsplanOperasyonModel> GetIsplanOperasyonList(Global global)
		{
			var response = _isplanService.Ncch_GetIsplanOperasyonList_NLog(global, false);

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
		public ListResponse<IsplanOperasyonModel> GetIsplanOperasyonDurumList(Global global)
		{
			var response = _isplanService.Ncch_GetIsplanOperasyonDurumList_NLog(global, false);

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
		public ListResponse<IsplanParcaOperasyonModel> GetIsplanParcaOperasyonList(List<dynamic> data)
		{
			Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
			var dataDic = JsonConvert.DeserializeObject<Dictionary<string, object>>(data[1].ToString());
			string uryrkd = dataDic["URYRKD"].ToString();
			string ispkod = dataDic["ISPKOD"].ToString();
			string gnrevz = dataDic["GNREZV"].ToString();
			string urakod = dataDic["URAKOD"].ToString();
			string stkodu = dataDic["STKODU"].ToString();

			var response = _isplanService.Ncch_GetIsplanParcaOperasyonList_NLog(global, uryrkd, ispkod, gnrevz, urakod, stkodu, false);

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
		public ListResponse<IsplanUrunParcaModel> GetIsplanUrunParcaList(Global global)
		{
			var response = _isplanService.Ncch_GetIsplanUrunParcaList_NLog(global, "", false);

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
		public ListResponse<IsyeriOperasyonModel> GetIsyeriOperasyonList(Global global)
		{
			var response = _isplanService.Ncch_GetIsyeriOperasyonList_NLog(global, false);

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
		public ListResponse<string> GetUserIsyeriOperasyonList(Global global)
		{
			var resp = _gnklopService.Ncch_GetListByPersonelId_NLog(global.PersId.Value, global, false);

			ListResponse<string> response = new ListResponse<string>();
			if (response.Status == ResponseStatusEnum.OK)
			{
				response.Items = new List<string>();
				foreach (GNKLOP gnklop in resp.Items) response.Items.Add(gnklop.ISOPKD);

				response.Message = "";
				response.ErrorCode = "";
				response.ErrorMessage = "";
				response.RequestMessage = "";
			}

			return response;
		}
	}
}