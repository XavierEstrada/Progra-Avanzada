using proyectoPA.BaseDatos;
using proyectoPA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proyectoPA.Models
{
    public class PeliculaModel
    {
        // Método para agregar una nueva película
        public bool NuevaPelicula(Pelicula movie)
        {
            var rowsAffected = 0;

            var tablaP = new tPelicula
            {
                titulo = movie.Titulo,
                duracion = movie.Duracion,
                director = movie.Director,
                sinopsis = movie.Sinopsis,
                fecha_estreno = movie.Fecha_estreno,
                clasificacion = movie.Clasificacion,
                poster_url = movie.Poster_Url
            };

            using (var context = new CINE_DBEntities())
            {
                context.tPelicula.Add(tablaP);
                rowsAffected = context.SaveChanges();
            }

            return rowsAffected > 0;
        }

        // Método para consultar todas las películas
        public List<tPelicula> ConsultarPeli()
        {
            using (var context = new CINE_DBEntities())
            {
                return context.tPelicula.ToList();
            }
        }

        // Método para eliminar una película por ID
        public bool EliminarPelicula(int id)
        {
            try
            {
                using (var context = new CINE_DBEntities())
                {
                    // Encuentra la película por su ID en la tabla tPelicula
                    var pelicula = context.tPelicula.Find(id);
                    if (pelicula != null)
                    {
                        context.tPelicula.Remove(pelicula);
                        context.SaveChanges();
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                // Manejo de errores (opcionalmente puedes loguear el error)
                System.Diagnostics.Debug.WriteLine("Error en EliminarPelicula: " + ex.ToString());
                return false;
            }
        }
    }
}
