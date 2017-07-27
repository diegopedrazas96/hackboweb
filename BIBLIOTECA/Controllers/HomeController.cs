using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BIBLIOTECA.MODELDB;
using System.Data;
using BIBLIOTECA.SuiteClases.ClsAC;

namespace BIBLIOTECA.Controllers
{
    public class HomeController : Controller
    {
        public DataTable listaAPP { get; set; }
        public ActionResult Index()
        {
            string lsCusr = (Session["Usuario"] == null ? "adm" : Convert.ToString(Session["Usuario"]));
                int liCepc = (Session["xCepc"] == null ? 1 : Convert.ToInt32(Session["xCepc"]));
            using (AcEntities ac = new AcEntities())
            {

                listaAPP = clsAcapp.acappObtenerListaAsig(liCepc, lsCusr, ac);
                ViewBag.Lista= listaAPP.AsEnumerable();
            }
            if (Session["Usuario"] == null)
            {

                return RedirectToAction("Login", "Home");
            }
            else
            {

                return View();
            }

        }
        public ActionResult Login()
        {
            if (Session["Usuario"] !=null)
            {

                return RedirectToAction("Index", "Home");
            }else
            {

                return View();
            }
        
        }
        [HttpPost]
        public ActionResult Login(acusr acusr)
        {
            ModelState.Clear();
            if (ModelState.IsValid)
            {
                using (AcEntities ac = new AcEntities())
                {
                    var login = ac.acusr.Where(a => a.acusrCusr.Equals(acusr.acusrCusr) && a.acusrPass.Equals(acusr.acusrPass)).FirstOrDefault();
                    if (login != null)
                    {
                        Session["Usuario"] = login.acusrCusr;
                        Session["xCepc"] = 1;
                        return RedirectToAction("Index", "Home");
                    }
                    else{
                        ViewBag.Error = "Página no encontrada";
                    }
                }

            }

            return View();
        }
        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login","Home");

        }
        public object CargarMenu()
        {
            return null ;
        }
    }
}