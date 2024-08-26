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
        //estaba dando un errror y decia que eso era para interactuar con la bd
        //private readonly ApplicationDbContext _context;

        ReservaModel ReservaM = new ReservaModel();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Reservar()
        {
            return View(new Reserva());
        }

        [HttpPost]
        
        public ActionResult Reservar(Reserva model)
        {
            if (ModelState.IsValid)
            {
               // Lógica para extraer el precio de la base de datos según la sala
                //si es en 2 o 3d
                //var sala = _context.Salas.Find(model.IdSala);
                //if (sala == null)
                //{
                    //ModelState.AddModelError("IdSala", "Sala no encontrada.");
                    ////return View(model);
                //}

                //model.Precio = sala.Precio; 

             
                if (model.FechaHora < DateTime.Now)
                {
                    ModelState.AddModelError("FechaHora", "La fecha y hora no pueden ser anteriores a la actual.");
                    return View(model);
                }

                
                TempData["Success"] = "Reserva realizada exitosamente.";
                return RedirectToAction("Confirmacion");
            }

            return View(model);
        }

        public ActionResult Confirmacion()
        {
            return View();
        }
    }

}