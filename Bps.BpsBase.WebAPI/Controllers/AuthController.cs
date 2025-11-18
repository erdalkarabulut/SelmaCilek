using System.Web.Http;
using System.Web.Http.Cors;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.GN.Params;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;


namespace Bps.BpsBase.WebAPI.Controllers
{
    [Route("api/Auth/{action}", Name = "AuthApi")]
    public class AuthController : ApiController
    {
        protected IGnkullService _gnkullService;

        public AuthController(IGnkullService gnkullService)
        {
            _gnkullService = gnkullService;
        }

        public AuthController()
        {

        }

        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public StandardResponse<Global> LoginTerm(GirisParam girisParam)
        {
            var response = new StandardResponse<Global>();

            //girisParam = new GirisParam{
            //    SIRKID = 1,
            //    KULKOD = "ilkay",
            //    PASSWD = "1234",
            //    RememberMe = false,
            //    DilKod = "tr-TR",
            //    ReturnUrl = "",
            //    KaynakKod = "1"
            //};

            var loginResponse = _gnkullService.Ncch_UserLogin_Log(girisParam, "");
            response.Message = loginResponse.Message;
            response.Status = loginResponse.Status;

            if (loginResponse.Status == ResponseStatusEnum.OK)
            {
                GNKULL _kullanici = loginResponse.Nesne;
                
                if (_kullanici.ROLEKD != "TERM" && _kullanici.ROLEKD != "ADMIN")
                {
                    response.Status = ResponseStatusEnum.ERROR;
                    response.Message = "Bu kullanıcının terminal yetkisi yoktur!";
                    return response;
                }

                Global global = new Global();
                global.UserKod = _kullanici.KULKOD;
                global.UserId = _kullanici.Id;
                global.FirstName = _kullanici.GNNAME;
                global.LastName = _kullanici.GNSNAM;
                global.PersId = _kullanici.PERSID;
                global.Role = _kullanici.ROLEKD;
                global.KaynakKod = "1";
                global.DilKod = girisParam.KaynakKod;
                global.Email = _kullanici.GNMAIL;
                global.SirketId = girisParam.SIRKID;
                global.SirketType = true;

                response.Nesne = global;
                response.Message = "";
                response.ErrorCode = "";
                response.ErrorMessage = "";
                response.RequestMessage = "";
            }

            return response;
        }
    }
}