using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Onigashimaxxx.Models
{
    public class Usuario
    {
        //'matiaserradorr@gmail.com' - '12345'
        public int IdUsuario { get; set; }
        public string Correo { get; set; }
        public string Contraseña { get; set; }
        public string ConfirmarContraseña { get; set; }
    }
}