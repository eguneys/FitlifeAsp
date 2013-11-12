using System.Web;
using System.Web.Optimization;

namespace Fitlife.WebUI
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Scripts/jquery-ui-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.unobtrusive*",
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/moment").Include(
                "~/Scripts/moment.js",
                "~/Scripts/async.js")
                );

            bundles.Add(new ScriptBundle("~/bundles/Boldex").Include(
              //  "~/Scripts/Boldex/bootstrap.min.js",
                "~/Scripts/Boldex/bootstrap-carousel.js",
                "~/Scripts/Boldex/carousel/jquery.carouFredSel-{version}-packed.js",
                "~/Scripts/Boldex/uitotop/easing.js",
                "~/Scripts/Boldex/uitotop/jquery.ui.totop.js",
                "~/Scripts/Boldex/prettyphoto/*.js",
                "~/Scripts/Boldex/fitvids/*.js",
                "~/Scripts/Boldex/bootstrap-carousel.js",
                "~/Scripts/Boldex/jquery.isotope.js",
                "~/Scripts/Boldex/base.js"));


            bundles.Add(new ScriptBundle("~/bundles/bizStrap").Include(

                                "~/Scripts/bizStrap/jquery.themepunch2.js",
                                "~/Scripts/bizStrap/jquery.themepunch1.js",
                                "~/Scripts/bizStrap/jquery.carouFredsel.js",
                                "~/Scripts/bizStrap/jquery.easy-pie-chart.js",
                                "~/Scripts/bizStrap/library.js",                              
                                "~/Scripts/bizStrap/function.js",
                                "~/Scripts/bizStrap/main.js"

                ));

            bundles.Add(new ScriptBundle("~/bundles/BlueImp").Include(
                "~/Scripts/BlueImp/*.js"
));

            bundles.Add(new ScriptBundle("~/bundles/KnockoutKendo").Include(
                "~/Scripts/KendoUI/kendo.web.min.js",
                "~/Scripts/KendoUI/kendo-binding.js",
                "~/Scripts/KendoUI/knockout-kendo.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/Controllers").Include(
                                "~/Scripts/Controllers/*.js"
                ));
                //bundles.Add(new ScriptBundle("~/bundles/EmberApp").Include(
                //    "~/Scripts/handlebars.js",
                //    "~/Scripts/ember-{version}.js",
                //"~/Scripts/EmberApp/*.js"));


            bundles.Add(new ScriptBundle("~/bundles/knockoutapp").Include(
                                "~/Scripts/knockout-{version}.js",
                                "~/Scripts/KendoUI/jquery.percentageloader-0.1.min.js",
                                "~/Scripts/KendoUI/kendo.web.min.js",
                                "~/Scripts/KendoUI/knockout-kendo.min.js",
                                "~/Scripts/KendoUI/kendo-binding.js",
                                "~/Scripts/KnockoutApp/*.js"
                ));

            bundles.Add(new StyleBundle("~/Content/SiteBundle").Include(
                                "~/Content/Site2.css"
                ));

            bundles.Add(new StyleBundle("~/Content/fontawesomeBundle").Include(
                "~/Content/font-awesome.min.css"
                ));

          //  bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/boldexBundle").Include(
                "~/Content/Boldex/ui.totop.css",
                "~/Content/Boldex/prettyPhoto.css",
                "~/Content/Boldex/base.css"
                               ));

            bundles.Add(new StyleBundle("~/Content/bizStrapBundle").Include(
                                "~/Content/bizStrap/*.css"
                ));

            bundles.Add(new StyleBundle("~/Content/KendoUIBundle").Include(
                                "~/Content/KendoUI/kendo.common.min.css",
                                "~/Content/KendoUI/kendo.default.min.css"
                ));

            bundles.Add(new StyleBundle("~/Content/themes/base/cssBundle").Include(
                        "~/Content/themes/base/jquery.ui.core.css",
                        "~/Content/themes/base/jquery.ui.resizable.css",
                        "~/Content/themes/base/jquery.ui.selectable.css",
                        "~/Content/themes/base/jquery.ui.accordion.css",
                        "~/Content/themes/base/jquery.ui.autocomplete.css",
                        "~/Content/themes/base/jquery.ui.button.css",
                        "~/Content/themes/base/jquery.ui.dialog.css",
                        "~/Content/themes/base/jquery.ui.slider.css",
                        "~/Content/themes/base/jquery.ui.tabs.css",
                        "~/Content/themes/base/jquery.ui.datepicker.css",
                        "~/Content/themes/base/jquery.ui.progressbar.css",
                        "~/Content/themes/base/jquery.ui.theme.css"));
        }
    }
}