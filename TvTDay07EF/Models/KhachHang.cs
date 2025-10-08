using System;
using System.Collections.Generic;

namespace TvTDay07EF.Models;

public partial class KhachHang
{
    public int Id { get; set; }

    public string? MaKhachHang { get; set; }

    public string? HoTenKhachHang { get; set; }

    public string? Email { get; set; }

    public string? MaKhau { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public DateTime? NgayDangKy { get; set; }

    public byte? TrangThai { get; set; }

    public virtual ICollection<HoaDon> HoaDons { get; set; } = new List<HoaDon>();
}
