using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.SA;
using Bps.BpsBase.Entities.Concrete.SA;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.SA
{
    public class EfSadegaDal : EfEntityRepositoryBase<SADEGA, BpsContext>, ISadegaDal
    {
    }
}
