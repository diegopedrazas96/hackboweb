using BIBLIOTECA.MODELDB;
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
    public class EmpresaController : ApiController
    {
        public IEnumerable<acepc> lstAcepc { get; set; }
        AcEntities db = new AcEntities();
        // GET: api/Empresa
        [HttpGet]
        public IEnumerable<acepc> GetList()
        {
         
            JavaScriptSerializer js = new JavaScriptSerializer();
            AcEntities ctx = new AcEntities();

            lstAcepc = db.acepc.Where(a => a.acepcStat == 0).ToList();

            return lstAcepc;

        }

        // GET: api/Empresa/5
        public string Get(int id)
        {
            // GET: api/Empresa
            
            return "value";
        }

        // POST: api/Empresa
        public void Post([FromBody]string value)
        {
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
