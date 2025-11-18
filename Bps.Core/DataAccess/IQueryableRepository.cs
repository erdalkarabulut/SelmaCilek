using System.Linq;
using Bps.Core.Entities;

namespace Bps.Core.DataAccess
{
    public interface IQueryableRepository<T> where T:class ,IEntity,new()
    {
        IQueryable<T> Table { get; }
    }
}
