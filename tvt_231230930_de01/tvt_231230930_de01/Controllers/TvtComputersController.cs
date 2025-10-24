using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tvt_231230930_de01.Models;

namespace Tvt_231230930_de01.Controllers
{
    public class TvtComputersController : Controller
    {
        private readonly Tvt_231230930_de01Context _context;

        public TvtComputersController(Tvt_231230930_de01Context context)
        {
            _context = context;
        }

        // GET: TvtComputers
        public async Task<IActionResult> TvtIndex()
        {
            return View(await _context.TvtComputers.ToListAsync());
        }

        // GET: TvtComputers/Details/5
        public async Task<IActionResult> TvtDetails(int? id)
        {
            if (id == null)
                return NotFound();

            var tvtComputer = await _context.TvtComputers
                .FirstOrDefaultAsync(m => m.tvtComId == id);
            if (tvtComputer == null)
                return NotFound();

            return View(tvtComputer);
        }

        // GET: TvtComputers/Create
        public IActionResult TvtCreate()
        {
            return View();
        }

        // POST: TvtComputers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TvtCreate([Bind("tvtComId,tvtComName,tvtComprice,tvtComImage,tvtComStatus")] TvtComputer tvtComputer)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvtComputer);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(TvtIndex)); 
            }
            return View(tvtComputer);
        }

        // GET: TvtComputers/Edit/5
        public async Task<IActionResult> TvtEdit(int? id)
        {
            if (id == null)
                return NotFound();

            var tvtComputer = await _context.TvtComputers.FindAsync(id);
            if (tvtComputer == null)
                return NotFound();

            return View(tvtComputer);
        }

        // POST: TvtComputers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TvtEdit(int id, [Bind("tvtComId,tvtComName,tvtComprice,tvtComImage,tvtComStatus")] TvtComputer tvtComputer)
        {
            if (id != tvtComputer.tvtComId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvtComputer);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvtComputerExists(tvtComputer.tvtComId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(TvtIndex)); 
            }
            return View(tvtComputer);
        }

        // GET: TvtComputers/Delete/5
        public async Task<IActionResult> TvtDelete(int? id)
        {
            if (id == null)
                return NotFound();

            var tvtComputer = await _context.TvtComputers
                .FirstOrDefaultAsync(m => m.tvtComId == id);
            if (tvtComputer == null)
                return NotFound();

            return View(tvtComputer);
        }

        // POST: TvtComputers/Delete/5
        [HttpPost, ActionName("TvtDelete")] 
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TvtDeleteConfirmed(int id)
        {
            var tvtComputer = await _context.TvtComputers.FindAsync(id);
            if (tvtComputer != null)
                _context.TvtComputers.Remove(tvtComputer);

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(TvtIndex));
        }

        private bool TvtComputerExists(int id)
        {
            return _context.TvtComputers.Any(e => e.tvtComId == id);
        }
    }
}
