using System;
using System.Collections.Generic;

namespace TvTDay07EF.Models;

public partial class HoaDon
{
    public int Id { get; set; }

    public string? MaHoaDon { get; set; }

    public int? MaKhaHang { get; set; }

    public DateTime? NgayHoaDon { get; set; }

    public DateTime? NgayNhan { get; set; }

    public string? HoTenKhachHang { get; set; }

    public string? Email { get; set; }

    public string? DienThoai { get; set; }

    public string? DiaChi { get; set; }

    public double? TongTriGia { get; set; }

    public byte? TrangThai { get; set; }

    public virtual ICollection<CtHoaDon> CtHoaDons { get; set; } = new List<CtHoaDon>();

    public virtual KhachHang? MaKhaHangNavigation { get; set; }
}
