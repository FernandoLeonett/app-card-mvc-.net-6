using app_card.Models;
using app_card.Models.validators;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using app_card.Models.Interfaces;
using Vereyon.Web;

namespace app_card.Controllers
{

    [AccessRoutes]
    public class CardController : Controller
    {
        private IRepositoryFactory _repositoryFactory;
        private readonly IFlashMessage _flashMessage;



        public CardController(IRepositoryFactory repositoryFactory, IFlashMessage flashMessage)
        {
            _repositoryFactory = repositoryFactory;
            _flashMessage = flashMessage;
        }
        // GET: HomeController

        public ActionResult Index()
        {
            List<Card> cards = _repositoryFactory.GetCardRepository().GetAll(DataSource.ChristmasCards, DataSource.BIRTHDAYCARDS);
            var imageOptions = new List<SelectListItem>
        {
            new SelectListItem { Value = "~/img/bird.jpg", Text = "Bird" },
            new SelectListItem { Value = "~/img/bridge.jpg", Text = "Bridge" },
            new SelectListItem { Value = "~/img/cliff.jpg", Text = "Cliff" },
            new SelectListItem { Value = "~/img/colibri.jpg", Text = "Colibri" },
            new SelectListItem { Value = "~/img/clothe.jpg", Text = "Clothe" },
            new SelectListItem { Value = "~/img/orange.jpg", Text = "Orange" },
            new SelectListItem { Value = "~/img/ninos.jpg", Text = "Ninos" },
            new SelectListItem { Value = "~/img/shopping.jpg", Text = "Shopping" }
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

        [HttpPost]
        public ActionResult Create(CardViewModel createdCard)
        {
            try
            {
                // Verificar si la propiedad ImageOptions es nula
                

                if (ModelState.IsValid)
                {
                    Card newCard = new Card
                    {
                        Description = createdCard.Card.Description,
                        Title = createdCard.Card.Title,
                        UrlImage = createdCard.SelectedOption,
                        DataSource = createdCard.Card.DataSource
                    };

                    _repositoryFactory.GetCardRepository().Add(newCard);

                    _flashMessage.Warning("Operacion exitosa", "Imagen Agregada");

                }
                else
                {
                    _flashMessage.Warning("Error al crear", "verifique los campos");
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                _flashMessage.Danger("Ha ocurrido un error ", ex.Message);

                return RedirectToAction("Index");
            }
        }

        // GET: CardController/Edit/5
        [HttpPost]
        public IActionResult Edit(Card card)
        {
            try
            {
                // Validar modelo
                if (ModelState.IsValid)
                {
                    if (_repositoryFactory.GetCardRepository().Update(card))
                    {
                        _flashMessage.Info("La Card ", card.Title + " Ha sido actualizada");
                        return RedirectToAction("Index");

                    }
                    return RedirectToAction("Index");
                }
                _flashMessage.Warning("La card no se puede actualizar", "verifique los campos");


                return RedirectToAction("Index");

            }
            catch (Exception ex)
            {
                _flashMessage.Danger("Ha ocurrido un error ", ex.Message);
                return RedirectToAction("Index");
            }
        }

        [Route("Card/Delete/{id}")]
        public ActionResult Delete(string id, DataSource db)

        {

            if (id != null)
            {

                if (_repositoryFactory.GetCardRepository().Delete(id, db))
                {

                    _flashMessage.Info("Operacion Exitosa", "la card fue eliminada");
                }
                else
                {
                    _flashMessage.Warning("La card no se encontro", "la card no fue eliminada");

                }
            }
            else
            {
                _flashMessage.Warning("No se puedo eliminar", "no se ha provisto un identificador para la card");

            }
            // Código del método
            return RedirectToAction("Index");
        }
    }
}
