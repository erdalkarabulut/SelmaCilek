using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.CM;
using Bps.BpsBase.Entities.Concrete.CM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.CM
{
    public class EfCmkartDal : EfEntityRepositoryBase<CMKART, BpsContext>, ICmkartDal
    {
    }
}
