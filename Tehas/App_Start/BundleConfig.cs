using System.Web;
using System.Web.Optimization;

namespace Klinik.Frontend
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/wysiwyg").Include(
                        "~/Content/wysiwyg/jquery-te-1.4.0.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/ajax").Include(
                        "~/Scripts/jquery.unobtrusive-ajax.min.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/addtocart").Include(
                        "~/Scripts/addtocart.js"));

            bundles.Add(new ScriptBundle("~/bundles/deleteImage").Include(
                        "~/Scripts/deleteImage.js"));

            bundles.Add(new ScriptBundle("~/bundles/lazyload").Include(
                        "~/Scripts/lazyload.js"));

            bundles.Add(new ScriptBundle("~/bundles/jcarousellite").Include(
                        "~/Scripts/jquery.jcarousel.js",
                        "~/Scripts/jcarousellite_1.0.1c5.js"));
           
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/Scripts/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js",
                "~/Scripts/jquery.validate.unobtrusive.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/style.css",
                      "~/Content/reset.css"
                      ));

            bundles.Add(new StyleBundle("~/Content/tabtastic").Include(
                      "~/Content/styleAdmin.css",
                      "~/Content/reset.css",
                      "~/Content/tabtastic.css",
                      "~/Content/wysiwyg/jquery-te-1.4.0.css"
                      ));
        }
    }
}
