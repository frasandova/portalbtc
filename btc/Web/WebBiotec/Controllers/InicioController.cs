using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebBiotec.Models.DTO;

namespace WebBiotec.Controllers
{
    public class InicioController : Controller
    {
        // GET: Inicio
        public ActionResult Index()
        {
            return View();
        }

        public List<tablaVentas> ventas_consolidado(string MES)
        {
            List<tablaVentas> ventas = WebBiotec.Models.DAO.DaoControlPresupuesto.getVentasConsoliado(MES);
            return ventas;
        }
    }
}