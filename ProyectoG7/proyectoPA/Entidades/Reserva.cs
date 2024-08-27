using System;
using System.ComponentModel.DataAnnotations;

namespace proyectoPA.Entidades
{
    public class Reserva
    {
        
        public string Nombre { get; set; }

        
        public int IdSala { get; set; }

        
        public DateTime FechaHora { get; set; }

        
        public decimal Precio { get; set; }

        [Required(ErrorMessage = "La cantidad es obligatoria.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a 0.")]
        public int Cantidad_Entradas{ get; set; }

        public decimal MontoTotal => Precio * Cantidad_Entradas;
    }
}