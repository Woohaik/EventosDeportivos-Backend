//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Data.DBMODELS
{
    using System;
    using System.Collections.Generic;
    
    public partial class reservations
    {
        public int reservarionid { get; set; }
        public int customersid { get; set; }
        public int eventsid { get; set; }
        public Nullable<int> cantidad { get; set; }
    
        public virtual customers customers { get; set; }
        public virtual events events { get; set; }
    }
}