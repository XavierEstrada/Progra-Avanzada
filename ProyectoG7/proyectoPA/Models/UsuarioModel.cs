using proyectoPA.BaseDatos;
using proyectoPA.Entidades;
using System.Linq;

namespace proyectoPA.Models
{
    public class UsuarioModel
    {
        public bool RegistraUsuario(Usuario user)
        {


            var rowsAffected = 0;

            var tablaU = new tUsuario();
            tablaU.nombre = user.Nombre;
            tablaU.identificacion = user.Identificacion;
            tablaU.email = user.Email;
            tablaU.contrasenna = user.Contrasenna;
            tablaU.idRol = 2;

            using (var context = new CINE_DBEntities())
            {
                context.tUsuario.Add(tablaU);
                rowsAffected = context.SaveChanges();
            }

            return (rowsAffected > 0 ? true : false);


        }



        public Usuario ValidarUsuario(string email, string contrasenna)
        {
            using (var context = new CINE_DBEntities())
            {
                var usuario = context.tUsuario
                    .FirstOrDefault(u => u.email== email && u.contrasenna == contrasenna);

                if (usuario != null)
                {
                    return new Usuario
                    {
                        Id_usuario = usuario.id_usuario,
                        Nombre = usuario.nombre,
                        Identificacion = usuario.identificacion,
                        Email = usuario.email,
                        Contrasenna = usuario.contrasenna,
                        IdRol = (byte)usuario.idRol
                    };
                }
                return null;
            }
        }
    }
}
