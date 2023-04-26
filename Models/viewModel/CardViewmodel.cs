using app_card.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;

public class CardViewModel
{
    public Card Card { get; set; }


    [DisplayName("Imagenes")]
    public SelectList? ImageOptions { get; set; }
    public string? SelectedOption { get; set; }


}

