using System.Collections.Generic;
using System.Threading.Tasks;
using Business.Models;
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
                    Tags = _context._mapper.Map<IEnumerable<TagDTO>> (await _context._tag.GetAllTagActived ())
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

        // // GET: Admin/Details/5
        // public async Task<IActionResult> Details (Guid? id) {
        //     if (id == null) {
        //         return NotFound ();
        //     }

        //     var tagDTO = await _context.TagDTO
        //         .FirstOrDefaultAsync (m => m.Id == id);
        //     if (tagDTO == null) {
        //         return NotFound ();
        //     }

        //     return View (tagDTO);
        // }

        // // GET: Admin/Create
        // public IActionResult Create () {
        //     return View ();
        // }

        // // POST: Admin/Create
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Create ([Bind ("Id,UserId,Name,TargetLink,Start,End,Thumb,HideInfo,ShortText,OpenNewTab,Campaingn,Parameters,IsPriority,Active,Deleted,CreateAt")] TagDTO tagDTO) {
        //     if (ModelState.IsValid) {
        //         tagDTO.Id = Guid.NewGuid ();
        //         _context.Add (tagDTO);
        //         await _context.SaveChangesAsync ();
        //         return RedirectToAction (nameof (Index));
        //     }
        //     return View (tagDTO);
        // }

        // // GET: Admin/Edit/5
        // public async Task<IActionResult> Edit (Guid? id) {
        //     if (id == null) {
        //         return NotFound ();
        //     }

        //     var tagDTO = await _context.TagDTO.FindAsync (id);
        //     if (tagDTO == null) {
        //         return NotFound ();
        //     }
        //     return View (tagDTO);
        // }

        // // POST: Admin/Edit/5
        // // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        // [HttpPost]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> Edit (Guid id, [Bind ("Id,UserId,Name,TargetLink,Start,End,Thumb,HideInfo,ShortText,OpenNewTab,Campaingn,Parameters,IsPriority,Active,Deleted,CreateAt")] TagDTO tagDTO) {
        //     if (id != tagDTO.Id) {
        //         return NotFound ();
        //     }

        //     if (ModelState.IsValid) {
        //         try {
        //             _context.Update (tagDTO);
        //             await _context.SaveChangesAsync ();
        //         } catch (DbUpdateConcurrencyException) {
        //             if (!TagDTOExists (tagDTO.Id)) {
        //                 return NotFound ();
        //             } else {
        //                 throw;
        //             }
        //         }
        //         return RedirectToAction (nameof (Index));
        //     }
        //     return View (tagDTO);
        // }

        // // GET: Admin/Delete/5
        // public async Task<IActionResult> Delete (Guid? id) {
        //     if (id == null) {
        //         return NotFound ();
        //     }

        //     var tagDTO = await _context.TagDTO
        //         .FirstOrDefaultAsync (m => m.Id == id);
        //     if (tagDTO == null) {
        //         return NotFound ();
        //     }

        //     return View (tagDTO);
        // }

        // // POST: Admin/Delete/5
        // [HttpPost, ActionName ("Delete")]
        // [ValidateAntiForgeryToken]
        // public async Task<IActionResult> DeleteConfirmed (Guid id) {
        //     var tagDTO = await _context.TagDTO.FindAsync (id);
        //     _context.TagDTO.Remove (tagDTO);
        //     await _context.SaveChangesAsync ();
        //     return RedirectToAction (nameof (Index));
        // }

        // private bool TagDTOExists (Guid id) {
        //     return _context.TagDTO.Any (e => e.Id == id);
        // }
    }
}