using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Extensions {

    public class RenderLinksAdmUserViewComponent : ViewComponent {

        private IControllerServices _services;

        public RenderLinksAdmUserViewComponent (IControllerServices services) {
            this._services = services;
        }

        public async Task<IViewComponentResult> InvokeAsync () {

            var tagDTO = new TagDTO (
                _services._user.UserName (),
                _services._profile,
                _services._mapper.Map<IEnumerable<TagDTO>> (await _services._tag.GetAllTagActived ()));

            return View (tagDTO);
        }

    }
}