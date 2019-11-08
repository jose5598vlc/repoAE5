using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api.Models
{
    public class Usuario
    {

        public Usuario(int idUsuario, string Nombre, string Apellidos, string Email, string Edad)
        {
            this.idUsuario = idUsuario;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Email = Email;
            this.Edad = Edad;
        }

        public int idUsuario { get; set; }

        public string Nombre { get; set; }

        public string Apellidos { get; set; }

        public string Email { get; set; }

        public string Edad { get; set; }
    }

    
}