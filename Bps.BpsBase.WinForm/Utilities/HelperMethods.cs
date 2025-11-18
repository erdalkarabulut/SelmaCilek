using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.GlobalStaticsVariables;

namespace BPS.Windows.Forms.Utilities
{
    public static class HelperMethods
    {
        public static async Task RefreshYetki(Global global)
        {
            IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();

            var list = _gnyetkService.Ncch_GetProjelerYetkiList_NLog(global).Items;

            var yetkis = new List<GNYETK>();
            foreach (var menu in list)
            {
                var model = new GNYETK()
                {
                    SIRKID = global.SirketId.Value,
                    PROKOD = menu.PROKOD,
                    MNUNAM = menu.MNUNAM,
                    MNUTAG = menu.MNUTAG,
                    KULKOD = menu.KULKOD,
                    EKLEME = false,
                    DEGIST = false,
                    KAYDET = false,
                    SILMEK = false,
                    GRNTLM = false,
                    PDFGOS = false,
                    EXCGOS = false,
                    YAZDIR = false,
                    CSVGOS = false,
                    XMLGOS = false,
                    DOCGOS = false,
                    GNONAY = false,
                    ACTIVE = true,
                    SLINDI = false,
                    KOPYAL = false,
                    KYNKKD = global.KaynakKod,
                    EKKULL = "admin",
                    ETARIH = DateTime.Now,
                };

                yetkis.Add(model);
            }

            _gnyetkService.Ncch_AddMulti_NLog(yetkis, global, false);
        }
    }
}
