using app_card.Models;
using Microsoft.AspNetCore.Mvc;
using Vereyon.Web;

namespace app_card.Controllers
{
    public class UserController : Controller
    {
        private readonly IFlashMessage _flashMessage;

        public UserController(IFlashMessage flashMessage)
        {
            _flashMessage = flashMessage;

        }
        private readonly List<User> users = new()
        {
            new User
            {
                Email = "ariel@example.com",
                Password = "1234",
                Rol = Rol.Administrator
            },
            new User
            {
                Email = "fernando@example.com",
                Password = "1234",
                Rol = Rol.User
            },
            new User
            {
                Email = "carlos@example.com",
                Password = "1234",
                Rol = Rol.User
            }
        };


        // GET: UserController
        public ActionResult Login()
        {
            if (HttpContext.Session.GetString("userEmail") == null)
            {
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Card");
            }

        }

        // GET: UserController/Details/5

        [HttpPost]
        public IActionResult Login(User user)
        {
            if (ModelState.IsValid)
            {
                // Buscar usuario en la lista de usuarios
                User authenticatedUser = users.FirstOrDefault(u => u.Email == user.Email && u.Password == user.Password);

                if (authenticatedUser != null)
                {
                    // Almacenar información del usuario en la sesión
                    HttpContext.Session.SetString("userEmail", authenticatedUser.Email);
                    HttpContext.Session.SetString("rol", authenticatedUser.Rol.ToString());

                    // Redirigir al usuario a la página principal de la aplicación
                    return RedirectToAction("Index", "Card");
                }
                else
                {
                    // Agregar mensaje de error 
                    _flashMessage.Warning("Usuario no existe", "Error en Login");

                    // Devolver la vista Login con mensaje de error
                    return View("Login", user);
                }
            }

            // Devolver la vista Login con modelo de usuario
            return View("Login", user);
        }
        // GET: UserController/Edit/5


        public IActionResult Logout()
        {
            if (HttpContext.Session.GetString("userEmail") != null)
            {
                HttpContext.Session.Clear();
            }

            return RedirectToAction("Login");

        }
    }
}
