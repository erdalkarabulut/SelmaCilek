using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.Entities.Concrete.SP;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.SP
{
    public class EfSpfbasDal : EfEntityRepositoryBase<SPFBAS, BpsContext>, ISpfbasDal
    {
    }
}
