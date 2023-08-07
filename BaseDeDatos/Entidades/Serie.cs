using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseDeDatos.Entidades
{
    public class Series
    {
        [Key]
        public int IdSerie { get; set; } //IDSERIE 1
        public string NombreSerie { get; set; } //DB
        public int AñoCreacion { get; set; } //1986

        [ForeignKey("IdPersonaje")]
        public Personajes Personaje { get; set; }
    }
}
