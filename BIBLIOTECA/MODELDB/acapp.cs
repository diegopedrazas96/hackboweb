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
    
    public partial class acapp
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public acapp()
        {
            this.acaxp = new HashSet<acaxp>();
            this.aclog = new HashSet<aclog>();
        }
    
        public int acappCapp { get; set; }
        public string acappDesc { get; set; }
        public int acappCmod { get; set; }
        public int acappTapp { get; set; }
        public string acappUrlx { get; set; }
        public string acappCtrl { get; set; }
        public int acappNord { get; set; }
        public int acappVisi { get; set; }
        public int acappeGra { get; set; }
        public int acappeEli { get; set; }
        public int acappeAct { get; set; }
        public int acappeBus { get; set; }
        public int acappStat { get; set; }
        public int acappRide { get; set; }
    
        public virtual accon accon { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<acaxp> acaxp { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<aclog> aclog { get; set; }
        public virtual acmod acmod { get; set; }
    }
}
