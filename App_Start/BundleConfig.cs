﻿using System.Web;
using System.Web.Optimization;

namespace AppWebCompleto
{
    public class BundleConfig
    {
        // Para obter mais informações sobre o agrupamento, visite https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use a versão em desenvolvimento do Modernizr para desenvolver e aprender. Em seguida, quando estiver
            // pronto para a produção, utilize a ferramenta de build em https://modernizr.com para escolher somente os testes que precisa.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                        "~/Scripts/bootstrap.bundle.min.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/adminlte/plugins/fontawesome-free/css/all.min.css",
                      "~/adminlte/css/adminlte.min.css",
                      "~/adminlte/plugins/summernote/summernote-bs4.min.css",
                      "~/adminlte/plugins/datatables-bs4/css/dataTables.bootstrap4.min.css",
                      "~/adminlte/plugins/datatables-responsive/css/responsive.bootstrap4.min.css",
                      "~/adminlte/plugins/datatables-buttons/css/buttons.bootstrap4.min.css",
                      "~/adminlte/plugins/datatables-searchpanes/css/searchPanes.bootstrap4.min.css",
                      "~/adminlte/plugins/icheck-bootstrap/icheck-bootstrap.min.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/adminlte/js").Include(
             "~/adminlte/js/adminlte.min.js",
             "~/adminlte/plugins/datatables/jquery.dataTables.min.js",
             "~/adminlte/plugins/datatables-bs4/js/dataTables.bootstrap4.min.js",
             "~/adminlte/plugins/datatables-responsive/js/dataTables.responsive.min.js",
             "~/adminlte/plugins/datatables-responsive/js/responsive.bootstrap4.min.js",
             "~/adminlte/plugins/datatables-buttons/js/dataTables.buttons.min.js",
             "~/adminlte/plugins/datatables-buttons/js/buttons.bootstrap4.min.js",
             "~/adminlte/plugins/datatables-buttons/js/buttons.html5.min.js",
             "~/adminlte/plugins/datatables-buttons/js/buttons.print.min.js",
             "~/adminlte/plugins/datatables-buttons/js/buttons.colVis.min.js",
             "~/adminlte/plugins/jszip/jszip.min.js",
             "~/adminlte/plugins/pdfmake/pdfmake.min.js",
             "~/adminlte/plugins/pdfmake/vfs_fonts.js",
             "~/adminlte/plugins/datatables-searchpanes/js/dataTables.searchPanes.min.js",
            //"~/adminlte/plugins/jquery/jquery.min.js",
             "~/adminlte/plugins/summernote/summernote-bs4.min.js"
             ));
        }
    }
}
