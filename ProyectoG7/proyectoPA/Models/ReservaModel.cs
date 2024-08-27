using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using proyectoPA.Entidades;

namespace proyectoPA.Models
{
    public class ReservaModel
    {
        private string connectionString = "CINE_DBEntities";

        public Pelicula ObtenerDetallesPelicula(int movieID)
        {
            using (var context = new SqlConnection(connectionString))
            {
                context.Open();
                var command = new SqlCommand("sp_Reserva", context)
                {
                    CommandType = System.Data.CommandType.StoredProcedure
                };
                command.Parameters.AddWithValue("@MovieID", movieID);

                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Pelicula
                        {
                            IdPelicula = Convert.ToInt32(reader["IdPelicula"]),
                            Titulo = reader["Titulo"].ToString(),
                            Duracion = Convert.ToInt32(reader["Duracion"]),
                            Director = reader["Director"].ToString(),
                            Clasificacion = reader["Clasificacion"].ToString(),
                            Poster_Url = reader["Poster_Url"].ToString()
                        };
                    }
                }
            }
            return null;
        }

        public List<Sala> ObtenerSalas()
        {
            List<Sala> salas = new List<Sala>();
            using (var context = new SqlConnection(connectionString))
            {
                context.Open();
                var command = new SqlCommand("SELECT id_sala, nombre FROM tSala", context);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        salas.Add(new Sala
                        {
                            IdSala = Convert.ToInt32(reader["id_sala"]),
                            Nombre = reader["nombre"].ToString()
                        });
                    }
                }
            }
            return salas;
        }

        public void RealizarReserva(int idPelicula, int idSala, DateTime fecha, int cantidadEntradas)
        {
            using (var context = new SqlConnection(connectionString))
            {
                context.Open();
                var command = new SqlCommand("INSERT INTO tReserva (id_usuario, id_funcion, cantidad_entradas, fecha_reserva, total_pagado) VALUES (@id_usuario, @id_funcion, @cantidad_entradas, @fecha_reserva, @total_pagado)", context);

                // Aquí debes obtener el id_usuario de la sesión actual, por ahora lo dejamos como un ejemplo
                int idUsuario = 1; // Cambia esto según tu lógica de usuario

                command.Parameters.AddWithValue("@id_usuario", idUsuario);
                command.Parameters.AddWithValue("@id_funcion", idSala); // Deberás obtener el id_funcion real
                command.Parameters.AddWithValue("@cantidad_entradas", cantidadEntradas);
                command.Parameters.AddWithValue("@fecha_reserva", fecha);
                command.Parameters.AddWithValue("@total_pagado", 100 * cantidadEntradas); // Ajusta el cálculo según tu lógica

                command.ExecuteNonQuery();
            }
        }
    }

    public class Sala
    {
        public int IdSala { get; set; }
        public string Nombre { get; set; }
    }
}
