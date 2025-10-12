using Microsoft.EntityFrameworkCore;

namespace Day09_CodeFirst_ShoppingCart.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
        {
            Console.WriteLine($"Database đang dùng: {Database.GetDbConnection().Database}");
        }

        public DbSet<KhachHang> KhachHangs { get; set; }
        public DbSet<QuanTri> QuanTris { get; set; }
        public DbSet<HoaDon> HoaDons { get; set; }
        public DbSet<ChiTietHoaDon> ChiTietHoaDons { get; set; }
        public DbSet<SanPham> SanPhams { get; set; }
        public DbSet<LoaiSanPham> LoaiSanPhams { get; set; }
    }
}
