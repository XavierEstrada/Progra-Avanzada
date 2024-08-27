using System.Collections.Generic;
using System.Web.Mvc;

namespace proyectoPA.Controllers
{
    public class ReservaController : Controller
    {
        //// Acción para mostrar la página de reserva de película
        //public ActionResult ReservarPelicula(int idPelicula)
        //{
        //    // Pasamos el ID de la película a la vista
        //    ViewBag.PeliculaId = idPelicula;

        //    // Lista de salas con sus precios
        //    ViewBag.Salas = new List<SelectListItem>
        //    {
        //        new SelectListItem { Text = "Sala Normal", Value = "2500" },
        //        new SelectListItem { Text = "Sala IMAX", Value = "5000" },
        //        new SelectListItem { Text = "Sala VIP", Value = "7000" }
        //    };

        //    return View();
        //}

        //// Acción para manejar el post del formulario de reserva
        //[HttpPost]
        //public ActionResult ReservarPelicula(int cantidadEntradas, int salaSeleccionada)
        //{
        //    // Lógica simple para manejar la reserva (puedes expandirla según necesites)
        //    decimal total = cantidadEntradas * salaSeleccionada;

        //    // Mostrar un mensaje de éxito
        //    TempData["Mensaje"] = "Se ha comprado exitosamente. Total: " + total.ToString("C");

        //    // Redirigir a una vista de confirmación o a la página principal
        //    return RedirectToAction("Confirmacion");
        //}

        //// Acción para mostrar la confirmación de la reserva
        //public ActionResult Confirmacion()
        //{
        //    ViewBag.Mensaje = TempData["Mensaje"];
        //    return View();
        //}
    }
}
