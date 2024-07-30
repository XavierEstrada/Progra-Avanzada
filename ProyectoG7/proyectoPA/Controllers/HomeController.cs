using proyectoPA.Models;
using proyectoPA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace proyectoPA.Controllers
{
    public class HomeController : Controller
    {

        UsuarioModel usuarioU = new UsuarioModel();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult InicioSesion()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registro(Usuario user)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    bool respuesta = usuarioU.RegistraUsuario(user);
                    if (respuesta)
                    {
                        ViewBag.Mensaje = "Usuario registrado con éxito.";
                        return RedirectToAction("InicioSesion", "Home");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Usuario no registrado. Por favor, revise la información proporcionada.";
                    }
                }
                catch (Exception ex)
                {
             
                    ViewBag.Mensaje = "Ocurrió un error al registrar el usuario: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Mensaje = "Por favor, corrija los errores en el formulario.";
            }

            return View();
        }   


        public ActionResult QuienesSomos()
            {
                return View();
            }

        }
}