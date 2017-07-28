using BIBLIOTECA.MODELDB;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;

namespace BIBLIOTECA.Controllers
{
    public class EstadoAsientoController : ApiController
    {
        public IEnumerable<estadoasientos> lstAcepc { get; set; }
        AcEntities db = new AcEntities();
        // GET: api/Empresa
        [HttpGet]
        public IEnumerable<estadoasientos> GetList()
        {
         
            JavaScriptSerializer js = new JavaScriptSerializer();
            AcEntities ctx = new AcEntities();

            lstAcepc = db.estadoasientos.ToList();

            return lstAcepc;

        }

       
        public HttpResponseMessage PostValue(estadoasientos a)
        {
            
            estadoasientos item = a;
            var model = db.estadoasientos;

            var modelItem = model.FirstOrDefault(it => it.Id == item.Id);
            if (modelItem != null)
            {
                modelItem.Estado = item.Estado;
                db.Entry(modelItem).State = EntityState.Modified;
                db.SaveChanges();
            }
            dynamic response = Request.CreateResponse<string>(HttpStatusCode.Accepted, item.Id.ToString());
            response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = item.Id.ToString() }));
            return response;
        }
        // GET: api/Empresa/5
        public string Get(int id)
        {
            // GET: api/Empresa
            
            return "value";
        }

        // POST: api/Empresa
       

        // PUT: api/Empresa/5
        public void Put(int id)
        {
   
        }

        // DELETE: api/Empresa/5
        public void Delete(int id)
        {
        }
    }
}
