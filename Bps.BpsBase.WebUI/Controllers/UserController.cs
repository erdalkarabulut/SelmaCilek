using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Params;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Model;
using Bps.Core.Web.Session;
using DevExpress.Web.Demos.Models;
using Newtonsoft.Json;

namespace Bps.BpsBase.WebUI.Controllers
{
    public class UserController : UnsecureController
    {
        private Global global;

        public UserController()
        {
            global = SessionHelper.ConvertSessiontoGlobal();
        }

        private IGnkullService _gnkullService = InstanceFactory.GetInstance<IGnkullService>();
        private readonly IGnthrkService _gnthrkService = InstanceFactory.GetInstance<IGnthrkService>();
        private readonly IGnyetkService _gnyetkService = InstanceFactory.GetInstance<IGnyetkService>();
        private readonly IGnfileService _gnfileService = InstanceFactory.GetInstance<IGnfileService>();

        public ActionResult Login(string returnUrl)
        {
            var param = new GirisParam();
            HttpCookie cookie = System.Web.HttpContext.Current.Request.Cookies["Language"];
            var langkd = "";
            if (cookie != null) langkd = cookie.Value ?? "tr-TR";
            else langkd = "tr-TR";
            param.DilKod = langkd;
            param.ReturnUrl = returnUrl;

            Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(langkd);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(langkd);

            return View(param);
        }

        public ActionResult LoginAjaxWinPartial(int? id, int? menuTag, bool hizliErisim = false)
        {
            return PartialView("LoginAjaxWinPartial");
        }

        public ActionResult GirisYap(GirisParam param)
        {
            param.KaynakKod = "4";
            var sonuc = _gnkullService.Ncch_UserLogin_Log(param);
            Utils.ChangeCurrentTheme(Session["Theme"].ToString());
            Utils.CurrentStoredTheme(Utils.TunableThemeCookieKey, Session["Theme"].ToString());
            Utils.CurrentStoredTheme(Utils.CurrentThemeAspCookieKey, Session["Theme"].ToString());

            Thread.CurrentThread.CurrentCulture = new CultureInfo(param.DilKod);
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(param.DilKod);

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = param.DilKod;
            Response.Cookies.Add(cookie);

            if (sonuc.Status == ResponseStatusEnum.OK)
            {
                //if (!string.IsNullOrEmpty(param.ReturnUrl) && param.ReturnUrl != "/")
                //{
                //    var areaNames = RouteTable.Routes.OfType<Route>()
                //        .Where(d => d.DataTokens != null && d.DataTokens.ContainsKey("area"))
                //        .Select(r => r.DataTokens["area"]).ToArray();

                //    foreach (var areaName in areaNames)
                //    {
                //        if (param.ReturnUrl.Contains("/" + areaName + "/"))
                //        {
                //            if (areaName == "PY")
                //            {
                //                Session["ProjeKod"] = "DH";
                //            }
                //            else
                //            {
                //                Session["ProjeKod"] = areaName;
                //            }
                //            break;
                //        }
                //    }
                //}
            }
            return Json(sonuc);
        }

        public ActionResult CikisYap(string redirect = "/")
        {
            //FormsAuthentication.SignOut();
            try
            {
                HttpContext.Session?.Clear();
            }
            catch
            {
                // ignored
            }
            return Redirect(redirect);
        }

        public ActionResult SessionBreak()
        {
            var sonuc = new StandardResponse();
            //FormsAuthentication.SignOut();
            try
            {
                //var _cacheManager = (ICacheManager)Activator.CreateInstance(typeof(MemoryCacheManager));
                //_cacheManager.Clear();
                //sonuc.Message = "Cache temizlendi!";
                HttpContext.Session?.Clear();
                sonuc.Status = ResponseStatusEnum.OK;
                sonuc.Message = "Session koparıldı!";
            }
            catch (Exception e)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = e.Message;
            }
            return Json(sonuc);
        }

        public ActionResult GetMenuList(string projeKod)
        {
            var sonuc = new ListResponse<ProjeMenuListed>();
            object obj = null;
            try
            {
                if (string.IsNullOrEmpty(projeKod))
                {
                    //projeKod = Session["ProjeKod"].ToString();
                    projeKod = "GN";
                }
                string link = Server.MapPath("..\\KulMenu\\ferdem.json");
                using (StreamReader r = new StreamReader(link))
                {
                    using (JsonTextReader jr = new JsonTextReader(r))
                    {
                        //jr. = Formatting.Indented;
                        JsonSerializer serializer = new JsonSerializer();
                        obj = serializer.Deserialize(jr);
                    }
                }
            }
            catch (Exception e)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            sonuc.Items = JsonConvert.DeserializeObject<List<ProjeMenuListed>>(obj.ToString());
            sonuc.Items = sonuc.Items.Where(w => w.PROKOD == projeKod).OrderBy(o => o.MNUTAG).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return Json(sonuc);
        }

        public JsonResult GetUserInfos()
        {
            var resimkontrol = _gnfileService.Cch_GetDefaultFile_NLog(global, "GNKULL", global.UserId ?? 0);
            if (resimkontrol.Nesne != null)
            {
                global.ResimVarMi = true;
                global.UserImgPath = resimkontrol.Nesne.GNPATH;
            }
            return Json(global);
        }

        public ActionResult ChangeLanguage(string langkd, bool login = false)
        {
            if (langkd != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(langkd);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(langkd);
            }

            HttpCookie cookie = new HttpCookie("Language");
            cookie.Value = langkd;
            Response.Cookies.Add(cookie);

            if (!login)
            {
                var response = _gnkullService.Cch_GetByUserKod_NLog(SessionHelper.UserKod, global);
                if (response.Status == ResponseStatusEnum.OK && response.Nesne != null)
                {
                    response.Nesne.LANGKD = langkd;
                    _gnkullService.UpdateOnlyForLanguage(response.Nesne, global);
                }
                System.Web.HttpContext.Current.Session["DilKod"] = langkd;
                return Redirect("/Dashboard/Index");
            }
            return RedirectToAction("Login", "User");
        }

        public ActionResult TopBar()
        {
            var model = new TopBarInfoModel();
            model.Projects = _gnthrkService.Cch_GetListByTeknad(global, "PROJKD", false).Items;
            model.Languages = _gnthrkService.Cch_GetListByTeknad(global, "LANGKD", false).Items;
            return PartialView("Templates/TopBar", model);
        }

        public ActionResult ProjeYetkiKontrol(string projeKod)
        {
            global.ProjeKod = projeKod;
            var sonuc = _gnyetkService.Cch_ProjeYetkiKontrol_NLog(global, projeKod, global.UserKod);
            return Json(sonuc);
        }

        public ActionResult HesapWindow()
        {
            var teknads = new List<string>() { "ROLEKD" };
            var teknadsResponse = _gnthrkService.Ncch_GetThrkByMultiTeknad_NLog(global, teknads, false);
            ViewData["RolList"] = teknadsResponse.Items.Where(w => w.TEKNAD == "ROLEKD").ToList();

            var kullResponse = _gnkullService.Cch_GetByUserKod_NLog(global.UserKod, global);
            return PartialView("HesapWindow", kullResponse.Nesne);
        }

        public ActionResult SifreKaydet(HesapModel hesapModel)
        {
            var kullResponse = _gnkullService.SifreKaydet(hesapModel, global);
            return Json(kullResponse);
        }
    }
}