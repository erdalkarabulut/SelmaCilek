using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.KS;
using Bps.BpsBase.Entities.Concrete.KS;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.KS
{
    public class EfKskasaDal : EfEntityRepositoryBase<KSKASA, BpsContext>, IKskasaDal
    {
    }
}
