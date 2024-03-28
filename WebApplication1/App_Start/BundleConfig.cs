using System.Web.Optimization;

namespace WebApplication1
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new Bundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            // bundles.
            BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/myscriptsbundle")
                .Include("~/Scripts/jquery-3.4.1.js")
                .Include("~/Scripts/jquery.validate.js")
                .Include("~/Scripts/jquery.validate.unobtrusive.js")

                );

            bundles.Add(new StyleBundle("~/mystylesbundle")
                .Include("~/Content/bootstrap.css")
                .Include("~/Content/bootstrap-grid.css")
                );



        }
    }
}
