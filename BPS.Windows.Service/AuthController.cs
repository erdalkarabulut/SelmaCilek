using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service
{
    public class AuthController : Bps.BpsBase.WebAPI.Controllers.AuthController
    {
        public AuthController()
        {
            _gnkullService = InstanceFactory.GetInstance<IGnkullService>();
        }
    }
}
