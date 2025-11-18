using System.Collections.Generic;

namespace Bps.Core.Response
{
    public class ListResponse<T> : BaseResponse
    {
        public List<T> Items { get; set; }

        public int TotalCount { get; set; }
    }
}
