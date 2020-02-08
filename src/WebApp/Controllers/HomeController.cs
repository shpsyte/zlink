using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers {

    public class HomeController : BaseController {
        public HomeController (IControllerServices services) : base (services) { }

        public IActionResult Index () {
            return View ();
        }

        public IActionResult Privacy () {
            return View ();

        }

        [Route ("erro/{id:length(3,3)}")]

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