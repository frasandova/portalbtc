using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBiotec.Models.DTO;

namespace WebBiotec.Controllers
{
    public class TradeMarketingController : Controller
    {
        // GET: TradeMarketing
        [Authorize]
        public ActionResult ControlPresupuesto()
        {
            return View();
        }

        [Authorize]
        public ActionResult ControlDocumentos()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult ControlDocumentos(string comboboxClientes, string comboboxNumeroDocumento, string engineeFacturaEstado, string txtComentario, string txtFechaEmision, string txtFechaGasto, string txtCuentaContable, string comboboxCuentaContableNueva, string txtNuevaFechaGasto)
        {

            WebBiotec.Models.DAO.DaoControlDocumento.IngresarEstadoFactura(comboboxClientes, comboboxNumeroDocumento, engineeFacturaEstado, txtComentario, txtFechaEmision, txtFechaGasto, txtCuentaContable, comboboxCuentaContableNueva, txtNuevaFechaGasto);
            return View();
        }

        public ActionResult Procedimiento(string comboboxClientes)
        {
            return View();
        }


        public JsonResult cargarClientesJSON()
        {
            var resultado = WebBiotec.Models.DAO.DaoControlPresupuesto.getClientes();
            ComboboxClientes itemTodos = new ComboboxClientes();
            itemTodos.texto = "Seleccionar";
            itemTodos.valor = "0";
            resultado.Add(itemTodos);
            ViewBag.cadenasClientes = resultado;

            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult cargarCadenasClientesJSON(string codCanal,string perfil)
        {
            var resultado = WebBiotec.Models.DAO.DaoControlPresupuesto.GetCadenasClientes(codCanal, perfil);
            return Json(resultado, JsonRequestBehavior.AllowGet);

        }

        public static List<ComboboxClientes> cargarClientes()
        {
            var resultado = WebBiotec.Models.DAO.DaoControlPresupuesto.getClientes();
            ComboboxClientes itemTodos = new ComboboxClientes();
            itemTodos.texto = "Seleccionar";
            itemTodos.valor = "0";
            resultado.Add(itemTodos);

            return resultado;

        }

        public JsonResult LoadGraficoVentas(string CODCANAL,string RUTCLIENTE, string MES)
        {
            var resultado = WebBiotec.Models.DAO.DaoControlPresupuesto.LoadGraficoVentas(CODCANAL, RUTCLIENTE, MES);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadGraficoProvisionFacturas(string CODCANAL, string RUTCLIENTE, string MES)
        {
            var resultado = WebBiotec.Models.DAO.DaoControlPresupuesto.LoadGraficoProvisionFacturas(CODCANAL, RUTCLIENTE, MES);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadGraficoDetalleCuenta(string CODCANAL, string RUTCLIENTE, string MES)
        {
            var resultado = WebBiotec.Models.DAO.DaoControlPresupuesto.getDetallePorCuentaGrafico(CODCANAL, RUTCLIENTE, MES);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadFacturasJson(string CODCANAL, string RUTCLIENTE)
        {
            var resultado = WebBiotec.Models.DAO.DaoControlDocumento.getFacturas(CODCANAL, RUTCLIENTE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadDetalleFacturasJson(string CODCANAL, string RUTCLIENTE, string FACTURA)
        {
            var resultado = WebBiotec.Models.DAO.DaoControlDocumento.getDetalleFacturas(CODCANAL, RUTCLIENTE, FACTURA);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LoadCuentasClientes(string RUTCLIENTE)
        {
            var resultado = WebBiotec.Models.DAO.DaoControlDocumento.getClientesCuentas(RUTCLIENTE);
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult LimpiarEstadoFactura(string RUTCLIENTE, string FACTURA, string FECHAEMISION, string FECHAGASTO)
        {
            WebBiotec.Models.DAO.DaoControlDocumento.setFacturasEstados(RUTCLIENTE, FACTURA, FECHAEMISION, FECHAGASTO);
            var resultado = "Factura " + FACTURA + " Actualizada";
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

        public JsonResult getDetallesDocumentosCuenta(string CODCANAL, string RUTCLIENTE, string MES, string CUENTA)
        {
            var result = WebBiotec.Models.DAO.DaoControlPresupuesto.getDetallesDocumentosCuenta(CODCANAL, RUTCLIENTE, MES, CUENTA);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [Authorize]
        public ActionResult mantEstadoFactura()
        {
            return View();
        }
     
    }
}