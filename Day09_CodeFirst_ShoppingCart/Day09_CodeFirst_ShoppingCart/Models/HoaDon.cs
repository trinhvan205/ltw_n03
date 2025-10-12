namespace Day09_CodeFirst_ShoppingCart.Models
{
    public class HoaDon
    {
        public int ID { get; set; }
        public string MaHoaDon { get; set; }
        public string MaKhachHang { get; set; }
        public DateTime NgayHoaDon { get; set; }
        public DateTime? NgayNhan { get; set; }
        public string HoTenKhachHang { get; set; }
        public string Email { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public decimal TongTriGia { get; set; }
        public string TrangThai { get; set; }

        // Khóa ngoại đến KhachHang
        public int KhachHangID { get; set; }
        public virtual KhachHang KhachHang { get; set; }

        // 1 hóa đơn có nhiều chi tiết hóa đơn
        public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();
    }
}
