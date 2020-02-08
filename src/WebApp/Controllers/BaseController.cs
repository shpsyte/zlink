using Microsoft.AspNetCore.Mvc;
using WebApp.Services;

namespace WebApp.Controllers {

  public class BaseController : Controller {

    public IControllerServices _this;

    public BaseController (IControllerServices services) {
      _this = services;
    }
  }

}