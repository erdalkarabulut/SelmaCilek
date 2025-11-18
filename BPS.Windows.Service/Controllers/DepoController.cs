using System.Web.Http;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service.Controllers
{
    [Route("api/Depo/{action}", Name = "DepoApi")]
    public class DepoController : Bps.BpsBase.WebAPI.Controllers.DepoController
    {
        public DepoController()
        {
            _gndptnService = InstanceFactory.GetInstance<IGndptnService>();
            _gndpnoService = InstanceFactory.GetInstance<IGndpnoService>();
        }
    }
}
