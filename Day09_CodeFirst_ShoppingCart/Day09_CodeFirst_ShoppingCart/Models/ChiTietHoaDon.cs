namespace Day09_CodeFirst_ShoppingCart.Models
{
    public class ChiTietHoaDon
    {
        public int ID { get; set; }
        public int HoaDonID { get; set; }
        public int SanPhamID { get; set; }
        public int SoLuongMua { get; set; }
        public decimal DonGiaMua { get; set; }
        public decimal ThanhTien { get; set; }
        public string TrangThai { get; set; }

        // Quan hệ n-1 đến HoaDon
        public virtual HoaDon HoaDon { get; set; }

        // Quan hệ n-1 đến SanPham
        public virtual SanPham SanPham { get; set; }
    }
}
