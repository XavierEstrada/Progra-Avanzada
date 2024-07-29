using System;

namespace proyectoPA.Entidades
{
    //Entidad-Objeto
    public class Pelicula
    {

        //Atributos

        public int IdPelicula { get; set; }

        public string Titulo { get; set; }

        public int Duracion { get; set; }

        public string Director { get; set; }

        public string Sinopsis { get; set; }

        public DateTime Fecha_estreno { get; set; }

        public string Clasificacion { get; set; }

        public string Poster_Url { get; set; }
    }
}
