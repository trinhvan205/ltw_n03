using System;
using System.Collections.Generic;

namespace Day09_DatabaseFirst_ShoppingCart.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public string MaHoaDon { get; set; } = null!;

    public string MaKhachHang { get; set; } = null!;

    public DateTime NgayHoaDon { get; set; }

    public DateTime? NgayNhan { get; set; }

    public string HoTenKhachHang { get; set; } = null!;

    public string Email { get; set; } = null!;

    public string DienThoai { get; set; } = null!;

    public string DiaChi { get; set; } = null!;

    public decimal TongTriGia { get; set; }

    public string TrangThai { get; set; } = null!;

    public int KhachHangId { get; set; }

    public int? QuanTriId { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual KhachHang KhachHang { get; set; } = null!;

    public virtual QuanTri? QuanTri { get; set; }
}
