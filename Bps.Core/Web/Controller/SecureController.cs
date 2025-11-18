using Bps.Core.Web.Authorization;

namespace Bps.Core.Web.Controller
{
    [AuthorizeSession]
    public class SecureController : UnsecureController
    {
    }
}