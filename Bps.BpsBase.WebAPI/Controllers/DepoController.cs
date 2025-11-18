using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;

namespace Bps.BpsBase.WebAPI.Controllers
{
	[Route("api/Depo/{action}", Name = "DepoApi")]
	public class DepoController : ApiController
	{
		protected IGndptnService _gndptnService;
		protected IGndpnoService _gndpnoService;

		public DepoController(IGndptnService gndptnService, IGndpnoService gndpnoService)
		{
			_gndptnService = gndptnService;
			_gndpnoService = gndpnoService;
		}

		public DepoController()
		{
		}

		[HttpPost]
		[EnableCors(origins: "*", headers: "*", methods: "*")]
		public ListResponse<DepoWmModel> GetDepoListTerm(Global global)
		{
			var depoList = _gndptnService.Cch_GetListAktif_NLog(global, false);
			var wmDepoList = _gndpnoService.Cch_GetListAktif_NLog(global, false);

			var response = new ListResponse<DepoWmModel>();
			response.Items = new List<DepoWmModel>();

			foreach (var depo in depoList.Items)
			{
				bool wm = wmDepoList.Items.FirstOrDefault(w => w.DPKODU == depo.DPKODU) != null;

				response.Items.Add(new DepoWmModel
				{
					Id = depo.Id,
					SIRKID = depo.SIRKID,
					URYRKD = depo.URYRKD,
					DPKODU = depo.DPKODU,
					DPTANM = depo.DPTANM,
					MIPGOS = depo.MIPGOS,
					WM = wm
				});
			}

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