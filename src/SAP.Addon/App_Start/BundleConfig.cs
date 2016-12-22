using System.Web.Optimization;

namespace SAP.Addon.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Bundles/css")
                .Include("~/Content/plugins/treegrid/jquery.treegrid.css")
                .Include("~/Content/css/skins/skin-blue.css"));

            bundles.Add(new ScriptBundle("~/Bundles/js")
                .Include("~/Scripts/Pages/application.js")
                .Include("~/Content/plugins/forms/bootstrap-datepicker/bootstrap-datepicker.js")
                .Include("~/Content/plugins/forms/bootstrap-markdown/bootstrap-markdown.js")
                .Include("~/Content/plugins/forms/spinner/jquery.bootstrap-touchspin.js")
                .Include("~/Content/plugins/forms/summernote/summernote.js")
                .Include("~/Content/plugins/forms/maskedinput/jquery.maskedinput.js")
                .Include("~/Scripts/Utils.js")
);

#if DEBUG
            BundleTable.EnableOptimizations = false;
#else
            BundleTable.EnableOptimizations = true;
#endif
        }
    }
}