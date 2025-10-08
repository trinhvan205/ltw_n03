using System;
using System.Collections.Generic;

namespace TvTDay07EF.Models;

public partial class QuanTri
{
    public int Id { get; set; }

    public string? TaiKhoan { get; set; }

    public string? MatKhau { get; set; }

    public byte? TrangThai { get; set; }
}
