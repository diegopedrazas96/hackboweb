using DevExpress.Web.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIBLIOTECA.Models;
using BIBLIOTECA.MODELDB;
using BIBLIOTECA.SuiteClases.ClsAC;
using System.Data;
using BIBLIOTECA.SuiteClases.clsTools;

namespace BIBLIOTECA.Controllers
{
    public class flotasController : Controller
    {
        AcEntities DB = new AcEntities();

        public DataTable listaAPP { get; set; }
        // GET: flotas
        public ActionResult Index()
        {
              string lsCusr = (Session["Usuario"] == null ? "adm" : Convert.ToString(Session["Usuario"]));
            int liCepc = (Session["xCepc"] == null ? 1 : Convert.ToInt32(Session["xCepc"]));
            using (AcEntities ac = new AcEntities())
            {

                listaAPP = clsAcapp.acappObtenerListaAsig(liCepc, lsCusr, ac);
                ViewBag.Lista = listaAPP.AsEnumerable();
            }

            flotaModel model = new flotaModel(DB);
            return PartialView( model);
        }

        // GET: flotas/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: flotas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: flotas/Create
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

        // GET: flotas/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: flotas/Edit/5
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

        // GET: flotas/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: flotas/Delete/5
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

        BIBLIOTECA.MODELDB.AcEntities db = new BIBLIOTECA.MODELDB.AcEntities();

        [ValidateInput(false)]
        public ActionResult GridViewPartial()
        {

             flotaModel model = new flotaModel(DB);
            return PartialView("_GridViewPartial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialAddNew(BIBLIOTECA.MODELDB.flotas item)
        {
            var model = db.flotas;
            
            if (ModelState.IsValid)
            {
                item.Id = clsTools.acserObtenerID("flotas", "Id", DB);
                //for (int i = 1; i <= item.NroPisos; i++)
                //{
                //    disenoflota diseno = new disenoflota();

                //    diseno.flotaId = item.Id;
                //    diseno.piso = i;

                //}

                try
                {
                    model.Add(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            flotaModel models = new flotaModel(DB);
            return PartialView("_GridViewPartial", models);
        }
        public ActionResult GridViewPartialFlotas(System.Int32 Id)
        {
            string lsCusr = (Session["Usuario"] == null ? "adm" : Convert.ToString(Session["Usuario"]));
            int liCepc = (Session["xCepc"] == null ? 1 : Convert.ToInt32(Session["xCepc"]));
            using (AcEntities ac = new AcEntities())
            {

                listaAPP = clsAcapp.acappObtenerListaAsig(liCepc, lsCusr, ac);
                ViewBag.Lista = listaAPP.AsEnumerable();
            }
            flotaModel models = new flotaModel(DB);
            return View("DisenoFlota", models);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialUpdate(BIBLIOTECA.MODELDB.flotas item)
        {
            var model = db.flotas;
            if (ModelState.IsValid)
            {
                try
                {
                    var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
                    if (modelItem != null)
                    {
                        this.UpdateModel(modelItem);
                        db.SaveChanges();
                    }
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridViewPartial", model.ToList());
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridViewPartialDelete(System.Int32 Id)
        {
            var model = db.flotas;
            if (Id >= 0)
            {
                try
                {
                    var item = model.FirstOrDefault(it => it.Id == Id);
                    if (item != null)
                        model.Remove(item);
                    db.SaveChanges();
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridViewPartial", model.ToList());
        }
    }
}
