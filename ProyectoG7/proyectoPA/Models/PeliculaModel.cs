using proyectoPA.BaseDatos;
using proyectoPA.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
namespace proyectoPA.Models
{
    public class PeliculaModel
    {

        public bool NuevaPelicula(Pelicula movie)
        {

            var rowsAffected = 0;

            var tabla = new tPelicula();
            tabla.titulo = movie.Titulo;
            tabla.duracion = movie.Duracion;
            tabla.director = movie.Director;
            tabla.sinopsis = movie.Sinopsis;
            tabla.fecha_estreno = movie.Fecha_estreno;
            tabla.clasificacion = movie.Clasificacion;
            tabla.poster_url = movie.Poster_Url;

            using (var context = new CINE_DBEntities())
            {
                context.tPelicula.Add(tabla);
                rowsAffected = context.SaveChanges();
            }

            return (rowsAffected > 0 ? true : false);


        }

        public List<tPelicula> ConsultarPeli()
        {
            using (var context = new CINE_DBEntities())
            {
                int ConsecutivoSesion = int.Parse(HttpContext.Current.Session["ConsecutivoUsuario"].ToString());

                return (from x in context.tPelicula
                        where x.id_pelicula != ConsecutivoSesion
                        select x).ToList();
            }







        }
    }}
