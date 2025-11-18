
namespace Bps.Core.Response
{
    public class StandardResponse<T> : BaseResponse
    {
        public T Nesne { get; set; }
    }

    public class StandardResponse : BaseResponse
    {

    }
}
