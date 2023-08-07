using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.Entidades
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; }
        public string TipoGenero { get; set; } //Shonen, Spokon, Seinen
    }
}
