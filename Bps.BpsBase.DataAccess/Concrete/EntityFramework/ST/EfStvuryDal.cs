using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.ST;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.ST
{
    public class EfStvuryDal : EfEntityRepositoryBase<STVURY, BpsContext>, IStvuryDal
    {
    }
}
