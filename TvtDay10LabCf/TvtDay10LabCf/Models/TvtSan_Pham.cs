using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TvtDay10LabCf.Models;

namespace TvtDay10LabCf.Models;
[Table("TvtSan_Pham")]
public class TvtSan_Pham
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long tvtId { get; set; }

    [Display(Name = "Mã sản phẩm")]
    public string tvtMaSanPham { get; set; }

    [Display(Name = "Tên sản phẩm")]
    public string tvtTenSanPham { get; set; }

    [Display(Name = "Hình ảnh")]
    public string tvtHinhAnh { get; set; }

    [Display(Name = "Số lượng")]
    public int tvtSoLuong { get; set; }

    [Display(Name = "Đơn giá")]
    [Column(TypeName = "decimal(18,2)")]
    public decimal tvtDonGia { get; set; }

    // Đặt lại tên khóa ngoại cho rõ ràng
    [ForeignKey(nameof(TvtLoai_San_Pham))]
    [Display(Name = "Mã loại")]
    public long tvtLoaiId { get; set; }
    [Display(Name = "Trạng thái")]
    public bool tvtTrangThai { get; set; }

    // Navigation property
    [Display(Name = "Loại sản phẩm")]
    public TvtLoai_San_Pham? TvtLoai_San_Pham { get; set; }
}
