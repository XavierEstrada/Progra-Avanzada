using proyectoPA.BaseDatos;
using proyectoPA.Entidades;
using proyectoPA.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace proyectoPA.Models
{
    public class UsuarioModel
    {

        // Metodo para registrar usuario
        public bool RegistraUsuario(Usuario user)
        {
            var rowsAffected = 0;

            var tablaU = new tUsuario();
            tablaU.nombre = user.Nombre;
            tablaU.identificacion = user.Identificacion;
            tablaU.email = user.Email;
            tablaU.contrasenna = user.Contrasenna;
            tablaU.idRol = 2;

            try
            {
                using (var context = new CINE_DBEntities())
                {
                    context.tUsuario.Add(tablaU);
                    rowsAffected = context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Registrar el error en la tabla tErrorLog
                using (var context = new CINE_DBEntities())
                {
                    var errorLog = new tErrorLog
                    {
                        ErrorMessage = ex.Message,
                        ErrorDateTime = DateTime.Now,
                        UserID = user.Id_usuario // Asumiendo que user.Id_usuario existe y está relacionado con el error
                    };

                    context.tErrorLog.Add(errorLog);
                    context.SaveChanges(); // Guardar el registro del error
                }

                return false; // Retornar false ya que ocurrió un error
            }

            return rowsAffected > 0;
        }





        //Validacion de usuario
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

        //Metodo para consultar usuario y traerse el nombre del rol tambien
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

        // Método para eliminar usuario por id
        public bool EliminarUsuario(int id)
        {
            try
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
            catch (Exception ex)
            {
                // Registrar el error en la tabla tErrorLog
                using (var context = new CINE_DBEntities())
                {
                    var errorLog = new tErrorLog
                    {
                        ErrorMessage = ex.Message,
                        ErrorDateTime = DateTime.Now,
                        UserID = id // Asumimos que el ID del usuario se asocia con el error
                    };

                    context.tErrorLog.Add(errorLog);
                    context.SaveChanges(); // Guardar el registro del error
                }

                return false; // Retornar false ya que ocurrió un error
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
