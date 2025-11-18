using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.UR;
using Bps.BpsBase.Entities.Concrete.UR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.UR
{
    public class EfUragacDal : EfEntityRepositoryBase<URAGAC, BpsContext>, IUragacDal
    {
    }
}
