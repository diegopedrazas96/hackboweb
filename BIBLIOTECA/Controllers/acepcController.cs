using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BIBLIOTECA.Controllers
{
    public class acepcController : Controller
    {
        // GET: acepc
        public ActionResult Index()
        {
            return View();
        }

        // GET: acepc/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: acepc/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: acepc/Create
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

        // GET: acepc/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: acepc/Edit/5
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

        // GET: acepc/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: acepc/Delete/5
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
