using System.Web;
using System.Web.Optimization;

namespace WebBiotec
{
    public class BundleConfig
    {
        // Para obtener más información sobre Bundles, visite http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                         "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Utilice la versión de desarrollo de Modernizr para desarrollar y obtener información. De este modo, estará
            // preparado para la producción y podrá utilizar la herramienta de compilación disponible en http://modernizr.com para seleccionar solo las pruebas que necesite.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////


            bundles.Add(new StyleBundle("~/Content/logincss").Include(
          //"~/Content/assets/plugins/jquery-datatables-editable/datatables.css",
          "~/Content/bootstrap.css",
          "~/Content/assets/login/css/core.css",
          "~/Content/assets/login/css/components.css",
          "~/Content/assets/login/css/icons.css",
          "~/Content/assets/login/css/pages.css",
          "~/Content/assets/login/css/menu.css",
          "~/Content/assets/login/css/responsive.css"));


            bundles.Add(new StyleBundle("~/Content/dataTableCss").Include(
          "~/Content/assets/dashboard/vendors/datatables.net-bs/css/dataTables.bootstrap.min.css",
          "~/Content/assets/dashboard/vendors/datatables.net-buttons-bs/css/buttons.bootstrap.min.css",
          "~/Content/assets/dashboard/vendors/datatables.net-fixedheader-bs/css/fixedHeader.bootstrap.min.css",
          "~/Content/assets/dashboard/vendors/datatables.net-responsive-bs/css/responsive.bootstrap.min.css",
          "~/Content/assets/dashboard/vendors/datatables.net-scroller-bs/css/scroller.bootstrap.min.css"));





            ////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////
            ////////////////////////////////////////////////////////////////////////////////////////////

            // Bundles Layout
            ///////////////////////////////////////////////////////////////////////////////////////

            bundles.Add(new StyleBundle("~/Content/dashboardcss").Include(
            //"~/Content/assets/plugins/jquery-datatables-editable/datatables.css",
            "~/Content/assets/dashboard/vendors/bootstrap/dist/css/bootstrap.min.css",
            "~/Content/assets/dashboard/vendors/font-awesome/css/font-awesome.min.css",
            "~/Content/assets/dashboard/vendors/nprogress/nprogress.css",
            "~/Content/assets/dashboard/vendors/iCheck/skins/flat/green.css",
            "~/Content/assets/dashboard/vendors/bootstrap-progressbar/css/bootstrap-progressbar-3.3.4.min.css",
            "~/Content/assets/dashboard/vendors/iCheck/skins/flat/green.css",
            "~/Content/assets/dashboard/vendors/jqvmap/dist/jqvmap.min.css",
            "~/Content/assets/dashboard/bootstrap-daterangepicker/daterangepicker.css",            
            "~/Content/assets/dashboard/build/css/custom.css"));
            //"~/Content/assets/dashboard/build/css/custom.min.css"));


            bundles.Add(new ScriptBundle("~/Content/dashboardjs").Include(
            //"~/Content/assets/dashboard/vendors/jquery/dist/jquery.min.js",
            "~/Content/assets/dashboard/vendors/bootstrap/dist/js/bootstrap.min.js",
            "~/Content/assets/dashboard/vendors/fastclick/lib/fastclick.js",
            "~/Content/assets/dashboard/vendors/iCheck/icheck.min.js",
            "~/Content/assets/dashboard/vendors/nprogress/nprogress.js",
            "~/Content/assets/dashboard/vendors/Chart.js/dist/Chart.min.js",
            "~/Content/assets/dashboard/vendors/gauge.js/dist/gauge.min.js",
            "~/Content/assets/dashboard/vendors/bootstrap-progressbar/bootstrap-progressbar.min.js",
            "~/Content/assets/dashboard/vendors/skycons/skycons.js",
            "~/Content/assets/dashboard/vendors/Flot/jquery.flot.js",
            "~/Content/assets/dashboard/vendors/Flot/jquery.flot.pie.js",
            "~/Content/assets/dashboard/vendors/Flot/jquery.flot.time.js",
            "~/Content/assets/dashboard/vendors/Flot/jquery.flot.stack.js",
            "~/Content/assets/dashboard/vendors/Flot/jquery.flot.resize.js",
            "~/Content/assets/dashboard/vendors/flot.orderbars/js/jquery.flot.orderBars.js",
            "~/Content/assets/dashboard/vendors/flot-spline/js/jquery.flot.spline.min.js",
            "~/Content/assets/dashboard/vendors/flot.curvedlines/curvedLines.js",
            "~/Content/assets/dashboard/vendors/DateJS/build/date.js",
            "~/Content/assets/dashboard/vendors/jqvmap/dist/jquery.vmap.js",
            "~/Content/assets/dashboard/vendors/jqvmap/dist/maps/jquery.vmap.world.j",
            "~/Content/assets/dashboard/vendors/jqvmap/examples/js/jquery.vmap.sampledata.js",
            "~/Content/assets/dashboard/vendors/moment/min/moment.min.js",
            "~/Content/assets/dashboard/vendors/bootstrap-daterangepicker/daterangepicker.js",
            "~/Content/assets/dashboard/build/js/custom.js"));

            bundles.Add(new ScriptBundle("~/Content/jquery").Include(
           "~/Content/assets/dashboard/vendors/jquery/dist/jquery.min.js"
           ));                  

            //Amchart
            bundles.Add(new ScriptBundle("~/Content/AmchartJs").Include(
                "~/Content/assets/amcharts/amcharts/amcharts.js",
                "~/Content/assets/amcharts/amcharts/serial.js",
                "~/Content/assets/amcharts/amcharts/radar.js",
                "~/Content/assets/amcharts/amcharts/pie.js",
                "~/Content/assets/amcharts/amcharts/themes/dark.js",
                "~/Content/assets/amcharts/amcharts/themes/light.js",
                "~/Content/assets/amcharts/amcharts/plugins/export/export.min.js"
                ));

                bundles.Add(new StyleBundle("~/Content/AmchartCs").Include(
                "~/Content/assets/amcharts/amcharts/plugins/export/export.css"
                ));

            //DataTable
            bundles.Add(new ScriptBundle("~/TablasEditables").Include(
                  "~/Content/assets/plugins/jquery-datatables-editable/jquery.dataTables.js",
                  "~/Content/assets/plugins/datatables/dataTables.bootstrap.js",
                  "~/Content/assets/plugins/tiny-editable/mindmup-editabletable.js",
                  "~/Content/assets/plugins/datatables/dataTables.buttons.min.js",
                  "~/Content/assets/plugins/datatables/buttons.bootstrap.min.js",
                  "~/Content/assets/plugins/datatables/jszip.min.js",
                  "~/Content/assets/plugins/datatables/pdfmake.min.js",
                  "~/Content/assets/plugins/datatables/vfs_fonts.js",
                  "~/Content/assets/plugins/datatables/buttons.html5.min.js",
                  "~/Content/assets/plugins/datatables/buttons.print.min.js",
                  "~/Content/assets/plugins/datatables/dataTables.fixedHeader.min.js",
                  "~/Content/assets/plugins/datatables/dataTables.keyTable.min.js",
                  "~/Content/assets/plugins/datatables/dataTables.responsive.min.js",
                  "~/Content/assets/plugins/datatables/responsive.bootstrap.min.js",
                  "~/Content/assets/plugins/datatables/dataTables.scroller.min.js"
                  ));

            bundles.Add(new ScriptBundle("~/Init").Include(
                  "~/Content/assets/pages/jquery.datatables.editable.init.js"));

            //Kendoui

            bundles.Add(new StyleBundle("~/KendoCss").Include(
                "~/Content/assets/kendoui/styles/kendo.common-material.min.css",
                "~/Content/assets/kendoui/styles/kendo.material.min.css"
                //"~/Content/assets/kendoui/styles/kendo.common.min.css"
                ));
            //"~/Content/assets/kendoui/styles/kendo.default.min.css",
            //"~/Content/assets/kendoui/styles/kendo.default.mobile.min.css",


            bundles.Add(new ScriptBundle("~/KendoJs").Include(
                "~/Content/assets/kendoui/js/kendo.all.min.js",
                "~/Content/assets/kendoui/js/cultures/kendo.culture.es-CL.min.js",
                "~/Content/assets/kendoui/js/kendo.all.min.js",
                "~/Content/assets/kendoui/js/jszip.min.js",
                "~/Content/assets/kendoui/js/kendo.all.min.js",
                "~/Content/assets/kendoui/js/pako.min.js"));

            bundles.Add(new ScriptBundle("~/ComunesJs").Include(
         "~/Scripts/comunes.js"
         ));

            bundles.Add(new ScriptBundle("~/Content/dataTableJs").Include(
                "~/Content/assets/dashboard/vendors/datatables.net/js/jquery.dataTables.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-bs/js/dataTables.bootstrap.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-buttons/js/dataTables.buttons.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-buttons-bs/js/buttons.bootstrap.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-buttons/js/buttons.flash.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-buttons/js/buttons.html5.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-buttons/js/buttons.print.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-fixedheader/js/dataTables.fixedHeader.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-keytable/js/dataTables.keyTable.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-responsive/js/dataTables.responsive.min.js",
                "~/Content/assets/dashboard/vendors/datatables.net-responsive-bs/js/responsive.bootstrap.js",
                "~/Content/assets/dashboard/vendors/datatables.net-scroller/js/dataTables.scroller.min.js"));

        }
    }
}
