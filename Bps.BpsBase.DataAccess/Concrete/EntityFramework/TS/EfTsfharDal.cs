using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.TS;
using Bps.BpsBase.Entities.Concrete.TS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.TS
{
    public class EfTsfharDal : EfEntityRepositoryBase<TSFHAR, BpsContext>, ITsfharDal
    {
    }
}
