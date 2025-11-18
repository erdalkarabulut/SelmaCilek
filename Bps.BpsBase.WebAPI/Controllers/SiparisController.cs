using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SP;
using Bps.BpsBase.Entities.Models.SP.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Utilities.Converters;
using Newtonsoft.Json;
using Convert = System.Convert;


namespace Bps.BpsBase.WebAPI.Controllers
{
    [Route("api/Siparis/{action}", Name = "SiparisApi")]
    public class SiparisController : ApiController
    {
        protected ISpfbasService _spfbasService;
        protected ISpfharService _spfharService;
        protected IWmadrsService _wmadrsService;

        public SiparisController(ISpfbasService spfbasService, ISpfharService spfharService, IWmadrsService wmadrsService)
        {
            _spfbasService = spfbasService;
            _spfharService = spfharService;
            _wmadrsService = wmadrsService;
        }

        public SiparisController()
        {
        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public ListResponse<SpBaslikAcikModel> GetAcikSiparisListTerm(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            List<string> parameters = JsonConvert.DeserializeObject<List<string>>(data[1].ToString());
            int sphrtp = Convert.ToInt32(parameters[0]);

            var response = _spfbasService.Ncch_GetAcikSiparisList_NLog(global, sphrtp, false);

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
        public ListResponse<SpRezervasyonPaket> GetRezervasyonPaketListTerm(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            List<string> parameters = JsonConvert.DeserializeObject<List<string>>(data[1].ToString());

            var response = _spfbasService.Ncch_GetRezervasyonPaketList_NLog(parameters[0], global, false);

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
        public ListResponse<SpStokAdresMiktar> GetSpStokAdresMiktarListTerm(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            List<string> parameters = JsonConvert.DeserializeObject<List<string>>(data[1].ToString());
            bool rezervasyon = Convert.ToBoolean(parameters[1]);
            
            ListResponse<SpStokAdresMiktar> response = _wmadrsService.GetSiparisStokAdresMiktar(global, parameters[0], rezervasyon, false);

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
        public ListResponse<SPFHAR> GetSiparisKalemListTerm(List<dynamic> data)
        {
            Global global = JsonConvert.DeserializeObject<Global>(data[0].ToString());
            List<string> parameters = JsonConvert.DeserializeObject<List<string>>(data[1].ToString());

            var response = _spfharService.Cch_GetListByBelge_NLog(parameters[0], global);

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