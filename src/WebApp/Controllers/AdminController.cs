using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers {

  public class AdminController : BaseController {

    public AdminController (IControllerServices services) : base (services) {

    }

    [Route ("admin-link")]
    public async Task<IActionResult> Index () {
      return View (_context._mapper
        .Map<IEnumerable<TagDTO>> (await _context._tagServices.GetAll ())
      );
    }

  }
}