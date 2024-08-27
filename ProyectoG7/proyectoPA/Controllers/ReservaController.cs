using System;
using proyectoPA.Models;
using proyectoPA.Entidades;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;



namespace proyectoPA.Controllers
{

    public class ReservaController : Controller
    {

        ReservaModel ReservaM = new ReservaModel();

        [HttpGet]
        public ActionResult ReservaPelicula()
        {
            return View();
        }

        [HttpGet]
        public ActionResult ReservaPelicula(int id)
        {
            var pelicula = reservaModel.ObtenerPeliculaPorId(id);
            if (pelicula == null)
            {
                return HttpNotFound();
            }

            // Crear un ViewModel para la vista
            var viewModel = new ReservaViewModel
            {
                Pelicula = pelicula,
                FechaSeleccionada = DateTime.Now.Date,
                Salas = ObtenerSalas() // Método para obtener la lista de salas
            };

            return View(viewModel);
        }

        [HttpPost]
        public ActionResult ReservaPelicula(ReservaViewModel model)
        {
            if (ModelState.IsValid)
            {
                var reserva = new Reserva
                {
                    Nombre = "Nombre del Usuario", // Reemplazar con el nombre del usuario autenticado
                    IdSala = model.IdSala,
                    FechaHora = model.FechaSeleccionada,
                    Precio = model.PrecioPorEntrada,
                    Cantidad_Entradas = model.CantidadEntradas
                };

                if (reservaModel.RegistrarReserva(reserva))
                {
                    // Redirigir o mostrar mensaje de éxito
                }
                else
                {
                    // Mostrar mensaje de error
                }
            }

            return View(model);
        }

        private SelectList ObtenerSalas()
        {
            // Método para obtener la lista de salas
            // Esto depende de cómo esté estructurada tu base de datos
            var salas = new List<SelectListItem>
            {
                new SelectListItem { Value = "1", Text = "Sala 1" },
                new SelectListItem { Value = "2", Text = "Sala 2" },
                // Agregar más salas aquí
            };

            return new SelectList(salas, "Value", "Text");
        }
    }

    //[HttpPost]
    //public ActionResult Reservar(Reserva model)
    //{
    //    if (ModelState.IsValid)
    //    {
    //        // Lógica para extraer el precio de la base de datos según la sala
    //        //si es en 2 o 3d
    //        //var sala = _context.Salas.Find(model.IdSala);
    //        //if (sala == null)
    //        //{
    //        //ModelState.AddModelError("IdSala", "Sala no encontrada.");
    //        ////return View(model);
    //        //}

    //        //model.Precio = sala.Precio; 


    //        if (model.FechaHora < DateTime.Now)
    //        {
    //            ModelState.AddModelError("FechaHora", "La fecha y hora no pueden ser anteriores a la actual.");
    //            return View(model);
    //        }


    //        TempData["Success"] = "Reserva realizada exitosamente.";
    //        return RedirectToAction("Confirmacion");
    //    }

    //    return View(model);
    //}

}
