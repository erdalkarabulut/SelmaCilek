using System.Web.Http;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service.Controllers
{
	[Route("api/Uretim/{action}", Name = "UretimApi")]
	public class UretimController : Bps.BpsBase.WebAPI.Controllers.UretimController
	{
		public UretimController()
		{
			_ursureService = InstanceFactory.GetInstance<IUrsureService>();
			_isplanService = InstanceFactory.GetInstance<IIsplanService>();
		}
	}
}