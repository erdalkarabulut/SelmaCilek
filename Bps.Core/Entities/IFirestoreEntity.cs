using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bps.Core.Entities
{
    public interface IFirestoreEntity
    {
        IFirestoreEntity Deserialize(Dictionary<string, object> map);
        Dictionary<string, object> Serialize();
        string DocumentId { get; set; }
    }
}
