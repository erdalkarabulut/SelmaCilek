using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service.Controllers
{
    public class AuthController : Bps.BpsBase.WebAPI.Controllers.AuthController
    {
        public AuthController()
        {
            _gnkullService = InstanceFactory.GetInstance<IGnkullService>();
        }
    }
}
