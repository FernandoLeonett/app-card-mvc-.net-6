using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class CardViewModel
{
    public int Id { get; set; }

    [Required(ErrorMessage = "El título es requerido")]
    public string Title { get; set; }

    [Required(ErrorMessage = "La descripción es requerida")]
    public string Description { get; set; }

    [Display(Name = "Imagen")]
    public string Image { get; set; }

    public SelectList ImageOptions { get; set; } // Opciones para la selección de la imagen
}
namespace app_card.Models.viewModel
{
    public class CardViewmodel
    {
    }
}
