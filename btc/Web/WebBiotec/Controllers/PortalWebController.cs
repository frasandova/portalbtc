using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebBiotec.Controllers
{
    public class PortalWebController : Controller
    {
        // GET: PortalWeb
        public ActionResult Index()
        {
            return View();
        }



        public JsonResult cargarClientes()
        {
            var resultado = WebBiotec.Models.DAO.DaoControlPresupuesto.getClientes();
            return Json(resultado, JsonRequestBehavior.AllowGet);
        }

    }
}