﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class CINE_DBEntities : DbContext
    {
        public CINE_DBEntities()
            : base("name=CINE_DBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<tCompra> tCompra { get; set; }
        public virtual DbSet<tErrorLog> tErrorLog { get; set; }
        public virtual DbSet<tFuncion> tFuncion { get; set; }
        public virtual DbSet<tGenero> tGenero { get; set; }
        public virtual DbSet<tPelicula> tPelicula { get; set; }
        public virtual DbSet<tPelicula_Genero> tPelicula_Genero { get; set; }
        public virtual DbSet<tReserva> tReserva { get; set; }
        public virtual DbSet<tRoles> tRoles { get; set; }
        public virtual DbSet<tSala> tSala { get; set; }
        public virtual DbSet<tUsuario> tUsuario { get; set; }
    }
}
