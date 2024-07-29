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
            var respuesta = peliculaM.NuevaPelicula(movie);

            if (respuesta)
            {
                ViewBag.msj = "Pelicula registrada";
                return  RedirectToAction("RegistroPelicula", "Pelicula");
            }
            else
            {
                ViewBag.msj = "Pelicula no registrada, revisar informacion";
                return View();
            }
           
        }




        public ActionResult ConsultaPelicula() {

            var respuesta = peliculaM.ConsultarPeli();
            return View(respuesta);
        }





    }
}