using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Areas.ST.Controllers
{
    public class IslemController : SecureController
    {
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private readonly IStftipService _stftipService = InstanceFactory.GetInstance<IStftipService>();
        private readonly ISthrktService _sthrktService = InstanceFactory.GetInstance<ISthrktService>();
        private readonly IStkartService _stkartService = InstanceFactory.GetInstance<IStkartService>();
        private readonly IGndptnService _gndptnService = InstanceFactory.GetInstance<IGndptnService>();

        public ActionResult StokHareketMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            var global = SessionHelper.ConvertSessiontoGlobal();
            ViewData["FisTipList"] = _stftipService.Cch_GetList_NLog(global, false).Items;
            return View("StokHareketMainPanel", menuTag);
        }

        public ActionResult StokHareketGridPartial(int? menuTag, int? fisTipNo)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _sthrktService.Cch_GetListBaslikByFisTip_NLog(global, fisTipNo, false);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            ViewData["FisTipNo"] = fisTipNo;

            //var teknads = new List<string>() { "STANKD", "STALKD", "OLCUKD", "MALGKD", "EANTKD" };
            //var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            
            //ViewData["StokAnaGrupList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").ToList();
            //ViewData["StokAltGrupList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();
            //ViewData["OlcuList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();
            //ViewData["MalGrupList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
            //ViewData["EanTipList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "EANTKD").ToList();
            return PartialView("StokHareketGridPartial", sonuc.Items);
        }

        public ActionResult StokHareketEkleWindow(int? menuTag, int? fisTipNo)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            ViewData["MenuTag"] = menuTag??0;
            var model = new StokHareketModel()
            {
                Baslik = new STHBAS()
                {
                    STFTNO = fisTipNo.Value,
                    ACTIVE = true
                },
                Kalemler = new List<STHRKT>()
            };

            ViewData["DepoTanimList"] = _gndptnService.Cch_GetList_NLog(global, false).Items;

            return PartialView("StokHareketEkleWindow", model);
        }

        public ActionResult ShSayimGp(int? menuTag, int? fisTipNo)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _sthrktService.Ncch_GetListKalemByFisTip_NLog(global, fisTipNo, false);
            //var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global).Nesne;
            //ViewData["YetkiModel"] = yetki;
            ViewData["FisTipNo"] = fisTipNo;

            var teknads = new List<string>() { "ISMSKD", "OLCUKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            var stKarts = _stkartService.Cch_GetList_NLog(global, false);

            ViewData["ISMSKDList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "ISMSKD").ToList();
            ViewData["STKARTList"] = stKarts.Items;
            //ViewData["StokAltGrupList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();
            ViewData["OlcuList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();
            //ViewData["MalGrupList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
            //ViewData["EanTipList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "EANTKD").ToList();

            ViewData["DepoTanimList"] = _gndptnService.Cch_GetList_NLog(global, false).Items;
            return PartialView("ShSayimGp", sonuc.Items);
        }
        
    }
}