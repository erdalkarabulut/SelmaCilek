using System.Web.Http;
using System.Web.Http.Cors;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Entities.Models.IK.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;

namespace Bps.BpsBase.WebAPI.Controllers
{
    [Route("api/Personel/{action}", Name = "PersonelApi")]
    public class PersonelController : ApiController
    {
        protected IIkpersService _ikpersService;

        public PersonelController(IIkpersService ikpersService)
        {
            _ikpersService = ikpersService;
        }

        public PersonelController()
        {
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ListResponse<IkpersSicilAdPozModel> GetPersonelListTerm(Global global)
        {
            var response = _ikpersService.Ncch_GetListPersonelSicilAdPoz_NLog(global, false);

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