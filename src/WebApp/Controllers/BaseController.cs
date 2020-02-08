using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers {

  public class BaseController : Controller {

    public IControllerServices _context;

    public BaseController (IControllerServices services) {
      _context = services;
    }
  }

}