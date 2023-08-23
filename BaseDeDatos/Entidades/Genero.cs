using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.Entidades
{
    public class Genero
    {
        [Key]
        public int IdGenero { get; set; } //01 - 02 - 03 ...
        public string TipoGenero { get; set; } //Shonen, Spokon, Seinen

        [ForeignKey("Serie")]
        public Serie series{ get; set; }
    }
}
