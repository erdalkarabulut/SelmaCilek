using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SA;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.SA;
using Bps.Core.Response;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Areas.SA.Controllers
{
    public class TanimController : Controller
    {
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private readonly ISadegaService _sadegaService = InstanceFactory.GetInstance<ISadegaService>();
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();

        #region SA Değer Anahtarı

        public ActionResult SaDegAnMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("DegAn/SaDegAnMainPanel", menuTag);
        }

        public ActionResult SaDegAnGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _sadegaService.Cch_GetList_NLog(global, true);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("DegAn/SaDegAnGridPartial", sonuc.Items);
        }

        public ActionResult SaDegAnEkleWindow(int? id, int? menuTag)
        {
            var model = new SADEGA();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _sadegaService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }
            var responseProje = _gnthrkService.Cch_GetListByTeknad(global, "PROJKD", yetkiKontrol: false);
            var reponseDilKod = _gnthrkService.Cch_GetListByTeknad(global, "LANGKD", yetkiKontrol: false);
            var responseRolKod = _gnthrkService.Cch_GetListByTeknad(global, "ROLEKD", yetkiKontrol: false);
            var responseSCQ = _gnthrkService.Cch_GetListByTeknad(global, "SCQUKD", yetkiKontrol: false);
            ViewData["ProjeList"] = responseProje.Items;
            ViewData["DilList"] = reponseDilKod.Items;
            ViewData["RolList"] = responseRolKod.Items;
            ViewData["SCQList"] = responseSCQ.Items;

            return PartialView("DegAn/SaDegAnEkleWindow", model);
        }

        public ActionResult SaDegAnKaydet(SADEGA model, int? menuTag, string imagePath, string imageName)
        {
            StandardResponse<SADEGA> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _sadegaService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _sadegaService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _sadegaService.Ncch_Add_NLog(model, global);

            return Json(sonuc);
        }

        public ActionResult SaDegAnSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _sadegaService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _sadegaService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }
        #endregion
    }
}