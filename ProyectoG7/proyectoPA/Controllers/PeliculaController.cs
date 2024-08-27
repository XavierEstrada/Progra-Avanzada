using proyectoPA.Models;
using proyectoPA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoPA.Controllers
{
    public class PeliculaController : Controller
    {

        PeliculaModel peliculaM = new PeliculaModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult RegistroPelicula()
        {
            return View();
        }

        [HttpPost]
        public ActionResult RegistroPelicula(Pelicula movie)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var respuesta = peliculaM.NuevaPelicula(movie);
                    if (respuesta)
                    {
                        // Redirige a la acción ConsultaPelicula si la película se registró correctamente
                        return RedirectToAction("ConsultaPelicula", "Pelicula");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Película no registrada. Por favor, revise la información proporcionada.";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Ocurrió un error al registrar la película: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Mensaje = "Por favor, corrija los errores en el formulario.";
            }

            // Si no es una solicitud Ajax, vuelve a mostrar el formulario con los errores
            return View(movie);
        }

        // Acción para eliminar una pelicula
        [HttpPost]
        public JsonResult EliminarPelicula(int id)
        {
            bool exito = peliculaM.EliminarPelicula(id);
            return Json(new { success = exito });
        }

        public ActionResult ConsultaPelicula() {

            var respuesta = peliculaM.ConsultarPeli();
            return View(respuesta);
        }

        [HttpGet]
        public ActionResult Cartelera()
        {
            return View();
        }




    }
}