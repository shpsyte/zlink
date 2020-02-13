using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers {
    public class AdminController : BaseController {
        public AdminController (IControllerServices services) : base (services) { }

        [Route ("admin-link")]
        public async Task<IActionResult> Index () {

            return View (
                new TagDTO () {
                    Tags = _context._mapper.Map<IEnumerable<TagDTO>> (await _context._tag.GetAllTagActived ()),
                        TotalTags = await _context._tag.GetAllTagActivedCount ()
                }
            );
        }

        [Route ("admin-create-link")]
        public async Task<JsonResult> Create (TagDTO tagDTO) {

            await _context._tag.Add (_context._mapper.Map<Tag> (tagDTO));

            return Json (new {
                success = OperacaoValida (),
                    data = tagDTO
            });
        }

        [Route ("admin-update-link")]
        public async Task<JsonResult> Update (TagDTO tagDTO) {

            var dataObj = await _context._tag.GetOne (a => a.Id == tagDTO.Id);

            dataObj.Name = tagDTO.Name;
            dataObj.TargetLink = tagDTO.TargetLink;
            dataObj.Active = dataObj.Active;

            await _context._tag.Update (dataObj);

            return Json (new {
                success = OperacaoValida (),
                    data = tagDTO
            });
        }

        [AllowAnonymous]
        [Route ("/{username:length(1,10)}")]
        public async Task<IActionResult> Profile (string username) {
            _context._mapper.Map<IEnumerable<TagDTO>> (await _context._tag.GetAllTagByUserName (username));
            return View ();
        }

    }
}