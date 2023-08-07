using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.Entidades
{
    public class Publico
    {
        [Key]
        public int IdPublico { get; set; } //IDPUBLICO 1
        public bool Niños { get; set; } //No
        public bool Jovenes { get; set; } //Si
        public bool Adultos { get; set; } //No

    }
}
