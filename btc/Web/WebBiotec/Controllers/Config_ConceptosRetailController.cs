using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebBiotec.Models;

namespace WebBiotec.Controllers
{
    public class Config_ConceptosRetailController : Controller
    {
        private ModelMantenedores db = new ModelMantenedores();

        [Authorize]
        // GET: Config_ConceptosRetail
        public ActionResult Index(string comboboxCanales="",string comboboxClientes="")
        {

         
            ViewBag.comboboxClientes = comboboxClientes;
            if (comboboxClientes != "0" && comboboxClientes != "")
            {
                string vrut = comboboxClientes.Substring(0, comboboxClientes.IndexOf(";"));
                string vficha = comboboxClientes.Substring(comboboxClientes.IndexOf(";") + 1);
                int cantidad;

                using (var ctx = new Model1())
                {
                    cantidad = ctx.Database.SqlQuery<int>("select count(*) from [dbo].[CONFIG_CADENAS] where RUT =@vRut"
                                     , new SqlParameter("@vRut", vrut))
                                     .SingleOrDefault();
                }

                if (cantidad == 0)
                {
                    if (vficha != "0")
                    {
                        return View(db.Config_ConceptosRetail
                                      .Where(x => x.RUT == vrut && x.FICHA == vficha)
                                      .ToList());
                    }
                    else
                    {
                        return View(db.Config_ConceptosRetail.Where(x => x.RUT == vrut).ToList());
                    }
                }
                else
                {
                    List<string> listaRut;
                    using (var ctx = new Model1())
                    {
                      listaRut = ctx.Database.SqlQuery<string>(
                     "SELECT RUT FROM [dbo].[CONFIG_CADENAS] WHERE CADENA IN(SELECT CADENA FROM [dbo].[CONFIG_CADENAS] WHERE RUT = @vRut)"
                      ,new SqlParameter("@vRut", vrut)).ToList();
                    }
                    // XXXX

                    return View(db.Config_ConceptosRetail.Where(x => listaRut.Contains(x.RUT)).ToList());
                    //return View(db.Config_ConceptosRetail.Where(x => x.RUT == vrut).ToList());
                    //dataSource.StateList.Where(s => countryCodes.Contains(s.CountryCode))

                }




            }
            else
            {
                var result = from e in db.Config_ConceptosRetail
                             orderby e.RUT, e.COD_CONCEPTO
                             select e;

                return View(result);
                //    .OrderBy(x=> x.RUT)
                //    .OrderBy(x=> x.COD_CONCEPTO)
                //    .ToList());
            }

            
        }

        //[HttpPost]
        //public ActionResult Index(string rut)
        //{
        //    return View(db.Config_ConceptosRetail.Where(x => x.RUT == rut).ToList());
            
        //}

        // GET: Config_ConceptosRetail/Details/5
        public ActionResult Details(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Config_ConceptosRetail config_ConceptosRetail = db.Config_ConceptosRetail.Find(id);
            if (config_ConceptosRetail == null)
            {
                return HttpNotFound();
            }
            return View(config_ConceptosRetail);
        }

        // GET: Config_ConceptosRetail/Create
        public ActionResult Create(string comboboxCanales = "", string comboboxClientes = "")

        {
            var listClientesCuentas = Models.DAO.DaoControlDocumento.getMasterCuentas();
            List<SelectListItem> listCuentasContables = new List<SelectListItem>();
            foreach (var item in listClientesCuentas)
            {
                SelectListItem selectedListItem = new SelectListItem
                {
                    Text = item.TEXTO,
                    Value = item.VALOR
                };
                listCuentasContables.Add(selectedListItem);
            }
            //ViewBag.COD_CONCEPTO = listCuentasContables;
            ViewBag.CuentasContables = listCuentasContables;
            return View();
        }

        // POST: Config_ConceptosRetail/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,RUT,FICHA,COD_CONCEPTO,CONCEPTO,COD_CUENTA,PORCENTAJE,TIPO_CALCULO")] Config_ConceptosRetail config_ConceptosRetail, string comboboxCanales = "", string comboboxClientes = "")
        {
            if (ModelState.IsValid)
            {
                db.Config_ConceptosRetail.Add(config_ConceptosRetail);
                db.SaveChanges();
                return RedirectToAction("Index", new { comboboxCanales = comboboxCanales, comboboxClientes = comboboxClientes });
            }
            var listClientesCuentas = Models.DAO.DaoControlDocumento.getMasterCuentas();
            List<SelectListItem> listCuentasContables = new List<SelectListItem>();
            foreach (var item in listClientesCuentas)
            {
                SelectListItem selectedListItem = new SelectListItem
                {
                    Text = item.TEXTO,
                    Value = item.VALOR
                };
                listCuentasContables.Add(selectedListItem);
            }
            ViewBag.CuentasContables = listCuentasContables;
            return View(config_ConceptosRetail);
        }

        // GET: Config_ConceptosRetail/Edit/5
        public ActionResult Edit(int? id, string comboboxCanales = "", string comboboxClientes = "")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            //var listClientesCuentas = Models.DAO.DaoControlDocumento.getClientesCuentas(comboboxClientes);
            var listClientesCuentas = Models.DAO.DaoControlDocumento.getMasterCuentas();
            

            List<SelectListItem> listCuentasContables = new List<SelectListItem>();
            foreach (var item in listClientesCuentas)
            {
                SelectListItem selectedListItem = new SelectListItem
                {
                    Text = item.TEXTO,
                    Value = item.VALOR
                };
                listCuentasContables.Add(selectedListItem);
            }
            ViewBag.CuentasContables = listCuentasContables;
            Config_ConceptosRetail config_ConceptosRetail = db.Config_ConceptosRetail.Find(id);
       

            if (config_ConceptosRetail == null)
            {
                return HttpNotFound();
            }
            return View(config_ConceptosRetail);
        }

        // POST: Config_ConceptosRetail/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,RUT,FICHA,COD_CONCEPTO,CONCEPTO,COD_CUENTA,PORCENTAJE,TIPO_CALCULO")] Config_ConceptosRetail config_ConceptosRetail, string comboboxCanales = "", string comboboxClientes = "")
        {
            if (ModelState.IsValid)
            {
                db.Entry(config_ConceptosRetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { comboboxCanales = comboboxCanales, comboboxClientes = comboboxClientes});
            }
            var listClientesCuentas = Models.DAO.DaoControlDocumento.getMasterCuentas();
            List<SelectListItem> listCuentasContables = new List<SelectListItem>();
            foreach (var item in listClientesCuentas)
            {
                SelectListItem selectedListItem = new SelectListItem
                {
                    Text = item.TEXTO,
                    Value = item.VALOR
                };
                listCuentasContables.Add(selectedListItem);
            }
            ViewBag.CuentasContables = listCuentasContables;
            return View(config_ConceptosRetail);
        }

        // GET: Config_ConceptosRetail/Delete/5
        public ActionResult Delete(int? id, string comboboxCanales = "", string comboboxClientes = "")
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Config_ConceptosRetail config_ConceptosRetail = db.Config_ConceptosRetail.Find(id);
            if (config_ConceptosRetail == null)
            {
                return HttpNotFound();
            }
            return View(config_ConceptosRetail);
        }

        // POST: Config_ConceptosRetail/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Config_ConceptosRetail config_ConceptosRetail = db.Config_ConceptosRetail.Find(id);
            db.Config_ConceptosRetail.Remove(config_ConceptosRetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
        
    }

}
