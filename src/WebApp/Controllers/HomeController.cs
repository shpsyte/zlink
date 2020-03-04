using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers {

    [Authorize]
    public class HomeController : Controller {

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