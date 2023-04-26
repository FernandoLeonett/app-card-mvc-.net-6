using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace app_card.Models
{

    public enum DataSource
    {

        BIRTHDAYCARDS,
        ChristmasCards
    }
    public class Card
    {
        public Guid? Id { get; set; }
        [DisplayName("Titulo")]

        [Required(ErrorMessage = "El título es requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "El título debe tener al menos 3 caracteres y no más de 50 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "La descripción es requerida")]
        [StringLength(250, MinimumLength = 3, ErrorMessage = "La descripción debe tener al menos 3 caracteres y no más de 250 caracteres")]
        [DisplayName("Descripción")]
        public string Description { get; set; }

        public string? UrlImage { get; set; }
        [DisplayName("Base de datos")]

        [Required(ErrorMessage = "debe seleccionar la base de datos")]
        public DataSource DataSource { get; set; }
    }
}
