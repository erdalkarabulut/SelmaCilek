using Bps.Core.DataAccess.EntityFramework;
using Bps.BpsBase.DataAccess.Concrete.Context;
using Bps.BpsBase.DataAccess.Abstract.WM;
using Bps.BpsBase.Entities.Concrete.WM;

namespace Bps.BpsBase.DataAccess.Concrete.EntityFramework.WM
{
    public class EfWmadrtDal : EfEntityRepositoryBase<WMADRT, BpsContext>, IWmadrtDal
    {
    }
}
