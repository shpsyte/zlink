using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.ViewModels;

namespace WebApp.Controllers {
    public class HomeController : Controller {
        public IActionResult Index () {
            return View ();
        }

        public IActionResult Privacy () {
            return View ();
        }

        [Route ("erro/{id:lenght(3,3)}")]

        public IActionResult Error (int id) {
            var erroViewModel = new ErrorViewModel {
                ErrorCode = id,
                Message = "Erro",
                Title = "Erro Title"
            };
            return View ("Error", erroViewModel);
        }
    }
}