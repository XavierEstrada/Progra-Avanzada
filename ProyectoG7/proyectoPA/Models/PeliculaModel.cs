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

            var tablaP = new tPelicula();
            tablaP.titulo = movie.Titulo;
            tablaP.duracion = movie.Duracion;
            tablaP.director = movie.Director;
            tablaP.sinopsis = movie.Sinopsis;
            tablaP.fecha_estreno = movie.Fecha_estreno;
            tablaP.clasificacion = movie.Clasificacion;
            tablaP.poster_url = movie.Poster_Url;

            using (var context = new CINE_DBEntities())
            {
                context.tPelicula.Add(tablaP);
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
