using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.IS;
using Bps.BpsBase.Entities.Concrete.IS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.IS
{
    public class EfIsrevzDal : EfEntityRepositoryBase<ISREVZ, BpsContext>, IIsrevzDal
    {
    }
}
