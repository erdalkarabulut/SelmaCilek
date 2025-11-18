using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.GN
{
    public class EfGnkxmlDal : EfEntityRepositoryBase<GNKXML, BpsContext>, IGnkxmlDal
    {
    }
}
