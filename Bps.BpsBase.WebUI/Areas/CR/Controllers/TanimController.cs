using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SA;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.CR.Single;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Areas.CR.Controllers
{
    public class TanimController : SecureController
    {
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        private readonly ICrcariService _crcariService = InstanceFactory.GetInstance<ICrcariService>();
        private readonly ICradrsService _cradrsService = InstanceFactory.GetInstance<ICradrsService>();

        #region Cari Kart

        public ActionResult CariMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;

            var global = SessionHelper.ConvertSessiontoGlobal();
            ViewData["CRHRKDList"] = _gnthrkService.Cch_GetListByTeknad(global, "CRHRKD", false).Items;
            return View(menuTag);
        }

        public ActionResult CariGridPartial(int? menuTag, string cariTipKod)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _crcariService.Cch_GetListByTip_NLog(global, cariTipKod);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            ViewData["CariTipKod"] = cariTipKod??"";
            
            var teknads = new List<string>() { "CRHRKD", "CRBGKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, yetkiKontrol: false);

            ViewData["CRHRKDList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "CRHRKD").ToList();
            ViewData["CRBGKDList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "CRBGKD").ToList();

            return PartialView("CariGridPartial", sonuc.Items);
        }

        public ActionResult CariKartEkleWindow(int? id, int? menuTag, string value)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = new GenelCariKartModel();
            model.CariKart = new CRCARI()
            {
                CRHRKD = value,
                ACTIVE = true
            };
            model.Adresler = new List<CRADRS>();

            if (id != null && id > 0)
            {
                var result = _crcariService.Ncch_GetById_NLog(id.Value, global);
                model.CariKart = result.Nesne;
            }
            
            ViewData["MenuTag"] = menuTag;

            return PartialView("CariKartEkleWindow", model);
        }

        public ActionResult CariKartKaydet(GenelCariKartModel model, int? menuTag)
        {
            StandardResponse<CRCARI> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.CariKart.Id > 0)
            {
                var response = _crcariService.Cch_GetById_NLog(model.CariKart.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _crcariService.Ncch_Update_Log(model.CariKart, response.Nesne, global);
            }
            else
                sonuc = _crcariService.Ncch_Add_NLog(model.CariKart, global);
            return Json(sonuc);
        }

        public ActionResult CariSecimLookupPartial(string cariKod, string cmbName, bool enable = true)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            ViewData["Name"] = cmbName;
            ViewData["Enable"] = enable;
            ViewData["CariKod"] = cariKod ?? "";
            var sonuc = _crcariService.Cch_GetList_NLog(global, false);
            return PartialView("Templates/CariSecimLookupPartial", sonuc.Items);
        }

        #endregion Cari Kart

        #region Cari Adres

        public ActionResult CariAdresMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("Adres/CariAdresMainPanel", menuTag);
        }

        public ActionResult CariAdresGridPartial(int? menuTag, string cariKartKod)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _cradrsService.Cch_GetListByCariKod_NLog(global, cariKartKod);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            ViewData["CariKartKod"] = cariKartKod ?? "";
            return PartialView("Adres/CariAdresGridPartial", sonuc.Items);
        }

        public ActionResult CariAdresEkleWindow(int? id, int? menuTag, string value)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = new CRADRS()
            {
                CRKODU = value,
                ACTIVE = true
            };
            if (id != null && id > 0)
            {
                var result = _cradrsService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }

            ViewData["MenuTag"] = menuTag;
            return PartialView("Adres/CariAdresEkleWindow", model);
        }

        public ActionResult CariAdresKaydet(CRADRS model, int? menuTag)
        {
            StandardResponse<CRADRS> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _cradrsService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }
                global.IsCompare = true;
                sonuc = _cradrsService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _cradrsService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult AdresSecimCmbPartial(int? adresNo, string cariKartKod, string cmbName)
        {
            var sonuc = new ListResponse<CRADRS>();
            var global = SessionHelper.ConvertSessiontoGlobal();
            sonuc.Items = _cradrsService
                .Cch_GetListByCariKod_NLog(SessionHelper.ConvertSessiontoGlobal(), cariKartKod, yetkiKontrol: false).Items;
            ViewData["ComboboxName"] = cmbName ?? "";
            ViewData["AdresNo"] = adresNo ?? 0;
            ViewData["CariKartKod"] = cariKartKod ?? "";
            return PartialView("Templates/AdresSecimCmbPartial", sonuc.Items);
        }

        #endregion Cari Adres
    }
}