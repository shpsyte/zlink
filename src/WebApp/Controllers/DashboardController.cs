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
        public IActionResult Dashboard (Guid id) {
            return View (new Dashboard (id));
        }

        [Route ("app-data-dashboard/{id?}")]
        public async Task<JsonResult> DashboardData (Guid id, Nullable<DateTime> start, Nullable<DateTime> end) {
            var data = (await GetData (id, start ?? DateTime.MinValue, end ?? DateTime.MaxValue));

            return Json (new {
                data.Id,
                    data.Stats
            });
        }

        private async Task<Dashboard> GetData (Guid id, DateTime start, DateTime end) {
            return new Dashboard (
                _context._mapper.Map<TagDTO> (await _context._tag.GetTagWithAllTagData (id)),
                start,
                end
            );
        }
    }
}