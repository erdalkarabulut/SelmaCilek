using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.Abstract.SA;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SA;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.BpsBase.Entities.Models.ST.Single;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Areas.ST.Controllers
{
    public class TanimController : SecureController
    {
        private readonly ISttdtrService _sttdtrService = InstanceFactory.GetInstance<ISttdtrService>();
        private readonly IStmaltService _stmaltService = InstanceFactory.GetInstance<IStmaltService>();
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        private readonly IStkartService _stkartService = InstanceFactory.GetInstance<IStkartService>();
        private readonly IStnameService _stnameService = InstanceFactory.GetInstance<IStnameService>();
        private readonly IStdepoService _stdepoService = InstanceFactory.GetInstance<IStdepoService>();
        private readonly IStmhsbService _stmhsbService = InstanceFactory.GetInstance<IStmhsbService>();
        private readonly IStsaleService _stsaleService = InstanceFactory.GetInstance<IStsaleService>();
        private readonly ISadegaService _sadegaService = InstanceFactory.GetInstance<ISadegaService>();
        private readonly IGndptnService _gndptnService = InstanceFactory.GetInstance<IGndptnService>();
        private readonly IStftipService _stftipService = InstanceFactory.GetInstance<IStftipService>();

        #region Stok Tedarik Türü

        public ActionResult StokTedTurMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("TedTur/StokTedTurMainPanel", menuTag);
        }

        public ActionResult StokTedTurGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _sttdtrService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            
            return PartialView("TedTur/StokTedTurGridPartial", sonuc.Items);
        }

        public ActionResult StokTedTurEkleWindow(int? id, int? menuTag)
        {
            var model = new STTDTR();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _sttdtrService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }
            var uretimYeriList = _gnthrkService.Cch_GetListByTeknad(global, "URYRKD", yetkiKontrol: false);
            ViewData["ÜretimYeriList"] = uretimYeriList.Items;
            ViewData["MenuTag"] = menuTag??0;
            return PartialView("TedTur/StokTedTurEkleWindow", model);
        }

        public ActionResult StokTedTurKaydet(STTDTR model, int? menuTag)
        {
            StandardResponse<STTDTR> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _sttdtrService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _sttdtrService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _sttdtrService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult StokTedTurSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _sttdtrService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _sttdtrService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        public ActionResult TedTurSecimCp(string tedKod, string cmbName)
        {
            var sonuc = new ListResponse<STTDTR>();
            var global = SessionHelper.ConvertSessiontoGlobal();
            sonuc = _sttdtrService.Cch_GetList_NLog(global, false);
            ViewData["ComboboxName"] = cmbName;
            ViewData["TedKod"] = tedKod??"";
            return PartialView("Templates/TedTurSecimCp", sonuc.Items);
        }


        #endregion

        #region Malzeme Türü

        public ActionResult StokMalTuruMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("MalTur/StokMalTuruMainPanel", menuTag);
        }

        public ActionResult StokMalTuruGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _stmaltService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            //var sekmeler = _gnthrkService.Cch_GetListByTeknad(global, "STSKKD", false).Items;
            ViewData["YetkiModel"] = yetki;
            //ViewData["Sekmeler"] = sekmeler;
            return PartialView("MalTur/StokMalTuruGridPartial", sonuc.Items);
        }

        public ActionResult StokMalTuruEkleWindow(int? id, int? menuTag)
        {
            var model = new STMALT();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _stmaltService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }

            var stokCinsListesi = _gnthrkService.Cch_GetListByTeknad(global, "STCNKD", yetkiKontrol: false);
            ViewData["StokCinsListesi"] = stokCinsListesi.Items;
            ViewData["MenuTag"] = menuTag??0;
            return PartialView("MalTur/StokMalTuruEkleWindow", model);
        }

        public ActionResult StokMalTuruKaydet(STMALT model, int? menuTag)
        {
            StandardResponse<STMALT> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _stmaltService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _stmaltService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _stmaltService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult StokMalTuruSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _stmaltService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _stmaltService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }


        public ActionResult MultiMalTurSecimCp(string sekmeler, string cmbName)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            ViewData["Name"] = cmbName;
            ViewData["Sekmeler"] = sekmeler ?? "";
            var sonuc = _gnthrkService.Cch_GetListByTeknad(global, "STSKKD", false);
            return PartialView("MultiMalTurSecimCp", sonuc.Items);
        }
        #endregion

        #region Stok Kartı

        public ActionResult StokKartMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            var global = SessionHelper.ConvertSessiontoGlobal();
            var responseMalzemeTur = _stmaltService.Cch_GetList_NLog(global, false);
            ViewData["MalzemeTurListesi"] = responseMalzemeTur.Items;
            return View("StokKart/StokKartMainPanel", menuTag);
        }

        public ActionResult StokKartGridPartial(int? menuTag, string malzemeTur)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _stkartService.Cch_GetListByMalTur_NLog(global, malzemeTur);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            ViewData["Malzeme"] = malzemeTur;
            
            var teknads = new List<string>() { "STANKD", "STALKD", "OLCUKD", "MALGKD", "EANTKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            var stokName = _stnameService.Cch_GetList_NLog(global, false).Items.Where(w=>w.LANGKD == global.DilKod).ToList();

            ViewData["StokAnaGrupList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "STANKD").ToList();
            ViewData["StokAltGrupList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "STALKD").ToList();
            ViewData["OlcuList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();
            ViewData["MalGrupList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "MALGKD").ToList();
            ViewData["EanTipList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "EANTKD").ToList();
            ViewData["StokNameList"] = stokName;
            return PartialView("StokKart/StokKartGridPartial", sonuc.Items);
        }

        public ActionResult StokKartEkleWindow(int? id, int? menuTag, string sekmeKod, string malTur)
        {
            //var global = SessionHelper.ConvertSessiontoGlobal();
            //global.MenuTag = menuTag;
            //var model = new GenelStokKartModel();
            //model.StokKart = new STKART()
            //{
            //    STMLTR=malTur,
            //    ACTIVE = true
            //};
            //model.DilTanimlari= new List<STNAME>();
            //model.DepoTanimlari= new List<STDEPO>();
            //model.MuhasebeTanimlari= new List<STMHSB>();
            //model.SatisTanim = new List<STSALE>();
            //model.SatinAlmaDegerAnahtar= new SADEGA();
            //var responseSaDeger = _sadegaService.Cch_GetList_NLog(global, false);
            //ViewData["SatinAlmaDegerList"] = responseSaDeger.Items;

            //if (id != null && id > 0)
            //{
            //    var result = _stkartService.Ncch_GetById_NLog(id.Value, global);
            //    model.StokKart = result.Nesne;
            //    model.SatinAlmaDegerAnahtar =
            //        responseSaDeger.Items.FirstOrDefault(f => f.SADEGK == result.Nesne.SADEGK);
            //}

            //var malTurList = _stmaltService.Cch_GetByMalTur_NLog(malTur, global, false);
            //var teknadsResponse = _gnthrkService.Cch_GetListByTeknad(global, "STSKKD", false);
            //var newSekmeList= new List<GNTHRK>();
            //var malTurSplited = malTurList.Nesne.STBKDR.Split(',');
            //foreach (var sekme in malTurSplited)
            //{
            //    var skm = teknadsResponse.Items.FirstOrDefault(f => f.HARKOD == sekme);
            //    if (skm != null)
            //    {
            //        newSekmeList.Add(skm);
            //    }
            //}
            //ViewData["SekmeKodList"] = newSekmeList;

            //var responseStNames = _stnameService.Cch_GetList_NLog(global, false);
            //ViewData["StokNameList"] = responseStNames.Items;
            //ViewData["MenuTag"] = menuTag;

            return PartialView("StokKart/StokKartEkleWindow");
        }

        public ActionResult StokKartKaydet(GenelStokKartModel model, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            //var sonuc = _stokService.Ncch_StokKartKaydet_Log(global, model);
            return Json("sonuc");
        }

        public ActionResult StokKartSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _stkartService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _stkartService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        public ActionResult StokDilTanimGp(int? menuTag, string stokKodu, string stName)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _stnameService.Cch_GetListByStokKodu_NLog(global, stokKodu, false);
            
            //if (sonuc.Items.Count <1 || sonuc.Items.FirstOrDefault(f=>f.LANGKD == global.DilKod) == null)
            //{
            //    sonuc.Items.Add(new STNAME()
            //    {
            //        LANGKD = global.DilKod,
            //        STKODU = stokKodu,
            //        STKNAM = ""
            //    });
            //}

            var dilResponse = _gnthrkService.Cch_GetListByTeknad(global, "LANGKD", yetkiKontrol: false);
            ViewData["DilList"] = dilResponse.Items;
            return PartialView("StokKart/StokDilTanimGp", sonuc.Items);
        }

        public ActionResult StokDepoGp(int? menuTag, string stokKodu)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _stdepoService.Cch_GetByStokKodu_NLog(global, stokKodu, false);

            var tedTurList = _sttdtrService.Cch_GetList_NLog(global, false).Items;
            var uretimYeriList = _gnthrkService.Cch_GetListByTeknad(global, "URYRKD", false).Items;
            var depoList = _gndptnService.Cch_GetList_NLog(global, false).Items;
            ViewData["DepoList"] = depoList;
            ViewData["UretimYeriList"] = uretimYeriList;
            ViewData["TedTurList"] = tedTurList;

            return PartialView("StokKart/StokDepoGp", sonuc.Items);
        }

        public ActionResult StokMuhasebeGp(int? menuTag, string stokKodu)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _stmhsbService.Cch_GetByStokKodu_NLog(global, stokKodu, false);

            var depoList = _gndptnService.Cch_GetList_NLog(global, false).Items;
            ViewData["DepoList"] = depoList;
            ViewData["StokKodu"] = stokKodu ?? "";
            ViewData["MenuTag"] = menuTag ?? 0;

            return PartialView("StokKart/StokMuhasebeGp", sonuc.Items);
        }


        public ActionResult StokSatisGp(int? menuTag, string stokKodu)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _stsaleService.Cch_GetListByStokKodu_NLog(global, stokKodu, false);

            var depoList = _gndptnService.Cch_GetList_NLog(global, false).Items;
            ViewData["DepoList"] = depoList;
            ViewData["StokKodu"] = stokKodu ?? "";
            ViewData["MenuTag"] = menuTag ?? 0;


            var teknads = new List<string>() { "SLORKD", "SLKNKD", "OLCUKD"};
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);

            ViewData["SatisOrgList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "SLORKD").ToList();
            ViewData["DagitimKanalList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "SLKNKD").ToList();
            ViewData["OlcuList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "OLCUKD").ToList();

            return PartialView("StokKart/StokSatisGp", sonuc.Items);
        }

        public ActionResult StokSecimLookupPartial(string stokKodu, string cmbName, bool? enable, bool? isRequired)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            ViewData["Name"] = cmbName;
            ViewData["StokKodu"] = stokKodu ?? "";
            ViewData["Enable"] = enable ?? true;
            ViewData["IsRequired"] = isRequired ?? false;
            var sonuc = _stkartService.Cch_GetList_NLog(global, false);
            return PartialView("Templates/StokSecimLookupPartial", sonuc.Items);
        }

        #endregion

        #region Stok Fiş Tipi

        public ActionResult StokFisTipiMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("FisTip/StokFisTipiMainPanel", menuTag);
        }

        public ActionResult StokFisTipiGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _stftipService.Cch_GetList_NLog(global, true);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("FisTip/StokFisTipiGridPartial", sonuc.Items);
        }

        public ActionResult StokFisTipiEkleWindow(int? id, int? menuTag)
        {
            var model = new STFTIP();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _stftipService.Ncch_GetById_NLog(id.Value, global);
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

            return PartialView("FisTip/StokFisTipiEkleWindow", model);
        }

        public ActionResult StokFisTipiKaydet(STFTIP model, int? menuTag, string imagePath, string imageName)
        {
            StandardResponse<STFTIP> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _stftipService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _stftipService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _stftipService.Ncch_Add_NLog(model, global);

            return Json(sonuc);
        }

        public ActionResult StokFisTipiSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _stftipService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _stftipService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion
    }
}