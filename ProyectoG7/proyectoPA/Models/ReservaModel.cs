using System;
using System.Collections.Generic;
using System.Linq;
using proyectoPA.BaseDatos;
using proyectoPA.Entidades;

namespace proyectoPA.Models
{
    public class ReservaModel
    {
        //    // Obtener detalles de la película usando LINQ
        //    public Pelicula ObtenerDetallesPelicula(int idPelicula)
        //    {
        //        using (var context = new CINE_DBEntities())
        //        {
        //            return context.tPelicula
        //                .Where(p => p.id_pelicula == idPelicula)
        //                .Select(p => new Pelicula
        //                {
        //                    IdPelicula = p.id_pelicula,
        //                    Titulo = p.titulo,
        //                    Duracion = p.duracion,
        //                    Director = p.director,
        //                    Clasificacion = p.clasificacion,
        //                    Poster_Url = p.poster_url
        //                })
        //                .FirstOrDefault();
        //        }
        //    }
        //    public class Sala
        //    {
        //        public int IdSala { get; set; }
        //        public string Nombre { get; set; }
        //        public decimal Precio { get; set; }
        //    }

        //    public static class SalaRepository
        //    {
        //        public static List<Sala> ObtenerSalas()
        //        {
        //            return new List<Sala>
        //        {
        //            new Sala { IdSala = 1, Nombre = "Sala Normal", Precio = 2500 },
        //            new Sala { IdSala = 2, Nombre = "Sala IMAX", Precio = 5000 },
        //            new Sala { IdSala = 3, Nombre = "Sala VIP", Precio = 7000 }
        //        };
        //        }
        //    }
        //}
    }
}
