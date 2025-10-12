using System;
using System.Collections.Generic;

namespace Day09_DatabaseFirst_ShoppingCart.Models;

public partial class ChiTietHoaDon
{
    public int Id { get; set; }

    public int HoaDonId { get; set; }

    public int SanPhamId { get; set; }

    public int SoLuongMua { get; set; }

    public decimal DonGiaMua { get; set; }

    public decimal ThanhTien { get; set; }

    public string TrangThai { get; set; } = null!;

    public virtual HoaDon HoaDon { get; set; } = null!;

    public virtual SanPham SanPham { get; set; } = null!;
}
