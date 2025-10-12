namespace Day09_CodeFirst_ShoppingCart.Models
{
    public class SanPham
    {
        public int ID { get; set; }
        public string MaSanPham { get; set; }
        public string TenSanPham { get; set; }
        public string HinhAnh { get; set; }
        public int SoLuong { get; set; }
        public decimal DonGia { get; set; }
        public string TrangThai { get; set; }

        // Khóa ngoại đến LoaiSanPham
        public int MaLoai { get; set; }
        public virtual LoaiSanPham LoaiSanPham { get; set; }

        // 1 sản phẩm có thể xuất hiện trong nhiều chi tiết hóa đơn
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}
