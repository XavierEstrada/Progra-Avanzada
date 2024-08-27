using proyectoPA.Models;
using proyectoPA.Entidades;
using System.Web.Mvc;

namespace proyectoPA.Controllers
{
    public class UsuarioController : Controller
    {
        UsuarioModel usuarioC = new UsuarioModel();

        // Acción para consultar usuarios
        public ActionResult ConsultaUsuarios()
        {
            var respuesta = usuarioC.ConsultarUsuarios();
            return View(respuesta);
        }

        // Acción para eliminar un usuario
        [HttpPost]
        public JsonResult EliminarUsuario(int id)
        {
            bool exito = usuarioC.EliminarUsuario(id);
            return Json(new { success = exito });
        }


        // Acción para cargar la vista de actualización con los datos del usuario
        public ActionResult ActualizarUsuario(int id)
        {
            // Obtiene el usuario por ID
            Usuario usuario = usuarioC.ObtenerUsuarioPorId(id);
            if (usuario == null)
            {
                return HttpNotFound();
            }
            return View(usuario);
        }

        // Acción para manejar la actualización del usuario
        [HttpPost]
        public ActionResult ActualizarUsuario(Usuario usuario)
        {
            if (ModelState.IsValid)
            {
                bool exito = usuarioC.ActualizarUsuario(usuario);
                if (exito)
                {
                    return RedirectToAction("ConsultaUsuarios"); // Redirige a la vista de consulta
                }
                else
                {
                    ModelState.AddModelError("", "Error al actualizar el usuario.");
                }
            }
            return View(usuario);
        }

        public ActionResult Perfil()
        {
            return View();
        }
    }
}
