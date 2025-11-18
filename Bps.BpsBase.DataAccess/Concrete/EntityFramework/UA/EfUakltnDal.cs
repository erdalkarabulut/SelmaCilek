using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.UA;
using Bps.BpsBase.Entities.Concrete.UA;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.UA
{
    public class EfUakltnDal : EfEntityRepositoryBase<UAKLTN, BpsContext>, IUakltnDal
    {
    }
}
