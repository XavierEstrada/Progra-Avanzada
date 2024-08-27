using System;
using System.Web.Mvc;
using proyectoPA.Models;

namespace proyectoPA.Controllers
{
    public class ReservaController : Controller
    {
        private ReservaModel reservaModel = new ReservaModel();

        // Acción para mostrar los detalles de la película y el formulario de reserva
        public ActionResult ReservarPelicula(int idPelicula)
        {
            var pelicula = reservaModel.ObtenerDetallesPelicula(idPelicula);
            var salas = reservaModel.ObtenerSalas();

            if (pelicula == null)
            {
                return HttpNotFound();
            }

            ViewBag.Salas = new SelectList(salas, "IdSala", "Nombre");

            return View(pelicula);
        }

        // Acción para manejar la reserva
        [HttpPost]
        public ActionResult ReservarPelicula(int idPelicula, int idSala, DateTime fecha, int cantidadEntradas)
        {
            // Lógica para guardar la reserva en la base de datos
            reservaModel.RealizarReserva(idPelicula, idSala, fecha, cantidadEntradas);

            // Redirigir a una vista de confirmación o a otra acción
            return RedirectToAction("Index", "Home");
        }
    }
}
