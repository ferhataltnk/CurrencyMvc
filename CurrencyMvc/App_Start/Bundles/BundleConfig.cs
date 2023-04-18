using System.Web.Optimization;

namespace CurrencyMvc.App_Start.Bundles
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jq-ajax-bundle").Include(
                "~/lib/jquery/dist/jquery.min.js",
                "~/lib/jquery-unobtrusive-ajax/jquery.unobtrusive-ajax.min.js"));
        }
    }
}
