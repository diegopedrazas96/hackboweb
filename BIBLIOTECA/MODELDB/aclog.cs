//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BIBLIOTECA.MODELDB
{
    using System;
    using System.Collections.Generic;
    
    public partial class aclog
    {
        public int aclogRide { get; set; }
        public string aclogCusr { get; set; }
        public int aclogClgn { get; set; }
        public int aclogCmod { get; set; }
        public int aclogCapp { get; set; }
        public int aclogCevn { get; set; }
        public System.DateTime aclogFsys { get; set; }
        public int aclogRida { get; set; }
    
        public virtual acapp acapp { get; set; }
        public virtual accon accon { get; set; }
        public virtual aclgn aclgn { get; set; }
        public virtual acmod acmod { get; set; }
        public virtual acusr acusr { get; set; }
    }
}