using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Model;
using Bps.Core.Web.Model.Devexpress;
using Bps.Core.Web.Session;
using DevExpress.Web.Mvc;
using Newtonsoft.Json;

namespace Bps.BpsBase.WebUI.Controllers
{
    public class MainController : SecureController
    {
        private Global global;

        public MainController()
        {
            global = SessionHelper.ConvertSessiontoGlobal();
        }

        private IGnService _gnService = InstanceFactory.GetInstance<IGnService>();
        private IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private ILogsService _logsService = InstanceFactory.GetInstance<ILogsService>();

        public ActionResult Index(string projeKodu, string projeTanim)
        {
            System.Web.HttpContext.Current.Session["MenuTag"] = 0;
            global.ProjeKod = projeKodu;
            global.ProjeTanim = projeTanim;
            var sonuc = _gnyetkService.Cch_ProjeYetkiKontrol_NLog(global, global.UserKod, global.ProjeKod);
            if (sonuc.Status != ResponseStatusEnum.OK)
            {
                return RedirectToAction("Error", new { message = "'" + projeTanim + "' projesine erişim yetkiniz bulunmamaktadır!"});
            }
            System.Web.HttpContext.Current.Session["ProjeKod"] = projeKodu;
            System.Web.HttpContext.Current.Session["ProjeTanim"] = projeTanim;
            return View();
        }

        public ActionResult Error(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        public ActionResult Error2()
        {
            return View();
        }

        #region Partials
        
        public ActionResult NavBarPartial()
        {
            var menus = _gnyetkService.Cch_GetProjeMenuYetkiList_NLog(global,global.ProjeKod,global.UserKod);
            //var stardate = new DateTime(2020, 01, 01);
            //var enddate = new DateTime(2020, 12, 31);
            //var holidays = DateSystem.GetPublicHoliday(stardate, enddate, CountryCode.TR);
            ViewData["ProjeTanim"] = global.ProjeTanim;
            
            return PartialView("Navigation/NavigationPartial", menus);
        }

        public ActionResult HeadPartial()
        {
            return PartialView("Templates/HeadPartial");
        }

        public ActionResult SearchPartial()
        {
            return PartialView("Search/SearchPartial", false);
        }

        [ValidateInput(false)]
        public ActionResult SearchListPartial(string text)
        {
            System.Threading.Thread.Sleep(500);
            ViewData["RequestText"] = text;
            var list=new List<ProjeMenuListed>();
            if (!string.IsNullOrEmpty(text))
            {
                var menus = _gnyetkService.Cch_GetProjeMenuYetkiList_NLog(global, global.ProjeKod, global.UserKod);
                list = menus.Items.Where(w => w.MNUNAM.ToLower().Contains(text.ToLower())).ToList();
            }
            return PartialView("Search/SearchListPartial", list);
        }

        public ActionResult ToolBar(GridViewSettings settings, ProjeMenuListed yetki, DevToolBarParam toolParam)
        {
            ViewData["YetkiModel"] = yetki;
            ViewData["ToolParam"] = toolParam;
            return PartialView("Templates/ToolBar", settings);
        }

        public ActionResult ToolBarBatch(GridViewSettings settings, DevToolBarParam toolParam)
        {
            ViewData["ToolParam"] = toolParam;
            return PartialView("Templates/ToolBarBatch", settings);
        }

        public ActionResult FormFooterPartial(string ekleJs, string iptalJs, bool enableKaydet = true, bool enableIptal = true)
        {
            ViewData["EkleJs"] = ekleJs ?? "";
            ViewData["IptalJs"] = iptalJs ?? "";
            ViewData["EnableKaydet"] = enableKaydet;
            ViewData["EnableIptal"] = enableIptal;
            return PartialView("Templates/FormFooterPartial");
        }

        #endregion

        #region Yerleşim

        public ActionResult YerlesimWindow(int? menuTag, string gridName)
        {
            var list = new List<GridLayoutModel>();
            string path = Server.MapPath("~\\KulGridLayout\\" + global.UserKod + ".json");
            if (System.IO.File.Exists(path))
            {

                var json = System.IO.File.ReadAllText(path);
                list = JsonConvert.DeserializeObject<List<GridLayoutModel>>(json);
                if (list.Count > 0)
                {
                    list = list.Where(w => w.Grid == gridName).ToList();
                }
            }

            ViewData["menuTag"] = menuTag;
            ViewData["gridName"] = gridName;
            return PartialView("YerlesimWindow", list);
        }

        public ActionResult YerlesimGridParital(int? menuTag, string gridName)
        {
            var list = new List<GridLayoutModel>();
            string path = Server.MapPath("~\\KulGridLayout\\" + global.UserKod + ".json");
            if (System.IO.File.Exists(path))
            {

                var json = System.IO.File.ReadAllText(path);
                list = JsonConvert.DeserializeObject<List<GridLayoutModel>>(json);
                if (list.Count > 0)
                {
                    list = list.Where(w => w.Grid == gridName).ToList();
                }
            }

            ViewData["menuTag"] = menuTag;
            ViewData["gridName"] = gridName;
            return PartialView("YerlesimGridParital", list);
        }

        public ActionResult SaveLayout(string gridName, string name)
        {
            var result = new StandardResponse();
            var layoutData = Session[global.UserKod + gridName] != null ? Session[global.UserKod + gridName].ToString() : "";
            if (string.IsNullOrEmpty(layoutData))
            {
                result.Status = ResponseStatusEnum.ERROR;
                result.Message = "İşlem tamamlanamadı! Layout bilgisi okunamadı!";
                return Json(result);
            }

            result = _gnService.DevexpressSaveGridLayout(gridName, layoutData, name, global);
            return Json(result);
        }

        public ActionResult LayoutProcess(string gridName, string name, int type)
        {
            var result = new StandardResponse<string>();
            var layoutData = Session[global.UserKod + gridName] != null ? Session[global.UserKod + gridName].ToString() : "";
            if (string.IsNullOrEmpty(layoutData))
            {
                result.Status = ResponseStatusEnum.ERROR;
                result.Message = "İşlem tamamlanamadı! Layout bilgisi okunamadı!";
                return Json(result);
            }

            result = _gnService.DevexpressProcessGridLayout(gridName, layoutData, name, type, global);

            if (result.Status == ResponseStatusEnum.OK)
            {
                if (type == 0 && result.Nesne == "Count:0")
                {
                    Session[global.UserKod + gridName] = null;
                }
                else if (type == 1)
                {
                    Session[global.UserKod + gridName] = result.Nesne;
                }
            }
            return Json(result);
        }

        #endregion

        #region Belge Akış

        public ActionResult BelgeAkisiWindow(int? id, string type, int? menuTag)
        {
            ViewData["id"] = id;
            ViewData["type"] = type;
            return PartialView("BelgeAkisiWindow");
        }

        public ActionResult BelgeAkisGridParital(int? id, string type, int? menuTag)
        {
            global.MenuTag = menuTag;
            var result = _logsService.Ncch_GetLogsByType_NLog(id, type, global, yetkiKontrol: false);
            ViewData["id"] = id ?? -1;
            ViewData["type"] = type ?? "";
            ViewData["menuTag"] = menuTag ?? 0;
            return PartialView("BelgeAkisGridParital",result.Items);
        }

        #endregion

        #region Ek - File Manager

        public ActionResult EkWindow(int? menuTag, int? tableId, string tableName, string title)
        {
            ViewData["TableId"] = tableId ?? 0;
            ViewData["TableName"] = tableName ?? "";
            ViewData["Title"] = title ?? "";
            Session.Remove(SessionHelper.UserKod + "-" + tableName + "-" + tableId);
            return PartialView("EkWindow");
        }

        #endregion

        #region Edit Popup
        
        public ActionResult EditWindow(BatchEditParamModel model)
        {
            return PartialView("EditWindow", model);
        }

        #endregion
    }
}