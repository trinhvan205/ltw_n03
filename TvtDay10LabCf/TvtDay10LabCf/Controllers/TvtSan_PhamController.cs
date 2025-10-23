using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TvtDay10LabCf.Models;

namespace TvtDay10LabCf.Controllers
{
    public class TvtSan_PhamController : Controller
    {
        private readonly TvtDay10LabCfContext _context;

        public TvtSan_PhamController(TvtDay10LabCfContext context)
        {
            _context = context;
        }

        // GET: TvtSan_Pham
        public async Task<IActionResult> tvtIndex()
        {
            var tvtDay10LabCfContext = _context.tvtSan_Phams.Include(t => t.TvtLoai_San_Pham);
            return View(await tvtDay10LabCfContext.ToListAsync());
        }

        // GET: TvtSan_Pham/Details/5
        public async Task<IActionResult> tvtDetails(long? tvtid)
        {
            if (tvtid == null)
            {
                return NotFound();
            }

            var tvtSan_Pham = await _context.tvtSan_Phams
                .Include(t => t.TvtLoai_San_Pham)
                .FirstOrDefaultAsync(m => m.tvtId == tvtid);
            if (tvtSan_Pham == null)
            {
                return NotFound();
            }

            return View(tvtSan_Pham);
        }

        // GET: TvtSan_Pham/Create
        public IActionResult tvtCreate()
        {
            ViewData["tvtLoaiId"] = new SelectList(
                _context.tvtLoai_San_Phams,
                "tvtId",
                "tvtTenLoai"   // ✅ Hiển thị tên loại thay vì ID
            );
            return View();
        }


        // POST: TvtSan_Pham/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtCreate([Bind("tvtId,tvtMaSanPham,tvtTenSanPham,tvtHinhAnh,tvtSoLuong,tvtDonGia,tvtLoaiId,tvtTrangThai")] TvtSan_Pham tvtSan_Pham)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tvtSan_Pham);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(tvtIndex));
            }
            ViewData["tvtLoaiId"] = new SelectList(_context.tvtLoai_San_Phams, "tvtId", "tvtId", tvtSan_Pham.tvtLoaiId);
            return View(tvtSan_Pham);
        }

        // GET: TvtSan_Pham/Edit/5
        public async Task<IActionResult> tvtEdit(long? tvtid)
        {
            if (tvtid == null) return NotFound();

            var tvtSan_Pham = await _context.tvtSan_Phams.FindAsync(tvtid);
            if (tvtSan_Pham == null) return NotFound();

            // ✅ Hiển thị tên loại thay vì ID
            ViewData["tvtLoaiId"] = new SelectList(
                _context.tvtLoai_San_Phams,
                "tvtId",
                "tvtTenLoai",
                tvtSan_Pham.tvtLoaiId
            );

            return View(tvtSan_Pham);
        }


        // POST: TvtSan_Pham/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtEdit(long tvtid, [Bind("tvtId,tvtMaSanPham,tvtTenSanPham,tvtHinhAnh,tvtSoLuong,tvtDonGia,tvtLoaiId,tvtTrangThai")] TvtSan_Pham tvtSan_Pham)
        {
            if (tvtid != tvtSan_Pham.tvtId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tvtSan_Pham);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TvtSan_PhamExists(tvtSan_Pham.tvtId))
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
            ViewData["tvtLoaiId"] = new SelectList(_context.tvtLoai_San_Phams, "tvtId", "tvtId", tvtSan_Pham.tvtLoaiId);
            return View(tvtSan_Pham);
        }

        // GET: TvtSan_Pham/Delete/5
        public async Task<IActionResult> tvtDelete(long? tvtid)
        {
            if (tvtid == null)
            {
                return NotFound();
            }

            var tvtSan_Pham = await _context.tvtSan_Phams
                .Include(t => t.TvtLoai_San_Pham)
                .FirstOrDefaultAsync(m => m.tvtId == tvtid);
            if (tvtSan_Pham == null)
            {
                return NotFound();
            }

            return View(tvtSan_Pham);
        }

        // POST: TvtSan_Pham/Delete/5
        [HttpPost, ActionName("tvtDelete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtDeleteConfirmed(long tvtid)
        {
            var tvtSan_Pham = await _context.tvtSan_Phams.FindAsync(tvtid);
            if (tvtSan_Pham != null)
            {
                _context.tvtSan_Phams.Remove(tvtSan_Pham);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(tvtIndex));
        }

        private bool TvtSan_PhamExists(long tvtid)
        {
            return _context.tvtSan_Phams.Any(e => e.tvtId == tvtid);
        }
    }
}
