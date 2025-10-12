using System.ComponentModel.DataAnnotations;

namespace Day09_CodeFirst_ShoppingCart.Models
{
    public class LoaiSanPham
    {
        [Key]
        public int ID { get; set; }
        public string MaLoai { get; set; }
        public string TenLoai { get; set; }
        public string TrangThai { get; set; }

        // 1 loại sản phẩm có nhiều sản phẩm
        public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
    }
}
