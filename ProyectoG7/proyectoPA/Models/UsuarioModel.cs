using proyectoPA.BaseDatos;
using proyectoPA.Entidades;
using proyectoPA.ViewModels;
using System.Collections.Generic;
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
                    .FirstOrDefault(u => u.email == email && u.contrasenna == contrasenna);

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


        public List<UsuarioViewModel> ConsultarUsuarios()
        {
            using (var context = new CINE_DBEntities())
            {
                var usuarios = from u in context.tUsuario
                               join r in context.tRoles on u.idRol equals r.idRol
                               select new UsuarioViewModel
                               {
                                   IdUsuario = u.id_usuario,
                                   Nombre = u.nombre,
                                   Identificacion = u.identificacion,
                                   Email = u.email,
                                   NombreRol = r.rolNombre
                               };

                return usuarios.ToList();
            }
        }

        public bool EliminarUsuario(int id)
        {
            using (var context = new CINE_DBEntities())
            {
                var usuario = context.tUsuario.Find(id);
                if (usuario != null)
                {
                    context.tUsuario.Remove(usuario);
                    var rowsAffected = context.SaveChanges();
                    return rowsAffected > 0;
                }
                return false;
            }
        }

        // Método para obtener un usuario por su ID
        public Usuario ObtenerUsuarioPorId(int id)
        {
            using (var context = new CINE_DBEntities())
            {
                var usuario = context.tUsuario.Find(id);
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

        // Método para actualizar un usuario
        public bool ActualizarUsuario(Usuario user)
        {
            using (var context = new CINE_DBEntities())
            {
                var usuario = context.tUsuario.Find(user.Id_usuario);
                if (usuario != null)
                {
                    usuario.nombre = user.Nombre;
                    usuario.identificacion = user.Identificacion;
                    usuario.email = user.Email;
                    usuario.contrasenna = user.Contrasenna;
                    usuario.idRol = user.IdRol;

                    var rowsAffected = context.SaveChanges();
                    return rowsAffected > 0;
                }
                return false;
            }
        }
    }
}
