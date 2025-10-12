namespace Day09_CodeFirst_ShoppingCart.Models
{
    public class QuanTri
    {
        public int ID { get; set; }
        public string TaiKhoan { get; set; }
        public string MatKhau { get; set; }
        public string TrangThai { get; set; }

        // 1 quản trị có thể tạo nhiều hóa đơn (nếu có quan hệ)
        public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
    }
}
