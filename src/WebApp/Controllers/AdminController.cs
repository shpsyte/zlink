using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
using Business.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using WebApp.Services;
using WebApp.ViewModels;

namespace WebApp.Controllers {

    public class AdminController : BaseController {
        public AdminController (IControllerServices services) : base (services) { }

        [Route ("app-link")]
        public async Task<IActionResult> Index () {
            return View (new TagDTO (_context._mapper.Map<IEnumerable<TagDTO>> (await _context._tag.GetAllTagActived ())));
        }

        [Route ("app-create-link")]
        public async Task<JsonResult> Create (TagDTO tagDTO) {

            await _context._tag.Add (_context._mapper.Map<Tag> (tagDTO));
            return Json (new {
                success = OperacaoValida (),
                    data = tagDTO
            });
        }

        [Route ("app-update-link")]
        public async Task<JsonResult> Update (TagDTO tagDTO) {

            //prevent null columns....
            var dataObj = await _context._tag.GetOne (a => a.Id == tagDTO.Id);
            dataObj.Name = tagDTO.Name;
            dataObj.TargetLink = tagDTO.TargetLink;
            dataObj.Active = tagDTO.Active;
            await _context._tag.Update (dataObj);

            return Json (new {
                success = OperacaoValida (),
                    data = tagDTO
            });
        }

        [AllowAnonymous]
        [Route ("app/{username?}")]
        [Route ("p/{username?}")]
        [Route ("/{username}")]
        public async Task<IActionResult> Profile (string username) {

            var tagDTO = new TagDTO (
                username,
                _context._profile,
                _context._mapper.Map<IEnumerable<TagDTO>> (await _context._tag.GetAllTagByUserName (username)));

            return View (tagDTO);
        }

        [AllowAnonymous]
        [Route ("app-save-ip-data")]
        public async Task<JsonResult> RegisterIpData (Guid id) {

            var tagDTO = new TagDataDTO (id,
                _context._ipServices.ipFromServer,
                _context._ipServices.userAgent,
                JsonConvert.DeserializeObject<IPDTO> (await _context._ipServices.GetDataFromIp ()));

            var task = _context._tagData.Add (_context._mapper.Map<TagData> (tagDTO));

            return Json (new {
                success = OperacaoValida ()
            });
        }

    }
}