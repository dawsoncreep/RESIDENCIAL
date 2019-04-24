using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace FrontEnd.App_Start
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Assets/node_modules/jquery/dist/jquery.js"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información sobre los formularios. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Assets/node_modules/modernizr/modernizr*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Assets/node_modules/bootstrap/dist/js/bootstrap.js",
                      "~/Assets/node_modules/Respond.js/dest/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/enums").Include(
                      "~/Assets/js/enums.js"));

            bundles.Add(new ScriptBundle("~/bundles/users").Include(
                "~/Assets/js/User/*.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/menu").Include(
                "~/Assets/js/Menu/*.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/administration").Include(
                "~/Assets/js/Administration/*.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Assets/js/common.js"
                ));


            bundles.Add(new StyleBundle("~/Content/bootstraptheme").Include(
                    "~/Assets/node_modules/bootstrap/dist/css/bootstrap-theme.css",
                    "~/Assets/css/site.css"));

            bundles.Add(new StyleBundle("~/Content/fontawesome").Include(
                "~/Assets/node_modules/font-awesome/css/font-awesome.css"
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Assets/node_modules/bootstrap/dist/css/bootstrap.css"
                      ));
        }
    }
}