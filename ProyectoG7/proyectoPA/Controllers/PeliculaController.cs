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
                        ViewBag.Mensaje = "Pelicula registrada con éxito.";
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Pelicula no registrada. Por favor, revise la información proporcionada.";
                    }
                }
                catch (Exception ex)
                {
                    // Manejo de errores
                    ViewBag.Mensaje = "Ocurrió un error al registrar la película: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Mensaje = "Por favor, corrija los errores en el formulario.";
            }

            return View(movie);
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