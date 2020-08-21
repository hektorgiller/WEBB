using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace PersonelMVC.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/scripts").Include(
                 "~/Scripts/jquery-3.0.0.min.js",
                 "~/Scripts/jquery.unobtrusive-ajax.min.js",
                 "~/Scripts/bootstrap.min.js",
                 "~/Scripts/DataTables/jquery.dataTables.min.js",
                 "~/Scripts/DataTables/responsive.bootstrap.min.js" 
                ));
        }
    }
}