using System;

namespace proyectoPA.Entidades
{
    public class Usuario
    {

        public int Id_usuario { get; set; }
        public string Nombre { get; set; }
        public string Identificacion { get; set; }
        public string Email {  get; set; }
        public string Contrasenna { get; set; }
        public byte IdRol {  get; set; }



    }
}