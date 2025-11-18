using System.Web.Http;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service.Controllers
{
    [Route("api/Siparis/{action}", Name = "SiparisApi")]
    public class SiparisController : Bps.BpsBase.WebAPI.Controllers.SiparisController
    {
        public SiparisController()
        {
            _spfbasService = InstanceFactory.GetInstance<ISpfbasService>();
            _spfharService = InstanceFactory.GetInstance<ISpfharService>();
            _wmadrsService = InstanceFactory.GetInstance<IWmadrsService>();
        }
    }
}
