using BIBLIOTECA.MODELDB;
using BIBLIOTECA.SuiteClases.clsTools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Script.Serialization;

namespace BIBLIOTECA.Controllers
{
    public class ViajeClienteController : ApiController
    {
        public IEnumerable<viajecliente> lstAcepc { get; set; }
        AcEntities db = new AcEntities();
        // GET: api/Empresa
        [HttpGet]
        public IEnumerable<viajecliente> GetList()
        {
         
            JavaScriptSerializer js = new JavaScriptSerializer();
            AcEntities ctx = new AcEntities();

            lstAcepc = db.viajecliente.ToList();

            return lstAcepc;

        }

        // GET: api/Empresa/5
        public string Get(int id)
        {
            // GET: api/Empresa
            
            return "value";
        }

        // POST: api/Empresa
       
        public HttpResponseMessage PostValue(viajecliente a)
        {
            AcEntities db = new AcEntities();
            viajecliente item = a;
            var model = db.viajecliente;
            dynamic response = null;
            try
            {

                if (ModelState.IsValid)
                {
                    var loItem = model.OrderByDescending(e => e.id).First();
                    if (loItem == null) loItem = new viajecliente();

                    item.id = clsTools.acserObtenerID("viajecliente", "id", db);
                    model.Add(item);
                    db.SaveChanges();
                    response = Request.CreateResponse<string>(HttpStatusCode.Accepted, item.id.ToString());
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = item.id.ToString() }));
                    
                }
            } catch ( Exception e){

            }
            return response;
        }
        // PUT: api/Empresa/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Empresa/5
        public void Delete(int id)
        {
        }
    }
}
