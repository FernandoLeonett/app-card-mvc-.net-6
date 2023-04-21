using app_card.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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



            return View(cards);
        }

        // GET: HomeController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: HomeController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HomeController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: HomeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HomeController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: HomeController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
