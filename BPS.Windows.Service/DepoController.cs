using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service
{
    [Route("api/Depo/{action}", Name = "DepoApi")]
    public class DepoController : Bps.BpsBase.WebAPI.Controllers.DepoController
    {
        public DepoController()
        {
            _gndptnService = InstanceFactory.GetInstance<IGndptnService>();
        }
    }
}
