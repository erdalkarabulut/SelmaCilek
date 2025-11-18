using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Models.GN.Params;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Web.Model;

namespace Bps.BpsBase.Business.Abstract.GN
{
    public interface IGnService
    {
        StandardResponse Ncch_GetListYetki_NLog(Global global, string[] roles);
        StandardResponse DevexpressSaveGridLayout(string gridName, string layoutData, string name, Global global);
        StandardResponse<string> DevexpressProcessGridLayout(string gridName, string layoutData, string name, int type, Global global);
    }
}
