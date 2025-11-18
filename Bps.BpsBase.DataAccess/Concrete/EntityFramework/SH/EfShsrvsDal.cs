using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.SH;
using Bps.BpsBase.Entities.Concrete.SH;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.SH
{
    public class EfShsrvsDal : EfEntityRepositoryBase<SHSRVS, BpsContext>, IShsrvsDal
    {
    }
}
