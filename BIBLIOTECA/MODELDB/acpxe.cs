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
    
    public partial class acpxe
    {
        public int acpxeCpxe { get; set; }
        public int acpxeCprf { get; set; }
        public int acpxeCepc { get; set; }
        public int acpxeStat { get; set; }
        public int acpxeRide { get; set; }
    
        public virtual acepc acepc { get; set; }
        public virtual acprf acprf { get; set; }
    }
}
