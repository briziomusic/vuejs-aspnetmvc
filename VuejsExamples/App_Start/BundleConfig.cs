using System.Web;
using System.Web.Optimization;

namespace VuejsExamples
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

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


#if DEBUG
            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                "~/Scripts/vue.js",
                "~/Scripts/vue-resource.min.js"
            ));
#else
            bundles.Add(new ScriptBundle("~/bundles/vue").Include(
                "~/Scripts/vue.min.js",
                "~/Scripts/vue-resource.min.js"
            ));
#endif

            bundles.Add(new ScriptBundle("~/bundles/views/home").Include(
                "~/Scripts/views/home/index.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/views/client-side-sorting").Include(
                "~/Scripts/views/home/client-side-sorting.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/views/master-detail/index").Include(
                "~/Scripts/views/master-detail/index.js"
            ));

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}
