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

    public class DashboardController : BaseController {
        public DashboardController (IControllerServices services) : base (services) { }

        [Route ("app-dashboard")]
        public async Task<IActionResult> Dashboard () {
            return View (new Dashboard (
                _context._mapper.Map<IEnumerable<TagDTO>> (await _context._tag.GetAllTagActived ())));
        }

        [Route ("app-data-dashboard/{id?}")]
        public async Task<JsonResult> DashboardData (Guid id, Nullable<DateTime> start, Nullable<DateTime> end) {
            var data = (await GetData (id, start ?? DateTime.MinValue, end ?? DateTime.MaxValue));

            return Json (new {
                data.Id,
                    data.Tag.Name,
                    data.Stats
            });
        }

        private async Task<Dashboard> GetData (Guid id, DateTime start, DateTime end) {
            var dash = new Dashboard (
                _context._mapper.Map<TagDTO> (await _context._tag.GetTagWithAllTagData (id)),
                start,
                end
            );
            return dash;
        }
    }
}