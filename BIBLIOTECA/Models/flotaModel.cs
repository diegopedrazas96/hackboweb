using BIBLIOTECA.MODELDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BIBLIOTECA.Models
{
    public class flotaModel
    {

        private AcEntities loDb = null;
        public flotas flota { get; set; }
        public IEnumerable<acepc> lstAcepc { get; set; }

        public IEnumerable<accon> lstAccon { get; set; }
        public IEnumerable<flotas> flotas { get; set; }
        public DataTable lstAcepcAsig { get; set; }
        public flotaModel(AcEntities _db)
        {
            loDb = _db;
            flota = new flotas();
            flotas = loDb.flotas.ToList();
            lstAcepc = loDb.acepc.Where(a => a.acepcStat == 0).ToList();

            lstAccon = loDb.accon.Where(a => a.acconPref == 4 && a.acconCorr >0).ToList();
        }
     
    }
}