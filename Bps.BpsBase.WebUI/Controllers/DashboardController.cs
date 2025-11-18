using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Controllers
{
    public class DashboardController : SecureController
    {
        private Global global;

        public DashboardController()
        {
            global = SessionHelper.ConvertSessiontoGlobal();
        }

        private readonly IGnkukrService _gnkukrService = InstanceFactory.GetInstance<IGnkukrService>();
        
        public ActionResult Index()
        {
            var cards= new List<KullaniciKartModel>();

            var kulKartResponse = _gnkukrService.Ncch_GetKulKartList_NLog(global, global.UserKod, false);
            if (kulKartResponse.Status == ResponseStatusEnum.OK && kulKartResponse.Items.Count > 0)
            {
                //var fileNames = Directory.GetFiles(Server.MapPath("~\\Views\\Dashboard\\Cards\\"), "*.cshtml")
                //    .Select(Path.GetFileName)
                //    .ToList();
                cards = kulKartResponse.Items.OrderBy(o => o.ACTIVE).ThenBy(o => o.KARTKD).ToList();
            }

            return View(cards);
        }

        public ActionResult AnaEkranaDon()
        {
            return Redirect("/");
        }
        
        public ActionResult DashboardGuncelle(List<KullaniciKartModel> model)
        {
            var sonuc = _gnkukrService.Ncch_DashboardGuncelle_Log(global, model);
            return Json(sonuc);
        }

        public ActionResult CardView()
        {
             var fileNames = Directory.GetFiles(Server.MapPath("~\\Views\\Dashboard\\Cards\\"), "*.cshtml")
                .Select(Path.GetFileName)
                .ToList();
            var cardNames = new List<CardModel>();
            foreach (var file in fileNames)
            {
                var model = new CardModel()
                {
                    CardName = file.Replace(".cshtml",""),
                    ACTIVE = false
                };
                cardNames.Add(model);
            }

            if (cardNames.Count > 0)
                cardNames = cardNames.OrderBy(o => o.ACTIVE).ThenBy(o => o.CardName).ToList();
            return View(cardNames);
        }

        public ActionResult CartPartial(string partialName)
        {
            return PartialView("Cards/" + partialName, partialName);
        }

    }
}