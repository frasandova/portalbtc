using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBiotec.Controllers
{
    public class MantenedorFacturasController : Controller
    {
        // GET: MantenedorFacturas
        public ActionResult Index()
        {
            return View();
        }


        // GET: MantenedorFacturas/DeleteEstadoFactura/5
        public ActionResult DeleteEstadoFactura(string RUT, string N_FACTURA, string FECHA_EMISION, string FECHA_GASTO, string monthpicker ="", string monthpickerfin="",string comboboxCanales="", string comboboxClientes="")
        {
            ViewBag.monthpicker = monthpicker;
            ViewBag.monthpickerfin = monthpickerfin;
            ViewBag.comboboxCanales = comboboxCanales;
            ViewBag.comboboxClientes = comboboxClientes;

            ViewBag.RUT = RUT;
            ViewBag.N_FACTURA = N_FACTURA;
            ViewBag.FECHA_EMISION = FECHA_EMISION;
            ViewBag.FECHA_GASTO = FECHA_GASTO;
            return View();
        }

        // POST: MantenedorFacturas/DeleteEstadoFactura/1-9/1/201801/201802
        [HttpPost, ActionName("DeleteEstadoFactura")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string RUT, string N_FACTURA, string FECHA_EMISION, string FECHA_GASTO, string monthpicker = "", string monthpickerfin = "", string comboboxCanales = "", string comboboxClientes = "")
        {
            WebBiotec.Models.DAO.DaoControlDocumento.setFacturasEstados(RUT, N_FACTURA, FECHA_EMISION, FECHA_GASTO);

            return RedirectToAction("mantEstadoFactura", "TradeMarketing" , new
            {
                monthpicker = monthpicker,
                monthpickerfin = monthpickerfin,
                comboboxCanales = comboboxCanales,
                comboboxClientes = comboboxClientes
            });


            //return RedirectToAction("mantEstadoFactura", "TradeMarketing");


            //Html.ActionLink("VOLVER", "mantEstadoFactura", "TradeMarketing")
        }
    }
}