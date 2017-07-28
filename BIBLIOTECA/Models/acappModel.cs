using BIBLIOTECA.MODELDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BIBLIOTECA.Models
{
    public class acappModel
    {
        private AcEntities loDb = null;
        public acapp Acapp { get; set; }
        public IEnumerable<acapp> lstAcapp { get; set; }
        public IEnumerable<acmod> lstAcmod { get; set; }
        public IEnumerable<accon> lstTipo { get; set; }
        public acappModel(AcEntities _db)
        {
            loDb = _db;
            Acapp = new acapp();
            lstAcapp = (from lo in _db.acapp
                        where lo.acappStat == 0
                        orderby lo.acappCmod, lo.acappTapp, lo.acappNord
                        select lo).ToList();

            //lstAcapp = loDb.acapps.Where(a => a.acappStat == 0).OrderBy(a=> a.acappCmod).OrderBy(a => a.acappTapp).OrderBy(a => a.acappNord).ToList();
            lstAcmod = loDb.acmod.Where(a => a.acmodStat == 0).ToList();
            lstTipo = loDb.accon.Where(a => a.acconPref == 1 && a.acconCorr > 0).ToList();
        }
    }
}