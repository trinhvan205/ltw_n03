using System;
using System.Collections.Generic;

namespace Day09_DatabaseFirst_ShoppingCart.Models;

public partial class SanPham
{
    public int Id { get; set; }

    public string MaSanPham { get; set; } = null!;

    public string TenSanPham { get; set; } = null!;

    public string HinhAnh { get; set; } = null!;

    public int SoLuong { get; set; }

    public decimal DonGia { get; set; }

    public string TrangThai { get; set; } = null!;

    public int MaLoai { get; set; }

    public int LoaiSanPhamId { get; set; }

    public virtual ICollection<ChiTietHoaDon> ChiTietHoaDons { get; set; } = new List<ChiTietHoaDon>();

    public virtual LoaiSanPham LoaiSanPham { get; set; } = null!;
}
