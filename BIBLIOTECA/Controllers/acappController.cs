using DevExpress.Web.Mvc;
using BIBLIOTECA.MODELDB;
using BIBLIOTECA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIBLIOTECA.SuiteClases.ClsAC;
using System.Data;

namespace BIBLIOTECA.Controllers
{
   
    public class acappController : Controller
    {

        public DataTable listaAPP { get; set; }
        AcEntities DB = new AcEntities();  
        public ActionResult Index()
        {
            string lsCusr = (Session["Usuario"] == null ? "adm" : Convert.ToString(Session["Usuario"]));
            int liCepc = (Session["xCepc"] == null ? 1 : Convert.ToInt32(Session["xCepc"]));
            using (AcEntities ac = new AcEntities())
            {

                listaAPP = clsAcapp.acappObtenerListaAsig(liCepc, lsCusr, ac);
                ViewBag.Lista = listaAPP.AsEnumerable();
            }
            acappModel model =new acappModel(DB);
            return View(model);
        }

        // GET: acapp/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: acapp/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: acapp/Create
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

        // GET: acapp/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: acapp/Edit/5
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

        // GET: acapp/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: acapp/Delete/5
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

        [ValidateInput(false)]
        public ActionResult GridView1Partial()
        {
            acappModel model = new acappModel(DB);
            return PartialView("_GridView1Partial", model);
        }

        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialAddNew(BIBLIOTECA.MODELDB.acapp item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to insert the new item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialUpdate(BIBLIOTECA.MODELDB.acapp item)
        {
            var model = new object[0];
            if (ModelState.IsValid)
            {
                try
                {
                    // Insert here a code to update the item in your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            else
                ViewData["EditError"] = "Please, correct all errors.";
            return PartialView("_GridView1Partial", model);
        }
        [HttpPost, ValidateInput(false)]
        public ActionResult GridView1PartialDelete(System.Int32 acappCapp)
        {
            var model = new object[0];
            if (acappCapp >= 0)
            {
                try
                {
                    // Insert here a code to delete the item from your model
                }
                catch (Exception e)
                {
                    ViewData["EditError"] = e.Message;
                }
            }
            return PartialView("_GridView1Partial", model);
        }
    }
}
