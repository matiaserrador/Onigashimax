using System.ComponentModel.DataAnnotations;

namespace BaseDeDatos.Entidades
{
    public class Personajes
    {
        [Key]
        public int IdPersonajes { get; set; } //IDPERSONAJE 1
        public string NombrePJ { get; set; } // Gokú
        public int Edad { get; set; } // 35
        public bool Masculino { get; set; } //Si
        public bool Femenino { get; set; }//No

      
    }
}