using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BIBLIOTECA.MODELDB;
using BIBLIOTECA.SuiteClases.clsTools;
namespace BIBLIOTECA.Controllers
{
    public class ClientesController : ApiController
    {
        // GET: api/Clientes
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Clientes/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Clientes
        public HttpResponseMessage PostValue(clientes a)
        {

            AcEntities db = new AcEntities();
            clientes item = a;
            var model = db.clientes;
            dynamic response = null;
            try
            {

                if (ModelState.IsValid)
                {
                    var loItem = model.OrderByDescending(e => e.Id).First();
                    if (loItem == null) loItem = new clientes();

                    item.Id = clsTools.acserObtenerID("clientes", "Id", db);
                    model.Add(item);
                    db.SaveChanges();
                    response = Request.CreateResponse<string>(HttpStatusCode.Accepted, item.Id.ToString());
                    response.Headers.Location = new Uri(Url.Link("DefaultApi", new { id = item.Id.ToString() }));

                }
            }
            catch (Exception e)
            {

            }
            return response;
        }

        // PUT: api/Clientes/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Clientes/5
        public void Delete(int id)
        {
        }
    }
}
