using proyectoPA.Models;
using proyectoPA.Entidades;
using proyectoPA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

		public ActionResult Perfil()
		{
			return View();
		}

	}
}
