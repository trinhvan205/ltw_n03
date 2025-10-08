using System;
using System.Collections.Generic;

namespace TvTDay07EF.Models;

public partial class LoaiSanPham
{
    public int Id { get; set; }

    public string? MaLoai { get; set; }

    public string? TenLoai { get; set; }

    public byte? TrangThai { get; set; }

    public virtual ICollection<SanPham> SanPhams { get; set; } = new List<SanPham>();
}
