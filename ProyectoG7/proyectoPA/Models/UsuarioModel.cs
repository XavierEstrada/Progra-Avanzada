using proyectoPA.BaseDatos;
using proyectoPA.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace proyectoPA.Models
{
    public class UsuarioModel
    {

        public bool RegistraUsuario(Usuario user) {


            var rowsAffected = 0;

            var tablaU = new tUsuario();
            tablaU.nombre = user.Nombre;
            tablaU.identificacion = user.Identificacion;
            tablaU.email = user.Email;
            tablaU.contrasenna = user.Contrasenna;
            user.IdRol = 2;

            using (var context = new CINE_DBEntities())
            {
                context.tUsuario.Add(tablaU);
                rowsAffected = context.SaveChanges();
            }

            return (rowsAffected > 0 ? true : false);


        }



    }
}