using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TH1_lms.Models;

namespace TH1_lms.ViewComponents
{
    public class MajorViewComponent : ViewComponent
    {
        private readonly SchoolContext _context;

        public MajorViewComponent(SchoolContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var majors = await _context.Majors.ToListAsync(); //lấy danh sách chuyên ngành từ cơ sở dữ liệu
            return View("RenderMajor", majors); //trả về view RenderMajor và truyền danh sách chuyên ngành vào
        }
    }
}
