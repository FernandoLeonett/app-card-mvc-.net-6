using app_card.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

    public class IndexViewModel
    {
    
            public List<Card> Cards { get; set; }
            public CardViewModel NewCard { get; set; }
        

    }
