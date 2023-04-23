using app_card.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Reflection;

namespace app_card.Controllers
{
    public class CardController : Controller
    {
        // GET: HomeController
        public ActionResult Index()
        {
            var cards = new List<Card>
{
    new Card { Title = "Shopping", Description = "Go shopping for new clothes", Id = 1, UrlImage = "~/img/shopping.jpg", DataSource = DataSource.BIRTHDAY },
    new Card { Title = "Cliff", Description = "Watch the sunset from the top of the cliff", Id = 2, UrlImage = "~/img/cliff.jpg", DataSource = DataSource.CHRISTMAS },
    new Card { Title = "Bridge", Description = "Take a walk on the bridge", Id = 3, UrlImage = "~/img/bridge.jpg", DataSource = DataSource.BIRTHDAY },
    new Card { Title = "Bird", Description = "Take pictures of the colorful birds in the park lorem ipsusmmasasa jjasasas hhhh sss jjja kkkkas ljjjnlas fernando jose hernandez leonett es el mj", Id = 4, UrlImage = "~/img/bird.jpg", DataSource = DataSource.CHRISTMAS,  }, new Card { Title = "Bird", Description = "Take pictures of the colorful birds in the park lorem ipsusmmasasa jjasasas hhhh sss jjja kkkkas ljjjnlas fernando jose hernandez leonett es el mj", Id = 4, DataSource = DataSource.CHRISTMAS }
};

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










        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
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
        public ActionResult Create(CardViewModel card, string ImageOptions)
        {
            try
            {
                Card newCard = new Card { Description = card.Description, Title = card.Title };

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
