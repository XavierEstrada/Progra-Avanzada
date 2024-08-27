using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoPA.ViewModels
{
    public class UsuarioViewModel
    {
        public int IdUsuario { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Email { get; set; }
        public string NombreRol { get; set; }
    }
}