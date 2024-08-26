using proyectoPA.Models;
using proyectoPA.Entidades;
using System;
using System.Linq;
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

        public ActionResult CerrarSesion()
        {
            // Limpiar la sesión
            Session.Clear();

            // Redirigir al inicio
            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public ActionResult InicioSesion(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    Usuario user = usuarioU.ValidarUsuario(usuario.Email, usuario.Contrasenna);
                    if (user != null)
                    {
                        // Aquí puedes establecer una sesión y redirigir al usuario a la página principal
                        Session["Usuario"] = user.Nombre;
                        Session["UsuarioIdRol"] = user.IdRol;
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        ViewBag.Mensaje = "Correo electrónico o contraseña incorrectos.";
                    }
                }
                catch (Exception ex)
                {
                    ViewBag.Mensaje = "Ocurrió un error al intentar iniciar sesión: " + ex.Message;
                }
            }
            else
            {
                ViewBag.Mensaje = "Por favor, corrija los errores en el formulario.";
            }

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
		public ActionResult Perfil()
		{
			return View();
		}

	}
}
