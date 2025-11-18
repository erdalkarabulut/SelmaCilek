using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.IK;
using Bps.BpsBase.Entities.Concrete.IK;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.IK
{
    public class EfIkpersDal : EfEntityRepositoryBase<IKPERS, BpsContext>, IIkpersDal
    {
    }
}
