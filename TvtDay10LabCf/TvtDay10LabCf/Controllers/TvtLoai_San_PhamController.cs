using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TvtDay10LabCf.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace TvtDay10LabCf.Controllers
{
    public class TvtLoai_San_PhamController : Controller
    {
        private readonly TvtDay10LabCfContext _context;

        public TvtLoai_San_PhamController(TvtDay10LabCfContext context)
        {
            _context = context;
        }

        // GET: TvtLoai_San_Pham
        public async Task<IActionResult> tvtIndex()
        {
            return View(await _context.tvtLoai_San_Phams.ToListAsync());
        }

        // GET: TvtLoai_San_Pham/Details/5
        public async Task<IActionResult> tvtDetails(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tvtLoai_San_Pham = await _context.tvtLoai_San_Phams
                .FirstOrDefaultAsync(m => m.tvtId == id);
            if (tvtLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(tvtLoai_San_Pham);
        }

        // GET: TvtLoai_San_Pham/Create
        public IActionResult tvtCreate()
        {
            return View();
        }

        // POST: TvtLoai_San_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtCreate([Bind("tvtId,tvtMaLoai,tvtTenLoai,tvtTrangThai")] TvtLoai_San_Pham tvtLoai_San_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvtLoai_San_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(tvtIndex));
            }
            return View(tvtLoai_San_Pham);
        }

        // GET: TvtLoai_San_Pham/Edit/5
        public async Task<IActionResult> tvtEdit(long? tvtId)
        {
            if (tvtId == null)
            {
                return NotFound();
            }

            var tvtLoai_San_Pham = await _context.tvtLoai_San_Phams.FindAsync(tvtId);
            if (tvtLoai_San_Pham == null)
            {
                return NotFound();
            }
            return View(tvtLoai_San_Pham);
        }

        // POST: TvtLoai_San_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtEdit(long tvtId, [Bind("tvtId,tvtMaLoai,tvtTenLoai,tvtTrangThai")] TvtLoai_San_Pham tvtLoai_San_Pham)
        {
            if (tvtId != tvtLoai_San_Pham.tvtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvtLoai_San_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvtLoai_San_PhamExists(tvtLoai_San_Pham.tvtId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(tvtIndex));
            }
            return View(tvtLoai_San_Pham);
        }

        // GET: TvtLoai_San_Pham/Delete/5
        public async Task<IActionResult> tvtDelete(long? tvtId)
        {
            if (tvtId == null)
            {
                return NotFound();
            }

            var tvtLoai_San_Pham = await _context.tvtLoai_San_Phams
                .FirstOrDefaultAsync(m => m.tvtId == tvtId);
            if (tvtLoai_San_Pham == null)
            {
                return NotFound();
            }

            return View(tvtLoai_San_Pham);
        }

        // POST: TvtLoai_San_Pham/Delete/5
        [HttpPost, ActionName("tvtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtDeleteConfirmed(long tvtId)
        {
            var tvtLoai_San_Pham = await _context.tvtLoai_San_Phams.FindAsync(tvtId);
            if (tvtLoai_San_Pham != null)
            {
                _context.tvtLoai_San_Phams.Remove(tvtLoai_San_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TvtLoai_San_PhamExists(long tvtId)
        {
            return _context.tvtLoai_San_Phams.Any(e => e.tvtId == tvtId);
        }
    }
}
