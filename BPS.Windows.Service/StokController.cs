using Bps.BpsBase.Business.Abstract.ST;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.Business.Abstract.XX;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service
{
    [Route("api/StokKart/{action}", Name = "StokKartApi")]
    public class StokController : Bps.BpsBase.WebAPI.Controllers.StokController
    {
        public StokController()
        {
            _sthrktService = InstanceFactory.GetInstance<ISthrktService>();
            _stkartService = InstanceFactory.GetInstance<IStkartService>();
            _stftipService = InstanceFactory.GetInstance<IStftipService>();
            _stdepoService = InstanceFactory.GetInstance<IStdepoService>();
            _wmhratService = InstanceFactory.GetInstance<IWmhratService>();
            _xxService = InstanceFactory.GetInstance<IXXService>();
        }
    }
}
