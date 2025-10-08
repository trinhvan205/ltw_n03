using System;
using System.Collections.Generic;

namespace TvTDay07EF.Models;

public partial class SanPham
{
    public int Id { get; set; }

    public string? MaSanPham { get; set; }

    public string? TenSanPham { get; set; }

    public string? HinhAnh { get; set; }

    public int? SoLuong { get; set; }

    public double? DonGia { get; set; }

    public int? MaLoai { get; set; }

    public byte? TrangThai { get; set; }

    public virtual ICollection<CtHoaDon> CtHoaDons { get; set; } = new List<CtHoaDon>();

    public virtual LoaiSanPham? MaLoaiNavigation { get; set; }
}
