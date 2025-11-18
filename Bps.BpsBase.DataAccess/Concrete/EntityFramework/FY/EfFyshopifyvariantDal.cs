using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.FY;
using Bps.BpsBase.Entities.Concrete.FY;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.FY
{
    public class EfFyshopifyvariantDal : EfEntityRepositoryBase<FYShopifyVariant, BpsContext>, IFyshopifyvariantDal
    {
    }
}
