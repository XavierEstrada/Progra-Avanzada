//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace proyectoPA.BaseDatos
{
    using System;
    using System.Collections.Generic;
    
    public partial class tPelicula
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tPelicula()
        {
            this.tFuncion = new HashSet<tFuncion>();
            this.tPelicula_Genero = new HashSet<tPelicula_Genero>();
        }
    
        public int id_pelicula { get; set; }
        public string titulo { get; set; }
        public int duracion { get; set; }
        public string director { get; set; }
        public string sinopsis { get; set; }
        public System.DateTime fecha_estreno { get; set; }
        public string clasificacion { get; set; }
        public string poster_url { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tFuncion> tFuncion { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tPelicula_Genero> tPelicula_Genero { get; set; }
    }
}
