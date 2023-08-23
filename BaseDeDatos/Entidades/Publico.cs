using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BaseDeDatos.Entidades
{
    public class Publico
    {
        [Key]
        public int IdPublico { get; set; } //IDPUBLICO 1
        public string Niños { get; set; } //N
        public string Jovenes {get; set; }
        public string Adultos { get; set; }
        //public bool Niños { get; set; } //No
        //public bool Jovenes { get; set; } //Si
        //public bool Adultos { get; set; } //No

    }
}
