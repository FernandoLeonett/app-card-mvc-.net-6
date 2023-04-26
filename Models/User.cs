using System.ComponentModel.DataAnnotations;

namespace app_card.Models
{

    public enum Rol
    {

        Administrator,
        User
    }
    public class User
    {
        [EmailAddress(ErrorMessage ="debe cumplir con el formato email"), Required(ErrorMessage = "el email es requerido")]
        public string Email { get; set; }
        [Required(ErrorMessage ="clave requerida")]
        public string Password { get; set; }
        public Rol Rol { get; set; }
    }
}
