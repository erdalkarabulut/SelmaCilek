using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.CR;
using Bps.BpsBase.Entities.Concrete.CR;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.CR
{
    public class EfCrytklDal : EfEntityRepositoryBase<CRYTKL, BpsContext>, ICrytklDal
    {
    }
}
