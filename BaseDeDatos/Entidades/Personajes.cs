using System.ComponentModel.DataAnnotations;

namespace BaseDeDatos.Entidades
{
    public class Personajes
    {
        [Key]
        public int IdPersonajes { get; set; } //IDPERSONAJE 1, 2, 3 etc
        public string NombrePJ { get; set; } // Gokú , Luffy, Naruto, etc
        public int Edad { get; set; } // 35, 17, 30, etc
        public bool Masculino { get; set; } //Si, si, si
        public bool Femenino { get; set; }//No, no, no
    }
}