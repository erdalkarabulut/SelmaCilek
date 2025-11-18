using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract;
using Bps.BpsBase.Entities.Concrete;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework
{
    public class EfLockedDal : EfEntityRepositoryBase<LOCKED, BpsContext>, ILockedDal
    {
    }
}
