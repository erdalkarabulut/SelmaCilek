using System.Web.Optimization;

namespace Bps.BpsBase.WebUI
{
   
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css"));



            var scriptBundle = new ScriptBundle("~/Scripts/DevExtremeBundle");
            var styleBundle = new StyleBundle("~/Content/DevExtremeBundle");
            // CLDR scripts
            scriptBundle
                .Include("~/Scripts/DevExtreme/cldr.js")
                .Include("~/Scripts/DevExtreme/cldr/event.js")
                .Include("~/Scripts/DevExtreme/cldr/supplemental.js")
                .Include("~/Scripts/DevExtreme/cldr/unresolved.js");
            // Globalize 1.x
            scriptBundle
                .Include("~/Scripts/DevExtreme/globalize.js")
                .Include("~/Scripts/DevExtreme/globalize/message.js")
                .Include("~/Scripts/DevExtreme/globalize/number.js")
                .Include("~/Scripts/DevExtreme/globalize/currency.js")
                .Include("~/Scripts/DevExtreme/globalize/date.js");
            // NOTE: jQuery may already be included in the default script bundle. Check the BundleConfig.cs file​​​
            // scriptBundle
            //    .Include("~/Scripts/jquery-1.10.2.js");
            // JSZip for client-side exporting
            // scriptBundle
            //    .Include("~/Scripts/jszip.js");
            // DevExtreme + extensions
            scriptBundle
                .Include("~/Scripts/DevExtreme/dx.all.js")
                .Include("~/Scripts/DevExtreme/aspnet/dx.aspnet.data.js")
                .Include("~/Scripts/DevExtreme/aspnet/dx.aspnet.mvc.js");
            // VectorMap data
            // scriptBundle
            //    .Include("~/Scripts/vectormap-data/africa.js")
            //    .Include("~/Scripts/vectormap-data/canada.js")
            //    .Include("~/Scripts/vectormap-data/eurasia.js")
            //    .Include("~/Scripts/vectormap-data/europe.js")
            //    .Include("~/Scripts/vectormap-data/usa.js")
            //    .Include("~/Scripts/vectormap-data/world.js");
            // DevExtreme themes              
            styleBundle
                .Include("~/Content/DevExtreme/dx.common.css")
                .Include("~/Content/DevExtreme/dx.light.css");
            bundles.Add(scriptBundle);
            bundles.Add(styleBundle);
#if !DEBUG
            BundleTable.EnableOptimizations = true;
#endif

            bundles.IgnoreList.Clear();
        }
    }
}