using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Notifications;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers {

    public class BaseController : Controller {

        public IControllerServices _context;

        public BaseController (IControllerServices services) {
            _context = services;
        }
        public bool OperacaoValida () {
            return !_context._notificator.TemNotificacao ();
        }

        public List<Notificacao> ErrorInModel () {
            return _context._notificator.ObterNotificacao ();
        }

        public async Task SendNotificationNewLink (TagDTO data) {
            await _context._tagHub.Clients.All.SendAsync ("NewTagAdd", data);
        }

    }

}