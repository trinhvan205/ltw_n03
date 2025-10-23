using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TvtDay10LabCf.Models;
namespace TvtDay10LabCf.Models;

[Table("TvtLoai_San_Pham")]
    public class TvtLoai_San_Pham
    {
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public long tvtId { get; set; }

    [Display(Name = "Mã loại")]
    [StringLength(10)]
    public string tvtMaLoai { get; set; }

    [Display(Name = "Tên loại")]
    [StringLength(100)]
    public string tvtTenLoai { get; set; }

    [Display(Name = "Trạng thái")]
    public bool tvtTrangThai { get; set; }

    // Navigation property
    public virtual ICollection<TvtSan_Pham>? TvtSan_Phams { get; set; }
    }
