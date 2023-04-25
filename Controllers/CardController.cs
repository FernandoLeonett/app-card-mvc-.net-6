using app_card.Models;
using app_card.Models.validators;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Logging;
using app_card.Models.Interfaces;
using static NuGet.Protocol.Core.Types.Repository;

namespace app_card.Controllers
{

    [AccessRoutes]
    public class CardController : Controller
    {
        private  IRepositoryFactory _repositoryFactory;



        public CardController(IRepositoryFactory repositoryFactory)
        {
            _repositoryFactory = repositoryFactory;
        }
        // GET: HomeController

        public ActionResult Index()
        {
             List<Card> cards = _repositoryFactory.GetCardRepository().GetAll(DataSource.ChristmasCards,DataSource.BIRTHDAYCARDS);
            var imageOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "bird.jpg", Text = "Imagen 1" },
            new SelectListItem { Value = "cliff.jpg", Text = "Imagen 2" },
            new SelectListItem { Value = "shopping.jpg", Text = "Imagen 3" }
        };
            IndexViewModel model = new IndexViewModel()
            {

                Cards = cards,
                NewCard = new CardViewModel
                {
                    ImageOptions = new SelectList(imageOptions, "Value", "Text")
                }



            };

            return View(model);
        }

           

        // GET: HomeController/Create
        public ActionResult Create()
        {
            var model = new CardViewModel();
            model.ImageOptions = new SelectList(new List<string> { "option1", "option2", "option3" }); // Lista de opciones para la imagen

            return RedirectToAction("Index");
        }



        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CardViewModel CreatedCard, string ImageOptions)
        {
            try
            {
                Card newCard = new Card { Description = CreatedCard.Card.Description, Title = CreatedCard.Card.Title };

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CardController/Edit/5
        [HttpPost]
        public IActionResult Edit(string title, string description)
        {
            // actualizar los datos en la base de datos
            // ...

            // redirigir al usuario a la página principal
            return RedirectToAction("Index");
        }


        // POST: HomeController/Edit/5




        // DELETE: CardController/Delete/5
        [Route("Card/Delete/{id}")]
        public ActionResult Delete(int id)
        {
            // Código del método
            return RedirectToAction("Index");
        }
        public ActionResult DeleteModal(int id, string title)
        {

            Card card= new Card { Title = title, Id=id };

            TempData["deleteCard"] = card;
            // Código del método
          return RedirectToAction("Index");
        }




    }
}
