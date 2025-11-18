using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Areas.GN.Controllers
{
    public class IslemController : SecureController
    {
        private readonly IDovkurService _dovkurService = InstanceFactory.GetInstance<IDovkurService>();
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();

        #region Döviz Kuru

        public ActionResult DovizKurMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("DovizKur/DovizKurMainPanel", menuTag);
        }

        public ActionResult DovizKurGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _dovkurService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            
            ViewData["DVCNKDList"] = _gnthrkService.Cch_GetListByTeknad(global, "DVCNKD", yetkiKontrol: false).Items;
            return PartialView("DovizKur/DovizKurGridPartial", sonuc.Items);
        }

        public ActionResult DovizKurEkleWindow(int? id, int? menuTag)
        {
            var model = new DOVKUR();
            model.ACTIVE = true;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _dovkurService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }

            ViewData["MenuTag"] = menuTag ?? 0;
            return PartialView("DovizKur/DovizKurEkleWindow", model);
        }

        public ActionResult DovizKurKaydet(DOVKUR model, int? menuTag)
        {
            StandardResponse<DOVKUR> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.MANUEL != null && model.MANUEL == true)
            {
                model = _dovkurService.GetDovizKuru(model);
            }

            if (model.Id > 0)
            {
                var response = _dovkurService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _dovkurService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _dovkurService.Ncch_Add_NLog(model, global);

            return Json(sonuc);
        }

        public ActionResult DovizKurSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _dovkurService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _dovkurService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion Döviz Kuru
    }
}