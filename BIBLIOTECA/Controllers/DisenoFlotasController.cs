using BIBLIOTECA.MODELDB;
using BIBLIOTECA.Models;
using BIBLIOTECA.SuiteClases.ClsAC;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBLIOTECA.Controllers
{
    public class DisenoFlotasController : Controller
    {
        public DataTable listaAPP { get; set; }
        AcEntities DB = new AcEntities();
        // GET: DisenoFlotas
        public ActionResult Index()
        {
            string lsCusr = (Session["Usuario"] == null ? "adm" : Convert.ToString(Session["Usuario"]));
            int liCepc = (Session["xCepc"] == null ? 1 : Convert.ToInt32(Session["xCepc"]));
            using (AcEntities ac = new AcEntities())
            {

                listaAPP = clsAcapp.acappObtenerListaAsig(liCepc, lsCusr, ac);
                ViewBag.Lista = listaAPP.AsEnumerable();
            }
            disenoflotaModal model = new disenoflotaModal(DB);
            return View(model);
        }

        // GET: DisenoFlotas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: DisenoFlotas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: DisenoFlotas/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DisenoFlotas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: DisenoFlotas/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: DisenoFlotas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: DisenoFlotas/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
