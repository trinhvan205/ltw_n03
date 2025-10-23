using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using TvtDay10LabCf.Models;

namespace TvtDay10LabCf.Controllers
{
    [Route("TvtLoai_San_Pham")]
    public class TvtLoai_San_PhamController : Controller
    {
        private readonly TvtDay10LabCfContext _context;

        public TvtLoai_San_PhamController(TvtDay10LabCfContext context)
        {
            _context = context;
        }

        // ================== INDEX ==================
        [HttpGet("tvtIndex")]
        public async Task<IActionResult> tvtIndex()
        {
            var list = await _context.tvtLoai_San_Phams.ToListAsync();
            return View(list);
        }

        // ================== DETAILS ==================
        [HttpGet("tvtDetails/{id?}")]
        public async Task<IActionResult> tvtDetails(long? tvtid)
        {
            if (tvtid == null)
                return NotFound();

            var item = await _context.tvtLoai_San_Phams
                .FirstOrDefaultAsync(m => m.tvtId == tvtid);

            if (item == null)
                return NotFound();

            return View(item);
        }

        // ================== CREATE ==================
        [HttpGet("tvtCreate")]
        public IActionResult tvtCreate()
        {
            return View();
        }

        [HttpPost("tvtCreate")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtCreate([Bind("tvtId,tvtMaLoai,tvtTenLoai,tvtTrangThai")] TvtLoai_San_Pham model)
        {
            if (ModelState.IsValid)
            {
                _context.Add(model);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(tvtIndex));
            }

            // In ra lỗi model (nếu có)
            var errors = ModelState.Values.SelectMany(v => v.Errors)
                                          .Select(e => e.ErrorMessage)
                                          .ToList();
            foreach (var err in errors)
                Console.WriteLine(err);

            return View(model);
        }

        // ================== EDIT ==================
        [HttpGet("tvtEdit/{tvtId}")]
        public async Task<IActionResult> tvtEdit(long? tvtId)
        {
            if (tvtId == null)
                return NotFound();

            var item = await _context.tvtLoai_San_Phams.FindAsync(tvtId);
            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost("tvtEdit/{tvtId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtEdit(long tvtId, [Bind("tvtId,tvtMaLoai,tvtTenLoai,tvtTrangThai")] TvtLoai_San_Pham model)
        {
            if (tvtId != model.tvtId)
                return NotFound();

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!_context.tvtLoai_San_Phams.Any(e => e.tvtId == model.tvtId))
                        return NotFound();
                    else
                        throw;
                }
                return RedirectToAction(nameof(tvtIndex));
            }

            return View(model);
        }

        // ================== DELETE ==================
        [HttpGet("tvtDelete/{tvtId}")]
        public async Task<IActionResult> tvtDelete(long? tvtId)
        {
            if (tvtId == null)
                return NotFound();

            var item = await _context.tvtLoai_San_Phams
                .FirstOrDefaultAsync(m => m.tvtId == tvtId);

            if (item == null)
                return NotFound();

            return View(item);
        }

        [HttpPost("tvtDelete/{tvtId}")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> tvtDeleteConfirmed(long tvtId)
        {
            var item = await _context.tvtLoai_San_Phams.FindAsync(tvtId);
            if (item != null)
            {
                _context.tvtLoai_San_Phams.Remove(item);
                await _context.SaveChangesAsync();
            }

            return RedirectToAction(nameof(tvtIndex));
        }
    }
}
