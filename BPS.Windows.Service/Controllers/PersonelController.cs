using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service.Controllers
{
    [Route("api/Personel/{action}", Name = "PersonelApi")]
    public class PersonelController : Bps.BpsBase.WebAPI.Controllers.PersonelController
    {
        public PersonelController()
        {
            _ikpersService = InstanceFactory.GetInstance<IIkpersService>();
        }
    }
}
