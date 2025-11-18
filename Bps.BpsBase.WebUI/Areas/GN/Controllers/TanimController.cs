using System.Collections.Generic;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.Entities.Concrete.SA;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Session;

namespace Bps.BpsBase.WebUI.Areas.GN.Controllers
{
    public class TanimController : SecureController
    {
        private readonly IGnmenuService _gnmenuService = InstanceFactory.GetInstance<IGnmenuService>();
        private readonly IGnevrkService _gnevrkService = InstanceFactory.GetInstance<IGnevrkService>();
        private readonly IGnmesjService _gnmesjService = InstanceFactory.GetInstance<IGnmesjService>();
        private readonly IGntipiService _gntipiService = InstanceFactory.GetInstance<IGntipiService>();
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        private readonly IGnkullService _gnkullService = InstanceFactory.GetInstance<IGnkullService>();
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private readonly IGnfileService _gnfileService = InstanceFactory.GetInstance<IGnfileService>();
        private readonly IGndptnService _gndptnService = InstanceFactory.GetInstance<IGndptnService>();
        private readonly IDovkurService _dovkurService = InstanceFactory.GetInstance<IDovkurService>();

        public List<GNTIPI> GetTipList()
        {
            //var list = new List<GNTIPI>();
            //list.Add(new GNTIPI()
            //{
            //    Id = 0,
            //    TIPKOD = "000",
            //    TIPADI = "ROOT",
            //    UTPKOD = "000"
            //});
            var sonuc = _gntipiService.Cch_GetList_NLog(SessionHelper.ConvertSessiontoGlobal(), yetkiKontrol: false);
            //list.AddRange(sonuc.Items);
            return sonuc.Items;
        }

        //public List<ListItem> GetTipListWd()
        //{
        //    var items = _gntipiService
        //        .Cch_GetList_NLog(SessionHelper.ConvertSessiontoGlobal(), yetkiKontrol: false).Items;
        //    var projeler = new List<ListItem>();
        //    projeler.Add(new ListItem("ROOT", "000"));
        //    projeler.AddRange(
        //        items.ToArray().Select(x => new ListItem(x.TIPADI, x.TIPKOD)).ToList());
        //    return projeler;
        //}

        public ActionResult GetTipHareketList(string ustTipKod)
        {
            var sonuc = new ListResponse<TipHareketListModel>();
            if (ustTipKod == "000")
            {
                sonuc.Items = new List<TipHareketListModel>();
                sonuc.Items.Add(new TipHareketListModel()
                {
                    Id = 0,
                    TIPKOD = "000",
                    TANIMI = "ROOT"
                });
            }
            else
            {
                sonuc = _gnthrkService.Cch_TipHareketListGetir(SessionHelper.ConvertSessiontoGlobal(), ustTipKod, yetkiKontrol: false);
            }

            return Json(sonuc);
        }

        #region Menü

        public ActionResult MenuMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("Menu/MenuMainPanel", menuTag);
        }

        public ActionResult MenuGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _gnmenuService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("Menu/MenuGridPartial", sonuc.Items);
        }

        public ActionResult MenuEkleWindow(int? id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            var model = new GNMENU()
            {
                PROKOD = global.ProjeKod
            };
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _gnmenuService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }
            var sonuc = _gnthrkService.Cch_GetListByTeknad(global, "PROJKD", yetkiKontrol: false);
            ViewData["ProjeList"] = sonuc.Items;
            return PartialView("Menu/MenuEkleWindow", model);
        }
        public ActionResult ParentMenuByProjeCmbPartial(string projeKod, int? parent)
        {
            var sonuc = new StandardResponse<CmbComboModel> { Nesne = new CmbComboModel() };
            if (string.IsNullOrEmpty(projeKod))
            {
                sonuc.Nesne.MenuList = new List<GNMENU>();
            }
            else
            {
                sonuc.Nesne.MenuList = _gnmenuService.Ncch_GetListParentByProkod_NLog(SessionHelper.ConvertSessiontoGlobal(), projeKod, yetkiKontrol: false).Items;
            }
            sonuc.Nesne.PARENT = parent ?? 0;
            return PartialView("Templates/ParentMenuByProjeCmbPartial", sonuc.Nesne);
        }

        public ActionResult MenuKaydet(GNMENU model, int? menuTag)
        {
            StandardResponse<GNMENU> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _gnmenuService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _gnmenuService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _gnmenuService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult MenuSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _gnmenuService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _gnmenuService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        #region Evrak

        public ActionResult EvrakMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("Evrak/EvrakMainPanel",menuTag);
        }

        public ActionResult EvrakGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _gnevrkService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("Evrak/EvrakGridPartial", sonuc.Items);
        }

        public ActionResult EvrakEkleWindow(int? id, int? menuTag)
        {
            var model = new GNEVRK();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _gnevrkService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }
            var dbResponse = _gnevrkService.GetDbTables();
            ViewData["DbTables"] = dbResponse.Items;
            return PartialView("Evrak/EvrakEkleWindow", model);
        }

        public ActionResult EvrakKaydet(GNEVRK model, int? menuTag)
        {
            StandardResponse<GNEVRK> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _gnevrkService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _gnevrkService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _gnevrkService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult EvrakSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _gnevrkService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _gnevrkService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        #region Mesaj

        public ActionResult MesajMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("Mesaj/MesajMainPanel", menuTag);
        }

        public ActionResult MesajGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _gnmesjService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("Mesaj/MesajGridPartial", sonuc.Items);
        }

        public ActionResult MesajEkleWindow(int? id, int? menuTag)
        {
            var model = new GNMESJ();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _gnmesjService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }
            var dilResponse = _gnthrkService.Cch_GetListByTeknad(global, "LANGKD", yetkiKontrol: false);
            ViewData["DilList"] = dilResponse.Items;
            return PartialView("Mesaj/MesajEkleWindow", model);
        }

        public ActionResult MesajKaydet(GNMESJ model, int? menuTag)
        {
            StandardResponse<GNMESJ> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _gnmesjService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _gnmesjService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _gnmesjService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult MesajSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _gnmesjService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _gnmesjService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        #region Tip

        public ActionResult TipMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("Tip/TipMainPanel", menuTag);
        }

        public ActionResult TipGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _gntipiService.TipListGetir(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("Tip/TipGridPartial", sonuc.Items);
        }

        public ActionResult TipEkleWindow(int? id, int? menuTag)
        {
            var model = new GNTIPI();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _gntipiService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }
            ViewData["TipListesi"] = GetTipList();
            return PartialView("Tip/TipEkleWindow", model);
        }

        public ActionResult TipKaydet(GNTIPI model, int? menuTag)
        {
            StandardResponse<GNTIPI> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _gntipiService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _gntipiService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _gntipiService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult TipSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _gntipiService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _gntipiService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        #region Tip Hareket

        public ActionResult TipHareketMainPanel(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            var tipList = _gntipiService.Cch_GetAll_NLog(global, yetkiKontrol: false);

            ViewData["TipList"] = tipList.Items;
            return View("TipHareket/TipHareketMainPanel", menuTag);
        }

        public ActionResult TipHareketGridPartial(int? menuTag, string tipKod)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _gnthrkService.Cch_TipHareketListGetir(global, tipKod, true);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            ViewData["ustTipKod"] = "";
            return PartialView("TipHareket/TipHareketGridPartial", sonuc.Items);
        }

        public ActionResult TipHrkParentCmbPartial(string ustTipKod, int? parent)
        {
            var sonuc = new StandardResponse<CmbComboModel> { Nesne = new CmbComboModel() };
            if (string.IsNullOrEmpty(ustTipKod))
            {
                sonuc.Nesne.TipHareketList = new List<TipHareketListModel>();
            }
            else
            {
                if (ustTipKod == "000")
                {
                    sonuc.Nesne.TipHareketList = new List<TipHareketListModel>();
                    sonuc.Nesne.TipHareketList.Add(new TipHareketListModel()
                    {
                        Id = 0,
                        TIPKOD = "000",
                        TANIMI = "ROOT",

                    });
                }
                else
                {
                    sonuc.Nesne.TipHareketList = _gnthrkService
                        .Cch_TipHareketListGetir(SessionHelper.ConvertSessiontoGlobal(), ustTipKod, yetkiKontrol: false)
                        .Items;
                }
            }

            sonuc.Nesne.PARENT = parent ?? 0;
            return PartialView("Templates/TipHrkParentCmbPartial", sonuc.Nesne);
        }

        public ActionResult TipHrkCmbPartial(string tipKod, string harKod, string cmbName, bool? isRequried)
        {
            var sonuc = new StandardResponse<CmbComboModel> { Nesne = new CmbComboModel() };
            sonuc.Nesne.TipHareketList = _gnthrkService
                .Cch_TipHareketListGetir(SessionHelper.ConvertSessiontoGlobal(), tipKod, yetkiKontrol: false).Items;
            sonuc.Nesne.HARKOD = harKod ?? "";
            sonuc.Nesne.ComboboxName = cmbName;
            sonuc.Nesne.IsRequired = isRequried;
            return PartialView("Templates/TipHrkCmbPartial", sonuc.Nesne);
        }

        public ActionResult UstTipCmbPartial(string tipKod, string harKod, string cmbName, string childName)
        {
            var sonuc = new StandardResponse<CmbComboModel> { Nesne = new CmbComboModel() };
            sonuc.Nesne.TipHareketList = _gnthrkService
                .Cch_TipHareketListGetir(SessionHelper.ConvertSessiontoGlobal(), tipKod, yetkiKontrol: false).Items;
            sonuc.Nesne.HARKOD = harKod ?? "";
            ViewData["ComboboxName"] = cmbName;
            ViewData["ChildName"] = childName;
            return PartialView("Templates/UstTipCmbPartial", sonuc.Nesne);
        }

        public ActionResult AltTipCmbPartial(string ustTipKod, string harKod, string cmbName, int? parentId, string childName, string ustHarKod)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            var sonuc = new StandardResponse<CmbComboModel> { Nesne = new CmbComboModel() };

            if (parentId == null && !string.IsNullOrEmpty(ustHarKod))
            {
                parentId = _gnthrkService
                    .Cch_GetAltTipByTipKodAndHarKod(global, ustTipKod, ustHarKod, yetkiKontrol: false).Nesne.Id;
            }
            sonuc.Nesne.TipHareketList = _gnthrkService
                .Cch_TipHareketListByUstTip(global, ustTipKod, parentId, yetkiKontrol: false).Items;
            sonuc.Nesne.HARKOD = harKod ?? "";
            ViewData["ComboboxName"] = cmbName;
            ViewData["ustTipKod"] = ustTipKod;
            ViewData["parentId"] = parentId;
            ViewData["childName"] = childName;
            return PartialView("Templates/AltTipCmbPartial", sonuc.Nesne);
        }
        public ActionResult UstTipMultiCmbPartial(string tipKod, string harKod, string cmbName, List<string> altTipkods, List<string> childNames)
        {
            var sonuc = new StandardResponse<CmbComboModel> { Nesne = new CmbComboModel() };
            sonuc.Nesne.TipHareketList = _gnthrkService
                .Cch_TipHareketListGetir(SessionHelper.ConvertSessiontoGlobal(), tipKod, yetkiKontrol: false).Items;
            sonuc.Nesne.HARKOD = harKod ?? "";
            ViewData["ComboboxName"] = cmbName;
            ViewData["ChildNames"] = childNames;
            ViewData["altTipkods"] = altTipkods;
            List<ChildNameTipKod> childNamesTipKods = new List<ChildNameTipKod>();

            for (int i = 0; i < childNames.Count; i++)
            {
                var xx = new ChildNameTipKod
                {
                    ChildName = childNames[i],
                    AltTipKod = altTipkods[i],
                };

                childNamesTipKods.Add(xx);
            }
            ViewData["ChildNamesTipKods"] = childNamesTipKods;

            return PartialView("Templates/UstTipMultiCmbPartial", sonuc.Nesne);
        }
        public ActionResult AltTipMultiCmbPartial(string ustTipKod, string harKod, string tipkod, string cmbName, int? parentId, string childName, string ustHarKod)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            var sonuc = new StandardResponse<CmbComboModel> { Nesne = new CmbComboModel() };

            if (parentId == null && !string.IsNullOrEmpty(ustHarKod))
            {
                parentId = _gnthrkService
                    .Cch_GetAltTipByTipKodAndHarKod(global, ustTipKod, ustHarKod, yetkiKontrol: false).Nesne.Id;
            }
            sonuc.Nesne.TipHareketList = _gnthrkService
                .Cch_TipHareketListByUstTipAltTip(global, ustTipKod, tipkod, parentId, yetkiKontrol: false).Items;
            sonuc.Nesne.HARKOD = harKod ?? "";
            ViewData["ComboboxName"] = cmbName;
            ViewData["ustTipKod"] = ustTipKod;
            ViewData["parentId"] = parentId;
            ViewData["childName"] = childName;
            return PartialView("Templates/AltTipMultiCmbPartial", sonuc.Nesne);
        }

        public ActionResult TipHrkEkleWindow(int? id, int? menuTag, string tipKod, string ustTipKod)
        {
            var model = new GNTHRK();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (!string.IsNullOrEmpty(tipKod)) model.TIPKOD = tipKod;
            if (id != null && id > 0)
            {
                var result = _gnthrkService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }
            ViewData["ustTipKod"] = ustTipKod;
            return PartialView("TipHareket/TipHrkEkleWindow", model);
        }

        public ActionResult TipHrkKaydet(GNTHRK model, int? menuTag)
        {
            StandardResponse<GNTHRK> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _gnthrkService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _gnthrkService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _gnthrkService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult TipHrkSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _gnthrkService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _gnthrkService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        #region Yetki

        public ActionResult YetkiMainPanel(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            var kullResponse = _gnkullService.Cch_GetAll_NLog(global, yetkiKontrol: false);
            var projeResponse = _gnthrkService.Cch_GetListByTeknad(global, "PROJKD", yetkiKontrol: false);
            ViewData["ProjeList"] = projeResponse.Items;
            ViewData["KullaniciList"] = kullResponse.Items;
            return View("Yetki/YetkiMainPanel", menuTag);
        }

        public ActionResult YetkiGridPartial(int? menuTag, string kulKod, string projeKod)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _gnyetkService.Ncch_GetListByFilter_NLog(global, kulKod, projeKod, true);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            ViewData["KulKod"] = kulKod;
            return PartialView("Yetki/YetkiGridPartial", sonuc.Items);
        }

        public ActionResult MenuByProjeCmbPartial(string projeKod, int? menuTag)
        {
            var sonuc = new StandardResponse<CmbComboModel> { Nesne = new CmbComboModel() };

            if (string.IsNullOrEmpty(projeKod))
            {
                sonuc.Nesne.MenuList = new List<GNMENU>();
            }
            else
            {
                sonuc.Nesne.MenuList = _gnmenuService.Ncch_MenuProListGetir_NLog(SessionHelper.ConvertSessiontoGlobal(), projeKod, yetkiKontrol: false).Items;
            }

            sonuc.Nesne.MNUTAG = menuTag ?? 0;
            return PartialView("Templates/MenubyProjeCmbPartial", sonuc.Nesne);
        }

        public ActionResult YetkiEkleWindow(int? id, int? menuTag, string kullaniciKod, string projeKod)
        {
            var model = new GNYETK()
            {
                ACTIVE = true,
                CSVGOS = true,
                DEGIST = true,
                DOCGOS = true,
                EXCGOS = true,
                KAYDET = true,
                GRNTLM = true,
                PDFGOS = true,
                EKLEME = true,
                SILMEK = true,
                YAZDIR = true,
                XMLGOS = true
            };
            if (!string.IsNullOrEmpty(kullaniciKod)) model.KULKOD = kullaniciKod;
            if (!string.IsNullOrEmpty(projeKod)) model.PROKOD = projeKod;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _gnyetkService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }

            var responseProje = _gnthrkService.Cch_GetListByTeknad(global, "PROJKD", yetkiKontrol: false);
            ViewData["ProjeList"] = responseProje.Items;
            ViewData["TipListesi"] = GetTipList();
            return PartialView("Yetki/YetkiEkleWindow", model);
        }

        public ActionResult YetkiKaydet(GNYETK model, int? menuTag)
        {
            StandardResponse<GNYETK> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _gnyetkService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _gnyetkService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _gnyetkService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult YetkiSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _gnyetkService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _gnyetkService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        #region Kullanici

        public ActionResult KullaniciMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("Kullanici/KullaniciMainPanel", menuTag);
        }

        public ActionResult KullaniciGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _gnkullService.Cch_GetList_NLog(global, true);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("Kullanici/KullaniciGridPartial", sonuc.Items);
        }

        public ActionResult KullaniciEkleWindow(int? id, int? menuTag)
        {
            var model = new GNKULL();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _gnkullService.Ncch_GetById_NLog(id.Value, global);
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

            ViewData["MenuTag"] = menuTag ?? 0;
            return PartialView("Kullanici/KullaniciEkleWindow", model);
        }

        public ActionResult KullaniciKaydet(GNKULL model, int? menuTag, string imagePath, string imageName)
        {
            StandardResponse<GNKULL> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _gnkullService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _gnkullService.Ncch_UpdateWithImage_Log(model, response.Nesne, global, imagePath);
            }
            else
                sonuc = _gnkullService.Ncch_AddWithImage_NLog(model, global, imagePath);

            return Json(sonuc);
        }

        public ActionResult KullaniciSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _gnkullService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _gnkullService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        #region Depo Tanımları

        public ActionResult DepoTanimMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("Depo/DepoTanimMainPanel", menuTag);
        }

        public ActionResult DepoTanimGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _gndptnService.Cch_GetList_NLog(global);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("Depo/DepoTanimGridPartial", sonuc.Items);
        }

        public ActionResult DepoTanimEkleWindow(int? id, int? menuTag)
        {
            var model = new GNDPTN {ACTIVE = true};
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _gndptnService.Ncch_GetById_NLog(id.Value, global);
                model = result.Nesne;
            }

            return PartialView("Depo/DepoTanimEkleWindow", model);
        }

        public ActionResult DepoTanimKaydet(GNDPTN model, int? menuTag)
        {
            StandardResponse<GNDPTN> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

            if (model.Id > 0)
            {
                var response = _gndptnService.Cch_GetById_NLog(model.Id, global);
                if (response.Status != ResponseStatusEnum.OK)
                {
                    return Json(response);
                }

                global.IsCompare = true;
                sonuc = _gndptnService.Ncch_Update_Log(model, response.Nesne, global);
            }
            else
                sonuc = _gndptnService.Ncch_Add_NLog(model, global);
            return Json(sonuc);
        }

        public ActionResult DepoTanimSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _gndptnService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _gndptnService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        #region Döviz Kuru

        public ActionResult DovizKuruMainPanel(int? menuTag)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = menuTag;
            return View("DovizKuru/DovizKuruMainPanel", menuTag);
        }

        public ActionResult DovizKuruGridPartial(int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var sonuc = _dovkurService.Cch_GetList_NLog(global, true);
            var yetki = _gnyetkService.Cch_GetProjeMenuYetki_NLog(global, global.UserKod).Nesne;
            ViewData["YetkiModel"] = yetki;
            return PartialView("DovizKuru/DovizKuruGridPartial", sonuc.Items);
        }

        public ActionResult DovizKuruEkleWindow(int? id, int? menuTag)
        {
            var model = new DOVKUR();
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            if (id != null && id > 0)
            {
                var result = _dovkurService.Ncch_GetById_NLog(id.Value, global);
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

            return PartialView("DovizKuru/DovizKuruEkleWindow", model);
        }

        public ActionResult DovizKuruKaydet(DOVKUR model, int? menuTag, string imagePath, string imageName)
        {
            StandardResponse<DOVKUR> sonuc;
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;

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

        public ActionResult DovizKuruSil(int id, int? menuTag)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            global.MenuTag = menuTag;
            var model = _dovkurService.Ncch_GetById_NLog(id, global).Nesne;
            var sonuc = _dovkurService.Ncch_Delete_Log(model, global);
            return Json(sonuc);
        }

        #endregion

        public ActionResult RenderPhoto()
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            var sonuc = _gnfileService.Cch_GetDefaultFile_NLog(global, "GNKULL", SessionHelper.UserId.Value);
            return File(sonuc.Nesne.GNDOSY, "jpg");
        }
        
        public ActionResult TopluAktarWindow(string type, string gridId)
        {
            ViewData["gridId"] = gridId;
            return new PartialViewResult
            {
                ViewName = "winTopluAktarim",
                //Model = type,
                ViewData = ViewData
            };
        }

    }
}