using System.Web;
using System.Web.Optimization;

namespace EasyManager.UI
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/jquery/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap/bootstrap.js",
                      "~/Scripts/bootstrap/bootstrap-notify.js",
                      "~/Scripts/plugins/DatePickerScripts/bootstrap-datepicker.js",
                      "~/Scripts/plugins/dataTables/jquery.dataTables.min.js",
                      "~/Scripts/plugins/dataTables/dataTables.bootstrap.min.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/highcharts").Include(
                      "~/Scripts/plugins/highcharts/highcharts.js",
                      "~/Scripts/plugins/highcharts/exporting.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/highmaps").Include(
                      "~/Scripts/plugins/highcharts/highmaps.js",
                      "~/Scripts/plugins/highcharts/data.js",
                      "~/Scripts/plugins/highcharts/za-all.js",
                      "~/Scripts/plugins/highcharts/exporting.js"
                      ));

            bundles.Add(new ScriptBundle("~/bundles/klorofil").Include(
                      "~/Scripts/plugins/jquery-slimscroll/jquery.slimscroll.js",
                      "~/Scripts/plugins/toastr/toastr.js",
                      "~/Scripts/template/klorofil.js"
                      ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/vendor/icon-sets.css",
                      "~/Content/main.css",
                      "~/Content/demo.css",
                      "~/Content/animate.css",
                      "~/Content/spinner.css",
                      "~/Content/DatePickerStyles/bootstrap-datepicker3.css",
                      "~/Content/dataTables/dataTables.bootstrap.min.css"
                      ));
        }
    }
}
