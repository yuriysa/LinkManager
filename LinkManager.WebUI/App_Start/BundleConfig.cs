using System.Web.Optimization;
using System.Web.UI.WebControls;

namespace LinkManager.WebUI
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/vendors/angular.js",
                "~/Scripts/vendors/ui-bootstrap.js",
                "~/Scripts/vendors/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/home/linkCtrl.js",
                "~/Scripts/spa/services/apiService.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/css/bootstrap.css",
                "~/Content/css/ui-bootstrap-csp.css",
                "~/Content/css/bootstrap-theme.css"));

            BundleTable.EnableOptimizations = false;
        }
    }
}