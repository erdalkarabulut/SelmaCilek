using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.IK;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Areas.IK.Controllers
{
    public class PersonelController : SecureController
    {
        private const string ProjeKod = "IK";
        private const string ProjeTanim = "İnsan Kaynakları";
        private Global global = new Global();

        public PersonelController()
        {
            System.Web.HttpContext.Current.Session["ProjeKod"] = ProjeKod;
            System.Web.HttpContext.Current.Session["ProjeTanim"] = ProjeTanim;
            global = SessionHelper.ConvertSessiontoGlobal();
        }

        private readonly IIkpersService _ikpersService = InstanceFactory.GetInstance<IIkpersService>();
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();

        public ActionResult PersonelMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View(menuTag);
        }

        public ActionResult PersonelGridPartial(int? menuTag)
        {
            global.MenuTag = menuTag;
            var sonuc = _ikpersService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;

            //var tipList = _gnthrkService.Cch_GetList_NLog(global, false).Items;

            var teknads = new List<string>()
            {
                "DEPAKD", "POZSKD", "LOKAKD", "CNEDKD","CLDRKD","MSRFKD","UYRKKD","CINSKD","MHALKD","MAHAKD","ILCEKD","SEHRKD","ULKEKD"
            };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            ViewData["DepartmanList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "DEPAKD").ToList();
            ViewData["PozisyonList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "POZSKD").ToList();
            ViewData["LokasyonList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "LOKAKD").ToList();
            ViewData["CikisNedenList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "CNEDKD").ToList();
            ViewData["CalismaDurumList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "CLDRKD").ToList();
            ViewData["MasrafYeriList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "MSRFKD").ToList();
            ViewData["UyrukList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "UYRKKD").ToList();
            ViewData["CinsiyetList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "CINSKD").ToList();
            ViewData["MedeniHalList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "MHALKD").ToList();
            ViewData["MahalleList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "MAHAKD").ToList();
            ViewData["IlceList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "ILCEKD").ToList();
            ViewData["SehirList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "SEHRKD").ToList();
            ViewData["UlkeList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "ULKEKD").ToList();

            return PartialView("PersonelGridPartial", sonuc.Items);
        }

        public ActionResult PersonelEkleWindow(int? id, int? menuTag)
        {
            global.MenuTag = menuTag;
            var model = new IKPERS();
            if (id != null && id > 0)
            {
                var result = _ikpersService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }

            ViewData["MenuTag"] = menuTag ?? 0;
            return PartialView("PersonelEkleWindow", model);
        }

        public ActionResult PersonelKaydet(IKPERS model, int? menuTag, string imagePath)
        {
            StandardResponse<IKPERS> sonuc;
            global.MenuTag = menuTag;
            if (model.Id > 0)
            {
                var response = _ikpersService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _ikpersService.Ncch_UpdateWithImage_Log(model, response.Nesne, global, imagePath);
            }
            else
                sonuc = _ikpersService.Ncch_AddWithImage_NLog(model, global, imagePath);
            return Json(sonuc);
        }

        public ActionResult PersonelSil(int id, int? menuTag)
        {
            global.MenuTag = menuTag;
            var model = _ikpersService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _ikpersService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        public ActionResult PersonelListPartial(int? menuTag, int? persId)
        {
            global.MenuTag = menuTag;

            var sonuc = _ikpersService.Ncch_GetList_NLog(global, false);
            if (persId > 0)
            {
                sonuc = _ikpersService.Ncch_GetList_NLog(global, false);
                var x = sonuc.Items.Where(z => z.Id == persId).ToList();
                sonuc.Items = x;
            }
            return PartialView("Templates/PersonelListPartial", sonuc.Items);
        }

        public ActionResult PersonelSecimGlPartial(string datas, string cmbName, bool enable = true, bool isMulti = true, bool isRequired = false)
        {
            var sonuc = _ikpersService.Cch_GetList_NLog(global, false);
            ViewData["Name"] = cmbName;
            ViewData["Enable"] = enable;
            ViewData["IsRequired"] = isRequired;
            ViewData["IsMulti"] = isMulti;
            ViewData["Datas"] = datas ?? "";
            return PartialView("Templates/PersonelSecimGlPartial", sonuc.Items);
        }
    }
}