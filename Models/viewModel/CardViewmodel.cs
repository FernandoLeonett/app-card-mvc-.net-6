using app_card.Controllers;
using app_card.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

public class CardViewModel
{


    public Card Card { get; set; }



    public SelectList ImageOptions { get; set; } // Opciones para la selección de la imagen
}

