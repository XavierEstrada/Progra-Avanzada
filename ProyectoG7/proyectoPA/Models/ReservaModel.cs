using proyectoPA.BaseDatos;
using proyectoPA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proyectoPA.Models
{
    public class ReservaModel
    {
        // Obtiene una lista de todas las películas disponibles
        public List<Pelicula> ObtenerPeliculas()
        {
            using (var context = new CINE_DBEntities())
            {
                return context.tPelicula.ToList();
            }
        }

        // Obtiene los detalles de una película específica
        public Pelicula ObtenerPeliculaPorId(int id)
        {
            using (var context = new CINE_DBEntities())
            {
                return context.tPelicula.FirstOrDefault(p => p.id_pelicula == id);
            }
        }

        //// Método para registrar una reserva
        //public bool RegistrarReserva(Reserva reserva)
        //{
        //    var rowsAffected = 0;
        //    var tablaR = new tReserva
        //    {
        //        Nombre = reserva.Nombre,
        //        IdSala = reserva.IdSala,
        //        FechaHora = reserva.FechaHora,
        //        Precio = reserva.Precio,
        //        CantidadEntradas = reserva.Cantidad_Entradas
        //    };

        //    using (var context = new CINE_DBEntities())
        //    {
        //        context.tReserva.Add(tablaR);
        //        rowsAffected = context.SaveChanges();
        //    }

        //    return rowsAffected > 0;
        //}
    }
}
