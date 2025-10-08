using System;
using System.Collections.Generic;

namespace TvTDay07EF.Models;

public partial class CtHoaDon
{
    public int Id { get; set; }

    public int? HoaDonId { get; set; }

    public int? SanPhamId { get; set; }

    public int? SoLuongMua { get; set; }

    public double? DonGiaMua { get; set; }

    public double? ThanhTien { get; set; }

    public byte? TrangThai { get; set; }

    public virtual HoaDon? HoaDon { get; set; }

    public virtual SanPham? SanPham { get; set; }
}
