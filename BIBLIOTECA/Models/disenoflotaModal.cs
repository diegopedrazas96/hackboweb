using BIBLIOTECA.MODELDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;

namespace BIBLIOTECA.Models
{
    public class disenoflotaModal
    {

        private AcEntities loDb = null;
        public disenoflota flota { get; set; }
        public List<flotas> flotas { get; set; }

        public IEnumerable<accon> tipos { get; set; }
        public IEnumerable<viajeflota> viajeflota { get; set; }
        public IEnumerable<disenoflota> disenoflotas { get; set; }
       
        public IEnumerable<acepc> empresa { get; set; }
        public DataTable lstAcepcAsig { get; set; }
        public disenoflotaModal(AcEntities _db)
        {
            loDb = _db;
            flota = new disenoflota();
            flotas = loDb.flotas.ToList();
            tipos = loDb.accon.Where(a => a.acconPref == 4 && a.acconCorr>=0).ToList();
            disenoflotas = loDb.disenoflota.Where(a => a.flotaId == 1).ToList();
            empresa = loDb.acepc.ToList();
        }
     
    }
}