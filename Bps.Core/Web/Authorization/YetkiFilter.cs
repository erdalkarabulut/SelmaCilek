using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bps.Core.Web.Model;
using Bps.Core.Web.Session;
using Newtonsoft.Json;

namespace Bps.Core.Web.Authorization
{
    public class YetkiFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /// 1 : Görüntüleme Ekranı
            /// 2 : Ekleme Ekranı
            /// 3 : Değiştirme Ekranı
            /// 4 : Silme
            /// 5 : PDF
            /// 6 : Excel
            /// 7 : Yazdir
            /// 8 : Değişiklik Kaydet
            /// 9 : XML
            /// 10 : CSV
            /// 11 : DOC 
            
            var control = true;
            base.OnActionExecuting(filterContext);

            //if (!filterContext.IsChildAction)
            //{
            //    foreach (var parameter in filterContext.ActionParameters)
            //    {
            //        if (parameter.Key == "menuTag")
            //        {
            //            var myAttr = filterContext.ActionDescriptor.GetCustomAttributes(true).FirstOrDefault();

            //            if (myAttr != null)
            //            {
            //                if (parameter.Value == null)
            //                {
            //                    Ext.Net.X.Call("BpsAlert.error", "Menü bilgisi okunamadı, lütfen yöneticinizle iletişime geçiniz!");
            //                    filterContext.Result = Ext.Net.MVC.ControllerExtensions.Direct((System.Web.Mvc.Controller)filterContext.Controller);
            //                    return;
            //                }

            //                var order = ((System.Web.Mvc.FilterAttribute)((filterContext.ActionDescriptor
            //                    .GetCustomAttributes(true))[0])).Order;
            //                var menuControl = MenuControlByJson((int)parameter.Value, order);
            //                if (!menuControl)
            //                {
            //                    Ext.Net.X.Call("BpsAlert.error", "Yetkiniz Yok!");
            //                    filterContext.Result = Ext.Net.MVC.ControllerExtensions.Direct((System.Web.Mvc.Controller)filterContext.Controller);
            //                    return;
            //                }
            //            }
            //        }
            //    }
            //}
        }

        public override void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (filterContext.IsChildAction)
                return;
        }

        public bool MenuControlByJson(int? menuTag, int order)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();

            object obj = null;
            try
            {
                string link = HttpContext.Current.Server.MapPath("~\\KulMenu\\" + global.UserKod + ".json");
                using (StreamReader r = new StreamReader(link))
                {
                    using (JsonTextReader jr = new JsonTextReader(r))
                    {
                        //jr. = Formatting.Indented;
                        JsonSerializer serializer = new JsonSerializer();
                        obj = serializer.Deserialize(jr);
                    }
                }

                var items = JsonConvert.DeserializeObject<List<ProjeMenuListed>>(obj.ToString());
                var control = items.FirstOrDefault(w => w.PROKOD == global.ProjeKod && w.MNUTAG == menuTag);

                if (control != null)
                {
                    switch (order)
                    {
                        case 1:
                            if (control.GRNTLM) return true;
                            break;
                        case 2:
                            if (control.EKLEME) return true;
                            break;
                        case 3:
                            if (control.DEGIST) return true;
                            break;
                        case 4:
                            if (control.SILMEK) return true;
                            break;
                        case 5:
                            if (control.PDFGOS) return true;
                            break;
                        case 6:
                            if (control.EXCGOS) return true;
                            break;
                        case 8:
                            if (control.SILMEK && control.DEGIST && control.EKLEME) return true;
                            break;
                        case 9:
                            if (control.XMLGOS) return true;
                            break;
                        case 10:
                            if (control.CSVGOS) return true;
                            break;
                        case 11:
                            if (control.DOCGOS) return true;
                            break;
                    }
                }
            }
            catch (Exception e)
            {
                ;
            }
            return false;
        }
    }
}