namespace Day09_CodeFirst_ShoppingCart.Models
{
    public class KhachHang
    {
        public int ID { get; set; }
        public string MaKhachHang { get; set; }
        public string HoTenKhachHang { get; set; }
        public string Email { get; set; }
        public string MatKhau { get; set; }
        public string DienThoai { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayDangKy { get; set; }
        public string TrangThai { get; set; }

        // 1 khách hàng có thể có nhiều hóa đơn
        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }
}
