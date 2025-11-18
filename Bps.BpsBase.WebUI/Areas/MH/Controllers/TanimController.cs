using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.MH;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.MH;
using Bps.Core.Response;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Areas.MH.Controllers
{
    public class TanimController : Controller
    {
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private readonly IMhhsplService _mhhsplService = InstanceFactory.GetInstance<IMhhsplService>();
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();

        #region MuhHspPln
        public ActionResult MuhHspPlnMainPanel(int? menuTag)
        {
            return View("HesapPlan/MuhHspPlnMainPanel", menuTag);
        }

        public ActionResult MuhHspPlnGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _mhhsplService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            var teknads = new List<string>() { "HSPTKD", "DVCNKD", "DGSKKD", "KDVDKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            ViewData["HSPTKDList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "HSPTKD").ToList();
            ViewData["DVCNKDList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "DVCNKD").ToList();
            ViewData["DGSKKDList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "DGSKKD").ToList();
            ViewData["KDVDKDList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "KDVDKD").ToList();
            return PartialView("HesapPlan/MuhHspPlnGridPartial", sonuc.Items);
        }

        public ActionResult MuhHspPlnEkleWindow(int? id, int? menuTag)
        {
            var model = new MHHSPL();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _mhhsplService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }
            //var dbResponse = _mhhsplService.GetDbTables();
            //ViewData["DbTables"] = dbResponse.Items;
            return PartialView("HesapPlan/MuhHspPlnEkleWindow", model);
        }
        public ActionResult MuhHspPlnKaydet(MHHSPL model, int? menuTag)
        {
            StandardResponse<MHHSPL> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _mhhsplService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _mhhsplService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _mhhsplService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult MuhHspPlnSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _mhhsplService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _mhhsplService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        public ActionResult MultiMuhasebeSecimCmbPartial(string muhaKod, string cmbName, bool enable = true)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            ViewData["Name"] = cmbName;
            ViewData["Enable"] = enable;
            ViewData["MuhaKod"] = muhaKod ?? "";
            var sonuc = _mhhsplService.Cch_GetList_NLog(global, false);
            return PartialView("Templates/MultiMuhasebeSecimCmbPartial", sonuc.Items);
        }

        #endregion MuhHspPln

    }
}