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
            // Configurar el layout basado en el rol del usuario
            ConfigurarLayout();
            return View();
        }

        public ActionResult InicioSesion()
        {
            // Configurar el layout para la página de inicio de sesión
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
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
            ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
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
            ConfigurarLayout();
            return View();
        }

        private void ConfigurarLayout()
        {
   
            if (Session["UsuarioIdRol"] != null && Session["UsuarioIdRol"].ToString() == "1") // Rol de Administrador
            {
                ViewBag.Layout = "~/Views/Shared/_LayoutAdmin.cshtml";
            }
            else
            {
                ViewBag.Layout = "~/Views/Shared/_Layout.cshtml";
            }
        }
    }
}
