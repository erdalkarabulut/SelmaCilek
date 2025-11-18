using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.SN;
using Bps.BpsBase.Entities.Concrete.SN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.SN
{
    public class EfSnkrtyDal : EfEntityRepositoryBase<SNKRTY, BpsContext>, ISnkrtyDal
    {
    }
}
