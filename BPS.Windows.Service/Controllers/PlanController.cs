using System.Web.Http;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;

namespace BPS.Windows.Service.Controllers
{
	[Route("api/Plan/{action}", Name = "PlanApi")]
	public class PlanController : Bps.BpsBase.WebAPI.Controllers.PlanController
	{
		public PlanController()
		{
			_isplanService = InstanceFactory.GetInstance<IIsplanService>();
			_gnklopService = InstanceFactory.GetInstance<IGnklopService>();
		}
	}
}