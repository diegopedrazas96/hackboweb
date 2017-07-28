using BIBLIOTECA.MODELDB;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;


namespace BIBLIOTECA.Models
{
    public class acepcModel
    {

        private AcEntities loDb = null;
        public acepc Acepc { get; set; }
        public IEnumerable<accon> lstAccon { get; set; }
        public IEnumerable<acepc> lstAcepc { get; set; }
        public DataTable lstAcepcAsig { get; set; }
        public acepcModel(AcEntities _db)
        {
            loDb = _db;
            Acepc = new acepc();
            lstAccon = loDb.accon.Where(a => a.acconPref == 2 && a.acconCorr > 0).ToList();
            lstAcepc = loDb.acepc.Where(a => a.acepcStat == 0).ToList();
        }
        public acepcModel(int acepcCepc, AcEntities _db)
        {
            loDb = _db;

            Acepc = (acepcCepc > 0 ? loDb.acepc.Find(acepcCepc) : new acepc());
            lstAccon = loDb.accon.Where(a => a.acconPref == 2 && a.acconCorr > 0).ToList();
            lstAcepc = loDb.acepc.Where(a => a.acepcStat == 0).ToList();
            //lstAcepcAsig = clsAC.clsAcprf.acepcObtenerLista(acepcCepc, _db);
        }
    }
}